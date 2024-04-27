using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private ParticleSystem particleSystem; // we want to remove the vfx after the firing of particles are done

    private void Awake() {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update() {
        if(particleSystem && !particleSystem.IsAlive()){ //this checks if the particle system is present if so checks if all particles are fired if complete destroys it
            destroySelf();
        }
    }
    public void destroySelf(){
        Destroy(gameObject);
    }
}
