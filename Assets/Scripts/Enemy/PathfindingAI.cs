using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private KnockBackEffect knockBackEffect;

    private Vector2 moveDirection;

    private Rigidbody2D rb;

    private void Awake() {
        knockBackEffect = GetComponent<KnockBackEffect>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        //as the object was getting moved in each frame the knockback effect was overwrite so with help of boolean property we check if to knockback or move 
        if(knockBackEffect.getKnocked){return;};
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void moveTo(Vector2 targetPos){
        moveDirection = targetPos;
    }
}

