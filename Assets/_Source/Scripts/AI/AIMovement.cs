using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour{

    private NavMeshAgent nav;

    [Header("Enemy info")]
        public float atkRange;
        public float atkSpeed;
        public float currentAtkCooldown;
        public int[] atkDamage;
        public bool canAttack;

    [Header("Player info")]
        public Transform player;
    void Start(){

        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = atkRange;

    }

    // Update is called once per frame
    void Update(){
        
        if (player == null) return;

        Chase();

        if(Vector3.Distance(transform.position, player.position) < atkRange){

            if(canAttack){
                Attack();
            }else{

                currentAtkCooldown -= Time.deltaTime;

                if(currentAtkCooldown <= 0){
                    currentAtkCooldown = atkSpeed;
                    canAttack = true;
                }

            }

        }
        
        

    }

    void Chase(){
        nav.SetDestination(player.position);
    }

    void Attack(){

        canAttack = false;

        player.GetComponent<IDamageable>().takeDamage(Random.Range(atkDamage[0],atkDamage[1]));

    }

}
