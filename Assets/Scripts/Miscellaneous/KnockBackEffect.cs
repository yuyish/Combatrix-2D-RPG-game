using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float knockbackTime = .2f;

    //to check wether knockback should be used
    public bool getKnocked{get; private set;}

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void getKnockedBack(Transform damageSource,float thrust){
        getKnocked = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * rb.mass * thrust;
        rb.AddForce(difference,ForceMode2D.Impulse);
        StartCoroutine(knockBackRoutine());
    }

    private IEnumerator knockBackRoutine(){
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        getKnocked = false;
    }
}
