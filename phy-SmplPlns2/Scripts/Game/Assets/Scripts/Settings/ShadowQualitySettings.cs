using Assets.Scripts.Rendering;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Settings
{
	public class ShadowQualitySettings : SettingsCategory<ShadowQualitySettings>
	{
		public enum ShadowQualityLevel
		{
			[EnumOption("Off", "Shadows are disabled entirely. This has an obvious impact on visual quality, but it can improve performance on devices that struggle to reach playable framerates.")]
			Off = 0,
			[EnumOption("Low", "Shadows are lower quality and have a short view distance.")]
			Low = 1,
			[EnumOption("Medium", "Shadow quality and view distance tries to strike a decent balance between high and low quality.")]
			Medium = 2,
			[EnumOption("High", "Shadows are higher quality and have a larger view distance than the lower qualities.")]
			High = 3,
			[EnumOption("Very High", "Shadows are at their highest quality and the shadow view distance is dynamic, allowing for far greater shadow view distances when flying.")]
			VeryHigh = 4
		}

		private class OriginalShadowQualitySettings
		{
			public float Cascade2Split { get; }

			public Vector2 Cascade3Split { get; }

			public Vector3 Cascade4Split { get; }

			public float CascadeBorder { get; }

			public int MainLightShadowmapResolution { get; }

			public int ShadowCascadeCount { get; }

			public float ShadowDistance { get; }

			public bool SupportsAdditionalLightShadows { get; }

			public OriginalShadowQualitySettings()
			{
				UniversalRenderPipelineAsset asset = UniversalRenderPipeline.asset;
				Cascade2Split = asset.cascade2Split;
				Cascade3Split = asset.cascade3Split;
				Cascade4Split = asset.cascade4Split;
				CascadeBorder = asset.cascadeBorder;
				ShadowCascadeCount = asset.shadowCascadeCount;
				ShadowDistance = asset.shadowDistance;
				MainLightShadowmapResolution = asset.mainLightShadowmapResolution;
				SupportsAdditionalLightShadows = asset.supportsAdditionalLightShadows;
			}

			public void Restore()
			{
				UniversalRenderPipelineAsset asset = UniversalRenderPipeline.asset;
				asset.cascade2Split = Cascade2Split;
				asset.cascade3Split = Cascade3Split;
				asset.cascade4Split = Cascade4Split;
				asset.cascadeBorder = CascadeBorder;
				asset.shadowCascadeCount = ShadowCascadeCount;
				asset.shadowDistance = ShadowDistance;
				asset.mainLightShadowmapResolution = MainLightShadowmapResolution;
				UniversalRenderPipelineSettings.SupportsAdditionalLightShadows = SupportsAdditionalLightShadows;
			}
		}

		private OriginalShadowQualitySettings _originalShadowSettings;

		public BoolSetting DesignerShadows { get; private set; }

		public EnumSetting<ShadowQualityLevel> ShadowQuality { get; private set; }

		public BoolSetting TreeShadows { get; private set; }

		public ShadowQualitySettings()
			: base("Shadows")
		{
			_originalShadowSettings = new OriginalShadowQualitySettings();
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				break;
			case SettingsCategoryPreset.VeryHigh:
				ShadowQuality.Value = ShadowQualityLevel.VeryHigh;
				TreeShadows.Value = true;
				DesignerShadows.Value = true;
				break;
			case SettingsCategoryPreset.High:
				ShadowQuality.Value = ShadowQualityLevel.High;
				TreeShadows.Value = true;
				DesignerShadows.Value = true;
				break;
			case SettingsCategoryPreset.Medium:
				ShadowQuality.Value = ShadowQualityLevel.Medium;
				TreeShadows.Value = true;
				DesignerShadows.Value = true;
				break;
			case SettingsCategoryPreset.Low:
				ShadowQuality.Value = ShadowQualityLevel.Low;
				TreeShadows.Value = true;
				DesignerShadows.Value = true;
				break;
			default:
				ShadowQuality.Value = ShadowQualityLevel.Off;
				TreeShadows.Value = false;
				DesignerShadows.Value = false;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			ShadowQuality = CreateEnum<ShadowQualityLevel>("Shadow Quality").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Adjusts the quality and view distance of shadows. Shadow quality can have a performance impact on both CPU and GPU performance.").SetDefault(ShadowQualityLevel.High);
			DesignerShadows = CreateBool("Designer Shadows").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Determines whether shadows are enabled in the designer. Disabling shadows can improve performance in the designer. Some players may also find it useful to disable shadows in the designer so that they don't obstruct the view when building craft.").SetDefault(value: true);
			TreeShadows = CreateBool("Tree Shadows").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Determines whether trees cast shadows. Disabling shadows cast by trees can help improve performance on some devices.").SetDefault(value: true);
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			ShadowQuality.Changed += delegate
			{
				ApplyShadowSettings();
			};
			ShadowQuality.RaiseSettingChangedEvent();
			Application.quitting += OnApplicationQuitting;
		}

		private void ApplyShadowSettings()
		{
			if (Device.IsMobileBuild)
			{
				UniversalRenderPipelineSettings.ShadowDistance = (Game.Instance.Device.IsAndroidVRBuild ? 20 : 70);
				UniversalRenderPipelineSettings.ShadowCascadeCount = 1;
			}
			else if (ShadowQuality.Value == ShadowQualityLevel.High || ShadowQuality.Value == ShadowQualityLevel.VeryHigh)
			{
				UniversalRenderPipelineSettings.ShadowCascadeCount = 4;
				UniversalRenderPipelineSettings.MainLightShadowmapResolution = 8192;
				UniversalRenderPipelineSettings.ShadowDistance = 2000f;
			}
			else if (ShadowQuality.Value == ShadowQualityLevel.Medium)
			{
				UniversalRenderPipelineSettings.ShadowCascadeCount = 4;
				UniversalRenderPipelineSettings.MainLightShadowmapResolution = 4096;
				UniversalRenderPipelineSettings.ShadowDistance = 1000f;
			}
			else if (ShadowQuality.Value == ShadowQualityLevel.Low)
			{
				UniversalRenderPipelineSettings.ShadowCascadeCount = 3;
				UniversalRenderPipelineSettings.MainLightShadowmapResolution = 2048;
				UniversalRenderPipelineSettings.ShadowDistance = 500f;
			}
			UniversalRenderPipelineSettings.SupportsAdditionalLightShadows = (ShadowQualityLevel)ShadowQuality >= ShadowQualityLevel.High;
		}

		private void OnApplicationQuitting()
		{
			if (Device.IsUnityEditor)
			{
				_originalShadowSettings.Restore();
			}
		}
	}
}
