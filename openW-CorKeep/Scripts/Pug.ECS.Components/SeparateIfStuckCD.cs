using Unity.Entities;
using Unity.Mathematics;

public struct SeparateIfStuckCD : IComponentData, IQueryTypeParameter
{
	public float timer;

	public int2 lastPos;
}
