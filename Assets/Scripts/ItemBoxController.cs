using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxController : MonoBehaviour
{
    public GameObject[] itemList;

    public Vector3 moveDirection;

    bool hasSpawned = false;

    SpriteRenderer renderer;
    Sprite open;
    Sprite closed;

    Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    private void Start()
    {
        renderer = GameObject.Find("Chest").GetComponent<SpriteRenderer>();
        open = Resources.Load<Sprite>("Chest_Open");
        closed = Resources.Load<Sprite>("Chest_Closed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            if (!hasSpawned) {
                Spawn();
                hasSpawned = true;
                renderer.sprite = open;
                moveDirection = rb.transform.position - other.transform.position;
                rb.AddForce(moveDirection.normalized * -1000f);
            }
        }
    }

    void Spawn() {
        Instantiate(itemList[Random.Range(0, itemList.Length)], transform.position, Quaternion.identity);
        Debug.Log("Spawned!");
    }
}
