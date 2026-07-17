using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] Button restart;
    private int score;
    private int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        score = 0;

        UpdateScore();
        UpdateHighScore();

        GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>().PlayMusic(); // music seamlessly continues when restarting
    }

    public void AddPoints(int pts) // adds the points to the score and updates the UI
    {
        score += pts;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "High score : " + highScore;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score); // in the end of the game the highscore is checked and updated if > than the old one
        }

        restart.gameObject.SetActive(true); // the restart button is showed
    }
}
