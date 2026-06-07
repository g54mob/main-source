using System.Runtime.CompilerServices;
using Pathfinding.Drawing.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Drawing
{
	[BurstCompile(FloatMode = FloatMode.Default)]
	internal struct GeometryBuilderJob : IJob
	{
		public struct Vertex
		{
			public float3 position;

			public float3 uv2;

			public Color32 color;

			public float2 uv;
		}

		public struct TextVertex
		{
			public float3 position;

			public Color32 color;

			public float2 uv;
		}

		[NativeDisableUnsafePtrRestriction]
		public unsafe DrawingData.ProcessedBuilderData.MeshBuffers* buffers;

		[NativeDisableUnsafePtrRestriction]
		public unsafe SDFCharacter* characterInfo;

		public int characterInfoLength;

		public Color32 currentColor;

		public float4x4 currentMatrix;

		public CommandBuilder.LineWidthData currentLineWidthData;

		public float lineWidthMultiplier;

		private float3 minBounds;

		private float3 maxBounds;

		public float3 cameraPosition;

		public quaternion cameraRotation;

		public float2 cameraDepthToPixelSize;

		public float maxPixelError;

		public bool cameraIsOrthographic;

		private float3 lastNormalizedLineDir;

		private float lastLineWidth;

		public const float MaxCirclePixelError = 0.5f;

		public const int VerticesPerCharacter = 4;

		public const int TrianglesPerCharacter = 6;

		internal static readonly float4[] BoxVertices;

		internal static readonly int[] BoxTriangles;

		public const int MaxStackSize = 32;

		private unsafe static void Add<T>(UnsafeAppendBuffer* buffer, T value) where T : struct
		{
		}

		private unsafe static void Reserve(UnsafeAppendBuffer* buffer, int size)
		{
		}

		internal static float3 PerspectiveDivide(float4 p)
		{
			return default(float3);
		}

		private unsafe void AddText(ushort* text, CommandBuilder.TextData textData, Color32 color)
		{
		}

		private unsafe void AddText3D(ushort* text, CommandBuilder.TextData3D textData, Color32 color)
		{
		}

		private unsafe void AddTextInternal(ushort* text, float3 pivot, float3 right, float3 up, LabelAlignment alignment, float size, bool sizeIsInPixels, int numCharacters, Color32 color)
		{
		}

		private void AddLine(CommandBuilder.LineData line)
		{
		}

		internal static int CircleSteps(float3 center, float radius, float maxPixelError, ref float4x4 currentMatrix, float2 cameraDepthToPixelSize, float3 cameraPosition)
		{
			return 0;
		}

		private void AddCircle(CommandBuilder.CircleData circle)
		{
		}

		private void AddDisc(CommandBuilder.CircleData circle)
		{
		}

		private void AddSphereOutline(CommandBuilder.SphereData circle)
		{
		}

		private void AddCircle(CommandBuilder.CircleXZData circle)
		{
		}

		private void AddDisc(CommandBuilder.CircleXZData circle)
		{
		}

		private void AddSolidTriangle(CommandBuilder.TriangleData triangle)
		{
		}

		private void AddWireBox(CommandBuilder.BoxData box)
		{
		}

		private void AddPlane(CommandBuilder.PlaneData plane)
		{
		}

		private void AddBox(CommandBuilder.BoxData box)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Next(ref UnsafeAppendBuffer.Reader reader, ref NativeArray<float4x4> matrixStack, ref NativeArray<Color32> colorStack, ref NativeArray<CommandBuilder.LineWidthData> lineWidthStack, ref int matrixStackSize, ref int colorStackSize, ref int lineWidthStackSize)
		{
		}

		private void CreateTriangles()
		{
		}

		public void Execute()
		{
		}
	}
}
