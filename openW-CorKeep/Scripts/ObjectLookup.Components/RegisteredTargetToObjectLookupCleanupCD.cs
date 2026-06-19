using Unity.Entities;
using Unity.Mathematics;

public struct RegisteredTargetToObjectLookupCleanupCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
{
	public int2 tilePosition;

	public Entity targetEntity;

	public int2 entityOffset;

	public int2 entitySize;
}
