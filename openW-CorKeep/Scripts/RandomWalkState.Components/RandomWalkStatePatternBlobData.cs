using Unity.Entities;

public struct RandomWalkStatePatternBlobData
{
	public WalkStateSelectionType groupSelectionType;

	public float totalGroupWeights;

	public BlobArray<float> groupRandomWeights;

	public BlobArray<RandomWalkStatePatternGroupData> groups;
}
