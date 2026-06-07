using DV.VRTK_Extensions;
using UnityEngine;

public abstract class AHandPoseSnapper : MonoBehaviour
{
	public virtual Transform HoldTransform => base.transform;

	public virtual bool HoldPosition => false;

	public virtual bool HoldRotation => false;

	public virtual void EnterInteraction(VRTK_HandPoseController_DV handPoseController)
	{
	}

	public virtual Vector3 AdjustPosition(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		return sourcePosition;
	}

	public virtual Quaternion AdjustRotation(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		return sourceRotation;
	}
}
