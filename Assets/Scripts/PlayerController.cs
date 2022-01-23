using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireDelay;
    private float lastFire;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Player Shooting
        float shootHorizontal = Input.GetAxis("ShootHorizontal");
        float shootVeritcal = Input.GetAxis("ShootVertical");

        if ((shootHorizontal != 0 || shootVeritcal != 0) && Time.time > lastFire + fireDelay) {
            Shoot(shootHorizontal, shootVeritcal);
            lastFire = Time.time;
        }

        rb2d.velocity = new Vector3(moveHorizontal * speed, moveVertical * speed, 0);

        fireDelay = GameController.FireRate;
        speed = GameController.MoveSpeed;
    }

    // Shoot method to spawn bullet
    void Shoot(float x, float y) {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3((x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                                                                  (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                                                                  0);
    }
}
