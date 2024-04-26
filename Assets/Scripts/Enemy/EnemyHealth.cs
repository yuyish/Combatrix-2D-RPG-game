using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;


    private void Start() {
        currentHealth = startingHealth;
    }

    public void takeDamage(int damageAmount){
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);
        detectDeathEnemy();
    }

    public void detectDeathEnemy(){
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
