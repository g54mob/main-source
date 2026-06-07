using Assets.Scripts.Settings;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Rendering
{
	public class CameraQualityScript : MonoBehaviour
	{
		private EnumSetting<DisplayQualitySettings.AntiAliasingType> _antiAliasingSetting;

		private Camera _camera;

		private UniversalAdditionalCameraData _cameraData;

		private EnumSetting<ShadowQualitySettings.ShadowQualityLevel> _shadowQualitySetting;

		public void UpdateAntiAliasingSettings()
		{
			if (_cameraData == null)
			{
				return;
			}
			if (Game.Instance.XRDeviceManager.HmdActive)
			{
				_cameraData.antialiasing = AntialiasingMode.None;
				return;
			}
			switch (Game.Instance.Settings.Quality.Display.AntiAliasing.Value)
			{
			case DisplayQualitySettings.AntiAliasingType.None:
			case DisplayQualitySettings.AntiAliasingType.MSAA2:
			case DisplayQualitySettings.AntiAliasingType.MSAA4:
			case DisplayQualitySettings.AntiAliasingType.MSAA8:
				_cameraData.antialiasing = AntialiasingMode.None;
				break;
			case DisplayQualitySettings.AntiAliasingType.FXAA:
				_cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
				break;
			case DisplayQualitySettings.AntiAliasingType.SMAA:
				_cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
				break;
			case DisplayQualitySettings.AntiAliasingType.TAA:
				_cameraData.antialiasing = AntialiasingMode.TemporalAntiAliasing;
				break;
			default:
				_cameraData.antialiasing = AntialiasingMode.None;
				break;
			}
		}

		protected virtual void Awake()
		{
			_camera = GetComponent<Camera>();
			_cameraData = _camera.GetComponent<UniversalAdditionalCameraData>();
			_antiAliasingSetting = Game.Instance.Settings.Quality.Display.AntiAliasing;
			_antiAliasingSetting.Changed += OnAntiAliasingSettingChanged;
			UpdateAntiAliasingSettings();
			_shadowQualitySetting = Game.Instance.Settings.Quality.Shadow.ShadowQuality;
			_shadowQualitySetting.Changed += OnShadowQualityChanged;
			UpdateShadowQualitySettings();
		}

		protected virtual void OnDestroy()
		{
			_antiAliasingSetting.Changed -= OnAntiAliasingSettingChanged;
			Game.Instance.XRDeviceManager.HmdActiveChanged -= OnHmdActiveChanged;
		}

		protected virtual void Start()
		{
			Game.Instance.XRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
		}

		private void OnAntiAliasingSettingChanged(object sender, SettingChangedEventArgs<DisplayQualitySettings.AntiAliasingType> e)
		{
			UpdateAntiAliasingSettings();
		}

		private void OnHmdActiveChanged(bool active)
		{
			UpdateAntiAliasingSettings();
		}

		private void OnShadowQualityChanged(object sender, SettingChangedEventArgs<ShadowQualitySettings.ShadowQualityLevel> e)
		{
			UpdateShadowQualitySettings();
		}

		private void UpdateShadowQualitySettings()
		{
			_cameraData.renderShadows = _shadowQualitySetting.Value != ShadowQualitySettings.ShadowQualityLevel.Off;
		}
	}
}
