using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("+10 bullets!");

            PlayerBehavior.ammoPickedUp();
            gameManager.PrintLootReport();
        }
    }
}
