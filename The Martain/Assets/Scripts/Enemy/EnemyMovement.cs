using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public GameObject target1;
	public GameObject target2; 
	public Rigidbody2D rb; 
	public float speed; 
	public float scale; 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> (); 
		transform.localScale = new Vector3 (-scale, scale, scale); //flips the character around using the defined float scale value that should equal the scale of the sprite
		rb.velocity = new Vector2 ( speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.transform.position.x >= target2.transform.position.x) {
			transform.localScale = new Vector3 (scale, scale, scale);
			rb.velocity = new Vector2 (-speed, 0);
		}

		if (rb.transform.position.x <= target1.transform.position.x) {
			transform.localScale = new Vector3 (-scale, scale, scale);
			rb.velocity = new Vector2 ( speed, 0);
		}
	}
}
