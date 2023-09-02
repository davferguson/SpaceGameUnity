using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/TileData")]
public class TileData : RuleTile
{
    public Item item;
    public TileBase[] tiles;
    public String contents;
    public int durability;
}
