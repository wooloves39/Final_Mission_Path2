using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationText : MonoBehaviour {
	float time;
	RectTransform text;
	// Use this for initialization
	void Start () {
		time = 0.0f;
		text = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 0.1f) {
			time = 0.0f;
			Debug.Log (1);
			text.Rotate (new Vector3 (3, 0, 0));
		}
	}
}
