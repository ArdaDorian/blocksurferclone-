using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    internal int diamondCount;

    public static LevelManager instance;

    internal int movementStatues=0;

    private void Awake()
    {
        instance = this;
    }
    
}
