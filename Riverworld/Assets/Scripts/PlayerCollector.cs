using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollector : MonoBehaviour
{
    // Declaring variables
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text timerText;
    public int targetScore = 10;
    public int highScore;
    public float timer = 0;
    public float timerDuration;
    public bool runTimer = false;
    public bool isStartLevel;

    // Singleton instance
    public static PlayerCollector instance;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object across scenes
        }
        else
        {
            instance.transform.position = transform.position;
            instance.transform.rotation = transform.rotation;
            instance.scoreText = scoreText;
            instance.highScoreText = highScoreText;
            instance.timerText = timerText;
            instance.runTimer = runTimer;
            instance.timer = timerDuration;
            if (isStartLevel)
            {
                instance.score = 0;
            }

            Destroy(gameObject);  // Destroy the duplicate
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            Destroy(gameObject); // Clean up when returning to main menu
        }
    }

    void Update()
    {
        Debug.Log(score);

        if (targetScore == score)
        {
            targetScore *= 10;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (runTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            score++;
            AudioManager.PlayTwinkle();
            if (score > highScore)
            {
                highScore = score;
            }
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Lilies: " + score;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;

        if (timerText != null)
        {
            timerText.text = "Time Left: " + timer.ToString("F1");
            timerText.gameObject.SetActive(runTimer);
        }
    }
}


