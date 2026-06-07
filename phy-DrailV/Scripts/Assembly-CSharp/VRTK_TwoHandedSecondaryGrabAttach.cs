using UnityEngine;
using VRTK;
using VRTK.SecondaryControllerGrabActions;

public class VRTK_TwoHandedSecondaryGrabAttach : VRTK_BaseGrabAction
{
	private ConfigurableJoint joint;

	public override void Initialise(VRTK_InteractableObject currentGrabbdObject, VRTK_InteractGrab currentPrimaryGrabbingObject, VRTK_InteractGrab currentSecondaryGrabbingObject, Transform primaryGrabPoint, Transform secondaryGrabPoint)
	{
		base.Initialise(currentGrabbdObject, currentPrimaryGrabbingObject, currentSecondaryGrabbingObject, primaryGrabPoint, secondaryGrabPoint);
		SetupJoints(on: true);
	}

	public override void ResetAction()
	{
		SetupJoints(on: false);
		base.ResetAction();
	}

	public override void OnDropAction()
	{
		base.OnDropAction();
		SetupJoints(on: false);
	}

	private void SetupJoints(bool on)
	{
		VRTK_ConfigurableJointGrabAttach component = GetComponent<VRTK_ConfigurableJointGrabAttach>();
		if (on)
		{
			component.joint.xMotion = ConfigurableJointMotion.Limited;
			component.joint.yMotion = ConfigurableJointMotion.Limited;
			component.joint.zMotion = ConfigurableJointMotion.Free;
			component.joint.angularXMotion = ConfigurableJointMotion.Free;
			component.joint.angularYMotion = ConfigurableJointMotion.Free;
			component.joint.angularZMotion = ConfigurableJointMotion.Free;
			joint = base.gameObject.AddComponent<ConfigurableJoint>();
			joint.connectedBody = secondaryGrabbingObject.controllerAttachPoint;
			joint.anchor = secondaryInitialGrabPoint.localPosition;
			joint.xMotion = ConfigurableJointMotion.Limited;
			joint.yMotion = ConfigurableJointMotion.Limited;
			joint.zMotion = ConfigurableJointMotion.Limited;
			joint.angularXMotion = ConfigurableJointMotion.Free;
			joint.angularYMotion = ConfigurableJointMotion.Free;
			joint.angularZMotion = ConfigurableJointMotion.Limited;
			joint.lowAngularXLimit = component.angularXLimitLow;
			joint.highAngularXLimit = component.angularXLimitHigh;
			joint.angularXLimitSpring = component.angularXLimitSpring;
			joint.angularYLimit = component.angularYLimit;
			joint.angularZLimit = component.angularZLimit;
			joint.angularYZLimitSpring = component.angularYZLimitSpring;
		}
		else
		{
			if ((bool)component.joint)
			{
				component.joint.xMotion = ConfigurableJointMotion.Limited;
				component.joint.yMotion = ConfigurableJointMotion.Limited;
				component.joint.zMotion = ConfigurableJointMotion.Limited;
				component.joint.angularXMotion = ConfigurableJointMotion.Limited;
				component.joint.angularYMotion = ConfigurableJointMotion.Limited;
				component.joint.angularZMotion = ConfigurableJointMotion.Limited;
			}
			Object.Destroy(joint);
			joint = null;
		}
	}
}
