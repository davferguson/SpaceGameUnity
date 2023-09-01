using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public TileBase tile;
    public Sprite icon;
    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int buildRange = new Vector2Int(5,5);
}

public enum ItemType{
    Building,
    Resource,
    Tool
}

public enum ActionType{
    Mine,
    Place
}