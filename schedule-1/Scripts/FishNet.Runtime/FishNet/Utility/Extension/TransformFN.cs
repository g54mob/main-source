using FishNet.Documenting;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Utility.Extension
{
	[APIExclude]
	public static class TransformFN
	{
		public static TransformProperties GetWorldProperties(this Transform t)
		{
			return default(TransformProperties);
		}

		public static void SetWorldProperties(this TransformPropertiesCls tp, Transform t)
		{
		}

		public static void SetTransformOffsets(this Transform t, Transform target, ref Vector3 pos, ref Quaternion rot)
		{
		}

		public static TransformProperties GetTransformOffsets(this Transform t, Transform target)
		{
			return default(TransformProperties);
		}

		public static void SetLocalPositionAndRotation(this Transform t, Vector3 pos, Quaternion rot)
		{
		}

		public static void SetLocalPositionRotationAndScale(this Transform t, Vector3 pos, Quaternion rot, Vector3 scale)
		{
		}
	}
}
