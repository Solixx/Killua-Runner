using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public GameManager speed;
    private float screenLimitY = -10;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        speed = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerController.gameOver == false){

            transform.Translate(Vector2.left * speed.obstacleSpeed * Time.deltaTime);

            if(gameObject.CompareTag("Obstacle")){

                if(transform.position.x < screenLimitY){

                    Destroy(gameObject);
                }
            }
        }
    }
}
