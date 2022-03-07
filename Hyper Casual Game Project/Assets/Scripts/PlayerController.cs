using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerYpos;
    void Start()
    {
        playerYpos = transform.position.y;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerYpos = -playerYpos;

            transform.position = new Vector3(transform.position.x,playerYpos,transform.position.z);
        }
    }
}
