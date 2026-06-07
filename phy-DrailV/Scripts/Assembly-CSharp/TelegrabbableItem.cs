using System;
using DV.CabControls.VRTK;
using UnityEngine;
using VRTK.GrabAttachMechanics;

public class TelegrabbableItem : Telegrabbable
{
	[NonSerialized]
	public ItemVRTK item;

	[NonSerialized]
	public Rigidbody rb;

	private bool originalDetectCollisions;

	public override bool RemoteInteractionOnly => false;

	public override bool IsTelegrabAllowed(Vector3 _)
	{
		if (!item.IsGrabbed() && item.InteractionAllowed)
		{
			return !item.IsInBelt();
		}
		return false;
	}

	protected override void SetState(bool isBeingTelegrabbed)
	{
		if (isBeingTelegrabbed)
		{
			originalDetectCollisions = rb.detectCollisions;
			rb.isKinematic = true;
			rb.detectCollisions = false;
			item.InteractionAllowed = false;
		}
		else
		{
			rb.isKinematic = false;
			rb.detectCollisions = originalDetectCollisions;
			item.InteractionAllowed = true;
		}
	}

	public override Transform GetAnchor(bool isRightHand)
	{
		if (!isRightHand)
		{
			return item.GrabAnchorLeft;
		}
		return item.GrabAnchorRight;
	}

	public override bool ShouldRotateToController()
	{
		VRTK_BaseGrabAttach component = item.GetComponent<VRTK_BaseGrabAttach>();
		if ((bool)component && component.precisionGrab)
		{
			return false;
		}
		return true;
	}
}
