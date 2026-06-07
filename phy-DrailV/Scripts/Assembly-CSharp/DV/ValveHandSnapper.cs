using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV
{
	public class ValveHandSnapper : AHandPoseSnapper
	{
		[InspectorNote("With Y pointing up", "")]
		public Transform axis;

		private VRTK_HandPoseController_DV handPoseController;

		private float rotationOffset;

		public override bool HoldPosition => true;

		public override Transform HoldTransform => axis;

		private void Awake()
		{
			if (axis == null)
			{
				Debug.LogError("ValveHandSnapper component on " + base.gameObject.name + " has no axis assigned, can't work without it!", this);
			}
		}

		public override void EnterInteraction(VRTK_HandPoseController_DV handPoseController)
		{
			this.handPoseController = handPoseController;
			rotationOffset = Vector3.SignedAngle(axis.forward, handPoseController.transform.forward, axis.up);
		}

		public override Vector3 AdjustPosition(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
		{
			return axis.position;
		}

		public override Quaternion AdjustRotation(bool rightHand, Vector3 handRoot, Vector3 sourcePosition, Vector3 sourceForward, Vector3 sourceUp, Quaternion sourceRotation)
		{
			if (!handPoseController)
			{
				return axis.rotation;
			}
			if (!handPoseController.poseToAnchor.TryGetValue(HandPose.Valve, out var value))
			{
				return axis.rotation;
			}
			Quaternion localRotation = value.localRotation;
			if (!rightHand)
			{
				Vector3 eulerAngles = localRotation.eulerAngles;
				eulerAngles.y = 180f + (180f - eulerAngles.y);
				localRotation.eulerAngles = eulerAngles;
			}
			return axis.rotation * Quaternion.AngleAxis(rotationOffset, Vector3.up) * localRotation;
		}
	}
}
