using UnityEngine;

public class PointHandSnapper : AHandPoseSnapper
{
	public Transform pointMarker;

	public override Transform HoldTransform => pointMarker;

	private void Awake()
	{
		if (!pointMarker)
		{
			pointMarker = base.transform;
		}
	}

	public override Vector3 AdjustPosition(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		return (pointMarker ? pointMarker : base.transform).position;
	}

	public override Quaternion AdjustRotation(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
	{
		return sourceRotation;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere((pointMarker ? pointMarker : base.transform).position, 0.01f);
	}
}
