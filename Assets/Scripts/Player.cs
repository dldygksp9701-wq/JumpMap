using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerController controller;
   
    void Start()
    {
        CharacterManager.instance.player = this;
        controller = GetComponent<PlayerController>();
    }

    
    void Update()
    {
        
    }
}
