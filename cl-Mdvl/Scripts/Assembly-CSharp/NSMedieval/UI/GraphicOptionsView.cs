using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class GraphicOptionsView : OptionsView
	{
		[FormerlySerializedAs("screenSettinsFailsafePanel")]
		[SerializeField]
		private ScreenSettingsResetView screenSettingsFailsafePanel;

		[SerializeField]
		private Toggle fullscreenToggle;

		[SerializeField]
		private Toggle runInBackgroundToggle;

		[SerializeField]
		private TMP_Dropdown resolutionDropdown;

		[SerializeField]
		private TMP_Dropdown textureQualityDropdown;

		[SerializeField]
		private TMP_Dropdown shadowQualityDropdown;

		[SerializeField]
		private TMP_Dropdown antiAliasingDropdown;

		[SerializeField]
		private Toggle anisotropicFilteringToggle;

		[SerializeField]
		private TMP_Dropdown vsyncDropdown;

		[SerializeField]
		private TMP_Dropdown fpsCapDropdown;

		[SerializeField]
		private GameObject fpsCapDropdownGO;

		[SerializeField]
		private Toggle softParticlesToggle;

		[SerializeField]
		private Toggle motionBlurToggle;

		[SerializeField]
		private Slider sharpnessSlider;

		[SerializeField]
		private Toggle ambientOcclusionToggle;

		[SerializeField]
		private Toggle bloomToggle;

		[SerializeField]
		private Toggle sunBeamsToggle;

		[SerializeField]
		private Toggle environmentParticlesFootprintsToggle;

		[SerializeField]
		private Toggle birdsEffectToggle;

		[SerializeField]
		private Toggle grassEffectToggle;

		[SerializeField]
		private Toggle environmentParticlesToggle;

		private readonly Dictionary<int, Resolution> wantedResolutions = new Dictionary<int, Resolution>();

		private int savedResolutionIndex;

		public override void Show()
		{
			base.Show();
			RefreshToggles();
			SetupVSyncOptions();
			SetupFPSCapOptions();
			SetupTextureQualityOptions();
			SetupShadowQualityOptions();
			SetupAntiAliasingOptions();
			sharpnessSlider.value = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.Sharpness;
		}

		private void Start()
		{
			fullscreenToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetFullscreen(value);
			});
			runInBackgroundToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetRunInBackground(value);
			});
			vsyncDropdown.onValueChanged.AddListener(delegate(int value)
			{
				SetVSyncOption(value);
			});
			fpsCapDropdown.onValueChanged.AddListener(delegate(int value)
			{
				MonoSingleton<OptionsController>.Instance.SetFPSCap(value);
			});
			textureQualityDropdown.onValueChanged.AddListener(delegate(int value)
			{
				MonoSingleton<OptionsController>.Instance.SetTextureQuality(value);
			});
			shadowQualityDropdown.onValueChanged.AddListener(delegate(int value)
			{
				MonoSingleton<OptionsController>.Instance.SetShadowsQuality(value);
			});
			antiAliasingDropdown.onValueChanged.AddListener(delegate(int value)
			{
				MonoSingleton<OptionsController>.Instance.SetAntiAliasing(value);
			});
			softParticlesToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetSoftParticles(value);
			});
			anisotropicFilteringToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetAnisotropicFiltering(value);
			});
			motionBlurToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetMotionBlur(value);
			});
			sharpnessSlider.onValueChanged.AddListener(delegate(float value)
			{
				MonoSingleton<OptionsController>.Instance.SetSharpness(value);
			});
			bloomToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetBloom(value);
			});
			ambientOcclusionToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetAmbientOcclusion(value);
			});
			sunBeamsToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetSunbeams(value);
			});
			environmentParticlesToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetEnvironmentParticles(value);
			});
			environmentParticlesFootprintsToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetEnvironmentFootprintsParticles(value);
			});
			birdsEffectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetBirdsEffect(value);
			});
			grassEffectToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetGrassHidden(!value);
			});
			SetupResolutionOptions();
			MonoSingleton<OptionsController>.Instance.FullscreenExternalEvent += RefreshToggles;
		}

		private void RefreshToggles()
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				fullscreenToggle.isOn = base.GlobalSettings.Fullscreen;
				runInBackgroundToggle.isOn = base.GlobalSettings.RunInBackground;
				softParticlesToggle.isOn = base.GlobalSettings.SoftParticles;
				anisotropicFilteringToggle.isOn = base.GlobalSettings.AnisotropicFiltering;
				motionBlurToggle.isOn = base.GlobalSettings.MotionBlur;
				bloomToggle.isOn = base.GlobalSettings.Bloom;
				ambientOcclusionToggle.isOn = base.GlobalSettings.AmbientOcclusion;
				sunBeamsToggle.isOn = base.GlobalSettings.SunBeams;
				environmentParticlesToggle.isOn = base.GlobalSettings.EnvironmentParticles;
				birdsEffectToggle.isOn = base.GlobalSettings.BirdsEffect;
				grassEffectToggle.isOn = !base.GlobalSettings.GrassHidden;
				environmentParticlesFootprintsToggle.isOn = base.GlobalSettings.EnvironmentFootprintsParticles;
			});
		}

		private void SetVSyncOption(int value)
		{
			MonoSingleton<OptionsController>.Instance.SetVSync(value);
			fpsCapDropdownGO.SetActive(base.GlobalSettings.VSync == 0);
		}

		private void SetupVSyncOptions()
		{
			vsyncDropdown.ClearOptions();
			vsyncDropdown.AddOptions(new List<string>
			{
				base.Localize.GetText("general_off"),
				base.Localize.GetText("options_vSync_everyBlock"),
				base.Localize.GetText("options_vSync_everySecondBlock")
			});
			vsyncDropdown.SetValueWithoutNotify(base.GlobalSettings.VSync);
		}

		private void SetupFPSCapOptions()
		{
			fpsCapDropdown.ClearOptions();
			fpsCapDropdown.AddOptions(new List<string>
			{
				base.Localize.GetText("general_off"),
				"30",
				"60"
			});
			fpsCapDropdown.SetValueWithoutNotify(base.GlobalSettings.FPSCap);
			fpsCapDropdownGO.SetActive(base.GlobalSettings.VSync == 0);
		}

		private void SetupResolutionOptions()
		{
			Vector2Int defaultResolution = base.GlobalSettings.DefaultResolution;
			if (resolutionDropdown != null && resolutionDropdown.options.Count != 0)
			{
				return;
			}
			int num = 0;
			List<string> list = new List<string>();
			int num2 = 0;
			for (int num3 = Screen.resolutions.Length - 1; num3 >= 0; num3--)
			{
				Resolution value = Screen.resolutions[num3];
				if (value.width >= 1024)
				{
					list.Add($"{value.width}x{value.height} @{value.refreshRate}Hz");
					wantedResolutions.Add(num2, value);
					if (value.width == defaultResolution.x && value.height == defaultResolution.y && value.refreshRate == base.GlobalSettings.RefreshRate)
					{
						num = num2;
					}
					num2++;
				}
			}
			savedResolutionIndex = num;
			resolutionDropdown.AddOptions(list);
			resolutionDropdown.SetValueWithoutNotify(savedResolutionIndex);
			resolutionDropdown.onValueChanged.AddListener(delegate(int key)
			{
				MonoSingleton<OptionsController>.Instance.SetResolution(wantedResolutions[key]);
				screenSettingsFailsafePanel.ShowResolution(delegate
				{
					MonoSingleton<OptionsController>.Instance.KeepResolutionSettings();
					savedResolutionIndex = key;
				}, delegate
				{
					MonoSingleton<OptionsController>.Instance.RevertResolutionSettings();
					resolutionDropdown.SetValueWithoutNotify(savedResolutionIndex);
				});
			});
		}

		private void SetupTextureQualityOptions()
		{
			textureQualityDropdown.ClearOptions();
			textureQualityDropdown.AddOptions(new List<string>
			{
				base.Localize.GetText("general_full"),
				base.Localize.GetText("general_half")
			});
			textureQualityDropdown.SetValueWithoutNotify(base.GlobalSettings.TextureQuality);
		}

		private void SetupShadowQualityOptions()
		{
			shadowQualityDropdown.ClearOptions();
			shadowQualityDropdown.AddOptions(new List<string>
			{
				base.Localize.GetText("general_low"),
				base.Localize.GetText("general_medium"),
				base.Localize.GetText("general_high"),
				base.Localize.GetText("general_veryHigh"),
				base.Localize.GetText("general_off")
			});
			shadowQualityDropdown.SetValueWithoutNotify(base.GlobalSettings.ShadowQuality);
		}

		private void SetupAntiAliasingOptions()
		{
			antiAliasingDropdown.ClearOptions();
			antiAliasingDropdown.AddOptions(new List<string>
			{
				base.Localize.GetText("general_off"),
				base.Localize.GetText("options_aa_FXAA"),
				base.Localize.GetText("options_aa_SMAA_low"),
				base.Localize.GetText("options_aa_SMAA_medium"),
				base.Localize.GetText("options_aa_SMAA_high")
			});
			antiAliasingDropdown.SetValueWithoutNotify(base.GlobalSettings.AntiAliasing);
		}
	}
}
