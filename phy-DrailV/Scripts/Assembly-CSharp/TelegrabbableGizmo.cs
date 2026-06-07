using System;
using DV.CabControls.VRTK;
using UnityEngine;

public class TelegrabbableGizmo : Telegrabbable
{
	[NonSerialized]
	public GizmoVRTK gizmo;

	[NonSerialized]
	public Rigidbody rb;

	public override bool RemoteInteractionOnly => false;

	public override bool IsTelegrabAllowed(Vector3 targetPosition)
	{
		if (!gizmo.IsGrabbed())
		{
			return gizmo.InteractionAllowed;
		}
		return false;
	}

	protected override void SetState(bool isBeingTelegrabbed)
	{
		if (isBeingTelegrabbed)
		{
			gizmo.InteractionAllowed = false;
		}
		else
		{
			gizmo.InteractionAllowed = true;
		}
	}

	public override Transform GetAnchor(bool isRightHand)
	{
		if (!isRightHand)
		{
			return gizmo.GrabAnchorLeft;
		}
		return gizmo.GrabAnchorRight;
	}

	public override bool ShouldRotateToController()
	{
		return true;
	}
}
