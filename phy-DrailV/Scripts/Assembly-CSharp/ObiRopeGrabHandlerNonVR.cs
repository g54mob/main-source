using DV.Interaction;
using UnityEngine;

public class ObiRopeGrabHandlerNonVR : AGrabHandler
{
	public ObiRopeGrabArea grabArea;

	public override bool IsItem => false;

	protected override void Start()
	{
		base.Start();
		base.enabled = false;
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		foreach (Collider item in componentsInChildren)
		{
			interactionColliders.Add(item);
		}
	}

	public override Vector3 GetAnchor()
	{
		return Vector3.zero;
	}

	public override Vector3 GetAxis()
	{
		return Vector3.forward;
	}

	public override void StartInteraction(Vector3 startWorldPosition, Grabber grabbedBy)
	{
		if (grabArea.CanGrab())
		{
			base.StartInteraction(startWorldPosition, grabbedBy);
			grabArea.StartGrab(startWorldPosition);
		}
	}

	public override void FeedPosition(Vector3 worldPosition)
	{
		grabArea.FeedPosition(worldPosition);
	}

	public override void EndInteraction()
	{
		base.EndInteraction();
		grabArea.EndGrab();
	}
}
