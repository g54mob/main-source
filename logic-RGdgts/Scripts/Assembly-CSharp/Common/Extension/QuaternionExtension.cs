using UnityEngine;

namespace Common.Extension
{
	public static class QuaternionExtension
	{
		public static Vector3 GetSafeSignedEuler(this Quaternion q)
		{
			return default(Vector3);
		}

		public static float AngleToSigned180(float angle)
		{
			return 0f;
		}

		public static Vector3 GetPlasmaAngles(this in Quaternion q)
		{
			return default(Vector3);
		}

		public static void SetFromPlasmaAngles(this ref Quaternion q, in Vector3 pitchYawRoll)
		{
		}
	}
}
