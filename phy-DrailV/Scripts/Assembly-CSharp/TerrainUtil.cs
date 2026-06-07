using UnityEngine;

public class TerrainUtil
{
	public const float SPHERECAST_RADIUS = 0.1f;

	private static RaycastHit[] hits = new RaycastHit[10];

	public static Terrain RaycastTerrain(Vector3 origin, Vector3 direction, out RaycastHit? hit, int layerMask, float sphereCastRadius = 0.1f, float maxLength = 10000f)
	{
		int num = Physics.SphereCastNonAlloc(origin, sphereCastRadius, direction, hits, maxLength, layerMask);
		if (num != 0)
		{
			for (int i = 0; i < num; i++)
			{
				Terrain component = hits[i].collider.GetComponent<Terrain>();
				if (component != null)
				{
					hit = hits[i];
					return component;
				}
			}
		}
		hit = null;
		return null;
	}
}
