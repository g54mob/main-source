using ModApi.Settings.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace ModApi.Settings
{
	public class CraftQualitySettings : SettingsCategory<CraftQualitySettings>
	{
		public enum CraftReflectionsQuality
		{
			[EnumOption("None", "Craft parts will not reflect anything in their surface.", DisplayOrder = 0)]
			None = 0,
			[EnumOption("Static", "Reflective craft parts will use a vague static image to give the illusion of the parts reflecting their surroundings without actually doing so.", DisplayOrder = 1)]
			Static = 1,
			[EnumOption("Realtime", "Reflective craft parts will reflect the surrounding world in realtime. Enabling this option can result in extreme performance impacts.", State = SettingState.Hidden, DisplayOrder = 2)]
			[EnumOption(1u, DeviceFlags.Desktop, State = SettingState.Enabled, DisplayName = "Realtime")]
			Realtime = 2
		}

		public enum DetailTextureQuality
		{
			[EnumOption("Detail textures will not be used for craft parts.")]
			Disabled = 0,
			[EnumOption("Low resolution textures will be used for the detail texturing on craft parts.")]
			Low = 1,
			[EnumOption("Medium resolution textures will be used for the detail texturing on craft parts.")]
			Medium = 2,
			[EnumOption("High resolution textures will be used for the detail texturing on craft parts.")]
			[EnumOption(1u, DeviceFlags.LowRam, State = SettingState.Hidden)]
			High = 3
		}

		public enum MaxCraftLights
		{
			[EnumOption(DisplayName = "0")]
			Zero = 0,
			[EnumOption(DisplayName = "1")]
			One = 1,
			[EnumOption(DisplayName = "2")]
			Two = 2,
			[EnumOption(DisplayName = "4")]
			Four = 4,
			[EnumOption(DisplayName = "6")]
			Six = 6,
			[EnumOption(DisplayName = "8")]
			Eight = 8,
			[EnumOption(DisplayName = "16")]
			Sixteen = 16,
			[EnumOption(DisplayName = "Unlimited")]
			Unlimited = int.MaxValue
		}

		public enum NormalMapQuality
		{
			[EnumOption("Normal maps will not be used for craft parts.")]
			Disabled = 0,
			[EnumOption("Low resolution textures will be used for the normal maps on craft parts.")]
			Low = 1,
			[EnumOption("Medium resolution textures will be used for the normal maps on craft parts.")]
			Medium = 2,
			[EnumOption("High resolution textures will be used for the normal maps on craft parts.")]
			[EnumOption(1u, DeviceFlags.LowRam, State = SettingState.Hidden)]
			High = 3
		}

		public EnumSetting<MaxCraftLights> CraftLightsLimit { get; private set; }

		public EnumSetting<DetailTextureQuality> DetailTextures { get; private set; }

		public EnumSetting<NormalMapQuality> NormalMaps { get; private set; }

		public EnumSetting<CraftReflectionsQuality> Reflections { get; private set; }

		public CraftQualitySettings()
			: base("Craft")
		{
			RegisterPresetList(SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
		}

		public void ConfigurePartRenderer(Renderer renderer)
		{
			renderer.reflectionProbeUsage = (((CraftReflectionsQuality)Reflections != CraftReflectionsQuality.None) ? ReflectionProbeUsage.Simple : ReflectionProbeUsage.Off);
			renderer.lightProbeUsage = LightProbeUsage.Off;
			renderer.allowOcclusionWhenDynamic = false;
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
			if (preset == SettingsCategoryPreset.Custom)
			{
				return;
			}
			bool flag = devices.HasFlag(DeviceFlags.Mobile);
			bool flag2 = devices.HasFlag(DeviceFlags.LowRam);
			switch (preset)
			{
			case SettingsCategoryPreset.High:
				NormalMaps.Value = (flag2 ? NormalMapQuality.Medium : NormalMapQuality.High);
				DetailTextures.Value = (flag2 ? DetailTextureQuality.Medium : DetailTextureQuality.High);
				CraftLightsLimit.Value = MaxCraftLights.Unlimited;
				if (devices.HasFlag(DeviceFlags.Windows) && devices.HasFlag(DeviceFlags.HighEnd))
				{
					Reflections.Value = CraftReflectionsQuality.Realtime;
				}
				else
				{
					Reflections.Value = CraftReflectionsQuality.Static;
				}
				break;
			case SettingsCategoryPreset.Medium:
				NormalMaps.Value = (flag ? NormalMapQuality.Medium : NormalMapQuality.High);
				DetailTextures.Value = (flag ? DetailTextureQuality.Medium : DetailTextureQuality.High);
				CraftLightsLimit.Value = MaxCraftLights.Six;
				Reflections.Value = CraftReflectionsQuality.Static;
				break;
			default:
				NormalMaps.Value = NormalMapQuality.Disabled;
				DetailTextures.Value = DetailTextureQuality.Disabled;
				CraftLightsLimit.Value = MaxCraftLights.Zero;
				Reflections.Value = CraftReflectionsQuality.None;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			Reflections = CreateEnum<CraftReflectionsQuality>("Reflections").SetDescription("This setting changes the way reflections are handled on the craft surfaces.");
			DetailTextures = CreateEnum<DetailTextureQuality>("Detail Textures").SetDescription("This setting adjusts the quality of the craft detail textures. These textures apply designs on craft parts via lightening or darkening their base color.");
			NormalMaps = CreateEnum<NormalMapQuality>("Normal Maps").SetDescription("This setting adjusts the quality of the craft normal maps. Normal maps affect lighting and make the parts appear more detailed.");
			CraftLightsLimit = CreateEnum<MaxCraftLights>("Max Craft Lights").SetDescription("The maximum number of active lights on a craft at any given time. The most recently activated lights are given priority when the limit has been exceeded.");
		}
	}
}
