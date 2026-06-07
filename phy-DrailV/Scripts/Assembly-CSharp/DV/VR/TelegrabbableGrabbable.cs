using DV.CabControls;
using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class TelegrabbableGrabbable : TelegrabbableInteractionTarget
	{
		private const float MOVEMENT_AMPLIFICATION = 1f;

		private const float ROTATION_AMPLIFICATION = 1f;

		private Transform relativeTo;

		private Vector3 originalHandPos;

		private Vector3 originalHitPos;

		private Quaternion originalHandRot;

		private VRTK_InteractGrab fakeController;

		private HandPose grabPose;

		protected override void Start()
		{
			base.Start();
			if (TryGetComponent<IGrabPoseProvider>(out var component))
			{
				grabPose = component.GrabPose;
			}
			else
			{
				grabPose = HandPose.PreGrab;
			}
			base.enabled = false;
		}

		private void Update()
		{
			SetHighlight(on: true);
			Vector3 vector = relativeTo.InverseTransformPoint(handler.ControllerReference.actual.transform.position) - originalHandPos;
			vector *= 1f;
			Vector3 position = relativeTo.TransformPoint(originalHitPos + vector);
			fakeController.transform.position = position;
			Quaternion b = handler.ControllerReference.actual.transform.rotation * Quaternion.Inverse(relativeTo.rotation);
			fakeController.transform.rotation = Quaternion.SlerpUnclamped(originalHandRot, b, 1f) * relativeTo.rotation;
		}

		public override void StartInteraction(TelegrabInteractionHandler handler)
		{
			base.StartInteraction(handler);
			base.enabled = true;
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Normal);
			relativeTo = ((base.transform.parent != null) ? base.transform.parent : base.transform);
			Vector3 vector = relativeTo.InverseTransformPoint(handler.Telegrab.CurrentTelegrabData.SphereCastHit.point);
			Vector3 vector2 = relativeTo.InverseTransformPoint(handler.ControllerReference.actual.transform.position);
			originalHandPos = vector2;
			originalHitPos = vector;
			originalHandRot = handler.ControllerReference.actual.transform.rotation * Quaternion.Inverse(relativeTo.rotation);
			fakeController = handler.GetFakeController();
			fakeController.transform.position = handler.Telegrab.CurrentTelegrabData.SphereCastHit.point;
			fakeController.transform.rotation = handler.ControllerReference.actual.transform.rotation;
			fakeController.transform.SetParent(relativeTo);
			fakeController.gameObject.SetActive(value: true);
			fakeController.interactTouch.ForceTouch(base.gameObject);
			fakeController.AttemptGrab();
			fakeController.ControllerUngrabInteractableObject += OnUnGrab;
			handler.FakeInteractableObjectProvider.GrabFakeObject(grabPose);
		}

		private void OnUnGrab(object sender, ObjectInteractEventArgs e)
		{
			handler.StopInteracting();
		}

		public override void StopInteraction(TelegrabInteractionHandler handler)
		{
			base.StopInteraction(handler);
			SetHighlight(on: false);
			base.enabled = false;
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Weak);
			fakeController.ControllerUngrabInteractableObject -= OnUnGrab;
			fakeController.ForceRelease();
			fakeController.transform.SetParent(null);
			fakeController.gameObject.SetActive(value: false);
			handler.ReturnFakeController();
			fakeController = null;
			handler.FakeInteractableObjectProvider.UngrabFakeObject();
		}
	}
}
