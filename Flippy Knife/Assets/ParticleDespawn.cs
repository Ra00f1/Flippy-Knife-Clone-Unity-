using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDespawn : MonoBehaviour {

	float time = 0.0F;

	void FixedUpdate() {
		time = time + Time.deltaTime;

		Debug.Log(time);

		if (time >= 10) {
			Destroy(gameObject);
		}
	}	
}
