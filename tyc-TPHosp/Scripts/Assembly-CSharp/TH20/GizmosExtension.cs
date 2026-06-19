using System;
using UnityEngine;

namespace TH20
{
	public static class GizmosExtension
	{
		public static void Line(Vector3 start, Vector3 end, Color color)
		{
			Gizmos.color = color;
			Gizmos.DrawLine(start, end);
		}

		public static void Circle(Vector3 center, float radius, Color color, int segments = 20)
		{
			Vector3 vector = Vector3.zero;
			for (float num = 0f; num < 360f; num += 360f / (float)segments)
			{
				float f = num * ((float)Math.PI / 180f);
				Vector3 vector2 = center + new Vector3(Mathf.Sin(f) * radius, 0f, Mathf.Cos(f) * radius);
				if (num > 0f)
				{
					Line(vector2, vector, color);
				}
				vector = vector2;
			}
			Line(vector, center + new Vector3(Mathf.Sin(0f) * radius, 0f, Mathf.Cos(0f) * radius), color);
		}

		public static void DebugCylinder(Vector3 start, Vector3 end, float radius, Color color)
		{
			Vector3 vector = (end - start).normalized * radius;
			Vector3 vector2 = Vector3.Slerp(vector, -vector, 0.5f);
			Vector3 vector3 = Vector3.Cross(vector, vector2).normalized * radius;
			Circle(start, radius, color);
			Circle(end, radius, color);
			Circle((start + end) * 0.5f, radius, color);
			Line(start + vector3, end + vector3, color);
			Line(start - vector3, end - vector3, color);
			Line(start + vector2, end + vector2, color);
			Line(start - vector2, end - vector2, color);
			Line(start - vector3, start + vector3, color);
			Line(start - vector2, start + vector2, color);
			Line(end - vector3, end + vector3, color);
			Line(end - vector2, end + vector2, color);
		}
	}
}
