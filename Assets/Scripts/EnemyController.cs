using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum State{
        Roaming
    }

    private State state;
    private PathfindingAI enemyPathfinding;

    private void Start() {
        StartCoroutine(RoamingCoroutine());
    }
    private void Awake() {
        state = State.Roaming;
        enemyPathfinding = GetComponent<PathfindingAI>();
    }

    private IEnumerator RoamingCoroutine(){
        while(state == State.Roaming){
            Vector2 roamingPosition = getRoamingPosition();
            enemyPathfinding.moveTo(roamingPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 getRoamingPosition(){
        return new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
    }
}
