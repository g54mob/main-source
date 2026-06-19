using Unity.Entities;

public struct RandomWalkStatePatternGroupData
{
	public WalkStateSelectionType patternSelectionType;

	public float totalPatternWeights;

	public BlobArray<float> patternRandomWeights;

	public BlobArray<RandomWalkStatePatterData> patterns;
}
