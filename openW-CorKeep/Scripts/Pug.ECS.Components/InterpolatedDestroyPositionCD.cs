using Unity.Entities;
using Unity.Mathematics;

public struct InterpolatedDestroyPositionCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float3 position;
}
