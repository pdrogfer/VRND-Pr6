using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headControl : MonoBehaviour {
    public GameObject GameLogic;
    public GameObject Player;

    private float speed = 5.0f;
	// Use this for initialization
	private Vector3 dir;
	private Quaternion rot;

	void Start () {
		
	}
	
	void FixedUpdate () {
		
        if(GameLogic.GetComponent<GameLogic>().playerTurn == true) {
			
            if (GameLogic.GetComponent<holdPiece>().holdingPiece == true) {
				
                dir = GameLogic.GetComponent<holdPiece>().pieceBeingHeld.transform.position - transform.position;
                rot = Quaternion.LookRotation(-dir);
                // slerp to the desired rotation over time
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
            }
        } 
		else {
			
            dir = Player.transform.position - transform.position;
            dir.y = 0; // keep the direction strictly horizontal
            rot = Quaternion.LookRotation(-dir);
            // slerp to the desired rotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
        }
        
	}
}
