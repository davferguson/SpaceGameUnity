using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image image;
    [HideInInspector] public Item item;

    public void InitializeItem(Item newItem){
        item = newItem;
        image.sprite = newItem.icon;
    }
}
