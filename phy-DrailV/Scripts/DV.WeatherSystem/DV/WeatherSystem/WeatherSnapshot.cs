using System;
using UnityEngine;

namespace DV.WeatherSystem
{
	[Serializable]
	public class WeatherSnapshot
	{
		[Range(0f, 1f)]
		public float startTime;

		public float rayleigh;

		public float mie;

		public float brightness;

		public float contrast;

		public float directionality;

		public float fogginess;

		public float fogHeightBias;

		public float fogDensity;

		public float fogDistanceDensity;

		public float fogHeightDensity;

		public float fogHeight;

		public float cloudSize;

		public float cloudOpacity;

		public float cloudCoverage;

		public float cloudSharpness;

		public float cloudColoring;

		public float cloudAttenuation;

		public float cloudSaturation;

		public float cloudScattering;

		public float cloudBrightness;

		public float lightIntensity;

		public float shaftsIntensity;

		public float shadowStrength;

		public float ambientMult;

		public float skyIntensity;

		public float equatorIntensity;

		public float groundIntensity;

		public float reflectionMult;

		public float sunMeshBrightness;

		public float sunMeshContrast;

		public float moonMeshBrightness;

		public float moonMeshContrast;

		public float moonHaloSize;

		public float moonHaloBrightness;

		public float starsSize;

		public float starsBrightness;

		public float eyeAdaptationMin;

		public float eyeAdaptationMax;

		public float wetness;

		public float rainStrength;

		public Color lightColorDay;

		public Color lightColorNight;

		public Color skyColorDay;

		public Color skyColorNight;

		public Color cloudColorDay;

		public Color cloudColorNight;

		public Color sunMeshColor;

		public Color moonMeshColor;

		public Color sunRayColor;

		public Color moonRayColor;

		public Color ambientColor;

		public Color fogColor;

		private const float FogAdjustPower = 4f;

		private const float FogAdjustMultiplier = 1.5f;

		public float DisplayFogDensity
		{
			get
			{
				return ConvertStorageToDisplayFog(fogDensity);
			}
			set
			{
				fogDensity = ConvertDisplayToStorageFog(value);
			}
		}

		public float DisplayFogDistanceDensity
		{
			get
			{
				return ConvertStorageToDisplayFog(fogDistanceDensity);
			}
			set
			{
				fogDistanceDensity = ConvertDisplayToStorageFog(value);
			}
		}

		public float DisplayFogHeightDensity
		{
			get
			{
				return ConvertStorageToDisplayFog(fogHeightDensity);
			}
			set
			{
				fogHeightDensity = ConvertDisplayToStorageFog(value);
			}
		}

		public float OverallFogDensity => fogHeightDensity;

		public float OverallFogginess => fogginess;

		public static float ConvertDisplayToStorageFog(float val)
		{
			return Mathf.Pow(val, 0.25f) * 1.5f;
		}

		public static float ConvertStorageToDisplayFog(float val)
		{
			return Mathf.Pow(val / 1.5f, 4f);
		}

		public WeatherSnapshot Clone()
		{
			return (WeatherSnapshot)MemberwiseClone();
		}

		public void CopyFrom(WeatherSnapshot source)
		{
			rayleigh = source.rayleigh;
			mie = source.mie;
			brightness = source.brightness;
			contrast = source.contrast;
			directionality = source.directionality;
			fogginess = source.fogginess;
			fogHeightBias = source.fogHeightBias;
			fogDensity = source.fogDensity;
			fogDistanceDensity = source.fogDistanceDensity;
			fogHeightDensity = source.fogHeightDensity;
			fogHeight = source.fogHeight;
			cloudSize = source.cloudSize;
			cloudOpacity = source.cloudOpacity;
			cloudCoverage = source.cloudCoverage;
			cloudSharpness = source.cloudSharpness;
			cloudColoring = source.cloudColoring;
			cloudAttenuation = source.cloudAttenuation;
			cloudSaturation = source.cloudSaturation;
			cloudScattering = source.cloudScattering;
			cloudBrightness = source.cloudBrightness;
			lightIntensity = source.lightIntensity;
			shaftsIntensity = source.shaftsIntensity;
			shadowStrength = source.shadowStrength;
			ambientMult = source.ambientMult;
			skyIntensity = source.skyIntensity;
			equatorIntensity = source.equatorIntensity;
			groundIntensity = source.groundIntensity;
			reflectionMult = source.reflectionMult;
			sunMeshBrightness = source.sunMeshBrightness;
			sunMeshContrast = source.sunMeshContrast;
			moonMeshBrightness = source.moonMeshBrightness;
			moonMeshContrast = source.moonMeshContrast;
			moonHaloSize = source.moonHaloSize;
			moonHaloBrightness = source.moonHaloBrightness;
			starsSize = source.starsSize;
			starsBrightness = source.starsBrightness;
			eyeAdaptationMin = source.eyeAdaptationMin;
			eyeAdaptationMax = source.eyeAdaptationMax;
			wetness = source.wetness;
			rainStrength = source.rainStrength;
			lightColorDay = source.lightColorDay;
			lightColorNight = source.lightColorNight;
			skyColorDay = source.skyColorDay;
			skyColorNight = source.skyColorNight;
			cloudColorDay = source.cloudColorDay;
			cloudColorNight = source.cloudColorNight;
			sunMeshColor = source.sunMeshColor;
			moonMeshColor = source.moonMeshColor;
			sunRayColor = source.sunRayColor;
			moonRayColor = source.moonRayColor;
			ambientColor = source.ambientColor;
			fogColor = source.fogColor;
		}
	}
}
