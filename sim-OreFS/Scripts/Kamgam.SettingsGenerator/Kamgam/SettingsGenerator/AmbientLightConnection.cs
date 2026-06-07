using UnityEngine;
using UnityEngine.Rendering;

namespace Kamgam.SettingsGenerator
{
	public class AmbientLightConnection : Connection<float>
	{
		public float MinColorIntensity = 0.01f;

		public float MaxColorIntensity = 2f;

		public override float Get()
		{
			if (RenderSettings.ambientMode == AmbientMode.Skybox && RenderSettings.skybox != null)
			{
				return MathUtils.MapWithAnchor(RenderSettings.ambientIntensity, 0f, 1f, 8f, 0f, 50f, 100f);
			}
			Color ambientLight = RenderSettings.ambientLight;
			return MathUtils.MapWithAnchor(Mathf.Max(Mathf.Max(ambientLight.r, ambientLight.g, ambientLight.b), 0.01f), 0f, MaxColorIntensity * 0.5f, MaxColorIntensity, 0f, 50f, 100f);
		}

		public override void Set(float intensity)
		{
			intensity = Mathf.Max(intensity, MinColorIntensity);
			if (RenderSettings.ambientMode == AmbientMode.Skybox && RenderSettings.skybox != null)
			{
				RenderSettings.ambientIntensity = MathUtils.MapWithAnchor(intensity, 0f, 50f, 100f, 0f, 1f, 8f);
			}
			else
			{
				float num = MathUtils.MapWithAnchor(intensity, 0f, 50f, 100f, 0f, MaxColorIntensity * 0.5f, MaxColorIntensity);
				Color ambientLight = RenderSettings.ambientLight;
				float num2 = Mathf.Max(ambientLight.r, ambientLight.g, ambientLight.b);
				float num3 = num / num2;
				RenderSettings.ambientLight = new Color(Mathf.Min(ambientLight.r * num3, 2f), Mathf.Min(ambientLight.g * num3, 2f), Mathf.Min(ambientLight.b * num3, 2f));
			}
			NotifyListenersIfChanged(intensity);
		}
	}
}
