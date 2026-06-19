using Unity.Entities;

public struct CanBeScannedCD : IComponentData, IQueryTypeParameter
{
	public ObjectDataCD objectData;
}
