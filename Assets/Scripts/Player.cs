using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerController controller;
    public Condition condition;
    public ItemData itemdata;

    public Action addItem;
    private void Awake()
    {
        CharacterManager.instance.player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<Condition>();
        
        
    }
   
}
