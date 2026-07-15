using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;
    private int highScore;
    public Button restart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        score = 0;

        updateScore();
        updateHighScore();

        GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>().PlayMusic(); // music seamlessly continues when restarting
    }

    public void addPoints(int pts)
    {
        score += pts;
        updateScore();
    }

    public void updateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void updateHighScore()
    {
        highScoreText.text = "High score : " + highScore;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score); // in the end of the game the highscore is checked and updated if > than the old one
        }

        restart.gameObject.SetActive(true); // the restart button is showed
    }
}
