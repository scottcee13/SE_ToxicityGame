using UnityEngine;
// Updated player movement script

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed
    public float rotationSpeed = 720f; // Degrees per second for turning

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // If the GameObject doesn't have one, add it automatically
        if (controller == null)
            controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from Unity’s Input system (WASD / arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Combine into a movement direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Smoothly rotate towards movement direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime / 360f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move character forward
            Vector3 move = transform.forward * moveSpeed * Time.deltaTime;
            controller.Move(move);
        }
    }
}

