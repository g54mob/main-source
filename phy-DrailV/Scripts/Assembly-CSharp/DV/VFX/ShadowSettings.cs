using System.Linq;
using UnityEngine;

namespace DV.VFX
{
	public static class ShadowSettings
	{
		private struct ShadowsPreset
		{
			public ShadowQuality quality;

			public ShadowResolution resolution;

			public ShadowProjection projection;

			public int cascades;

			public float distance;

			public float lightAngle;

			public ShadowsPreset(ShadowQuality quality, ShadowResolution resolution, ShadowProjection projection, int cascades, float distance, float lightAngle)
			{
				this.quality = quality;
				this.resolution = resolution;
				this.projection = projection;
				this.cascades = cascades;
				this.distance = distance;
				this.lightAngle = lightAngle;
			}
		}

		private static readonly ShadowsPreset[] Presets = new ShadowsPreset[7]
		{
			new ShadowsPreset(ShadowQuality.Disable, ShadowResolution.Low, ShadowProjection.StableFit, 0, 0f, 0f),
			new ShadowsPreset(ShadowQuality.HardOnly, ShadowResolution.Low, ShadowProjection.StableFit, 0, 10f, 0.5f),
			new ShadowsPreset(ShadowQuality.HardOnly, ShadowResolution.Low, ShadowProjection.StableFit, 2, 40f, 0.5f),
			new ShadowsPreset(ShadowQuality.HardOnly, ShadowResolution.Medium, ShadowProjection.StableFit, 2, 100f, 0.5f),
			new ShadowsPreset(ShadowQuality.All, ShadowResolution.High, ShadowProjection.StableFit, 4, 400f, 0f),
			new ShadowsPreset(ShadowQuality.All, ShadowResolution.VeryHigh, ShadowProjection.StableFit, 4, 1000f, 0f),
			new ShadowsPreset(ShadowQuality.All, ShadowResolution.VeryHigh, ShadowProjection.StableFit, 4, 1200f, 0f)
		};

		public static void SetShadowSettings(GraphicsOptions.ShadowsQuality newShadowsQuality)
		{
			ShadowsPreset p = Presets[(int)newShadowsQuality];
			QualitySettings.shadows = p.quality;
			QualitySettings.shadowResolution = p.resolution;
			QualitySettings.shadowProjection = p.projection;
			QualitySettings.shadowCascades = p.cascades;
			QualitySettings.shadowDistance = p.distance;
			float distance = Presets.First((ShadowsPreset preset) => preset.cascades == p.cascades).distance;
			float num = (VRManager.IsVREnabled() ? 0.25f : 1f);
			if (p.cascades == 2)
			{
				QualitySettings.shadowCascade2Split = 0.2f * (distance / p.distance) * num;
			}
			else if (p.cascades == 4)
			{
				float num2 = distance * 0.03f * num;
				float num3 = distance * 0.1f;
				float x = num2 / p.distance;
				float num4 = num3 / p.distance;
				float num5 = 1f - num4;
				QualitySettings.shadowCascade4Split = new Vector3(x, num4, num4 + num5 * 0.3f);
			}
			TOD_Sky instance = TOD_Sky.Instance;
			if ((bool)instance)
			{
				instance.MinLightAngleMove = p.lightAngle;
			}
		}
	}
}
