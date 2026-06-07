using UnityEngine;

namespace Data.Lighting
{
	[CreateAssetMenu(menuName = "LightingConfig", fileName = "LightingConfig", order = 0)]
	public class LightingConfig : ScriptableObject
	{
		[SerializeField]
		private Color _ambientLightColor;

		[SerializeField]
		private float _environmentLightingIntensity;

		[SerializeField]
		private float _environmentReflectionIntensity;

		public float EnvironmentLightingIntensity => _environmentLightingIntensity;

		public float EnvironmentReflectionIntensity => _environmentReflectionIntensity;

		public void CopyCurrentValues()
		{
			_ambientLightColor = RenderSettings.ambientLight;
			_environmentLightingIntensity = RenderSettings.ambientIntensity;
			_environmentReflectionIntensity = RenderSettings.reflectionIntensity;
		}

		public void Apply()
		{
			RenderSettings.ambientLight = _ambientLightColor;
			RenderSettings.ambientIntensity = _environmentLightingIntensity;
			RenderSettings.reflectionIntensity = _environmentReflectionIntensity;
		}
	}
}
