using System.Collections.Generic;
using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class VRHeightAdjust : MonoBehaviour
	{
		public VRTK_InteractGrab leftHand;

		public VRTK_InteractGrab rightHand;

		private HashSet<VRTK_ControllerEvents> activeTriggerControllers = new HashSet<VRTK_ControllerEvents>();

		private HashSet<VRTK_InteractGrab> grabbingControllers = new HashSet<VRTK_InteractGrab>();

		private bool ignoreGrabbedEvent;

		private float lastHeight;

		private void Awake()
		{
			Subscribe(leftHand);
			Subscribe(rightHand);
			base.enabled = false;
		}

		private void Subscribe(VRTK_InteractGrab controller)
		{
			controller.ControllerGrabInteractableObject += delegate
			{
				if (!ignoreGrabbedEvent)
				{
					grabbingControllers.Add(controller);
					CheckState();
				}
			};
			controller.ControllerUngrabInteractableObject += delegate
			{
				grabbingControllers.Remove(controller);
				CheckState();
			};
			if (controller.TryGetComponent<VRTK_ControllerEvents>(out var controllerEvents))
			{
				controllerEvents.TriggerPressed += delegate
				{
					activeTriggerControllers.Add(controllerEvents);
					CheckState();
				};
				controllerEvents.TriggerReleased += delegate
				{
					activeTriggerControllers.Remove(controllerEvents);
					CheckState();
				};
			}
		}

		private void CheckState()
		{
			base.enabled = activeTriggerControllers.Count == 2 && grabbingControllers.Count == 0;
		}

		private void OnEnable()
		{
			lastHeight = leftHand.transform.parent.localPosition.y + rightHand.transform.parent.localPosition.y;
			ignoreGrabbedEvent = true;
			leftHand.GetComponent<FakeInteractableObjectProvider>().GrabFakeObject(HandPose.Grab);
			rightHand.GetComponent<FakeInteractableObjectProvider>().GrabFakeObject(HandPose.Grab);
			ignoreGrabbedEvent = false;
		}

		private void OnDisable()
		{
			leftHand.GetComponent<FakeInteractableObjectProvider>().UngrabFakeObject();
			rightHand.GetComponent<FakeInteractableObjectProvider>().UngrabFakeObject();
		}

		private void Update()
		{
			float num = leftHand.transform.parent.localPosition.y + rightHand.transform.parent.localPosition.y;
			if (!(Mathf.Abs(lastHeight - num) < 0.1f))
			{
				float num2 = Mathf.Sign(num - lastHeight);
				lastHeight += num2 * 0.1f;
				int p = (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType) ? 14 : 15);
				float num3 = GamePreferences.Get<float>((Preferences)p);
				num3 -= num2 * 0.1f;
				num3 = Mathf.Clamp(num3, -0.5f, 0.5f);
				GamePreferences.Set((Preferences)p, num3);
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(leftHand.gameObject), HapticIntensityType.Normal);
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(rightHand.gameObject), HapticIntensityType.Normal);
			}
		}
	}
}
