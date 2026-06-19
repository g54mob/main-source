using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MateoRyhr
{
	public static class Filter
	{
		public static Collider[] GetUniqueChildrenOfRoot(Collider[] colliders)
		{
			List<Transform> list = new List<Transform>();
			List<Collider> list2 = colliders.ToList();
			foreach (Collider collider in colliders)
			{
				Transform transform = ColliderUtil.GetColliderRoot(collider).transform;
				if (!list.Contains(transform))
				{
					list.Add(transform);
				}
				else
				{
					list2.Remove(collider);
				}
			}
			return list2.ToArray();
		}

		public static List<Collider> GetUniqueChildrenOfRoot(List<Collider> colliders)
		{
			List<Transform> list = new List<Transform>();
			List<Collider> list2 = colliders.ToList();
			foreach (Collider collider in colliders)
			{
				Transform transform = ColliderUtil.GetColliderRoot(collider).transform;
				if (!list.Contains(transform))
				{
					list.Add(transform);
				}
				else
				{
					list2.Remove(collider);
				}
			}
			return list2;
		}
	}
}
