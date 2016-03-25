using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	Transform player;
	Vector3 cameraPosition;

	void Update () 
	{
		TrackPlayer ();
	}

	void TrackPlayer()
	{
		if (gameObject.name == "P1Camera(Clone)")
		{
			player = GameObject.FindGameObjectWithTag ("Player 1").transform;
		}
		else if (gameObject.name == "P2Camera(Clone)")
		{
			player = GameObject.FindGameObjectWithTag ("Player 2").transform;
		}
		if (player == null)
		{
			Debug.Log ("Nah");
		}
		else if (player != null)
		{
			cameraPosition = new Vector3 (player.position.x, player.position.y + 1, -10);
			transform.position = cameraPosition;
		}
	}
}
