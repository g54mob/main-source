using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public static class UnityExtensions
	{
		public static Quaternion ReverseX(this Quaternion quaternion)
		{
			quaternion.ToAngleAxis(out var angle, out var axis);
			return Quaternion.AngleAxis(0f - angle, new Vector3(0f - axis.x, axis.y, axis.z));
		}

		public static IEnumerable<Transform> GetChildren(this Transform parent)
		{
			foreach (Transform item in parent)
			{
				yield return item;
			}
		}

		public static IEnumerable<Transform> Traverse(this Transform parent)
		{
			yield return parent;
			foreach (Transform item in parent)
			{
				foreach (Transform item2 in item.Traverse())
				{
					yield return item2;
				}
			}
		}

		public static SkeletonBone ToSkeletonBone(this Transform t)
		{
			return new SkeletonBone
			{
				name = t.name,
				position = t.localPosition,
				rotation = t.localRotation,
				scale = t.localScale
			};
		}
	}
}
