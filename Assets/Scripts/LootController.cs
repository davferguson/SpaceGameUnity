using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private CircleCollider2D collider;
    [SerializeField] private float moveSpeed;

    private Item item;

    public void Initialize(Item item){
        this.item = item;
        sr.sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            StartCoroutine(MoveAndCollect(other.transform));
        }
    }

    private IEnumerator MoveAndCollect(Transform target){
        Destroy(collider);

        while(transform.position != target.position){
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }

        Destroy(gameObject);
    }
}
