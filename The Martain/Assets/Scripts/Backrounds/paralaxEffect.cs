using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxEffect : MonoBehaviour {
	public Transform [] backgrounds; //Array (list) ; this is for foregrounds and backgrounds 
	private float[] paralaxScales; 	//Proportion of the camera's movement to move the backgrounds by 
	public float smoothing = 1f; 

	private Transform cam; 
	private Vector3 previousCamPos; 

	void Awake(){
		cam = Camera.main.transform; 
	}

	void Start () {
		//The previous frame has the current's frame's camera position 
		previousCamPos = cam.position; 

		paralaxScales = new float[backgrounds.Length]; 

		for (int i = 0; i < backgrounds.Length; i++) {
			paralaxScales [i] = backgrounds [i].position.z * -1; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			float paralax = (previousCamPos.x - cam.position.x) * paralaxScales [i];

			float backgroundTargetPosX = backgrounds [i].position.x + paralax; 

			Vector3 backroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y, backgrounds [i].position.z); 

			backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backroundTargetPos, smoothing * Time.deltaTime); 
		}
		 
		//set the previous cam position to the camera's position at the end of the frame

		previousCamPos = cam.position; 
	}
}
