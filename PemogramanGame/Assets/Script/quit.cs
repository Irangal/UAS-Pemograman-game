using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .SceneManagement ;


public class quit : MonoBehaviour {
	public string NameScene="";
	public void Retry ()
	{
		SceneManager.LoadScene ("Gameplay");
	}

	private void Update ()
	{
		if (Input .GetKeyUp (KeyCode.Escape ))
		{
			Application.Quit ();
		}
	}
	private void OnTriggerEnter2D (Collider2D collision)
	{
		if(collision.tag.Equals ("Player"))
		{
			SceneManager.LoadScene (NameScene);
		}
	}
}