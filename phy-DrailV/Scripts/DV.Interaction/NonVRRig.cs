using UnityEngine;

public class NonVRRig : MonoBehaviour, IPlayerRig
{
	public Transform attachPoint;

	Transform IPlayerRig.GetAttachPoint()
	{
		return attachPoint;
	}
}
