using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CorgiGodRays
{
	public class GodRaysRenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public enum VolumeStepQuality
		{
			Low = 0x10,
			Med = 0x20,
			High = 0x40
		}

		[Serializable]
		public enum VolumeTextureQuality
		{
			Low = 4,
			Med = 2,
			High = 1
		}

		[Serializable]
		public enum BilateralBlurSamples
		{
			Low = 2,
			Med = 4,
			High = 7
		}

		[Serializable]
		public class GodRaysSettings
		{
			[Tooltip("Resources used by the plugin internally.")]
			public GodRaysRenderData renderData;

			[Tooltip("Random jitter used when tracing rays through the depth and shadowmap buffers. If this value is higher you can get away with lower step counts - but you may want to cover it up with the blur options.")]
			[Range(0f, 1f)]
			public float Jitter;

			[Tooltip("The size of the internal godrays texture. Higher looks better but requires more GPU performance.")]
			public VolumeTextureQuality textureQuality;

			[Tooltip("Higher values of this require more GPU performance, but look nicer. Scales with texture quality. You can get away with higher step counts if texture quality is lower.")]
			public VolumeStepQuality stepQuality;

			[Tooltip("Blur the internal godrays texture? Useful for lower quality settings.")]
			public bool blur;

			[Tooltip("How many times should the blur pass be ran? When using lower quality settings, you may want to increase this value.")]
			[Range(1f, 4f)]
			public int BlurCount;

			[Tooltip("During the blur, how many samples should be taken? Higher values mean higher quality, but also more GPU performance overhead.")]
			public BilateralBlurSamples blurSamples;

			[Tooltip("When using a lower texture quality, enabling this may make things look nicer. Only has an effect if not on the highest texture quality.")]
			public bool depthAwareUpsampling;

			[Tooltip("If you want the godrays to work with the main directional light, enable this. Note: there is a small GPU performance overhead for enabling this.")]
			public bool allowMainLight;

			[Tooltip("If you want the godrays to work with lights other than the main directional light, enable this. Note: there is a small GPU performance overhead for enabling this.")]
			public bool allowAdditionalLights;

			[Tooltip("[Experimental] If enabled, renders the effect over multiple frames.")]
			public bool temporallyRender;

			[Tooltip("When temporally rendering, how many frames to render over? Higher values MAY save more performance, but come at a cost of reduced visual clarity and possibly a darker overall image.")]
			[Range(2f, 8f)]
			public int temporalDuration;

			[Tooltip("When temporally rendering, should we discard? If false, it writes zero instead. Writing zero is more visually stable, but results in a darker image.")]
			public bool temporalUseDiscard;

			[Tooltip("When temporally rendering, should motion vectors be rendered and used for reprojecting the volumetric data from the previous frame? Note: Only works 'correctly' with temporalDuration = 2.")]
			public bool temporalReprojection;

			[Tooltip("If you want the godrays to be affected by additional lights' shadows, enable this. Note: there is a large GPU performance overhead for enabling this.")]
			public bool allowAdditionalLightShadows;

			[Tooltip("The higher this is, the higher the GPU cost can be for calcualting volumetrics for additional lights. They will be sorted by distance to camera (non-directionally).")]
			[Range(1f, 256f)]
			public int maxAdditionalLightCount;

			[Tooltip("You may need to toggle this on or off depending on your exact SRP configuration. Usually leave this on.")]
			public bool useUnityDepthDirectly;

			[Tooltip("If you are using Unity's ScreenSpaceShadows ReaderFeature, you will need to enable this. If not, usually leave this off.")]
			public bool supportUnityScreenSpaceShadows;

			[Tooltip("If enabled, a curve will be used to control volumetrics intensity based on distance from the camera. Enabling this will incur a small GPU performance overhead.")]
			public bool useVariableIntensity;

			[Tooltip("If useVariableIntensity is enabled, this curve will be used to control volumetric intensity based on distance. This curve is turned into a texture at runtime.")]
			public AnimationCurve variableIntensityCurve;

			[Tooltip("Max distance to trace out volumetrics. The smaller this value is, the higher quality volumetrics can appear, but they will also fade out much sooner.")]
			public float maxDistance;

			[Tooltip("If enabled, light color of the main light and the additional lights will be encoded into the godrays texture. This will require more GPU performance, but will result in more accurate colors.")]
			public bool encodeLightColor;

			[Tooltip("If enabled, use higher quality textures (float instead of half) - some platforms may not support one or the other.")]
			public bool enableHighQualityTextures;

			[Tooltip("If an additional light is not in this layer, it will not be included for volumetrics.")]
			public LayerMask AdditionalLightLayers;

			[Tooltip("Render this effect after opaque renders have finished, or after transparent renders have finished. Setting to custom allows you to define the exact RenderPassEvent, but you will be on your own to deal with the consequences.")]
			public GodraysRenderOrder renderOrder;

			[Tooltip("[Advanced] When renderOrder is set to Custom, you can set the exact RenderPassEvent here. Only do this if you know exactly what you are doing.")]
			public RenderPassEvent customRenderPassEvent;

			[Tooltip("[Advanced] If you need to offset the customRenderPassEvent value to arrange around other custom effects, do so here.")]
			public int customRenderPassOffset;
		}

		[Serializable]
		public enum GodraysRenderOrder
		{
			AfterOpaque = 0,
			AfterTransparent = 1,
			Custom = 2
		}

		public GodRaysSettings settings;

		[NonSerialized]
		private GodRaysRenderPass _renderPass;

		public override void Create()
		{
		}

		private void OnDisable()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		private void OnValidate()
		{
		}

		public void EditorSetDirty()
		{
		}

		public void TriggerRefreshCurveTexture()
		{
		}
	}
}
