using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft{ get { return facingLeft;} set {facingLeft = value;}}

    public static PlayerController Instance;
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;

    private Rigidbody2D rb;
    private Animator myAnimator;

    private SpriteRenderer spriteRenderer;

    private bool facingLeft = false;

    
    private void Awake() {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnEnable() {
        playerControls.Enable();
    }
    

    private void FixedUpdate() {
        adjustPlayerFaceDirection();
        Move();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput(){
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY",movement.y);
    }

    private void Move(){
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void adjustPlayerFaceDirection(){
        Vector3 mousepos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousepos.x < playerScreenPoint.x) {
            //flip position of sprite
            spriteRenderer.flipX = true;
            FacingLeft = true;
        }else{
            spriteRenderer.flipX = false;
            FacingLeft = false;
        }
    }
}
