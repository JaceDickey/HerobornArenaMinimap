using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpeningWallScript : MonoBehaviour
{
    public static bool destroyThis = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyThis == true)
        {
            Destroy(gameObject);
        }
    }

    public static void destroy()
    {
        destroyThis = true;
    }
}
