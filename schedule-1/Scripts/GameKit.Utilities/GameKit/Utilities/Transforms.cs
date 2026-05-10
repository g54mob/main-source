using System.Collections.Generic;
using UnityEngine;

namespace GameKit.Utilities
{
	public static class Transforms
	{
		public static Vector3 GetOnScreenPosition(this RectTransform rectTransform, Vector3 desiredPosition, Vector2 padding)
		{
			return default(Vector3);
		}

		public static void SetParentAndKeepTransform(this Transform src, Transform parent)
		{
		}

		public static void DestroyChildren(this Transform t, bool destroyImmediately = false)
		{
		}

		public static void DestroyChildren<T>(this Transform t, bool destroyImmediately = false) where T : MonoBehaviour
		{
		}

		public static void GetComponentsInChildren<T>(this Transform parent, List<T> results, bool includeParent = true, bool includeInactive = false) where T : Component
		{
		}

		public static Vector3 GetPosition(this Transform t, bool localSpace)
		{
			return default(Vector3);
		}

		public static Quaternion GetRotation(this Transform t, bool localSpace)
		{
			return default(Quaternion);
		}

		public static Vector3 GetScale(this Transform t)
		{
			return default(Vector3);
		}

		public static void SetPosition(this Transform t, bool localSpace, Vector3 pos)
		{
		}

		public static void SetRotation(this Transform t, bool localSpace, Quaternion rot)
		{
		}

		public static void SetScale(this Transform t, Vector3 scale)
		{
		}
	}
}
