using System;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class EclipseModule : CozyModule
	{
		public enum EclipseStyle
		{
			manual = 0,
			occlusion = 1
		}

		[Range(0f, 1f)]
		public float eclipseRatio;

		public EclipseStyle eclipseStyle = EclipseStyle.occlusion;

		[GradientUsage(true)]
		public Gradient skyZenithColor;

		[GradientUsage(true)]
		public Gradient skyHorizonColor;

		[GradientUsage(true)]
		public Gradient cloudColor;

		[GradientUsage(true)]
		public Gradient cloudHighlightColor;

		[GradientUsage(true)]
		public Gradient highAltitudeCloudColor;

		[GradientUsage(true)]
		public Gradient sunlightColor;

		[GradientUsage(true)]
		public Gradient moonlightColor;

		[GradientUsage(true)]
		public Gradient starColor;

		[GradientUsage(true)]
		public Gradient ambientLightHorizonColor;

		[GradientUsage(true)]
		public Gradient ambientLightZenithColor;

		public AnimationCurve ambientLightMultiplier;

		public AnimationCurve galaxyIntensity;

		[GradientUsage(true)]
		public Gradient fogColor1;

		[GradientUsage(true)]
		public Gradient fogColor2;

		[GradientUsage(true)]
		public Gradient fogColor3;

		[GradientUsage(true)]
		public Gradient fogColor4;

		[GradientUsage(true)]
		public Gradient fogColor5;

		[GradientUsage(true)]
		public Gradient fogFlareColor;

		[GradientUsage(true)]
		public Gradient fogMoonFlareColor;

		public AnimationCurve fogSmoothness;

		[GradientUsage(true)]
		public Gradient sunColor;

		public AnimationCurve sunFlareFalloff;

		[GradientUsage(true)]
		public Gradient sunFlareColor;

		public AnimationCurve moonFalloff;

		[GradientUsage(true)]
		public Gradient moonFlareColor;

		[GradientUsage(true)]
		public Gradient galaxy1Color;

		[GradientUsage(true)]
		public Gradient galaxy2Color;

		[GradientUsage(true)]
		public Gradient galaxy3Color;

		[GradientUsage(true)]
		public Gradient lightScatteringColor;

		public AnimationCurve fogLightFlareIntensity;

		public AnimationCurve fogLightFlareFalloff;

		[GradientUsage(true)]
		public Gradient cloudMoonColor;

		[GradientUsage(true)]
		public Gradient cloudTextureColor;

		[Range(0f, 1f)]
		public float moonSize = 0.95f;

		public EclipseProfile profile;

		public void Update()
		{
			Shader.SetGlobalVector(CozyShaderIDs.CZY_EclipseDirectionID, base.weatherSphere.moonDirection);
		}

		public override void PropogateVariables()
		{
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_MoonSizeID, moonSize);
			if (eclipseStyle == EclipseStyle.occlusion)
			{
				eclipseRatio = Mathf.Clamp01((0f - Vector3.Dot(base.weatherSphere.sunTransform.forward, base.weatherSphere.moonDirection) - 0.995f) / 0.004999995f) * Mathf.Clamp01(MathF.Sin(MathF.PI * 2f * (base.weatherSphere.dayPercentage - 0.25f)));
			}
			if (eclipseRatio > 0f)
			{
				Color color = profile.skyZenithColor.Evaluate(eclipseRatio);
				base.weatherSphere.skyZenithColor = Color.Lerp(base.weatherSphere.skyZenithColor, new Color(color.r, color.g, color.b, base.weatherSphere.skyZenithColor.a), color.a);
				color = profile.skyHorizonColor.Evaluate(eclipseRatio);
				base.weatherSphere.skyHorizonColor = Color.Lerp(base.weatherSphere.skyHorizonColor, new Color(color.r, color.g, color.b, base.weatherSphere.skyHorizonColor.a), color.a);
				color = profile.cloudColor.Evaluate(eclipseRatio);
				base.weatherSphere.cloudColor = Color.Lerp(base.weatherSphere.cloudColor, new Color(color.r, color.g, color.b, base.weatherSphere.cloudColor.a), color.a);
				color = profile.cloudHighlightColor.Evaluate(eclipseRatio);
				base.weatherSphere.cloudHighlightColor = Color.Lerp(base.weatherSphere.cloudHighlightColor, new Color(color.r, color.g, color.b, base.weatherSphere.cloudHighlightColor.a), color.a);
				color = profile.highAltitudeCloudColor.Evaluate(eclipseRatio);
				base.weatherSphere.highAltitudeCloudColor = Color.Lerp(base.weatherSphere.highAltitudeCloudColor, new Color(color.r, color.g, color.b, base.weatherSphere.highAltitudeCloudColor.a), color.a);
				color = profile.sunlightColor.Evaluate(eclipseRatio);
				base.weatherSphere.sunlightColor = Color.Lerp(base.weatherSphere.sunlightColor, new Color(color.r, color.g, color.b, base.weatherSphere.sunlightColor.a), color.a);
				color = profile.moonlightColor.Evaluate(eclipseRatio);
				base.weatherSphere.moonlightColor = Color.Lerp(base.weatherSphere.moonlightColor, new Color(color.r, color.g, color.b, base.weatherSphere.moonlightColor.a), color.a);
				color = profile.starColor.Evaluate(eclipseRatio);
				base.weatherSphere.starColor = Color.Lerp(base.weatherSphere.starColor, new Color(color.r, color.g, color.b, base.weatherSphere.starColor.a), color.a);
				color = profile.ambientLightHorizonColor.Evaluate(eclipseRatio);
				base.weatherSphere.ambientLightHorizonColor = Color.Lerp(base.weatherSphere.ambientLightHorizonColor, new Color(color.r, color.g, color.b, base.weatherSphere.ambientLightHorizonColor.a), color.a);
				color = profile.ambientLightZenithColor.Evaluate(eclipseRatio);
				base.weatherSphere.ambientLightZenithColor = Color.Lerp(base.weatherSphere.ambientLightZenithColor, new Color(color.r, color.g, color.b, base.weatherSphere.ambientLightZenithColor.a), color.a);
				float b = profile.ambientLightMultiplier.Evaluate(eclipseRatio);
				base.weatherSphere.ambientLightMultiplier = Mathf.Lerp(base.weatherSphere.ambientLightMultiplier, b, eclipseRatio);
				b = profile.galaxyIntensity.Evaluate(eclipseRatio);
				base.weatherSphere.galaxyIntensity = Mathf.Lerp(base.weatherSphere.galaxyIntensity, b, eclipseRatio);
				b = profile.sunFlareFalloff.Evaluate(eclipseRatio);
				base.weatherSphere.sunFalloff = Mathf.Lerp(base.weatherSphere.sunFalloff, b, eclipseRatio);
				color = profile.fogColor1.Evaluate(eclipseRatio);
				base.weatherSphere.fogColor1 = Color.Lerp(base.weatherSphere.fogColor1, new Color(color.r, color.g, color.b, base.weatherSphere.fogColor1.a), color.a);
				color = profile.fogColor2.Evaluate(eclipseRatio);
				base.weatherSphere.fogColor2 = Color.Lerp(base.weatherSphere.fogColor2, new Color(color.r, color.g, color.b, base.weatherSphere.fogColor2.a), color.a);
				color = profile.fogColor3.Evaluate(eclipseRatio);
				base.weatherSphere.fogColor3 = Color.Lerp(base.weatherSphere.fogColor3, new Color(color.r, color.g, color.b, base.weatherSphere.fogColor3.a), color.a);
				color = profile.fogColor4.Evaluate(eclipseRatio);
				base.weatherSphere.fogColor4 = Color.Lerp(base.weatherSphere.fogColor4, new Color(color.r, color.g, color.b, base.weatherSphere.fogColor4.a), color.a);
				color = profile.fogColor5.Evaluate(eclipseRatio);
				base.weatherSphere.fogColor5 = Color.Lerp(base.weatherSphere.fogColor5, new Color(color.r, color.g, color.b, base.weatherSphere.fogColor5.a), color.a);
				color = profile.fogFlareColor.Evaluate(eclipseRatio);
				base.weatherSphere.fogFlareColor = Color.Lerp(base.weatherSphere.fogFlareColor, new Color(color.r, color.g, color.b, base.weatherSphere.fogFlareColor.a), color.a);
				color = profile.fogMoonFlareColor.Evaluate(eclipseRatio);
				base.weatherSphere.fogMoonFlareColor = Color.Lerp(base.weatherSphere.fogMoonFlareColor, new Color(color.r, color.g, color.b, base.weatherSphere.fogMoonFlareColor.a), color.a);
				b = profile.fogSmoothness.Evaluate(eclipseRatio);
				base.weatherSphere.fogSmoothness = Mathf.Lerp(base.weatherSphere.fogSmoothness, b, eclipseRatio);
				color = profile.sunColor.Evaluate(eclipseRatio);
				base.weatherSphere.sunColor = Color.Lerp(base.weatherSphere.sunColor, new Color(color.r, color.g, color.b, base.weatherSphere.sunColor.a), color.a);
				b = profile.sunFlareFalloff.Evaluate(eclipseRatio);
				base.weatherSphere.sunFalloff = Mathf.Lerp(base.weatherSphere.sunFalloff, b, eclipseRatio);
				color = profile.sunFlareColor.Evaluate(eclipseRatio);
				base.weatherSphere.sunFlareColor = Color.Lerp(base.weatherSphere.sunFlareColor, new Color(color.r, color.g, color.b, base.weatherSphere.sunFlareColor.a), color.a);
				b = profile.moonFalloff.Evaluate(eclipseRatio);
				base.weatherSphere.moonFalloff = Mathf.Lerp(base.weatherSphere.moonFalloff, b, eclipseRatio);
				color = profile.moonFlareColor.Evaluate(eclipseRatio);
				base.weatherSphere.moonFlareColor = Color.Lerp(base.weatherSphere.moonFlareColor, new Color(color.r, color.g, color.b, base.weatherSphere.moonFlareColor.a), color.a);
				color = profile.galaxy1Color.Evaluate(eclipseRatio);
				base.weatherSphere.galaxy1Color = Color.Lerp(base.weatherSphere.galaxy1Color, new Color(color.r, color.g, color.b, base.weatherSphere.galaxy1Color.a), color.a);
				color = profile.galaxy2Color.Evaluate(eclipseRatio);
				base.weatherSphere.galaxy2Color = Color.Lerp(base.weatherSphere.galaxy2Color, new Color(color.r, color.g, color.b, base.weatherSphere.galaxy2Color.a), color.a);
				color = profile.galaxy3Color.Evaluate(eclipseRatio);
				base.weatherSphere.galaxy3Color = Color.Lerp(base.weatherSphere.galaxy3Color, new Color(color.r, color.g, color.b, base.weatherSphere.galaxy3Color.a), color.a);
				color = profile.lightScatteringColor.Evaluate(eclipseRatio);
				base.weatherSphere.lightScatteringColor = Color.Lerp(base.weatherSphere.lightScatteringColor, new Color(color.r, color.g, color.b, base.weatherSphere.lightScatteringColor.a), color.a);
				b = profile.fogLightFlareIntensity.Evaluate(eclipseRatio);
				base.weatherSphere.fogLightFlareIntensity = Mathf.Lerp(base.weatherSphere.fogLightFlareIntensity, b, eclipseRatio);
				b = profile.fogLightFlareFalloff.Evaluate(eclipseRatio);
				base.weatherSphere.fogLightFlareFalloff = Mathf.Lerp(base.weatherSphere.fogLightFlareFalloff, b, eclipseRatio);
				color = profile.cloudMoonColor.Evaluate(eclipseRatio);
				base.weatherSphere.cloudMoonColor = Color.Lerp(base.weatherSphere.cloudMoonColor, new Color(color.r, color.g, color.b, base.weatherSphere.cloudMoonColor.a), color.a);
				color = profile.cloudTextureColor.Evaluate(eclipseRatio);
				base.weatherSphere.cloudTextureColor = Color.Lerp(base.weatherSphere.cloudTextureColor, new Color(color.r, color.g, color.b, base.weatherSphere.cloudTextureColor.a), color.a);
			}
		}

		public void GetAngles(out float orbit, out float declination)
		{
			if (!base.weatherSphere.timeModule || !base.weatherSphere.GetModule<CozySatelliteModule>())
			{
				orbit = 1f;
				declination = 1f;
				return;
			}
			base.weatherSphere.GetModule(out CozySatelliteModule module);
			SatelliteProfile satelliteProfile = module.satellites[base.weatherSphere.GetModule<CozySatelliteModule>().mainMoon];
			int num = base.weatherSphere.timeModule.AbsoluteDay - satelliteProfile.rotationPeriodOffset;
			int num2 = satelliteProfile.declinationPeriod / 2;
			orbit = (float)(num % satelliteProfile.rotationPeriod) / (float)satelliteProfile.rotationPeriod;
			declination = (float)(num % num2) / (float)num2;
		}

		public int DaysTillNextEclipse()
		{
			if (!base.weatherSphere.timeModule || !base.weatherSphere.GetModule<CozySatelliteModule>())
			{
				return -1;
			}
			base.weatherSphere.GetModule(out CozySatelliteModule module);
			SatelliteProfile satelliteProfile = module.satellites[base.weatherSphere.GetModule<CozySatelliteModule>().mainMoon];
			int num = satelliteProfile.declinationPeriod / 2;
			int num2 = satelliteProfile.rotationPeriod * num / GCD(satelliteProfile.rotationPeriod, num);
			int num3 = (base.weatherSphere.timeModule.AbsoluteDay - satelliteProfile.rotationPeriodOffset) % num2;
			return (num2 - num3) % num2;
		}

		public void GetNextEclipseDate(out int day, out int year)
		{
			day = -1;
			year = -1;
			if ((bool)base.weatherSphere.timeModule && (bool)base.weatherSphere.GetModule<CozySatelliteModule>())
			{
				base.weatherSphere.GetModule(out CozySatelliteModule module);
				SatelliteProfile satelliteProfile = module.satellites[base.weatherSphere.GetModule<CozySatelliteModule>().mainMoon];
				int num = satelliteProfile.declinationPeriod / 2;
				int num2 = satelliteProfile.rotationPeriod * num / GCD(satelliteProfile.rotationPeriod, num);
				int num3 = (base.weatherSphere.timeModule.AbsoluteDay - satelliteProfile.rotationPeriodOffset) % num2;
				int num4 = (num2 - num3) % num2;
				day = num4 % base.weatherSphere.timeModule.DaysPerYear;
				year = Mathf.FloorToInt(num4 / base.weatherSphere.timeModule.DaysPerYear);
			}
		}

		public float DeclinationCyclePosition()
		{
			return DeclinationCyclePosition(0);
		}

		public float DeclinationCyclePosition(int dayOffset)
		{
			if (!base.weatherSphere.timeModule || !base.weatherSphere.GetModule<CozySatelliteModule>())
			{
				return -1f;
			}
			base.weatherSphere.GetModule(out CozySatelliteModule module);
			SatelliteProfile satelliteProfile = module.satellites[base.weatherSphere.GetModule<CozySatelliteModule>().mainMoon];
			float num = satelliteProfile.declinationPeriod;
			return (float)(base.weatherSphere.timeModule.AbsoluteDay - satelliteProfile.rotationPeriodOffset + dayOffset) % num / num;
		}

		public float OrbitCyclePosition()
		{
			return OrbitCyclePosition(0);
		}

		public float OrbitCyclePosition(int dayOffset)
		{
			if (!base.weatherSphere.timeModule || !base.weatherSphere.GetModule<CozySatelliteModule>())
			{
				return -1f;
			}
			base.weatherSphere.GetModule(out CozySatelliteModule module);
			SatelliteProfile satelliteProfile = module.satellites[base.weatherSphere.GetModule<CozySatelliteModule>().mainMoon];
			return (float)(base.weatherSphere.timeModule.AbsoluteDay - satelliteProfile.rotationPeriodOffset + dayOffset) % (float)satelliteProfile.rotationPeriod / (float)satelliteProfile.rotationPeriod;
		}

		private static int GCD(int a, int b)
		{
			while (b != 0)
			{
				int num = b;
				b = a % b;
				a = num;
			}
			return a;
		}

		public override void DeinitializeModule()
		{
			base.DeinitializeModule();
			Shader.SetGlobalVector(CozyShaderIDs.CZY_EclipseDirectionID, -Vector3.up);
			Shader.SetGlobalFloat(CozyShaderIDs.CZY_MoonSizeID, 1f);
		}
	}
}
