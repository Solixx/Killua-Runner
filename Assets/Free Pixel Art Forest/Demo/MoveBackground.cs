using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {


	private Vector3 startPos;
	private float repeatWidth;
	private PlayerController playerController;
	public float speed = 0f;

	// Use this for initialization
	void Start () {

		playerController = GameObject.Find("Player").GetComponent<PlayerController>();

		startPos = transform.position;
		repeatWidth = GetComponent<BoxCollider2D>().size.x/2;
	}
	
	// Update is called once per frame
	void Update () {

		if(playerController.gameOver == false){

			transform.Translate(Vector2.left * speed * Time.deltaTime);

			if(transform.position.x < startPos.x - repeatWidth){   
				transform.position = startPos;
			}
		}
	}
}
