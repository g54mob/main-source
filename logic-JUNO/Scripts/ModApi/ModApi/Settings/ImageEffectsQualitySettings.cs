using ModApi.Settings.Core;
using UnityEngine;

namespace ModApi.Settings
{
	public class ImageEffectsQualitySettings : SettingsCategory<ImageEffectsQualitySettings>
	{
		public enum ReEntryQuality
		{
			[EnumOption("Re-entry and vapor trail effects will be disabled.")]
			Off = 0,
			[EnumOption("Re-entry and vapor trail effects will be enabled.")]
			On = 1
		}

		public enum ToneMap
		{
			[EnumOption("None", "The default tonemapping.")]
			None = 0,
			[EnumOption("Old Video", "Oversaturated, bright and contrasty, like a good'ol TV.")]
			OldVideo = 1,
			[EnumOption("Old Photo", "A sepia tone similar to that of a really old photo.")]
			OldPhoto = 2,
			[EnumOption("Old Camera", "Dark green and blue, you feel old just looking at it.")]
			OldCamera = 3,
			[EnumOption("Faded", "All colors washed out, sad as a rainy day.")]
			Faded = 4,
			[EnumOption("Dream", "Faded pink to make you feel like in a dreampop videoclip.")]
			Dream = 5,
			[EnumOption("Western", "Prepare a daisy hoss and your bettermost poke hat.")]
			Western = 6,
			[EnumOption("Fantasy", "Vibid and warm, ready to slay some dragons.")]
			Fantasy = 7,
			[EnumOption("Dystopian", "Dark and sinister, solitude made color.")]
			Dystopian = 8,
			[EnumOption("Gray Scale", "In case you are too lazy to just lower your saturation.")]
			Gray = 9,
			[EnumOption("Just Red", "Grayscale but with a touch of color.")]
			Red = 10,
			[EnumOption("Just Green", "Grayscale but with a touch of color.")]
			Green = 11,
			[EnumOption("Just Blue", "Grayscale but with a touch of color.")]
			Blue = 12,
			[EnumOption("Cartoon", "Vibrant colors and blue grass, Namek here we go!")]
			Cartoon = 13,
			[EnumOption("Retro", "Similar to the early consoles, using a limited color range.")]
			Retro = 14,
			[EnumOption("Alien", "Hard on the eye, barely usable, but quite fun.")]
			Alien = 15
		}

		public NumericSetting<float> AmbientOcclusion { get; private set; }

		public NumericSetting<float> BloomIntensity { get; private set; }

		public NumericSetting<float> Contrast { get; private set; }

		public BoolSetting Enabled { get; private set; }

		public BoolSetting HdrEnabled { get; private set; }

		public EnumSetting<ReEntryQuality> ReEntry { get; private set; }

		public EnumSetting<ToneMap> Tonemapping { get; private set; }

		public NumericSetting<float> Saturation { get; private set; }

		public NumericSetting<float> Sharpness { get; private set; }

		public NumericSetting<float> SunFlareIntensity { get; private set; }

		public NumericSetting<float> AnamorphicFlareIntensity { get; private set; }

		public bool SupportsHdr { get; }

		public ImageEffectsQualitySettings()
			: base("Image Effects")
		{
			RegisterPresetList(SettingsCategoryPreset.Off, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
			SupportsHdr = true;
			if (Device.IsAndroidBuild)
			{
				SupportsHdr = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
			}
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			DeviceFlags flags = CurrentDevice.Flags;
			bool flag = flags.HasFlag(DeviceFlags.Mobile);
			if (flags.HasFlag(DeviceFlags.HighEnd))
			{
				if (!flag)
				{
					return SettingsCategoryPreset.High;
				}
				return SettingsCategoryPreset.Medium;
			}
			if (flags.HasFlag(DeviceFlags.MidRange))
			{
				if (!flag)
				{
					return SettingsCategoryPreset.Medium;
				}
				return SettingsCategoryPreset.Off;
			}
			return SettingsCategoryPreset.Off;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			Contrast.Value = 1f;
			Sharpness.Value = 0f;
			Saturation.Value = 0f;
			Tonemapping.Value = ToneMap.None;
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				return;
			case SettingsCategoryPreset.High:
				Enabled.Value = true;
				SunFlareIntensity.Value = 1f;
				AnamorphicFlareIntensity.Value = 1f;
				ReEntry.Value = ReEntryQuality.On;
				HdrEnabled.Value = true;
				AmbientOcclusion.Value = (Device.IsMobileBuild ? 0f : 1f);
				break;
			default:
				Enabled.Value = true;
				SunFlareIntensity.Value = 1f;
				AnamorphicFlareIntensity.Value = 0f;
				ReEntry.Value = ReEntryQuality.Off;
				HdrEnabled.Value = !Device.IsMobileBuild;
				AmbientOcclusion.Value = 0f;
				break;
			case SettingsCategoryPreset.Low:
				Enabled.Value = true;
				SunFlareIntensity.Value = 0f;
				AnamorphicFlareIntensity.Value = 0f;
				ReEntry.Value = ReEntryQuality.Off;
				HdrEnabled.Value = !Device.IsMobileBuild;
				AmbientOcclusion.Value = 0f;
				break;
			case SettingsCategoryPreset.Off:
				Enabled.Value = false;
				BloomIntensity.Value = 0f;
				SunFlareIntensity.Value = 0f;
				AnamorphicFlareIntensity.Value = 0f;
				ReEntry.Value = ReEntryQuality.Off;
				HdrEnabled.Value = false;
				AmbientOcclusion.Value = 0f;
				break;
			}
			BloomIntensity.Value = (HdrEnabled.Value ? 1f : 0f);
			if (!SupportsHdr)
			{
				HdrEnabled.Value = false;
				BloomIntensity.Value = 0f;
				ReEntry.Value = ReEntryQuality.Off;
			}
		}

		protected override void InitializeSettings()
		{
			Enabled = CreateBool("Enabled").SetDescription("Toggles image effects on/off.");
			SunFlareIntensity = CreateNumeric("Sun Flare Intensity", 0f, 1.5f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the intensity of the sun flare. Zero percent is off.");
			AnamorphicFlareIntensity = CreateNumeric("Anamorphic Flare Intensity", 0f, 1.5f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the intensity of the anamorphic flares. Zero percent is off.");
			HdrEnabled = CreateBool("High Dynamic Range").SetDescription("Toggles HDR on/off. HDR can have a significant impact on memory usage and performance.").SetApplyType(SettingApplyType.RequiresSceneRestart).SetState((!SupportsHdr) ? SettingState.Disabled : SettingState.Enabled);
			BloomIntensity = CreateNumeric("Bloom Intensity", 0f, 1.5f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the intensity of bloom. Zero percent is off.").SetState((!SupportsHdr) ? SettingState.Disabled : SettingState.Enabled);
			Tonemapping = CreateEnum<ToneMap>("Tonemapping", "tonemapping").SetDescription("Applies a LUT to remap the colors.");
			Contrast = CreateNumeric("Contrast", 0.5f, 1.5f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the contrast image setting.");
			Saturation = CreateNumeric("Saturation", -1f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the saturation image setting.");
			Sharpness = CreateNumeric("Sharpness", 0f, 1f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Changes the sharpness image setting.");
			ReEntry = CreateEnum<ReEntryQuality>("Re-Entry / Vapor Trails", "reEntry-VaporTrails").SetDescription("Toggles re-entry and vapor trail effects.").SetState((!SupportsHdr) ? SettingState.Disabled : SettingState.Enabled);
			AmbientOcclusion = CreateNumeric("Ambient Occlusion", 0f, 2f, 0.01f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Intensity of ambient occlusion, which renders soft shadows in complex geometry and makes the scene look more realistic.").SetApplyType(SettingApplyType.Immediate);
		}
	}
}
