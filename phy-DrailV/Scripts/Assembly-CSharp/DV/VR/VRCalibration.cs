using System.Collections;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class VRCalibration : SingletonBehaviour<VRCalibration>
	{
		private const float TIME_BETWEEN_MESSAGES = 2f;

		private bool triggerPressed;

		private GameObject notification;

		private bool IsInterrupted => SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers);

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private IEnumerator Start()
		{
			SetupControllerListeners(on: true);
			NotificationManager nm = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager;
			while (!WorldStreamingInit.IsLoaded)
			{
				yield return null;
			}
			while (!PlayerManager.ActiveCamera)
			{
				yield return null;
			}
			yield return null;
			while (IsInterrupted)
			{
				yield return null;
			}
			notification = nm.ShowNotification("vr_calib/starting", null, 2f);
			while ((bool)notification && !triggerPressed)
			{
				if (IsInterrupted)
				{
					Cleanup();
					yield break;
				}
				yield return null;
			}
			triggerPressed = false;
			bool isSeated = GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);
			notification = nm.ShowNotification(isSeated ? "vr_calib/seated_instructions" : "vr_calib/roomscale_instructions");
			while (!triggerPressed)
			{
				if (IsInterrupted)
				{
					Cleanup();
					yield break;
				}
				yield return null;
			}
			triggerPressed = false;
			nm.ClearNotification(notification);
			if (isSeated)
			{
				SingletonBehaviour<VRManager>.Instance.ResetSeatedPosition();
			}
			notification = nm.ShowNotification("vr_calib/done", null, 2f);
			while ((bool)notification && !triggerPressed)
			{
				if (IsInterrupted)
				{
					Cleanup();
					yield break;
				}
				yield return null;
			}
			triggerPressed = false;
			nm.ClearNotification(notification);
			Cleanup();
		}

		private void Cleanup()
		{
			if ((bool)notification)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(notification);
			}
			SetupControllerListeners(on: false);
			Object.Destroy(base.gameObject);
		}

		private void OnTriggerPressed(object sender, ControllerInteractionEventArgs e)
		{
			triggerPressed = true;
		}

		private void SetupControllerListeners(bool on)
		{
			VRTK_ControllerEvents componentInChildren = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
			VRTK_ControllerEvents componentInChildren2 = VRTK_DeviceFinder.GetControllerRightHand(getActual: true).GetComponentInChildren<VRTK_ControllerEvents>(includeInactive: true);
			if (on)
			{
				componentInChildren.TriggerPressed += OnTriggerPressed;
				componentInChildren2.TriggerPressed += OnTriggerPressed;
			}
			else
			{
				componentInChildren.TriggerPressed -= OnTriggerPressed;
				componentInChildren2.TriggerPressed -= OnTriggerPressed;
			}
		}

		public static void Recalibrate()
		{
			if (!SingletonBehaviour<VRCalibration>.Instance)
			{
				new GameObject("VRCalibration").AddComponent<VRCalibration>();
			}
		}
	}
}
