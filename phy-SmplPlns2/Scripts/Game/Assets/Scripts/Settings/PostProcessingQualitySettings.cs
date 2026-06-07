using Jundroo.Common.Platform;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class PostProcessingQualitySettings : SettingsCategory<PostProcessingQualitySettings>
	{
		public BoolSetting AmbientOcclusion { get; private set; }

		public NumericSetting<float> AmbientOcclusionIntensity { get; private set; }

		public NumericSetting<float> BloomIntensity { get; private set; }

		public NumericSetting<float> Brightness { get; private set; }

		public NumericSetting<float> Contrast { get; private set; }

		public override int Order => 1000;

		public NumericSetting<float> Saturation { get; private set; }

		public PostProcessingQualitySettings()
			: base("Post Processing")
		{
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				break;
			case SettingsCategoryPreset.Medium:
			case SettingsCategoryPreset.High:
			case SettingsCategoryPreset.VeryHigh:
				AmbientOcclusion.Value = true;
				break;
			default:
				AmbientOcclusion.Value = false;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			AmbientOcclusion = CreateBool("Ambient Occlusion").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Determines whether ambient occlusion (AO) is enabled. This effect darkens areas where surfaces are close together, like creases, holes, and intersections, to simulate how ambient light is blocked or occluded, making the scene appear more realistic. Disabling ambient occlusion can improve performance in GPU limited situations.").SetDefault(value: true);
			AmbientOcclusionIntensity = CreateNumeric("Ambient Occlusion Intensity", -100f, 100f, 1f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (x != 0f) ? ((!(x > 0f)) ? $"{x:F0}%" : $"+{x:F0}%") : "Default").SetDescription("Adjusts the strength of the ambient occlusion (AO) effect. This effect darkens areas where surfaces are close together, like creases, holes, and intersections, to simulate how ambient light is blocked or occluded, making the scene appear more realistic.")
				.SetDefault(0f);
			Brightness = CreateNumeric("Brightness", -100f, 100f, 1f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (x != 0f) ? ((!(x > 0f)) ? $"{x:F0}%" : $"+{x:F0}%") : "Default").SetDescription("Adjusts the brightness of the game.")
				.SetDefault(0f);
			Contrast = CreateNumeric("Contrast", -100f, 100f, 1f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (x != 0f) ? ((!(x > 0f)) ? $"{x:F0}%" : $"+{x:F0}%") : "Default").SetDescription("Adjusts the color contrast of the game.")
				.SetDefault(0f);
			Saturation = CreateNumeric("Saturation", -100f, 100f, 1f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (x != 0f) ? ((!(x > 0f)) ? $"{x:F0}%" : $"+{x:F0}%") : "Default").SetDescription("Adjusts the color saturation of the game.")
				.SetDefault(0f);
			BloomIntensity = CreateNumeric("Bloom Intensity", -100f, 100f, 1f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (x != 0f) ? ((!(x > 0f)) ? $"{x:F0}%" : $"+{x:F0}%") : "Default").SetDescription("Adjusts the strength of the bloom effect. This effect makes bright areas of the game appear to glow.")
				.SetDefault(0f);
		}
	}
}
