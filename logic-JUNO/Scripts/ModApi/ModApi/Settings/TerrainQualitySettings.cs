using System;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace ModApi.Settings
{
	public class TerrainQualitySettings : SettingsCategory<TerrainQualitySettings>
	{
		public enum GeometryDetailQuality
		{
			[EnumOption("Use the lowest setting for the terrain's geometric detail. This helps reduce terrain load time, memory consumption, and render speed, but could be different for each planet.")]
			Low = 0,
			[EnumOption("Use the medium setting for the terrain's geometric detail.")]
			[EnumOption(1u, DeviceFlags.LowRam, State = SettingState.Disabled)]
			Medium = 1,
			[EnumOption("Use the highest setting for the terrain's geometric detail. This may greatly increase terrain load time, memory consumption, and render speed, depending on the planet.")]
			[EnumOption(1u, DeviceFlags.LowRam, State = SettingState.Disabled)]
			High = 2
		}

		public enum PlanetCubemapQuality
		{
			[EnumOption("Low", "Low resolution textures will be used for distant planets, map view planets, and the main menu planet. Normal mapping will not be used.")]
			Low = 0,
			[EnumOption("Medium", "Low resolution textures and normal maps will be used for distant planets, map view planets, and the main menu planet.")]
			Medium = 1,
			[EnumOption("High", "Low resolution textures and normal maps will be used for distant planets and map view planets. Higher resolutions textures will be used for the current planet (in flight and map view) as well as on the main menu.")]
			High = 2,
			[EnumOption("Very High", "Low resolution textures including cliffs and normal maps will be used for distant planets and map view planets. Very high resolution textures will be used for the current planet (in flight and map view), and high in the main menu.This can be incredibly slow, especially in low end devices, taking up to hours and requiring loads of ram, vram and disk space.")]
			[EnumOption(1u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			VeryHigh = 3,
			[EnumOption("Ultra", "Low resolution textures including cliffs and normal maps will be used for distant planets and map view planets. 2k resolution textures will be used for the current planet (in flight and map view), and high resolution textures in the main menu.This can be incredibly slow, especially in low end devices, taking up to hours and requiring loads of ram, vram and disk space.")]
			[EnumOption(1u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.LowEndGraphics, State = SettingState.Disabled)]
			Ultra = 4,
			[EnumOption("Ultra Pro", "Low resolution textures including cliffs and normal maps will be used for distant planets and map view planets. 4k resolution textures will be used for the current planet (in flight and map view), and high resolution textures in the main menu.This can be incredibly slow, especially in low end devices, taking up to hours and requiring loads of ram, vram and disk space.")]
			[EnumOption(1u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.LowEndGraphics, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.MidRangeGraphics, State = SettingState.Disabled)]
			UltraPro = 5,
			[EnumOption("MEGA ULTRA PRO", "This is going to use 8k textures, are you even sure you want to? Generating them will take a while so better leave it running overnight. Make sure you have at least 6GB of VRAM in your GPU for the stock systems, more for larger ones, or you will get frequent crashes.")]
			[EnumOption(1u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.LowEndGraphics, State = SettingState.Disabled)]
			[EnumOption(1u, DeviceFlags.MidRangeGraphics, State = SettingState.Disabled)]
			MegaUltraPro = 6
		}

		public enum StructureDetailQuality
		{
			[EnumOption("Only required components of structures will be loaded.")]
			Low = 0,
			[EnumOption("Most components of structures will be loaded.")]
			Medium = 1,
			[EnumOption("All components of structures will be loaded.")]
			High = 2
		}

		public enum StructureNormalMapQuality
		{
			[EnumOption("Disabled", "Terrain related structures (like launchpads, runways, and buildings) will not be normal mapped.")]
			Off = 0,
			[EnumOption("Enabled", "Terrain related structures (like launchpads, runways, and buildings) will use normal mapping whenever possible.")]
			On = 1
		}

		public enum TextureQuality
		{
			[EnumOption("Disabled", "Textures will not be applied to planet surfaces.", DisplayOrder = 0)]
			Off = 0,
			[EnumOption("Medium", "Distance blending will be used for textures applied to the planet's surface. This approach could result in some visual artifacts between blending levels.", DisplayOrder = 1)]
			BlendedFast = 1,
			[EnumOption("High", "High quality distance blending will be used for textures applied to the planet's surface. This provides the best surface detail but may be slower than the other approach.", DisplayOrder = 2)]
			Blended = 2
		}

		public class CubemapQualitySettings
		{
			public float CubemapTransitionScale { get; }

			public int GenerationDownsampleCount { get; }

			public int MapViewHighDetailSize { get; }

			public int MapViewLowDetailSize { get; }

			public int MaxSize { get; }

			public int MenuGenerationDownsampleCount { get; }

			public int MenuSize { get; }

			public int MinSize { get; }

			public int NavMapSize { get; }

			public bool NormalMapsEnabled { get; }

			public bool NormalCliffColorEnabled { get; }

			public int ScaledSpaceHighDetailSize { get; }

			public int ScaledSpaceLowDetailSize { get; }

			public CubemapQualitySettings(PlanetCubemapQuality quality)
			{
				switch (quality)
				{
				case PlanetCubemapQuality.MegaUltraPro:
					ScaledSpaceLowDetailSize = 128;
					ScaledSpaceHighDetailSize = 8192;
					MapViewLowDetailSize = 128;
					MapViewHighDetailSize = 8192;
					NavMapSize = 1024;
					MenuSize = 512;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = true;
					CubemapTransitionScale = 1f / 32f;
					break;
				case PlanetCubemapQuality.UltraPro:
					ScaledSpaceLowDetailSize = 128;
					ScaledSpaceHighDetailSize = 4096;
					MapViewLowDetailSize = 128;
					MapViewHighDetailSize = 4096;
					NavMapSize = 1024;
					MenuSize = 512;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = true;
					CubemapTransitionScale = 0.0625f;
					break;
				case PlanetCubemapQuality.Ultra:
					ScaledSpaceLowDetailSize = 128;
					ScaledSpaceHighDetailSize = 2048;
					MapViewLowDetailSize = 128;
					MapViewHighDetailSize = 2048;
					NavMapSize = 1024;
					MenuSize = 512;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = true;
					CubemapTransitionScale = 0.125f;
					break;
				case PlanetCubemapQuality.VeryHigh:
					ScaledSpaceLowDetailSize = 128;
					ScaledSpaceHighDetailSize = 1024;
					MapViewLowDetailSize = 128;
					MapViewHighDetailSize = 1024;
					NavMapSize = 1024;
					MenuSize = 512;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = true;
					CubemapTransitionScale = 0.25f;
					break;
				case PlanetCubemapQuality.High:
					ScaledSpaceLowDetailSize = 64;
					ScaledSpaceHighDetailSize = 512;
					MapViewLowDetailSize = 64;
					MapViewHighDetailSize = 512;
					NavMapSize = 512;
					MenuSize = 256;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = false;
					CubemapTransitionScale = 0.5f;
					break;
				case PlanetCubemapQuality.Medium:
					ScaledSpaceLowDetailSize = 64;
					ScaledSpaceHighDetailSize = 256;
					MapViewLowDetailSize = 64;
					MapViewHighDetailSize = 256;
					NavMapSize = 256;
					MenuSize = 256;
					NormalMapsEnabled = true;
					NormalCliffColorEnabled = false;
					CubemapTransitionScale = 1f;
					break;
				case PlanetCubemapQuality.Low:
					ScaledSpaceLowDetailSize = 64;
					ScaledSpaceHighDetailSize = 256;
					MapViewLowDetailSize = 64;
					MapViewHighDetailSize = 256;
					NavMapSize = 256;
					MenuSize = 256;
					NormalMapsEnabled = false;
					NormalCliffColorEnabled = false;
					CubemapTransitionScale = 1f;
					break;
				default:
					throw new NotSupportedException();
				}
				MaxSize = System.Math.Max(System.Math.Max(ScaledSpaceHighDetailSize, MapViewHighDetailSize), System.Math.Max(MenuSize, NavMapSize));
				MinSize = System.Math.Min(System.Math.Min(ScaledSpaceLowDetailSize, MapViewLowDetailSize), System.Math.Min(MenuSize, NavMapSize));
				GenerationDownsampleCount = (int)(System.Math.Log(MaxSize, 2.0) - System.Math.Log(MinSize, 2.0)) + 1;
				MenuGenerationDownsampleCount = (int)(System.Math.Log(MenuSize, 2.0) - System.Math.Log(MinSize, 2.0)) + 1;
			}
		}

		public EnumSetting<PlanetCubemapQuality> Cubemaps { get; private set; }

		public CubemapQualitySettings CubemapSettings { get; private set; }

		public EnumSetting<GeometryDetailQuality> GeometryDetail { get; private set; }

		public NumericSetting<float> LodDistance { get; private set; }

		public NumericSetting<int> MaxSubdivisionLevelBias { get; private set; }

		public NumericSetting<int> MinSubdivisionLevelBias { get; private set; }

		public BoolSetting ScaledSpaceVertexDisplacement { get; private set; }

		public EnumSetting<StructureDetailQuality> StructureDetail { get; private set; }

		public EnumSetting<StructureNormalMapQuality> StructureNormalMaps { get; private set; }

		public EnumSetting<TextureQuality> Textures { get; private set; }

		public TerrainQualitySettings()
			: base("Terrain")
		{
			RegisterPresetList(DeviceFlags.Mobile, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
			RegisterPresetList(DeviceFlags.Desktop, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Ultra, SettingsCategoryPreset.Custom);
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
				bool flag = devices.HasFlag(DeviceFlags.Mobile);
				bool flag2 = devices.HasFlag(DeviceFlags.LowRam);
				switch (preset)
				{
				case SettingsCategoryPreset.Ultra:
					Textures.Value = TextureQuality.Blended;
					Cubemaps.Value = PlanetCubemapQuality.Ultra;
					LodDistance.Value = (flag ? 5f : 10f);
					GeometryDetail.Value = ((!flag2) ? GeometryDetailQuality.High : GeometryDetailQuality.Low);
					StructureDetail.Value = ((!flag2) ? StructureDetailQuality.High : StructureDetailQuality.Low);
					StructureNormalMaps.Value = StructureNormalMapQuality.On;
					ScaledSpaceVertexDisplacement.Value = true;
					break;
				case SettingsCategoryPreset.High:
					Textures.Value = TextureQuality.Blended;
					Cubemaps.Value = PlanetCubemapQuality.High;
					LodDistance.Value = (flag ? 5f : 10f);
					GeometryDetail.Value = ((!flag2) ? GeometryDetailQuality.High : GeometryDetailQuality.Low);
					StructureDetail.Value = ((!flag2) ? StructureDetailQuality.High : StructureDetailQuality.Low);
					StructureNormalMaps.Value = StructureNormalMapQuality.On;
					ScaledSpaceVertexDisplacement.Value = true;
					break;
				case SettingsCategoryPreset.Medium:
					Textures.Value = (flag ? TextureQuality.BlendedFast : TextureQuality.Blended);
					Cubemaps.Value = PlanetCubemapQuality.Medium;
					LodDistance.Value = (flag ? 3f : 5f);
					GeometryDetail.Value = ((!flag2) ? GeometryDetailQuality.Medium : GeometryDetailQuality.Low);
					StructureDetail.Value = ((!flag2) ? StructureDetailQuality.Medium : StructureDetailQuality.Low);
					StructureNormalMaps.Value = ((!flag) ? StructureNormalMapQuality.On : StructureNormalMapQuality.Off);
					ScaledSpaceVertexDisplacement.Value = true;
					break;
				default:
					Textures.Value = ((!flag) ? TextureQuality.Blended : TextureQuality.Off);
					Cubemaps.Value = ((!flag) ? PlanetCubemapQuality.Medium : PlanetCubemapQuality.Low);
					LodDistance.Value = (flag ? 2f : 3f);
					GeometryDetail.Value = GeometryDetailQuality.Low;
					StructureDetail.Value = StructureDetailQuality.Low;
					StructureNormalMaps.Value = ((!flag) ? StructureNormalMapQuality.On : StructureNormalMapQuality.Off);
					ScaledSpaceVertexDisplacement.Value = true;
					break;
				}
			}
		}

		protected override void InitializeSettings()
		{
			Textures = CreateEnum<TextureQuality>("Textures").SetDescription("The texture mapping approach used when rendering planet surfaces.");
			StructureNormalMaps = CreateEnum<StructureNormalMapQuality>("Structure Normal Maps").SetDescription("Enables or disables normal mapping on terrain related structures, like the launch pad, runways, and buildings.");
			Cubemaps = CreateEnum<PlanetCubemapQuality>("Planet Cubemaps").SetApplyType(SettingApplyType.RequiresSceneRestart).AddWarning(DeviceFlags.Mobile, (PlanetCubemapQuality x) => x > PlanetCubemapQuality.High, "Your current Planet Cubemaps setting will lead to hours of loading screens and likely crash your device, please, lower them back if you don't know what you are doing.").AddWarning(DeviceFlags.LowEnd, (PlanetCubemapQuality x) => x > PlanetCubemapQuality.High, "Your current Planet Cubemaps setting will lead to hours of loading screens and likely crash your device, please, lower them back if you don't know what you are doing.")
				.AddWarning(DeviceFlags.MidRange, (PlanetCubemapQuality x) => x > PlanetCubemapQuality.VeryHigh, "Your current Planet Cubemaps setting will lead to hours of loading screens and likely crash your device, is it worth it?")
				.AddWarning(DeviceFlags.HighEnd, (PlanetCubemapQuality x) => x > PlanetCubemapQuality.VeryHigh, "Your current Planet Cubemaps setting will lead a long loading screen the first time you go into flight, get some popcorn ready.")
				.SetDescription("This adjusts the quality of planet cubemaps. These are used to render distant planets, planets in map view, and the planet on the main menu.");
			GeometryDetail = CreateEnum<GeometryDetailQuality>("Geometric Detail").SetApplyType(SettingApplyType.RequiresQuadsphereReload).SetState(DeviceFlags.LowRam, SettingState.Hidden).SetDescription("The detail level used when generating and rendering the terrain geometry. This can have large impacts on performance.");
			StructureDetail = CreateEnum<StructureDetailQuality>("Structure Detail").SetApplyType(SettingApplyType.RequiresQuadsphereReload).SetDescription("The detail level used when loading structures on the terrain.");
			LodDistance = CreateNumeric("LOD Distance", 2f, 10f, 0.1f).SetXmlName("lodDistance").SetEnforcedRange(DeviceFlags.Desktop, 2f, 25f).SetEnforcedRange(DeviceFlags.Mobile, 2f, 10f)
				.SetRange(DeviceFlags.LowRam, 2f, 5f, 0.1f)
				.SetEnforcedRange(DeviceFlags.LowRam, 2f, 5f)
				.SetDisplayFormatter((float x) => x.ToString("F1"))
				.SetDescription("This affects the distances at which higher detail terrain is loaded. The higher the value, the more terrain detail that can be seen at a given distance from the surface. Increasing this value can have very large performance and memory impacts.");
			MinSubdivisionLevelBias = CreateNumeric("Min Subdivision Level Bias", -5, 5, 1).SetDescription("The adjustment applied to the quad sphere minimum subdivision level setting. Increasing this number will improve detail when far away from the ground and can greatly reduce performance and increase memory usage and load times.").SetApplyType(SettingApplyType.RequiresQuadsphereReload).SetState(SettingState.Hidden)
				.SetDefault(0);
			MaxSubdivisionLevelBias = CreateNumeric("Max Subdivision Level Bias", -5, 5, 1).SetDescription("The adjustment applied to the quad sphere maximum subdivision level setting. Increasing this number will improve detail when close to the ground, but it can greatly reduce performance and increase memory usage and load times.").SetApplyType(SettingApplyType.RequiresQuadsphereReload).SetState(SettingState.Hidden)
				.SetDefault(0);
			ScaledSpaceVertexDisplacement = CreateBool("Scaled Space Vertex Displacement").SetDescription("Toggles vertex displacement for scaled space planets. When disabled, scaled space planets are perfect spheres. When enabled, the shape of scaled space planets resembles the actual planet shape at the cost of some performance impact.").SetState(SettingState.Hidden).SetDefault(value: true);
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			StructureNormalMaps.Changed += OnStructureNormalMapsChanged;
			StructureNormalMaps.RaiseSettingChangedEvent();
			Cubemaps.Changed += CubemapSettingsChanged;
			Cubemaps.RaiseSettingChangedEvent();
		}

		private void CubemapSettingsChanged(object sender, SettingChangedEventArgs<PlanetCubemapQuality> e)
		{
			CubemapSettings = new CubemapQualitySettings(e.Setting);
		}

		private void OnStructureNormalMapsChanged(object sender, SettingChangedEventArgs<StructureNormalMapQuality> e)
		{
			if (e.Setting.Value == StructureNormalMapQuality.On)
			{
				Shader.EnableKeyword("TERRAIN_STRUCTURE_NORMAL_MAPS_ON");
			}
			else
			{
				Shader.DisableKeyword("TERRAIN_STRUCTURE_NORMAL_MAPS_ON");
			}
		}
	}
}
