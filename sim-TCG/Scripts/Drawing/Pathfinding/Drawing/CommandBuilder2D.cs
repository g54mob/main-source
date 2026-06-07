using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Drawing
{
	public struct CommandBuilder2D
	{
		private CommandBuilder draw;

		private bool xy;

		private static readonly float3 XY_UP = new float3(0f, 0f, 1f);

		private static readonly float3 XZ_UP = new float3(0f, 1f, 0f);

		private static readonly quaternion XY_TO_XZ_ROTATION = quaternion.RotateX(-MathF.PI / 2f);

		private static readonly quaternion XZ_TO_XZ_ROTATION = quaternion.identity;

		private static readonly float4x4 XZ_TO_XY_MATRIX = new float4x4(new float4(1f, 0f, 0f, 0f), new float4(0f, 0f, 1f, 0f), new float4(0f, 1f, 0f, 0f), new float4(0f, 0f, 0f, 1f));

		public CommandBuilder2D(CommandBuilder draw, bool xy)
		{
			this.draw = draw;
			this.xy = xy;
		}

		public unsafe void Line(float2 a, float2 b)
		{
			draw.Reserve<CommandBuilder.LineData>();
			UnsafeAppendBuffer* buffer = draw.buffer;
			int length = buffer->Length;
			int length2 = length + 4 + 24;
			byte* num = buffer->Ptr + length;
			*(int*)num = 5;
			CommandBuilder.LineData* ptr = (CommandBuilder.LineData*)(num + 4);
			if (xy)
			{
				ptr->a = new float3(a, 0f);
				ptr->b = new float3(b, 0f);
			}
			else
			{
				ptr->a = new float3(a.x, 0f, a.y);
				ptr->b = new float3(b.x, 0f, b.y);
			}
			buffer->Length = length2;
		}

		public unsafe void Line(float2 a, float2 b, Color color)
		{
			draw.Reserve<Color32, CommandBuilder.LineData>();
			UnsafeAppendBuffer* buffer = draw.buffer;
			int length = buffer->Length;
			int length2 = length + 4 + 24 + 4;
			byte* num = buffer->Ptr + length;
			*(int*)num = 261;
			((int*)num)[1] = (int)CommandBuilder.ConvertColor(color);
			CommandBuilder.LineData* ptr = (CommandBuilder.LineData*)(num + 8);
			if (xy)
			{
				ptr->a = new float3(a, 0f);
				ptr->b = new float3(b, 0f);
			}
			else
			{
				ptr->a = new float3(a.x, 0f, a.y);
				ptr->b = new float3(b.x, 0f, b.y);
			}
			buffer->Length = length2;
		}

		public void Line(float3 a, float3 b)
		{
			draw.Line(a, b);
		}

		public void Circle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			Circle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle);
		}

		public void Circle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
				draw.CircleXZInternal(new float3(center.x, center.z, center.y), radius, startAngle, endAngle);
				draw.PopMatrix();
			}
			else
			{
				draw.CircleXZInternal(center, radius, startAngle, endAngle);
			}
		}

		public void SolidCircle(float2 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			SolidCircle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle);
		}

		public void SolidCircle(float3 center, float radius, float startAngle = 0f, float endAngle = MathF.PI * 2f)
		{
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
			}
			draw.SolidCircleXZInternal(new float3(center.x, 0f - center.z, center.y), radius, startAngle, endAngle);
			if (xy)
			{
				draw.PopMatrix();
			}
		}

		public void WirePill(float2 a, float2 b, float radius)
		{
			WirePill(a, b - a, math.length(b - a), radius);
		}

		public void WirePill(float2 position, float2 direction, float length, float radius)
		{
			direction = math.normalizesafe(direction);
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
				return;
			}
			if (length <= 0f || math.all(direction == 0f))
			{
				Circle(position, radius);
				return;
			}
			float4x4 matrix = ((!xy) ? new float4x4(new float4(direction.x, 0f, direction.y, 0f), new float4(0f, 1f, 0f, 0f), new float4(math.cross(new float3(direction.x, 0f, direction.y), XZ_UP), 0f), new float4(position.x, 0f, position.y, 1f)) : new float4x4(new float4(direction, 0f, 0f), new float4(math.cross(new float3(direction, 0f), XY_UP), 0f), new float4(0f, 0f, 1f, 0f), new float4(position, 0f, 1f)));
			draw.PushMatrix(matrix);
			Circle(new float2(0f, 0f), radius, MathF.PI / 2f, 4.712389f);
			Line(new float2(0f, 0f - radius), new float2(length, 0f - radius));
			Circle(new float2(length, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
			Line(new float2(0f, radius), new float2(length, radius));
			draw.PopMatrix();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle = false)
		{
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
		}

		public void Polyline(NativeArray<float2> points, bool cycle = false)
		{
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
		}

		public void Cross(float2 position, float size = 1f)
		{
			size *= 0.5f;
			Line(position - new float2(size, 0f), position + new float2(size, 0f));
			Line(position - new float2(0f, size), position + new float2(0f, size));
		}

		public void WireRectangle(float3 center, float2 size)
		{
			draw.WirePlane(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, size);
		}

		public void WireRectangle(Rect rect)
		{
			float2 float5 = rect.min;
			float2 float6 = rect.max;
			Line(new float2(float5.x, float5.y), new float2(float6.x, float5.y));
			Line(new float2(float6.x, float5.y), new float2(float6.x, float6.y));
			Line(new float2(float6.x, float6.y), new float2(float5.x, float6.y));
			Line(new float2(float5.x, float6.y), new float2(float5.x, float5.y));
		}

		public void SolidRectangle(Rect rect)
		{
			draw.SolidPlane(new float3(rect.center.x, rect.center.y, 0f), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, new float2(rect.width, rect.height));
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize)
		{
			draw.WireGrid(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize);
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize)
		{
			draw.WireGrid(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(Matrix4x4 matrix)
		{
			return draw.WithMatrix(matrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeMatrix WithMatrix(float3x3 matrix)
		{
			return draw.WithMatrix(matrix);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeColor WithColor(Color color)
		{
			return draw.WithColor(color);
		}

		[BurstDiscard]
		public CommandBuilder.ScopeLineWidth WithLineWidth(float pixels, bool automaticJoins = true)
		{
			return draw.WithLineWidth(pixels, automaticJoins);
		}

		public void PushMatrix(Matrix4x4 matrix)
		{
			draw.PushMatrix(matrix);
		}

		public void PushMatrix(float4x4 matrix)
		{
			draw.PushMatrix(matrix);
		}

		public void PopMatrix()
		{
			draw.PopMatrix();
		}

		public void Line(Vector3 a, Vector3 b)
		{
			draw.Line(a, b);
		}

		public void Line(Vector2 a, Vector2 b)
		{
			Line(xy ? new Vector3(a.x, a.y, 0f) : new Vector3(a.x, 0f, a.y), xy ? new Vector3(b.x, b.y, 0f) : new Vector3(b.x, 0f, b.y));
		}

		public void Line(Vector3 a, Vector3 b, Color color)
		{
			draw.Line(a, b, color);
		}

		public void Line(Vector2 a, Vector2 b, Color color)
		{
			Line(xy ? new Vector3(a.x, a.y, 0f) : new Vector3(a.x, 0f, a.y), xy ? new Vector3(b.x, b.y, 0f) : new Vector3(b.x, 0f, b.y), color);
		}

		public void Ray(float3 origin, float3 direction)
		{
			draw.Ray(origin, direction);
		}

		public void Ray(float2 origin, float2 direction)
		{
			Ray(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y));
		}

		public void Ray(Ray ray, float length)
		{
			draw.Ray(ray, length);
		}

		public void Arc(float3 center, float3 start, float3 end)
		{
			draw.Arc(center, start, end);
		}

		public void Arc(float2 center, float2 start, float2 end)
		{
			Arc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y));
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		public void Polyline(NativeArray<float3> points, bool cycle = false)
		{
			draw.Polyline(points, cycle);
		}

		public void Cross(float3 position, float size = 1f)
		{
			draw.Cross(position, size);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3)
		{
			draw.Bezier(p0, p1, p2, p3);
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3)
		{
			Bezier(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y));
		}

		public void Arrow(float3 from, float3 to)
		{
			ArrowRelativeSizeHead(from, to, xy ? XY_UP : XZ_UP, 0.2f);
		}

		public void Arrow(float2 from, float2 to)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y));
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize)
		{
			draw.Arrow(from, to, up, headSize);
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headSize);
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction)
		{
			draw.ArrowRelativeSizeHead(from, to, up, headFraction);
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction)
		{
			ArrowRelativeSizeHead(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headFraction);
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width = 60f)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					Quaternion q = Quaternion.LookRotation(direction, xy ? XY_UP : XZ_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					draw.CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
				}
			}
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width = 60f)
		{
			ArrowheadArc(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), offset, width);
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size)
		{
			draw.WireRectangle(center, rotation, size);
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size)
		{
			WireRectangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, size);
		}

		public void Ray(float3 origin, float3 direction, Color color)
		{
			draw.Ray(origin, direction, color);
		}

		public void Ray(float2 origin, float2 direction, Color color)
		{
			Ray(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), color);
		}

		public void Ray(Ray ray, float length, Color color)
		{
			draw.Ray(ray, length, color);
		}

		public void Arc(float3 center, float3 start, float3 end, Color color)
		{
			draw.Arc(center, start, end, color);
		}

		public void Arc(float2 center, float2 start, float2 end, Color color)
		{
			Arc(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? new float3(start, 0f) : new float3(start.x, 0f, start.y), xy ? new float3(end, 0f) : new float3(end.x, 0f, end.y), color);
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(List<Vector3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(Vector3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		[BurstDiscard]
		public void Polyline(float3[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Polyline(NativeArray<float3> points, bool cycle, Color color)
		{
			draw.Polyline(points, cycle, color);
		}

		public void Polyline(NativeArray<float3> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Cross(float3 position, float size, Color color)
		{
			draw.Cross(position, size, color);
		}

		public void Cross(float3 position, Color color)
		{
			Cross(position, 1f, color);
		}

		public void Bezier(float3 p0, float3 p1, float3 p2, float3 p3, Color color)
		{
			draw.Bezier(p0, p1, p2, p3, color);
		}

		public void Bezier(float2 p0, float2 p1, float2 p2, float2 p3, Color color)
		{
			Bezier(xy ? new float3(p0, 0f) : new float3(p0.x, 0f, p0.y), xy ? new float3(p1, 0f) : new float3(p1.x, 0f, p1.y), xy ? new float3(p2, 0f) : new float3(p2.x, 0f, p2.y), xy ? new float3(p3, 0f) : new float3(p3.x, 0f, p3.y), color);
		}

		public void Arrow(float3 from, float3 to, Color color)
		{
			ArrowRelativeSizeHead(from, to, xy ? XY_UP : XZ_UP, 0.2f, color);
		}

		public void Arrow(float2 from, float2 to, Color color)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), color);
		}

		public void Arrow(float3 from, float3 to, float3 up, float headSize, Color color)
		{
			draw.Arrow(from, to, up, headSize, color);
		}

		public void Arrow(float2 from, float2 to, float2 up, float headSize, Color color)
		{
			Arrow(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headSize, color);
		}

		public void ArrowRelativeSizeHead(float3 from, float3 to, float3 up, float headFraction, Color color)
		{
			draw.ArrowRelativeSizeHead(from, to, up, headFraction, color);
		}

		public void ArrowRelativeSizeHead(float2 from, float2 to, float2 up, float headFraction, Color color)
		{
			ArrowRelativeSizeHead(xy ? new float3(from, 0f) : new float3(from.x, 0f, from.y), xy ? new float3(to, 0f) : new float3(to.x, 0f, to.y), xy ? new float3(up, 0f) : new float3(up.x, 0f, up.y), headFraction, color);
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, float width, Color color)
		{
			if (math.any(direction))
			{
				if (offset < 0f)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (offset != 0f)
				{
					draw.PushColor(color);
					Quaternion q = Quaternion.LookRotation(direction, xy ? XY_UP : XZ_UP);
					PushMatrix(Matrix4x4.TRS(origin, q, Vector3.one));
					float num = MathF.PI / 2f - width * (MathF.PI / 360f);
					float num2 = MathF.PI / 2f + width * (MathF.PI / 360f);
					draw.CircleXZInternal(float3.zero, offset, num, num2);
					float3 a = new float3(math.cos(num), 0f, math.sin(num)) * offset;
					float3 b = new float3(math.cos(num2), 0f, math.sin(num2)) * offset;
					float3 float5 = new float3(0f, 0f, 1.4142f * offset);
					Line(a, float5);
					Line(float5, b);
					PopMatrix();
					draw.PopColor();
				}
			}
		}

		public void ArrowheadArc(float3 origin, float3 direction, float offset, Color color)
		{
			ArrowheadArc(origin, direction, offset, 60f, color);
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, float width, Color color)
		{
			ArrowheadArc(xy ? new float3(origin, 0f) : new float3(origin.x, 0f, origin.y), xy ? new float3(direction, 0f) : new float3(direction.x, 0f, direction.y), offset, width, color);
		}

		public void ArrowheadArc(float2 origin, float2 direction, float offset, Color color)
		{
			ArrowheadArc(origin, direction, offset, 60f, color);
		}

		public void WireRectangle(float3 center, quaternion rotation, float2 size, Color color)
		{
			draw.WireRectangle(center, rotation, size, color);
		}

		public void WireRectangle(float2 center, quaternion rotation, float2 size, Color color)
		{
			WireRectangle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), rotation, size, color);
		}

		public void Line(float3 a, float3 b, Color color)
		{
			draw.Line(a, b, color);
		}

		public void Circle(float2 center, float radius, float startAngle, float endAngle, Color color)
		{
			Circle(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), radius, startAngle, endAngle, color);
		}

		public void Circle(float2 center, float radius, Color color)
		{
			Circle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void Circle(float3 center, float radius, float startAngle, float endAngle, Color color)
		{
			draw.PushColor(color);
			if (xy)
			{
				draw.PushMatrix(XZ_TO_XY_MATRIX);
				draw.CircleXZInternal(new float3(center.x, center.z, center.y), radius, startAngle, endAngle);
				draw.PopMatrix();
			}
			else
			{
				draw.CircleXZInternal(center, radius, startAngle, endAngle);
			}
			draw.PopColor();
		}

		public void Circle(float3 center, float radius, Color color)
		{
			Circle(center, radius, 0f, MathF.PI * 2f, color);
		}

		public void WirePill(float2 a, float2 b, float radius, Color color)
		{
			WirePill(a, b - a, math.length(b - a), radius, color);
		}

		public void WirePill(float2 position, float2 direction, float length, float radius, Color color)
		{
			draw.PushColor(color);
			direction = math.normalizesafe(direction);
			if (radius <= 0f)
			{
				Line(position, position + direction * length);
			}
			else if (length <= 0f || math.all(direction == 0f))
			{
				Circle(position, radius);
			}
			else
			{
				float4x4 matrix = ((!xy) ? new float4x4(new float4(direction.x, 0f, direction.y, 0f), new float4(0f, 1f, 0f, 0f), new float4(math.cross(new float3(direction.x, 0f, direction.y), XZ_UP), 0f), new float4(position.x, 0f, position.y, 1f)) : new float4x4(new float4(direction, 0f, 0f), new float4(math.cross(new float3(direction, 0f), XY_UP), 0f), new float4(0f, 0f, 1f, 0f), new float4(position, 0f, 1f)));
				draw.PushMatrix(matrix);
				Circle(new float2(0f, 0f), radius, MathF.PI / 2f, 4.712389f);
				Line(new float2(0f, 0f - radius), new float2(length, 0f - radius));
				Circle(new float2(length, 0f), radius, -MathF.PI / 2f, MathF.PI / 2f);
				Line(new float2(0f, radius), new float2(length, radius));
				draw.PopMatrix();
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Count - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Count > 1)
			{
				Line(points[points.Count - 1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(List<Vector2> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(Vector2[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		[BurstDiscard]
		public void Polyline(float2[] points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[^1], points[0]);
			}
			draw.PopColor();
		}

		[BurstDiscard]
		public void Polyline(float2[] points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Polyline(NativeArray<float2> points, bool cycle, Color color)
		{
			draw.PushColor(color);
			for (int i = 0; i < points.Length - 1; i++)
			{
				Line(points[i], points[i + 1]);
			}
			if (cycle && points.Length > 1)
			{
				Line(points[points.Length - 1], points[0]);
			}
			draw.PopColor();
		}

		public void Polyline(NativeArray<float2> points, Color color)
		{
			Polyline(points, cycle: false, color);
		}

		public void Cross(float2 position, float size, Color color)
		{
			draw.PushColor(color);
			size *= 0.5f;
			Line(position - new float2(size, 0f), position + new float2(size, 0f));
			Line(position - new float2(0f, size), position + new float2(0f, size));
			draw.PopColor();
		}

		public void Cross(float2 position, Color color)
		{
			Cross(position, 1f, color);
		}

		public void WireRectangle(float3 center, float2 size, Color color)
		{
			draw.WirePlane(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, size, color);
		}

		public void WireRectangle(Rect rect, Color color)
		{
			draw.PushColor(color);
			float2 float5 = rect.min;
			float2 float6 = rect.max;
			Line(new float2(float5.x, float5.y), new float2(float6.x, float5.y));
			Line(new float2(float6.x, float5.y), new float2(float6.x, float6.y));
			Line(new float2(float6.x, float6.y), new float2(float5.x, float6.y));
			Line(new float2(float5.x, float6.y), new float2(float5.x, float5.y));
			draw.PopColor();
		}

		public void WireGrid(float2 center, int2 cells, float2 totalSize, Color color)
		{
			draw.WireGrid(xy ? new float3(center, 0f) : new float3(center.x, 0f, center.y), xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize, color);
		}

		public void WireGrid(float3 center, int2 cells, float2 totalSize, Color color)
		{
			draw.WireGrid(center, xy ? XY_TO_XZ_ROTATION : XZ_TO_XZ_ROTATION, cells, totalSize, color);
		}
	}
}
