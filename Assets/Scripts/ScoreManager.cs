    using TMPro;
    using UnityEngine;
using UnityEngine.SceneManagement;

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI leftPaddleScoreText;
        [SerializeField] private TextMeshProUGUI rightPaddleScoreText;
        [SerializeField] private int winScore = 10;
        [SerializeField] private GameManager gameManager;
        private int leftScore;
        private int rightScore;

    public void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
        leftPaddleScoreText.text = "Score: " + leftScore.ToString();
        rightPaddleScoreText.text = "Score: " + rightScore.ToString();
    }

    public void increaseLeftPaddleScore()
        {
            leftScore++;

            leftPaddleScoreText.text = "Score: " + leftScore.ToString();
            if(leftScore >= winScore)
            {
                gameManager.GameOver("Player Won");
            }

        }
        public void increaseRightPaddleScore()
        {
            rightScore++;

            rightPaddleScoreText.text = "Score: " + rightScore.ToString();
        
            if (rightScore >= winScore)
            {
              gameManager.GameOver("Computer Won");
            }
    }
   

    }
