using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;  // Reference to the TMP_Text component for displaying the current score
    [SerializeField] private TMP_Text _newBestText;  // Reference to the TMP_Text component for displaying the new best score text
    [SerializeField] private TMP_Text _bestScoreText;  // Reference to the TMP_Text component for displaying the best score

    private void Awake()
    {
        _bestScoreText.text = GameManager.Instance.HighScore.ToString();  // Display the best score retrieved from the GameManager

        if (!GameManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);  // Hide the score text if the game is not initialized
            _newBestText.gameObject.SetActive(false);  // Hide the new best score text if the game is not initialized
        }
        else
        {
            StartCoroutine(ShowScore());  // Start the coroutine to animate and display the score
        }
    }

    [SerializeField] private float _animationTime;  // Duration of the score animation
    [SerializeField] private AnimationCurve _speedCurve;  // Animation curve for the score animation

    private IEnumerator ShowScore()
    {
        int tempScore = 0;  // Temporary score used for animation
        _scoreText.text = tempScore.ToString();  // Display the initial temporary score

        int currentScore = GameManager.Instance.CurrentScore;  // Get the current score from the GameManager
        int highScore = GameManager.Instance.HighScore;  // Get the best score from the GameManager

        if (highScore < currentScore)
        {
            _newBestText.gameObject.SetActive(true);  // Show the new best score text if the current score is higher
            GameManager.Instance.HighScore = currentScore;  // Update the best score in the GameManager
        }
        else
        {
            _newBestText.gameObject.SetActive(false);  // Hide the new best score text if the current score is not higher
        }

        _bestScoreText.text = GameManager.Instance.HighScore.ToString();  // Update the displayed best score

        float speed = 1 / _animationTime;  // Calculate the speed of the score animation
        float timeElapsed = 0f;  // Time elapsed since the start of the animation

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;  // Update the time elapsed
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);  // Calculate the animated score value
            _scoreText.text = tempScore.ToString();  // Update the displayed score
            yield return null;
        }

        tempScore = currentScore;  // Set the final score value
        _scoreText.text = tempScore.ToString();  // Display the final score
    }

    [SerializeField] private AudioClip _clickClip;  // Audio clip for button click sound

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);  // Play the button click sound
        GameManager.Instance.GotoGameplay();  // Start the gameplay by navigating to the gameplay scene using the GameManager
    }
}
