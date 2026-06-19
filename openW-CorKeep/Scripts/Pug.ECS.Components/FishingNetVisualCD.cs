using Unity.Entities;

public struct FishingNetVisualCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float nextSplashTime;

	public bool isInLava;

	public BlobAssetReference<FishingNetTimerData> fishingNetTimerData;
}
