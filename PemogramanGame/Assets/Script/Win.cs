using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {
	float timer = 0;
	public GameObject Bullet;
	public Text info;


	// Use this for initialization
	void Start () {
		{
			info.text = ("Congratulations \n You Win!");
		}

	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5) {
			SceneManager.LoadScene ("Gameplay");
		}
	}
		public void SettingButtonCLicked ()
		{
			Application.LoadLevel ("Mainmenu");
		}

	}
