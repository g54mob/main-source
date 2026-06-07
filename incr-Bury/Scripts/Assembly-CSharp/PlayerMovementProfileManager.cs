using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementProfileManager : MonoBehaviour
{
	public enum MovementProfileNames
	{
		Normal = 0,
		NoMove = 1,
		NoJump = 2,
		NoJumpNoMove = 3,
		OneLegged = 4,
		NoLegged = 5
	}

	[SerializeField]
	private PlayerMovement playerMoveScript;

	[SerializeField]
	private List<PlayerMovementProfile> movementProfiles;

	private void Start()
	{
	}

	private void Update()
	{
		ProfileNullCheck();
	}

	public void SetNewMovementProfile(MovementProfileNames _profile)
	{
		try
		{
			playerMoveScript.currMovementProfile = movementProfiles[(int)_profile];
		}
		catch (Exception message)
		{
			Debug.Log(message);
			Debug.Log("Failed to assign new Movement Profile, perhaps an index out of range?, ignoring.");
		}
	}

	private void ProfileNullCheck()
	{
		if (playerMoveScript.currMovementProfile == null)
		{
			SetNewMovementProfile(MovementProfileNames.Normal);
		}
	}
}
