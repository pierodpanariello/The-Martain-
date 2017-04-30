using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity; 

    public float smoothtimey;
    public float smoothtimex;

    public GameObject Player;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothtimex);
        float posy = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothtimey);

        transform.position = new Vector3(posx, posy, transform.position.z);
    }
}
