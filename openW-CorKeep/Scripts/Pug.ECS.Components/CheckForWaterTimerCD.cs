using Unity.Entities;
using Unity.Mathematics;

public struct CheckForWaterTimerCD : IComponentData, IQueryTypeParameter
{
	public float Value;

	public int2 Position;

	public Entity growTimerEntity;
}
