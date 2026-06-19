using Unity.Entities;

public struct FishingStruggleInfoData
{
	public ObjectID fishID;

	public BlobArray<FishingTable.FishStruggleData> struggleData;

	public float difficultyRatio;
}
