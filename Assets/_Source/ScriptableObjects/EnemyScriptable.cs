using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyData", order = 0)]

public class EnemyScriptable : ScriptableObject{
    
    [Header("Data")]
    public Status status;

    [Header("Combat")]
    public float atkRange;
    public float atkSpeed;
    public int[] atkDamage;

    [Header("GFX")]
    public GameObject GFX;

}
