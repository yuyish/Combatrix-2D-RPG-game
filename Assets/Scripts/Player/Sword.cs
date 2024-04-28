using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private Transform weaponCollider;

    [SerializeField] private float attackCoolDownTime = .2f;
    private PlayerControls playerControl;

    private Animator myAnimator;

    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

    private bool attackButtonDown,isAttacking = false;

    private void Awake() {
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log(playerController);
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        playerControl = new PlayerControls();
        myAnimator = GetComponent<Animator>();

    }

    private void OnEnable() {
        playerControl.Enable();
    }

    private void Start() {
        playerControl.Combat.Attack.started += _ => startAttacking();
        playerControl.Combat.Attack.canceled += _ => stopAttacking();
    }

    private void Update() {
        Attack();
        mouseFollowWithOffset();
    }

    private void startAttacking(){
        attackButtonDown = true;
    }

    private void stopAttacking(){
        attackButtonDown = false;
    }

    private void Attack(){
        if(attackButtonDown && !isAttacking){
            isAttacking = true;
            myAnimator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab,slashAnimSpawnPoint.position,Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            StartCoroutine(attackCooldownRoutine());
        }
    }

    private void attackingStoppedAnimEvent(){
        weaponCollider.gameObject.SetActive(false);
    }

    public void swingUpFlipSlashAnimEvent(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180,0,0);
        
        if(playerController.FacingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void swingDownFlipSlashAnimEvent(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        
        if(playerController.FacingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void mouseFollowWithOffset(){
        Vector3 mousepos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);


        // float angle = Mathf.Atan2(mousepos.y,mousepos.x) * Mathf.Rad2Deg;

        if(mousepos.x < playerScreenPoint.x){
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180,0);
            weaponCollider.rotation = Quaternion.Euler(0, -180,0);
        }else{
            activeWeapon.transform.rotation = Quaternion.Euler(0,0,0);
            weaponCollider.rotation = Quaternion.Euler(0, 0,0);
        }
            
    }

    private IEnumerator attackCooldownRoutine(){
        yield return new WaitForSeconds(attackCoolDownTime);
        isAttacking = false;
    }

    
}
