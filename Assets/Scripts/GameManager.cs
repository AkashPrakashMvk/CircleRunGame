using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Static instance of the GameManager to make it accessible from other scripts

    private void Awake()
    {
        if (Instance == null)  // Check if the instance is null
        {
            Instance = this;  // Set the instance to this GameManager
            Init();  // Initialize the GameManager
            DontDestroyOnLoad(gameObject);  // Prevent the GameManager from being destroyed when loading new scenes
            return;
        }
        else
        {
            Destroy(gameObject);  // If an instance already exists, destroy this GameManager to ensure only one instance is maintained
        }
    }

    private string highScoreKey = "HighScore";  // Key for storing/retrieving the high score value in PlayerPrefs

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);  // Get the high score value from PlayerPrefs, defaulting to 0 if it doesn't exist
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);  // Set the high score value in PlayerPrefs
        }
    }

    public int CurrentScore { get; set; }  // Property to store the current score

    public bool IsInitialized { get; set; }  // Property to track whether the game is initialized

    private void Init()
    {
        CurrentScore = 0;  // Initialize the current score to 0
        IsInitialized = false;  // Set the game initialization status to false
    }

    private const string MainMenu = "MainMenu";  // Scene name for the main menu
    private const string Gameplay = "Gameplay";  // Scene name for the gameplay

    public void GotoMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);  // Load the main menu scene
    }

    public void GotoGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);  // Load the gameplay scene
    }
}
