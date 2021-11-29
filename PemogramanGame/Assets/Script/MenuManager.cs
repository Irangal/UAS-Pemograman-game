using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public GameObject Menupanel;
	public GameObject Tutorial;
	public GameObject Info;


	// Use this for initialization
	void Start () {
		Menupanel.SetActive (true);
		Tutorial .SetActive (false);
		Info .SetActive (false);


	}

	// Update is called once per frame
	void Update () {
	}
	public void PlayButtonClicked()
	{
		Application.LoadLevel ("Gameplay");
	}
	public void CreditsButtonClicked()
	{

		Menupanel.SetActive (false);
		Info .SetActive (true);
		Tutorial .SetActive (false);
	}
	public void HowToButon()
	{
		Menupanel.SetActive (false);
		Info  .SetActive (false);
		Tutorial .SetActive (true);
	}
	public void Quit_Clicked()
	{
		Application.Quit ();

	}
	public void BackButtonClicked()
	{
		Menupanel.SetActive (true);
		Info .SetActive (false);
		Tutorial .SetActive (false);







	}
}
