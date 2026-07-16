using UnityEngine;

internal class ZoneGenerationContext
{
	public Vector2Int mapSize;

	public int[] nodeConnections;

	public int nodeCount => mapSize.x * mapSize.y;

	public int NodesPerLane => mapSize.x;

	public ZoneGenerationContext(Vector2Int mapSize)
	{
		this.mapSize = mapSize;
		nodeConnections = new int[nodeCount];
	}
}
