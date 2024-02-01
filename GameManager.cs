using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Stopped,
        Running,
        Paused,
    }

    public GameState CurrentGameState { get; private set; } = GameState.Stopped;

    private void Awake()
    {
        // Ensure that there's only one instance of the GameManager in the scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed when reloading the scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        if (CurrentGameState == GameState.Stopped || CurrentGameState == GameState.Paused)
        {
            CurrentGameState = GameState.Running;
            // Initialize or reset game settings
            // For example: Reset score, player position, etc.
            Debug.Log("Game Started");
        }
    }

    public void PauseGame()
    {
        if (CurrentGameState == GameState.Running)
        {
            CurrentGameState = GameState.Paused;
            // Implement pause logic
            // For example: Stop timers, animations, etc.
            Debug.Log("Game Paused");
        }
    }

    public void ResumeGame()
    {
        if (CurrentGameState == GameState.Paused)
        {
            CurrentGameState = GameState.Running;
            // Resume paused game logic
            Debug.Log("Game Resumed");
        }
    }

    public void StopGame()
    {
        if (CurrentGameState != GameState.Stopped)
        {
            CurrentGameState = GameState.Stopped;
            // Implement game stop logic
            // For example: Show game over screen, save game state, etc.
            Debug.Log("Game Stopped");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Here you can check for global key presses, for example, to pause/resume the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (CurrentGameState == GameState.Running)
            {
                PauseGame();
            }
            else if (CurrentGameState == GameState.Paused)
            {
                ResumeGame();
            }
        }
    }
}