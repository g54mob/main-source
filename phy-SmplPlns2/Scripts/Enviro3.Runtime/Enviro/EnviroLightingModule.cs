using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Enviro
{
	[Serializable]
	[ExecuteInEditMode]
	public class EnviroLightingModule : EnviroModule
	{
		public EnviroLighting Settings;

		public EnviroLightingModule preset;

		private int currentFrame;

		private float lastAmbientSkyboxUpdate;

		public bool showDirectLightingControls;

		public bool showAmbientLightingControls;

		public bool showReflectionControls;

		private bool _night;

		private float _nightDayTransition;

		private float _nightDayStartIntensity;

		private static readonly int DayNightValueShaderID = Shader.PropertyToID("_DAY_NIGHT_VALUE");

		public override void Enable()
		{
			if (!(EnviroManager.instance == null))
			{
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

		public void ApplyLightingChanges()
		{
			Cleanup();
			Setup();
		}

		private void Setup()
		{
			if (EnviroManager.instance.Objects.directionalLight == null)
			{
				GameObject gameObject = new GameObject();
				if (Settings.lightingMode == EnviroLighting.LightingMode.Single)
				{
					gameObject.name = "Sun and Moon Directional Light";
				}
				else
				{
					gameObject.name = "Sun Directional Light";
				}
				gameObject.transform.SetParent(EnviroManager.instance.transform);
				gameObject.transform.localPosition = Vector3.zero;
				EnviroManager.instance.Objects.directionalLight = gameObject.AddComponent<Light>();
				EnviroManager.instance.Objects.directionalLight.type = LightType.Directional;
				EnviroManager.instance.Objects.directionalLight.shadows = LightShadows.Soft;
			}
			if (EnviroManager.instance.Objects.additionalDirectionalLight == null && Settings.lightingMode == EnviroLighting.LightingMode.Dual)
			{
				GameObject gameObject2 = new GameObject();
				gameObject2.name = "Moon Directional Light";
				gameObject2.transform.SetParent(EnviroManager.instance.transform);
				gameObject2.transform.localPosition = Vector3.zero;
				EnviroManager.instance.Objects.additionalDirectionalLight = gameObject2.AddComponent<Light>();
				EnviroManager.instance.Objects.additionalDirectionalLight.type = LightType.Directional;
				EnviroManager.instance.Objects.additionalDirectionalLight.shadows = LightShadows.Soft;
			}
			else if (EnviroManager.instance.Objects.additionalDirectionalLight != null && Settings.lightingMode == EnviroLighting.LightingMode.Single)
			{
				UnityEngine.Object.DestroyImmediate(EnviroManager.instance.Objects.additionalDirectionalLight.gameObject);
			}
		}

		private void Cleanup()
		{
			if (!(EnviroManager.instance == null))
			{
				if (EnviroManager.instance.Objects.directionalLight != null)
				{
					UnityEngine.Object.DestroyImmediate(EnviroManager.instance.Objects.directionalLight.gameObject);
				}
				if (EnviroManager.instance.Objects.additionalDirectionalLight != null)
				{
					UnityEngine.Object.DestroyImmediate(EnviroManager.instance.Objects.additionalDirectionalLight.gameObject);
				}
			}
		}

		public override void UpdateModule()
		{
			if (active && !(EnviroManager.instance == null))
			{
				currentFrame++;
				if (currentFrame >= Settings.updateIntervallFrames)
				{
					EnviroManager.instance.updateSkyAndLighting = true;
					currentFrame = 0;
				}
				else
				{
					EnviroManager.instance.updateSkyAndLighting = false;
				}
				if (EnviroManager.instance.Objects.directionalLight != null && Settings.setDirectLighting && EnviroManager.instance.updateSkyAndLighting)
				{
					UpdateDirectLighting();
				}
				if (Settings.setAmbientLighting)
				{
					UpdateAmbientLighting(Settings.ambientUpdateEveryFrame);
				}
			}
		}

		public void UpdateDirectLighting()
		{
			if (Settings.lightingMode == EnviroLighting.LightingMode.Single)
			{
				Light directionalLight = EnviroManager.instance.Objects.directionalLight;
				Quaternion rotation;
				float num;
				Color color;
				float shadowStrength;
				if (!EnviroManager.instance.isNight)
				{
					rotation = EnviroManager.instance.Objects.sun.transform.rotation;
					num = Settings.sunIntensityCurve.Evaluate(EnviroManager.instance.solarTime) * Settings.directLightIntensityModifier;
					color = Settings.sunColorGradient.Evaluate(EnviroManager.instance.solarTime);
					shadowStrength = 1f;
				}
				else
				{
					rotation = EnviroManager.instance.Objects.moon.transform.rotation;
					num = Settings.moonIntensityCurve.Evaluate(EnviroManager.instance.lunarTime) * Settings.directLightIntensityModifier;
					color = Settings.moonColorGradient.Evaluate(EnviroManager.instance.lunarTime);
					shadowStrength = 0.25f;
				}
				if (_night != EnviroManager.instance.isNight)
				{
					_night = EnviroManager.instance.isNight;
					_nightDayTransition = 1f;
					_nightDayStartIntensity = directionalLight.intensity;
				}
				if (_nightDayTransition > 0f)
				{
					float num2 = _nightDayTransition * 2f - 1f;
					if (num2 > 0f)
					{
						rotation = directionalLight.transform.rotation;
						color = directionalLight.color;
						shadowStrength = directionalLight.shadowStrength;
						num = Mathf.Lerp(0f, _nightDayStartIntensity, num2);
					}
					else
					{
						num2 = Mathf.Abs(num2);
						num = Mathf.Lerp(0f, num, num2);
					}
					Shader.SetGlobalFloat(DayNightValueShaderID, _night ? _nightDayTransition : (1f - _nightDayTransition));
					_nightDayTransition -= Time.unscaledDeltaTime * 0.5f;
				}
				else
				{
					Shader.SetGlobalFloat(DayNightValueShaderID, _night ? 0f : 1f);
				}
				directionalLight.shadowStrength = shadowStrength;
				directionalLight.transform.rotation = rotation;
				directionalLight.intensity = num;
				EnviroManager.instance.Objects.directionalLight.color = color;
			}
			else
			{
				EnviroManager.instance.Objects.directionalLight.transform.rotation = EnviroManager.instance.Objects.sun.transform.rotation;
				EnviroManager.instance.Objects.directionalLight.intensity = Settings.sunIntensityCurve.Evaluate(EnviroManager.instance.solarTime) * Settings.directLightIntensityModifier;
				EnviroManager.instance.Objects.directionalLight.color = Settings.sunColorGradient.Evaluate(EnviroManager.instance.solarTime);
				EnviroManager.instance.Objects.additionalDirectionalLight.transform.rotation = EnviroManager.instance.Objects.moon.transform.rotation;
				EnviroManager.instance.Objects.additionalDirectionalLight.intensity = Settings.moonIntensityCurve.Evaluate(EnviroManager.instance.lunarTime) * Settings.directLightIntensityModifier;
				EnviroManager.instance.Objects.additionalDirectionalLight.color = Settings.moonColorGradient.Evaluate(EnviroManager.instance.lunarTime);
			}
		}

		public void UpdateAmbientLighting(bool forced = false)
		{
			RenderSettings.ambientMode = Settings.ambientMode;
			float intensity = (RenderSettings.ambientIntensity = Settings.ambientIntensityCurve.Evaluate(EnviroManager.instance.solarTime) * Settings.ambientIntensityModifier);
			if (forced)
			{
				UpdateAmbient(Settings.ambientMode, intensity);
				if (EnviroManager.instance.Time != null)
				{
					lastAmbientSkyboxUpdate = EnviroManager.instance.Time.Settings.timeOfDay + Settings.ambientUpdateIntervall;
				}
			}
			else if (EnviroManager.instance.Time != null)
			{
				if (lastAmbientSkyboxUpdate < EnviroManager.instance.Time.Settings.timeOfDay || lastAmbientSkyboxUpdate > EnviroManager.instance.Time.Settings.timeOfDay + (Settings.ambientUpdateIntervall + 0.01f))
				{
					UpdateAmbient(Settings.ambientMode, intensity);
					lastAmbientSkyboxUpdate = EnviroManager.instance.Time.Settings.timeOfDay + Settings.ambientUpdateIntervall;
				}
			}
			else if (lastAmbientSkyboxUpdate < Time.realtimeSinceStartup || lastAmbientSkyboxUpdate > Time.realtimeSinceStartup + (Settings.ambientUpdateIntervall + 0.01f))
			{
				UpdateAmbient(Settings.ambientMode, intensity);
				lastAmbientSkyboxUpdate = Time.realtimeSinceStartup + Settings.ambientUpdateIntervall;
			}
		}

		private void UpdateAmbient(AmbientMode ambientMode, float intensity)
		{
			switch (ambientMode)
			{
			case AmbientMode.Flat:
				RenderSettings.ambientSkyColor = Settings.ambientSkyColorGradient.Evaluate(EnviroManager.instance.solarTime) * intensity;
				break;
			case AmbientMode.Trilight:
				RenderSettings.ambientSkyColor = Settings.ambientSkyColorGradient.Evaluate(EnviroManager.instance.solarTime) * intensity;
				RenderSettings.ambientEquatorColor = Settings.ambientEquatorColorGradient.Evaluate(EnviroManager.instance.solarTime) * intensity;
				RenderSettings.ambientGroundColor = Settings.ambientGroundColorGradient.Evaluate(EnviroManager.instance.solarTime) * intensity;
				break;
			case AmbientMode.Skybox:
				DynamicGI.UpdateEnvironment();
				break;
			case (AmbientMode)2:
				break;
			}
		}

		public void LoadModuleValues()
		{
			if (preset != null)
			{
				Settings = JsonUtility.FromJson<EnviroLighting>(JsonUtility.ToJson(preset.Settings));
			}
			else
			{
				Debug.Log("Please assign a saved module to load from!");
			}
		}

		public void SaveModuleValues()
		{
		}

		public void SaveModuleValues(EnviroLightingModule module)
		{
			module.Settings = JsonUtility.FromJson<EnviroLighting>(JsonUtility.ToJson(Settings));
		}
	}
}
