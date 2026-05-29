using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Util
{
	public class Draw
	{
		public static readonly Draw Debug;

		public static readonly Draw Gizmos;

		private bool gizmos;

		private Matrix4x4 matrix;

		private void SetColor(Color color)
		{
		}

		public void Polyline(List<Vector3> points, Color color, bool cycle = false)
		{
		}

		public void Line(Vector3 a, Vector3 b, Color color)
		{
		}

		public void CircleXZ(Vector3 center, float radius, Color color, float startAngle = 0f, float endAngle = (float)Math.PI * 2f)
		{
		}

		public void Cylinder(Vector3 position, Vector3 up, float height, float radius, Color color)
		{
		}

		public void CrossXZ(Vector3 position, Color color, float size = 1f)
		{
		}

		public void Bezier(Vector3 a, Vector3 b, Color color)
		{
		}
	}
}
