using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start() {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth = currentHealth - damage;
        healthBar.setHealth(currentHealth);
    }

}
