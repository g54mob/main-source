using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class DebugDrawUtils
	{
		public static void Line(Vector3 start, Vector3 end, Color color, float duration = 0f)
		{
			UnityEngine.Debug.DrawLine(start, end, color, duration);
		}

		public static void Marker(Vector3 pos, Color color, float duration = 0f)
		{
			Line(pos, pos + Vector3.up, color, duration);
		}

		public static void Arrow(Vector3 pos, float dir, Color color, float duration = 0f, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
		{
			Vector3 vector = Quaternion.Euler(0f, dir, 0f) * Vector3.forward;
			UnityEngine.Debug.DrawRay(pos, vector, color, duration);
			Vector3 vector2 = Quaternion.LookRotation(vector) * Quaternion.Euler(0f, 180f + arrowHeadAngle, 0f) * new Vector3(0f, 0f, 1f);
			Vector3 vector3 = Quaternion.LookRotation(vector) * Quaternion.Euler(0f, 180f - arrowHeadAngle, 0f) * new Vector3(0f, 0f, 1f);
			UnityEngine.Debug.DrawRay(pos + vector, vector2 * arrowHeadLength, color, duration);
			UnityEngine.Debug.DrawRay(pos + vector, vector3 * arrowHeadLength, color, duration);
		}

		public static void Bounds(GridBounds bounds, Color color, float duration = 0f)
		{
			Bounds(bounds.Min.ToWorldPosition(), bounds.Max.ToWorldPosition(), color, duration);
		}

		public static void Bounds(Vector3 min, Vector3 max, Color color, float duration = 0f)
		{
			Vector3 vector = new Vector3(min.x, min.y, min.z);
			Vector3 vector2 = new Vector3(max.x, max.y, max.z);
			Vector3 vector3 = new Vector3(min.x, min.y, max.z);
			Vector3 vector4 = new Vector3(min.x, max.y, min.z);
			Vector3 vector5 = new Vector3(max.x, min.y, min.z);
			Vector3 vector6 = new Vector3(min.x, max.y, max.z);
			Vector3 vector7 = new Vector3(max.x, min.y, max.z);
			Vector3 vector8 = new Vector3(max.x, max.y, min.z);
			Line(vector6, vector2, color, duration);
			Line(vector2, vector8, color, duration);
			Line(vector8, vector4, color, duration);
			Line(vector4, vector6, color, duration);
			Line(vector3, vector7, color, duration);
			Line(vector7, vector5, color, duration);
			Line(vector5, vector, color, duration);
			Line(vector, vector3, color, duration);
			Line(vector6, vector3, color, duration);
			Line(vector2, vector7, color, duration);
			Line(vector8, vector5, color, duration);
			Line(vector4, vector, color, duration);
		}

		public static void Bounds(Vector3 size, Matrix4x4 transform, Color color, float duration = 0f)
		{
			Vector3 vector = -size / 2f;
			Vector3 vector2 = size / 2f;
			Vector3 vector3 = transform.MultiplyPoint(new Vector3(vector.x, vector.y, vector.z));
			Vector3 vector4 = transform.MultiplyPoint(new Vector3(vector2.x, vector2.y, vector2.z));
			Vector3 vector5 = transform.MultiplyPoint(new Vector3(vector.x, vector.y, vector2.z));
			Vector3 vector6 = transform.MultiplyPoint(new Vector3(vector.x, vector2.y, vector.z));
			Vector3 vector7 = transform.MultiplyPoint(new Vector3(vector2.x, vector.y, vector.z));
			Vector3 vector8 = transform.MultiplyPoint(new Vector3(vector.x, vector2.y, vector2.z));
			Vector3 vector9 = transform.MultiplyPoint(new Vector3(vector2.x, vector.y, vector2.z));
			Vector3 vector10 = transform.MultiplyPoint(new Vector3(vector2.x, vector2.y, vector.z));
			Line(vector8, vector4, color, duration);
			Line(vector4, vector10, color, duration);
			Line(vector10, vector6, color, duration);
			Line(vector6, vector8, color, duration);
			Line(vector5, vector9, color, duration);
			Line(vector9, vector7, color, duration);
			Line(vector7, vector3, color, duration);
			Line(vector3, vector5, color, duration);
			Line(vector8, vector5, color, duration);
			Line(vector4, vector9, color, duration);
			Line(vector10, vector7, color, duration);
			Line(vector6, vector3, color, duration);
		}

		public static void ConvexPolygon(ConvexPolygon polygon, Color color, float duration = 0f)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (Vector2 point in polygon.Points)
			{
				list.Add(new Vector3(point.x, 0f, point.y));
			}
			LineList(list, color, Vector3.zero, joinEnds: true, duration);
		}

		public static void LineList(List<Vector3> lines, Color color, Vector3 origin, bool joinEnds = false, float duration = 0f)
		{
			if (lines.Count > 1)
			{
				Line(origin + lines[0], origin + lines[1], color, duration);
				for (int i = 1; i < lines.Count; i++)
				{
					Line(origin + lines[i - 1], origin + lines[i], color, duration);
				}
				if (joinEnds)
				{
					Line(origin + lines[0], origin + lines[lines.Count - 1], color, duration);
				}
			}
		}

		public static void Circle(Vector3 center, float radius, Color color, float duration = 0f, int segments = 20)
		{
			Vector3 vector = Vector3.zero;
			for (float num = 0f; num < 360f; num += 360f / (float)segments)
			{
				float f = num * ((float)Math.PI / 180f);
				Vector3 vector2 = center + new Vector3(Mathf.Sin(f) * radius, 0f, Mathf.Cos(f) * radius);
				if (num > 0f)
				{
					Line(vector2, vector, color, duration);
				}
				vector = vector2;
			}
			Line(vector, center + new Vector3(Mathf.Sin(0f) * radius, 0f, Mathf.Cos(0f) * radius), color, duration);
		}

		public static void DebugCylinder(Vector3 start, Vector3 end, float radius, Color color, float duration = 0f)
		{
			Vector3 vector = (end - start).normalized * radius;
			Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
			Circle(start, radius, color, duration);
			Circle(end, radius, color, duration);
			Circle((start + end) * 0.5f, radius, color, duration);
			Line(start + vector3, end + vector3, color, duration);
			Line(start - vector3, end - vector3, color, duration);
			Line(start + vector2, end + vector2, color, duration);
			Line(start - vector2, end - vector2, color, duration);
			Line(start - vector3, start + vector3, color, duration);
			Line(start - vector2, start + vector2, color, duration);
			Line(end - vector3, end + vector3, color, duration);
			Line(end - vector2, end + vector2, color, duration);
		}
	}
}
