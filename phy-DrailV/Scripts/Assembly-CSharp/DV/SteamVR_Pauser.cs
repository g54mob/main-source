using DV.UI;
using DV.Utils;
using UnityEngine;
using Valve.VR;

namespace DV
{
	public class SteamVR_Pauser : MonoBehaviour
	{
		private bool proxSensor;

		private bool requestingTextInput;

		private void Awake()
		{
			SingletonBehaviour<APlatformProvider>.Instance.OnTextInputStarted += OnTextInputStarted;
			SingletonBehaviour<APlatformProvider>.Instance.OnTextInputFinished += OnTextInputFinished;
			SteamVR_Events.System(EVREventType.VREvent_DashboardActivated).Listen(OnPauseRequiredEvent);
			SteamVR_Events.System(EVREventType.VREvent_PropertyChanged).Listen(OnPauseRequiredEvent);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isQuitting)
			{
				SingletonBehaviour<APlatformProvider>.Instance.OnTextInputStarted -= OnTextInputStarted;
				SingletonBehaviour<APlatformProvider>.Instance.OnTextInputFinished -= OnTextInputFinished;
				SteamVR_Events.System(EVREventType.VREvent_DashboardActivated).Remove(OnPauseRequiredEvent);
				SteamVR_Events.System(EVREventType.VREvent_PropertyChanged).Remove(OnPauseRequiredEvent);
			}
		}

		private void OnTextInputStarted(APlatformProvider.TextInputRequest _)
		{
			requestingTextInput = true;
		}

		private void OnTextInputFinished()
		{
			requestingTextInput = false;
		}

		private void OnPauseRequiredEvent(VREvent_t vrEvent)
		{
			if (!requestingTextInput && (vrEvent.eventType != 111 || vrEvent.data.property.prop == ETrackedDeviceProperty.Prop_DriverRequestsApplicationPause_Bool))
			{
				if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: true);
				}
				else
				{
					Debug.LogError("CanvasController isn't present!");
				}
			}
		}

		private void Update()
		{
			bool press = SteamVR_Controller.Input(0).GetPress(EVRButtonId.k_EButton_ProximitySensor);
			if (proxSensor == press)
			{
				return;
			}
			proxSensor = press;
			if (!proxSensor && !requestingTextInput)
			{
				if ((bool)SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance)
				{
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: true);
				}
				else
				{
					Debug.LogError("CanvasController isn't present!");
				}
			}
		}
	}
}
