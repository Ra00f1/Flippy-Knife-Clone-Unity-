using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	public float sX = 0.0f;
	public float sY = 0.0f;
	public float sZ = 0.0f;

	float i = 0.0f;

	void Update() {
		i = i + 0.01f;

		sX = Mathf.Sin(i) / 100;
		sY = Mathf.Sin(i) / 100;
		sZ = Mathf.Sin(i) / 100;
		transform.Rotate(sX, sY, sZ);
	}
}
