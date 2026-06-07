using UnityEngine;

namespace MalbersAnimations.PathCreation.Utility
{
	public static class MathUtility
	{
		private class PosRotScale
		{
			public readonly Vector3 position;

			public readonly Quaternion rotation;

			public readonly Vector3 scale;

			public PosRotScale(Transform t)
			{
				position = t.position;
				rotation = t.rotation;
				scale = t.localScale;
			}

			public void SetTransform(Transform t)
			{
				t.position = position;
				t.rotation = rotation;
				t.localScale = scale;
			}
		}

		private static PosRotScale LockTransformToSpace(Transform t, PathSpace space)
		{
			PosRotScale result = new PosRotScale(t);
			switch (space)
			{
			case PathSpace.xy:
				t.eulerAngles = new Vector3(0f, 0f, t.eulerAngles.z);
				t.position = new Vector3(t.position.x, t.position.y, 0f);
				break;
			case PathSpace.xz:
				t.eulerAngles = new Vector3(0f, t.eulerAngles.y, 0f);
				t.position = new Vector3(t.position.x, 0f, t.position.z);
				break;
			}
			float num = Mathf.Max(t.lossyScale.x, t.lossyScale.y, t.lossyScale.z);
			t.localScale = Vector3.one * num;
			return result;
		}

		public static Vector3 TransformPoint(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.TransformPoint(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static Vector3 InverseTransformPoint(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.InverseTransformPoint(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static Vector3 TransformVector(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.TransformVector(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static Vector3 InverseTransformVector(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.InverseTransformVector(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static Vector3 TransformDirection(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.TransformDirection(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static Vector3 InverseTransformDirection(Vector3 p, Transform t, PathSpace space)
		{
			PosRotScale posRotScale = LockTransformToSpace(t, space);
			Vector3 result = t.InverseTransformDirection(p);
			posRotScale.SetTransform(t);
			return result;
		}

		public static bool LineSegmentsIntersect(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
		{
			float num = (b2.x - b1.x) * (a1.y - a2.y) - (a1.x - a2.x) * (b2.y - b1.y);
			if (num == 0f)
			{
				return false;
			}
			float num2 = ((b1.y - b2.y) * (a1.x - b1.x) + (b2.x - b1.x) * (a1.y - b1.y)) / num;
			float num3 = ((a1.y - a2.y) * (a1.x - b1.x) + (a2.x - a1.x) * (a1.y - b1.y)) / num;
			if (num2 >= 0f && num2 <= 1f && num3 >= 0f)
			{
				return num3 <= 1f;
			}
			return false;
		}

		public static bool LinesIntersect(Vector2 a1, Vector2 a2, Vector2 a3, Vector2 a4)
		{
			return (a1.x - a2.x) * (a3.y - a4.y) - (a1.y - a2.y) * (a3.x - a4.x) != 0f;
		}

		public static Vector2 PointOfLineLineIntersection(Vector2 a1, Vector2 a2, Vector2 a3, Vector2 a4)
		{
			float num = (a1.x - a2.x) * (a3.y - a4.y) - (a1.y - a2.y) * (a3.x - a4.x);
			if (num == 0f)
			{
				Debug.LogError("Lines are parallel, please check that this is not the case before calling line intersection method");
				return Vector2.zero;
			}
			float num2 = ((a1.x - a3.x) * (a3.y - a4.y) - (a1.y - a3.y) * (a3.x - a4.x)) / num;
			return a1 + (a2 - a1) * num2;
		}

		public static Vector2 ClosestPointOnLineSegment(Vector2 p, Vector2 a, Vector2 b)
		{
			Vector2 vector = b - a;
			Vector2 lhs = p - a;
			float sqrMagnitude = vector.sqrMagnitude;
			if (sqrMagnitude == 0f)
			{
				return a;
			}
			float num = Mathf.Clamp01(Vector2.Dot(lhs, vector) / sqrMagnitude);
			return a + vector * num;
		}

		public static Vector3 ClosestPointOnLineSegment(Vector3 p, Vector3 a, Vector3 b)
		{
			Vector3 vector = b - a;
			Vector3 lhs = p - a;
			float sqrMagnitude = vector.sqrMagnitude;
			if (sqrMagnitude == 0f)
			{
				return a;
			}
			float num = Mathf.Clamp01(Vector3.Dot(lhs, vector) / sqrMagnitude);
			return a + vector * num;
		}

		public static int SideOfLine(Vector2 a, Vector2 b, Vector2 c)
		{
			return (int)Mathf.Sign((c.x - a.x) * (0f - b.y + a.y) + (c.y - a.y) * (b.x - a.x));
		}

		public static float MinAngle(Vector3 a, Vector3 b, Vector3 c)
		{
			return Vector3.Angle(a - b, c - b);
		}

		public static bool PointInTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
		{
			float num = 0.5f * ((0f - b.y) * c.x + a.y * (0f - b.x + c.x) + a.x * (b.y - c.y) + b.x * c.y);
			float num2 = 1f / (2f * num) * (a.y * c.x - a.x * c.y + (c.y - a.y) * p.x + (a.x - c.x) * p.y);
			float num3 = 1f / (2f * num) * (a.x * b.y - a.y * b.x + (a.y - b.y) * p.x + (b.x - a.x) * p.y);
			if (num2 >= 0f && num3 >= 0f)
			{
				return num2 + num3 <= 1f;
			}
			return false;
		}

		public static bool PointsAreClockwise(Vector2[] points)
		{
			float num = 0f;
			for (int i = 0; i < points.Length; i++)
			{
				int num2 = (i + 1) % points.Length;
				num += (points[num2].x - points[i].x) * (points[num2].y + points[i].y);
			}
			return num >= 0f;
		}
	}
}
