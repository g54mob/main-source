using System.Collections;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

public class VRTK_ConfigurableJointGrabAttach : VRTK_BaseJointGrabAttach
{
	public SoftJointLimit angularXLimitLow = new SoftJointLimit
	{
		limit = -1f
	};

	public SoftJointLimit angularXLimitHigh = new SoftJointLimit
	{
		limit = 1f
	};

	public SoftJointLimitSpring angularXLimitSpring = new SoftJointLimitSpring
	{
		spring = 1000f,
		damper = 50f
	};

	public SoftJointLimit angularYLimit = new SoftJointLimit
	{
		limit = 1f
	};

	public SoftJointLimit angularZLimit = new SoftJointLimit
	{
		limit = 1f
	};

	public SoftJointLimitSpring angularYZLimitSpring = new SoftJointLimitSpring
	{
		spring = 1000f,
		damper = 50f
	};

	[HideInInspector]
	public ConfigurableJoint joint;

	protected override void CreateJoint(GameObject obj)
	{
		ConfigurableJoint configurableJoint = obj.AddComponent<ConfigurableJoint>();
		configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
		configurableJoint.xMotion = ConfigurableJointMotion.Limited;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Limited;
		configurableJoint.lowAngularXLimit = angularXLimitLow;
		configurableJoint.highAngularXLimit = angularXLimitHigh;
		configurableJoint.angularXLimitSpring = angularXLimitSpring;
		configurableJoint.angularYLimit = angularYLimit;
		configurableJoint.angularZLimit = angularZLimit;
		configurableJoint.angularYZLimitSpring = angularYZLimitSpring;
		givenJoint = configurableJoint;
		joint = configurableJoint;
		base.CreateJoint(obj);
	}

	public override void StopGrab(bool applyGrabbingObjectVelocity)
	{
		GameObject secondaryGrabbingObject = grabbedObjectScript.GetSecondaryGrabbingObject();
		if ((bool)secondaryGrabbingObject)
		{
			VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(secondaryGrabbingObject);
			StartCoroutine(Regrab(controllerReference.scriptAlias.GetComponent<VRTK_InteractGrab_DV>()));
		}
		base.StopGrab(applyGrabbingObjectVelocity);
	}

	private IEnumerator Regrab(VRTK_InteractGrab_DV otherControllerGrab)
	{
		yield return WaitFor.EndOfFrame;
		otherControllerGrab.ForceGrabInteractable(GetComponent<VRTK_InteractableObject_DV>());
	}
}
