using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int durability = 5;

    public void Speak(){
        print("Durability: " + durability);
    }
}
