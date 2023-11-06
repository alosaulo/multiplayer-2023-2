using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    [SerializeField]
    int HealthPoints;

    [SerializeField]
    int MagicPoints;

    public void TakeDamage() 
    { 
        
    }

    public void TakeDamage(float damage) 
    { 
        
    }

    public void TakeDamage(int damage) 
    {
        HealthPoints -= damage;
    }

    public bool isDead() 
    { 
        return HealthPoints > 0;
    }

}
