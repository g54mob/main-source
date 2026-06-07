using System;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace ModApi.Settings
{
	public class VisualEffectsQualitySettings : SettingsCategory<VisualEffectsQualitySettings>
	{
		public enum AnisotropicFilteringMode
		{
			[EnumOption("Disabled", "Anisotropic filtering will never be used. Textures can look blurry at steep viewing angles.")]
			Disabled = 0,
			[EnumOption("Enabled", "Anisotropic filtering will be used for some textures but not all textures. For those textures that use it, this improves the look of the textures at steep viewing angles.")]
			PerTexture = 1,
			[EnumOption("Always", "Anisotropic filtering will always be used. This improves the look of textures at steep viewing angles.")]
			ForcedOn = 2
		}

		public enum SkyboxQuality
		{
			[EnumOption("Medium", "4k skybox, a bit pixelated on low FoV or large displays but no longer with square stars.")]
			Medium = 0,
			[EnumOption("High", "For those that want to bring the FoV down or play on a large display, 8k resolution.")]
			High = 1,
			[EnumOption("Ultra", "16k resolution, for people playing on 4k displays or making telescopes.")]
			Ultra = 2
		}

		public enum AtmosphereQuality
		{
			[EnumOption("Off", "Atmosphere rendering effects are not applied.")]
			Off = 0,
			[EnumOption("Low", "Low quality atmosphere rendering effects are applied.")]
			Low = 1,
			[EnumOption("High", "High quality atmosphere rendering effects are applied.")]
			High = 2,
			[EnumOption("Ultra", "A much more subdivided mesh is used, removing tesellation on the atmosphere edge.")]
			Ultra = 3
		}

		public enum ExplosionQuality
		{
			[EnumOption("Explosions will have minimal visual effects.")]
			Low = 0,
			[EnumOption("Explosions will have most visual effects except for the most taxing.")]
			Medium = 1,
			[EnumOption("Explosions will have all visual effects, including a point light and a shockwave.")]
			High = 2
		}

		public enum HeatDistortionQuality
		{
			[EnumOption("Heat distortion will be disabled.")]
			Off = 0,
			[EnumOption("Heat distortion will be enabled.")]
			On = 1
		}

		public enum LightingQualitySettingType
		{
			[EnumOption("Low", "Low quality lighting reduces graphical load and can improve framerate on weaker GPUs.")]
			Low = 0,
			[EnumOption(0u, DeviceFlags.Desktop, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.Mobile, DisplayName = "High", Description = "High quality lighting can improve the overall look of the game but it increases graphical load and can decrease framerate on weaker GPUs.")]
			Medium = 1,
			[EnumOption(0u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.Desktop, DisplayName = "High", Description = "High quality lighting can improve the overall look of the game but it increases graphical load and can decrease framerate on weaker GPUs.")]
			High = 2
		}

		public enum MenuSunQuality
		{
			[EnumOption("The sun in the main menu will not be very fancy.")]
			Low = 0,
			[EnumOption("The sun in the main menu will be as fancy as we can make it.")]
			High = 1
		}

		public enum TireTrackQuality
		{
			[EnumOption("Tire tracks will be disabled.")]
			Off = 0,
			[EnumOption("Short tire track length.")]
			Low = 1,
			[EnumOption("Medium tire track length.")]
			Medium = 2,
			[EnumOption("Maximum tire track length.")]
			High = 3
		}

		public EnumSetting<AnisotropicFilteringMode> AnisotropicFiltering { get; private set; }

		public EnumSetting<SkyboxQuality> Skybox { get; private set; }

		public EnumSetting<AtmosphereQuality> Atmosphere { get; private set; }

		public NumericSetting<int> DesignerLightingPartThreshold { get; private set; }

		public EnumSetting<ExplosionQuality> Explosions { get; private set; }

		public EnumSetting<HeatDistortionQuality> HeatDistortion { get; private set; }

		public BoolSetting LaunchSteam { get; private set; }

		public EnumSetting<LightingQualitySettingType> Lighting { get; private set; }

		public EnumSetting<MenuSunQuality> MainMenuSun { get; private set; }

		public EnumSetting<TireTrackQuality> TireTracks { get; private set; }

		public VisualEffectsQualitySettings()
			: base("Visual Effects")
		{
			RegisterPresetList(DeviceFlags.Mobile, SettingsCategoryPreset.VeryLow, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
			RegisterPresetList(DeviceFlags.Desktop, SettingsCategoryPreset.VeryLow, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Ultra, SettingsCategoryPreset.Custom);
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			DeviceFlags flags = CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.HighEnd))
			{
				return SettingsCategoryPreset.High;
			}
			if (flags.HasFlag(DeviceFlags.MidRange))
			{
				return SettingsCategoryPreset.Medium;
			}
			return SettingsCategoryPreset.Low;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				AnisotropicFiltering.Value = AnisotropicFilteringMode.ForcedOn;
				bool flag = devices.HasFlag(DeviceFlags.Mobile);
				switch (preset)
				{
				case SettingsCategoryPreset.Ultra:
					Lighting.Value = (flag ? LightingQualitySettingType.Medium : LightingQualitySettingType.High);
					LaunchSteam.Value = true;
					Skybox.Value = SkyboxQuality.Ultra;
					Atmosphere.Value = AtmosphereQuality.Ultra;
					TireTracks.Value = TireTrackQuality.High;
					Explosions.Value = ExplosionQuality.High;
					MainMenuSun.Value = ((!flag) ? MenuSunQuality.High : MenuSunQuality.Low);
					HeatDistortion.Value = HeatDistortionQuality.On;
					DesignerLightingPartThreshold.Value = (flag ? 1000 : 3000);
					break;
				case SettingsCategoryPreset.High:
					Lighting.Value = (flag ? LightingQualitySettingType.Medium : LightingQualitySettingType.High);
					LaunchSteam.Value = true;
					Skybox.Value = ((!flag) ? SkyboxQuality.High : SkyboxQuality.Medium);
					Atmosphere.Value = AtmosphereQuality.High;
					TireTracks.Value = TireTrackQuality.High;
					Explosions.Value = ExplosionQuality.High;
					MainMenuSun.Value = ((!flag) ? MenuSunQuality.High : MenuSunQuality.Low);
					HeatDistortion.Value = HeatDistortionQuality.On;
					DesignerLightingPartThreshold.Value = (flag ? 1000 : 3000);
					break;
				default:
					Lighting.Value = ((!flag) ? LightingQualitySettingType.High : LightingQualitySettingType.Low);
					LaunchSteam.Value = true;
					Skybox.Value = SkyboxQuality.Medium;
					Atmosphere.Value = AtmosphereQuality.High;
					TireTracks.Value = TireTrackQuality.Medium;
					Explosions.Value = ExplosionQuality.Medium;
					MainMenuSun.Value = MenuSunQuality.Low;
					HeatDistortion.Value = HeatDistortionQuality.Off;
					DesignerLightingPartThreshold.Value = ((!flag) ? 2000 : 0);
					break;
				case SettingsCategoryPreset.Low:
					Lighting.Value = ((!flag) ? LightingQualitySettingType.High : LightingQualitySettingType.Low);
					LaunchSteam.Value = false;
					Skybox.Value = SkyboxQuality.Medium;
					Atmosphere.Value = AtmosphereQuality.Low;
					TireTracks.Value = TireTrackQuality.Low;
					Explosions.Value = ExplosionQuality.Low;
					MainMenuSun.Value = MenuSunQuality.Low;
					HeatDistortion.Value = HeatDistortionQuality.Off;
					DesignerLightingPartThreshold.Value = ((!flag) ? 1000 : 0);
					break;
				case SettingsCategoryPreset.VeryLow:
					Lighting.Value = LightingQualitySettingType.Low;
					LaunchSteam.Value = false;
					Skybox.Value = SkyboxQuality.Medium;
					Atmosphere.Value = AtmosphereQuality.Off;
					TireTracks.Value = TireTrackQuality.Off;
					Explosions.Value = ExplosionQuality.Low;
					MainMenuSun.Value = MenuSunQuality.Low;
					HeatDistortion.Value = HeatDistortionQuality.Off;
					DesignerLightingPartThreshold.Value = 0;
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			Lighting = CreateEnum<LightingQualitySettingType>("Lighting").SetDescription("The lighting quality changes the accuracy of how light is applied to most surfaces in the game.").SetApplyType(SettingApplyType.RequiresQuadsphereReload);
			AnisotropicFiltering = CreateEnum<AnisotropicFilteringMode>("Anisotropic Filtering").SetDescription("Anisotropic filtering improves the look of textures at steep viewing angles.").SetState(SettingState.Hidden);
			Skybox = CreateEnum<SkyboxQuality>("Skybox").SetDescription("Sets the resolution of the skybox.").SetState(DeviceFlags.Mobile, SettingState.Disabled);
			Atmosphere = CreateEnum<AtmosphereQuality>("Atmosphere").SetDescription("Sets the quality of the atmospheres rendering.");
			HeatDistortion = CreateEnum<HeatDistortionQuality>("Heat Distortion").SetDescription("Enables or disables heat distortion effects on jet engines.");
			LaunchSteam = CreateBool("Launch Steam").SetDescription("Sets whether the steam from the launch pad is rendered.");
			TireTracks = CreateEnum<TireTrackQuality>("Tire Tracks").SetApplyType(SettingApplyType.RequiresSceneRestart).SetDescription("Sets the quality of the tire tracks.");
			Explosions = CreateEnum<ExplosionQuality>("Explosions").SetDescription("Sets the visual quality of explosions.");
			MainMenuSun = CreateEnum<MenuSunQuality>("Main Menu Sun").SetDescription("Sets the visual quality of the sun in the main menu.").SetState(DeviceFlags.Mobile, SettingState.Disabled).SetDefault(MenuSunQuality.Low);
			DesignerLightingPartThreshold = CreateNumeric("Designer Light Quality Part Threshold", 0, 3250, 250).SetDescription("If the part count in the designer exceeds this threshold, the secondary directional light (pointing upwards from the bottom) will reduce its lighting quality in order to boost framerate.").SetDisplayFormatter((int x) => (x != DesignerLightingPartThreshold.Max) ? x.ToString() : "No Limit");
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			AnisotropicFiltering.Changed += AnisotropicFilteringChanged;
			AnisotropicFiltering.RaiseSettingChangedEvent();
			Lighting.Changed += LightingQualityChanged;
			Lighting.RaiseSettingChangedEvent();
		}

		private void AnisotropicFilteringChanged(object sender, SettingChangedEventArgs<AnisotropicFilteringMode> e)
		{
			switch (e.Setting.Value)
			{
			case AnisotropicFilteringMode.Disabled:
				QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.Disable;
				break;
			case AnisotropicFilteringMode.PerTexture:
				QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.Enable;
				break;
			case AnisotropicFilteringMode.ForcedOn:
				QualitySettings.anisotropicFiltering = UnityEngine.AnisotropicFiltering.ForceEnable;
				break;
			default:
				Debug.LogError($"Anisotropic filtering setting '{e.Setting.Value}' is not supported.");
				break;
			}
		}

		private void LightingQualityChanged(object sender, SettingChangedEventArgs<LightingQualitySettingType> e)
		{
			switch (e.Setting.Value)
			{
			case LightingQualitySettingType.Low:
				Shader.EnableKeyword("SR_LIGHTING_LOW");
				Shader.DisableKeyword("SR_LIGHTING_MEDIUM");
				Shader.DisableKeyword("SR_LIGHTING_HIGH");
				break;
			case LightingQualitySettingType.Medium:
				Shader.DisableKeyword("SR_LIGHTING_LOW");
				Shader.EnableKeyword("SR_LIGHTING_MEDIUM");
				Shader.DisableKeyword("SR_LIGHTING_HIGH");
				break;
			case LightingQualitySettingType.High:
				Shader.DisableKeyword("SR_LIGHTING_LOW");
				Shader.DisableKeyword("SR_LIGHTING_MEDIUM");
				Shader.EnableKeyword("SR_LIGHTING_HIGH");
				break;
			default:
				throw new NotSupportedException($"Lighting quality '{e.Setting.Value}' is not supported");
			}
		}
	}
}
