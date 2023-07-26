using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;  // Minimum and maximum rotation speeds for the obstacle
    private float currentRotateSpeed;  // Current rotation speed of the obstacle

    [SerializeField] private float _minRotateTime, _maxRotateTime;  // Minimum and maximum rotation times for the obstacle
    private float rotateTime;  // Total time it takes to complete a rotation
    private float currentRotateTime;  // Time elapsed since the last rotation

    private void Awake()
    {
        currentRotateTime = 0f;  // Initialize the current rotation time to zero
        currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * 0.1f * Random.Range(0, 11);  // Calculate a random rotation speed within the specified range
        rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);  // Calculate a random rotation time within the specified range
        currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;  // Randomly determine the direction of rotation (clockwise or counterclockwise)
    }

    private void Update()
    {
        currentRotateTime += Time.deltaTime;  // Update the current rotation time with the time elapsed since the last frame

        if (currentRotateTime > rotateTime)
        {
            // If the current rotation time exceeds the rotation time, it's time to rotate again
            currentRotateTime = 0f;  // Reset the rotation time
            currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * 0.1f * Random.Range(0, 11);  // Calculate a new random rotation speed
            rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);  // Calculate a new random rotation time
            currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;  // Randomly determine the direction of rotation (clockwise or counterclockwise)
        }
    }

    private void FixedUpdate()
    {
        // Rotate the obstacle around its z-axis based on the current rotation speed
        transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);
    }
}
