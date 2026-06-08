public class TitanicBundleSlotSmall : TitanicBundleSlot
{
	protected override void Start()
	{
		base.Start();
		Utils.PreloadAsyncPrefab("titanic_bundle_details_icon");
		if (limitedTimeClock.PositionY == limitedTimeHeader1.PositionY)
		{
			Height--;
		}
	}
}
