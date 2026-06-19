using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct EffectiveVelocityCD : IComponentData, IQueryTypeParameter
{
	[GhostField(Composite = true)]
	public float2 Value;

	public bool IsMoving => math.lengthsq(Value) > 0f;

	public bool IsBarelyMoving => math.lengthsq(Value) > 0.05f;
}
