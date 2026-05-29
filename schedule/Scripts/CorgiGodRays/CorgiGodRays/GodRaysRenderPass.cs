using System;
using System.Reflection;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CorgiGodRays
{
	public class GodRaysRenderPass : ScriptableRenderPass
	{
		private struct VisibleLightRemap
		{
			public VisibleLight lightData;

			public int visibleLightIndex;
		}

		private const string _profilerTag = "GodRaysRenderPass";

		private static readonly int _GodRaysTexture;

		private static readonly int _CorgiGrabpass;

		private static readonly int _CopyBlitTex;

		private static readonly int _TempBlurTex;

		private static readonly int _BlurInputTex;

		private static readonly int _CorgiDepthGrabpassFullRes;

		private static readonly int _CorgiDepthGrabpassNonFullRes;

		private static readonly int _CorgiInverseProjection;

		private static readonly int _CorgiCameraToWorld;

		private static readonly int _CorgiInverseProjectionArray;

		private static readonly int _GodRaysParams;

		private static readonly int _MainLightScattering;

		private static readonly int _AdditionalLightScattering;

		private static readonly int _Jitter;

		private static readonly int _MaxDistance;

		private static readonly int _MainLightIntensity;

		private static readonly int _AdditionalLightIntensity;

		private static readonly int _TintColor;

		private static readonly int _CorgiVisibleLightCount;

		private static readonly int _CorgiVisibleLightData;

		private static readonly int _CorgiLightIndexToShadowIndex;

		private static readonly int _CorgiGodraysIntensityCurveTexture;

		[NonSerialized]
		private GodRaysRenderFeature.GodRaysSettings _settings;

		[NonSerialized]
		private ScriptableRenderer _renderer;

		[NonSerialized]
		private Matrix4x4[] _InverseProjectionArray;

		[NonSerialized]
		private MaterialPropertyBlock _propertyBlock;

		[NonSerialized]
		private Texture2D _intensityCurveTexture;

		[NonSerialized]
		private PropertyInfo _cacheRenderFeaturesPropertyInfo;

		[NonSerialized]
		private static GraphicsBuffer _additionalLightsBuffer;

		[NonSerialized]
		private static GraphicsBuffer _lightsToShadowIndexBuffer;

		[NonSerialized]
		private const int MaxLightCount = 256;

		private MixedLightingSetup m_MixedLightingSetup;

		private int _temporal_pass_index;

		private bool _curveTextureForceRefreshTrigger;

		private static Mesh s_FullscreenMesh;

		public static Mesh fullscreenMesh => null;

		public void Setup(GodRaysRenderFeature.GodRaysSettings settings, ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		private void DisposeCurveTexture()
		{
		}

		private void InitializeLightConstants(NativeArray<VisibleLight> lights, int lightIndex, out Vector4 lightPos, out Vector4 lightColor, out Vector4 lightAttenuation, out Vector4 lightSpotDir, out Vector4 lightOcclusionProbeChannel, out uint lightLayerMask, out bool isSubtractive)
		{
			lightPos = default(Vector4);
			lightColor = default(Vector4);
			lightAttenuation = default(Vector4);
			lightSpotDir = default(Vector4);
			lightOcclusionProbeChannel = default(Vector4);
			lightLayerMask = default(uint);
			isSubtractive = default(bool);
		}

		public static uint ToValidRenderingLayers(uint renderingLayers)
		{
			return 0u;
		}

		public static ref T UnsafeElementAtMutable<T>(NativeArray<T> array, int index) where T : struct
		{
			throw null;
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public void TriggerRefreshCurveTexture()
		{
		}

		private void EnsureCurveTexture()
		{
		}
	}
}
