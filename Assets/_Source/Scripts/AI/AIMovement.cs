using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour{

    private NavMeshAgent nav;

    void Start(){

        nav = GetComponent<NavMeshAgent>();

    }

    public bool Chase(Transform target){

        if (!target) return false;

        if (Vector3.Distance(transform.position, target.position) > nav.stoppingDistance){
            
            nav.SetDestination(target.position);
            return true;

        }
        return false;
    }

}
