using UnityEngine;

namespace RootMotion
{
	public static class QuaTools
	{
		public static float GetYaw(Quaternion space, Vector3 forward)
		{
			return 0f;
		}

		public static float GetPitch(Quaternion space, Vector3 forward)
		{
			return 0f;
		}

		public static float GetBank(Quaternion space, Vector3 forward, Vector3 up)
		{
			return 0f;
		}

		public static float GetYaw(Quaternion space, Quaternion rotation)
		{
			return 0f;
		}

		public static float GetPitch(Quaternion space, Quaternion rotation)
		{
			return 0f;
		}

		public static float GetBank(Quaternion space, Quaternion rotation)
		{
			return 0f;
		}

		public static Quaternion Lerp(Quaternion fromRotation, Quaternion toRotation, float weight)
		{
			return default(Quaternion);
		}

		public static Quaternion Slerp(Quaternion fromRotation, Quaternion toRotation, float weight)
		{
			return default(Quaternion);
		}

		public static Quaternion LinearBlend(Quaternion q, float weight)
		{
			return default(Quaternion);
		}

		public static Quaternion SphericalBlend(Quaternion q, float weight)
		{
			return default(Quaternion);
		}

		public static Quaternion FromToAroundAxis(Vector3 fromDirection, Vector3 toDirection, Vector3 axis)
		{
			return default(Quaternion);
		}

		public static Quaternion RotationToLocalSpace(Quaternion space, Quaternion rotation)
		{
			return default(Quaternion);
		}

		public static Quaternion FromToRotation(Quaternion from, Quaternion to)
		{
			return default(Quaternion);
		}

		public static Vector3 GetAxis(Vector3 v)
		{
			return default(Vector3);
		}

		public static Quaternion ClampRotation(Quaternion rotation, float clampWeight, int clampSmoothing)
		{
			return default(Quaternion);
		}

		public static float ClampAngle(float angle, float clampWeight, int clampSmoothing)
		{
			return 0f;
		}

		public static Quaternion MatchRotation(Quaternion targetRotation, Vector3 targetAxis1, Vector3 targetAxis2, Vector3 axis1, Vector3 axis2)
		{
			return default(Quaternion);
		}

		public static Vector3 ToBiPolar(Vector3 euler)
		{
			return default(Vector3);
		}

		public static float ToBiPolar(float angle)
		{
			return 0f;
		}

		public static Quaternion MirrorYZ(Quaternion r, Quaternion space)
		{
			return default(Quaternion);
		}

		public static Quaternion MirrorYZ(Quaternion r)
		{
			return default(Quaternion);
		}
	}
}
