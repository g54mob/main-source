using DV.Utils;
using UnityEngine;

public abstract class APlayerTeleport : SingletonBehaviour<APlayerTeleport>
{
	public void TeleportPlayer(Vector3 worldPosition, Vector3 worldForward, Transform target, bool useRotation, bool playFootstepSound)
	{
		TeleportPlayer(worldPosition, Quaternion.LookRotation(worldForward), target, useRotation, playFootstepSound);
	}

	public abstract void TeleportPlayer(Vector3 worldPosition, Quaternion worldRotation, Transform target, bool useRotation, bool playFootstepSound);
}
