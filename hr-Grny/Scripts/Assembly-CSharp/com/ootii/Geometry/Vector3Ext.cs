using UnityEngine;

namespace com.ootii.Geometry
{
	public static class Vector3Ext
	{
		public static Vector3 Null;

		static Vector3Ext()
		{
		}

		public static float SignedAngle(Vector3 rFrom, Vector3 rTo, Vector3 rAxis)
		{
			return 0f;
		}

		public static float SignedAngle(Vector3 rFrom, Vector3 rTo)
		{
			return 0f;
		}

		public static float AngleTo(this Vector3 rFrom, Vector3 rTo)
		{
			return 0f;
		}

		public static void DecomposeYawPitch(Transform rOwner, Vector3 rFrom, Vector3 rTo, ref float rYaw, ref float rPitch)
		{
		}

		public static float HorizontalMagnitude(this Vector3 rVector)
		{
			return 0f;
		}

		public static float HorizontalSqrMagnitude(this Vector3 rVector)
		{
			return 0f;
		}

		public static float HorizontalAngleTo(this Vector3 rFrom, Vector3 rTo)
		{
			return 0f;
		}

		public static float HorizontalAngleTo(this Vector3 rFrom, Vector3 rTo, Vector3 rUp)
		{
			return 0f;
		}

		public static float HorizontalAngleFrom(this Vector3 rTo, Vector3 rFrom)
		{
			return 0f;
		}

		public static float DistanceTo(this Vector3 rFrom, Vector3 rTo, float rYTolerance)
		{
			return 0f;
		}

		public static Vector3 DirectionTo(this Vector3 rFrom, Vector3 rTo)
		{
			return default(Vector3);
		}

		public static Vector3 NormalizeRotations(this Vector3 rThis)
		{
			return default(Vector3);
		}

		public static Vector3 AddRotation(this Vector3 rFrom, Vector3 rTo)
		{
			return default(Vector3);
		}

		public static Vector3 AddRotation(this Vector3 rFrom, float rX, float rY, float rZ)
		{
			return default(Vector3);
		}

		public static void FindOrthogonals(Vector3 rNormal, ref Vector3 rOrthoUp, ref Vector3 rOrthoRight)
		{
		}

		public static Vector3 PlaneNormal(Vector3 rVertexA, Vector3 rVertexB, Vector3 rVertexC)
		{
			return default(Vector3);
		}

		public static void PlaneFrom3Points(out Vector3 planeNormal, out Vector3 planePoint, Vector3 pointA, Vector3 pointB, Vector3 pointC)
		{
			planeNormal = default(Vector3);
			planePoint = default(Vector3);
		}

		public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
		{
			closestPointLine1 = default(Vector3);
			closestPointLine2 = default(Vector3);
			return false;
		}

		public static Vector3 MoveTo(Vector3 rValue, Vector3 rTarget, float rVelocity, float rDeltaTime)
		{
			return default(Vector3);
		}

		public static Vector2 FromString(this Vector2 rThis, string rString)
		{
			return default(Vector2);
		}

		public static Vector3 FromString(this Vector3 rThis, string rString)
		{
			return default(Vector3);
		}

		public static Vector4 FromString(this Vector4 rThis, string rString)
		{
			return default(Vector4);
		}

		public static float Dot(this Vector3 rThis, Vector3 rTarget)
		{
			return 0f;
		}

		public static Vector3 SmoothStep(Vector3 rStart, Vector3 rEnd, float rTime)
		{
			return default(Vector3);
		}
	}
}
