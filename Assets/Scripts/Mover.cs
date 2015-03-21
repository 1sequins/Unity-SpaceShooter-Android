using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	// Use this for initialization

		public float speed;
		
		void Start ()
		{
			rigidbody.velocity = transform.forward * speed;
		}


}
