using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Sirenix.Utilities;
using UnityEngine;

public class PlayerSplineController : Singleton<PlayerSplineController>
{
	public SplineFollower spline;

	private List<TSPlayerController> players;

	public LayerMask trainLayer;

	public List<TSPlayerController> Players
	{
		get
		{
			if (!players.IsNullOrEmpty())
			{
				return players;
			}
			return players = Object.FindObjectsOfType<TSPlayerController>().ToList();
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void CheckIsInTrain()
	{
		foreach (TSPlayerController player in Players)
		{
			if (!IsOnTrain(player))
			{
				player.transform.parent = null;
			}
			else
			{
				player.transform.parent = base.transform;
			}
		}
	}

	private void StopFollowingToTrain()
	{
		spline.follow = false;
	}

	public bool IsOnTrain(TSPlayerController player)
	{
		Vector3 origin = player.transform.position + Vector3.up * 3f;
		Vector3 direction = -Vector3.up;
		if (Physics.Raycast(origin, direction, 15f, trainLayer))
		{
			Debug.Log("Grounded!");
			return true;
		}
		Debug.Log("Not Grounded!");
		return false;
	}
}
