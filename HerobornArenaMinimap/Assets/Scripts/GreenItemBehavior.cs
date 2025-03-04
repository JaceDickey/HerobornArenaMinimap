using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        // 2                 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
     }
    // 1
    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(this.transform.parent.gameObject);

            PlayerBehavior.greenJumpPickedUp();
            gameManager.PrintLootReport();
        }
    }
}