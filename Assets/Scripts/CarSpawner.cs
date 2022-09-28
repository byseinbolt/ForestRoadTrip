using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
   
    [SerializeField] private Car _car;
    
    [SerializeField] private Transform _parent;
    

    private void Awake()
    {
        Instantiate(_car, _parent);
    }
}
