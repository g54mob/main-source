using Unity.Entities;
using Unity.Mathematics;

public struct PacketComponent : IComponentData, IQueryTypeParameter
{
	public float3 movedirection;

	public float moveSpeed;

	public float3 position;

	public int currentWaypointIndex;

	public int cableId;

	public int customerId;

	public float4 color;
}
