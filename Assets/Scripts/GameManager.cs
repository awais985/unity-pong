using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;
    [SerializeField] private PaddleMovement paddleMovement;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AIPaddle aIPaddle;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private GameObject mainMenuPanel;
    private bool isGameOver;

    void Start()
    {
        GameOverPanel(false);
        MainMenuPanel(true);
    }
    public void GameOver(string winner)
    {
        isGameOver = true;
        ResetGame();
        GameOverPanel(true);
        winnerText.text = winner;

    }

    public void RestartGame()
    {
        isGameOver = false;
        scoreManager.ResetScore();
        GameOverPanel(false);
        StartGame();
    }

    public void StartGame()
    {
        ballMovement.LaunchBall();
        paddleMovement.StartPaddle();
        aIPaddle.StartPaddle();
    }

    public void ResetGame()
    {
        ballMovement.StopBall();
        ballMovement.ResetBall();
        paddleMovement.StopPaddle();
        paddleMovement.ResetPaddle();
        aIPaddle.StopPaddle();
        aIPaddle.ResetPaddle();
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GameOverPanel(bool toggle)
    {
        gameOverPanel.SetActive(toggle);
    }
    public void MainMenuPanel(bool toggle) {
        gameOverPanel.SetActive(false);
        if (toggle) { 
        ResetGame();
        }
        else if(!toggle)
        {
            StartGame();
        }
            mainMenuPanel.SetActive(toggle);
    }
}
