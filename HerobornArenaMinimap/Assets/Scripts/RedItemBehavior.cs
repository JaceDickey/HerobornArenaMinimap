using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItemBehavior : MonoBehaviour
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
            Debug.Log("Stamina doubled!");

            PlayerBehavior.redStaminaPickedUp();
            gameManager.PrintLootReport();
        }
    }
}