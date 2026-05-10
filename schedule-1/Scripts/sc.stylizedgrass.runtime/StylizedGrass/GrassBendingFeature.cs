using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedGrass
{
	public class GrassBendingFeature : ScriptableRendererFeature
	{
		public class RenderBendVectors : ScriptableRenderPass
		{
			private const string profilerTag = "Render Grass Bending Vectors";

			private static ProfilingSampler profilerSampler;

			private const string profilerTagPass = "Geometry to vectors";

			private static ProfilingSampler profilerSamplerRendering;

			private Settings settings;

			public const int TexelsPerMeter = 1;

			private const float FRUSTUM_MULTIPLIER = 2f;

			private const string LightModeTag = "GrassBender";

			private static RenderTexture vectorMap;

			private static readonly int vectorMapID;

			private static readonly int vectorUVID;

			private static readonly int _CameraForwardVector;

			private static Vector4 rendererCoords;

			private static Vector4 cameraForwardvector;

			private static Vector3 centerPosition;

			private static int resolution;

			private static int m_resolution;

			public static int CurrentResolution;

			private static float orthoSize;

			private static Bounds bounds;

			private static readonly Quaternion viewRotation;

			private static readonly Vector3 viewScale;

			private static readonly Color neutralVector;

			private static Rect viewportRect;

			private FilteringSettings m_FilteringSettings;

			private RenderStateBlock m_RenderStateBlock;

			private readonly List<ShaderTagId> m_ShaderTagIdList;

			private static readonly Plane[] frustrumPlanes;

			private static Matrix4x4 projection { get; set; }

			private static Matrix4x4 view { get; set; }

			public RenderBendVectors(ref Settings settings)
			{
			}

			public static int CalculateResolution(float size)
			{
				return 0;
			}

			public void Setup(RenderingData renderingData)
			{
			}

			private static float SnapToTexel(float pos, float texelSize)
			{
				return 0f;
			}

			private static Vector3 SnapToTexel(Vector3 pos, float texelSizeX, float texelSizeZ)
			{
				return default(Vector3);
			}

			public void SetupProjection(CommandBuffer cmd, ref RenderingData renderingData)
			{
			}

			private static Vector3 StabilizeProjection(Vector3 pos, float texelSize)
			{
				return default(Vector3);
			}

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
			}

			public static void DrawOrthographicViewGizmo()
			{
			}
		}

		[Serializable]
		public class Settings
		{
			[Min(10f)]
			public float renderRange;

			public bool ignoreSceneView;
		}

		private RenderBendVectors m_ScriptablePass;

		public Settings settings;

		public static bool SRPBatcherEnabled()
		{
			return false;
		}

		public override void Create()
		{
		}

		private void OnDisable()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}
	}
}
