using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	bool isJump = true;
	bool isDead = false;
	int idMove = 0;
	Animator anim;
	int idSlide= 0;
	public GameObject Projectile; 
	public Vector2 projectileVelocity;
	public Vector2 projectileOffset;
	public float cooldown = 0.5f;
	public AudioClip audioCoin;
	private AudioSource MediaPlayerCoin;

	// Use this for initialization
	void Start()
	{
		MediaPlayerCoin = gameObject.AddComponent <AudioSource > ();
		MediaPlayerCoin.clip = audioCoin;
		
		{
			anim = GetComponent<Animator> ();
		}
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log("Jump "+isJump);
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MoveLeft();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			MoveRight();
		}


		if (Input.GetKeyDown(KeyCode.Space))
		{

			Jump();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow  )) {

			SlideLeft();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {

			SlideRight();
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			Idle();
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			Idle();
		}
		Move();
		Dead();
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (isJump)
		{
			anim.ResetTrigger("jump");
			if (idMove == 0) anim.SetTrigger("idle");
			isJump = false;
		}

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		// Kondisi ketika menyentuh tanah
		anim.SetTrigger("jump");
		anim.ResetTrigger("run");
		anim.ResetTrigger("idle");
		anim.ResetTrigger ("slide");
		isJump = false;
	}



	public void MoveRight()
	{
		idMove = 1;
	}

	public void MoveLeft()
	{
		idMove = 2;
	}

	private void Move()
	{
		if (idMove == 1 && !isDead)
		{
			// Kondisi ketika bergerak ke kekanan
			if (!isJump) anim.SetTrigger("run");
			transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
			transform.localScale = new Vector3(-1f, 1f, 1f) ;
		}
		if (idMove == 2 && !isDead)
		{
			// Kondisi ketika bergerak ke kiri

			if (!isJump) anim.SetTrigger("run");
			transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
		


	public void SlideLeft()
	{
		idSlide = 2;
	}

	public void Jump()
	{
		if (!isJump)
		{
			// Kondisi ketika Loncat
			gameObject.GetComponent<Rigidbody2D>().AddForce
			(Vector2.up * 500f);
		}
	}

	private  void Slide()
	{
		if (idSlide == 1 && !isDead) 
		{
			
				// Kondisi ketika bergerak ke kekanan
				if (!isJump) anim.SetTrigger("slide");
				transform.Translate(-1 * Time.deltaTime * 20f, 0, 0);
				transform.localScale = new Vector3(1f, 1f, 1f) ;

			}
	}
		

	private  void SlideRight()
	{
		if (idSlide == 2 && !isDead) 

		{
			// Kondisi ketika bergerak ke kiri

			if (!isJump) anim.SetTrigger("slide");
			transform.Translate(1 * Time.deltaTime * 200f, 0, 0);
			transform.localScale = new Vector3(-1f, 1f, 1f);

		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag.Equals("Coin"))
		{
			Data.score += 15;
			Destroy(collision.gameObject);
			MediaPlayerCoin.Play ();
		}
	}

	public void Idle()
	{
		// kondisi ketika idle/diam
		if (!isJump)
		{
			anim.ResetTrigger("jump");
			anim.ResetTrigger("run");
			anim.SetTrigger("idle");
			anim.ResetTrigger ("slide");
		}
		idMove = 0;
	}

	private void Dead()
	{
		if (!isDead) {
			if (transform.position.y < -10f) {

				// kondisi ketika jatuh
				isDead = true;
			}
		}
	}
}