using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UISoftMaskInternal
{
	internal static class TransformExtensions
	{
		private const float k_DefaultEpsilon = 0.1f;

		private static readonly Vector3[] s_Corners = new Vector3[4];

		public static int CompareHierarchyIndex(this Transform self, Transform other, Transform stopAt)
		{
			if (self == other)
			{
				return 0;
			}
			List<Transform> toRelease = self.GetTransforms(stopAt, ListPool<Transform>.Rent());
			List<Transform> toRelease2 = other.GetTransforms(stopAt, ListPool<Transform>.Rent());
			int num = Mathf.Min(toRelease.Count, toRelease2.Count);
			int result = 0;
			for (int i = 0; i < num; i++)
			{
				self = toRelease[toRelease.Count - i - 1];
				other = toRelease2[toRelease2.Count - i - 1];
				if (!(self == other))
				{
					result = self.GetSiblingIndex() - other.GetSiblingIndex();
					break;
				}
			}
			ListPool<Transform>.Return(ref toRelease);
			ListPool<Transform>.Return(ref toRelease2);
			return result;
		}

		private static List<Transform> GetTransforms(this Transform self, Transform stopAt, List<Transform> results)
		{
			results.Clear();
			while (self != stopAt)
			{
				results.Add(self);
				self = self.parent;
			}
			return results;
		}

		public static bool HasChanged(this Transform self, ref Matrix4x4 prev, float epsilon = 0.1f)
		{
			return self.HasChanged(null, ref prev, epsilon);
		}

		public static bool HasChanged(this Transform self, Transform baseTransform, ref Matrix4x4 prev, float epsilon = 0.1f)
		{
			if (!self)
			{
				return false;
			}
			int key = (baseTransform ? baseTransform.GetHashCode() : 0);
			if (FrameCache.TryGet<bool>(self, "HasChanged", key, out var result))
			{
				return result;
			}
			Matrix4x4 matrix4x = (baseTransform ? (baseTransform.worldToLocalMatrix * self.localToWorldMatrix) : self.localToWorldMatrix) * Matrix4x4.Scale(Vector3.one * 10000f);
			result = !Approximately(matrix4x, prev, epsilon);
			FrameCache.Set(self, "HasChanged", key, result);
			if (result)
			{
				prev = matrix4x;
			}
			return result;
		}

		private static bool Approximately(Matrix4x4 self, Matrix4x4 other, float epsilon = 0.1f)
		{
			for (int i = 0; i < 16; i++)
			{
				if (epsilon < Mathf.Abs(self[i] - other[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static Bounds GetRelativeBounds(this Transform self, Transform child)
		{
			if (!self || !child)
			{
				return new Bounds(Vector3.zero, Vector3.zero);
			}
			List<RectTransform> toRelease = ListPool<RectTransform>.Rent();
			child.GetComponentsInChildren(includeInactive: false, toRelease);
			if (toRelease.Count == 0)
			{
				ListPool<RectTransform>.Return(ref toRelease);
				return new Bounds(Vector3.zero, Vector3.zero);
			}
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Matrix4x4 worldToLocalMatrix = self.worldToLocalMatrix;
			for (int i = 0; i < toRelease.Count; i++)
			{
				toRelease[i].GetWorldCorners(s_Corners);
				for (int j = 0; j < 4; j++)
				{
					Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(s_Corners[j]);
					vector = Vector3.Min(lhs, vector);
					vector2 = Vector3.Max(lhs, vector2);
				}
			}
			ListPool<RectTransform>.Return(ref toRelease);
			Bounds result = new Bounds(vector, Vector3.zero);
			result.Encapsulate(vector2);
			return result;
		}
	}
}
