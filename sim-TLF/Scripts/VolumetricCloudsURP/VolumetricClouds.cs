using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
[VolumeComponentMenu("Sky/Volumetric Clouds (URP)")]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[HelpURL("https://github.com/jiaozi158/UnityVolumetricCloudsURP/tree/main")]
public class VolumetricClouds : VolumeComponent, IPostProcessComponent
{
	public enum CloudShadowResolution
	{
		VeryLow64 = 0x40,
		Low128 = 0x80,
		Medium256 = 0x100,
		High512 = 0x200,
		Ultra1024 = 0x400
	}

	public enum CloudPresets
	{
		Sparse = 0,
		Cloudy = 1,
		Overcast = 2,
		Stormy = 3,
		Custom = 4
	}

	[Serializable]
	public sealed class CloudPresetsParameter : VolumeParameter<CloudPresets>
	{
		public CloudPresetsParameter(CloudPresets value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	public enum CloudFadeInMode
	{
		Automatic = 0,
		Manual = 1
	}

	[Serializable]
	public sealed class CloudFadeInParameter : VolumeParameter<CloudFadeInMode>
	{
		public CloudFadeInParameter(CloudFadeInMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Serializable]
	public sealed class CloudShadowResolutionParameter : VolumeParameter<CloudShadowResolution>
	{
		public CloudShadowResolutionParameter(CloudShadowResolution value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}

	[Header("General")]
	[Tooltip("Enable/Disable the volumetric clouds effect.")]
	public BoolParameter state = new BoolParameter(value: false, BoolParameter.DisplayType.EnumPopup, overrideState: true);

	[Tooltip("Indicates whether the clouds are part of the scene or rendered into the skybox.")]
	public BoolParameter localClouds = new BoolParameter(value: false, BoolParameter.DisplayType.Checkbox);

	[Header("Shape")]
	[InspectorName("Cloud Preset")]
	[SerializeField]
	[Tooltip("Specifies the weather preset in Simple mode.")]
	private CloudPresetsParameter m_CloudPreset = new CloudPresetsParameter(CloudPresets.Cloudy);

	[Tooltip("Controls the global density of the cloud volume.")]
	public ClampedFloatParameter densityMultiplier = new ClampedFloatParameter(0.4f, 0f, 1f);

	[Tooltip("Controls the density (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
	public AnimationCurveParameter densityCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.15f, 1f), new Keyframe(1f, 0.1f)));

	[Tooltip("Controls the larger noise passing through the cloud coverage. A higher value will yield less cloud coverage and smaller clouds.")]
	public ClampedFloatParameter shapeFactor = new ClampedFloatParameter(0.9f, 0f, 1f);

	[Tooltip("Controls the size of the larger noise passing through the cloud coverage.")]
	public MinFloatParameter shapeScale = new MinFloatParameter(5f, 0.1f);

	[Tooltip("Controls the smaller noise on the edge of the clouds. A higher value will erode clouds more significantly.")]
	public ClampedFloatParameter erosionFactor = new ClampedFloatParameter(0.8f, 0f, 1f);

	[Tooltip("Controls the size of the smaller noise passing through the cloud coverage.")]
	public MinFloatParameter erosionScale = new MinFloatParameter(107f, 1f);

	[Tooltip("Controls the erosion (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
	public AnimationCurveParameter erosionCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0.9f), new Keyframe(1f, 1f)));

	[Tooltip("Controls the ambient occlusion (Y axis) of the volumetric clouds as a function of the height (X Axis) inside the cloud volume.")]
	public AnimationCurveParameter ambientOcclusionCurve = new AnimationCurveParameter(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.25f, 0.4f), new Keyframe(1f, 0f)));

	[Tooltip("When enabled, an additional noise should be evaluated for the clouds in the advanced and manual modes. This increases signficantly the cost of the volumetric clouds.")]
	public BoolParameter microErosion = new BoolParameter(value: false, BoolParameter.DisplayType.Checkbox);

	[Tooltip("Controls the smallest noise on the edge of the clouds. A higher value will erode clouds more.")]
	public ClampedFloatParameter microErosionFactor = new ClampedFloatParameter(0.5f, 0f, 1f);

	[Tooltip("Controls the size of the smaller noise passing through the cloud coverage.")]
	public MinFloatParameter microErosionScale = new MinFloatParameter(200f, 0.1f);

	[Tooltip("Controls the altitude of the bottom of the volumetric clouds volume in meters.")]
	public MinFloatParameter bottomAltitude = new MinFloatParameter(1200f, 0.01f);

	[Tooltip("Controls the size of the volumetric clouds volume in meters.")]
	public MinFloatParameter altitudeRange = new MinFloatParameter(2000f, 100f);

	[Tooltip("Controls the world space offset applied when evaluating the larger noise passing through the cloud coverage.")]
	public Vector3Parameter shapeOffset = new Vector3Parameter(Vector3.zero);

	[Tooltip("Controls the curvature of the cloud volume which defines the distance at which the clouds intersect with the horizon.")]
	public ClampedFloatParameter earthCurvature = new ClampedFloatParameter(0f, 0f, 1f);

	[Header("Wind")]
	[Tooltip("Sets the global horizontal wind speed in kilometers per hour.")]
	public FloatParameter globalSpeed = new FloatParameter(0f);

	[Tooltip("Controls the global orientation of the wind relative to the X world vector.")]
	public ClampedFloatParameter globalOrientation = new ClampedFloatParameter(0f, 0f, 360f);

	[AdditionalProperty]
	[Tooltip("Controls the multiplier to the speed of the larger cloud shapes.")]
	public ClampedFloatParameter shapeSpeedMultiplier = new ClampedFloatParameter(1f, 0f, 1f);

	[AdditionalProperty]
	[Tooltip("Controls the multiplier to the speed of the erosion cloud shapes.")]
	public ClampedFloatParameter erosionSpeedMultiplier = new ClampedFloatParameter(0.25f, 0f, 1f);

	[AdditionalProperty]
	[Tooltip("Controls the intensity of the wind-based altitude distortion of the clouds.")]
	public ClampedFloatParameter altitudeDistortion = new ClampedFloatParameter(0.25f, -1f, 1f);

	[AdditionalProperty]
	[Tooltip("Controls the vertical wind speed of the larger cloud shapes.")]
	public FloatParameter verticalShapeWindSpeed = new FloatParameter(0f);

	[AdditionalProperty]
	[Tooltip("Controls the vertical wind speed of the erosion cloud shapes.")]
	public FloatParameter verticalErosionWindSpeed = new FloatParameter(0f);

	[Header("Lighting")]
	[Tooltip("Controls the influence of the light probes on the cloud volume. A lower value will suppress the ambient light and produce darker clouds overall.")]
	public ClampedFloatParameter ambientLightProbeDimmer = new ClampedFloatParameter(1f, 0f, 2f);

	[Tooltip("Controls the influence of the sun light on the cloud volume. A lower value will suppress the sun light and produce darker clouds overall.")]
	public ClampedFloatParameter sunLightDimmer = new ClampedFloatParameter(1f, 0f, 2f);

	[AdditionalProperty]
	[Tooltip("Controls how much Erosion Factor is taken into account when computing ambient occlusion. The Erosion Factor parameter is editable in the custom preset, Advanced and Manual Modes.")]
	public ClampedFloatParameter erosionOcclusion = new ClampedFloatParameter(0.1f, 0f, 1f);

	[Tooltip("Specifies the tint of the cloud scattering color.")]
	public ColorParameter scatteringTint = new ColorParameter(new Color(0f, 0f, 0f, 1f));

	[AdditionalProperty]
	[Tooltip("Controls the amount of local scattering in the clouds. A higher value may produce a more powdery or diffused aspect.")]
	public ClampedFloatParameter powderEffectIntensity = new ClampedFloatParameter(0.25f, 0f, 1f);

	[AdditionalProperty]
	[Tooltip("Controls the amount of multi-scattering inside the cloud.")]
	public ClampedFloatParameter multiScattering = new ClampedFloatParameter(0.5f, 0f, 1f);

	[Header("Shadows")]
	[Tooltip("When enabled, URP evaluates the Volumetric Clouds' shadows. To render the shadows, this property overrides the cookie in the main directional light.")]
	public BoolParameter shadows = new BoolParameter(value: false);

	[Tooltip("Specifies the resolution of the volumetric clouds shadow map.")]
	public CloudShadowResolutionParameter shadowResolution = new CloudShadowResolutionParameter(CloudShadowResolution.Medium256);

	[Tooltip("Sets the size of the area covered by shadow around the camera.")]
	[AdditionalProperty]
	public MinFloatParameter shadowDistance = new MinFloatParameter(8000f, 1000f);

	[Tooltip("Controls the opacity of the volumetric clouds shadow.")]
	[AdditionalProperty]
	public ClampedFloatParameter shadowOpacity = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Controls the shadow opacity when outside the area covered by the volumetric clouds shadow.")]
	[AdditionalProperty]
	public ClampedFloatParameter shadowOpacityFallback = new ClampedFloatParameter(0f, 0f, 1f);

	[Header("Quality")]
	[Tooltip("Temporal accumulation increases the visual quality of clouds by decreasing the noise. A higher value will give you better quality but can create ghosting.")]
	public ClampedFloatParameter temporalAccumulationFactor = new ClampedFloatParameter(0.95f, 0f, 1f);

	[Tooltip("Specifies the strength of the perceptual blending for the volumetric clouds. This value should be treated as flag and only be set to 0.0 or 1.0.")]
	public ClampedFloatParameter perceptualBlending = new ClampedFloatParameter(1f, 0f, 1f);

	[Tooltip("Controls the number of steps when evaluating the clouds' transmittance. A higher value may lead to a lower noise level and longer view distance, but at a higher cost.")]
	public ClampedIntParameter numPrimarySteps = new ClampedIntParameter(32, 24, 256);

	[Tooltip("Controls the number of steps when evaluating the clouds' lighting. A higher value will lead to smoother lighting and improved self-shadowing, but at a higher cost.")]
	public ClampedIntParameter numLightSteps = new ClampedIntParameter(2, 1, 16);

	[Tooltip("Controls the mode in which the clouds fade in when close to the camera's near plane.")]
	public CloudFadeInParameter fadeInMode = new CloudFadeInParameter(CloudFadeInMode.Automatic);

	[Tooltip("Controls the minimal distance at which clouds start appearing.")]
	public MinFloatParameter fadeInStart = new MinFloatParameter(0f, 0f);

	[Tooltip("Controls the distance that it takes for the clouds to reach their complete density.")]
	public MinFloatParameter fadeInDistance = new MinFloatParameter(5000f, 0.01f);

	private static readonly AnimationCurve s_SparseDensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.75f, 1f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_SparseErosionCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0.9f), new Keyframe(1f, 1f));

	private static readonly AnimationCurve s_SparseAmbientOcclusionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.25f, 0.5f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_CloudyDensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.15f, 1f), new Keyframe(1f, 0.1f));

	private static readonly AnimationCurve s_CloudyErosionCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0.9f), new Keyframe(1f, 1f));

	private static readonly AnimationCurve s_CloudyAmbientOcclusionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.25f, 0.4f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_OvercastDensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.9f, 0f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_OvercastErosionCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.1f, 0.9f), new Keyframe(1f, 1f));

	private static readonly AnimationCurve s_OvercastAmbientOcclusionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_StormyDensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.037f, 1f), new Keyframe(0.6f, 1f), new Keyframe(1f, 0f));

	private static readonly AnimationCurve s_StormyErosionCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.05f, 0.8f), new Keyframe(0.2438f, 0.9498f), new Keyframe(0.5f, 1f), new Keyframe(0.93f, 0.9268f), new Keyframe(1f, 1f));

	private static readonly AnimationCurve s_StormyAmbientOcclusionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.1f, 0.4f), new Keyframe(1f, 0f));

	public CloudPresets cloudPreset
	{
		get
		{
			return m_CloudPreset.value;
		}
		set
		{
			m_CloudPreset.value = value;
			ApplyCurrentCloudPreset();
		}
	}

	public bool IsActive()
	{
		return state.value;
	}

	public bool IsTileCompatible()
	{
		return false;
	}

	private void ApplyCurrentCloudPreset()
	{
		bool value = microErosion.value;
		switch (cloudPreset)
		{
		case CloudPresets.Sparse:
			densityMultiplier.value = 0.4f;
			if (value)
			{
				shapeFactor.value = 0.925f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.85f;
				erosionScale.value = 75f;
				microErosionFactor.value = 0.65f;
				microErosionScale.value = 300f;
			}
			else
			{
				shapeFactor.value = 0.95f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.8f;
				erosionScale.value = 107f;
			}
			densityCurve.value = s_SparseDensityCurve;
			erosionCurve.value = s_SparseErosionCurve;
			ambientOcclusionCurve.value = s_SparseAmbientOcclusionCurve;
			bottomAltitude.value = 3000f;
			altitudeRange.value = 1000f;
			break;
		case CloudPresets.Cloudy:
			densityMultiplier.value = 0.4f;
			if (value)
			{
				shapeFactor.value = 0.875f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.9f;
				erosionScale.value = 75f;
				microErosionFactor.value = 0.65f;
				microErosionScale.value = 300f;
			}
			else
			{
				shapeFactor.value = 0.9f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.8f;
				erosionScale.value = 107f;
			}
			densityCurve.value = s_CloudyDensityCurve;
			erosionCurve.value = s_CloudyErosionCurve;
			ambientOcclusionCurve.value = s_CloudyAmbientOcclusionCurve;
			bottomAltitude.value = 1200f;
			altitudeRange.value = 2000f;
			break;
		case CloudPresets.Overcast:
			densityMultiplier.value = 0.3f;
			if (value)
			{
				shapeFactor.value = 0.45f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.7f;
				erosionScale.value = 75f;
				microErosionFactor.value = 0.5f;
				microErosionScale.value = 300f;
			}
			else
			{
				shapeFactor.value = 0.5f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.5f;
				erosionScale.value = 107f;
			}
			densityCurve.value = s_OvercastDensityCurve;
			erosionCurve.value = s_OvercastErosionCurve;
			ambientOcclusionCurve.value = s_OvercastAmbientOcclusionCurve;
			bottomAltitude.value = 1500f;
			altitudeRange.value = 2500f;
			break;
		case CloudPresets.Stormy:
			densityMultiplier.value = 0.35f;
			if (value)
			{
				shapeFactor.value = 0.825f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.9f;
				erosionScale.value = 75f;
				microErosionFactor.value = 0.6f;
				microErosionScale.value = 300f;
			}
			else
			{
				shapeFactor.value = 0.85f;
				shapeScale.value = 5f;
				erosionFactor.value = 0.75f;
				erosionScale.value = 107f;
			}
			densityCurve.value = s_StormyDensityCurve;
			erosionCurve.value = s_StormyErosionCurve;
			ambientOcclusionCurve.value = s_StormyAmbientOcclusionCurve;
			bottomAltitude.value = 1000f;
			altitudeRange.value = 5000f;
			break;
		}
	}
}
