using Unity.Entities;
using Unity.Mathematics;

public struct PlayerMovementForceCD : IComponentData, IQueryTypeParameter
{
	public float3 Value;
}
