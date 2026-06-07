using UnityEngine;

namespace MoreMountains.Tools
{
	public static class MMVector4Extensions
	{
		public static float SumComponents(this Vector4 vector)
		{
			return vector.x + vector.y + vector.z + vector.w;
		}

		public static Vector4 MMSetX(this Vector4 vector, float newValue)
		{
			vector.x = newValue;
			return vector;
		}

		public static Vector4 MMSetY(this Vector4 vector, float newValue)
		{
			vector.y = newValue;
			return vector;
		}

		public static Vector4 MMSetZ(this Vector4 vector, float newValue)
		{
			vector.z = newValue;
			return vector;
		}

		public static Vector4 MMSetW(this Vector4 vector, float newValue)
		{
			vector.w = newValue;
			return vector;
		}

		public static Vector4 MMInvert(this Vector4 newValue)
		{
			return new Vector4(1f / newValue.x, 1f / newValue.y, 1f / newValue.z, 1f / newValue.w);
		}

		public static Vector4 MMProject(this Vector4 vector, Vector4 projectedVector)
		{
			return Vector4.Dot(vector, projectedVector) * projectedVector;
		}

		public static Vector4 MMReject(this Vector4 vector, Vector4 rejectedVector)
		{
			return vector - vector.MMProject(rejectedVector);
		}

		public static Vector4 MMRound(this Vector4 vector)
		{
			vector.x = Mathf.Round(vector.x);
			vector.y = Mathf.Round(vector.y);
			vector.z = Mathf.Round(vector.z);
			vector.w = Mathf.Round(vector.w);
			return vector;
		}
	}
}
