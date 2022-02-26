using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] obtacles;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public float obstacleSpeed = 10f;

    private PlayerController playerController;
    private float speedAdd = 0.5f;
    //private float startSpawn = 2;
    private float delaySpawn = 3;
    private float score = 0;
    private float maxScore = 9999;
    private float scoreDelay = .1f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(SpawnObstaclesTimer(delaySpawn));
        StartCoroutine(ScoreCounter(score, scoreDelay));
        //InvokeRepeating("SpawnObstacles", startSpawn, delaySpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
        if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && playerController.gameOver == true){

            RestartGame();
        }
    }

    IEnumerator SpawnObstaclesTimer(float time){

        yield return new WaitForSeconds(time);

        while(playerController.gameOver == false){

            int randomObstacle = Random.Range(0, obtacles.Length);

            Instantiate(obtacles[randomObstacle], new Vector2(10, obtacles[randomObstacle].transform.position.y), obtacles[randomObstacle].transform.rotation);

            if(obstacleSpeed < 25){

                obstacleSpeed += speedAdd;
            }

            delaySpawn = Random.Range(1.5f, 3.5f);
            
            yield return new WaitForSeconds(delaySpawn);
        }
    }

    IEnumerator ScoreCounter(float score, float scoreDelay){

        yield return new WaitForSeconds(scoreDelay);

        while(playerController.gameOver == false){

            if(score < maxScore){

                score++;
            }

            scoreText.text = "Score: " + score;

            finalScoreText.text = "Score: " + score;

            yield return new WaitForSeconds(scoreDelay);
        }
    }

    public void GameOver(){

        if(playerController.gameOver == true){

            scoreText.gameObject.SetActive(false);

            finalScoreText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
    void SpawnObstacles(){

        int randomObstacle = Random.Range(0, obtacles.Length);

        Instantiate(obtacles[randomObstacle], new Vector2(10, obtacles[randomObstacle].transform.position.y), obtacles[randomObstacle].transform.rotation);

        obstacleSpeed += speedAdd;
    }
    */
}
