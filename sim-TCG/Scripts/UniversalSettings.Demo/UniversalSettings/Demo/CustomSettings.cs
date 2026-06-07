using UnityEngine;

namespace UniversalSettings.Demo
{
	public class CustomSettings : MonoBehaviour
	{
		[SerializeField]
		private PulseScale pulseScale;

		[SerializeField]
		private MeshRenderer cubeRenderer;

		[SerializeField]
		private Material[] cubeColors;

		private void Start()
		{
			UniversalSettingsRunner.Instance.onApplySettings += UpdateCustomSettings;
			UpdateCustomSettings();
		}

		private void OnDestroy()
		{
			UniversalSettingsRunner.Instance.onApplySettings -= UpdateCustomSettings;
		}

		private void UpdateCustomSettings()
		{
			bool customBoolean = UniversalSettingsRunner.Instance.GetCustomBoolean(0);
			float customFloat = UniversalSettingsRunner.Instance.GetCustomFloat(0);
			int customInteger = UniversalSettingsRunner.Instance.GetCustomInteger(0);
			RenderSettings.fog = customBoolean;
			pulseScale.speed = customFloat * 10f;
			cubeRenderer.sharedMaterial = cubeColors[customInteger];
		}
	}
}
