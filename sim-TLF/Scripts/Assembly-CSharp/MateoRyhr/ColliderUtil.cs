using UnityEngine;

namespace MateoRyhr
{
	public static class ColliderUtil
	{
		public static Collider GetColliderRoot(Collider collider)
		{
			Collider[] componentsInParent = collider.GetComponentsInParent<Collider>();
			if (componentsInParent.Length != 0)
			{
				return componentsInParent[^1];
			}
			return collider;
		}

		public static bool CheckDirectContact(Collider from, Collider to, bool parentColliderIsCollider)
		{
			Vector3 normalized = (to.bounds.center - from.bounds.center).normalized;
			Physics.Raycast(from.bounds.center, normalized, out var hitInfo, float.PositiveInfinity);
			if (!hitInfo.collider)
			{
				return false;
			}
			if (hitInfo.collider == to)
			{
				return true;
			}
			if (parentColliderIsCollider && GetColliderRoot(to) == GetColliderRoot(hitInfo.collider))
			{
				return true;
			}
			return false;
		}

		public static bool ColliderContainPoints(Collider collider, Vector3[] points)
		{
			foreach (Vector3 point in points)
			{
				if (!collider.bounds.Contains(point))
				{
					return false;
				}
			}
			return true;
		}
	}
}
