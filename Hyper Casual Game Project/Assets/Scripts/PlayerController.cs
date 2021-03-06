using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject particle;

    float playerYpos;
    void Start()
    {
        playerYpos = transform.position.y;
    }

    
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (!particle.activeInHierarchy)
            {
                particle.SetActive(true);

            }

            if (Input.GetMouseButtonDown(0))
            {
                PositionSwitch();
            }
        }

        
    }

    void PositionSwitch()
    {
        playerYpos = -playerYpos;

        transform.position = new Vector3(transform.position.x, playerYpos, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            //SceneManager.LoadScene("Game");

            //GameManager.instance.GameOver();

            GameManager.instance.UpdateLives();

            GameManager.instance.Shake();
        }
    }

    
}
