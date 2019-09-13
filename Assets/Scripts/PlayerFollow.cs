using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

	public float zoomFactor = 1.5f;
	public float zoomTime;
	public float followTimeDelta = 0.8f;
	public float minDistance;
	public float maxDistance;
	public float smoothTime;
	public GameObject BGM;

	public Transform player1;
	public Transform player2;

	Camera cam;
	Vector3 velocity;
	float vel;

	void Start(){
		cam = GetComponent<Camera> ();
		smoothTime = 1;
	}

	// Follow Two Transforms with a Fixed-Orientation Camera
	public void Update()
	{
			Vector3 midpoint = (player1.position + player2.position) / 2f;

			float distance = (player1.position - player2.position).magnitude;

			Vector3 cameraDestination = midpoint - cam.transform.forward * Mathf.Clamp (distance, minDistance, maxDistance) * zoomFactor;

			cam.transform.position = Vector3.SmoothDamp (cam.transform.position, cameraDestination, ref velocity, smoothTime);

			if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
				cam.transform.position = cameraDestination;
	}

	public IEnumerator Zoom(){
		zoomFactor = 0.75f;
		smoothTime = 0.1f;
		yield return new WaitForSeconds (zoomTime);
		zoomFactor = 1.5f;
		smoothTime = 1;
	}
	public IEnumerator KO(){
		zoomFactor = 0.75f;
		smoothTime = 0.1f;
		yield return new WaitForSeconds (zoomTime);
	}
}
