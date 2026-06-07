using System;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class MapQualitySettings : SettingsCategory<MapQualitySettings>
	{
		public NumericSetting<float> MapLineResolution { get; private set; }

		public BoolSetting PlanetVertexDisplacement { get; private set; }

		public MapQualitySettings()
			: base("Map")
		{
			RegisterPresetList(SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
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
					MapLineResolution.Value = (flag ? 0.5f : 1f);
					PlanetVertexDisplacement.Value = true;
					break;
				case SettingsCategoryPreset.Medium:
					MapLineResolution.Value = (flag ? 0.25f : 0.5f);
					PlanetVertexDisplacement.Value = true;
					break;
				default:
					MapLineResolution.Value = (flag ? 0.15f : 0.15f);
					PlanetVertexDisplacement.Value = true;
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			MapLineResolution = CreateNumeric("Orbit Line Resolution", 0.05f, 1f, 0.05f).SetDescription("Adjust the resolution of orbit lines in map-view.  This has a significant impact on performance in map view when many orbit lines are being shown.").SetDisplayFormatter((float x) => $"{(int)System.Math.Round(x * 100f, 0)}%").SetDefault(100f);
			PlanetVertexDisplacement = CreateBool("Planet Vertex Displacement").SetDescription("Toggles vertex displacement for map view planets. When disabled, map view planets are perfect spheres. When enabled, the shape of map view planets resembles the actual planet shape at the cost of some performance impact.").SetState(SettingState.Hidden).SetDefault(value: true);
		}
	}
}
