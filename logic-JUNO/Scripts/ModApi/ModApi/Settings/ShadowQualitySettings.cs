using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace ModApi.Settings
{
	public class ShadowQualitySettings : SettingsCategory<ShadowQualitySettings>
	{
		public enum LightType
		{
			Other = 0,
			PrimaryLight = 1,
			CraftPartLight = 2
		}

		public enum ShadowDistanceQuality
		{
			[EnumOption("Low", "Low resolution shadows with short maximum draw distances.")]
			Low = 0,
			[EnumOption("Medium", "Medium resolution shadows with moderate maximum draw distances.")]
			Medium = 1,
			[EnumOption("High", "High resolution shadows with far maximum draw distances.")]
			High = 2,
			[EnumOption(0u, DeviceFlags.All, State = SettingState.Enabled, DisplayName = "Very High", Description = "Same maximum draw distance as 'High' but uses higher resolution shadows if the GPU supports it.")]
			[EnumOption(1u, DeviceFlags.LowEndGraphics, State = SettingState.Disabled)]
			[EnumOption(2u, DeviceFlags.Mobile, State = SettingState.Disabled)]
			VeryHigh = 3
		}

		public BoolSetting CraftLightsCastShadows { get; private set; }

		public BoolSetting DesignerShadows { get; private set; }

		public bool Enabled
		{
			get
			{
				if (Game.InDesignerScene)
				{
					if (base.Preset != SettingsCategoryPreset.Off)
					{
						return DesignerShadows.Value;
					}
					return false;
				}
				if (base.Preset != SettingsCategoryPreset.Off)
				{
					if (!PartsReceiveShadows.Value)
					{
						return TerrainReceivesShadows.Value;
					}
					return true;
				}
				return false;
			}
		}

		public float MaxShadowDistance { get; private set; }

		public float MinShadowDistance { get; private set; }

		public BoolSetting PartsReceiveShadows { get; private set; }

		public EnumSetting<ShadowDistanceQuality> ShadowDistance { get; private set; }

		public NumericSetting<float> ShadowLerp { get; private set; }

		public BoolSetting SoftShadows { get; private set; }

		public BoolSetting TerrainReceivesShadows { get; private set; }

		public ShadowQualitySettings()
			: base("Shadows")
		{
			RegisterPresetList(SettingsCategoryPreset.Off, SettingsCategoryPreset.Low, SettingsCategoryPreset.Medium, SettingsCategoryPreset.High, SettingsCategoryPreset.Custom);
		}

		public void ConfigureLight(Light light, LightType type, bool enabled = true)
		{
			bool flag = false;
			if (Enabled && enabled && (type == LightType.PrimaryLight || (type == LightType.CraftPartLight && (bool)CraftLightsCastShadows)))
			{
				flag = true;
				light.shadows = ((!SoftShadows.Value) ? LightShadows.Hard : LightShadows.Soft);
				light.shadowCustomResolution = 0;
				light.shadowResolution = LightShadowResolution.FromQualitySettings;
				if (ShadowDistance.Value == ShadowDistanceQuality.VeryHigh)
				{
					light.shadowCustomResolution = 8192;
				}
			}
			if (!flag)
			{
				light.shadows = LightShadows.None;
			}
		}

		public void ConfigurePartRenderer(Renderer renderer)
		{
			renderer.shadowCastingMode = (Enabled ? ShadowCastingMode.On : ShadowCastingMode.Off);
			renderer.receiveShadows = (bool)PartsReceiveShadows && !Game.InDesignerScene;
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			DeviceFlags flags = CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.HighEndGraphics))
			{
				return SettingsCategoryPreset.High;
			}
			if (flags.HasFlag(DeviceFlags.MidRangeGraphics))
			{
				return SettingsCategoryPreset.Medium;
			}
			if (!flags.HasFlag(DeviceFlags.Mobile))
			{
				return SettingsCategoryPreset.Low;
			}
			return SettingsCategoryPreset.Off;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				break;
			case SettingsCategoryPreset.Off:
				PartsReceiveShadows.Value = false;
				TerrainReceivesShadows.Value = false;
				DesignerShadows.Value = false;
				CraftLightsCastShadows.Value = false;
				SoftShadows.Value = false;
				ShadowLerp.Value = 1f;
				ShadowDistance.Value = ShadowDistanceQuality.Low;
				break;
			case SettingsCategoryPreset.High:
				PartsReceiveShadows.Value = true;
				TerrainReceivesShadows.Value = true;
				DesignerShadows.Value = false;
				CraftLightsCastShadows.Value = true;
				SoftShadows.Value = false;
				ShadowLerp.Value = 1f;
				ShadowDistance.Value = ShadowDistanceQuality.High;
				break;
			case SettingsCategoryPreset.Medium:
				PartsReceiveShadows.Value = true;
				TerrainReceivesShadows.Value = true;
				DesignerShadows.Value = false;
				CraftLightsCastShadows.Value = false;
				SoftShadows.Value = false;
				ShadowLerp.Value = 1f;
				ShadowDistance.Value = ShadowDistanceQuality.Medium;
				break;
			default:
				PartsReceiveShadows.Value = false;
				TerrainReceivesShadows.Value = true;
				DesignerShadows.Value = false;
				CraftLightsCastShadows.Value = false;
				SoftShadows.Value = false;
				ShadowLerp.Value = 1f;
				ShadowDistance.Value = ShadowDistanceQuality.Low;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			PartsReceiveShadows = CreateBool("Parts Receive Shadows").SetDescription("Craft parts will cast and receive shadows if enabled.");
			TerrainReceivesShadows = CreateBool("Terrain Receives Shadows").SetDescription("The terrain will receive shadows cast by craft parts and other objects.");
			DesignerShadows = CreateBool("Designer Shadows").SetDescription("The platform in the designer will receive shadows cast by the craft parts.");
			CraftLightsCastShadows = CreateBool("Craft Lights Cast Shadows").SetDescription("Indicates whether the craft's light parts will create shadows.");
			ShadowDistance = CreateEnum<ShadowDistanceQuality>("Shadow Distance").SetDescription("Adjusts the maximum distance at which shadows are drawn. This also affects the resolution of the shadows.");
			ShadowLerp = CreateNumeric("Detail Distribution", 0f, 1f, 0.1f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Higher values result in higher detail on close-ups, but a decreasing shadow distance when zooming in, lower values maintain the larger distance at the cost of shadow resolution.");
			SoftShadows = CreateBool("Soft Shadows").SetState(SettingState.Hidden).SetDescription("If enabled, the shadow edges will have a softer look to them at some cost to performance.");
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			base.Changed += OnSettingsChanged;
			RaiseSettingsChangedEvent();
		}

		private void OnSettingsChanged(object sender, SettingsChangedEventArgs<ShadowQualitySettings> e)
		{
			QualitySettings.shadows = (Enabled ? ((!SoftShadows.Value) ? ShadowQuality.HardOnly : ShadowQuality.All) : ShadowQuality.Disable);
			switch (ShadowDistance.Value)
			{
			case ShadowDistanceQuality.VeryHigh:
				QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
				QualitySettings.shadowProjection = ShadowProjection.StableFit;
				QualitySettings.shadowCascades = 4;
				QualitySettings.shadowCascade4Split = new Vector3(0.02f, 0.06f, 0.22f);
				MaxShadowDistance = 2000f;
				MinShadowDistance = 500f;
				break;
			case ShadowDistanceQuality.High:
				QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
				QualitySettings.shadowProjection = ShadowProjection.StableFit;
				QualitySettings.shadowCascades = 4;
				QualitySettings.shadowCascade4Split = new Vector3(0.02f, 0.06f, 0.22f);
				MaxShadowDistance = 2000f;
				MinShadowDistance = 500f;
				break;
			case ShadowDistanceQuality.Medium:
				QualitySettings.shadowResolution = ShadowResolution.High;
				QualitySettings.shadowProjection = ShadowProjection.StableFit;
				QualitySettings.shadowCascades = 2;
				QualitySettings.shadowCascade2Split = 0.12f;
				MaxShadowDistance = 800f;
				MinShadowDistance = 200f;
				break;
			default:
				QualitySettings.shadowResolution = ShadowResolution.Medium;
				QualitySettings.shadowProjection = ShadowProjection.StableFit;
				QualitySettings.shadowCascades = 1;
				MaxShadowDistance = 200f;
				MinShadowDistance = 50f;
				break;
			}
			QualitySettings.shadowDistance = MaxShadowDistance;
		}
	}
}
