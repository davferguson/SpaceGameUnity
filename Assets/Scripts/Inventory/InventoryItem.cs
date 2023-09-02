using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI countText;
    [HideInInspector] public Item item;
    private int count = 1;

    public void InitializeItem(Item newItem){
        item = newItem;
        image.sprite = newItem.icon;
        RefreshCount();
    }

    public void RefreshCount() {
        countText.text = count.ToString();
    }

    public void IncreaseCount() {
        count++;
        RefreshCount();
    }
}
