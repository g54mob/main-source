using System.Numerics;
using Coherence.Common;
using UnityEngine;

namespace Coherence
{
	public static class CoherenceToUnityConverters
	{
		public static UnityEngine.Quaternion ToUnityQuaternion(this System.Numerics.Quaternion q)
		{
			return default(UnityEngine.Quaternion);
		}

		public static System.Numerics.Quaternion ToCoreQuaternion(this UnityEngine.Quaternion q)
		{
			return default(System.Numerics.Quaternion);
		}

		public static UnityEngine.Vector2 ToUnityVector2(this System.Numerics.Vector2 v)
		{
			return default(UnityEngine.Vector2);
		}

		public static System.Numerics.Vector2 ToCoreVector2(this UnityEngine.Vector2 v)
		{
			return default(System.Numerics.Vector2);
		}

		public static UnityEngine.Vector3 ToUnityVector3(this System.Numerics.Vector3 v)
		{
			return default(UnityEngine.Vector3);
		}

		public static System.Numerics.Vector3 ToCoreVector3(this UnityEngine.Vector3 v)
		{
			return default(System.Numerics.Vector3);
		}

		public static UnityEngine.Vector3 ToUnityVector3(this Vector3d v)
		{
			return default(UnityEngine.Vector3);
		}

		public static Vector3d ToVector3d(this UnityEngine.Vector3 v)
		{
			return default(Vector3d);
		}

		public static UnityEngine.Vector4 ToUnityVector4(this System.Numerics.Vector4 v)
		{
			return default(UnityEngine.Vector4);
		}

		public static System.Numerics.Vector4 ToCoreVector4(this UnityEngine.Vector4 v)
		{
			return default(System.Numerics.Vector4);
		}

		public static Color ToUnityColor(this System.Numerics.Vector4 c)
		{
			return default(Color);
		}

		public static System.Numerics.Vector4 ToCoreColor(this Color c)
		{
			return default(System.Numerics.Vector4);
		}
	}
}
