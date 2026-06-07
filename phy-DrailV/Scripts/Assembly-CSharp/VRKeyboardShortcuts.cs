using DV.Interaction.Inputs;
using DV.Utils;
using DV.VR;
using UnityEngine;

public class VRKeyboardShortcuts : MonoBehaviour
{
	private void Awake()
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.VRDebugShortcuts, OnPrefChanged);
		OnPrefChanged();
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.VRDebugShortcuts, OnPrefChanged);
	}

	private void OnPrefChanged()
	{
		base.enabled = GamePreferences.Get<bool>(Preferences.VRDebugShortcuts);
	}

	private void Update()
	{
		if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Recenter))
		{
			Recenter();
		}
		if (InputManager.NewPlayer.GetButtonUp(InputManager.Actions.ToggleTrackingMode))
		{
			ToggleTrackingMode();
		}
	}

	private void Recenter()
	{
		if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
		{
			SingletonBehaviour<VRManager>.Instance.ResetSeatedPosition();
		}
		else
		{
			VRCalibration.Recalibrate();
		}
	}

	private void ToggleTrackingMode()
	{
		bool value = !GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);
		GamePreferences.Set(Preferences.SeatedPlayAreaType, value);
	}
}
