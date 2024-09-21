using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status{
    
    public int health;
    public int armor;
    public int magicResist;

    public void init(){

        health = 100;
        armor = 10;
        magicResist = 15;

    }
    
}
