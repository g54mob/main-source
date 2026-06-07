using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class VRTK_TwoHandedPoleSecondaryGrab : VRTK_BaseTwoHandedSecondaryGrab
{
	private VRTK_TwoHandedPoleGrab primaryGrab;

	public override bool CanBecomePrimary => true;

	public override void Initialise(VRTK_InteractableObject currentGrabbdObject, VRTK_InteractGrab currentPrimaryGrabbingObject, VRTK_InteractGrab currentSecondaryGrabbingObject, Transform primaryGrabPoint, Transform secondaryGrabPoint)
	{
		base.Initialise(currentGrabbdObject, currentPrimaryGrabbingObject, currentSecondaryGrabbingObject, primaryGrabPoint, secondaryGrabPoint);
		if (primaryGrab == null)
		{
			primaryGrab = currentGrabbdObject.GetComponent<VRTK_TwoHandedPoleGrab>();
		}
		primaryGrab.StartSecondaryGrab(currentSecondaryGrabbingObject.gameObject, PipaUtils.PipaTransform(currentSecondaryGrabbingObject.gameObject).GetComponent<Rigidbody>(), secondaryGrabPoint);
	}

	public override void ResetAction()
	{
		VRTK_InteractableObject ungrabbedObject = grabbedObject;
		base.ResetAction();
		if (!(primaryGrab == null))
		{
			primaryGrab.StopSecondaryGrab(becomePrimary: false, ungrabbedObject);
			primaryGrab = null;
		}
	}

	public override void OnDropAction()
	{
		base.OnDropAction();
		ResetAction();
	}

	public override bool BecomePrimaryGrab()
	{
		VRTK_InteractableObject ungrabbedObject = grabbedObject;
		base.ResetAction();
		if (primaryGrab == null)
		{
			return false;
		}
		bool result = primaryGrab.StopSecondaryGrab(becomePrimary: true, ungrabbedObject);
		primaryGrab = null;
		return result;
	}
}
