using System;
using System.Collections.Generic;
using Aura2API;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State.Timers;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using SSMS;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval
{
	public class EnvironmentUpdate : MonoBehaviour
	{
		private const float EnvironmentUpdateIntervalSeconds = 0.5f;

		private const float EnvironmentLightsUpdateIntervalSeconds = 0.05f;

		[SerializeField]
		private Material skyboxMaterial;

		[Header("Fog color and intensity")]
		[SerializeField]
		private float ssmsBlurIntensity;

		[SerializeField]
		private bool volumeLight;

		[SerializeField]
		private float ssmsEnergyLoss;

		[SerializeField]
		private float ssmsMaxDensity;

		[SerializeField]
		private Color fogcolor;

		[SerializeField]
		private float ambIntencity;

		[SerializeField]
		private float fogstart;

		[SerializeField]
		private float fogend;

		[SerializeField]
		private float fogRangeCamHeightOffset = 50f;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color skyAmb;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color skyHor;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color skyGro;

		[Header("GI controle")]
		[SerializeField]
		private float ssgiIntencity;

		[SerializeField]
		private bool ssgiOn;

		[Header("Skybox")]
		[SerializeField]
		[Range(0f, 1f)]
		private float daynightCycle;

		[SerializeField]
		[Range(0f, 1f)]
		private float cloudsRainSkyAmount;

		[SerializeField]
		private ReflectionProbe probe;

		[Header("Post Procesing Stacks")]
		[SerializeField]
		private GameObject dayCC;

		[SerializeField]
		private GameObject twilightCC;

		[SerializeField]
		private GameObject nightCC;

		[SerializeField]
		private GameObject dawnCC;

		[SerializeField]
		private GameObject HeatCC;

		[SerializeField]
		private GameObject FrostCC;

		[Header("Rain Post Procesing Stacks")]
		[SerializeField]
		private GameObject rainDayCC;

		[SerializeField]
		private GameObject rainTwilightCC;

		[SerializeField]
		private GameObject rainNightCC;

		[SerializeField]
		private GameObject rainDawnCC;

		[Header("Post Procesing Stacks control")]
		[SerializeField]
		[Range(0f, 1f)]
		private float dayCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float twilightCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float nightCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float dawnCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float HeatCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float FrostCCW;

		[Header("Rain Post Procesing Stacks control ")]
		[SerializeField]
		[Range(0f, 1f)]
		private float rainDayCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float rainTwilightCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float rainNightCCW;

		[SerializeField]
		[Range(0f, 1f)]
		private float rainDawnCCW;

		[Header("Comput Shader control")]
		[SerializeField]
		[Range(0f, 1f)]
		private float rainAmount;

		[SerializeField]
		[Range(0f, 1f)]
		private float heavyRainAmount;

		[SerializeField]
		[Range(0f, 1f)]
		private float hailstormAmount;

		[SerializeField]
		private Color rainColor = Color.white;

		[SerializeField]
		private Color heavyRainColor = Color.cyan;

		[SerializeField]
		private Color hailstormColor = Color.blue;

		[SerializeField]
		[Range(0f, 1f)]
		private float snowAmount;

		[SerializeField]
		private Color snowColor = Color.white;

		[Range(0f, 1f)]
		[SerializeField]
		private float fogParticlesAlpha;

		[Range(0f, 1f)]
		[SerializeField]
		private float dustCloudsParticlesAlpha;

		[SerializeField]
		private Color fogColor = Color.white;

		[SerializeField]
		private Color dustSpecsColor = Color.white;

		[SerializeField]
		[Range(0f, 1f)]
		private float snowParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float snowDarkParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float fogParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float rainParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float heavyRainParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float hailstormParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float hailstormImpactParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float dustCloudsParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float dustSpecsParticlesCountNormalized = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float heavySnowParticlesCountNormalized = 1f;

		[Header("Global Shader Changes")]
		[SerializeField]
		[Range(0f, 1f)]
		private float rimLightGlobalShader;

		[SerializeField]
		[Range(0f, 1f)]
		private float rainGlobalShader;

		[SerializeField]
		[Range(0f, 1f)]
		private float snowGlobalShader;

		[SerializeField]
		[Range(0f, 1f)]
		private float cloudsGlobalShader;

		[SerializeField]
		[Range(0f, 1f)]
		private float WindBendGlobalShader;

		[SerializeField]
		[Range(0f, 1f)]
		private float WindStrengthGlobalShader;

		[Header("Skybox")]
		public Material skyboxMaterialInstance;

		[Header("Sun and moon controls")]
		[SerializeField]
		private GameObject sunSource;

		[SerializeField]
		private GameObject sunAngleObject;

		[SerializeField]
		private float sunI;

		[SerializeField]
		private Color sunC;

		[SerializeField]
		private bool sun;

		[SerializeField]
		private float auraSunLightIntencity;

		private AuraCamera AuraCameraEnabled;

		private AuraCamera AuraCameraEnabledPhoto;

		private AuraLight auraLight;

		private PostProcessVolume dawnCCPostProcesingVolume;

		private PostProcessVolume dayCCPostProcesingVolume;

		private PostProcessVolume frostCCPostProcesingVolume;

		private PostProcessVolume heatCCPostProcesingVolume;

		[NonSerialized]
		private GameObject mainCamera;

		private PostProcessVolume nightCCPostProcesingVolume;

		[NonSerialized]
		private GameObject photoCamera;

		private List<PostProcessVolume> postProcessingVolumes = new List<PostProcessVolume>();

		private PostProcessVolume rainDawnCCPostProcesingVolume;

		private PostProcessVolume rainDayCCPostProcesingVolume;

		private PostProcessVolume rainNightCCPostProcesingVolume;

		private PostProcessVolume rainTwilightCCPostProcesingVolume;

		private global::SSMS.SSMS ssmsBlur;

		private global::SSMS.SSMS ssmsBlurPhoto;

		private SSMSGlobalFog ssmsFog;

		private SSMSGlobalFog ssmsFogPhoto;

		private Light sunLight;

		[NonSerialized]
		private bool tutorialAngleSet;

		private PostProcessVolume twilightCCPostProcesingVolume;

		[NonSerialized]
		private Timer updateEnvironmentLightParamsTimer;

		[NonSerialized]
		private Timer updateEnvironmentTimer;

		private void Start()
		{
			skyboxMaterialInstance = new Material(skyboxMaterial);
			mainCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera.gameObject;
			photoCamera = MonoSingleton<CameraManager>.Instance.PhotoModeCamera.gameObject;
			sunLight = sunSource.GetComponent<Light>();
			auraLight = sunSource.GetComponent<AuraLight>();
			dayCCPostProcesingVolume = dayCC.GetComponent<PostProcessVolume>();
			twilightCCPostProcesingVolume = twilightCC.GetComponent<PostProcessVolume>();
			nightCCPostProcesingVolume = nightCC.GetComponent<PostProcessVolume>();
			dawnCCPostProcesingVolume = dawnCC.GetComponent<PostProcessVolume>();
			rainDayCCPostProcesingVolume = rainDayCC.GetComponent<PostProcessVolume>();
			rainTwilightCCPostProcesingVolume = rainTwilightCC.GetComponent<PostProcessVolume>();
			rainNightCCPostProcesingVolume = rainNightCC.GetComponent<PostProcessVolume>();
			rainDawnCCPostProcesingVolume = rainDawnCC.GetComponent<PostProcessVolume>();
			twilightCCPostProcesingVolume = twilightCC.GetComponent<PostProcessVolume>();
			heatCCPostProcesingVolume = HeatCC.GetComponent<PostProcessVolume>();
			frostCCPostProcesingVolume = FrostCC.GetComponent<PostProcessVolume>();
			ssmsBlur = mainCamera.GetComponent<global::SSMS.SSMS>();
			AuraCameraEnabled = mainCamera.GetComponent<AuraCamera>();
			ssmsFog = mainCamera.GetComponent<SSMSGlobalFog>();
			ssmsBlurPhoto = photoCamera.GetComponent<global::SSMS.SSMS>();
			AuraCameraEnabledPhoto = photoCamera.GetComponent<AuraCamera>();
			ssmsFogPhoto = photoCamera.GetComponent<SSMSGlobalFog>();
			postProcessingVolumes = new List<PostProcessVolume>
			{
				dayCCPostProcesingVolume, twilightCCPostProcesingVolume, nightCCPostProcesingVolume, dawnCCPostProcesingVolume, rainDayCCPostProcesingVolume, rainTwilightCCPostProcesingVolume, rainNightCCPostProcesingVolume, rainDawnCCPostProcesingVolume, twilightCCPostProcesingVolume, heatCCPostProcesingVolume,
				frostCCPostProcesingVolume
			};
			updateEnvironmentTimer = new Timer(0.5f, restartOnEnd: true);
			updateEnvironmentTimer.AddCallback(DoUpdateEnvironment);
			updateEnvironmentLightParamsTimer = new Timer(0.05f, restartOnEnd: true);
			updateEnvironmentLightParamsTimer.AddCallback(DoUpdateEnvironmentLightParams);
			MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent += OnCameraUpdate;
			MonoSingleton<OptionsController>.Instance.PostProcessingOptionEvent += OnOptionsUpdate;
			OnOptionsUpdate();
		}

		private void Update()
		{
			if (TutorialManager.IsTutorialActive)
			{
				UpdateSunAngleTutorial();
			}
			else
			{
				UpdateSunAngle();
			}
		}

		private void OnDisable()
		{
			RenderSettings.skybox = null;
		}

		private void OnDestroy()
		{
			if (MonoSingleton<RtsCamera>.IsInstantiated())
			{
				MonoSingleton<RtsCamera>.Instance.CameraUpdateEvent -= OnCameraUpdate;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.PostProcessingOptionEvent -= OnOptionsUpdate;
			}
			updateEnvironmentTimer.Dispose();
			updateEnvironmentTimer = null;
			updateEnvironmentLightParamsTimer.Dispose();
			updateEnvironmentLightParamsTimer = null;
			UnityEngine.Object.DestroyImmediate(skyboxMaterialInstance);
		}

		public void GetValuesFromAnimator()
		{
			DoUpdateEnvironment();
			DoUpdateEnvironmentLightParams();
		}

		private void UpdateSunAngleTutorial()
		{
			if (!tutorialAngleSet && MonoSingleton<WeatherManager>.IsInstantiated())
			{
				sunAngleObject.transform.localEulerAngles = MonoSingleton<WeatherManager>.Instance.SunAngle;
				if (MonoSingleton<WeatherManager>.Instance.SunAngle != Vector3.zero)
				{
					tutorialAngleSet = true;
				}
			}
		}

		private void UpdateSunAngle()
		{
			if (MonoSingleton<WeatherManager>.IsInstantiated())
			{
				sunAngleObject.transform.localEulerAngles = MonoSingleton<WeatherManager>.Instance.SunAngle;
			}
		}

		private void OnOptionsUpdate()
		{
			GlobalSettings globalSettings = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings;
			foreach (PostProcessVolume postProcessingVolume in postProcessingVolumes)
			{
				postProcessingVolume.profile.TryGetSettings<Bloom>(out var outSetting);
				postProcessingVolume.profile.TryGetSettings<AmbientOcclusion>(out var outSetting2);
				postProcessingVolume.profile.TryGetSettings<MotionBlur>(out var outSetting3);
				if (outSetting != null)
				{
					outSetting.active = globalSettings.Bloom;
				}
				if (outSetting2 != null)
				{
					outSetting2.active = globalSettings.AmbientOcclusion;
				}
				if (outSetting3 != null)
				{
					outSetting3.active = globalSettings.MotionBlur;
				}
			}
		}

		private void DoUpdateEnvironment()
		{
			if (MonoSingleton<GlobalShaderVariables>.IsInstantiated() && MonoSingleton<WeatherManager>.IsInstantiated() && GlobalSaveController.CurrentVillageData?.DateAndTime != null)
			{
				WeatherManager weatherManager = MonoSingleton<WeatherManager>.Instance;
				MonoSingleton<GlobalShaderVariables>.Instance.UpdateEnvironmentVariables(rainGlobalShader, snowGlobalShader, WindStrengthGlobalShader);
				Shader.SetGlobalFloat("_RimLightStrength", rimLightGlobalShader);
				Shader.SetGlobalFloat("_windGlobalBend", WindBendGlobalShader);
				Shader.SetGlobalFloat("_temperatureGlobal", GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius);
				RenderSettings.ambientIntensity = ambIntencity;
				ssmsFog.fogColor = fogcolor;
				ssmsFogPhoto.fogColor = fogcolor;
				ssmsBlur.intensity = ssmsBlurIntensity;
				ssmsBlurPhoto.intensity = ssmsBlurIntensity;
				ssmsFog.energyLoss = ssmsEnergyLoss;
				ssmsFogPhoto.energyLoss = ssmsEnergyLoss;
				if (base.gameObject != null && base.gameObject.activeInHierarchy && RenderSettings.skybox == null)
				{
					RenderSettings.skybox = skyboxMaterialInstance;
				}
				if (RenderSettings.skybox != null)
				{
					RenderSettings.skybox.SetFloat("_24hskyboxCycle", daynightCycle);
					RenderSettings.skybox.SetFloat("_rainCloudSky", cloudsRainSkyAmount);
				}
				dayCCPostProcesingVolume.weight = dayCCW;
				twilightCCPostProcesingVolume.weight = twilightCCW;
				nightCCPostProcesingVolume.weight = nightCCW;
				dawnCCPostProcesingVolume.weight = dawnCCW;
				rainDayCCPostProcesingVolume.weight = rainDayCCW;
				rainTwilightCCPostProcesingVolume.weight = rainTwilightCCW;
				rainNightCCPostProcesingVolume.weight = rainNightCCW;
				rainDawnCCPostProcesingVolume.weight = rainDawnCCW;
				heatCCPostProcesingVolume.weight = HeatCCW;
				frostCCPostProcesingVolume.weight = FrostCCW;
				sunLight.color = sunC;
				sunLight.enabled = sun;
				sunLight.intensity = sunI;
				RenderSettings.ambientSkyColor = skyAmb;
				RenderSettings.ambientEquatorColor = skyHor;
				RenderSettings.ambientGroundColor = skyGro;
				HandleParticleEffect(weatherManager.RainEffect, rainAmount > 0f && rainParticlesCountNormalized > 0f, delegate
				{
					weatherManager.RainEffect.GeometryRenderer.SetAlphaMultiplier(rainAmount);
					weatherManager.RainEffect.GeometryRenderer.SetColor(rainColor);
					weatherManager.RainEffect.ParticlesCountNormalized = rainParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.HeavyRainEffect, heavyRainAmount > 0f && heavyRainParticlesCountNormalized > 0f, delegate
				{
					weatherManager.HeavyRainEffect.GeometryRenderer.SetAlphaMultiplier(heavyRainAmount);
					weatherManager.HeavyRainEffect.GeometryRenderer.SetColor(heavyRainColor);
					weatherManager.HeavyRainEffect.ParticlesCountNormalized = heavyRainParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.HailstormEffect, hailstormAmount > 0f && hailstormParticlesCountNormalized > 0f, delegate
				{
					weatherManager.HailstormEffect.GeometryRenderer.SetAlphaMultiplier(hailstormAmount);
					weatherManager.HailstormEffect.GeometryRenderer.SetColor(hailstormColor);
					weatherManager.HailstormEffect.ParticlesCountNormalized = hailstormParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.DustCloudsEffect, dustCloudsParticlesAlpha > 0f && dustCloudsParticlesCountNormalized > 0f, delegate
				{
					weatherManager.DustCloudsEffect.GeometryRenderer.SetAlphaMultiplier(dustCloudsParticlesAlpha);
					weatherManager.DustCloudsEffect.ParticlesCountNormalized = dustCloudsParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.DustSpecsEffect, dustSpecsParticlesCountNormalized > 0f, delegate
				{
					weatherManager.DustSpecsEffect.GeometryRenderer.SetColor(dustSpecsColor);
					weatherManager.DustSpecsEffect.ParticlesCountNormalized = dustSpecsParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.FogEffect, fogParticlesAlpha > 0f && fogParticlesCountNormalized > 0f, delegate
				{
					weatherManager.FogEffect.GeometryRenderer.SetAlphaMultiplier(fogParticlesAlpha);
					weatherManager.FogEffect.GeometryRenderer.SetColor(fogColor);
					weatherManager.FogEffect.ParticlesCountNormalized = fogParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.HailstormImpactEffect, hailstormImpactParticlesCountNormalized > 0f, delegate
				{
					weatherManager.HailstormImpactEffect.ParticlesCountNormalized = hailstormImpactParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.SnowDarkEffect, snowDarkParticlesCountNormalized > 0f, delegate
				{
					weatherManager.SnowDarkEffect.ParticlesCountNormalized = snowDarkParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.SnowEffect, snowAmount > 0f && snowParticlesCountNormalized > 0f, delegate
				{
					weatherManager.SnowEffect.GeometryRenderer.SetAlphaMultiplier(snowAmount);
					weatherManager.SnowEffect.GeometryRenderer.SetColor(snowColor);
					weatherManager.SnowEffect.GeometryRenderer.SetSizeMultiplier(snowAmount);
					weatherManager.SnowEffect.ParticlesCountNormalized = snowParticlesCountNormalized;
				});
				HandleParticleEffect(weatherManager.SnowHeavyEffect, heavySnowParticlesCountNormalized > 0f, delegate
				{
					weatherManager.SnowHeavyEffect.ParticlesCountNormalized = heavySnowParticlesCountNormalized;
				});
			}
		}

		private void HandleParticleEffect(MonoBehaviour monoBehaviour, bool isEnabled, Action onEnabled)
		{
			if (!isEnabled)
			{
				if (monoBehaviour.gameObject.activeSelf)
				{
					monoBehaviour.gameObject.SetActive(value: false);
				}
				return;
			}
			if (!monoBehaviour.gameObject.activeSelf)
			{
				monoBehaviour.gameObject.SetActive(value: true);
			}
			onEnabled();
		}

		private void OnCameraUpdate()
		{
			ssmsFog.fogStart = fogstart + MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized * fogRangeCamHeightOffset;
			ssmsFog.fogEnd = fogend + MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized * fogRangeCamHeightOffset;
			ssmsFogPhoto.fogStart = fogstart + MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized * fogRangeCamHeightOffset;
			ssmsFogPhoto.fogEnd = fogend + MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized * fogRangeCamHeightOffset;
		}

		private void DoUpdateEnvironmentLightParams()
		{
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				probe.RenderProbe();
				Shader.SetGlobalFloat("_Clouds_amount", cloudsGlobalShader);
				auraLight.strength = auraSunLightIntencity;
				AuraCameraEnabled.enabled = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SunBeams && volumeLight;
				AuraCameraEnabledPhoto.enabled = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SunBeams && volumeLight;
			}
		}
	}
}
