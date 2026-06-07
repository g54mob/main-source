using System;
using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.UI.Presets
{
	public static class GraphicsPresets
	{
		public const string VERY_LOW = "Very Low";

		public const string LOW = "Low";

		public const string MEDIUM = "Medium";

		public const string HIGH = "High";

		public const string VERY_HIGH = "Very High";

		public const string ULTRA = "Ultra";

		public static readonly IReadOnlyList<string> PRESET_NAMES = Array.AsReadOnly(new string[6] { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" });

		public static List<SettingsPreset> Get()
		{
			if (VRManager.IsVREnabled())
			{
				return new List<SettingsPreset>
				{
					new SettingsPreset("Very Low", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 0 },
						{ "ShadowsQualityIndex", 0 },
						{ "ReflectionQualityIndex", 0 },
						{ "RainQualityIndex", 0 },
						{ "VegetationQualityIndex", 0 },
						{ "AntiAliasingDeferredLevelsIndex", 0 },
						{ "AmbientOcclusionQualityIndex", 0 },
						{ "DetailLevel", 0 },
						{ "LightingQualityIndex", 0 },
						{ "PostProcessing", false },
						{ "MotionBlur", false },
						{ "TerrainLightingQualityIndex", 0 }
					}),
					new SettingsPreset("Low", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 0 },
						{ "ShadowsQualityIndex", 1 },
						{ "ReflectionQualityIndex", 1 },
						{ "RainQualityIndex", 1 },
						{ "VegetationQualityIndex", 3 },
						{ "AntiAliasingDeferredLevelsIndex", 0 },
						{ "AmbientOcclusionQualityIndex", 0 },
						{ "DetailLevel", 0 },
						{ "LightingQualityIndex", 0 },
						{ "PostProcessing", false },
						{ "MotionBlur", false },
						{ "TerrainLightingQualityIndex", 0 }
					}),
					new SettingsPreset("Medium", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 1 },
						{ "ShadowsQualityIndex", 3 },
						{ "ReflectionQualityIndex", 2 },
						{ "RainQualityIndex", 2 },
						{ "VegetationQualityIndex", 4 },
						{ "AntiAliasingDeferredLevelsIndex", 0 },
						{ "AmbientOcclusionQualityIndex", 1 },
						{ "DetailLevel", 1 },
						{ "LightingQualityIndex", 1 },
						{ "PostProcessing", true },
						{ "MotionBlur", false },
						{ "TerrainLightingQualityIndex", 1 }
					}),
					new SettingsPreset("High", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 2 },
						{ "ShadowsQualityIndex", 4 },
						{ "ReflectionQualityIndex", 3 },
						{ "RainQualityIndex", 3 },
						{ "VegetationQualityIndex", 5 },
						{ "AntiAliasingDeferredLevelsIndex", 1 },
						{ "AmbientOcclusionQualityIndex", 2 },
						{ "DetailLevel", 2 },
						{ "LightingQualityIndex", 2 },
						{ "PostProcessing", true },
						{ "MotionBlur", true },
						{ "TerrainLightingQualityIndex", 1 }
					}),
					new SettingsPreset("Very High", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 2 },
						{ "ShadowsQualityIndex", 5 },
						{ "ReflectionQualityIndex", 4 },
						{ "RainQualityIndex", 3 },
						{ "VegetationQualityIndex", 6 },
						{ "AntiAliasingDeferredLevelsIndex", 1 },
						{ "AmbientOcclusionQualityIndex", 2 },
						{ "DetailLevel", 2 },
						{ "LightingQualityIndex", 2 },
						{ "PostProcessing", true },
						{ "MotionBlur", true },
						{ "TerrainLightingQualityIndex", 1 }
					}),
					new SettingsPreset("Ultra", new Dictionary<string, object>
					{
						{ "AnisotropicFiltering", 2 },
						{ "ShadowsQualityIndex", 6 },
						{ "ReflectionQualityIndex", 4 },
						{ "RainQualityIndex", 3 },
						{ "VegetationQualityIndex", 7 },
						{ "AntiAliasingDeferredLevelsIndex", 1 },
						{ "AmbientOcclusionQualityIndex", 2 },
						{ "DetailLevel", 2 },
						{ "LightingQualityIndex", 2 },
						{ "PostProcessing", true },
						{ "MotionBlur", true },
						{ "TerrainLightingQualityIndex", 2 }
					})
				};
			}
			return new List<SettingsPreset>
			{
				new SettingsPreset("Very Low", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 0 },
					{ "ShadowsQualityIndex", 0 },
					{ "ReflectionQualityIndex", 0 },
					{ "RainQualityIndex", 0 },
					{ "VegetationQualityIndex", 0 },
					{ "AntiAliasingDeferredLevelsIndex", 0 },
					{ "AmbientOcclusionQualityIndex", 0 },
					{ "DetailLevel", 0 },
					{ "LightingQualityIndex", 0 },
					{ "PostProcessing", false },
					{ "MotionBlur", false },
					{ "TerrainLightingQualityIndex", 0 }
				}),
				new SettingsPreset("Low", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 0 },
					{ "ShadowsQualityIndex", 1 },
					{ "ReflectionQualityIndex", 1 },
					{ "RainQualityIndex", 1 },
					{ "VegetationQualityIndex", 3 },
					{ "AntiAliasingDeferredLevelsIndex", 0 },
					{ "AmbientOcclusionQualityIndex", 0 },
					{ "DetailLevel", 0 },
					{ "LightingQualityIndex", 0 },
					{ "PostProcessing", false },
					{ "MotionBlur", false },
					{ "TerrainLightingQualityIndex", 0 }
				}),
				new SettingsPreset("Medium", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 1 },
					{ "ShadowsQualityIndex", 3 },
					{ "ReflectionQualityIndex", 2 },
					{ "RainQualityIndex", 2 },
					{ "VegetationQualityIndex", 4 },
					{ "AntiAliasingDeferredLevelsIndex", 0 },
					{ "AmbientOcclusionQualityIndex", 1 },
					{ "DetailLevel", 1 },
					{ "LightingQualityIndex", 1 },
					{ "PostProcessing", true },
					{ "MotionBlur", false },
					{ "TerrainLightingQualityIndex", 1 }
				}),
				new SettingsPreset("High", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 2 },
					{ "ShadowsQualityIndex", 4 },
					{ "ReflectionQualityIndex", 3 },
					{ "RainQualityIndex", 3 },
					{ "VegetationQualityIndex", 5 },
					{ "AntiAliasingDeferredLevelsIndex", 1 },
					{ "AmbientOcclusionQualityIndex", 2 },
					{ "DetailLevel", 2 },
					{ "LightingQualityIndex", 2 },
					{ "PostProcessing", true },
					{ "MotionBlur", true },
					{ "TerrainLightingQualityIndex", 1 }
				}),
				new SettingsPreset("Very High", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 2 },
					{ "ShadowsQualityIndex", 5 },
					{ "ReflectionQualityIndex", 4 },
					{ "RainQualityIndex", 3 },
					{ "VegetationQualityIndex", 6 },
					{ "AntiAliasingDeferredLevelsIndex", 1 },
					{ "AmbientOcclusionQualityIndex", 2 },
					{ "DetailLevel", 2 },
					{ "LightingQualityIndex", 2 },
					{ "PostProcessing", true },
					{ "MotionBlur", true },
					{ "TerrainLightingQualityIndex", 2 }
				}),
				new SettingsPreset("Ultra", new Dictionary<string, object>
				{
					{ "AnisotropicFiltering", 2 },
					{ "ShadowsQualityIndex", 6 },
					{ "ReflectionQualityIndex", 4 },
					{ "RainQualityIndex", 3 },
					{ "VegetationQualityIndex", 7 },
					{ "AntiAliasingDeferredLevelsIndex", 1 },
					{ "AmbientOcclusionQualityIndex", 2 },
					{ "DetailLevel", 2 },
					{ "LightingQualityIndex", 2 },
					{ "PostProcessing", true },
					{ "MotionBlur", true },
					{ "TerrainLightingQualityIndex", 2 }
				})
			};
		}
	}
}
