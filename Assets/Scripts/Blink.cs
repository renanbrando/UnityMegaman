using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {

	// Interval to turn on/off rendering 
	public float interval;

	IEnumerator Start () {

		// Gets object's component 
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (interval);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (interval);

		// Loops start method
		StartCoroutine(Start());
	}

	void update (){
		// Press enter
		if(Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene ("game-scene");
		}
	}

}
