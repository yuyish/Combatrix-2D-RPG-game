using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    [SerializeField] private GameObject deathVfxPrefab;
    private int currentHealth;
    private KnockBackEffect knockBack;

    private FlashEffect flashEffect;

    private void Awake() {
        knockBack = GetComponent<KnockBackEffect>();
        flashEffect = GetComponent<FlashEffect>();
    }

    private void Start() {
        currentHealth = startingHealth;
    }

    public void takeDamage(int damageAmount){
        currentHealth -= damageAmount;
        knockBack.getKnockedBack(PlayerController.Instance.transform,14f);
        StartCoroutine(flashEffect.flashEffectRoutine());
        StartCoroutine(checkDeathEnemyRoutine());
    }

    private IEnumerator checkDeathEnemyRoutine(){
        yield return new WaitForSeconds(flashEffect.getResetFlashTime());
        detectDeathEnemy();
    }
    public void detectDeathEnemy(){
        if(currentHealth <= 0){
            Instantiate(deathVfxPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
