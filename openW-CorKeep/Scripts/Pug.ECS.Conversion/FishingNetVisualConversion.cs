using Pug.Conversion;

public class FishingNetVisualConversion : SingleAuthoringComponentConverter<FishingNetVisualAuthoring>
{
	protected override void Convert(FishingNetVisualAuthoring authoring)
	{
		AddComponentData(new FishingNetVisualCD
		{
			fishingNetTimerData = CreateAndAddSimpleBlobAsset(new FishingNetTimerData
			{
				minMaxSplashTimerSingle = authoring.minMaxSplashTimerSingleFish,
				minMaxSplashTimerFull = authoring.minMaxSplashTimerFullNet
			})
		}, componentIsEnabled: false);
		EnsureHasBuffer<FishingNetSlotVisualBuffer>();
		for (int i = 0; i < authoring.visualSlots.Count; i++)
		{
			AddToBuffer(new FishingNetSlotVisualBuffer
			{
				visualOffset = authoring.visualSlots[i].visualOffset
			});
		}
		EnsureHasComponent<FishingNetInitCheckForLavaCD>(componentIsEnabled: true);
	}
}
