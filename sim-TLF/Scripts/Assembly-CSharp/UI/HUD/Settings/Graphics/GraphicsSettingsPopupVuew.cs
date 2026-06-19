using Loxodon.Framework.Views;
using Services.Save;
using Services.Save.Settings;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Zenject;

namespace UI.HUD.Settings.Graphics
{
	public class GraphicsSettingsPopupVuew : UIView
	{
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private GraphicsSettingsControllView _vsyncControll;

		[SerializeField]
		private GraphicsSettingsControllView _vignetteControll;

		[SerializeField]
		private GraphicsSettingsControllView _motionBlurControll;

		[SerializeField]
		private GraphicsSettingsControllView _cloudsControll;

		[SerializeField]
		private GraphicsSettingsControllSliderView _fpsControll;

		private Vignette _vignette;

		private MotionBlur _motionBlur;

		private Volume _volume;

		private VolumeProfile _profileInstance;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private SceneGraphicsSettingsRegistry _registry;

		protected override void Awake()
		{
			_volume = Object.FindFirstObjectByType<GraphicsSettingsSaveHandler>().GetComponent<Volume>();
			_profileInstance = _volume.profile;
			_profileInstance.TryGet<Vignette>(out _vignette);
			_profileInstance.TryGet<MotionBlur>(out _motionBlur);
		}

		protected override void Start()
		{
			_closeButton.onClick.AddListener(Close);
			_vsyncControll.Init("VSync", OnVsyncChanged, QualitySettings.vSyncCount > 0);
			_vignetteControll.Init("Vignette", OnVignetteChanged, _vignette.active);
			_motionBlurControll.Init("Motion Blur", OnMotionBlurChanged, _motionBlur.active);
			_fpsControll.Init("Target FPS", OnFpsChanged, Application.targetFrameRate);
		}

		private void OnFpsChanged(float value)
		{
			Application.targetFrameRate = (int)value;
		}

		private void OnMotionBlurChanged(bool value)
		{
			_motionBlur.active = value;
		}

		private void OnVignetteChanged(bool value)
		{
			_vignette.active = value;
		}

		private void OnVsyncChanged(bool value)
		{
			QualitySettings.vSyncCount = (value ? 1 : 0);
		}

		private void Close()
		{
			base.gameObject.SetActive(value: false);
			_saveService.Save(_registry.SaveKey);
		}
	}
}
