using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class Ladder : MonoBehaviour
{
	private void OnTriggerStay(Collider other)
	{
		//IL_009c: Expected O, but got F4
		//IL_01c0: Invalid comparison between F4 and O
		GameObject gameObject = other.gameObject;
		GameObject gameObject2 = MyPlayer.Instance.gameObject;
		if (!(gameObject == gameObject2))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		Transform transform = base.transform;
		playerMovement.onLadder = true;
		Vector3 forward = transform.forward;
		playerMovement.ladderNormal = (Vector3)forward.x;
		_ = forward.z;
		playerMovement.ladder = transform;
		Vector3 right = playerMovement.orientation.right;
		float num = playerMovement.x * right.z;
		Vector3 forward2 = playerMovement.orientation.forward;
		float num2 = playerMovement.y * forward2.z;
		float num3 = num2 + num;
		Vector3 ladderWishDir = default(Vector3);
		playerMovement.ladderWishDir = ladderWishDir;
		Vector3 position = playerMovement.feet.position;
		if (transform.position.y > position.y && playerMovement.grounded)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			Vector3 ladderWishDir2 = playerMovement.ladderWishDir;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)50f) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ladderWishDir2))
			{
				goto IL_0209;
			}
		}
		if (playerMovement.resetJumpCounter >= 2)
		{
			playerMovement.ladderRefreshCount = 0;
			return;
		}
		goto IL_0209;
		IL_0209:
		playerMovement.onLadder = false;
		playerMovement.onLadderLastFrame = false;
	}
}
