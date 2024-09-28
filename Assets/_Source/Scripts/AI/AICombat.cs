using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour
{

    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAtkCooldown;

    private NavMeshAgent nav;


    public void Init(EnemyScriptable pBrain){

        brain = pBrain;

        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = brain.atkRange;

    }

     public bool CheckandAttack(Transform target){

        cooldownRecovery();

        if(Vector3.Distance(transform.position, target.position) < brain.atkRange){

            if(canAttack){
                Attack(target);
            }

            return true;

        }

        return false;

    }

    public void cooldownRecovery(){

        currentAtkCooldown -= Time.deltaTime;

        if(currentAtkCooldown <= 0){
            currentAtkCooldown = brain.atkSpeed;
            canAttack = true;
        }

    }
    void Attack(Transform target){

        canAttack = false;

        target.GetComponent<IDamageable>().takeDamage(Random.Range(brain.atkDamage[0],brain.atkDamage[1]));

    }
}
