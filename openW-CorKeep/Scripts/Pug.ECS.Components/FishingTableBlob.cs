using Unity.Entities;

public struct FishingTableBlob
{
	public BlobArray<FishingInfoData> fishingInfoByBiome;

	public BlobArray<FishingInfoData> fishingInfoByWaterTileset;

	public BlobArray<FishingStruggleInfoData> fishingStruggleInfo;

	public FishingStruggleInfoData defaultFishingStruggleInfo;
}
