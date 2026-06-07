using System;
using System.Collections.Generic;
using System.Linq;
using SCPE;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DV.WeatherSystem
{
	public class WeatherPresetManager : MonoBehaviour
	{
		public TOD_Sky todSky;

		public TOD_Time todTime;

		[Header("Additional effects")]
		public MeshRenderer sunGlare;

		public Vector2 shaftsMinMax = new Vector2(0.1f, 1f);

		[NonSerialized]
		public float timeOfDay;

		[NonSerialized]
		public float fogDistanceDensity;

		[NonSerialized]
		public float fogHeight;

		private float fogHeightDensity;

		[NonSerialized]
		public float? cloudCoverageOverride;

		[NonSerialized]
		public float? heightFogDensityOverride;

		[Header("Light correction")]
		public bool dimLightByClouds = true;

		public float cloudCoverageDimmingStart = 0.75f;

		public float cloudCoverageDimmingEnd = 0.9f;

		private AutoExposure autoExposure;

		private Sunshafts sunShafts;

		private WeatherSnapshot internalSnapshot = new WeatherSnapshot();

		private int sp_Brightness = Shader.PropertyToID("_Brightness");

		public Weather24hPresetSO CurrentPreset { get; private set; }

		public float FogHeightDensity => heightFogDensityOverride ?? fogHeightDensity;

		public Light LightSource
		{
			get
			{
				if (!(todSky != null) || !(todSky.Components != null))
				{
					return null;
				}
				return todSky.Components.LightSource;
			}
		}

		public OverridableValue<float> TimeOfDayHours => todSky.Cycle.Hour;

		public DateTime DateTime
		{
			get
			{
				if (!(todSky != null) || todSky.Cycle == null)
				{
					return DateTime.Now;
				}
				return todSky.Cycle.DateTime;
			}
		}

		public DateTime RealDateTime
		{
			get
			{
				if (!(todSky != null) || todSky.Cycle == null)
				{
					return DateTime.Now;
				}
				return todSky.Cycle.RealDateTime;
			}
		}

		public OverridableValue<float> DayLengthInMinutes => todTime.DayLengthInMinutes;

		public WeatherSnapshot LerpedSnapshot => internalSnapshot;

		public event Action TimeJump;

		public event Action SecondChanged;

		public event Action MinuteChanged;

		public event Action HourChanged;

		public void SetSnapshot(WeatherSnapshot snapshot, Weather24hPresetSO closestPreset)
		{
			internalSnapshot.CopyFrom(snapshot);
			CurrentPreset = closestPreset;
		}

		private void Start()
		{
			FindPostProcessing();
			todTime.OnSecond += delegate
			{
				this.SecondChanged?.Invoke();
			};
			todTime.OnMinute += delegate
			{
				this.MinuteChanged?.Invoke();
			};
			todTime.OnHour += delegate
			{
				this.HourChanged?.Invoke();
			};
		}

		private void OnEnable()
		{
			if (todSky == null || todTime == null)
			{
				Debug.LogWarning("WeatherPresetManager doesn't have Time Of Day components assigned, disabling self");
				base.enabled = false;
			}
			else
			{
				todSky.deferValueUpdates = true;
				todSky.UpdateScatteringValuesRequested += UpdateScattering;
				todSky.UpdateOtherValuesRequested += UpdateRest;
			}
		}

		private void OnDisable()
		{
			todSky.UpdateScatteringValuesRequested -= UpdateScattering;
			todSky.UpdateOtherValuesRequested -= UpdateRest;
		}

		public void AdvanceTime(float amountOfTimeToSkipInSeconds)
		{
			todSky.Cycle.DateTime += TimeSpan.FromSeconds(amountOfTimeToSkipInSeconds);
			RefreshTimeOfDay();
		}

		public void SetTimeOfDay(float timeOfDay01)
		{
			todSky.Cycle.Hour.CurrentValue = Mathf.Lerp(0f, 24f, timeOfDay01);
			RefreshTimeOfDay();
		}

		public void RefreshTimeOfDay()
		{
			this.TimeJump?.Invoke();
			this.SecondChanged?.Invoke();
			this.MinuteChanged?.Invoke();
			this.HourChanged?.Invoke();
		}

		private void FindPostProcessing()
		{
			List<PostProcessVolume> list = (from v in UnityEngine.Object.FindObjectsOfType<PostProcessVolume>()
				where v.isGlobal
				select v).ToList();
			if (list.Count == 0)
			{
				Debug.LogWarning("WeatherPresetManager couldn't find any Post Processing volumes in scene");
				return;
			}
			foreach (PostProcessVolume item in list)
			{
				item.profile.TryGetSettings<Sunshafts>(out var outSetting);
				if (!sunShafts && (bool)outSetting)
				{
					sunShafts = outSetting;
				}
				else if ((bool)outSetting)
				{
					Debug.LogWarning("WeatherPresetManager found more than 1 global Post Processing volume with SunShafts, will use first.");
				}
			}
			if (!sunShafts)
			{
				Debug.LogWarning("WeatherPresetManager couldn't find Sunshafts on any volume's profile");
			}
		}

		private void Update()
		{
			timeOfDay = Mathf.Clamp01(Mathf.InverseLerp(0f, 24f, todSky.Cycle.Hour));
		}

		private void UpdateScattering()
		{
			TOD_AtmosphereParameters atmosphere = todSky.Atmosphere;
			WeatherSnapshot lerpedSnapshot = LerpedSnapshot;
			atmosphere.Directionality = lerpedSnapshot.directionality;
			atmosphere.MieMultiplier = lerpedSnapshot.mie;
			atmosphere.RayleighMultiplier = lerpedSnapshot.rayleigh;
			atmosphere.Brightness = lerpedSnapshot.brightness;
			atmosphere.Fogginess = lerpedSnapshot.fogginess;
			TOD_CloudParameters clouds = todSky.Clouds;
			clouds.Size = lerpedSnapshot.cloudSize;
			clouds.Opacity = lerpedSnapshot.cloudOpacity;
			clouds.Coverage = cloudCoverageOverride ?? lerpedSnapshot.cloudCoverage;
			clouds.Sharpness = lerpedSnapshot.cloudSharpness;
			clouds.Coloring = lerpedSnapshot.cloudColoring;
			clouds.Attenuation = lerpedSnapshot.cloudAttenuation;
			clouds.Saturation = lerpedSnapshot.cloudSaturation;
			clouds.Scattering = lerpedSnapshot.cloudScattering;
			clouds.Brightness = lerpedSnapshot.cloudBrightness;
			if ((bool)sunGlare)
			{
				sunGlare.material.SetFloat(sp_Brightness, Mathf.Clamp01(1f - lerpedSnapshot.fogginess));
			}
			if ((bool)sunShafts)
			{
				sunShafts.sunShaftIntensity.Override(lerpedSnapshot.shaftsIntensity);
			}
		}

		private void UpdateRest()
		{
			TOD_Sky tOD_Sky = todSky;
			WeatherSnapshot lerpedSnapshot = LerpedSnapshot;
			tOD_Sky.SunLightColor = lerpedSnapshot.lightColorDay;
			tOD_Sky.MoonLightColor = lerpedSnapshot.lightColorNight;
			tOD_Sky.SunRayColor = lerpedSnapshot.sunRayColor;
			tOD_Sky.MoonRayColor = lerpedSnapshot.moonRayColor;
			tOD_Sky.SunSkyColor = lerpedSnapshot.skyColorDay;
			tOD_Sky.MoonSkyColor = lerpedSnapshot.skyColorNight;
			tOD_Sky.SunMeshColor = lerpedSnapshot.sunMeshColor;
			tOD_Sky.MoonMeshColor = lerpedSnapshot.moonMeshColor;
			tOD_Sky.SunCloudColor = lerpedSnapshot.cloudColorDay;
			tOD_Sky.MoonCloudColor = lerpedSnapshot.cloudColorNight;
			tOD_Sky.FogColor = lerpedSnapshot.fogColor;
			fogDistanceDensity = lerpedSnapshot.DisplayFogDistanceDensity;
			fogHeightDensity = lerpedSnapshot.DisplayFogHeightDensity;
			fogHeight = lerpedSnapshot.fogHeight;
			Color ambientColor = (tOD_Sky.AmbientColor = lerpedSnapshot.ambientColor);
			tOD_Sky.AmbientColor = ambientColor;
			tOD_Sky.Night.LightIntensity = (tOD_Sky.Day.LightIntensity = lerpedSnapshot.lightIntensity * (dimLightByClouds ? Mathf.InverseLerp(cloudCoverageDimmingEnd, cloudCoverageDimmingStart, lerpedSnapshot.cloudCoverage) : 1f));
			tOD_Sky.Night.ShadowStrength = (tOD_Sky.Day.ShadowStrength = lerpedSnapshot.shadowStrength);
			tOD_Sky.Night.AmbientMultiplier = (tOD_Sky.Day.AmbientMultiplier = lerpedSnapshot.ambientMult);
			tOD_Sky.Night.SkyIntensity = (tOD_Sky.Day.SkyIntensity = lerpedSnapshot.skyIntensity);
			tOD_Sky.Night.EquatorIntensity = (tOD_Sky.Day.EquatorIntensity = lerpedSnapshot.equatorIntensity);
			tOD_Sky.Night.GroundIntensity = (tOD_Sky.Day.GroundIntensity = lerpedSnapshot.groundIntensity);
			tOD_Sky.Night.ReflectionMultiplier = (tOD_Sky.Day.ReflectionMultiplier = lerpedSnapshot.reflectionMult);
			tOD_Sky.Sun.MeshBrightness = lerpedSnapshot.sunMeshBrightness;
			tOD_Sky.Sun.MeshContrast = lerpedSnapshot.sunMeshContrast;
			tOD_Sky.Moon.MeshBrightness = lerpedSnapshot.moonMeshBrightness;
			tOD_Sky.Moon.MeshContrast = lerpedSnapshot.moonMeshContrast;
			tOD_Sky.Moon.HaloSize = lerpedSnapshot.moonHaloSize;
			tOD_Sky.Moon.HaloBrightness = lerpedSnapshot.moonHaloBrightness;
			RenderSettings.fogDensity = lerpedSnapshot.DisplayFogDensity;
			if ((bool)autoExposure)
			{
				autoExposure.minLuminance.value = lerpedSnapshot.eyeAdaptationMin;
				autoExposure.maxLuminance.value = lerpedSnapshot.eyeAdaptationMax;
			}
		}

		public void ForceUpdateVisuals()
		{
			UpdateScattering();
			UpdateRest();
		}
	}
}
