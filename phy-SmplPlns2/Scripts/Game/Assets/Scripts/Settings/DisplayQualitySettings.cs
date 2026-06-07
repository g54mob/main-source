using System;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Settings
{
	public class DisplayQualitySettings : SettingsCategory<DisplayQualitySettings>
	{
		public enum AntiAliasingType
		{
			[EnumOption("None", "No anti-aliasing will be used.")]
			None = 0,
			[EnumOption("MSAA x2", "MSAA 2x (Multi-Sample Anti-Aliasing) samples 2 points per pixel for high-quality edges, but with a higher performance cost.")]
			MSAA2 = 1,
			[EnumOption("MSAA 4x", "MSAA 4x (Multi-Sample Anti-Aliasing) samples 4 points per pixel for high-quality edges, but with a higher performance cost.")]
			MSAA4 = 2,
			[EnumOption("MSAA 8x", "MSAA 8x (Multi-Sample Anti-Aliasing) samples 8 points per pixel for high-quality edges, but with a higher performance cost.")]
			[EnumOption(1u, DeviceFlags.OSX, State = SettingState.Hidden)]
			MSAA8 = 3,
			[EnumOption("FXAA", "FXAA (Fast Approximate Anti-Aliasing) quickly smooths edges with a slight blur, offering high performance but lower visual quality.")]
			FXAA = 4,
			[EnumOption("SMAA", "SMAA (Subpixel Morphological Anti-Aliasing) reduces jagged edges with minimal performance impact, providing a good balance between quality and performance.")]
			SMAA = 5,
			[EnumOption("TAA", "TAA (Temporal Anti-Aliasing) blends multiple frames to reduce artifacts and provide smooth visuals, but can introduce ghosting effects.", State = SettingState.Hidden)]
			TAA = 6
		}

		public enum MobileDeviceEmulationMode
		{
			None = 0,
			Phone = 1,
			Tablet = 2
		}

		private int? _originalAntiAliasingValue;

		public EnumSetting<AntiAliasingType> AntiAliasing { get; private set; }

		public BoolSetting Fullscreen { get; private set; }

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

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			return SettingsCategoryPreset.None;
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
			VsyncCount = CreateNumeric("Refresh Rate", 0, 4, 1).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDefault(1).SetDescription(description)
				.AddWarning((int x) => x == 1 && Device.IsMobileBuild, "60Hz is generally not recommended on a mobile device as it can greatly impact battery life.")
				.SetDisplayFormatter((int x) => GetVsyncRefreshRateString(x));
			VsyncCount.UseSpinnerUI = true;
			VsyncCount.ReverseSpinnerUIValues = true;
			AntiAliasing = CreateEnum<AntiAliasingType>("Anti-Aliasing").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Anti-aliasing helps smooth pixelated edges.").SetState(DeviceFlags.Mobile, SettingState.Hidden);
			ResolutionScale = CreateNumeric("Resolution Scale", 0.25f, 2f, 0.05f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("This value scales the rendered resolution of the game while the user interface still renders at the specified resolution. " + System.Environment.NewLine + System.Environment.NewLine + "At values lower than 1, the game will be rendered at a lower resolution than the game screen and then upscaled. This is a trade-off of reduced graphical quality for performance gains. " + System.Environment.NewLine + System.Environment.NewLine + "At values higher than 1, the game will be rendered at a higher resolution than the game screen and then downscaled. This is a trade-off of increased graphical quality (particularly a reduction in aliasing) at the cost of performance.").SetDisplayFormatter((float x) => (x != 1f) ? ((x != 0.5f) ? ((x != 2f) ? $"{x * 100f:F0}%" : "Double Res") : "Half Res") : "Full Res");
			SceneManager.sceneLoaded += OnSceneLoaded;
			InitializeSettingDefaults();
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			if (!Device.IsMobileBuild)
			{
				Fullscreen.Changed += FullscreenChanged;
				Fullscreen.RaiseSettingChangedEvent();
			}
			AntiAliasing.Changed += OnAntiAliasingChanged;
			AntiAliasing.RaiseSettingChangedEvent();
			ResolutionScale.Changed += OnResolutionScaleChanged;
			ResolutionScale.RaiseSettingChangedEvent();
			VsyncCount.Changed += VSyncChanged;
			VsyncCount.RaiseSettingChangedEvent();
			Application.quitting += OnApplicationQuitting;
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

		private void InitializeSettingDefaults()
		{
			Resolution.Value = Screen.currentResolution;
			ResolutionScale.Value = 1f;
			Fullscreen.Value = true;
			VsyncCount.Value = ((!Device.IsMobileBuild) ? 1 : 2);
			DeviceFlags flags = Device.CurrentDevice.Flags;
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
			else
			{
				AntiAliasing.Value = AntiAliasingType.SMAA;
				if (flags.HasFlag(DeviceFlags.OSX) && (flags.HasFlag(DeviceFlags.LowEndGraphics) || flags.HasFlag(DeviceFlags.MidRangeGraphics)))
				{
					ResolutionScale.Value = 0.75f;
				}
			}
		}

		private void OnAntiAliasingChanged(object sender, SettingChangedEventArgs<AntiAliasingType> e)
		{
			int valueOrDefault = _originalAntiAliasingValue.GetValueOrDefault();
			if (!_originalAntiAliasingValue.HasValue)
			{
				valueOrDefault = UniversalRenderPipeline.asset.msaaSampleCount;
				_originalAntiAliasingValue = valueOrDefault;
			}
			int num = 1;
			num = e.Setting.Value switch
			{
				AntiAliasingType.MSAA2 => 2, 
				AntiAliasingType.MSAA4 => 4, 
				AntiAliasingType.MSAA8 => 8, 
				_ => 1, 
			};
			QualitySettings.antiAliasing = ((num != 1) ? num : 0);
			UniversalRenderPipeline.asset.msaaSampleCount = num;
		}

		private void OnApplicationQuitting()
		{
			if (Device.IsUnityEditor)
			{
				if (_originalAntiAliasingValue.HasValue)
				{
					UniversalRenderPipeline.asset.msaaSampleCount = _originalAntiAliasingValue.Value;
				}
				UniversalRenderPipeline.asset.renderScale = 1f;
			}
		}

		private void OnResolutionScaleChanged(object sender, SettingChangedEventArgs<float> e)
		{
			UniversalRenderPipeline.asset.renderScale = e.Setting.Value;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
		{
			if (scene.name != "Startup")
			{
				DoFullscreenCheck();
			}
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
