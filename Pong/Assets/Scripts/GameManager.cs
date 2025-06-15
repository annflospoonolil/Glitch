
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerPaddle playerPaddle;
    public ComputerPaddle computerPaddle;
    public Ball ball;
    public Text playerScore;
    public Text computerScore;
    public Button startButton;
    public GameObject pauseMenuPanel;
    public Button pauseButton;
    public Button resumeButton;
    public Button restartButton;
    public GameObject winPanel;
    public GameObject losePanel;
    public Button loseplayAgainButton;
    public Button winplayAgainButton;
    private Rigidbody2D rb;
    private bool isPaused = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Time.timeScale = 0f; // Pause the game at the start
        startButton.gameObject.SetActive(true);
        startButton.onClick.AddListener(StartGame);

        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
    public void StartGame()
    {
        Time.timeScale = 1f; // Resume the game
        startButton.gameObject.SetActive(false);
        Resetround();
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        pauseMenuPanel.SetActive(false);
    }
    private void TogglePause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
    }
    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }
    private void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Resetround();
        _playerScore = 0;
        _computerScore = 0;
        playerScore.text = "0";
        computerScore.text = "0";
    }



    private int _playerScore;
    private int _computerScore;
    public void PlayerScores()
    {
        _playerScore++;
        this.playerScore.text = _playerScore.ToString();
        Debug.Log("Player Score: " + _playerScore);
        if (_playerScore >= 10)
    {
        WinGame();
    }
    else
    {
        Resetround();
    }
    }
    public void ComputerScores()
    {
        _computerScore++;
        this.computerScore.text = _computerScore.ToString();
        Debug.Log("Computer Score: " + _computerScore);
        if (_computerScore >= 10)
        {
            LoseGame();
        }
        else
        {
            Resetround();
        }
    }
    private void LoseGame()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
        loseplayAgainButton.onClick.RemoveAllListeners();
        loseplayAgainButton.onClick.AddListener(RestartGame);
    }
    private void WinGame()
{
    Time.timeScale = 0f;
    winPanel.SetActive(true);
    winplayAgainButton.onClick.RemoveAllListeners();
    winplayAgainButton.onClick.AddListener(RestartGame);
}
    private void Resetround()
    {
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();

    }
}
