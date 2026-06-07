using Jundroo.Common.Platform;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class WaterQualitySettings : SettingsCategory<WaterQualitySettings>
	{
		public enum FoamSimRate
		{
			[EnumOption("Off", "Water will not simulate foam.")]
			Off = 0,
			[EnumOption("Low", "Water will simulate foam at a lower frequency.")]
			Low = 1,
			[EnumOption("Medium", "Water will simulate foam at a moderate frequency.")]
			Medium = 2,
			[EnumOption("High", "Water will simulate foam at a higher frequency.")]
			High = 3
		}

		public enum WaterQualityLevel
		{
			[EnumOption("Low", "Similar to medium quality without a few effects such as river flows, dynamic waves, and caustics")]
			Low = 0,
			[EnumOption("Medium", "Water will be rendered with all its various visual and physical effects fully enabled.")]
			Medium = 1,
			[EnumOption("High", "Water will be rendered with all its various visual and physical effects fully enabled with increased detail at further distances.")]
			High = 2
		}

		public EnumSetting<FoamSimRate> FoamSimulationRate { get; private set; }

		public BoolSetting RiversAndWaves { get; private set; }

		public BoolSetting ShoreWaves { get; private set; }

		public EnumSetting<WaterQualityLevel> WaterQuality { get; private set; }

		public BoolSetting WaterReflections { get; private set; }

		public WaterQualitySettings()
			: base("Water")
		{
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				return;
			case SettingsCategoryPreset.High:
			case SettingsCategoryPreset.VeryHigh:
				WaterQuality.Value = WaterQualityLevel.High;
				RiversAndWaves.Value = true;
				ShoreWaves.Value = true;
				FoamSimulationRate.Value = FoamSimRate.High;
				break;
			case SettingsCategoryPreset.Medium:
				WaterQuality.Value = WaterQualityLevel.Medium;
				RiversAndWaves.Value = true;
				ShoreWaves.Value = true;
				FoamSimulationRate.Value = FoamSimRate.Medium;
				break;
			case SettingsCategoryPreset.Low:
				WaterQuality.Value = WaterQualityLevel.Low;
				RiversAndWaves.Value = true;
				ShoreWaves.Value = true;
				FoamSimulationRate.Value = FoamSimRate.Off;
				break;
			default:
				WaterQuality.Value = WaterQualityLevel.Low;
				RiversAndWaves.Value = false;
				ShoreWaves.Value = false;
				FoamSimulationRate.Value = FoamSimRate.Off;
				break;
			}
			WaterReflections.Value = false;
		}

		protected override void InitializeSettings()
		{
			WaterQuality = CreateEnum<WaterQualityLevel>("Water Quality").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Adjusts the quality of the water. This can impact visual effects as well as some physics effects.").SetDefault(WaterQualityLevel.High);
			RiversAndWaves = CreateBool("Rivers and Waves").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Disabling this will turn off all rivers and waves. Leaving it enabled is recommended. Consider disabling it for devices below minimum requirements that need to squeeze some extra performance out of the game.").SetDefault(value: true);
			ShoreWaves = CreateBool("Shore Waves").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Toggles the waves along the shorelines. This has minimal impact on performance but some players may prefer less turbulent shorelines, either for physics-related or perhaps just visual reasons.").SetDefault(value: true);
			FoamSimulationRate = CreateEnum<FoamSimRate>("Foam Simulation Rate").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Defines the frequency of the foam simulation on the water surface.").SetDefault(FoamSimRate.Medium);
			WaterReflections = CreateBool("Water Reflections").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Enable real-time reflections in the surface of the water.").SetDefault(value: false)
				.SetState(SettingState.Hidden);
		}
	}
}
