using System;
using Assets.Scripts.Cameras;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.PlanetStudio;
using BeautifyEffect;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Flight.GameView
{
	public class ImageEffectsScript : MonoBehaviour
	{
		private float _defaultBloomIntensity;

		private IGameView _gameView;

		private float _sunFlareDefaultIntensity;

		private float _sunFlareMaxIntensity;

		public Beautify Beautify { get; private set; }

		public bool SunFlaresEnabled
		{
			get
			{
				if (Beautify.enabled)
				{
					return Beautify.sunFlares;
				}
				return false;
			}
		}

		public bool SunOccludedByTerrain { get; set; }

		public MSUnderWaterEffect Underwater { get; private set; }

		protected virtual void LateUpdate()
		{
			if (!Beautify.sunFlares)
			{
				return;
			}
			float num = 1f;
			if (SunOccludedByTerrain)
			{
				num = 0f;
			}
			else if (_gameView != null)
			{
				IPlanetNode planetNode = ScaledSpaceScript.Instance?.Sun.PlanetNode;
				Vector3d vector3d = planetNode.SolarPosition - _gameView.CameraSolarSystemPosition;
				if (_gameView.PlanetNode.PlanetData.HasWater)
				{
					double? num2 = _gameView.GameCamera?.AltitudeAboveSeaLevel;
					if (num2.HasValue && num2 < 0.0)
					{
						num = 1f - Mathf.Clamp01((float)num2.Value * (-1f / 3f));
						if (num > 0f && planetNode != null)
						{
							Vector3d normalized = (planetNode.SolarPosition - _gameView.CameraSolarSystemPosition).normalized;
							Vector3d normalized2 = _gameView.GameCamera.PlanetPosition.normalized;
							if (Vector3d.Dot(normalized, normalized2) <= 0.0)
							{
								num = 0f;
							}
						}
					}
				}
				if (vector3d.sqrMagnitude > 1000000.0)
				{
					num = 6f / (float)Math.Log10(vector3d.sqrMagnitude);
				}
			}
			Beautify.sunFlaresIntensity = Mathf.Lerp(0f, _sunFlareMaxIntensity, num);
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.ImageEffects.Changed -= OnImageEffectsChanged;
			Game.Instance.QualitySettings.Water.Changed -= OnWaterChanged;
		}

		protected virtual void OnDisable()
		{
			UpdateFromQualitySettings();
		}

		protected virtual void OnEnable()
		{
			UpdateFromQualitySettings();
		}

		protected virtual void Start()
		{
			UpdateFromQualitySettings();
			if (Game.InFlightScene)
			{
				_gameView = FlightSceneScript.Instance?.ViewManager.GameView;
			}
			else if (Game.InPlanetStudioScene)
			{
				_gameView = PlanetStudioScript.Instance.CelestialBodyDesignerScript.GameView;
			}
			if (Underwater != null)
			{
				Underwater.quadDropsRenderer.material.renderQueue = 4000;
				AudioMixerGroup gameMixerGroup = Game.Instance.AudioPlayer.GetGameMixerGroup();
				AudioSource audioSourceCamera = Underwater.AudioSourceCamera;
				if (audioSourceCamera != null && audioSourceCamera.outputAudioMixerGroup == null)
				{
					audioSourceCamera.outputAudioMixerGroup = gameMixerGroup;
				}
				AudioSource audioSourceUnderwater = Underwater.AudioSourceUnderwater;
				if (audioSourceUnderwater != null && audioSourceUnderwater.outputAudioMixerGroup == null)
				{
					audioSourceUnderwater.outputAudioMixerGroup = gameMixerGroup;
				}
			}
		}

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			Beautify = GetComponent<Beautify>();
			Underwater = GetComponent<MSUnderWaterEffect>();
			_defaultBloomIntensity = Beautify.bloomIntensity;
			_sunFlareDefaultIntensity = Beautify.sunFlaresIntensity;
			Game.Instance.QualitySettings.ImageEffects.Changed += OnImageEffectsChanged;
			Game.Instance.QualitySettings.Water.Changed += OnWaterChanged;
		}

		private void OnImageEffectsChanged(object sender, SettingsChangedEventArgs<ImageEffectsQualitySettings> e)
		{
			UpdateFromQualitySettings();
		}

		private void OnWaterChanged(object sender, SettingsChangedEventArgs<WaterQualitySettings> e)
		{
			UpdateFromQualitySettings();
		}

		private void UpdateFromQualitySettings()
		{
			ImageEffectsQualitySettings imageEffects = Game.Instance.QualitySettings.ImageEffects;
			Beautify.enabled = imageEffects.Enabled.Value && base.enabled;
			Camera camera = FlightSceneScript.Instance?.ViewManager?.MapViewManager?.MapViewCamera;
			if (camera != null)
			{
				camera.GetComponent<Beautify>().enabled = Beautify.enabled;
			}
			Beautify.contrast = imageEffects.Contrast.Value;
			Beautify.sharpen = Mathf.Lerp(0f, 15f, imageEffects.Sharpness.Value);
			Beautify.saturate = imageEffects.Saturation.Value * 2f;
			string text = imageEffects.Tonemapping.Value switch
			{
				ImageEffectsQualitySettings.ToneMap.OldVideo => "LUTs/OldVideo", 
				ImageEffectsQualitySettings.ToneMap.OldPhoto => "LUTs/OldPhoto", 
				ImageEffectsQualitySettings.ToneMap.OldCamera => "LUTs/OldCamera", 
				ImageEffectsQualitySettings.ToneMap.Faded => "LUTs/Faded", 
				ImageEffectsQualitySettings.ToneMap.Dream => "LUTs/Dream", 
				ImageEffectsQualitySettings.ToneMap.Western => "LUTs/Western", 
				ImageEffectsQualitySettings.ToneMap.Fantasy => "LUTs/Fantasy", 
				ImageEffectsQualitySettings.ToneMap.Dystopian => "LUTs/Dystopian", 
				ImageEffectsQualitySettings.ToneMap.Gray => "LUTs/Grayscale", 
				ImageEffectsQualitySettings.ToneMap.Red => "LUTs/JustRed", 
				ImageEffectsQualitySettings.ToneMap.Green => "LUTs/JustGreen", 
				ImageEffectsQualitySettings.ToneMap.Blue => "LUTs/JustBlue", 
				ImageEffectsQualitySettings.ToneMap.Cartoon => "LUTs/Cartoon", 
				ImageEffectsQualitySettings.ToneMap.Retro => "LUTs/Retro", 
				ImageEffectsQualitySettings.ToneMap.Alien => "LUTs/Alien", 
				_ => string.Empty, 
			};
			if (string.IsNullOrEmpty(text))
			{
				Beautify.lut = false;
			}
			else
			{
				Beautify.lut = true;
				Texture2D texture2D = Game.Instance.ResourceLoader.Load<Texture2D>(text);
				if (texture2D != null)
				{
					Beautify.lutTexture = texture2D;
				}
			}
			Beautify.anamorphicFlaresIntensity = 0.5f * imageEffects.AnamorphicFlareIntensity.Value;
			Beautify.anamorphicFlaresSpread = imageEffects.AnamorphicFlareIntensity.Value;
			if (Mathf.Approximately(0f, Beautify.anamorphicFlaresIntensity) && Beautify.anamorphicFlares)
			{
				Beautify.anamorphicFlares = false;
			}
			else if (!Beautify.anamorphicFlares)
			{
				Beautify.anamorphicFlares = true;
			}
			_sunFlareMaxIntensity = Mathf.Lerp(0f, _sunFlareDefaultIntensity, imageEffects.SunFlareIntensity.Value);
			Beautify.sunFlaresTint = FlightSceneScript.Instance?.FlightState?.SolarSystemData?.FlareColor ?? new Color(1f, 1f, 1f, 1f);
			if (Mathf.Approximately(0f, _sunFlareMaxIntensity) && Beautify.sunFlares)
			{
				Beautify.sunFlares = false;
			}
			else if (!Beautify.sunFlares)
			{
				Beautify.sunFlares = true;
			}
			Beautify.bloomIntensity = Mathf.Lerp(0f, _defaultBloomIntensity, imageEffects.BloomIntensity.Value);
			if (Mathf.Approximately(0f, Beautify.bloomIntensity) && Beautify.bloom)
			{
				Beautify.bloom = false;
			}
			else if (!Beautify.bloom)
			{
				Beautify.bloom = true;
			}
			if (Underwater != null)
			{
				Underwater.enabled = (bool)imageEffects.Enabled && base.enabled;
				WaterQualitySettings water = Game.Instance.QualitySettings.Water;
				Underwater.DisableBlur = !water.UnderwaterBlur.Value;
				Underwater.DisableDistortion = !water.UnderwaterDistortion.Value;
				Underwater.DisableWaterExitDrops = !water.UnderwaterExitEffect.Value;
			}
			SceneCameraScript.UpdateDepthTextureState();
		}
	}
}
