using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
		transform.rotation = Quaternion.Euler(new Vector3(0,-45,0));
              
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.forward*Time.deltaTime);
	}
}
