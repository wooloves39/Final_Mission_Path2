using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public GameObject bullet;
	GameObject obj;
	public float delay = 5.0f;
	public Vector3 taget;
	float time = 0.0f;
	bool attack = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > delay) {
			time = 0.0f;
			attack = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy") {
			if (attack) {
				attack = false;
				bullet.transform.position = this.transform.position + new Vector3(0,1,0);
				taget = other.transform.position;
				obj = Instantiate (bullet);
				obj.transform.SetParent (this.transform);

			}
		}
	}
}
