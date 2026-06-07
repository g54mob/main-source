using ModApi.Settings.Core;
using UnityEngine;

namespace ModApi.Settings
{
	public class WaterQualitySettings : SettingsCategory<WaterQualitySettings>
	{
		public enum NormalMapQuality
		{
			[EnumOption("Low", "Very basic normal mapping will be used for the water's surface.", DisplayOrder = 0)]
			Basic = 0,
			[EnumOption("Medium", "Distance blending will be used for the water's normal maps. This is the same approach as the high quality option except it can result in some visual artifacts on the water's surface. ", DisplayOrder = 1)]
			BlendedFast = 1,
			[EnumOption("High", "High quality distance blending will be used for the water's normal maps. This provides the best surface detail for the water.", DisplayOrder = 2)]
			Blended = 2
		}

		public enum ReflectionQuality
		{
			[EnumOption("None", "The water will not reflect anything.", DisplayOrder = 0)]
			None = 0,
			[EnumOption("Craft Only", "The water will only reflect the craft and particle effects.", DisplayOrder = 1)]
			CraftOnly = 1,
			[EnumOption("Craft and Terrain", "The water will reflect the craft, particle effects, and the surrounding terrain. This can result in a significant performance impact.", DisplayOrder = 2)]
			CraftAndTerrain = 2
		}

		public EnumSetting<NormalMapQuality> NormalMaps { get; private set; }

		public EnumSetting<ReflectionQuality> Reflections { get; private set; }

		public bool SupportsTessellation { get; }

		public BoolSetting Transparency { get; private set; }

		public BoolSetting UnderwaterBlur { get; private set; }

		public BoolSetting UnderwaterDistortion { get; private set; }

		public BoolSetting UnderwaterExitEffect { get; private set; }

		public BoolSetting Waves { get; private set; }

		public WaterQualitySettings()
			: base("Water")
		{
			RegisterPresetList(SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
			SupportsTessellation = !Device.IsIosBuild && SystemInfo.supportsTessellationShaders;
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
				return SettingsCategoryPreset.Medium;
			}
			return SettingsCategoryPreset.Low;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				bool flag = devices.HasFlag(DeviceFlags.Mobile);
				switch (preset)
				{
				case SettingsCategoryPreset.High:
					Waves.Value = !Device.IsIosBuild;
					Transparency.Value = true;
					UnderwaterBlur.Value = true;
					UnderwaterDistortion.Value = true;
					UnderwaterExitEffect.Value = true;
					NormalMaps.Value = NormalMapQuality.Blended;
					Reflections.Value = ReflectionQuality.CraftAndTerrain;
					break;
				case SettingsCategoryPreset.Medium:
					Waves.Value = !Device.IsIosBuild && !flag;
					Transparency.Value = !flag;
					UnderwaterBlur.Value = !flag;
					UnderwaterDistortion.Value = !flag;
					UnderwaterExitEffect.Value = !flag;
					NormalMaps.Value = (flag ? NormalMapQuality.BlendedFast : NormalMapQuality.Blended);
					Reflections.Value = ReflectionQuality.CraftOnly;
					break;
				default:
					Waves.Value = Device.IsIosBuild && false;
					Transparency.Value = false;
					UnderwaterBlur.Value = false;
					UnderwaterDistortion.Value = false;
					UnderwaterExitEffect.Value = false;
					NormalMaps.Value = NormalMapQuality.Basic;
					Reflections.Value = ReflectionQuality.None;
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			Waves = CreateBool("Waves").SetDescription("If enabled, the water have visible waves with physics.").SetState((!SupportsTessellation) ? SettingState.Disabled : SettingState.Enabled);
			Transparency = CreateBool("Transparency").SetDescription("If enabled, the water will be semi-transparent with refraction and have better shorelines.");
			UnderwaterBlur = CreateBool("Underwater Blur").SetDescription("If enabled, the camera image will be blurred when underwater. Note: Image Effects must be enabled for this to work.");
			UnderwaterDistortion = CreateBool("Underwater Distortion").SetDescription("If enabled, the camera image will warp and distort when underwater. Note: Image Effects must be enabled for this to work.");
			UnderwaterExitEffect = CreateBool("Underwater Exit Effect").SetDescription("If enabled, the camera image will have a brief water exit effect when the camera emerges from the water. Note: Image Effects must be enabled for this to work.");
			NormalMaps = CreateEnum<NormalMapQuality>("Texture Quality").SetDescription("This controls the quality of the texturing (normal maps) for the water's surface.");
			Reflections = CreateEnum<ReflectionQuality>("Reflections").SetDescription("This setting controls what (if anything) is reflected on the waters surface.");
		}
	}
}
