using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    private PlayerControls playerControl;

    private Animator myAnimator;

    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

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
        playerControl.Combat.Attack.started += _ => Attack() ;
    }

    private void Update() {
        mouseFollowWithOffset();
    }

    private void Attack(){
        myAnimator.SetTrigger("Attack");
        slashAnim = Instantiate(slashAnimPrefab,slashAnimSpawnPoint.position,Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
    }

    public void swingUpFlipSlashAnim(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180,0,0);
        
        if(playerController.FacingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void swingDownFlipSlashAnim(){
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        
        if(playerController.FacingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void mouseFollowWithOffset(){
        Vector3 mousepos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);


        float angle = Mathf.Atan2(mousepos.y,mousepos.x) * Mathf.Rad2Deg;

        if(mousepos.x < playerScreenPoint.x){
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180,0);
        }else{
            activeWeapon.transform.rotation = Quaternion.Euler(0,0,0);
        }
            
    }

    
}
