using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int health;

    [SerializeField] private Image healthbar;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }

    public void Hit()
    {
        health -= 1;
        Debug.Log("Health: " + health);

        float healthPercentage = (float)health / (float)maxHealth;

        Debug.Log("Health %: " + healthPercentage);

        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);

        if (health == 0)
        {
            Debug.Break();
        }
    }

    public void OnHealthChanged(float percentage)
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, percentage);

        healthbar.fillAmount = percentage;
        healthbar.color = healthColor;
    }
}
