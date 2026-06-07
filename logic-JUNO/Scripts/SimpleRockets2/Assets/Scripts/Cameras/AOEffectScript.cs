using System;
using Assets.Scripts.Input;
using HorizonBasedAmbientOcclusion;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.GameView.Events;
using ModApi.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Cameras
{
	public class AOEffectScript : MonoBehaviour
	{
		private float _baseIntensity;

		private float _baseMaxRadiusPixels;

		private float _baseRadius;

		private ICraftNode _craftNode;

		private bool _flight;

		private IGameCamera _gameCamera;

		private HBAO _hbao;

		private ImageEffectsQualitySettings _imageEffects;

		private float _intensity;

		private SceneMasterCameraScript _masterCam;

		private bool _underWater;

		protected virtual void OnDestroy()
		{
			Game.Instance.Settings.Quality.Display.Changed -= OnSettingsChanged;
			_imageEffects.Changed -= OnSettingsChanged;
			if (_masterCam != null)
			{
				_masterCam.ScreenResolutionChanged -= OnSettingsChanged;
			}
			if (_gameCamera != null)
			{
				_gameCamera.CameraUnderWaterStateChanged -= OnCameraUnderWaterStateChanged;
			}
		}

		protected virtual void Start()
		{
			Game.Instance.Settings.Quality.Display.Changed += OnSettingsChanged;
			_hbao = base.gameObject.GetComponent<HBAO>();
			_imageEffects = Game.Instance.Settings.Quality.ImageEffects;
			_imageEffects.Changed += OnSettingsChanged;
			_masterCam = UnityEngine.Object.FindObjectOfType<SceneMasterCameraScript>();
			_flight = Game.InFlightScene;
			_baseIntensity = _hbao.GetAoIntensity();
			_baseRadius = _hbao.GetAoRadius();
			_baseMaxRadiusPixels = _hbao.GetAoMaxRadiusPixels();
			if (_flight)
			{
				UpdateCraftNode();
				Game.Instance.FlightScene.CraftChanged += OnFlightSceneCraftChanged;
				_gameCamera = Game.Instance.FlightScene.ViewManager.GameView.GameCamera;
				_gameCamera.CameraUnderWaterStateChanged += OnCameraUnderWaterStateChanged;
				_masterCam.ScreenResolutionChanged += OnSettingsChanged;
			}
			UpdateFromSettings();
		}

		protected virtual void Update()
		{
			if (DebugInput.GetKeyDown(KeyCode.O) && DebugInput.GetKey(KeyCode.LeftShift))
			{
				_hbao.enabled = !_hbao.enabled;
			}
			ICraftNode craftNode = _craftNode;
			if (craftNode == null)
			{
				return;
			}
			ICraftScript craftScript = craftNode.CraftScript;
			if (craftScript != null)
			{
				_ = craftScript.AtmosphereSample;
				if (true && _hbao.enabled)
				{
					float num = Mathf.Lerp(0.5f, 1f, Mathf.Clamp01(_craftNode.CraftScript.AtmosphereSample.AirDensity));
					_hbao.SetAoIntensity(_intensity * num);
				}
			}
		}

		private void OnCameraUnderWaterStateChanged(object sender, CameraUnderwaterStateChangedEventArgs e)
		{
			_underWater = e.IsCameraUnderWater;
			UpdateFromSettings();
		}

		private void OnFlightSceneCraftChanged(ICraftNode craftNode)
		{
			UpdateCraftNode();
		}

		private void OnSettingsChanged(object sender, EventArgs e)
		{
			_hbao.CurrentTarget = BuiltinRenderTextureType.CameraTarget;
			_hbao.enabled = false;
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				UpdateFromSettings();
			});
		}

		private void UpdateCraftNode()
		{
			_craftNode = Game.Instance.FlightScene.CraftNode;
		}

		private void UpdateFromSettings()
		{
			if (_flight)
			{
				if (_masterCam.RenderTextureCraftMask != null)
				{
					_hbao.CurrentTarget = new RenderTargetIdentifier(GetComponent<SceneCameraScript>().MasterCamera.RenderTextureScene);
				}
				else
				{
					_hbao.CurrentTarget = BuiltinRenderTextureType.CameraTarget;
				}
			}
			_hbao.enabled = _imageEffects.AmbientOcclusion.Value > 0f && _imageEffects.Enabled.Value && !_underWater;
			if (_hbao.enabled)
			{
				_intensity = _baseIntensity * _imageEffects.AmbientOcclusion.Value;
				_hbao.SetAoIntensity(_intensity);
				_hbao.SetAoRadius(_baseRadius * _imageEffects.AmbientOcclusion.Value);
				_hbao.SetAoMaxRadiusPixels(_baseMaxRadiusPixels * _imageEffects.AmbientOcclusion.Value);
			}
		}
	}
}
