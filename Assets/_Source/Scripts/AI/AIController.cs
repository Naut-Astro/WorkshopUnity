using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour{

    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTransform;

    [Header("Scripts References")]
    private AIStates AIStatesScript;
    private AICombat AICombatScript;
    private AIMovement AIMovementScript;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("References Check")]
    [SerializeField] private bool referencesOK;

    public void Init(EnemyScriptable pBrain){

        referencesOK = false;

        AIStatesScript = GetComponent<AIStates>();
        AICombatScript = GetComponent<AICombat>();
        AIMovementScript = GetComponent<AIMovement>();

        brain = pBrain;

        AICombatScript.Init(brain);

        instantiateGFX();
        findPlayer();

        referencesOK = true;

    }

    void Update(){

        if (referencesOK == false) return;
        if (playerTransform == null) return;

        if(AIStatesScript.States == AIStateType.chasing){

            chaseBehaviour();
            return;
        }
        if(AIStatesScript.States == AIStateType.attacking){

            attackBehaviour();
            return;
        }

    }

    void chaseBehaviour(){
        var success = AIMovementScript.Chase(playerTransform);

        if(success == false){
            AIStatesScript.ChangetoState(AIStateType.attacking);
        }
    }

    void attackBehaviour(){
        var success = AICombatScript.CheckandAttack(playerTransform);

        if(success == false){
            AIStatesScript.ChangetoState(AIStateType.chasing);
        }
    }

    void instantiateGFX(){
        Instantiate(brain.GFX, GFXTransform);
    }

    void findPlayer(){

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

}
