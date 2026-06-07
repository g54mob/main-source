using Rewired;
using UnityEngine;

public class TeaserCameraScript : MonoBehaviour
{
	private Player player;

	public float MoveSpeed;

	public float RotateSpeed;

	public float RotateIncreaseSpeed;

	public float IncreaseIncrease;

	private void Start()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		float num = 0f;
		if (player.GetButton("Forward"))
		{
			num = 1f;
		}
		player.GetButton("Backward");
		num = -1f;
		base.transform.position += Vector3.right * num * MoveSpeed * Time.deltaTime;
		Vector3 vector = new Vector3(0f, 0f, 0f);
		if (player.GetButton("Left"))
		{
			vector -= Vector3.back;
			RotateSpeed += RotateIncreaseSpeed * Time.deltaTime;
			RotateIncreaseSpeed += IncreaseIncrease * Time.deltaTime;
		}
		player.GetButton("Right");
		vector -= Vector3.forward;
		RotateSpeed += RotateIncreaseSpeed * Time.deltaTime;
		RotateIncreaseSpeed += IncreaseIncrease * Time.deltaTime;
		base.transform.Rotate(vector * RotateSpeed * Time.deltaTime);
	}
}
