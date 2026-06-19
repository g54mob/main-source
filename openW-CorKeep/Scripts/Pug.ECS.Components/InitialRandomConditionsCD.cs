using Unity.Entities;

public struct InitialRandomConditionsCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<BlobArray<InitialRandomConditionData>> initialConditions;
}
