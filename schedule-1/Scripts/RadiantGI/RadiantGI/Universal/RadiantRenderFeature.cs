using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace RadiantGI.Universal
{
	public class RadiantRenderFeature : ScriptableRendererFeature
	{
		public enum RenderingPath
		{
			Forward = 0,
			Deferred = 1,
			Both = 2
		}

		private enum Pass
		{
			CopyExact = 0,
			Raycast = 1,
			BlurHorizontal = 2,
			BlurVertical = 3,
			Upscale = 4,
			TemporalAccum = 5,
			Albedo = 6,
			Normals = 7,
			Compose = 8,
			Compare = 9,
			FinalGIDebug = 10,
			Specular = 11,
			Copy = 12,
			WideFilter = 13,
			Depth = 14,
			CopyDepth = 15,
			RSM_Debug = 16,
			RSM = 17,
			NFO = 18,
			NFOBlur = 19
		}

		private static class ShaderParams
		{
			public static int MainTex;

			public static int DownscaledColorAndDepthRT;

			public static int ResolveRT;

			public static int SourceSize;

			public static int NoiseTex;

			public static int Downscaled1RT;

			public static int Downscaled1RTA;

			public static int Downscaled2RT;

			public static int Downscaled2RTA;

			public static int InputRT;

			public static int CompareTex;

			public static int TempAcum;

			public static int PrevResolve;

			public static int DownscaledDepthRT;

			public static int Probe1Cube;

			public static int Probe2Cube;

			public static int NFO_RT;

			public static int NFOBlurRT;

			public static int IndirectData;

			public static int RayData;

			public static int TemporalData;

			public static int WorldToViewDir;

			public static int CompareParams;

			public static int ExtraData;

			public static int ExtraData2;

			public static int ExtraData3;

			public static int ExtraData4;

			public static int ExtraData5;

			public static int EmittersPositions;

			public static int EmittersBoxMin;

			public static int EmittersBoxMax;

			public static int EmittersColors;

			public static int EmittersCount;

			public static int RSMIntensity;

			public static int StencilValue;

			public static int StencilCompareFunction;

			public static int SubstractLightingMultiplier;

			public static int ProbeData;

			public static int Probe1HDR;

			public static int Probe2HDR;

			public static int BoundsXZ;

			public static int DebugDepthMultiplier;

			public static int NFOTint;

			public const string SKW_FORWARD = "_FORWARD";

			public const string SKW_FORWARD_AND_DEFERRED = "_FORWARD_AND_DEFERRED";

			public const string SKW_COMPARE_MODE = "_COMPARE_MODE";

			public const string SKW_USES_BINARY_SEARCH = "_USES_BINARY_SEARCH";

			public const string SKW_USES_MULTIPLE_RAYS = "_USES_MULTIPLE_RAYS";

			public const string SKW_REUSE_RAYS = "_REUSE_RAYS";

			public const string SKW_FALLBACK_1_PROBE = "_FALLBACK_1_PROBE";

			public const string SKW_FALLBACK_2_PROBES = "_FALLBACK_2_PROBES";

			public const string SKW_VIRTUAL_EMITTERS = "_VIRTUAL_EMITTERS";

			public const string SKW_USES_NEAR_FIELD_OBSCURANCE = "_USES_NEAR_FIELD_OBSCURANCE";

			public const string SKW_ORTHO_SUPPORT = "_ORTHO_SUPPORT";
		}

		private class RadiantPass : ScriptableRenderPass
		{
			private class PerCameraData
			{
				public Vector3 lastCameraPosition;

				public RenderTexture rtAcum;

				public int rtAcumCreationFrame;

				public RenderTexture rtBounce;

				public int rtBounceCreationFrame;

				public float emittersSortTime;

				public Vector3 emittersLastCameraPosition;

				public readonly List<RadiantVirtualEmitter> emittersSorted;
			}

			public int computedGIRT;

			private const string RGI_CBUF_NAME = "RadiantGI";

			private const float GOLDEN_RATIO = 0.618034f;

			private const int MAX_EMITTERS = 32;

			private ScriptableRenderer renderer;

			private RadiantRenderFeature settings;

			private RenderTextureDescriptor sourceDesc;

			private RenderTextureDescriptor cameraTargetDesc;

			private readonly Dictionary<Camera, PerCameraData> prevs;

			private RadiantGlobalIllumination radiant;

			private float goldenRatioAcum;

			private bool usesReprojection;

			private bool usesCompareMode;

			private Vector3 camPos;

			private Volume[] volumes;

			private Material mat;

			private static readonly Vector4 unlimitedBounds;

			private Vector4[] emittersBoxMin;

			private Vector4[] emittersBoxMax;

			private Vector4[] emittersColors;

			private Vector4[] emittersPositions;

			private readonly Plane[] cameraPlanes;

			public bool Setup(ScriptableRenderer renderer, RadiantRenderFeature settings, bool isSceneView)
			{
				return false;
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			private void RenderGI(CommandBuffer cmd, Camera cam)
			{
			}

			private void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier destination, Pass pass)
			{
			}

			private void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Pass pass)
			{
			}

			private void FullScreenBlitToCamera(CommandBuffer cmd, RenderTargetIdentifier source, Pass pass)
			{
			}

			private float CalculateProbeWeight(Vector3 wpos, Vector3 probeBoxMin, Vector3 probeBoxMax, float blendDistance)
			{
				return 0f;
			}

			private bool SetupProbes(CommandBuffer cmd, Camera cam, out int numProbes)
			{
				numProbes = default(int);
				return false;
			}

			private int PickNearProbes(Camera cam, out ReflectionProbe probe1, out ReflectionProbe probe2)
			{
				probe1 = null;
				probe2 = null;
				return 0;
			}

			private float ComputeProbeValue(Vector3 camPos, ReflectionProbe probe)
			{
				return 0f;
			}

			private void SetupVolumeBounds(CommandBuffer cmd, Camera cam)
			{
			}

			private bool SetupEmitters(Camera cam, List<RadiantVirtualEmitter> emitters)
			{
				return false;
			}

			private void SortEmitters(Camera cam)
			{
			}

			private int EmittersDistanceComparer(RadiantVirtualEmitter p1, RadiantVirtualEmitter p2)
			{
				return 0;
			}

			public void Cleanup()
			{
			}
		}

		private class RadiantComparePass : ScriptableRenderPass
		{
			private const string RGI_CBUF_NAME = "RadiantGICompare";

			private Material mat;

			private RadiantGlobalIllumination radiant;

			private ScriptableRenderer renderer;

			private RadiantPass radiantPass;

			private RadiantRenderFeature settings;

			public bool Setup(ScriptableRenderer renderer, RadiantRenderFeature settings, RadiantPass radiantPass)
			{
				return false;
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			private void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Pass pass)
			{
			}

			private void FullScreenBlitToCamera(CommandBuffer cmd, RenderTargetIdentifier source, Pass pass)
			{
			}

			public void Cleanup()
			{
			}
		}

		private static readonly List<ReflectionProbe> probes;

		private static readonly List<RadiantVirtualEmitter> emitters;

		private static bool emittersForceRefresh;

		private static Mesh _fullScreenMesh;

		public RenderPassEvent renderPassEvent;

		[Tooltip("Select the rendering mode according to the URP asset.")]
		public RenderingPath renderingPath;

		[Tooltip("Allows Radiant to be executed even if camera has Post Processing option disabled.")]
		public bool ignorePostProcessingOption;

		private RadiantPass radiantPass;

		private RadiantComparePass comparePass;

		public static bool needRTRefresh;

		private static Mesh fullscreenMesh => null;

		private void OnDisable()
		{
		}

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public static void RegisterReflectionProbe(ReflectionProbe probe)
		{
		}

		public static void UnregisterReflectionProbe(ReflectionProbe probe)
		{
		}

		public static void RegisterVirtualEmitter(RadiantVirtualEmitter emitter)
		{
		}

		public static void UnregisterVirtualEmitter(RadiantVirtualEmitter emitter)
		{
		}
	}
}
