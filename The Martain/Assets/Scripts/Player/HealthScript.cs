using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class HealthScript : MonoBehaviour {

	public GameObject deathParticleEffect;
	public GameObject respawnParticleEffect; 

	public Sprite[] healthSprites; 
	public Image heartUI; 
	public int hurtDamage = 1;
	public int playerLives = 3;  
	public Transform spawnPoint;
	public Rigidbody2D player;  
	public Collider2D playerCollider; 
	// Use this for initialization
	void Start () {
		player.GetComponent<Renderer>().enabled = true;   //Make the player visible 
		playerLives = 3; 
		player = GetComponent<Rigidbody2D> (); 
		playerCollider = GetComponent<Collider2D> ();
		//Spawning the player into the spawn point
		player.transform.position = new Vector2 (spawnPoint.transform.position.x, spawnPoint.transform.position.y);
	}

	// Update is called once per frame
	void Update () {
		if (playerLives <= 0) {
			int scene = SceneManager.GetActiveScene().buildIndex; 
			SceneManager.LoadScene (scene -1, LoadSceneMode.Single); 
			playerLives = 3; 
			 
		}
		heartUI.sprite = healthSprites [playerLives-1];

	}

	 void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Hazard") {
			playerLives = playerLives - hurtDamage;  
			if (playerLives > 0) {
				StartCoroutine ("RespawnPlayerCo"); 
			}
		}
		if (coll.gameObject.tag == "Level End"){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); 
		}

	}
	// Player respawn coroutine 
	public IEnumerator RespawnPlayerCo() {
		Instantiate (deathParticleEffect, player.transform.position, player.transform.rotation);
		player.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(1); 
		player.transform.position = new Vector2 (spawnPoint.transform.position.x, spawnPoint.transform.position.y);
		player.GetComponent<Renderer>().enabled = true; 

	}
}
