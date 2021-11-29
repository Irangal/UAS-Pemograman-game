using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class GameOver : MonoBehaviour {
	public Text txScore;
	public Text txHighScore;
	public GameObject SnowMan;
	Text txSelamat;
	int highscore;
	Text ScoreUI;
	int Score;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		highscore = PlayerPrefs.GetInt("HS", 0);
		if (Score > highscore )
		{
			highscore = Score  ;
			PlayerPrefs.SetInt("HS", highscore);
		}
		{
			;
		}
		txHighScore.text = " " + highscore;
		txScore.text = "" + Score ;
	}
	public void RetryButtonCLicked ()
	{
		Application.LoadLevel ("Gameplay");
	}

	public void Replay()
	{
		Score = 0;
		SceneManager.LoadScene("Gameplay");

	}
}
