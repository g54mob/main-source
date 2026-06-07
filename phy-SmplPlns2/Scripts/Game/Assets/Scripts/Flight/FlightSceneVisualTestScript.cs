using System;
using System.Collections.Generic;
using Beautify.Universal;
using Enviro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight
{
	public class FlightSceneVisualTestScript : MonoBehaviour
	{
		[Serializable]
		private struct VisualSettings
		{
			[Serializable]
			public struct BloomSettings
			{
				public float Intensity;

				public float Threshold;

				public float MaxBrightness;
			}

			[Serializable]
			public struct LightingSettings
			{
				public AnimationCurve SunIntensity;

				public float SunIntensityScale;

				[GradientUsage(true)]
				public Gradient AmbientSkyColorGradient;

				public AnimationCurve AmbientIntensity;

				public float AmbientIntensityScale;
			}

			[Serializable]
			public struct SkySettings
			{
				public float Intensity;

				[GradientUsage(true)]
				public Gradient SunDiscColorGradient;

				public float SunDiscColorIntensity;
			}

			[Serializable]
			public struct TonemappingAndColorSettings
			{
				public Beautify.Universal.Beautify.TonemapOperator Tonemapping;

				public float PreExposure;

				public float PostBrightness;

				public float Saturation;

				public float Brightness;

				public float Contrast;
			}

			public string Name;

			public TonemappingAndColorSettings TonemappingAndColor;

			public LightingSettings Lighting;

			public SkySettings Sky;

			public BloomSettings Bloom;
		}

		private Beautify.Universal.Beautify _beautify;

		private EnviroManager _enviro;

		private Volume _postProcessingVolume;

		[SerializeField]
		private List<VisualSettings> _visualSettings;

		[SerializeField]
		private int _visualSettingSelectedIndex;

		protected virtual void OnValidate()
		{
			if (_visualSettingSelectedIndex < (_visualSettings?.Count ?? 0))
			{
				ApplyCurrentVisualSetting();
			}
		}

		protected virtual void Start()
		{
			_postProcessingVolume = FlightSceneScript.Instance.RenderingManager.GetComponentInChildren<Volume>();
			if (!_postProcessingVolume.profile.TryGet<Beautify.Universal.Beautify>(out _beautify))
			{
				Debug.LogError("Unable to find Beautify");
			}
			_enviro = EnviroManager.instance;
			if (_enviro == null)
			{
				Debug.LogError("Unable to find Enviro");
			}
		}

		private void ApplyCurrentVisualSetting()
		{
			VisualSettings visualSettings = _visualSettings[_visualSettingSelectedIndex];
			_beautify.tonemap.value = visualSettings.TonemappingAndColor.Tonemapping;
			_beautify.tonemapExposurePre.value = visualSettings.TonemappingAndColor.PreExposure;
			_beautify.tonemapExposurePre.overrideState = visualSettings.TonemappingAndColor.PreExposure != 1f;
			_beautify.tonemapBrightnessPost.value = visualSettings.TonemappingAndColor.PostBrightness;
			_beautify.tonemapBrightnessPost.overrideState = visualSettings.TonemappingAndColor.PostBrightness != 1f;
			_beautify.saturate.value = visualSettings.TonemappingAndColor.Saturation;
			_beautify.saturate.overrideState = visualSettings.TonemappingAndColor.Saturation != 1f;
			_beautify.brightness.value = visualSettings.TonemappingAndColor.Brightness;
			_beautify.brightness.overrideState = visualSettings.TonemappingAndColor.Brightness != 1f;
			_beautify.contrast.value = visualSettings.TonemappingAndColor.Contrast;
			_beautify.contrast.overrideState = visualSettings.TonemappingAndColor.Contrast != 1f;
			_beautify.bloomIntensity.value = visualSettings.Bloom.Intensity;
			_beautify.bloomIntensity.overrideState = true;
			_beautify.bloomThreshold.value = visualSettings.Bloom.Threshold;
			_beautify.bloomThreshold.overrideState = true;
			_beautify.bloomMaxBrightness.value = visualSettings.Bloom.MaxBrightness;
			_beautify.bloomMaxBrightness.overrideState = true;
			_enviro.Lighting.Settings.sunIntensityCurve = CreateAnimationCurve(visualSettings.Lighting.SunIntensity, visualSettings.Lighting.SunIntensityScale);
			_enviro.Lighting.Settings.ambientSkyColorGradient = CreateColorGradient(visualSettings.Lighting.AmbientSkyColorGradient);
			_enviro.Lighting.Settings.ambientIntensityCurve = CreateAnimationCurve(visualSettings.Lighting.AmbientIntensity, visualSettings.Lighting.AmbientIntensityScale);
			_enviro.Lighting.UpdateAmbientLighting(forced: true);
			_enviro.Sky.Settings.intensity = visualSettings.Sky.Intensity;
			_enviro.Sky.Settings.sunDiscColorGradient = CreateColorGradient(visualSettings.Sky.SunDiscColorGradient, visualSettings.Sky.SunDiscColorIntensity);
		}

		private void ApplyVisualSetting(int index)
		{
			if (index != _visualSettingSelectedIndex)
			{
				if (index >= _visualSettings.Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				_visualSettingSelectedIndex = index;
				ApplyCurrentVisualSetting();
			}
		}

		private AnimationCurve CreateAnimationCurve(AnimationCurve source, float scale = 1f)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			if (source != null)
			{
				Keyframe[] keys = source.keys;
				for (int i = 0; i < keys.Length; i++)
				{
					keys[i].value *= scale;
				}
				animationCurve.keys = keys;
			}
			return animationCurve;
		}

		private Gradient CreateColorGradient(Gradient source, float scale = 1f)
		{
			Gradient gradient = new Gradient();
			if (source != null)
			{
				gradient.mode = source.mode;
				gradient.colorSpace = source.colorSpace;
				gradient.alphaKeys = source.alphaKeys;
				GradientColorKey[] colorKeys = source.colorKeys;
				if (scale != 1f)
				{
					for (int i = 0; i < colorKeys.Length; i++)
					{
						colorKeys[i].color *= scale;
					}
				}
				gradient.colorKeys = colorKeys;
			}
			return gradient;
		}

		private void SaveCurrentSettings()
		{
			VisualSettings item = new VisualSettings
			{
				Name = string.Empty,
				TonemappingAndColor = 
				{
					Tonemapping = _beautify.tonemap.value,
					PreExposure = (_beautify.tonemapExposurePre.overrideState ? _beautify.tonemapExposurePre.value : 1f),
					PostBrightness = (_beautify.tonemapBrightnessPost.overrideState ? _beautify.tonemapBrightnessPost.value : 1f),
					Saturation = (_beautify.saturate.overrideState ? _beautify.saturate.value : 1f),
					Brightness = (_beautify.brightness.overrideState ? _beautify.brightness.value : 1f),
					Contrast = (_beautify.contrast.overrideState ? _beautify.contrast.value : 1f)
				},
				Lighting = 
				{
					SunIntensity = CreateAnimationCurve(_enviro.Lighting.Settings.sunIntensityCurve),
					SunIntensityScale = 1f,
					AmbientSkyColorGradient = CreateColorGradient(_enviro.Lighting.Settings.ambientSkyColorGradient),
					AmbientIntensity = CreateAnimationCurve(_enviro.Lighting.Settings.ambientIntensityCurve),
					AmbientIntensityScale = 1f
				},
				Sky = 
				{
					Intensity = _enviro.Sky.Settings.intensity,
					SunDiscColorGradient = CreateColorGradient(_enviro.Sky.Settings.sunDiscColorGradient),
					SunDiscColorIntensity = 1f
				},
				Bloom = 
				{
					Intensity = (_beautify.bloomIntensity.overrideState ? _beautify.bloomIntensity.value : 1f),
					Threshold = (_beautify.bloomThreshold.overrideState ? _beautify.bloomThreshold.value : 1f),
					MaxBrightness = (_beautify.bloomMaxBrightness.overrideState ? _beautify.bloomMaxBrightness.value : 10000f)
				}
			};
			_visualSettings.Add(item);
		}
	}
}
