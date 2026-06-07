using UnityEngine;
using VRTK;

public class LocomotionControlsToggle : MonoBehaviour
{
	public GameObject teleportLocomotion;

	public GameObject smoothLocomotion;

	public PlayerInputTouchpadControl touchpadControl;

	private bool controlsEnabled = true;

	private void Awake()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
		if (controllerReference != null && controllerReference.hand == hand)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			GamePreferences.RegisterToPreferenceUpdated(Preferences.SmoothLocomotion, OnSmoothLocomotionChanged);
			OnSmoothLocomotionChanged();
			OnTeleportLocomotionChanged();
		}
	}

	private void OnDestroy()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		if (!UnloadWatcher.isUnloading)
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SmoothLocomotion, OnSmoothLocomotionChanged);
		}
	}

	private void OnSmoothLocomotionChanged()
	{
		bool flag = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
		ToggleSmoothLocomotionGameObject(flag && controlsEnabled);
	}

	private void OnTeleportLocomotionChanged()
	{
		ToggleTeleportLocomotionGameObject(on: true);
	}

	private void ToggleSmoothLocomotionGameObject(bool on)
	{
		touchpadControl.ResetInput();
		smoothLocomotion.SetActive(on);
	}

	public void ToggleTeleportLocomotionGameObject(bool on, bool resetInput = true)
	{
		if (resetInput)
		{
			touchpadControl.ResetInput();
		}
		touchpadControl.ResetInput();
		teleportLocomotion.SetActive(on);
	}

	public void ToggleControls(bool controlsEnabled)
	{
		this.controlsEnabled = controlsEnabled;
		OnSmoothLocomotionChanged();
		OnTeleportLocomotionChanged();
	}
}
