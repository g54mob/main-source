using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RadiantGI.Universal
{
	[ExecuteInEditMode]
	[VolumeComponentMenu("Kronnect/Radiant Global Illumination")]
	public class RadiantGlobalIllumination : VolumeComponent, IPostProcessComponent
	{
		public enum DebugView
		{
			None = 0,
			Albedo = 1,
			Normals = 2,
			Specular = 3,
			Depth = 4,
			Raycast = 20,
			DownscaledHalf = 30,
			DownscaledQuarter = 40,
			ReflectiveShadowMap = 41,
			UpscaleToHalf = 50,
			TemporalAccumulationBuffer = 60,
			FinalGI = 70
		}

		[Serializable]
		public sealed class CompareFunctionParameter : VolumeParameter<CompareFunction>
		{
		}

		[Serializable]
		public sealed class DebugViewParameter : VolumeParameter<DebugView>
		{
		}

		[Tooltip("Intensity of the indirect lighting.")]
		public FloatParameter indirectIntensity;

		[Tooltip("Distance attenuation applied to indirect lighting. Reduces indirect intensity by square of distance.")]
		public ClampedFloatParameter indirectDistanceAttenuation;

		[Tooltip("Maximum brightness of indirect source.")]
		public FloatParameter indirectMaxSourceBrightness;

		[Tooltip("Determines how much influence has the surface normal map when receiving indirect lighting.")]
		public ClampedFloatParameter normalMapInfluence;

		[Tooltip("Add one ray bounce.")]
		public BoolParameter rayBounce;

		[Tooltip("Only in forward rendering mode: uses pixel luma to enhance results by adding variety to the effect based on the perceptual brigthness. Set this value to 0 to disable this feature.")]
		public FloatParameter lumaInfluence;

		[Tooltip("Intensity of the near field obscurance effect. Darkens surfaces occluded by other nearby surfaces.")]
		public FloatParameter nearFieldObscurance;

		[Tooltip("Spread or radius of the near field obscurance effect")]
		public ClampedFloatParameter nearFieldObscuranceSpread;

		[Tooltip("Maximum distance of Near Field Obscurance effect")]
		public FloatParameter nearFieldObscuranceMaxCameraDistance;

		[Tooltip("Distance threshold of the occluder")]
		public ClampedFloatParameter nearFieldObscuranceOccluderDistance;

		[ColorUsage(false)]
		[Tooltip("Tint color of Near Field Obscurance effect")]
		public ColorParameter nearFieldObscuranceTintColor;

		[Tooltip("Enable user-defined light emitters in the scene.")]
		public BoolParameter virtualEmitters;

		[Tooltip("Number of rays per pixel")]
		public ClampedIntParameter rayCount;

		[Tooltip("Max ray length. Increasing this value may also require increasing the 'Max Samples' value to avoid losing quality.")]
		public FloatParameter rayMaxLength;

		[Tooltip("Max samples taken during raymarch.")]
		public IntParameter rayMaxSamples;

		[Tooltip("Jitter adds a random offset to the ray direction to reduce banding. Useful when using low sample count.")]
		public FloatParameter rayJitter;

		[Tooltip("The assumed thickness for any geometry. Used to determine if ray crosses a surface.")]
		public FloatParameter thickness;

		[Tooltip("Improves raymarch accuracy by using binary search.")]
		public BoolParameter rayBinarySearch;

		[Tooltip("In case a ray miss a target, reuse rays from previous frames.")]
		public BoolParameter fallbackReuseRays;

		[Tooltip("If a ray misses a target, reuse result from history buffer. This value is the intensity of the previous color in case the ray misses the target.")]
		public ClampedFloatParameter rayReuse;

		[Tooltip("In case a ray miss a target, use nearby probes if they're available.")]
		public BoolParameter fallbackReflectionProbes;

		[Tooltip("Custom global probe intensity multiplier. Note that each probe has also an intensity property.")]
		public FloatParameter probesIntensity;

		[Tooltip("In case a ray miss a target, use reflective shadow map data from the main directional light. You need to add the ReflectiveShadowMap script to the directional light to use this feature.")]
		public BoolParameter fallbackReflectiveShadowMap;

		public ClampedFloatParameter reflectiveShadowMapIntensity;

		[Tooltip("Reduces resolution of all GI stages improving performance")]
		public ClampedFloatParameter downsampling;

		[Tooltip("Raytracing accuracy. Reducing this value will shrink the depth buffer used during raytracing, improving performance in exchange of accuracy.")]
		public ClampedIntParameter raytracerAccuracy;

		[Tooltip("Extra blur passes")]
		public ClampedIntParameter smoothing;

		[Tooltip("Uses motion vectors to blend into a history buffer to reduce flickering. Only applies in play mode.")]
		public BoolParameter temporalReprojection;

		[Tooltip("Reaction speed to screen changes. Higher values reduces ghosting but also the smoothing.")]
		public FloatParameter temporalResponseSpeed;

		[Tooltip("Reaction speed to camera position change. Higher values reduces ghosting when camera moves.")]
		public FloatParameter temporalCameraTranslationResponse;

		[Tooltip("Difference in depth with current frame to discard history buffer when reusing rays.")]
		public FloatParameter temporalDepthRejection;

		[Tooltip("Allowed difference in color between history and current GI buffers.")]
		public ClampedFloatParameter temporalChromaThreshold;

		[Tooltip("Renders the effect also in edit mode (when not in play-mode).")]
		public BoolParameter showInEditMode;

		[Tooltip("Renders the effect also in Scene View.")]
		public BoolParameter showInSceneView;

		[Tooltip("Computes GI emitted by objects with a minimum luminosity.")]
		public FloatParameter brightnessThreshold;

		[Tooltip("Maximum GI brightness.")]
		public FloatParameter brightnessMax;

		[Tooltip("Amount of GI which adds to specular surfaces. Reduce this value to avoid overexposition of shiny materials.")]
		public ClampedFloatParameter specularContribution;

		[Tooltip("Attenuates GI brightness from nearby surfaces.")]
		public FloatParameter nearCameraAttenuation;

		[Tooltip("Adjusted color saturation for the computed GI.")]
		public ClampedFloatParameter saturation;

		[Tooltip("Applies GI only inside the post processing volume (use only if the volume is local)")]
		public BoolParameter limitToVolumeBounds;

		[Tooltip("Enables stencil check during GI composition. This option let you exclude GI over certain objects that also use stencil buffer.")]
		public BoolParameter stencilCheck;

		public IntParameter stencilValue;

		public CompareFunctionParameter stencilCompareFunction;

		[Tooltip("Integration with URP native screen space ambient occlusion (also with HBAO in Lit AO mode). Amount of ambient occlusion that influences indirect lighting created by Radiant.")]
		public ClampedFloatParameter aoInfluence;

		public DebugViewParameter debugView;

		[Tooltip("Depth values multiplier for the depth debug view")]
		public FloatParameter debugDepthMultiplier;

		public BoolParameter compareMode;

		public BoolParameter compareSameSide;

		public ClampedFloatParameter comparePanning;

		public ClampedFloatParameter compareLineAngle;

		public ClampedFloatParameter compareLineWidth;

		public bool IsActive()
		{
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}
	}
}
