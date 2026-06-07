using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModApi.Settings
{
	public class DisplayQualitySettings : SettingsCategory<DisplayQualitySettings>
	{
		public enum AntiAliasingType
		{
			[EnumOption("None", "No anti-aliasing will be used.")]
			None = 0,
			[EnumOption("MSAA x2", "2x Multi-sample anti-aliasing will be used.")]
			[EnumOption(1u, DeviceFlags.OSX, State = SettingState.Hidden)]
			MSAA2 = 1,
			[EnumOption("MSAA x4", "4x Multi-sample anti-aliasing will be used.")]
			[EnumOption(1u, DeviceFlags.OSX, State = SettingState.Hidden)]
			MSAA4 = 2,
			[EnumOption("MSAA x8", "8x Multi-sample anti-aliasing will be used.")]
			[EnumOption(1u, DeviceFlags.OSX, State = SettingState.Hidden)]
			MSAA8 = 3,
			[EnumOption("FXAA", "Fast approximate anti-aliasing will be used.")]
			FXAA1 = 4,
			[EnumOption("FXAA 2", "", State = SettingState.Hidden)]
			FXAA2 = 5,
			[EnumOption("FXAA 3", "", State = SettingState.Hidden)]
			FXAA3 = 6,
			[EnumOption("DLAA", "", State = SettingState.Hidden)]
			DLAA = 7
		}

		public enum MobileDeviceEmulationMode
		{
			None = 0,
			Phone = 1,
			Tablet = 2
		}

		public EnumSetting<AntiAliasingType> AntiAliasing { get; private set; }

		public BoolSetting Fullscreen { get; private set; }

		public EnumSetting<MobileDeviceEmulationMode> MobileEmulation { get; private set; }

		public NumericSetting<float> MobileResolutionScale { get; private set; }

		public override int Order => -1000;

		public ResolutionSetting Resolution { get; private set; }

		public NumericSetting<float> ResolutionScale { get; private set; }

		public NumericSetting<int> VsyncCount { get; private set; }

		public DisplayQualitySettings()
			: base("Display")
		{
		}

		public void DoFullscreenCheck()
		{
			if (!Device.IsMobileBuild && Screen.fullScreen != Fullscreen.Value && !Fullscreen.PendingChange)
			{
				Fullscreen.Value = Screen.fullScreen;
				Fullscreen.CommitChanges();
			}
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			Resolution.Value = Screen.currentResolution;
			ResolutionScale.Value = 1f;
			Fullscreen.Value = true;
			VsyncCount.Value = ((!Device.IsMobileBuild) ? 1 : 2);
			DeviceFlags flags = CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.Mobile))
			{
				AntiAliasing.Value = AntiAliasingType.None;
				if (flags.HasFlag(DeviceFlags.LowEndGraphics) || (Device.IsAndroidBuild && flags.HasFlag(DeviceFlags.MidRangeGraphics)))
				{
					MobileResolutionScale.Value = 0.75f;
				}
				else
				{
					MobileResolutionScale.Value = 1f;
				}
			}
			else if (flags.HasFlag(DeviceFlags.OSX))
			{
				AntiAliasing.Value = AntiAliasingType.FXAA1;
			}
			else if (flags.HasFlag(DeviceFlags.HighEndGraphics))
			{
				AntiAliasing.Value = AntiAliasingType.MSAA8;
			}
			else if (flags.HasFlag(DeviceFlags.MidRangeGraphics))
			{
				AntiAliasing.Value = AntiAliasingType.MSAA4;
			}
			else
			{
				AntiAliasing.Value = AntiAliasingType.MSAA2;
			}
		}

		protected override void InitializeSettings()
		{
			Resolution = ResolutionSetting.Create("Resolution", this).SetDescription("The resolution at which the game is rendered.").SetState(DeviceFlags.Mobile, SettingState.Hidden);
			Fullscreen = CreateBool("Fullscreen").SetDescription("Toggles the option of rendering the game in fullscreen mode or windowed mode.").SetState(DeviceFlags.Mobile, SettingState.Hidden);
			MobileResolutionScale = CreateNumeric("Resolution", 0.25f, 1f, 0.05f, "mobileResolutionScale").SetDescription("Reducing the resolution can improve performance and battery life, but at the cost of reduced visual quality.").SetDisplayFormatter((float x) => $"{x * 100f:F0}%").SetState((!Device.IsMobileBuild) ? SettingState.Disabled : SettingState.Enabled);
			string description = "Uses V-Sync to lock the game's framerate to the monitors refresh rate to prevent screen tearing. Also improves battery life and reduces overheating on laptops and mobile devices.";
			if (Device.IsMobileBuild)
			{
				description = "Limits the maximum refresh rate of the game to improve battery life and reduce overheating.";
			}
			VsyncCount = CreateNumeric("Refresh Rate", 0, 4, 1).SetDefault(1).SetDescription(description).AddWarning((int x) => x == 1 && Device.IsMobileBuild, "60Hz is generally not recommended on a mobile device as it can greatly impact battery life.")
				.SetDisplayFormatter((int x) => GetVsyncRefreshRateString(x));
			VsyncCount.UseSpinnerUI = true;
			VsyncCount.ReverseSpinnerUIValues = true;
			AntiAliasing = CreateEnum<AntiAliasingType>("Anti-Aliasing").SetDescription("Anti-aliasing helps smooth pixelated edges.").SetState(DeviceFlags.Mobile, SettingState.Hidden);
			ResolutionScale = CreateNumeric("Resolution Scale", 0.25f, 1f, 0.05f).SetDescription("Allows the game scene to be rendered at smaller resolutions than the current resolution. This will allow the UI to stay high resolution while reducing the overall graphical resolution of the game.").SetDisplayFormatter((float x) => (x != 1f) ? ((x != 0.5f) ? $"{x * 100f:F0}%" : "Half") : "Full").SetState(SettingState.Hidden)
				.SetState(DeviceFlags.DebugBuild, SettingState.Enabled);
			MobileEmulation = CreateEnum<MobileDeviceEmulationMode>("MobileEmulation").SetDescription("Emulate the mobile device UI on a desktop. Only accessible from the Unity Editor.").SetDefault(MobileDeviceEmulationMode.None).SetApplyType(SettingApplyType.RequiresGameRestart)
				.SetState((!Device.IsDebugBuild || Device.IsMobileBuild) ? SettingState.Hidden : SettingState.Enabled);
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			if (!Device.IsMobileBuild)
			{
				Fullscreen.Changed += FullscreenChanged;
				Fullscreen.RaiseSettingChangedEvent();
			}
			VsyncCount.Changed += VSyncChanged;
			VsyncCount.RaiseSettingChangedEvent();
		}

		private static int GetMaxScreenRefreshRate()
		{
			int num = (int)Screen.currentResolution.refreshRateRatio.value;
			if (num == 59)
			{
				num = 60;
			}
			if (Device.IsMobileBuild)
			{
				num = 60;
			}
			return num;
		}

		private static string GetVsyncRefreshRateString(int vsyncCount)
		{
			if (vsyncCount > 0)
			{
				return $"{GetMaxScreenRefreshRate() / vsyncCount}Hz";
			}
			if (Device.IsMobileBuild)
			{
				return "Default";
			}
			return "Unrestricted";
		}

		private void FullscreenChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			if (e.Setting.Value != Screen.fullScreen)
			{
				Screen.fullScreen = e.Setting.Value;
			}
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
		{
			DoFullscreenCheck();
		}

		private void VSyncChanged(object sender, SettingChangedEventArgs<int> e)
		{
			int num = Mathf.Clamp(e.Setting.Value, 0, 4);
			if (Device.IsMobileBuild)
			{
				if (num > 0)
				{
					QualitySettings.vSyncCount = 0;
					Application.targetFrameRate = GetMaxScreenRefreshRate() / num;
				}
				else
				{
					QualitySettings.vSyncCount = 1;
					Application.targetFrameRate = -1;
				}
			}
			else
			{
				QualitySettings.vSyncCount = num;
				Application.targetFrameRate = -1;
			}
		}
	}
}
