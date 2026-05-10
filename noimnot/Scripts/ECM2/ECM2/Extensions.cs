using UnityEngine;

namespace ECM2
{
	public static class Extensions
	{
		public static int square(this int value)
		{
			return 0;
		}

		public static float square(this float value)
		{
			return 0f;
		}

		public static bool isZero(this float value)
		{
			return false;
		}

		public static Vector3 onlyX(this Vector3 vector3)
		{
			return default(Vector3);
		}

		public static Vector3 onlyY(this Vector3 vector3)
		{
			return default(Vector3);
		}

		public static Vector3 onlyZ(this Vector3 vector3)
		{
			return default(Vector3);
		}

		public static Vector3 onlyXY(this Vector3 vector3)
		{
			return default(Vector3);
		}

		public static Vector3 onlyXZ(this Vector3 vector3)
		{
			return default(Vector3);
		}

		public static bool isZero(this Vector2 vector2)
		{
			return false;
		}

		public static bool isZero(this Vector3 vector3)
		{
			return false;
		}

		public static bool isExceeding(this Vector3 vector3, float magnitude)
		{
			return false;
		}

		public static Vector3 normalized(this Vector3 vector3, out float magnitude)
		{
			magnitude = default(float);
			return default(Vector3);
		}

		public static float dot(this Vector3 vector3, Vector3 otherVector3)
		{
			return 0f;
		}

		public static Vector3 projectedOn(this Vector3 thisVector, Vector3 normal)
		{
			return default(Vector3);
		}

		public static Vector3 projectedOnPlane(this Vector3 thisVector, Vector3 planeNormal)
		{
			return default(Vector3);
		}

		public static Vector3 clampedTo(this Vector3 vector3, float maxLength)
		{
			return default(Vector3);
		}

		public static Vector3 perpendicularTo(this Vector3 thisVector, Vector3 otherVector)
		{
			return default(Vector3);
		}

		public static Vector3 tangentTo(this Vector3 thisVector, Vector3 normal, Vector3 up)
		{
			return default(Vector3);
		}

		public static Vector3 relativeTo(this Vector3 vector3, Transform relativeToThis, bool isPlanar = true)
		{
			return default(Vector3);
		}

		public static Vector3 relativeTo(this Vector3 vector3, Transform relativeToThis, Vector3 upAxis, bool isPlanar = true)
		{
			return default(Vector3);
		}

		public static Quaternion clampPitch(this Quaternion quaternion, float minPitchAngle, float maxPitchAngle)
		{
			return default(Quaternion);
		}
	}
}
