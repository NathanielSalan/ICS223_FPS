using UnityEngine;
//using UnityEngine.Windows;

public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    private float speed = 9.0f;
    private CharacterController charController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizonInput, 0, verticalInput);

        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        // take speed into account
        movement *= speed;

        // Add gravity
        movement.y = gravity;

        // make movement processor independent
        movement *= Time.deltaTime;

        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }
}
