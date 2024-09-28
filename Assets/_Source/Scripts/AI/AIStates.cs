using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIStates : MonoBehaviour{

    public AIStateType States;

    public void ChangetoState(AIStateType state){

        if(States == state) return;

        //Quaisquer outros efeitos de troca de estado vem aqui

        States = state;

    }

}
