using System;
using UnityEngine;

namespace Enviro
{
	[Serializable]
	[ExecuteInEditMode]
	public class EnviroSkyModule : EnviroModule
	{
		public EnviroSky Settings;

		public EnviroSkyModule preset;

		public bool showSkyControls;

		public bool showSkySunControls;

		public bool showSkyMoonControls;

		public bool showSkyStarsControls;

		public Material mySkyboxMat;

		private float starsTwinkling;

		public override void Enable()
		{
			if (!(EnviroManager.instance == null))
			{
				SetupSkybox();
			}
		}

		public override void Disable()
		{
			if (mySkyboxMat != null)
			{
				UnityEngine.Object.DestroyImmediate(mySkyboxMat);
			}
		}

		public override void UpdateModule()
		{
			if (active && !(EnviroManager.instance == null))
			{
				if (mySkyboxMat == null || (mySkyboxMat != RenderSettings.skybox && Settings.forcedSkyboxSetup))
				{
					SetupSkybox();
				}
				UpdateSkybox(mySkyboxMat);
				if (EnviroManager.instance != null && EnviroManager.instance.Time != null && Settings.moonMode == EnviroSky.MoonMode.Realistic)
				{
					UpdateMoonPhase();
				}
			}
		}

		public void SetupSkybox()
		{
			if (mySkyboxMat == null)
			{
				mySkyboxMat = new Material(Shader.Find("Enviro/Skybox"));
				RenderSettings.skybox = mySkyboxMat;
			}
			else
			{
				RenderSettings.skybox = mySkyboxMat;
			}
		}

		public void UpdateSkybox(Material mat)
		{
			float solarTime = EnviroManager.instance.solarTime;
			Shader.SetGlobalColor("_FrontColor1", Settings.frontColorGradient1.Evaluate(solarTime));
			Shader.SetGlobalColor("_FrontColor2", Settings.frontColorGradient2.Evaluate(solarTime));
			Shader.SetGlobalColor("_FrontColor5", Settings.frontColorGradient5.Evaluate(solarTime));
			Shader.SetGlobalColor("_BackColor1", Settings.backColorGradient1.Evaluate(solarTime));
			Shader.SetGlobalColor("_BackColor2", Settings.backColorGradient2.Evaluate(solarTime));
			Shader.SetGlobalColor("_BackColor5", Settings.backColorGradient5.Evaluate(solarTime));
			Shader.SetGlobalColor("_SkyColorTint", Settings.skyColorTint);
			Shader.SetGlobalColor("_SunColor", Settings.sunDiscColorGradient.Evaluate(solarTime));
			mat.SetColor("_MoonColor", Settings.moonColorGradient.Evaluate(solarTime));
			mat.SetColor("_MoonGlowColor", Settings.moonGlowColorGradient.Evaluate(solarTime));
			Shader.SetGlobalFloat("_Intensity", Settings.intensity * Settings.intensityCurve.Evaluate(solarTime));
			Shader.SetGlobalFloat("_MieScatteringIntensity", Settings.mieScatteringIntensityCurve.Evaluate(solarTime));
			mat.SetFloat("_MoonGlowIntensity", Settings.moonGlowIntensityCurve.Evaluate(solarTime));
			mat.SetFloat("_StarIntensity", Settings.starIntensityCurve.Evaluate(solarTime));
			mat.SetFloat("_GalaxyIntensity", Settings.galaxyIntensityCurve.Evaluate(solarTime));
			Shader.SetGlobalFloat("_frontBackDistribution0", Settings.distribution0);
			Shader.SetGlobalFloat("_frontBackDistribution1", Settings.distribution1);
			if (Settings.skyMode == EnviroSky.SkyMode.Simple)
			{
				Shader.EnableKeyword("ENVIRO_SIMPLESKY");
			}
			else
			{
				Shader.DisableKeyword("ENVIRO_SIMPLESKY");
				Shader.SetGlobalColor("_FrontColor0", Settings.frontColorGradient0.Evaluate(solarTime));
				Shader.SetGlobalColor("_BackColor0", Settings.backColorGradient0.Evaluate(solarTime));
				Shader.SetGlobalColor("_FrontColor3", Settings.frontColorGradient3.Evaluate(solarTime));
				Shader.SetGlobalColor("_FrontColor4", Settings.frontColorGradient4.Evaluate(solarTime));
				Shader.SetGlobalColor("_BackColor3", Settings.backColorGradient3.Evaluate(solarTime));
				Shader.SetGlobalColor("_BackColor4", Settings.backColorGradient4.Evaluate(solarTime));
				Shader.SetGlobalFloat("_frontBackDistribution2", Settings.distribution2);
				Shader.SetGlobalFloat("_frontBackDistribution3", Settings.distribution3);
				if (Settings.galaxyTex != null)
				{
					mat.SetTexture("_GalaxyTex", Settings.galaxyTex);
				}
			}
			if (Settings.moonMode == EnviroSky.MoonMode.Off)
			{
				mat.SetVector("_SkyMoonParameters", new Vector4(Settings.moonPhase, Settings.moonScale, Settings.moonScale, 0f));
			}
			else
			{
				mat.SetVector("_SkyMoonParameters", new Vector4(Settings.moonPhase, Settings.moonScale, Settings.moonScale, 1f));
			}
			mat.SetVector("_SkySunParameters", new Vector4(Settings.sunScale, Settings.sunScale, Settings.sunScale, Settings.sunScale));
			if (Settings.starsTex != null)
			{
				mat.SetTexture("_StarsTex", Settings.starsTex);
			}
			if (Settings.starsTwinklingTex != null)
			{
				mat.SetTexture("_StarsTwinklingTex", Settings.starsTwinklingTex);
			}
			if (Settings.sunTex != null)
			{
				mat.SetTexture("_SunTex", Settings.sunTex);
			}
			if (Settings.moonTex != null)
			{
				mat.SetTexture("_MoonTex", Settings.moonTex);
			}
			if (Settings.moonGlowTex != null)
			{
				mat.SetTexture("_MoonGlowTex", Settings.moonGlowTex);
			}
			Shader.SetGlobalVector("_SunDir", -EnviroManager.instance.Objects.sun.transform.forward);
			Shader.SetGlobalVector("_MoonDir", EnviroManager.instance.Objects.moon.transform.forward);
			if (EnviroManager.instance.FlatClouds == null)
			{
				Shader.SetGlobalFloat("_CirrusClouds", 0f);
				Shader.SetGlobalFloat("_FlatClouds", 0f);
			}
			if (EnviroManager.instance.Aurora == null)
			{
				Shader.SetGlobalFloat("_Aurora", 0f);
			}
			mat.SetFloat("_StarsTwinkling", Settings.starsTwinklingSpeed);
			if (Settings.starsTwinklingSpeed > 0f)
			{
				starsTwinkling += Settings.starsTwinklingSpeed * Time.deltaTime;
				Quaternion q = Quaternion.Euler(starsTwinkling, starsTwinkling, starsTwinkling);
				Matrix4x4 value = Matrix4x4.TRS(Vector3.zero, q, new Vector3(1f, 1f, 1f));
				mat.SetMatrix("_StarsTwinklingMatrix", value);
			}
		}

		private void UpdateMoonPhase()
		{
			float num = Vector3.SignedAngle(EnviroManager.instance.Objects.moon.transform.forward, EnviroManager.instance.Objects.sun.transform.forward, -EnviroManager.instance.transform.forward);
			if (EnviroManager.instance.Time.Settings.latitude >= 0f)
			{
				if (num < 0f)
				{
					Settings.moonPhase = EnviroHelper.Remap(num, 0f, -180f, -2f, 0f);
				}
				else
				{
					Settings.moonPhase = EnviroHelper.Remap(num, 0f, 180f, 2f, 0f);
				}
			}
			else if (num < 0f)
			{
				Settings.moonPhase = EnviroHelper.Remap(num, 0f, -180f, 2f, 0f);
			}
			else
			{
				Settings.moonPhase = EnviroHelper.Remap(num, 0f, 180f, -2f, 0f);
			}
		}

		public void LoadModuleValues()
		{
			if (preset != null)
			{
				Settings = JsonUtility.FromJson<EnviroSky>(JsonUtility.ToJson(preset.Settings));
			}
			else
			{
				Debug.Log("Please assign a saved module to load from!");
			}
		}

		public void SaveModuleValues()
		{
		}

		public void SaveModuleValues(EnviroSkyModule module)
		{
			module.Settings = JsonUtility.FromJson<EnviroSky>(JsonUtility.ToJson(Settings));
		}
	}
}
