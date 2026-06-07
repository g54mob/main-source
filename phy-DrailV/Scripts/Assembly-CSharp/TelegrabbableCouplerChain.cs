using UnityEngine;

public class TelegrabbableCouplerChain : TelegrabbableGizmo
{
	[SerializeField]
	private float maxDistance = 1.6f;

	public override bool IsTelegrabAllowed(Vector3 targetPosition)
	{
		if (!base.IsTelegrabAllowed(targetPosition))
		{
			return false;
		}
		return (targetPosition - base.transform.position).sqrMagnitude <= maxDistance * maxDistance;
	}
}
