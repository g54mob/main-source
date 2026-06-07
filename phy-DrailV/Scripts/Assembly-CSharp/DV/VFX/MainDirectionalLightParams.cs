using UnityEngine;

namespace DV.VFX
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Light))]
	public class MainDirectionalLightParams : MonoBehaviour
	{
		private readonly int sp_LightShadowData_DV = Shader.PropertyToID("_LightShadowData_DV");

		private Light directionalLight;

		private void Awake()
		{
			directionalLight = GetComponent<Light>();
			if (directionalLight.type != LightType.Directional)
			{
				Debug.LogError("MainDirectionalLightParams requires a directional light component.");
				base.enabled = false;
			}
		}

		private void LateUpdate()
		{
			Camera main = Camera.main;
			if ((bool)main)
			{
				Shader.SetGlobalVector(value: new Vector4(1f - directionalLight.shadowStrength, Mathf.Max(main.farClipPlane / QualitySettings.shadowDistance, 1f), 5f / Mathf.Min(main.farClipPlane, QualitySettings.shadowDistance), -1f * (2f + main.fieldOfView / 180f * 2f)), nameID: sp_LightShadowData_DV);
			}
		}
	}
}
