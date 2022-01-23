using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    private GameObject hidden;

    // Start is called before the first frame update
    void Start()
    {
        hidden = GameObject.Find("LockedDoors");
        hidden.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hidden.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        hidden.SetActive(true);
    }


}
