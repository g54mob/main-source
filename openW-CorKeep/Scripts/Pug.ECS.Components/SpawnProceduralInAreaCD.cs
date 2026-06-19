using Unity.Entities;

public struct SpawnProceduralInAreaCD : IComponentData, IQueryTypeParameter
{
	public int PendingSubAreas;
}
