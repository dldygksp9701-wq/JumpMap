using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string GetInteratPrompty();
    void OnInteract();
}


public class ItemDataObject : MonoBehaviour , IInteractable
{
    public ItemData data; 
   
    public string GetInteratPrompty()
    {
        string str = $"{data.itemName} \n {data.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.instance.player.itemdata = data;
        CharacterManager.instance.player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
//아이템 데이터 호출
