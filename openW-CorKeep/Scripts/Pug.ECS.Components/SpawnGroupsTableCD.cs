using Unity.Entities;

public struct SpawnGroupsTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<SpawnGroupsTable> Value;
}
