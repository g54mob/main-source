using System;
using System.Collections;
using UnityEngine;

namespace Enviro
{
	[Serializable]
	[ExecuteInEditMode]
	public class EnviroWeatherModule : EnviroModule
	{
		public EnviroWeather Settings;

		public EnviroWeatherModule preset;

		public EnviroWeatherType targetWeatherType;

		public float weatherBlendProgress;

		public bool globalAutoWeatherChange = true;

		public BoxCollider triggerCollider;

		public Rigidbody triggerRB;

		public bool showWeatherPresetsControls;

		public bool showTransitionControls;

		public bool showZoneControls;

		private bool instantTransition;

		public override void Enable()
		{
			if (!(EnviroManager.instance == null))
			{
				if (targetWeatherType == null && Settings.weatherTypes.Count > 0)
				{
					targetWeatherType = Settings.weatherTypes[0];
				}
				if (EnviroManager.instance.defaultZone != null)
				{
					EnviroManager.instance.currentZone = EnviroManager.instance.defaultZone;
				}
				weatherBlendProgress = 1f;
				Setup();
			}
		}

		public override void Disable()
		{
			if (!(EnviroManager.instance == null))
			{
				Cleanup();
			}
		}

		private void Setup()
		{
			if (EnviroManager.instance.gameObject.GetComponent<BoxCollider>() == null)
			{
				triggerCollider = EnviroManager.instance.gameObject.AddComponent<BoxCollider>();
			}
			else
			{
				triggerCollider = EnviroManager.instance.gameObject.GetComponent<BoxCollider>();
			}
			triggerCollider.isTrigger = true;
			triggerCollider.size = new Vector3(0.1f, 0.1f, 0.1f);
			if (EnviroManager.instance.gameObject.GetComponent<Rigidbody>() == null)
			{
				triggerRB = EnviroManager.instance.gameObject.AddComponent<Rigidbody>();
			}
			else
			{
				triggerRB = EnviroManager.instance.gameObject.GetComponent<Rigidbody>();
			}
			triggerRB.isKinematic = true;
		}

		private void Cleanup()
		{
			if (triggerCollider != null)
			{
				UnityEngine.Object.DestroyImmediate(triggerCollider);
			}
			if (triggerRB != null)
			{
				UnityEngine.Object.DestroyImmediate(triggerRB);
			}
		}

		public void CreateNewWeatherType()
		{
			EnviroWeatherType item = EnviroWeatherTypeCreation.CreateMyAsset();
			Settings.weatherTypes.Add(item);
		}

		public void RemoveWeatherType(EnviroWeatherType type)
		{
			Settings.weatherTypes.Remove(type);
		}

		public void CleanupList()
		{
			for (int i = 0; i < Settings.weatherTypes.Count; i++)
			{
				if (Settings.weatherTypes[i] == null)
				{
					Settings.weatherTypes.RemoveAt(i);
				}
			}
		}

		private IEnumerator InstantTransition()
		{
			yield return null;
			instantTransition = false;
		}

		public override void UpdateModule()
		{
			if (!active || EnviroManager.instance == null)
			{
				return;
			}
			if (!Application.isPlaying || instantTransition)
			{
				if (targetWeatherType != null)
				{
					BlendVolumetricCloudsOverride(1f);
					BlendFlatCloudsOverride(1f);
					BlendLightingOverride(1f);
					BlendSkyOverride(1f);
					BlendEffectsOverride(1f);
					BlendAuroraOverride(1f);
					BlendFogOverride(1f);
					BlendAudioOverride(1f);
					BlendEnvironmentOverride(1f);
					BlendLightningOverride(1f);
				}
				if (instantTransition)
				{
					instantTransition = false;
				}
			}
			else if (targetWeatherType != null)
			{
				BlendVolumetricCloudsOverride(Settings.cloudsTransitionSpeed * Time.unscaledDeltaTime);
				BlendFlatCloudsOverride(Settings.cloudsTransitionSpeed * Time.unscaledDeltaTime);
				BlendLightingOverride(Settings.lightingTransitionSpeed * Time.unscaledDeltaTime);
				BlendSkyOverride(Settings.skyTransitionSpeed * Time.unscaledDeltaTime);
				BlendEffectsOverride(Settings.effectsTransitionSpeed * Time.unscaledDeltaTime);
				BlendAuroraOverride(Settings.auroraTransitionSpeed * Time.unscaledDeltaTime);
				BlendFogOverride(Settings.fogTransitionSpeed * Time.unscaledDeltaTime);
				BlendAudioOverride(Settings.audioTransitionSpeed * Time.unscaledDeltaTime);
				BlendEnvironmentOverride(Settings.environmentTransitionSpeed * Time.unscaledDeltaTime);
				BlendLightningOverride(1f);
				UpdateWeatherBlendProgress(Settings.cloudsTransitionSpeed * Time.unscaledDeltaTime);
			}
		}

		private void BlendLightingOverride(float blendTime)
		{
			EnviroLightingModule lighting = EnviroManager.instance.Lighting;
			if (lighting != null)
			{
				lighting.Settings.directLightIntensityModifier = Mathf.Lerp(lighting.Settings.directLightIntensityModifier, targetWeatherType.lightingOverride.directLightIntensityModifier, blendTime);
				lighting.Settings.ambientIntensityModifier = Mathf.Lerp(lighting.Settings.ambientIntensityModifier, targetWeatherType.lightingOverride.ambientIntensityModifier, blendTime);
				lighting.Settings.shadowIntensity = Mathf.Lerp(lighting.Settings.shadowIntensity, targetWeatherType.lightingOverride.shadowIntensity, blendTime);
			}
		}

		private void BlendSkyOverride(float blendTime)
		{
			EnviroSkyModule sky = EnviroManager.instance.Sky;
			if (sky != null)
			{
				sky.Settings.skyColorTint = Color.Lerp(sky.Settings.skyColorTint, targetWeatherType.skyOverride.skyColorTint, blendTime);
			}
		}

		private void BlendFogOverride(float blendTime)
		{
			EnviroFogModule fog = EnviroManager.instance.Fog;
			if (fog != null)
			{
				fog.Settings.fogDensity = Mathf.Lerp(fog.Settings.fogDensity, targetWeatherType.fogOverride.fogDensity, blendTime);
				fog.Settings.fogHeightFalloff = Mathf.Lerp(fog.Settings.fogHeightFalloff, targetWeatherType.fogOverride.fogHeightFalloff, blendTime);
				fog.Settings.fogHeight = Mathf.Lerp(fog.Settings.fogHeight, targetWeatherType.fogOverride.fogHeight, blendTime);
				fog.Settings.fogDensity2 = Mathf.Lerp(fog.Settings.fogDensity2, targetWeatherType.fogOverride.fogDensity2, blendTime);
				fog.Settings.fogHeightFalloff2 = Mathf.Lerp(fog.Settings.fogHeightFalloff2, targetWeatherType.fogOverride.fogHeightFalloff2, blendTime);
				fog.Settings.fogHeight2 = Mathf.Lerp(fog.Settings.fogHeight2, targetWeatherType.fogOverride.fogHeight2, blendTime);
				fog.Settings.fogColorBlend = Mathf.Lerp(fog.Settings.fogColorBlend, targetWeatherType.fogOverride.fogColorBlend, blendTime);
				fog.Settings.fogColorMod = Color.Lerp(fog.Settings.fogColorMod, targetWeatherType.fogOverride.fogColorMod, blendTime);
				fog.Settings.scattering = Mathf.Lerp(fog.Settings.scattering, targetWeatherType.fogOverride.scattering, blendTime);
				fog.Settings.extinction = Mathf.Lerp(fog.Settings.extinction, targetWeatherType.fogOverride.extinction, blendTime);
				fog.Settings.anistropy = Mathf.Lerp(fog.Settings.anistropy, targetWeatherType.fogOverride.anistropy, blendTime);
				fog.Settings.unityFogDensity = Mathf.Lerp(fog.Settings.unityFogDensity, targetWeatherType.fogOverride.unityFogDensity, blendTime);
				fog.Settings.unityFogStartDistance = Mathf.Lerp(fog.Settings.unityFogStartDistance, targetWeatherType.fogOverride.unityFogStartDistance, blendTime);
				fog.Settings.unityFogEndDistance = Mathf.Lerp(fog.Settings.unityFogEndDistance, targetWeatherType.fogOverride.unityFogEndDistance, blendTime);
			}
		}

		private void BlendEffectsOverride(float blendTime)
		{
			EnviroEffectsModule effects = EnviroManager.instance.Effects;
			if (!(effects != null))
			{
				return;
			}
			for (int i = 0; i < effects.Settings.effectTypes.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < targetWeatherType.effectsOverride.effectsOverride.Count; j++)
				{
					if (effects.Settings.effectTypes[i].name == targetWeatherType.effectsOverride.effectsOverride[j].name)
					{
						effects.Settings.effectTypes[i].emissionRate = Mathf.Lerp(effects.Settings.effectTypes[i].emissionRate, targetWeatherType.effectsOverride.effectsOverride[j].emission, blendTime);
						flag = true;
					}
				}
				if (!flag)
				{
					effects.Settings.effectTypes[i].emissionRate = Mathf.Lerp(effects.Settings.effectTypes[i].emissionRate, 0f, blendTime);
				}
			}
		}

		private void BlendVolumetricCloudsOverride(float blendTime)
		{
			EnviroVolumetricCloudsModule volumetricClouds = EnviroManager.instance.VolumetricClouds;
			if (volumetricClouds != null)
			{
				volumetricClouds.settingsGlobal.ambientLighIntensity = Mathf.Lerp(volumetricClouds.settingsGlobal.ambientLighIntensity, targetWeatherType.cloudsOverride.ambientLightIntensity, blendTime);
				volumetricClouds.settingsLayer1.coverage = Mathf.Lerp(volumetricClouds.settingsLayer1.coverage, targetWeatherType.cloudsOverride.coverageLayer1, blendTime);
				volumetricClouds.settingsLayer1.dilateCoverage = Mathf.Lerp(volumetricClouds.settingsLayer1.dilateCoverage, targetWeatherType.cloudsOverride.dilateCoverageLayer1, blendTime);
				volumetricClouds.settingsLayer1.dilateType = Mathf.Lerp(volumetricClouds.settingsLayer1.dilateType, targetWeatherType.cloudsOverride.dilateTypeLayer1, blendTime);
				volumetricClouds.settingsLayer1.cloudsTypeModifier = Mathf.Lerp(volumetricClouds.settingsLayer1.cloudsTypeModifier, targetWeatherType.cloudsOverride.typeModifierLayer1, blendTime);
				volumetricClouds.settingsLayer1.anvilBias = Mathf.Lerp(volumetricClouds.settingsLayer1.anvilBias, targetWeatherType.cloudsOverride.anvilBiasLayer1, blendTime);
				volumetricClouds.settingsLayer1.scatteringIntensity = Mathf.Lerp(volumetricClouds.settingsLayer1.scatteringIntensity, targetWeatherType.cloudsOverride.scatteringIntensityLayer1, blendTime);
				volumetricClouds.settingsLayer1.multiScatteringA = Mathf.Lerp(volumetricClouds.settingsLayer1.multiScatteringA, targetWeatherType.cloudsOverride.multiScatteringALayer1, blendTime);
				volumetricClouds.settingsLayer1.multiScatteringB = Mathf.Lerp(volumetricClouds.settingsLayer1.multiScatteringB, targetWeatherType.cloudsOverride.multiScatteringBLayer1, blendTime);
				volumetricClouds.settingsLayer1.multiScatteringC = Mathf.Lerp(volumetricClouds.settingsLayer1.multiScatteringC, targetWeatherType.cloudsOverride.multiScatteringCLayer1, blendTime);
				volumetricClouds.settingsLayer1.powderIntensity = Mathf.Lerp(volumetricClouds.settingsLayer1.powderIntensity, targetWeatherType.cloudsOverride.powderIntensityLayer1, blendTime);
				volumetricClouds.settingsLayer1.silverLiningSpread = Mathf.Lerp(volumetricClouds.settingsLayer1.silverLiningSpread, targetWeatherType.cloudsOverride.silverLiningSpreadLayer1, blendTime);
				volumetricClouds.settingsLayer1.lightAbsorbtion = Mathf.Lerp(volumetricClouds.settingsLayer1.lightAbsorbtion, targetWeatherType.cloudsOverride.ligthAbsorbtionLayer1, blendTime);
				volumetricClouds.settingsLayer1.density = Mathf.Lerp(volumetricClouds.settingsLayer1.density, targetWeatherType.cloudsOverride.densityLayer1, blendTime);
				volumetricClouds.settingsLayer1.densitySmoothness = Mathf.Lerp(volumetricClouds.settingsLayer1.densitySmoothness, targetWeatherType.cloudsOverride.densitySmoothnessLayer1, blendTime);
				volumetricClouds.settingsLayer1.baseErosionIntensity = Mathf.Lerp(volumetricClouds.settingsLayer1.baseErosionIntensity, targetWeatherType.cloudsOverride.baseErosionIntensityLayer1, blendTime);
				volumetricClouds.settingsLayer1.detailErosionIntensity = Mathf.Lerp(volumetricClouds.settingsLayer1.detailErosionIntensity, targetWeatherType.cloudsOverride.detailErosionIntensityLayer1, blendTime);
				volumetricClouds.settingsLayer1.curlIntensity = Mathf.Lerp(volumetricClouds.settingsLayer1.curlIntensity, targetWeatherType.cloudsOverride.curlIntensityLayer1, blendTime);
				if (volumetricClouds.settingsGlobal.dualLayer)
				{
					volumetricClouds.settingsLayer2.coverage = Mathf.Lerp(volumetricClouds.settingsLayer2.coverage, targetWeatherType.cloudsOverride.coverageLayer2, blendTime);
					volumetricClouds.settingsLayer2.dilateCoverage = Mathf.Lerp(volumetricClouds.settingsLayer2.dilateCoverage, targetWeatherType.cloudsOverride.dilateCoverageLayer2, blendTime);
					volumetricClouds.settingsLayer2.dilateType = Mathf.Lerp(volumetricClouds.settingsLayer2.dilateType, targetWeatherType.cloudsOverride.dilateTypeLayer2, blendTime);
					volumetricClouds.settingsLayer2.cloudsTypeModifier = Mathf.Lerp(volumetricClouds.settingsLayer2.cloudsTypeModifier, targetWeatherType.cloudsOverride.typeModifierLayer2, blendTime);
					volumetricClouds.settingsLayer2.anvilBias = Mathf.Lerp(volumetricClouds.settingsLayer2.anvilBias, targetWeatherType.cloudsOverride.anvilBiasLayer2, blendTime);
					volumetricClouds.settingsLayer2.scatteringIntensity = Mathf.Lerp(volumetricClouds.settingsLayer2.scatteringIntensity, targetWeatherType.cloudsOverride.scatteringIntensityLayer2, blendTime);
					volumetricClouds.settingsLayer2.multiScatteringA = Mathf.Lerp(volumetricClouds.settingsLayer2.multiScatteringA, targetWeatherType.cloudsOverride.multiScatteringALayer2, blendTime);
					volumetricClouds.settingsLayer2.multiScatteringB = Mathf.Lerp(volumetricClouds.settingsLayer2.multiScatteringB, targetWeatherType.cloudsOverride.multiScatteringBLayer2, blendTime);
					volumetricClouds.settingsLayer2.multiScatteringC = Mathf.Lerp(volumetricClouds.settingsLayer2.multiScatteringC, targetWeatherType.cloudsOverride.multiScatteringCLayer2, blendTime);
					volumetricClouds.settingsLayer2.powderIntensity = Mathf.Lerp(volumetricClouds.settingsLayer2.powderIntensity, targetWeatherType.cloudsOverride.powderIntensityLayer2, blendTime);
					volumetricClouds.settingsLayer2.silverLiningSpread = Mathf.Lerp(volumetricClouds.settingsLayer2.silverLiningSpread, targetWeatherType.cloudsOverride.silverLiningSpreadLayer2, blendTime);
					volumetricClouds.settingsLayer2.lightAbsorbtion = Mathf.Lerp(volumetricClouds.settingsLayer2.lightAbsorbtion, targetWeatherType.cloudsOverride.ligthAbsorbtionLayer2, blendTime);
					volumetricClouds.settingsLayer2.density = Mathf.Lerp(volumetricClouds.settingsLayer2.density, targetWeatherType.cloudsOverride.densityLayer2, blendTime);
					volumetricClouds.settingsLayer2.densitySmoothness = Mathf.Lerp(volumetricClouds.settingsLayer2.densitySmoothness, targetWeatherType.cloudsOverride.densitySmoothnessLayer2, blendTime);
					volumetricClouds.settingsLayer2.baseErosionIntensity = Mathf.Lerp(volumetricClouds.settingsLayer2.baseErosionIntensity, targetWeatherType.cloudsOverride.baseErosionIntensityLayer2, blendTime);
					volumetricClouds.settingsLayer2.detailErosionIntensity = Mathf.Lerp(volumetricClouds.settingsLayer2.detailErosionIntensity, targetWeatherType.cloudsOverride.detailErosionIntensityLayer2, blendTime);
					volumetricClouds.settingsLayer2.curlIntensity = Mathf.Lerp(volumetricClouds.settingsLayer2.curlIntensity, targetWeatherType.cloudsOverride.curlIntensityLayer2, blendTime);
				}
			}
		}

		private void BlendFlatCloudsOverride(float blendTime)
		{
			EnviroFlatCloudsModule flatClouds = EnviroManager.instance.FlatClouds;
			if (flatClouds != null)
			{
				flatClouds.settings.cirrusCloudsAlpha = Mathf.Lerp(flatClouds.settings.cirrusCloudsAlpha, targetWeatherType.flatCloudsOverride.cirrusCloudsAlpha, blendTime);
				flatClouds.settings.cirrusCloudsCoverage = Mathf.Lerp(flatClouds.settings.cirrusCloudsCoverage, targetWeatherType.flatCloudsOverride.cirrusCloudsCoverage, blendTime);
				flatClouds.settings.cirrusCloudsColorPower = Mathf.Lerp(flatClouds.settings.cirrusCloudsColorPower, targetWeatherType.flatCloudsOverride.cirrusCloudsColorPower, blendTime);
				flatClouds.settings.flatCloudsCoverage = Mathf.Lerp(flatClouds.settings.flatCloudsCoverage, targetWeatherType.flatCloudsOverride.flatCloudsCoverage, blendTime);
				flatClouds.settings.flatCloudsDensity = Mathf.Lerp(flatClouds.settings.flatCloudsDensity, targetWeatherType.flatCloudsOverride.flatCloudsDensity, blendTime);
				flatClouds.settings.flatCloudsLightIntensity = Mathf.Lerp(flatClouds.settings.flatCloudsLightIntensity, targetWeatherType.flatCloudsOverride.flatCloudsLightIntensity, blendTime);
				flatClouds.settings.flatCloudsAmbientIntensity = Mathf.Lerp(flatClouds.settings.flatCloudsAmbientIntensity, targetWeatherType.flatCloudsOverride.flatCloudsAmbientIntensity, blendTime);
				flatClouds.settings.flatCloudsAbsorbtion = Mathf.Lerp(flatClouds.settings.flatCloudsAbsorbtion, targetWeatherType.flatCloudsOverride.flatCloudsAbsorbtion, blendTime);
			}
		}

		private void BlendAuroraOverride(float blendTime)
		{
			EnviroAuroraModule aurora = EnviroManager.instance.Aurora;
			if (aurora != null)
			{
				aurora.Settings.auroraIntensityModifier = Mathf.Lerp(aurora.Settings.auroraIntensityModifier, targetWeatherType.auroraOverride.auroraIntensity, blendTime);
			}
		}

		private void BlendEnvironmentOverride(float blendTime)
		{
			EnviroEnvironmentModule environment = EnviroManager.instance.Environment;
			if (environment != null)
			{
				environment.Settings.temperatureWeatherMod = Mathf.Lerp(environment.Settings.temperatureWeatherMod, targetWeatherType.environmentOverride.temperatureWeatherMod, blendTime);
				environment.Settings.wetnessTarget = Mathf.Lerp(environment.Settings.wetnessTarget, targetWeatherType.environmentOverride.wetnessTarget, blendTime);
				environment.Settings.snowTarget = Mathf.Lerp(environment.Settings.snowTarget, targetWeatherType.environmentOverride.snowTarget, blendTime);
				environment.Settings.windDirectionX = Mathf.Lerp(environment.Settings.windDirectionX, targetWeatherType.environmentOverride.windDirectionX, blendTime);
				environment.Settings.windDirectionY = Mathf.Lerp(environment.Settings.windDirectionY, targetWeatherType.environmentOverride.windDirectionY, blendTime);
				environment.Settings.windSpeed = Mathf.Lerp(environment.Settings.windSpeed, targetWeatherType.environmentOverride.windSpeed, blendTime);
				environment.Settings.windTurbulence = Mathf.Lerp(environment.Settings.windTurbulence, targetWeatherType.environmentOverride.windTurbulence, blendTime);
			}
		}

		private void BlendAudioOverride(float blendTime)
		{
			EnviroAudioModule audio = EnviroManager.instance.Audio;
			if (!(audio != null))
			{
				return;
			}
			for (int i = 0; i < audio.Settings.ambientClips.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < targetWeatherType.audioOverride.ambientOverride.Count; j++)
				{
					if (targetWeatherType.audioOverride.ambientOverride[j].name == audio.Settings.ambientClips[i].name)
					{
						audio.Settings.ambientClips[i].volume = Mathf.Lerp(audio.Settings.ambientClips[i].volume, targetWeatherType.audioOverride.ambientOverride[j].volume, blendTime);
						flag = true;
					}
				}
				if (!flag)
				{
					audio.Settings.ambientClips[i].volume = Mathf.Lerp(audio.Settings.ambientClips[i].volume, 0f, blendTime);
				}
			}
			for (int k = 0; k < audio.Settings.weatherClips.Count; k++)
			{
				bool flag2 = false;
				for (int l = 0; l < targetWeatherType.audioOverride.weatherOverride.Count; l++)
				{
					if (targetWeatherType.audioOverride.weatherOverride[l].name == audio.Settings.weatherClips[k].name)
					{
						audio.Settings.weatherClips[k].volume = Mathf.Lerp(audio.Settings.weatherClips[k].volume, targetWeatherType.audioOverride.weatherOverride[l].volume, blendTime);
						flag2 = true;
					}
				}
				if (!flag2)
				{
					audio.Settings.weatherClips[k].volume = Mathf.Lerp(audio.Settings.weatherClips[k].volume, 0f, blendTime);
				}
			}
		}

		private void BlendLightningOverride(float blendTime)
		{
			EnviroLightningModule lightning = EnviroManager.instance.Lightning;
			if (lightning != null)
			{
				lightning.Settings.lightningStorm = targetWeatherType.lightningOverride.lightningStorm;
				lightning.Settings.randomLightingDelay = Mathf.Lerp(lightning.Settings.randomLightingDelay, targetWeatherType.lightningOverride.randomLightningDelay, blendTime);
			}
		}

		private void UpdateWeatherBlendProgress(float blendTime)
		{
			weatherBlendProgress = Mathf.Lerp(weatherBlendProgress, 1f, blendTime);
			weatherBlendProgress = Mathf.Clamp01(weatherBlendProgress);
			if ((double)weatherBlendProgress >= 0.99)
			{
				weatherBlendProgress = 1f;
			}
		}

		public void ChangeWeather(EnviroWeatherType type)
		{
			if (targetWeatherType != type)
			{
				EnviroManager.instance.NotifyWeatherChanged(type);
				EnviroManager.instance.NotifyZoneWeatherChanged(type, null);
			}
			if (EnviroManager.instance.currentZone != null)
			{
				EnviroManager.instance.currentZone.currentWeatherType = type;
			}
			targetWeatherType = type;
			weatherBlendProgress = 0f;
		}

		public void ChangeWeather(string typeName)
		{
			for (int i = 0; i < Settings.weatherTypes.Count; i++)
			{
				if (Settings.weatherTypes[i].name == typeName)
				{
					if (targetWeatherType != Settings.weatherTypes[i])
					{
						EnviroManager.instance.NotifyWeatherChanged(Settings.weatherTypes[i]);
						EnviroManager.instance.NotifyZoneWeatherChanged(Settings.weatherTypes[i], null);
					}
					if (EnviroManager.instance.currentZone != null)
					{
						EnviroManager.instance.currentZone.currentWeatherType = Settings.weatherTypes[i];
					}
					targetWeatherType = Settings.weatherTypes[i];
					weatherBlendProgress = 0f;
				}
			}
		}

		public void ChangeWeather(int index)
		{
			for (int i = 0; i < Settings.weatherTypes.Count; i++)
			{
				if (i == index)
				{
					if (targetWeatherType != Settings.weatherTypes[i])
					{
						EnviroManager.instance.NotifyWeatherChanged(Settings.weatherTypes[i]);
						EnviroManager.instance.NotifyZoneWeatherChanged(Settings.weatherTypes[i], null);
					}
					if (EnviroManager.instance.currentZone != null)
					{
						EnviroManager.instance.currentZone.currentWeatherType = Settings.weatherTypes[i];
					}
					targetWeatherType = Settings.weatherTypes[i];
					weatherBlendProgress = 0f;
					break;
				}
			}
		}

		public void ChangeZoneWeather(int weather, int zone)
		{
			if (EnviroManager.instance.zones.Count >= zone && Settings.weatherTypes.Count >= weather)
			{
				EnviroManager.instance.zones[zone].currentWeatherType = Settings.weatherTypes[weather];
				EnviroManager.instance.NotifyZoneWeatherChanged(Settings.weatherTypes[weather], EnviroManager.instance.zones[zone]);
			}
		}

		public void ChangeWeatherInstant(EnviroWeatherType type)
		{
			if (targetWeatherType != type)
			{
				EnviroManager.instance.NotifyWeatherChanged(type);
				EnviroManager.instance.NotifyZoneWeatherChanged(type, null);
			}
			if (EnviroManager.instance.currentZone != null)
			{
				EnviroManager.instance.currentZone.currentWeatherType = type;
			}
			targetWeatherType = type;
			weatherBlendProgress = 1f;
			instantTransition = true;
		}

		public void ChangeWeatherInstant(string typeName)
		{
			for (int i = 0; i < Settings.weatherTypes.Count; i++)
			{
				if (Settings.weatherTypes[i].name == typeName)
				{
					if (targetWeatherType != Settings.weatherTypes[i])
					{
						EnviroManager.instance.NotifyWeatherChanged(Settings.weatherTypes[i]);
						EnviroManager.instance.NotifyZoneWeatherChanged(Settings.weatherTypes[i], null);
					}
					if (EnviroManager.instance.currentZone != null)
					{
						EnviroManager.instance.currentZone.currentWeatherType = Settings.weatherTypes[i];
					}
					targetWeatherType = Settings.weatherTypes[i];
					weatherBlendProgress = 1f;
					instantTransition = true;
				}
			}
		}

		public void ChangeWeatherInstant(int index)
		{
			for (int i = 0; i < Settings.weatherTypes.Count; i++)
			{
				if (i == index)
				{
					if (targetWeatherType != Settings.weatherTypes[i])
					{
						EnviroManager.instance.NotifyWeatherChanged(Settings.weatherTypes[i]);
						EnviroManager.instance.NotifyZoneWeatherChanged(Settings.weatherTypes[i], null);
					}
					if (EnviroManager.instance.currentZone != null)
					{
						EnviroManager.instance.currentZone.currentWeatherType = Settings.weatherTypes[i];
					}
					targetWeatherType = Settings.weatherTypes[i];
					weatherBlendProgress = 1f;
					instantTransition = true;
					break;
				}
			}
		}

		public void RegisterZone(EnviroZone zone)
		{
			EnviroManager.instance.zones.Add(zone);
		}

		public void RemoveZone(EnviroZone zone)
		{
			if (EnviroManager.instance.zones.Contains(zone))
			{
				EnviroManager.instance.zones.Remove(zone);
			}
		}

		public void LoadModuleValues()
		{
			if (preset != null)
			{
				Settings = JsonUtility.FromJson<EnviroWeather>(JsonUtility.ToJson(preset.Settings));
			}
			else
			{
				Debug.Log("Please assign a saved module to load from!");
			}
		}

		public void SaveModuleValues()
		{
		}

		public void SaveModuleValues(EnviroWeatherModule module)
		{
			module.Settings = JsonUtility.FromJson<EnviroWeather>(JsonUtility.ToJson(Settings));
		}
	}
}
