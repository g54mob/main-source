using Unity.Entities;

public struct FlowerCD : IComponentData, IQueryTypeParameter
{
	public ObjectID plantID;

	public int plantVariation;
}
