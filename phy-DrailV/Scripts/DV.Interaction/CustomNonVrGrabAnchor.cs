using UnityEngine;

public class CustomNonVrGrabAnchor : MonoBehaviour, ICustomNonVRGrabAnchor
{
	public Vector3 customLocalPosition = Vector3.zero;

	public Vector3 customLocalRotation = Vector3.zero;

	public (Vector3 localPos, Quaternion localRot) GetGrabAnchor()
	{
		return (localPos: customLocalPosition, localRot: Quaternion.Euler(customLocalRotation));
	}
}
