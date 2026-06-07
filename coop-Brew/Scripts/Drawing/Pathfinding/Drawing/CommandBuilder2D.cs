using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Drawing
{
	public struct CommandBuilder2D
	{
		private CommandBuilder draw;

		private bool xy;

		private static readonly float3 XY_UP;

		private static readonly float3 XZ_UP;

		private static readonly quaternion XY_TO_XZ_ROTATION;

		private static readonly quaternion XZ_TO_XZ_ROTATION;

		private static readonly float4x4 XZ_TO_XY_MATRIX;

		public CommandBuilder2D(CommandBuilder draw, bool xy)
		{
			this.draw = default(CommandBuilder);
			this.xy = false;
		}

		public void Line(float2 a, float2 b)
		{
		}

		public void Line(float2 a, float2 b, Color color)
		{
		}

		public void Line(float3 a, float3 b)
		{
		}

		public void Circle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		public void Circle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		public void SolidCircle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		public void SolidCircle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
		}

		public void WirePill(float2 a, float2 b, float radius)
		{
		}

		public void WirePill(float2 position, float2 direction, float length, float radius)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle = false)
		{
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle = false)
		{
		}

		public void Polyline(NativeArray<float2> points, bool cycle = false)
		{
		}

		public void Cross(float2 position, float size = 1f)
		{
		}

		public void WireRectangle(float3 center, float2 size)
		{
		}

		public void WireRectangle(Rect rect)
		{
		}

		public void SolidRectangle(Rect rect)
		{
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize)
		{
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize)
		{
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(Matrix4x4 matrix)
		{
			return default(CommandBuilder.ScopeMatrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(float3x3 matrix)
		{
			return default(CommandBuilder.ScopeMatrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeColor WithColor(Color color)
		{
			return default(CommandBuilder.ScopeColor);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeLineWidth WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return default(CommandBuilder.ScopeLineWidth);
		}

		public void PushMatrix(Matrix4x4 matrix)
		{
		}

		public void PushMatrix(float4x4 matrix)
		{
		}

		public void PopMatrix()
		{
		}

		public void Line(Vector3 a, Vector3 b)
		{
		}

		public void Line(Vector2 a, Vector2 b)
		{
		}

		public void Line(Vector3 a, Vector3 b, Color color)
		{
		}

		public void Line(Vector2 a, Vector2 b, Color color)
		{
		}

		public void Ray(float3 origin, float3 direction)
		{
		}

		public void Ray(float2 origin, float2 direction)
		{
		}

		public void Ray(Ray ray, float length)
		{
		}

		public void Arc(float3 center, float3 start, float3 end)
		{
		}

		public void Arc(float2 center, float2 start, float2 end)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle = false)
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

		public void Cross(float3 position, float size = 1f)
		{
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3)
		{
		}

		public void Arrow(float3 from, float3 to)
		{
		}

		public void Arrow(float2 from, float2 to)
		{
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize)
		{
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width = 60f)
		{
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size)
		{
		}

		public void Ray(float3 origin, float3 direction, Color color)
		{
		}

		public void Ray(float2 origin, float2 direction, Color color)
		{
		}

		public void Ray(Ray ray, float length, Color color)
		{
		}

		public void Arc(float3 center, float3 start, float3 end, Color color)
		{
		}

		public void Arc(float2 center, float2 start, float2 end, Color color)
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

		public void Cross(float3 position, float size, Color color)
		{
		}

		public void Cross(float3 position, Color color)
		{
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3, Color color)
		{
		}

		public void Arrow(float3 from, float3 to, Color color)
		{
		}

		public void Arrow(float2 from, float2 to, Color color)
		{
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize, Color color)
		{
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction, Color color)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width, Color color)
		{
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, Color color)
		{
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size, Color color)
		{
		}

		public void Line(float3 a, float3 b, Color color)
		{
		}

		public void Circle(float2 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		public void Circle(float2 center, float radius, Color color)
		{
		}

		public void Circle(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
		}

		public void Circle(float3 center, float radius, Color color)
		{
		}

		public void WirePill(float2 a, float2 b, float radius, Color color)
		{
		}

		public void WirePill(float2 position, float2 direction, float length, float radius, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle, Color color)
		{
		}

		[BurstDiscard]
		public void Polyline(float2[] points, Color color)
		{
		}

		public void Polyline(NativeArray<float2> points, bool cycle, Color color)
		{
		}

		public void Polyline(NativeArray<float2> points, Color color)
		{
		}

		public void Cross(float2 position, float size, Color color)
		{
		}

		public void Cross(float2 position, Color color)
		{
		}

		public void WireRectangle(float3 center, float2 size, Color color)
		{
		}

		public void WireRectangle(Rect rect, Color color)
		{
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize, Color color)
		{
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize, Color color)
		{
		}
	}
}
