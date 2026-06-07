using System;
using UnityEngine;

namespace Dreamteck
{
	public static class LinearAlgebraUtility
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public static Vector3 ProjectOnLine(Vector3 fromPoint, Vector3 toPoint, Vector3 project)
		{
			Vector3 vector = Vector3.Project(project - fromPoint, toPoint - fromPoint) + fromPoint;
			Vector3 rhs = toPoint - fromPoint;
			Vector3 lhs = vector - fromPoint;
			if (Vector3.Dot(lhs, rhs) > 0f)
			{
				if (lhs.sqrMagnitude <= rhs.sqrMagnitude)
				{
					return vector;
				}
				return toPoint;
			}
			return fromPoint;
		}

		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
		{
			Vector3 vector = b - a;
			return Vector3.Dot(value - a, vector) / Vector3.Dot(vector, vector);
		}

		public static float DistanceOnSphere(Vector3 from, Vector3 to, float radius)
		{
			float num = 0f;
			if (from == to)
			{
				return 0f;
			}
			if (from == -to)
			{
				return MathF.PI * radius;
			}
			return Mathf.Sqrt(2f) * radius * Mathf.Sqrt(1f - Vector3.Dot(from, to));
		}

		public static Vector3 FlattenVector(Vector3 input, Axis axis, float flatValue = 0f)
		{
			switch (axis)
			{
			case Axis.X:
				input.x = flatValue;
				break;
			case Axis.Y:
				input.y = flatValue;
				break;
			case Axis.Z:
				input.z = flatValue;
				break;
			}
			return input;
		}
	}
}
