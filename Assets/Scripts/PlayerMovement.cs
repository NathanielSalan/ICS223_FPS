using UnityEngine;
[RequireComponent (typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    float hInput;
    float vInput;
    Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Directional Inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        // Speed
        float speed = 5.0f;
        Vector3 movement = new Vector3(hInput, 0, vInput) * speed;

        // Regular Technique
        //transform.Translate (movement);

        // Move Position Technique
        //Vector3 newPosition = rb.position + movement;
        //rb.MovePosition(newPosition);

        // Add Force Technique
        //Vector3 forceMovement = new Vector3(hInput, 0, vInput);
        //rb.AddForce(forceMovement * 20f);

        rb.linearVelocity = movement;
    }


}
