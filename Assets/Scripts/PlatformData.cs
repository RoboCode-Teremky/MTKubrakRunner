using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour
{
    public int CountBonuses(){
        int sum=0;
        foreach (Bonus bonus in GetComponentsInChildren<Bonus>())
        {
            if(bonus.value>0)
                sum += bonus.value;
        }
        return sum;
        
    }
}
