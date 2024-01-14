using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CharacterWalkAnimation : MonoBehaviour
{
	public float speed;
	public Rigidbody rb;
	public Animator anim;



	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			rb.transform.Translate (Vector3.forward * speed * Time.deltaTime);
			anim.SetBool ("IsForward", true);

		} else 
			anim.SetBool ("IsForward", false);



		if (Input.GetKey (KeyCode.A)) {
			rb.transform.Translate (Vector3.left * speed * Time.deltaTime);
			anim.SetBool ("IsLeft", true);
		}
		else
			anim.SetBool ("IsLeft", false);


		if (Input.GetKey (KeyCode.D)) {
			rb.transform.Translate (Vector3.right * speed * Time.deltaTime);
			anim.SetBool ("IsRight", true);
		}
		else
			anim.SetBool ("IsRight", false);

		if (Input.GetKey (KeyCode.S))
		{
			rb.transform.Translate (-Vector3.forward * speed * Time.deltaTime);
			anim.SetBool ("IsBack", true);
		}
		else 
			anim.SetBool ("IsBack", false);






	}


}


// notice that if you do not use rigidbody the script will be okay but in high speed the player may penetrate walls (common mistake)

