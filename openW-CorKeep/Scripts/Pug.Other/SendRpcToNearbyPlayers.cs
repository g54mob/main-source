using Unity.Entities;
using Unity.Mathematics;

public struct SendRpcToNearbyPlayers : IComponentData, IQueryTypeParameter
{
	public float3 position;

	public float distance;

	public Entity connection;

	public bool includeConnection;

	public bool alsoCreateForServer;
}
