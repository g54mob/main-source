using UnityEngine;

public class TeleporterComponent : MonoBehaviour
{
	public void TeleportTargetObjetTowardsDirection(Transform targetObject, Vector3 direction, float teleportLength)
	{
		targetObject.position += direction * teleportLength;
	}

	public void TeleportThisObjectTo(Transform teleportPosRef)
	{
		base.transform.position = teleportPosRef.position;
	}
}
