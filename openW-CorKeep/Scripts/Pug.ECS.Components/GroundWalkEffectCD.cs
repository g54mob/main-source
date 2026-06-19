using Unity.Entities;
using Unity.Mathematics;

public struct GroundWalkEffectCD : IComponentData, IQueryTypeParameter
{
	public float DistanceToTriggerSq;

	public float2 LastTriggerPosition;
}
