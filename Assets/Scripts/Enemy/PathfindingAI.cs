using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Vector2 moveDirection;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    public void moveTo(Vector2 targetPos){
        moveDirection = targetPos;
    }
}

