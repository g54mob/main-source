using Unity.Entities;
using Unity.Mathematics;

public struct AddToObjectLookupTriggerCD : IComponentData, IQueryTypeParameter
{
	public float3 position;

	public ObjectID objectID;

	public int variation;

	public bool hasDirection;

	public DirectionCD directionCD;
}
