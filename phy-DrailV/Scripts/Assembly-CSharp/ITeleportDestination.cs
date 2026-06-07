using UnityEngine;

public interface ITeleportDestination : IPointable
{
	bool IsTeleportAllowed();

	bool ShouldRotatePlayerOnTeleport();

	(Vector3 pos, Quaternion rot) GetTeleportPose();

	void AfterPlayerTeleported();
}
