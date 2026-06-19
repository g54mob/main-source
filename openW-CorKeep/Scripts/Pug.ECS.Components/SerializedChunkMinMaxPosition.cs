using Unity.Entities;
using Unity.Mathematics;

public struct SerializedChunkMinMaxPosition : IComponentData, IQueryTypeParameter
{
	public int2 Min;

	public int2 Max;
}
