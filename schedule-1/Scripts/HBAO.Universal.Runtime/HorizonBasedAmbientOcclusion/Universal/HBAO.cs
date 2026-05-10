using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace HorizonBasedAmbientOcclusion.Universal
{
	[VolumeComponentMenu("Lighting/HBAO")]
	[ExecuteInEditMode]
	public class HBAO : VolumeComponent, IPostProcessComponent
	{
		public enum Preset
		{
			FastestPerformance = 0,
			FastPerformance = 1,
			Normal = 2,
			HighQuality = 3,
			HighestQuality = 4,
			Custom = 5
		}

		public enum Mode
		{
			Normal = 0,
			LitAO = 1
		}

		public enum RenderingPath
		{
			Forward = 0,
			Deferred = 1
		}

		public enum Quality
		{
			Lowest = 0,
			Low = 1,
			Medium = 2,
			High = 3,
			Highest = 4
		}

		public enum Resolution
		{
			Full = 0,
			Half = 1
		}

		public enum NoiseType
		{
			Dither = 0,
			InterleavedGradientNoise = 1,
			SpatialDistribution = 2
		}

		public enum Deinterleaving
		{
			Disabled = 0,
			x4 = 1
		}

		public enum DebugMode
		{
			Disabled = 0,
			AOOnly = 1,
			ColorBleedingOnly = 2,
			SplitWithoutAOAndWithAO = 3,
			SplitWithAOAndAOOnly = 4,
			SplitWithoutAOAndAOOnly = 5,
			ViewNormals = 6
		}

		public enum BlurType
		{
			None = 0,
			Narrow = 1,
			Medium = 2,
			Wide = 3,
			ExtraWide = 4
		}

		public enum PerPixelNormals
		{
			Reconstruct2Samples = 0,
			Reconstruct4Samples = 1,
			Camera = 2
		}

		public enum VarianceClipping
		{
			Disabled = 0,
			_4Tap = 1,
			_8Tap = 2
		}

		[Serializable]
		public sealed class PresetParameter : VolumeParameter<Preset>
		{
			public PresetParameter(Preset value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class ModeParameter : VolumeParameter<Mode>
		{
			public ModeParameter(Mode value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class RenderingPathParameter : VolumeParameter<RenderingPath>
		{
			public RenderingPathParameter(RenderingPath value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class QualityParameter : VolumeParameter<Quality>
		{
			public QualityParameter(Quality value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class DeinterleavingParameter : VolumeParameter<Deinterleaving>
		{
			public DeinterleavingParameter(Deinterleaving value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class ResolutionParameter : VolumeParameter<Resolution>
		{
			public ResolutionParameter(Resolution value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class NoiseTypeParameter : VolumeParameter<NoiseType>
		{
			public NoiseTypeParameter(NoiseType value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class DebugModeParameter : VolumeParameter<DebugMode>
		{
			public DebugModeParameter(DebugMode value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class PerPixelNormalsParameter : VolumeParameter<PerPixelNormals>
		{
			public PerPixelNormalsParameter(PerPixelNormals value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class VarianceClippingParameter : VolumeParameter<VarianceClipping>
		{
			public VarianceClippingParameter(VarianceClipping value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class BlurTypeParameter : VolumeParameter<BlurType>
		{
			public BlurTypeParameter(BlurType value, bool overrideState = false)
			{
			}
		}

		[Serializable]
		public sealed class MinMaxFloatParameter : VolumeParameter<Vector2>
		{
			public float min;

			public float max;

			public MinMaxFloatParameter(Vector2 value, float min, float max, bool overrideState = false)
			{
			}
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class SettingsGroup : Attribute
		{
			public bool isExpanded;
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class ParameterDisplayName : Attribute
		{
			public string name;

			public ParameterDisplayName(string name)
			{
			}
		}

		public class Presets : SettingsGroup
		{
		}

		public class GeneralSettings : SettingsGroup
		{
		}

		public class AOSettings : SettingsGroup
		{
		}

		public class TemporalFilterSettings : SettingsGroup
		{
		}

		public class BlurSettings : SettingsGroup
		{
		}

		public class ColorBleedingSettings : SettingsGroup
		{
		}

		[Presets]
		public PresetParameter preset;

		[Tooltip("The mode of the AO.")]
		[Space(6f)]
		[GeneralSettings]
		public ModeParameter mode;

		[Tooltip("The rendering path used for AO. Temporary settings as for now rendering path is internal to renderer settings.")]
		[GeneralSettings]
		[Space(6f)]
		public RenderingPathParameter renderingPath;

		[Tooltip("The quality of the AO.")]
		[Space(6f)]
		[GeneralSettings]
		public QualityParameter quality;

		[GeneralSettings]
		[Tooltip("The deinterleaving factor.")]
		public DeinterleavingParameter deinterleaving;

		[GeneralSettings]
		[Tooltip("The resolution at which the AO is calculated.")]
		public ResolutionParameter resolution;

		[Tooltip("The type of noise to use.")]
		[Space(10f)]
		[GeneralSettings]
		public NoiseTypeParameter noiseType;

		[Tooltip("The debug mode actually displayed on screen.")]
		[GeneralSettings]
		[Space(10f)]
		public DebugModeParameter debugMode;

		[Tooltip("AO radius: this is the distance outside which occluders are ignored.")]
		[Space(6f)]
		[AOSettings]
		public ClampedFloatParameter radius;

		[AOSettings]
		[Tooltip("Maximum radius in pixels: this prevents the radius to grow too much with close-up object and impact on performances.")]
		public ClampedFloatParameter maxRadiusPixels;

		[AOSettings]
		[Tooltip("For low-tessellated geometry, occlusion variations tend to appear at creases and ridges, which betray the underlying tessellation. To remove these artifacts, we use an angle bias parameter which restricts the hemisphere.")]
		public ClampedFloatParameter bias;

		[Tooltip("This value allows to scale up the ambient occlusion values.")]
		[AOSettings]
		public ClampedFloatParameter intensity;

		[Tooltip("Enable/disable MultiBounce approximation.")]
		[AOSettings]
		public BoolParameter useMultiBounce;

		[Tooltip("MultiBounce approximation influence.")]
		[AOSettings]
		public ClampedFloatParameter multiBounceInfluence;

		[Tooltip("How much AO affect direct lighting.")]
		[AOSettings]
		public ClampedFloatParameter directLightingStrength;

		[AOSettings]
		[Tooltip("The amount of AO offscreen samples are contributing.")]
		public ClampedFloatParameter offscreenSamplesContribution;

		[Space(10f)]
		[AOSettings]
		[Tooltip("The max distance to display AO.")]
		public FloatParameter maxDistance;

		[Tooltip("The distance before max distance at which AO start to decrease.")]
		[AOSettings]
		public FloatParameter distanceFalloff;

		[Space(10f)]
		[AOSettings]
		[Tooltip("The type of per pixel normals to use.")]
		public PerPixelNormalsParameter perPixelNormals;

		[Space(10f)]
		[Tooltip("This setting allow you to set the base color if the AO, the alpha channel value is unused.")]
		[AOSettings]
		public ColorParameter baseColor;

		[TemporalFilterSettings]
		[Space(6f)]
		[ParameterDisplayName("Enabled")]
		public BoolParameter temporalFilterEnabled;

		[Tooltip("The type of variance clipping to use.")]
		[TemporalFilterSettings]
		public VarianceClippingParameter varianceClipping;

		[Space(6f)]
		[ParameterDisplayName("Type")]
		[BlurSettings]
		[Tooltip("The type of blur to use.")]
		public BlurTypeParameter blurType;

		[Space(10f)]
		[Tooltip("This parameter controls the depth-dependent weight of the bilateral filter, to avoid bleeding across edges. A zero sharpness is a pure Gaussian blur. Increasing the blur sharpness removes bleeding by using lower weights for samples with large depth delta from the current pixel.")]
		[BlurSettings]
		public ClampedFloatParameter sharpness;

		[ColorBleedingSettings]
		[ParameterDisplayName("Enabled")]
		[Space(6f)]
		public BoolParameter colorBleedingEnabled;

		[Tooltip("This value allows to control the saturation of the color bleeding.")]
		[ColorBleedingSettings]
		[Space(10f)]
		public ClampedFloatParameter saturation;

		[Tooltip("Use masking on emissive pixels")]
		[ColorBleedingSettings]
		public ClampedFloatParameter brightnessMask;

		[Tooltip("Brightness level where masking starts/ends")]
		[ColorBleedingSettings]
		public MinMaxFloatParameter brightnessMaskRange;

		public void EnableHBAO(bool enable)
		{
		}

		public Preset GetCurrentPreset()
		{
			return default(Preset);
		}

		public void ApplyPreset(Preset preset)
		{
		}

		public Mode GetMode()
		{
			return default(Mode);
		}

		public void SetMode(Mode mode)
		{
		}

		public RenderingPath GetRenderingPath()
		{
			return default(RenderingPath);
		}

		public void SetRenderingPath(RenderingPath renderingPath)
		{
		}

		public Quality GetQuality()
		{
			return default(Quality);
		}

		public void SetQuality(Quality quality)
		{
		}

		public Deinterleaving GetDeinterleaving()
		{
			return default(Deinterleaving);
		}

		public void SetDeinterleaving(Deinterleaving deinterleaving)
		{
		}

		public Resolution GetResolution()
		{
			return default(Resolution);
		}

		public void SetResolution(Resolution resolution)
		{
		}

		public NoiseType GetNoiseType()
		{
			return default(NoiseType);
		}

		public void SetNoiseType(NoiseType noiseType)
		{
		}

		public DebugMode GetDebugMode()
		{
			return default(DebugMode);
		}

		public void SetDebugMode(DebugMode debugMode)
		{
		}

		public float GetAoRadius()
		{
			return 0f;
		}

		public void SetAoRadius(float radius)
		{
		}

		public float GetAoMaxRadiusPixels()
		{
			return 0f;
		}

		public void SetAoMaxRadiusPixels(float maxRadiusPixels)
		{
		}

		public float GetAoBias()
		{
			return 0f;
		}

		public void SetAoBias(float bias)
		{
		}

		public float GetAoOffscreenSamplesContribution()
		{
			return 0f;
		}

		public void SetAoOffscreenSamplesContribution(float offscreenSamplesContribution)
		{
		}

		public float GetAoMaxDistance()
		{
			return 0f;
		}

		public void SetAoMaxDistance(float maxDistance)
		{
		}

		public float GetAoDistanceFalloff()
		{
			return 0f;
		}

		public void SetAoDistanceFalloff(float distanceFalloff)
		{
		}

		public PerPixelNormals GetAoPerPixelNormals()
		{
			return default(PerPixelNormals);
		}

		public void SetAoPerPixelNormals(PerPixelNormals perPixelNormals)
		{
		}

		public Color GetAoColor()
		{
			return default(Color);
		}

		public void SetAoColor(Color baseColor)
		{
		}

		public float GetAoIntensity()
		{
			return 0f;
		}

		public void SetAoIntensity(float intensity)
		{
		}

		public bool UseMultiBounce()
		{
			return false;
		}

		public void EnableMultiBounce(bool enabled = true)
		{
		}

		public float GetAoMultiBounceInfluence()
		{
			return 0f;
		}

		public void SetAoMultiBounceInfluence(float multiBounceInfluence)
		{
		}

		public bool IsTemporalFilterEnabled()
		{
			return false;
		}

		public void EnableTemporalFilter(bool enabled = true)
		{
		}

		public VarianceClipping GetTemporalFilterVarianceClipping()
		{
			return default(VarianceClipping);
		}

		public void SetTemporalFilterVarianceClipping(VarianceClipping varianceClipping)
		{
		}

		public BlurType GetBlurType()
		{
			return default(BlurType);
		}

		public void SetBlurType(BlurType blurType)
		{
		}

		public float GetBlurSharpness()
		{
			return 0f;
		}

		public void SetBlurSharpness(float sharpness)
		{
		}

		public bool IsColorBleedingEnabled()
		{
			return false;
		}

		public void EnableColorBleeding(bool enabled = true)
		{
		}

		public float GetColorBleedingSaturation()
		{
			return 0f;
		}

		public void SetColorBleedingSaturation(float saturation)
		{
		}

		public float GetColorBleedingBrightnessMask()
		{
			return 0f;
		}

		public void SetColorBleedingBrightnessMask(float brightnessMask)
		{
		}

		public Vector2 GetColorBleedingBrightnessMaskRange()
		{
			return default(Vector2);
		}

		public void SetColorBleedingBrightnessMaskRange(Vector2 brightnessMaskRange)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}
