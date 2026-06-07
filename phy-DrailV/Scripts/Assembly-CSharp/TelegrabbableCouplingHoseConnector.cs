using UnityEngine;

public class TelegrabbableCouplingHoseConnector : TelegrabbableGizmo
{
	[SerializeField]
	private CouplingHoseConnector connector;

	public override bool IsTelegrabAllowed(Vector3 targetPosition)
	{
		if (connector.IsWithinGrabbableDistance(targetPosition))
		{
			return base.IsTelegrabAllowed(targetPosition);
		}
		return false;
	}
}
