using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/TileData")]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;
    public String contents;
}
