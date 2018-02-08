using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float impulse;

	public Transform floorVerifier;
	bool isOnFloor;

	Animator anim;
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		// Interface for components
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Move
		float move_x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		transform.Translate (move_x, 0.0f, 0.0f);
		anim.SetFloat ("pHorizontal", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

		// Verify colision with floor
		isOnFloor = Physics2D.Linecast(transform.position, floorVerifier.position, 1 << LayerMask.NameToLayer("Floor"));

		// Jump
		if (Input.GetButtonDown ("Jump") && isOnFloor) {
			rb.velocity = new Vector2 (0.0f, impulse);
		}

		// Orientation
		if (move_x > 0) {
			spriteRenderer.flipX = false;
		} else if (move_x < 0) {
			spriteRenderer.flipX = true;
		}

	}
}
