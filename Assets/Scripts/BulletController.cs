using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public bool isEnemyBullet = false;

    private Vector2 lastPos;
    private Vector2 curPos;
    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelay());
        if (!isEnemyBullet) {
            transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyBullet) {
            curPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
            if (curPos == lastPos) {
                Destroy(gameObject);
            }
            lastPos = curPos;
        }
    }

    public void GetPlayer(Transform player) {
        playerPos = player.position;
    }

    IEnumerator DestroyDelay() {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && !isEnemyBullet) {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }

        if (col.tag == "Player" && isEnemyBullet) {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
