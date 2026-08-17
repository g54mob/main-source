using Assets.Scripts.Actors.Player;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	private float zoom = 20f;

	public Transform target;

	private void Update()
	{
		if (MyPlayer.Instance != null)
		{
			Transform transform = base.transform;
			transform.LookAt(target);
		}
	}

	private void Zoom()
	{
		zoom = 6f;
		Time.timeScale = 0.5f;
	}
}
