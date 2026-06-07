using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Drawing
{
	public static class Draw
	{
		internal static CommandBuilder builder;

		internal static CommandBuilder ingame_builder;

		public static ref CommandBuilder editor
		{
			get
			{
				throw null;
			}
		}

		public static CommandBuilder2D xy => default(CommandBuilder2D);

		public static CommandBuilder2D xz => default(CommandBuilder2D);

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithMatrix(Matrix4x4 matrix)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithMatrix(float3x3 matrix)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithColor(Color color)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static CommandBuilder.ScopeEmpty WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return default(CommandBuilder.ScopeEmpty);
		}

		[BurstDiscard]
		public static void PushMatrix(Matrix4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PushMatrix(float4x4 matrix)
		{
		}

		[BurstDiscard]
		public static void PopMatrix()
		{
		}

		[BurstDiscard]
		public static void Line(float3 a, float3 b)
		{
		}

		[BurstDiscard]
		public static void Line(Vector3 a, Vector3 b)
		{
		}

		[BurstDiscard]
		public static void Line(Vector3 a, Vector3 b, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(float3 origin, float3 direction)
		{
		}

		[BurstDiscard]
		public static void Ray(Ray ray, float length)
		{
		}

		[BurstDiscard]
		public static void Arc(float3 center, float3 start, float3 end)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		[BurstDiscard]
		public static void Circle(float3 center, float3 normal, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 bottom, float3 top, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 position, float3 up, float height, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 start, float3 end, float radius)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 position, float3 direction, float length, float radius)
		{
		}

		[BurstDiscard]
		public static void WireSphere(float3 position, float radius)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, float3 size)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, quaternion rotation, float3 size)
		{
		}

		[BurstDiscard]
		public static void WireBox(Bounds bounds)
		{
		}

		[BurstDiscard]
		public static void WireMesh(Mesh mesh)
		{
		}

		[BurstDiscard]
		public static void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, float size = 1f)
		{
		}

		[BurstDiscard]
		public static void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
		}

		[BurstDiscard]
		public static void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
		}

		[BurstDiscard]
		public static void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize)
		{
		}

		[BurstDiscard]
		public static void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public static void WireRectangle(Rect rect)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, float3 normal, float2 size)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, quaternion rotation, float2 size)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, float3 size)
		{
		}

		[BurstDiscard]
		public static void SolidBox(Bounds bounds)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, quaternion rotation, float3 size)
		{
		}

		[BurstDiscard]
		public static void Line(float3 a, float3 b, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(float3 origin, float3 direction, Color color)
		{
		}

		[BurstDiscard]
		public static void Ray(Ray ray, float length, Color color)
		{
		}

		[BurstDiscard]
		public static void Arc(float3 center, float3 start, float3 end, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Circle instead")]
		public static void CircleXZ(float3 center, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void Circle(float3 center, float3 normal, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 bottom, float3 top, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCylinder(float3 position, float3 up, float height, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 start, float3 end, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireCapsule(float3 position, float3 direction, float length, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void WireSphere(float3 position, float radius, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(List<Vector3> points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(Vector3[] points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(float3[] points, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public static void Polyline(NativeArray<float3> points, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WireBox(Bounds bounds, Color color)
		{
		}

		[BurstDiscard]
		public static void WireMesh(Mesh mesh, Color color)
		{
		}

		[BurstDiscard]
		public static void WireMesh(NativeArray<float3> vertices, NativeArray<int> triangles, Color color)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		public static void Cross(float3 position, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xz.Cross instead")]
		public static void CrossXZ(float3 position, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, float size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.Cross instead")]
		public static void CrossXY(float3 position, Color color)
		{
		}

		[BurstDiscard]
		public static void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, Color color)
		{
		}

		[BurstDiscard]
		public static void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
		}

		[BurstDiscard]
		public static void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
		}

		[BurstDiscard]
		public static void WireGrid(float3 center, quaternion rotation, int2 cells, float2 totalSize, Color color)
		{
		}

		[BurstDiscard]
		public static void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		[Obsolete("Use Draw.xy.WireRectangle instead")]
		public static void WireRectangle(Rect rect, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, float3 normal, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void WirePlane(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, float3 size, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(Bounds bounds, Color color)
		{
		}

		[BurstDiscard]
		public static void SolidBox(float3 center, quaternion rotation, float3 size, Color color)
		{
		}
	}
}
