using UnityEngine;

namespace com.ootii.Geometry
{
	public static class QuaternionExt
	{
		public static float EPSILON;

		public static Quaternion InverseIdentity;

		public static bool IsEqual(Quaternion rLeft, Quaternion rRight)
		{
			return false;
		}

		public static bool IsEqual(ref Quaternion rLeft, ref Quaternion rRight)
		{
			return false;
		}

		public static bool IsIdentity(this Quaternion rThis)
		{
			return false;
		}

		public static Quaternion RotationTo(this Quaternion rFrom, Quaternion rTo)
		{
			return default(Quaternion);
		}

		public static Quaternion OrientTo(this Quaternion rFrom, Quaternion rTo)
		{
			return default(Quaternion);
		}

		public static Quaternion Subtract(this Quaternion rLHS, Quaternion rRHS)
		{
			return default(Quaternion);
		}

		public static Quaternion Negate(this Quaternion rThis)
		{
			return default(Quaternion);
		}

		public static Quaternion Conjugate(this Quaternion rThis)
		{
			return default(Quaternion);
		}

		public static Vector3 Forward(this Quaternion rThis)
		{
			return default(Vector3);
		}

		public static Vector3 Up(this Quaternion rThis)
		{
			return default(Vector3);
		}

		public static Vector3 Right(this Quaternion rThis)
		{
			return default(Vector3);
		}

		public static Quaternion FromToRotation(Vector3 u, Vector3 v)
		{
			return default(Quaternion);
		}

		public static void DecomposeSwingTwist(this Quaternion rThis, Vector3 rAxis, ref Quaternion rSwing, ref Quaternion rTwist)
		{
		}

		public static void DecomposeTwistSwingAxisAngles(this Quaternion rThis, Vector3 rTwistAxis, ref float rTwistAngle, ref Vector3 rSwingAxis, ref float rSwingAngle)
		{
		}

		public static Quaternion FromString(this Quaternion rThis, string rString)
		{
			return default(Quaternion);
		}
	}
}
