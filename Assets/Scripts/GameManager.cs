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

        GameObject.Find("MusicClass").GetComponent<MusicClass>().PlayMusic();
    }

    public void addPoints(int n)
    {
        score += n;
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
            PlayerPrefs.SetInt("highscore", score); // à la fin du jeu on vérifie si c'est le meilleur score
        }

        restart.gameObject.SetActive(true); // on affiche le bouton restart
    }
}
