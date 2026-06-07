using UnityEngine;

public static class SuperCollider
{
	public static bool ClosestPointOnSurface(Collider collider, Vector3 to, float radius, out Vector3 closestPointOnSurface)
	{
		closestPointOnSurface = default(Vector3);
		return false;
	}

	public static Vector3 ClosestPointOnSurface(SphereCollider collider, Vector3 to)
	{
		return default(Vector3);
	}

	public static Vector3 ClosestPointOnSurface(BoxCollider collider, Vector3 to)
	{
		return default(Vector3);
	}

	public static Vector3 ClosestPointOnSurface(CapsuleCollider collider, Vector3 to)
	{
		return default(Vector3);
	}

	public static Vector3 ClosestPointOnSurface(TerrainCollider collider, Vector3 to, float radius, bool debug = false)
	{
		return default(Vector3);
	}
}
