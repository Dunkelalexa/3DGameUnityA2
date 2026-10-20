using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    private int _winScore = 100;

    public TextMeshProUGUI uiScoreText;

    public TextMeshProUGUI uiHealthText;

    public static GameManager Instance { get; private set; }               //singleton, the private set protects the variable, static means it is shared with all instances of the class

    public void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        uiScoreText.text = _score.ToString();
    }


    public void UpdateHealthUI(int health)
    {
        uiHealthText.text= health.ToString();
    }

    public void IncreaseScoreAndUpdateUI(int score)
    {
        _score += score;
        uiScoreText.text = _score.ToString();

        if (_score >= _winScore) 
        {
            WinGame();
        }
    }


    public void GameOver()                                               // Launches the game over menu when you lose
    {
        SceneManager.LoadScene("GameOverMenu");
    }

    public void WinGame()                                               // Launches the win menu when hit 100 points
    {
        SceneManager.LoadScene("WinMenu");
    }
}
