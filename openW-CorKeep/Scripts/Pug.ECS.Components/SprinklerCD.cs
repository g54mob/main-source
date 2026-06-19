using Unity.Entities;

public struct SprinklerCD : IComponentData, IQueryTypeParameter
{
	public float timer;
}
