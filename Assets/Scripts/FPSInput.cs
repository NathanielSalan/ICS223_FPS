using UnityEngine;
//using UnityEngine.Windows;

public class FPSInput : MonoBehaviour
{
    private float speed = 9.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizonInput, 0, verticalInput) * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
