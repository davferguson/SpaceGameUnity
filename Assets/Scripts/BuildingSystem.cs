using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private TileBase highlightedTile;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private Tilemap tempTilemap;
    [SerializeField] private GameObject lootPrefab;

    private Vector3Int playerPos;
    private Vector3Int highlightedTilePos;
    private bool isHighlighted;

    private void Update(){
        playerPos = mainTilemap.WorldToCell(transform.position);

        if(item != null){
            HighlightTile(item);
        }

        if(Input.GetMouseButtonDown(0)){
            if(isHighlighted){
                if(item.itemType == ItemType.Tool){
                    BreakTile(highlightedTilePos);
                }
            }
        }
    }

    private void HighlightTile(Item currentItem){
        Vector3Int mouseGridPos = GetMouseOnGridPos();

        if(highlightedTilePos != mouseGridPos){
            tempTilemap.SetTile(highlightedTilePos, null);
            highlightedTilePos = mouseGridPos;

            if(InRange(playerPos, mouseGridPos, (Vector3Int)currentItem.buildRange)){
                if(CheckCondition(mainTilemap.GetTile<TileData>(mouseGridPos), currentItem)){
                    tempTilemap.SetTile(mouseGridPos, highlightedTile);
                    highlightedTilePos = mouseGridPos;

                    isHighlighted = true;
                } else {
                    isHighlighted = false;
                }
            } else{
                isHighlighted = false;
            }

        }
    }

    private Vector3Int GetMouseOnGridPos() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mouseCellPos = mainTilemap.WorldToCell(mousePos);
        mouseCellPos.z = 0;

        return mouseCellPos;
    }
    private bool InRange(Vector3Int positionA, Vector3Int positionB, Vector3Int range){
        Vector3Int distance = positionA - positionB;
        if(Math.Abs(distance.x) >= range.x || Math.Abs(distance.y) >= range.y){
            return false;
        }
        return true;
    }

    private bool CheckCondition(TileData tileData, Item currentItem){
        if(currentItem.itemType == ItemType.Building){
            if(!tileData){
                return true;
            }
        } else if(currentItem.itemType == ItemType.Tool){
            if(tileData){
                if(tileData.item.actionType == currentItem.actionType){
                    return true;
                }
            }
        }
        return false;
    }

    private void BreakTile(Vector3Int position){
        tempTilemap.SetTile(position, null);
        isHighlighted = false;

        TileData tileData = mainTilemap.GetTile<TileData>(position);
        mainTilemap.SetTile(position, null);

        Vector3 centerPos = mainTilemap.GetCellCenterWorld(position);
        GameObject loot = Instantiate(lootPrefab, centerPos, Quaternion.identity);
        loot.GetComponent<LootController>().Initialize(tileData.item);
    }
}
