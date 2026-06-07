using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class QuadMath
	{
		public static void Calc2DQuadRightUp(float degreeRotation, out Vector2 right, out Vector2 up)
		{
			right = Vector2.right;
			up = Vector2.up;
			Quaternion quaternion = Quaternion.AngleAxis(degreeRotation, Vector3.forward);
			right = quaternion * right;
			up = quaternion * up;
		}

		public static List<Vector2> Calc2DQuadCornerPoints(Vector2 quadCenter, Vector2 quadSize, float degreeRotation)
		{
			Vector2 right = Vector2.right;
			Vector2 up = Vector2.up;
			Calc2DQuadRightUp(degreeRotation, out right, out up);
			Vector2 vector = quadSize * 0.5f;
			return new List<Vector2>
			{
				quadCenter - right * vector.x + up * vector.y,
				quadCenter + right * vector.x + up * vector.y,
				quadCenter + right * vector.x - up * vector.y,
				quadCenter - right * vector.x - up * vector.y
			};
		}

		public static List<Vector2> Calc2DQuadCornerPoints(Vector2 quadCenter, Vector2 quadSize, Vector2 right, Vector2 up)
		{
			Vector2 vector = quadSize * 0.5f;
			return new List<Vector2>
			{
				quadCenter - right * vector.x + up * vector.y,
				quadCenter + right * vector.x + up * vector.y,
				quadCenter + right * vector.x - up * vector.y,
				quadCenter - right * vector.x - up * vector.y
			};
		}

		public static List<Vector3> Calc3DQuadCornerPoints(Vector3 quadCenter, Vector2 quadSize, Quaternion quadRotation)
		{
			Vector3 vector = quadRotation * Vector3.right;
			Vector3 vector2 = quadRotation * Vector3.up;
			Vector3 vector3 = quadSize * 0.5f;
			return new List<Vector3>
			{
				quadCenter - vector * vector3.x + vector2 * vector3.y,
				quadCenter + vector * vector3.x + vector2 * vector3.y,
				quadCenter + vector * vector3.x - vector2 * vector3.y,
				quadCenter - vector * vector3.x - vector2 * vector3.y
			};
		}

		public static Vector3 Calc3DQuadCorner(Vector3 quadCenter, Vector2 quadSize, Quaternion quadRotation, QuadCorner quadCorner)
		{
			Vector3 vector = quadRotation * Vector3.right;
			Vector3 vector2 = quadRotation * Vector3.up;
			Vector3 vector3 = quadSize * 0.5f;
			switch (quadCorner)
			{
			case QuadCorner.TopLeft:
				return quadCenter - vector * vector3.x + vector2 * vector3.y;
			case QuadCorner.TopRight:
				return quadCenter + vector * vector3.x + vector2 * vector3.y;
			case QuadCorner.BottomRight:
				return quadCenter + vector * vector3.x - vector2 * vector3.y;
			default:
				return quadCenter - vector * vector3.x - vector2 * vector3.y;
			}
		}

		public static OBB Calc3DQuadOBB(Vector3 quadCenter, Vector2 quadSize, Quaternion quadRotation, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			Vector3 size = quadSize + epsilon.SizeEps;
			size.z = epsilon.ExtrudeEps * 2f;
			return new OBB(quadCenter, size, quadRotation);
		}

		public static bool Raycast(Ray ray, out float t, Vector3 quadCenter, float quadWidth, float quadHeight, Vector3 quadRight, Vector3 quadUp, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			t = 0f;
			Vector3 vector = Vector3.Normalize(Vector3.Cross(quadRight, quadUp));
			Plane plane = new Plane(vector, quadCenter);
			if (plane.Raycast(ray, out var enter) && Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, quadCenter, quadWidth, quadHeight, quadRight, quadUp, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(plane.normal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = Calc3DQuadOBB(quadCenter, new Vector2(quadWidth, quadHeight), Quaternion.LookRotation(vector, quadUp), epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool RaycastWire(Ray ray, out float t, Vector3 quadCenter, float quadWidth, float quadHeight, Vector3 quadRight, Vector3 quadUp, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			t = 0f;
			Vector3 vector = Vector3.Normalize(Vector3.Cross(quadRight, quadUp));
			Plane plane = new Plane(vector, quadCenter);
			Vector2 quadSize = new Vector2(quadWidth, quadHeight);
			Quaternion quadRotation = Quaternion.LookRotation(vector, quadUp);
			if (plane.Raycast(ray, out var enter))
			{
				Vector3 point = ray.GetPoint(enter);
				List<Vector3> list = Calc3DQuadCornerPoints(quadCenter, quadSize, quadRotation);
				if (point.GetDistanceToSegment(list[0], list[1]) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
				if (point.GetDistanceToSegment(list[1], list[2]) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
				if (point.GetDistanceToSegment(list[2], list[3]) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
				if (point.GetDistanceToSegment(list[3], list[0]) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(plane.normal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = Calc3DQuadOBB(quadCenter, quadSize, Quaternion.LookRotation(vector, quadUp), epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool Contains3DPoint(Vector3 point, bool checkOnPlane, Vector3 quadCenter, float quadWidth, float quadHeight, Vector3 quadRight, Vector3 quadUp, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			Plane plane = new Plane(Vector3.Cross(quadRight, quadUp).normalized, quadCenter);
			if (checkOnPlane && plane.GetAbsDistanceToPoint(point) > epsilon.ExtrudeEps)
			{
				return false;
			}
			quadWidth += epsilon.WidthEps;
			quadHeight += epsilon.HeightEps;
			Vector3 v = point - quadCenter;
			float num = v.AbsDot(quadRight);
			float num2 = v.AbsDot(quadUp);
			if (num > quadWidth * 0.5f)
			{
				return false;
			}
			if (num2 > quadHeight * 0.5f)
			{
				return false;
			}
			return true;
		}

		public static bool Contains2DPoint(Vector2 point, Vector2 quadCenter, float quadWidth, float quadHeight, float degreeRotation, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			Calc2DQuadRightUp(degreeRotation, out var right, out var up);
			return Contains2DPoint(point, quadCenter, quadWidth, quadHeight, right, up, epsilon);
		}

		public static bool Contains2DPoint(Vector2 point, Vector2 quadCenter, float quadWidth, float quadHeight, Vector2 quadRight, Vector2 quadUp, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			quadWidth += epsilon.WidthEps;
			quadHeight += epsilon.HeightEps;
			Vector2 v = point - quadCenter;
			float num = v.AbsDot(quadRight);
			float num2 = v.AbsDot(quadUp);
			if (num > quadWidth * 0.5f)
			{
				return false;
			}
			if (num2 > quadHeight * 0.5f)
			{
				return false;
			}
			return true;
		}

		public static bool Is2DPointOnBorder(Vector2 point, Vector2 quadCenter, float quadWidth, float quadHeight, float degreeRotation, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			Calc2DQuadRightUp(degreeRotation, out var right, out var up);
			return Is2DPointOnBorder(point, quadCenter, quadWidth, quadHeight, right, up, epsilon);
		}

		public static bool Is2DPointOnBorder(Vector2 point, Vector2 quadCenter, float quadWidth, float quadHeight, Vector2 quadRight, Vector2 quadUp, QuadEpsilon epsilon = default(QuadEpsilon))
		{
			SegmentEpsilon epsilon2 = new SegmentEpsilon
			{
				PtOnSegmentEps = epsilon.WireEps
			};
			List<Vector2> list = Calc2DQuadCornerPoints(quadCenter, new Vector2(quadWidth, quadHeight), quadRight, quadUp);
			for (int i = 0; i < list.Count; i++)
			{
				Vector2 startPoint = list[i];
				Vector2 endPoint = list[(i + 1) % list.Count];
				if (SegmentMath.Is2DPointOnSegment(point, startPoint, endPoint, epsilon2))
				{
					return true;
				}
			}
			return false;
		}
	}
}
