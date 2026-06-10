using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class CameraSettingsView : OptionsView
	{
		[SerializeField]
		private Toggle screenEdgeMouseScrollToggle;

		[SerializeField]
		private Slider cameraSensitivitySlider;

		[SerializeField]
		private Toggle cameraVisualsToggle;

		[SerializeField]
		private Slider cameraTargetVisualsDuration;

		[SerializeField]
		private Toggle cameraOffsetByBuildings;

		[SerializeField]
		private Toggle cameraShakeToggle;

		[SerializeField]
		private TMP_Text[] coyoteCameraOptionsTexts;

		private void Start()
		{
			GlobalSaveController instance = MonoSingleton<GlobalSaveController>.Instance;
			SetupCameraSensitivityOption(instance.GlobalSettings.CameraSensitivity);
			screenEdgeMouseScrollToggle.onValueChanged.AddListener(delegate
			{
				OnScreenEdgeMouseScrollToggleChange();
			});
			cameraVisualsToggle.onValueChanged.AddListener(delegate
			{
				OnCameraVisualsChange();
			});
			cameraSensitivitySlider.onValueChanged.AddListener(delegate
			{
				OnCameraSensitivityValueChange();
			});
			cameraTargetVisualsDuration.onValueChanged.AddListener(delegate
			{
				OnCameraVisualsDurationChange();
			});
			cameraOffsetByBuildings.onValueChanged.AddListener(delegate
			{
				OnCameraOffsetByBuildingsChange();
			});
			cameraShakeToggle.onValueChanged.AddListener(delegate
			{
				OnCameraShakeChange();
			});
		}

		public override void Show()
		{
			base.Show();
			GlobalSaveController instance = MonoSingleton<GlobalSaveController>.Instance;
			cameraVisualsToggle.isOn = instance.GlobalSettings.CameraVisuals;
			screenEdgeMouseScrollToggle.isOn = instance.GlobalSettings.ScreenEdgeMouseScroll;
			cameraOffsetByBuildings.isOn = instance.GlobalSettings.CameraOffsetByBuildings;
			cameraTargetVisualsDuration.value = instance.GlobalSettings.CameraVisualsDurationTime;
			cameraShakeToggle.isOn = instance.GlobalSettings.CameraShake;
		}

		private void OnScreenEdgeMouseScrollToggleChange()
		{
			MonoSingleton<OptionsController>.Instance.SetScreenEdgeMouseScrool(screenEdgeMouseScrollToggle.isOn);
		}

		private void OnCameraSensitivityValueChange()
		{
			MonoSingleton<OptionsController>.Instance.SetCameraSensitivity(cameraSensitivitySlider.value);
		}

		private void OnCameraVisualsChange()
		{
			MonoSingleton<OptionsController>.Instance.SetCameraVisuals(cameraVisualsToggle.isOn);
		}

		private void OnCameraVisualsDurationChange()
		{
			MonoSingleton<OptionsController>.Instance.SetCameraVisualsDurationTime(cameraTargetVisualsDuration.value);
		}

		private void OnCameraOffsetByBuildingsChange()
		{
			MonoSingleton<OptionsController>.Instance.SetCameraOffsetByBuildings(cameraOffsetByBuildings.isOn);
		}

		private void OnCameraShakeChange()
		{
			MonoSingleton<OptionsController>.Instance.SetCameraShake(cameraShakeToggle.isOn);
		}

		private void SetupCameraSensitivityOption(float value)
		{
			CameraSettings data = Repository<GameplayCameraSettingsData, CameraSettings>.Instance.GetData<CameraSettings>();
			Slider slider = cameraSensitivitySlider;
			slider.minValue = data.CameraSensitivityMin;
			slider.maxValue = data.CameraSensitivityMax;
			slider.value = value;
		}
	}
}
