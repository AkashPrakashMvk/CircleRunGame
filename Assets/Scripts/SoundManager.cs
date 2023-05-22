using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // Static instance of the SoundManager to make it accessible from other scripts

    private void Awake()
    {
        if (Instance == null)  // Check if the instance is null
        {
            Instance = this;  // Set the instance to this SoundManager
            DontDestroyOnLoad(gameObject);  // Prevent the SoundManager from being destroyed when loading new scenes
            return;
        }
        else
        {
            Destroy(gameObject);  // If an instance already exists, destroy this SoundManager to ensure only one instance is maintained
        }
    }

    [SerializeField] private AudioSource _effectSource;  // Reference to the AudioSource component for playing sound effects

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);  // Play the provided audio clip as a one-shot sound effect
    }
}
