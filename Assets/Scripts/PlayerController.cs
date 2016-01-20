using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed; 
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public GameObject shotSpwan;
	public float fireRate;

	private float nextFire;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Rigidbody clone;
			clone = Instantiate(shot, transform.position, transform.rotation) as Rigidbody;
			//GameObject clone =
			shot.transform.position = shotSpwan.transform.position;
			GetComponent<AudioSource>().Play();

		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var Rigidbody = GetComponent<Rigidbody>();
		Rigidbody.velocity = movement * speed;

		Rigidbody.position = new Vector3 
			(Mathf.Clamp(Rigidbody.position.x, boundary.xMin, boundary.xMax),
			 0.0f,
			 Mathf.Clamp(Rigidbody.position.z, boundary.zMin, boundary.zMax));

		Rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, Rigidbody.velocity.x * -tilt);

	}
}
