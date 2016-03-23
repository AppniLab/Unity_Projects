using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

	public float fov=90;

	public Vector3 v1,v2,v_npc,v_player;

	float fov_radians;
	float fov_degrees;
	float min_cosine;
	float dotP;

	// Use this for initialization
	void Start () 
	{
		fov_degrees = 90f;
		fov_radians = fov_degrees*Mathf.Deg2Rad;
		min_cosine = Mathf.Cos(fov_radians/2); //0.7f
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.DrawRay(transform.position,Quaternion.Euler(new Vector3(0f,45f,0f))*Vector3.forward*10f,Color.green,10f);
		Debug.DrawRay(transform.position,Quaternion.Euler(new Vector3(0f,-45f,0f))*Vector3.forward*10f,Color.green,10f);
		Debug.DrawRay(transform.position,Vector3.forward,Color.red,10f);

		v_npc = transform.position;
		v_player = GameObject.Find("Player").transform.position;

		v2 = v_player - v_npc;
		v1 = new Vector3(0,0,1);

		dotP = Vector3.Dot(v1.normalized,v2.normalized);

		//Debug.Log("dot P :"+dotP.ToString());

		if(dotP > min_cosine && dotP <=1)
		{
			Debug.Log("object is in sight");
			transform.Translate(v2*Time.deltaTime*0.5f);

		}
		else
			Debug.Log("object is in out of sight");
	}
}
