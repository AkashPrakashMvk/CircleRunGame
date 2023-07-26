using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private bool hasGameFinished;  // Flag to indicate if the game has finished

    [SerializeField] private TMP_Text _scoreText;  // Reference to the TMP_Text component for displaying the score

    private float score;  // Current score of the player
    private float scoreSpeed;  // Speed at which the score increases
    private int currentLevel;  // Current level of the game

    [SerializeField] private List<int> _levelSpeed, _levelMax;  // Lists to store the speed and maximum score for each level

    private void Awake()
    {
        GameManager.Instance.IsInitialized = true;  // Set the GameManager's IsInitialized flag to true

        score = 0;  // Initialize the score to zero
        currentLevel = 0;  // Start at level 0
        _scoreText.text = ((int)score).ToString();  // Display the initial score as text

        scoreSpeed = _levelSpeed[currentLevel];  // Set the initial score speed based on the current level
    }

    private void Update()
    {
        if (hasGameFinished) return;  // If the game has finished, exit the Update function

        score += scoreSpeed * Time.deltaTime;  // Increase the score based on the score speed and time elapsed

        _scoreText.text = ((int)score).ToString();  // Update the score text

        if (score > _levelMax[Mathf.Clamp(currentLevel, 0, _levelMax.Count - 1)])
        {
            // If the score surpasses the maximum score for the current level, advance to the next level
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, _levelMax.Count - 1);
            scoreSpeed = _levelSpeed[currentLevel];  // Update the score speed based on the new level
        }
    }

    public void GameEnded()
    {
        hasGameFinished = true;  // Set the game finished flag to true
        GameManager.Instance.CurrentScore = (int)score;  // Set the GameManager's CurrentScore to the final score

        StartCoroutine(GameOver());  // Start the game over coroutine
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);  // Wait for 2 seconds

        GameManager.Instance.GotoMainMenu();  // Go back to the main menu using the GameManager
    }
}
