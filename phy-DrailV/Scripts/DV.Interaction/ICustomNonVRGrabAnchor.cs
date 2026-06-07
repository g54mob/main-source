using UnityEngine;

public interface ICustomNonVRGrabAnchor
{
	(Vector3 localPos, Quaternion localRot) GetGrabAnchor();
}
