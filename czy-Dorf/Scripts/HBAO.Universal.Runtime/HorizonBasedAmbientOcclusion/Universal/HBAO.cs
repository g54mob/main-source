using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HorizonBasedAmbientOcclusion.Universal
{
	[ExecuteInEditMode]
	public class HBAO : VolumeComponent
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
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class ModeParameter : VolumeParameter<Mode>
		{
			public ModeParameter(Mode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class RenderingPathParameter : VolumeParameter<RenderingPath>
		{
			public RenderingPathParameter(RenderingPath value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class QualityParameter : VolumeParameter<Quality>
		{
			public QualityParameter(Quality value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class DeinterleavingParameter : VolumeParameter<Deinterleaving>
		{
			public DeinterleavingParameter(Deinterleaving value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class ResolutionParameter : VolumeParameter<Resolution>
		{
			public ResolutionParameter(Resolution value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class NoiseTypeParameter : VolumeParameter<NoiseType>
		{
			public NoiseTypeParameter(NoiseType value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class DebugModeParameter : VolumeParameter<DebugMode>
		{
			public DebugModeParameter(DebugMode value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class PerPixelNormalsParameter : VolumeParameter<PerPixelNormals>
		{
			public PerPixelNormalsParameter(PerPixelNormals value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class VarianceClippingParameter : VolumeParameter<VarianceClipping>
		{
			public VarianceClippingParameter(VarianceClipping value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class BlurTypeParameter : VolumeParameter<BlurType>
		{
			public BlurTypeParameter(BlurType value, bool overrideState = false)
				: base(value, overrideState)
			{
			}
		}

		[Serializable]
		public sealed class MinMaxFloatParameter : VolumeParameter<Vector2>
		{
			public float min;

			public float max;

			public MinMaxFloatParameter(Vector2 value, float min, float max, bool overrideState = false)
				: base(value, overrideState)
			{
				this.min = min;
				this.max = max;
			}
		}

		public PresetParameter preset = new PresetParameter(Preset.Normal);

		public ModeParameter mode = new ModeParameter(Mode.Normal);

		public RenderingPathParameter renderingPath = new RenderingPathParameter(RenderingPath.Forward);

		public QualityParameter quality = new QualityParameter(Quality.Medium);

		public DeinterleavingParameter deinterleaving = new DeinterleavingParameter(Deinterleaving.Disabled);

		public ResolutionParameter resolution = new ResolutionParameter(Resolution.Full);

		public NoiseTypeParameter noiseType = new NoiseTypeParameter(NoiseType.Dither);

		public DebugModeParameter debugMode = new DebugModeParameter(DebugMode.Disabled);

		public ClampedFloatParameter radius = new ClampedFloatParameter(0.8f, 0.25f, 5f);

		public ClampedFloatParameter maxRadiusPixels = new ClampedFloatParameter(128f, 16f, 256f);

		public ClampedFloatParameter bias = new ClampedFloatParameter(0.05f, 0f, 0.5f);

		public ClampedFloatParameter intensity = new ClampedFloatParameter(0f, 0f, 4f);

		public BoolParameter useMultiBounce = new BoolParameter(value: false);

		public ClampedFloatParameter multiBounceInfluence = new ClampedFloatParameter(1f, 0f, 1f);

		public ClampedFloatParameter directLightingStrength = new ClampedFloatParameter(0.25f, 0f, 1f);

		public ClampedFloatParameter offscreenSamplesContribution = new ClampedFloatParameter(0f, 0f, 1f);

		public FloatParameter maxDistance = new FloatParameter(150f);

		public FloatParameter distanceFalloff = new FloatParameter(50f);

		public PerPixelNormalsParameter perPixelNormals = new PerPixelNormalsParameter(PerPixelNormals.Camera);

		public ColorParameter baseColor = new ColorParameter(Color.black);

		public BoolParameter temporalFilterEnabled = new BoolParameter(value: false);

		public VarianceClippingParameter varianceClipping = new VarianceClippingParameter(VarianceClipping._4Tap);

		public BlurTypeParameter blurType = new BlurTypeParameter(BlurType.Medium);

		public ClampedFloatParameter sharpness = new ClampedFloatParameter(8f, 0f, 16f);

		public BoolParameter colorBleedingEnabled = new BoolParameter(value: false);

		public ClampedFloatParameter saturation = new ClampedFloatParameter(1f, 0f, 4f);

		public ClampedFloatParameter brightnessMask = new ClampedFloatParameter(1f, 0f, 1f);

		public MinMaxFloatParameter brightnessMaskRange = new MinMaxFloatParameter(new Vector2(0f, 0.5f), 0f, 2f);

		public void EnableHBAO(bool enable)
		{
			intensity.overrideState = enable;
		}

		public Preset GetCurrentPreset()
		{
			return preset.value;
		}

		public void ApplyPreset(Preset preset)
		{
			if (preset == Preset.Custom)
			{
				this.preset.Override(preset);
				return;
			}
			DebugMode value = debugMode.value;
			bool overrideState = debugMode.overrideState;
			SetAllOverridesTo(state: false);
			debugMode.overrideState = overrideState;
			debugMode.value = value;
			switch (preset)
			{
			case Preset.FastestPerformance:
				SetQuality(Quality.Lowest);
				SetAoRadius(0.5f);
				SetAoMaxRadiusPixels(64f);
				SetBlurType(BlurType.ExtraWide);
				break;
			case Preset.FastPerformance:
				SetQuality(Quality.Low);
				SetAoRadius(0.5f);
				SetAoMaxRadiusPixels(64f);
				SetBlurType(BlurType.Wide);
				break;
			case Preset.HighQuality:
				SetQuality(Quality.High);
				SetAoRadius(1f);
				break;
			case Preset.HighestQuality:
				SetQuality(Quality.Highest);
				SetAoRadius(1.2f);
				SetAoMaxRadiusPixels(256f);
				SetBlurType(BlurType.Narrow);
				break;
			}
			this.preset.Override(preset);
		}

		public Mode GetMode()
		{
			return mode.value;
		}

		public void SetMode(Mode mode)
		{
			this.mode.Override(mode);
		}

		public RenderingPath GetRenderingPath()
		{
			return renderingPath.value;
		}

		public void SetRenderingPath(RenderingPath renderingPath)
		{
			this.renderingPath.Override(renderingPath);
		}

		public Quality GetQuality()
		{
			return quality.value;
		}

		public void SetQuality(Quality quality)
		{
			this.quality.Override(quality);
		}

		public Deinterleaving GetDeinterleaving()
		{
			return deinterleaving.value;
		}

		public void SetDeinterleaving(Deinterleaving deinterleaving)
		{
			this.deinterleaving.Override(deinterleaving);
		}

		public Resolution GetResolution()
		{
			return resolution.value;
		}

		public void SetResolution(Resolution resolution)
		{
			this.resolution.Override(resolution);
		}

		public NoiseType GetNoiseType()
		{
			return noiseType.value;
		}

		public void SetNoiseType(NoiseType noiseType)
		{
			this.noiseType.Override(noiseType);
		}

		public DebugMode GetDebugMode()
		{
			return debugMode.value;
		}

		public void SetDebugMode(DebugMode debugMode)
		{
			this.debugMode.Override(debugMode);
		}

		public float GetAoRadius()
		{
			return radius.value;
		}

		public void SetAoRadius(float radius)
		{
			this.radius.Override(Mathf.Clamp(radius, this.radius.min, this.radius.max));
		}

		public float GetAoMaxRadiusPixels()
		{
			return maxRadiusPixels.value;
		}

		public void SetAoMaxRadiusPixels(float maxRadiusPixels)
		{
			this.maxRadiusPixels.Override(Mathf.Clamp(maxRadiusPixels, this.maxRadiusPixels.min, this.maxRadiusPixels.max));
		}

		public float GetAoBias()
		{
			return bias.value;
		}

		public void SetAoBias(float bias)
		{
			this.bias.Override(Mathf.Clamp(bias, this.bias.min, this.bias.max));
		}

		public float GetAoOffscreenSamplesContribution()
		{
			return offscreenSamplesContribution.value;
		}

		public void SetAoOffscreenSamplesContribution(float offscreenSamplesContribution)
		{
			this.offscreenSamplesContribution.Override(Mathf.Clamp(offscreenSamplesContribution, this.offscreenSamplesContribution.min, this.offscreenSamplesContribution.max));
		}

		public float GetAoMaxDistance()
		{
			return maxDistance.value;
		}

		public void SetAoMaxDistance(float maxDistance)
		{
			this.maxDistance.Override(maxDistance);
		}

		public float GetAoDistanceFalloff()
		{
			return distanceFalloff.value;
		}

		public void SetAoDistanceFalloff(float distanceFalloff)
		{
			this.distanceFalloff.Override(distanceFalloff);
		}

		public PerPixelNormals GetAoPerPixelNormals()
		{
			return perPixelNormals.value;
		}

		public void SetAoPerPixelNormals(PerPixelNormals perPixelNormals)
		{
			this.perPixelNormals.Override(perPixelNormals);
		}

		public Color GetAoColor()
		{
			return baseColor.value;
		}

		public void SetAoColor(Color baseColor)
		{
			this.baseColor.Override(baseColor);
		}

		public float GetAoIntensity()
		{
			return intensity.value;
		}

		public void SetAoIntensity(float intensity)
		{
			this.intensity.Override(Mathf.Clamp(intensity, this.intensity.min, this.intensity.max));
		}

		public bool UseMultiBounce()
		{
			return useMultiBounce.value;
		}

		public void EnableMultiBounce(bool enabled = true)
		{
			useMultiBounce.Override(enabled);
		}

		public float GetAoMultiBounceInfluence()
		{
			return multiBounceInfluence.value;
		}

		public void SetAoMultiBounceInfluence(float multiBounceInfluence)
		{
			this.multiBounceInfluence.Override(Mathf.Clamp(multiBounceInfluence, this.multiBounceInfluence.min, this.multiBounceInfluence.max));
		}

		public bool IsTemporalFilterEnabled()
		{
			return temporalFilterEnabled.value;
		}

		public void EnableTemporalFilter(bool enabled = true)
		{
			temporalFilterEnabled.Override(enabled);
		}

		public VarianceClipping GetTemporalFilterVarianceClipping()
		{
			return varianceClipping.value;
		}

		public void SetTemporalFilterVarianceClipping(VarianceClipping varianceClipping)
		{
			this.varianceClipping.Override(varianceClipping);
		}

		public BlurType GetBlurType()
		{
			return blurType.value;
		}

		public void SetBlurType(BlurType blurType)
		{
			this.blurType.Override(blurType);
		}

		public float GetBlurSharpness()
		{
			return sharpness.value;
		}

		public void SetBlurSharpness(float sharpness)
		{
			this.sharpness.Override(Mathf.Clamp(sharpness, this.sharpness.min, this.sharpness.max));
		}

		public bool IsColorBleedingEnabled()
		{
			return colorBleedingEnabled.value;
		}

		public void EnableColorBleeding(bool enabled = true)
		{
			colorBleedingEnabled.Override(enabled);
		}

		public float GetColorBleedingSaturation()
		{
			return saturation.value;
		}

		public void SetColorBleedingSaturation(float saturation)
		{
			this.saturation.Override(Mathf.Clamp(saturation, this.saturation.min, this.saturation.max));
		}

		public float GetColorBleedingBrightnessMask()
		{
			return brightnessMask.value;
		}

		public void SetColorBleedingBrightnessMask(float brightnessMask)
		{
			this.brightnessMask.Override(Mathf.Clamp(brightnessMask, this.brightnessMask.min, this.brightnessMask.max));
		}

		public Vector2 GetColorBleedingBrightnessMaskRange()
		{
			return brightnessMaskRange.value;
		}

		public void SetColorBleedingBrightnessMaskRange(Vector2 brightnessMaskRange)
		{
			brightnessMaskRange.x = Mathf.Clamp(brightnessMaskRange.x, this.brightnessMaskRange.min, this.brightnessMaskRange.max);
			brightnessMaskRange.y = Mathf.Clamp(brightnessMaskRange.y, this.brightnessMaskRange.min, this.brightnessMaskRange.max);
			brightnessMaskRange.x = Mathf.Min(brightnessMaskRange.x, brightnessMaskRange.y);
			this.brightnessMaskRange.Override(brightnessMaskRange);
		}

		public bool IsActive()
		{
			if (intensity.overrideState)
			{
				return intensity.value > 0f;
			}
			return false;
		}

		public bool IsTileCompatible()
		{
			return true;
		}
	}
}
