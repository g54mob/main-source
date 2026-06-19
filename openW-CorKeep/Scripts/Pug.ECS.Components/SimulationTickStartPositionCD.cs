using Unity.Entities;
using Unity.Mathematics;

public struct SimulationTickStartPositionCD : IComponentData, IQueryTypeParameter
{
	public float2 Value;
}
