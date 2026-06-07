using UnityEngine;

namespace DV.Interaction.Inputs
{
	public class MouseSensitivitySetter : MonoBehaviour
	{
		private void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				GamePreferences.RegisterToPreferenceUpdated(Preferences.MouseSensitivity, OnSens);
				OnSens();
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.MouseSensitivity, OnSens);
			}
		}

		private void OnSens()
		{
			InputManager.MouseSensitivity = GamePreferences.Get<float>(Preferences.MouseSensitivity);
		}
	}
}
