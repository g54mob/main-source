using UnityEngine;

namespace TriLib
{
	public static class TransformExtensions
	{
		public static void LoadMatrix(this Transform transform, Matrix4x4 matrix, bool local = true)
		{
			if (local)
			{
				transform.localScale = matrix.ExtractScale();
				transform.localRotation = matrix.ExtractRotation();
				transform.localPosition = matrix.ExtractPosition();
			}
			else
			{
				transform.rotation = matrix.ExtractRotation();
				transform.position = matrix.ExtractPosition();
			}
		}

		public static Bounds EncapsulateBounds(this Transform transform)
		{
			Renderer[] componentsInChildren = transform.GetComponentsInChildren<Renderer>();
			Bounds result;
			if (componentsInChildren != null && componentsInChildren.Length != 0)
			{
				result = componentsInChildren[0].bounds;
				for (int i = 1; i < componentsInChildren.Length; i++)
				{
					Renderer renderer = componentsInChildren[i];
					result.Encapsulate(renderer.bounds);
				}
			}
			else
			{
				result = default(Bounds);
			}
			return result;
		}

		public static Transform FindDeepChild(this Transform transform, string name, bool endsWith = false)
		{
			if (endsWith ? (transform.name == name) : transform.name.EndsWith(name))
			{
				return transform;
			}
			foreach (Transform item in transform)
			{
				Transform transform2 = item.FindDeepChild(name);
				if (transform2 != null)
				{
					return transform2;
				}
			}
			return null;
		}

		public static void DestroyChildren(this Transform transform, bool destroyImmediate = false)
		{
			for (int num = transform.childCount - 1; num >= 0; num--)
			{
				Transform child = transform.GetChild(num);
				if (destroyImmediate)
				{
					Object.DestroyImmediate(child.gameObject);
				}
				else
				{
					Object.Destroy(child.gameObject);
				}
			}
		}
	}
}
