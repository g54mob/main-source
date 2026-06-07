using DV.Telemetry;
using DV.Utils;
using UnityEngine;

public class TelemetryController : MonoBehaviour
{
	private void Awake()
	{
		SingletonBehaviour<TelemetryCentral>.Instance.enabled = GamePreferences.Get<bool>(Preferences.TelemetryEnabled);
		GamePreferences.RegisterToPreferenceUpdated(Preferences.TelemetryEnabled, OnTelemetrySettingChanged);
	}

	private void OnTelemetrySettingChanged()
	{
		SingletonBehaviour<TelemetryCentral>.Instance.enabled = GamePreferences.Get<bool>(Preferences.TelemetryEnabled);
		if (!SingletonBehaviour<TelemetryCentral>.Instance.enabled)
		{
			SingletonBehaviour<TelemetryCentral>.Instance.ReleaseBuffers();
		}
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.TelemetryEnabled, OnTelemetrySettingChanged);
	}
}
