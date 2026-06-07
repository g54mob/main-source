using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Drawing
{
	[BurstCompile]
	public struct CommandBuilder : IDisposable
	{
		[Flags]
		internal enum Command
		{
			PushColorInline = 0x100,
			PushColor = 0,
			PopColor = 1,
			PushMatrix = 2,
			PushSetMatrix = 3,
			PopMatrix = 4,
			Line = 5,
			Circle = 6,
			CircleXZ = 7,
			Disc = 8,
			DiscXZ = 9,
			SphereOutline = 0xA,
			Box = 0xB,
			WirePlane = 0xC,
			WireBox = 0xD,
			SolidTriangle = 0xE,
			PushPersist = 0xF,
			PopPersist = 0x10,
			Text = 0x11,
			Text3D = 0x12,
			PushLineWidth = 0x13,
			PopLineWidth = 0x14,
			CaptureState = 0x15
		}

		internal struct TriangleData
		{
			public float3 a;

			public float3 b;

			public float3 c;
		}

		internal struct LineData
		{
			public float3 a;

			public float3 b;
		}

		internal struct LineDataV3
		{
			public Vector3 a;

			public Vector3 b;
		}

		internal struct CircleXZData
		{
			public float3 center;

			public float radius;

			public float startAngle;

			public float endAngle;
		}

		internal struct CircleData
		{
			public float3 center;

			public float3 normal;

			public float radius;
		}

		internal struct SphereData
		{
			public float3 center;

			public float radius;
		}

		internal struct BoxData
		{
			public float3 center;

			public float3 size;
		}

		internal struct PlaneData
		{
			public float3 center;

			public quaternion rotation;

			public float2 size;
		}

		internal struct PersistData
		{
			public float endTime;
		}

		internal struct LineWidthData
		{
			public float pixels;

			public bool automaticJoins;
		}

		internal struct TextData
		{
			public float3 center;

			public LabelAlignment alignment;

			public float sizeInPixels;

			public int numCharacters;
		}

		internal struct TextData3D
		{
			public float3 center;

			public quaternion rotation;

			public LabelAlignment alignment;

			public float size;

			public int numCharacters;
		}

		public struct ScopeMatrix : IDisposable
		{
			internal CommandBuilder builder;

			public void Dispose()
			{
			}
		}

		public struct ScopeColor : IDisposable
		{
			internal CommandBuilder builder;

			public void Dispose()
			{
			}
		}

		public struct ScopePersist : IDisposable
		{
			internal CommandBuilder builder;

			public void Dispose()
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct ScopeEmpty : IDisposable
		{
			public void Dispose()
			{
			}
		}

		public struct ScopeLineWidth : IDisposable
		{
			internal CommandBuilder builder;

			public void Dispose()
			{
			}
		}

		public enum SymbolDecoration : byte
		{
			None = 0,
			ArrowHead = 1,
			Circle = 2
		}

		public struct PolylineWithSymbol
		{
			private enum State : byte
			{
				NotStarted = 0,
				ConnectingSegment = 1,
				PreSymbolPadding = 2,
				Symbol = 3,
				PostSymbolPadding = 4
			}

			private float3 prev;

			private float offset;

			private readonly float symbolSize;

			private readonly float connectingSegmentLength;

			private readonly float symbolPadding;

			private readonly float symbolOffset;

			public float3 up;

			private readonly SymbolDecoration symbol;

			private State state;

			private readonly bool reverseSymbols;

			public PolylineWithSymbol(SymbolDecoration symbol, float symbolSize, float symbolPadding, float symbolSpacing, bool reverseSymbols = false, float offset = 0f)
			{
				prev = default(float3);
				this.offset = 0f;
				this.symbolSize = 0f;
				connectingSegmentLength = 0f;
				this.symbolPadding = 0f;
				symbolOffset = 0f;
				up = default(float3);
				this.symbol = default(SymbolDecoration);
				state = default(State);
				this.reverseSymbols = false;
			}

			public void MoveTo(ref CommandBuilder draw, float3 next)
			{
			}
		}

		[BurstCompile]
		private class JobWireMesh
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate void JobWireMeshDelegate(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw);

			internal unsafe delegate void WireMesh_00000106_0024PostfixBurstDelegate(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw);

			internal static class WireMesh_00000106_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public static void Constructor()
				{
				}

				public static void Initialize()
				{
				}

				public unsafe static void Invoke(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
				{
				}
			}

			internal delegate void Execute_00000107_0024PostfixBurstDelegate(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw);

			internal static class Execute_00000107_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public static void Constructor()
				{
				}

				public static void Initialize()
				{
				}

				public static void Invoke(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
				{
				}
			}

			public static readonly JobWireMeshDelegate JobWireMeshFunctionPointer;

			[BurstCompile]
			public unsafe static void WireMesh(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
			{
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(JobWireMeshDelegate))]
			private static void Execute(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal unsafe static void WireMesh_0024BurstManaged(float3* verts, int* indices, int vertexCount, int indexCount, ref CommandBuilder draw)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[MonoPInvokeCallback(typeof(JobWireMeshDelegate))]
			internal static void Execute_0024BurstManaged(ref Mesh.MeshData rawMeshData, ref CommandBuilder draw)
			{
			}
		}

		[NativeDisableUnsafePtrRestriction]
		internal unsafe UnsafeAppendBuffer* buffer;

		private GCHandle gizmos;

		[NativeSetThreadIndex]
		private int threadIndex;

		private DrawingData.BuilderData.BitPackedMeta uniqueID;

		private static readonly float3 DEFAULT_UP;

		internal static readonly float4x4 XZtoXYPlaneMatrix;

		internal static readonly float4x4 XZtoYZPlaneMatrix;

		internal int BufferSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public CommandBuilder2D xy => default(CommandBuilder2D);

		public CommandBuilder2D xz => default(CommandBuilder2D);

		public Camera[] cameraTargets
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal unsafe CommandBuilder(UnsafeAppendBuffer* buffer, GCHandle gizmos, int threadIndex, DrawingData.BuilderData.BitPackedMeta uniqueID)
		{
			this.buffer = null;
			this.gizmos = default(GCHandle);
			this.threadIndex = 0;
			this.uniqueID = default(DrawingData.BuilderData.BitPackedMeta);
		}

		internal unsafe CommandBuilder(DrawingData gizmos, DrawingData.Hasher hasher, RedrawScope frameRedrawScope, RedrawScope customRedrawScope, bool isGizmos, bool isBuiltInCommandBuilder, int sceneModeVersion)
		{
			buffer = null;
			this.gizmos = default(GCHandle);
			threadIndex = 0;
			uniqueID = default(DrawingData.BuilderData.BitPackedMeta);
		}

		public void Dispose()
		{
		}

		public void DisposeAfter(JobHandle dependency, AllowedDelay allowedDelay = AllowedDelay.EndOfFrame)
		{
		}

		internal void DisposeInternal()
		{
		}

		public void DiscardAndDispose()
		{
		}

		internal void DiscardAndDisposeInternal()
		{
		}

		public void Preallocate(int size)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Reserve(int additionalSpace)
		{
		}

		[BurstDiscard]
		private void AssertBufferExists()
		{
		}

		[BurstDiscard]
		private static void AssertNotRendering()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A>() where A : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A, B>() where A : struct where B : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Reserve<A, B, C>() where A : struct where B : struct where C : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint ConvertColor(Color color)
		{
			return 0u;
		}

		internal void Add<T>(T value) where T : struct
		{
		}

		[BurstDiscard]
		public ScopeMatrix WithMatrix(Matrix4x4 matrix)
		{
			return default(ScopeMatrix);
		}

		[BurstDiscard]
		public ScopeMatrix WithMatrix(float3x3 matrix)
		{
			return default(ScopeMatrix);
		}

		[BurstDiscard]
		public ScopeColor WithColor(Color color)
		{
			return default(ScopeColor);
		}

		[BurstDiscard]
		public ScopePersist WithDuration(float duration)
		{
			return default(ScopePersist);
		}

		[BurstDiscard]
		public ScopeLineWidth WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return default(ScopeLineWidth);
		}

		[BurstDiscard]
		public ScopeMatrix InLocalSpace(Transform transform)
		{
			return default(ScopeMatrix);
		}

		[BurstDiscard]
		public ScopeMatrix InScreenSpace(Camera camera)
		{
			return default(ScopeMatrix);
		}

		public void PushMatrix(Matrix4x4 matrix)
		{
		}

		public void PushMatrix(float4x4 matrix)
		{
		}

		public void PushSetMatrix(Matrix4x4 matrix)
		{
		}

		public void PushSetMatrix(float4x4 matrix)
		{
		}

		public void PopMatrix()
		{
		}

		public void PushColor(Color color)
		{
		}

		public void PopColor()
		{
		}

		public void PushDuration(float duration)
		{
		}

		public void PopDuration()
		{
		}

		[Obsolete("Renamed to PushDuration for consistency")]
		public void PushPersist(float duration)
		{
		}

		[Obsolete("Renamed to PopDuration for consistency")]
		public void PopPersist()
		{
		}

		public void PushLineWidth(float pixels, bool automaticJoins = true)
		{
		}

		public void PopLineWidth()
		{
		}

		public void Line(float3 a, float3 b)
		{
		}

		public void Line(Vector3 a, Vector3 b)
		{
		}

		public void Line(Vector3 a, Vector3 b, Color color)
		{
		}

		public void Ray(float3 origin, float3 direction)
		{
		}

		public void Ray(Ray ray, float length)
		{
		}

		public void Arc(float3 center, float3 start, float3 end)
		{
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		internal void CircleXZInternal(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		internal void CircleXZInternal(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		public void Circle(float3 center, float3 normal, float radius)
		{
		}

		public void SolidArc(float3 center, float3 start, float3 end)
		{
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		internal void SolidCircleXZInternal(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		internal void SolidCircleXZInternal(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		public void SolidCircle(float3 center, float3 normal, float radius)
		{
		}

		public void SphereOutline(float3 center, float radius)
		{
		}

		public void WireCylinder(float3 bottom, float3 top, float radius)
		{
		}

		public void WireCylinder(float3 position, float3 up, float height, float radius)
		{
		}

		private static void OrthonormalBasis(float3 normal, out float3 basis1, out float3 basis2)
		{
			basis1 = default(float3);
			basis2 = default(float3);
		}

		public void WireCapsule(float3 start, float3 end, float radius)
		{
		}

		public void WireCapsule(float3 position, float3 direction, float length, float radius)
		{
		}

		public void WireSphere(float3 position, float radius)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle = false)
		{
		}

		public void Polyline<T>(T points, bool cycle = false) where T : IReadOnlyList<float3>
		{
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle = false)
		{
		}

		public void Polyline(NativeArray<float3> points, bool cycle = false)
		{
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap)
		{
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap)
		{
		}

		public void WireBox(float3 center, float3 size)
		{
		}

		public void WireBox(float3 center, quaternion rotation, float3 size)
		{
		}

		public void WireBox(Bounds bounds)
		{
		}

		public void WireMesh(Mesh mesh)
		{
		}

		public void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles)
		{
		}

		public void SolidMesh(Mesh mesh)
		{
		}

		private void SolidMeshInternal(Mesh mesh, bool temporary, Color color)
		{
		}

		private void SolidMeshInternal(Mesh mesh, bool temporary)
		{
		}

		[BurstDiscard]
		public void SolidMesh(List<Vector3> vertices, List<int> triangles, List<Color> colors)
		{
		}

		[BurstDiscard]
		public void SolidMesh(Vector3[] vertices, int[] triangles, Color[] colors, int vertexCount, int indexCount)
		{
		}

		public void Cross(float3 position, float size = 1f)
		{
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, float size = 1f)
		{
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, float size = 1f)
		{
		}

		public static float3 EvaluateCubicBezier(float3 p0, float3 p1, float3 p2, float3 p3, float t)
		{
			return default(float3);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		public void CatmullRom(List<Vector3> points)
		{
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		public void Arrow(float3 from, float3 to)
		{
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
		}

		public void Arrowhead(float3 center, float3 direction, float radius)
		{
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
		}

		public void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize)
		{
		}

		public void WireTriangle(float3 a, float3 b, float3 c)
		{
		}

		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public void WireRectangleXZ(float3 center, float2 size)
		{
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
		}

		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public void WireRectangle(Rect rect)
		{
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius)
		{
		}

		public void WirePentagon(float3 center, quaternion rotation, float radius)
		{
		}

		public void WireHexagon(float3 center, quaternion rotation, float radius)
		{
		}

		public void WirePolygon(float3 center, int vertices, quaternion rotation, float radius)
		{
		}

		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public void SolidRectangle(Rect rect)
		{
		}

		public void SolidPlane(float3 center, float3 normal, float2 size)
		{
		}

		public void SolidPlane(float3 center, quaternion rotation, float2 size)
		{
		}

		private static float3 calculateTangent(float3 normal)
		{
			return default(float3);
		}

		public void WirePlane(float3 center, float3 normal, float2 size)
		{
		}

		public void WirePlane(float3 center, quaternion rotation, float2 size)
		{
		}

		public void PlaneWithNormal(float3 center, float3 normal, float2 size)
		{
		}

		public void PlaneWithNormal(float3 center, quaternion rotation, float2 size)
		{
		}

		public void SolidTriangle(float3 a, float3 b, float3 c)
		{
		}

		public void SolidBox(float3 center, float3 size)
		{
		}

		public void SolidBox(Bounds bounds)
		{
		}

		public void SolidBox(float3 center, quaternion rotation, float3 size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment)
		{
		}

		public void Label2D(float3 position, string text, float sizeInPixels = 14f)
		{
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		private void AddText(string text)
		{
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels = 14f)
		{
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels = 14f)
		{
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels = 14f)
		{
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels = 14f)
		{
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment)
		{
		}

		internal unsafe void Label2D(float3 position, byte* text, int byteCount, float sizeInPixels, LabelAlignment alignment)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment)
		{
		}

		internal unsafe void Label3D(float3 position, quaternion rotation, byte* text, int byteCount, float size, LabelAlignment alignment)
		{
		}

		public void Line(float3 a, float3 b, Color color)
		{
		}

		public void Ray(float3 origin, float3 direction, Color color)
		{
		}

		public void Ray(Ray ray, float length, Color color)
		{
		}

		public void Arc(float3 center, float3 start, float3 end, Color color)
		{
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xz.Circle instead")]
		public void CircleXZ(float3 center, float radius, Color color)
		{
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xy.Circle instead")]
		public void CircleXY(float3 center, float radius, Color color)
		{
		}

		public void Circle(float3 center, float3 normal, float radius, Color color)
		{
		}

		public void SolidArc(float3 center, float3 start, float3 end, Color color)
		{
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xz.SolidCircle instead")]
		public void SolidCircleXZ(float3 center, float radius, Color color)
		{
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[Obsolete("Use Draw.xy.SolidCircle instead")]
		public void SolidCircleXY(float3 center, float radius, Color color)
		{
		}

		public void SolidCircle(float3 center, float3 normal, float radius, Color color)
		{
		}

		public void SphereOutline(float3 center, float radius, Color color)
		{
		}

		public void WireCylinder(float3 bottom, float3 top, float radius, Color color)
		{
		}

		public void WireCylinder(float3 position, float3 up, float height, float radius, Color color)
		{
		}

		public void WireCapsule(float3 start, float3 end, float radius, Color color)
		{
		}

		public void WireCapsule(float3 position, float3 direction, float length, float radius, Color color)
		{
		}

		public void WireSphere(float3 position, float radius, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(float3[] points, Color color)
		{
		}

		public void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
		}

		public void Polyline(NativeArray<float3> points, Color color)
		{
		}

		public void DashedLine(float3 a, float3 b, float dash, float gap, Color color)
		{
		}

		public void DashedPolyline(List<Vector3> points, float dash, float gap, Color color)
		{
		}

		public void WireBox(float3 center, float3 size, Color color)
		{
		}

		public void WireBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}

		public void WireBox(Bounds bounds, Color color)
		{
		}

		public void WireMesh(Mesh mesh, Color color)
		{
		}

		public void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles, Color color)
		{
		}

		public void SolidMesh(Mesh mesh, Color color)
		{
		}

		public void Cross(float3 position, float size, Color color)
		{
		}

		public void Cross(float3 position, Color color)
		{
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, float size, Color color)
		{
		}

		[Obsolete("Use Draw.xz.Cross instead")]
		public void CrossXZ(float3 position, Color color)
		{
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, float size, Color color)
		{
		}

		[Obsolete("Use Draw.xy.Cross instead")]
		public void CrossXY(float3 position, Color color)
		{
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		public void CatmullRom(List<Vector3> points, Color color)
		{
		}

		public void CatmullRom(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		public void Arrow(float3 from, float3 to, Color color)
		{
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
		}

		public void Arrowhead(float3 center, float3 direction, float radius, Color color)
		{
		}

		public void Arrowhead(float3 center, float3 direction, float3 up, float radius, Color color)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
		}

		public void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize, Color color)
		{
		}

		public void WireTriangle(float3 a, float3 b, float3 c, Color color)
		{
		}

		[Obsolete("Use Draw.xz.WireRectangle instead")]
		public void WireRectangleXZ(float3 center, float2 size, Color color)
		{
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public void WireRectangle(Rect rect, Color color)
		{
		}

		public void WireTriangle(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		public void WirePentagon(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		public void WireHexagon(float3 center, quaternion rotation, float radius, Color color)
		{
		}

		public void WirePolygon(float3 center, int vertices, quaternion rotation, float radius, Color color)
		{
		}

		[Obsolete("Use Draw.xy.SolidRectangle instead")]
		public void SolidRectangle(Rect rect, Color color)
		{
		}

		public void SolidPlane(float3 center, float3 normal, float2 size, Color color)
		{
		}

		public void SolidPlane(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		public void WirePlane(float3 center, float3 normal, float2 size, Color color)
		{
		}

		public void WirePlane(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		public void PlaneWithNormal(float3 center, float3 normal, float2 size, Color color)
		{
		}

		public void PlaneWithNormal(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		public void SolidTriangle(float3 a, float3 b, float3 c, Color color)
		{
		}

		public void SolidBox(float3 center, float3 size, Color color)
		{
		}

		public void SolidBox(Bounds bounds, Color color)
		{
		}

		public void SolidBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, string text, float size, LabelAlignment alignment, Color color)
		{
		}

		public void Label2D(float3 position, string text, float sizeInPixels, Color color)
		{
		}

		public void Label2D(float3 position, string text, Color color)
		{
		}

		public void Label2D(float3 position, string text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString32Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString64Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString128Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		public void Label2D(float3 position, ref FixedString512Bytes text, float sizeInPixels, LabelAlignment alignment, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString32Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString64Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString128Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		public void Label3D(float3 position, quaternion rotation, ref FixedString512Bytes text, float size, LabelAlignment alignment, Color color)
		{
		}

		public static void Initialize_0024JobWireMesh_WireMesh_00000106_0024BurstDirectCall()
		{
		}

		public static void Initialize_0024JobWireMesh_Execute_00000107_0024BurstDirectCall()
		{
		}
	}
}
