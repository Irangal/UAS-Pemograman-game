using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoReplay : MonoBehaviour {
	float timer = 0;
	public Text info;


	// Use this for initialization
	void Start () {
		{
			info.text = ("YOU LOSE!");
		}

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5) {
			SceneManager.LoadScene ("Gameplay");
		}

	}
}
