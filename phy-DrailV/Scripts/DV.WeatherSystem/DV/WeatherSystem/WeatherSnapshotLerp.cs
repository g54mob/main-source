using UnityEngine;

namespace DV.WeatherSystem
{
	public class WeatherSnapshotLerp
	{
		public WeatherSnapshot a;

		public WeatherSnapshot b;

		public WeatherSnapshot lerped;

		public float lerpFactor;

		public WeatherSnapshotLerp()
		{
			lerped = new WeatherSnapshot();
		}

		public void Lerp()
		{
			Lerp(a, b, lerpFactor, lerped);
		}

		public static WeatherSnapshot Lerp(WeatherSnapshot a, WeatherSnapshot b, float lerpFactor, WeatherSnapshot lerped = null)
		{
			if (lerped == null)
			{
				lerped = new WeatherSnapshot();
			}
			lerped.startTime = lerpFactor;
			lerped.rayleigh = Mathf.Lerp(a.rayleigh, b.rayleigh, lerpFactor);
			lerped.mie = Mathf.Lerp(a.mie, b.mie, lerpFactor);
			lerped.brightness = Mathf.Lerp(a.brightness, b.brightness, lerpFactor);
			lerped.contrast = Mathf.Lerp(a.contrast, b.contrast, lerpFactor);
			lerped.directionality = Mathf.Lerp(a.directionality, b.directionality, lerpFactor);
			lerped.fogginess = Mathf.Lerp(a.fogginess, b.fogginess, lerpFactor);
			lerped.fogHeightBias = Mathf.Lerp(a.fogHeightBias, b.fogHeightBias, lerpFactor);
			lerped.fogDensity = Mathf.Lerp(a.fogDensity, b.fogDensity, lerpFactor);
			lerped.fogDistanceDensity = Mathf.Lerp(a.fogDistanceDensity, b.fogDistanceDensity, lerpFactor);
			lerped.fogHeightDensity = Mathf.Lerp(a.fogHeightDensity, b.fogHeightDensity, lerpFactor);
			lerped.fogHeight = Mathf.Lerp(a.fogHeight, b.fogHeight, lerpFactor);
			lerped.cloudSize = Mathf.Lerp(a.cloudSize, b.cloudSize, lerpFactor);
			lerped.cloudOpacity = Mathf.Lerp(a.cloudOpacity, b.cloudOpacity, lerpFactor);
			lerped.cloudCoverage = Mathf.Lerp(a.cloudCoverage, b.cloudCoverage, lerpFactor);
			lerped.cloudSharpness = Mathf.Lerp(a.cloudSharpness, b.cloudSharpness, lerpFactor);
			lerped.cloudColoring = Mathf.Lerp(a.cloudColoring, b.cloudColoring, lerpFactor);
			lerped.cloudAttenuation = Mathf.Lerp(a.cloudAttenuation, b.cloudAttenuation, lerpFactor);
			lerped.cloudSaturation = Mathf.Lerp(a.cloudSaturation, b.cloudSaturation, lerpFactor);
			lerped.cloudScattering = Mathf.Lerp(a.cloudScattering, b.cloudScattering, lerpFactor);
			lerped.cloudBrightness = Mathf.Lerp(a.cloudBrightness, b.cloudBrightness, lerpFactor);
			lerped.lightIntensity = Mathf.Lerp(a.lightIntensity, b.lightIntensity, lerpFactor);
			lerped.shaftsIntensity = Mathf.Lerp(a.shaftsIntensity, b.shaftsIntensity, lerpFactor);
			lerped.shadowStrength = Mathf.Lerp(a.shadowStrength, b.shadowStrength, lerpFactor);
			lerped.ambientMult = Mathf.Lerp(a.ambientMult, b.ambientMult, lerpFactor);
			lerped.skyIntensity = Mathf.Lerp(a.skyIntensity, b.skyIntensity, lerpFactor);
			lerped.equatorIntensity = Mathf.Lerp(a.equatorIntensity, b.equatorIntensity, lerpFactor);
			lerped.groundIntensity = Mathf.Lerp(a.groundIntensity, b.groundIntensity, lerpFactor);
			lerped.reflectionMult = Mathf.Lerp(a.reflectionMult, b.reflectionMult, lerpFactor);
			lerped.sunMeshBrightness = Mathf.Lerp(a.sunMeshBrightness, b.sunMeshBrightness, lerpFactor);
			lerped.sunMeshContrast = Mathf.Lerp(a.sunMeshContrast, b.sunMeshContrast, lerpFactor);
			lerped.moonMeshBrightness = Mathf.Lerp(a.moonMeshBrightness, b.moonMeshBrightness, lerpFactor);
			lerped.moonMeshContrast = Mathf.Lerp(a.moonMeshContrast, b.moonMeshContrast, lerpFactor);
			lerped.moonHaloSize = Mathf.Lerp(a.moonHaloSize, b.moonHaloSize, lerpFactor);
			lerped.moonHaloBrightness = Mathf.Lerp(a.moonHaloBrightness, b.moonHaloBrightness, lerpFactor);
			lerped.starsSize = Mathf.Lerp(a.starsSize, b.starsSize, lerpFactor);
			lerped.starsBrightness = Mathf.Lerp(a.starsBrightness, b.starsBrightness, lerpFactor);
			lerped.eyeAdaptationMin = Mathf.Lerp(a.eyeAdaptationMin, b.eyeAdaptationMin, lerpFactor);
			lerped.eyeAdaptationMax = Mathf.Lerp(a.eyeAdaptationMax, b.eyeAdaptationMax, lerpFactor);
			lerped.wetness = Mathf.Lerp(a.wetness, b.wetness, lerpFactor);
			lerped.rainStrength = Mathf.Lerp(a.rainStrength, b.rainStrength, lerpFactor);
			lerped.lightColorDay = Color.Lerp(a.lightColorDay, b.lightColorDay, lerpFactor);
			lerped.lightColorNight = Color.Lerp(a.lightColorNight, b.lightColorNight, lerpFactor);
			lerped.skyColorDay = Color.Lerp(a.skyColorDay, b.skyColorDay, lerpFactor);
			lerped.skyColorNight = Color.Lerp(a.skyColorNight, b.skyColorNight, lerpFactor);
			lerped.cloudColorDay = Color.Lerp(a.cloudColorDay, b.cloudColorDay, lerpFactor);
			lerped.cloudColorNight = Color.Lerp(a.cloudColorNight, b.cloudColorNight, lerpFactor);
			lerped.sunMeshColor = Color.Lerp(a.sunMeshColor, b.sunMeshColor, lerpFactor);
			lerped.moonMeshColor = Color.Lerp(a.moonMeshColor, b.moonMeshColor, lerpFactor);
			lerped.sunRayColor = Color.Lerp(a.sunRayColor, b.sunRayColor, lerpFactor);
			lerped.moonRayColor = Color.Lerp(a.moonRayColor, b.moonRayColor, lerpFactor);
			lerped.ambientColor = Color.Lerp(a.ambientColor, b.ambientColor, lerpFactor);
			lerped.fogColor = Color.Lerp(a.fogColor, b.fogColor, lerpFactor);
			return lerped;
		}
	}
}
