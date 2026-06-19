using Unity.Entities;

public struct JewelryCanBePolishedCD : IComponentData, IQueryTypeParameter
{
	public ObjectID polishedVersion;
}
