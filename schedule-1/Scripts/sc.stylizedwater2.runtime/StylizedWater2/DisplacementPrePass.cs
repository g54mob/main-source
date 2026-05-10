using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	public class DisplacementPrePass : ScriptableRenderPass
	{
		[Serializable]
		public class Settings
		{
			public bool enable;

			public float range;

			[Range(0.1f, 4f)]
			public float cellSize;
		}

		private const string profilerTag = "Water Displacement Prepass";

		private static readonly ProfilingSampler profilerSampler;

		public const string KEYWORD = "WATER_DISPLACEMENT_PASS";

		public const float VOID_THRESHOLD = -1000f;

		private Color targetClearColor;

		private FilteringSettings m_FilteringSettings;

		private RenderStateBlock m_RenderStateBlock;

		private readonly List<ShaderTagId> m_ShaderTagIdList;

		private static readonly Quaternion viewRotation;

		private static readonly Vector3 viewScale;

		private static Rect viewportRect;

		private const string BufferName = "_WaterDisplacementBuffer";

		private static readonly int _WaterDisplacementBuffer;

		private const string CoordsName = "_WaterDisplacementCoords";

		private static readonly int _WaterDisplacementCoords;

		private RTHandle renderTarget;

		private static Vector3 centerPosition;

		private static Vector4 rendererCoords;

		private int resolution;

		private int m_resolution;

		private float orthoSize;

		private Settings settings;

		private static Matrix4x4 projection { get; set; }

		private static Matrix4x4 view { get; set; }

		public void Setup(Settings settings)
		{
		}

		private static Vector3 StabilizeProjection(Vector3 pos, float texelSize)
		{
			return default(Vector3);
		}

		private void SetupProjection(CommandBuffer cmd, Camera camera)
		{
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public void Dispose()
		{
		}
	}
}
