using System;
using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.VR
{
	public class TelegrabbableTwistScroller : TelegrabbableInteractionTarget
	{
		public const float ANGLE_PER_SCROLL = 22.5f;

		[NonSerialized]
		public float anglePerScroll;

		[NonSerialized]
		public Vector3 localAxis;

		[NonSerialized]
		public bool flipScrollDirection;

		private IScrollable scrollable;

		private Transform relativeTo;

		private Quaternion originalRot;

		private float currentAngle;

		private int overflowCounter;

		private Transform handTransform;

		private Quaternion ControllerRot => handTransform.rotation;

		protected override void Start()
		{
			base.Start();
			base.enabled = false;
		}

		private void Update()
		{
			SetHighlight(on: true);
			Quaternion quaternion = originalRot * relativeTo.rotation;
			Vector3 vector = ControllerRot * Vector3.left;
			Vector3 to = quaternion * Vector3.left;
			Vector3 vector2 = quaternion * Vector3.forward;
			float num = Vector3.SignedAngle(Vector3.ProjectOnPlane(vector, vector2), to, vector2);
			float num2 = Mathf.DeltaAngle(num, currentAngle);
			if (Mathf.Abs(num2) > anglePerScroll)
			{
				currentAngle = Mathf.MoveTowardsAngle(currentAngle, num, anglePerScroll);
				Vector3 lhs = base.transform.TransformDirection(localAxis);
				Vector3 rhs = handler.ControllerReference.actual.transform.position - base.transform.position;
				rhs.Normalize();
				if (Vector3.Dot(lhs, rhs) > 0f)
				{
					num2 = 0f - num2;
				}
				if (flipScrollDirection)
				{
					num2 = 0f - num2;
				}
				ScrollAction action = ((num2 > 0f) ? ScrollAction.ScrollUp : ScrollAction.ScrollDown);
				if (scrollable.IsAtEnd(action) || overflowCounter != 0)
				{
					overflowCounter += action.IsPositive().ToDir();
					return;
				}
				scrollable.Scroll(action);
				HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Weak);
			}
		}

		public override void StartInteraction(TelegrabInteractionHandler handler)
		{
			base.StartInteraction(handler);
			relativeTo = PlayerManager.PlayerTransform;
			scrollable = GetComponent<IScrollable>();
			handTransform = handler.ControllerReference.actual.GetComponentInChildren<VRTK_SDKTransformModify_DV>().transform.Find("HandRoot/OrientationReference");
			originalRot = ControllerRot * Quaternion.Inverse(relativeTo.rotation);
			currentAngle = 0f;
			overflowCounter = 0;
			base.enabled = true;
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Normal);
			handler.FakeInteractableObjectProvider.GrabFakeObject(HandPose.Grab);
		}

		public override void StopInteraction(TelegrabInteractionHandler handler)
		{
			base.StopInteraction(handler);
			SetHighlight(on: false);
			base.enabled = false;
			scrollable.Scroll(ScrollAction.Release);
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Weak);
			handler.FakeInteractableObjectProvider.UngrabFakeObject();
		}
	}
}
