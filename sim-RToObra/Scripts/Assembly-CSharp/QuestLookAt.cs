using UnityEngine;

public class QuestLookAt : MonoBehaviour
{
	public float viewAngleMax = 90f;

	private static int raycastIgnoreBits = 0;

	private static RaycastHit[] raycastHits = new RaycastHit[1] { default(RaycastHit) };

	public bool seenByPlayer
	{
		get
		{
			if (raycastIgnoreBits == 0)
			{
				raycastIgnoreBits = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Ignore Raycast"));
			}
			return CanSee(Player.instance.mainCamera, base.transform.position, 3f, viewAngleMax, raycastIgnoreBits);
		}
	}

	public static bool CanSee(Camera camera, Vector3 pos, float maxDist, float maxAngle, int raycastIgnoreLayerMask)
	{
		Vector3 position = camera.transform.position;
		float num = Vector3.Distance(pos, position);
		if (num > maxDist)
		{
			return false;
		}
		float num2 = Quaternion.Angle(camera.transform.rotation, Quaternion.LookRotation(pos - position));
		if (num2 > maxAngle)
		{
			return false;
		}
		Vector3 vector = position;
		if (Physics.SphereCastNonAlloc(vector, 0.05f, (pos - vector).normalized, raycastHits, Mathf.Min(maxDist, num) - 0.05f, ~raycastIgnoreLayerMask) > 0)
		{
			return false;
		}
		return true;
	}
}
