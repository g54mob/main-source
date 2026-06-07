using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AmplifyOcclusion
{
	[Serializable]
	[PostProcess(typeof(AmplifyAmbientOcclusionRenderer), PostProcessEvent.AmbientOcclusion, "Amplify/Ambient Occlusion", true)]
	public sealed class AmplifyOcclusionEffect : PostProcessEffectSettings
	{
		[Header("Ambient Occlusion")]
		[Tooltip("How to inject the occlusion: Post Effect = Overlay, Deferred = Deferred Injection, Debug - Vizualize.")]
		public ApplicationMethodParameter ApplyMethod = new ApplicationMethodParameter
		{
			value = ApplicationMethod.PostEffect
		};

		[Tooltip("Number of samples per pass.")]
		public SampleCountParameter SampleCount = new SampleCountParameter
		{
			value = SampleCountLevel.Medium
		};

		[Tooltip("Source of per-pixel normals: None = All, Camera = Forward, GBuffer = Deferred.")]
		public PerPixelNormalsParameter PerPixelNormals = new PerPixelNormalsParameter
		{
			value = PerPixelNormalSource.Camera
		};

		[Tooltip("Final applied intensity of the occlusion effect.")]
		[Range(0f, 1f)]
		public FloatParameter Intensity = new FloatParameter
		{
			value = 1f
		};

		[Tooltip("Color tint for occlusion.")]
		public ColorParameter Tint = new ColorParameter
		{
			value = Color.black
		};

		[Tooltip("Radius spread of the occlusion.")]
		public FloatParameter Radius = new FloatParameter
		{
			value = 2f
		};

		[Tooltip("Power exponent attenuation of the occlusion.")]
		[Range(0f, 16f)]
		public FloatParameter PowerExponent = new FloatParameter
		{
			value = 1.8f
		};

		[Tooltip("Controls the initial occlusion contribution offset.")]
		[Range(0f, 0.99f)]
		public FloatParameter Bias = new FloatParameter
		{
			value = 0.05f
		};

		[Tooltip("Controls the thickness occlusion contribution.")]
		[Range(0f, 1f)]
		public FloatParameter Thickness = new FloatParameter
		{
			value = 1f
		};

		[Tooltip("Compute the Occlusion and Blur at half of the resolution.")]
		public BoolParameter Downsample = new BoolParameter
		{
			value = true
		};

		[Tooltip("Cache optimization for best performance / quality tradeoff.")]
		public BoolParameter CacheAware = new BoolParameter
		{
			value = true
		};

		[Header("Distance Fade")]
		[Tooltip("Control parameters at faraway.")]
		public BoolParameter FadeEnabled = new BoolParameter
		{
			value = false
		};

		[Tooltip("Distance in Unity unities that start to fade.")]
		public FloatParameter FadeStart = new FloatParameter
		{
			value = 100f
		};

		[Tooltip("Length distance to performe the transition.")]
		public FloatParameter FadeLength = new FloatParameter
		{
			value = 50f
		};

		[Tooltip("Final Intensity parameter.")]
		[Range(0f, 1f)]
		public FloatParameter FadeToIntensity = new FloatParameter
		{
			value = 0f
		};

		public ColorParameter FadeToTint = new ColorParameter
		{
			value = Color.black
		};

		[Tooltip("Final Radius parameter.")]
		public FloatParameter FadeToRadius = new FloatParameter
		{
			value = 2f
		};

		[Tooltip("Final PowerExponent parameter.")]
		[Range(0f, 16f)]
		public FloatParameter FadeToPowerExponent = new FloatParameter
		{
			value = 1f
		};

		[Tooltip("Final Thickness parameter.")]
		[Range(0f, 1f)]
		public FloatParameter FadeToThickness = new FloatParameter
		{
			value = 1f
		};

		[Header("Bilateral Blur")]
		public BoolParameter BlurEnabled = new BoolParameter
		{
			value = true
		};

		[Tooltip("Radius in screen pixels.")]
		[Range(1f, 4f)]
		public IntParameter BlurRadius = new IntParameter
		{
			value = 3
		};

		[Tooltip("Number of times that the Blur will repeat.")]
		[Range(1f, 4f)]
		public IntParameter BlurPasses = new IntParameter
		{
			value = 1
		};

		[Tooltip("Sharpness of blur edge-detection: 0 = Softer Edges, 20 = Sharper Edges.")]
		[Range(0f, 20f)]
		public FloatParameter BlurSharpness = new FloatParameter
		{
			value = 15f
		};

		[Header("Temporal Filter")]
		[Tooltip("Accumulates the effect over the time.")]
		public BoolParameter FilterEnabled = new BoolParameter
		{
			value = true
		};

		public BoolParameter FilterDownsample = new BoolParameter
		{
			value = true
		};

		[Tooltip("Controls the accumulation decayment: 0 = More flicker with less ghosting, 1 = Less flicker with more ghosting.")]
		[Range(0f, 1f)]
		public FloatParameter FilterBlending = new FloatParameter
		{
			value = 0.8f
		};

		[Tooltip("Controls the discard sensitivity based on the motion of the scene and objects.")]
		[Range(0f, 1f)]
		public FloatParameter FilterResponse = new FloatParameter
		{
			value = 0.5f
		};

		internal RenderTextureFormat m_occlusionRTFormat = RenderTextureFormat.RGHalf;

		private static bool formatChecked;

		private static bool formatSupported;

		private bool checkRenderTextureFormats()
		{
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB32) && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
			{
				m_occlusionRTFormat = RenderTextureFormat.RGHalf;
				if (!SystemInfo.SupportsRenderTextureFormat(m_occlusionRTFormat))
				{
					m_occlusionRTFormat = RenderTextureFormat.RGFloat;
					if (!SystemInfo.SupportsRenderTextureFormat(m_occlusionRTFormat))
					{
						m_occlusionRTFormat = RenderTextureFormat.ARGBHalf;
					}
				}
				return true;
			}
			return false;
		}

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (!formatChecked)
			{
				formatSupported = checkRenderTextureFormats();
				formatChecked = true;
			}
			if ((bool)enabled && formatSupported && (float)Intensity > 0f && (float)Radius > 0f)
			{
				return base.IsEnabledAndSupported(context);
			}
			return false;
		}
	}
}
