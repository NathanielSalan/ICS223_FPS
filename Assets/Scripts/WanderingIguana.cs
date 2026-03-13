using UnityEngine;

public class WanderingIguana : MonoBehaviour
{
    private float iguanaSpeed = 3.0f;
    private float obstacleRange = 9.0f;
    private Animator anim;
    private float turn = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if we are headed for an obstacle
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Test Collisions
        if(Physics.SphereCast(ray, 0.5f, out hit))
        {
            // if turn value is not set to 0: Decide on left or right turn
            if (hit.distance < obstacleRange)
            {
                if (Mathf.Approximately(turn, 0.0f))
                {
                    // 0 = left, 1 = right
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f;

                }

                // Move with a turn
                Move(turn, 0.1f);
            }
            else // no obstacle: move forward
            {
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f;

                Move(turn, forwardSpeed);
            }
        }
        
    }

    private void Move(float turn, float forward)
    {
        float dampTime = 0.2f;
        if (anim != null)
        {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);
            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        }
    }
}
