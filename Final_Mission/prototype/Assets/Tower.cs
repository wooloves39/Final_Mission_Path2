using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy") {
			bullet.transform.LookAt (other.transform.position);
			bullet.transform.Translate (Vector3.forward* 10*Time.deltaTime);
			if (Vector3.Distance (bullet.transform.position, other.transform.position) < 0.25f) {
				bullet.transform.position = (this.transform.position) + new Vector3(0,1,0);
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		bullet.transform.position = (this.transform.position) + new Vector3(0,1,0);
	}
}
