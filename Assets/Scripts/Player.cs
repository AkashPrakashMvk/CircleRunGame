using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;  // Rotation speed of the player
    [SerializeField] private AudioClip _moveClip, _loseClip;  // Audio clips for player movement and losing the game

    [SerializeField] private GameplayManager _gm;  // Reference to the GameplayManager script
    [SerializeField] private GameObject _explosionPrefab;  // Prefab for the explosion effect

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySound(_moveClip);  // Play the movement sound
            _rotateSpeed *= -1f;  // Reverse the rotation speed to change direction
        }    
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);  // Rotate the player based on the rotation speed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(_explosionPrefab, transform.GetChild(0).position, Quaternion.identity);  // Instantiate the explosion effect at a specific position
            SoundManager.Instance.PlaySound(_loseClip);  // Play the losing sound
            _gm.GameEnded();  // Call the GameEnded() method in the GameplayManager
            Destroy(gameObject);  // Destroy the player object
        }
    }
}
