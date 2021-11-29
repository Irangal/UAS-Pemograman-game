using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform player;
	public Transform Bg;
	public Transform Bg1;
	private Vector3 offset;

	// Use this for initialization
	void Start()
	{
			offset = transform.position - player.transform.position;

		}

		// Update is called once per frame
		void LateUpdate () {
			

	}

	// Update is called once per frame
	void Update()
	{
		if (player.position.x != transform.position.x && player.position.x > 0 && player.position.x < 100f)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 0.1f);
		}
		Bg1.transform.position = new Vector2(transform.position.x * 1.0f, Bg1.transform.position.y);

	}
}