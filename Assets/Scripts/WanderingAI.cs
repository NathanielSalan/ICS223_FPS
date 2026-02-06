using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 3.0f;
    private float obstacleRange = 5.0f;
    private float sphereRadius = 0.75f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move Enemy
        Vector3 movement = Vector3.forward * enemySpeed * Time.deltaTime;
        transform.Translate(movement);
        // generate Ray
        Ray ray = new Ray(transform.position, transform.forward);
        // Spherecast and determine if Enemy needs to turn
        RaycastHit hit;
        if (Physics.SphereCast(ray, sphereRadius, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float turnAngle = Random.Range(-110, 110);
                transform.Rotate(Vector3.up * turnAngle);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;

        Debug.DrawLine(transform.position, rangeTest);
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }
}
