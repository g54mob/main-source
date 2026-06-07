using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class TransformExtensions
	{
		public static Transform SetLocal(this Transform transform, Vector3 localPosition, Quaternion localRotation)
		{
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
			return transform;
		}

		public static Transform SetLocal(this Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 scale)
		{
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
			transform.localScale = scale;
			return transform;
		}

		public static Transform SetLocal(this Transform transform, Vector3 localPosition, Transform parent)
		{
			transform.parent = parent;
			transform.localPosition = localPosition;
			return transform;
		}

		public static Transform SetLocal(this Transform transform, Vector3 localPosition, Quaternion localRotation, Transform parent)
		{
			transform.parent = parent;
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
			return transform;
		}

		public static Transform SetLocal(this Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 scale, Transform parent)
		{
			transform.parent = parent;
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
			transform.localScale = scale;
			return transform;
		}
	}
}
