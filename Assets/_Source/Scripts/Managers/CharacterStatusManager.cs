using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamageable{
    
    public Status status;

    public event Action OnTakeDamage;

    public void Start(){
        status.init();
    }

    public void Update(){
        
        if(Input.GetKeyDown(KeyCode.K)){
            takeDamage(Random.Range(0,5));
        }

    }

    public void takeDamage(int amount){

        Debug.Log("Tomando " + amount + " de DANO!");
        status.health -= amount;
        OnTakeDamage?.Invoke();

        if(status.health <= 0){
           die();
        }

    }

    public void die(){
         Destroy(this.gameObject);
    }

}
