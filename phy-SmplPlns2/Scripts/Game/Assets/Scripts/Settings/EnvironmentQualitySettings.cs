using Jundroo.Common.Platform;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public class EnvironmentQualitySettings : SettingsCategory<EnvironmentQualitySettings>
	{
		public enum CloudQualityLevel
		{
			[EnumOption("Low", "Flat 2D clouds will be used as part of the skybox instead of 3D volumetric clouds.")]
			Low = 0,
			[EnumOption("Medium", "Volumetric clouds will be used at a reduced quality level.")]
			Medium = 1,
			[EnumOption("High", "High quality volumetric clouds will be used.")]
			High = 2
		}

		public enum TerrainQualityLevel
		{
			[EnumOption("Low", "The visual quality of the terrain surface will be significantly reduced.")]
			Low = 0,
			[EnumOption("Medium", "The visual quality of the terrain surface will be somewhat reduced.")]
			Medium = 1,
			[EnumOption("High", "The visual quality of the terrain surface will be at its highest quality.")]
			High = 2
		}

		public enum TreeDensityQualityLevel
		{
			[EnumOption("No Trees", "No trees will be rendered.")]
			Off = 0,
			[EnumOption("Low", "Approximately 10% of the trees will be rendered.")]
			Low = 1,
			[EnumOption("Medium", "Approximately 50% of the trees will be rendered.")]
			Medium = 2,
			[EnumOption("High", "All trees will be rendered.")]
			High = 3
		}

		private const float MaxTreeDistance = 10000f;

		public EnumSetting<CloudQualityLevel> Clouds { get; private set; }

		public BoolSetting OcclusionCulling { get; private set; }

		public EnumSetting<TerrainQualityLevel> TerrainQuality { get; private set; }

		public Setting<TreeDensityQualityLevel> TreeDensity { get; private set; }

		public Setting<float> TreeDistance { get; private set; }

		public EnvironmentQualitySettings()
			: base("Environment")
		{
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				break;
			case SettingsCategoryPreset.High:
			case SettingsCategoryPreset.VeryHigh:
				Clouds.Value = CloudQualityLevel.High;
				TerrainQuality.Value = TerrainQualityLevel.High;
				TreeDensity.Value = TreeDensityQualityLevel.High;
				TreeDistance.Value = 10000f;
				break;
			case SettingsCategoryPreset.Medium:
				Clouds.Value = CloudQualityLevel.Medium;
				TerrainQuality.Value = TerrainQualityLevel.Medium;
				TreeDensity.Value = TreeDensityQualityLevel.Medium;
				TreeDistance.Value = 5000f;
				break;
			case SettingsCategoryPreset.Low:
				Clouds.Value = CloudQualityLevel.Low;
				TerrainQuality.Value = TerrainQualityLevel.Low;
				TreeDensity.Value = TreeDensityQualityLevel.Low;
				TreeDistance.Value = 2500f;
				break;
			default:
				Clouds.Value = CloudQualityLevel.Low;
				TerrainQuality.Value = TerrainQualityLevel.Low;
				TreeDensity.Value = TreeDensityQualityLevel.Off;
				TreeDistance.Value = 2500f;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			Clouds = CreateEnum<CloudQualityLevel>("Clouds").SetRaiseChangedEventOnlyWhenCommitted(value: true).SetDescription("Adjusts the visual quality of the clouds, sky, and fog. Higher settings are very GPU heavy. Lowering this setting can have big performance gains for GPU limited situations.").SetDefault(CloudQualityLevel.High)
				.SetApplyType(Game.Instance.Device.IsOsxBuild ? SettingApplyType.RequiresSceneRestart : SettingApplyType.Immediate);
			TerrainQuality = CreateEnum<TerrainQualityLevel>("Terrain").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Adjusts the visual quality of the terrain's surface. Higher settings are very GPU heavy. Lowering this setting can have big performance gains for GPU limited situations.").SetDefault(TerrainQualityLevel.High);
			TreeDensity = (EnumSetting<TreeDensityQualityLevel>)CreateEnum<TreeDensityQualityLevel>("Tree Density").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Adjusts the density of the trees. Higher settings mean more trees being rendered on screen, which can reduce performance.").SetDefault(TreeDensityQualityLevel.High);
			TreeDistance = (NumericSetting<float>)CreateNumeric("Tree View Distance", 1000f, 10000f, 500f).SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDisplayFormatter((float x) => (!(x > 0f)) ? "No Trees" : $"{x / 1000f:0.0} km").SetDescription("Adjusts the rendering distance for trees. A greater rendering distance means more trees being rendered on screen, which can reduce performance.")
				.SetDefault(2500f);
			OcclusionCulling = CreateBool("Occlusion Culling").SetDescription("Hide environment objects that are far away or obscured by terrain").SetDefault(value: true).SetState(SettingState.Hidden);
		}
	}
}
