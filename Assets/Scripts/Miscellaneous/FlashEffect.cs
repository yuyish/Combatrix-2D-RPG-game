using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Material flashMat;

    [SerializeField] private float resetFlashMatTime = .2f;

    private Material defaultMat; //to restore default material of sprite after certain flash time
    private SpriteRenderer spriteRenderer;
    

    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }

    public IEnumerator flashEffectRoutine(){
        spriteRenderer.material = flashMat; //changed the material to white flash
        yield return new WaitForSeconds(resetFlashMatTime);
        spriteRenderer.material = defaultMat; //restored to default material of the sprite
    }

    public float getResetFlashTime(){
        return resetFlashMatTime;
    }

    
}
