using UnityEngine;

namespace PajamaLlama.Extensions
{
	public static class TransformExtensions
	{
		public static Transform GetOrInstantiateChildWithName(this Transform transform, string name)
		{
			int childCount = transform.childCount;
			Transform child;
			for (int i = 0; i < childCount; i++)
			{
				child = transform.GetChild(i);
				if (child.name.Equals(name))
				{
					return child;
				}
			}
			child = new GameObject().transform;
			child.name = name;
			child.SetParent(transform);
			child.localPosition = Vector3.zero;
			child.localRotation = Quaternion.identity;
			child.localScale = Vector3.one;
			return child;
		}

		public static string HierarchyPathToString(this Transform transform)
		{
			string text = transform.name;
			while ((bool)transform.parent)
			{
				transform = transform.parent;
				text = transform.name + "/" + text;
			}
			return text;
		}

		public static void Reset(this Transform transform)
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}

		public static void SetParentAndReset(this Transform transform, Transform parent)
		{
			transform.SetParent(parent);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}

		public static void CopyLocalPositionRotationAndScale(this Transform transform, Transform transformToCopy)
		{
			transform.localPosition = transformToCopy.localPosition;
			transform.localRotation = transformToCopy.localRotation;
			transform.localScale = transformToCopy.localScale;
		}

		public static Rect InverseTransformRect(this RectTransform rectTransform, RectTransform other)
		{
			Vector2 lhs = rectTransform.InverseTransformPoint(other.TransformPoint(other.rect.min));
			Vector2 rhs = rectTransform.InverseTransformPoint(other.TransformPoint(other.rect.max));
			Vector2 vector = Vector2.Min(lhs, rhs);
			Vector2 vector2 = Vector2.Max(lhs, rhs);
			return new Rect(vector, vector2 - vector);
		}
	}
}
