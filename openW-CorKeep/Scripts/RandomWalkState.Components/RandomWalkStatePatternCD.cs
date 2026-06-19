using Unity.Entities;

public struct RandomWalkStatePatternCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<RandomWalkStatePatternBlobData> Value;
}
