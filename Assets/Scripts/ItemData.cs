using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    JumpUp,
    Buff
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public string description;
    public ItemType type;
    public int maxStackMount;
    public float coolTime;

}
