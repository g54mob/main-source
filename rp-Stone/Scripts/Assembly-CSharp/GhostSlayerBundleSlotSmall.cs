public class GhostSlayerBundleSlotSmall : LimitedTimeBundleSlot
{
	protected override void Start()
	{
		base.Start();
		string value = Te.xt("tid_shop_staff") + " +11";
		title.SetValue(value);
		if (limitedTimeClock.PositionY == limitedTimeHeader1.PositionY)
		{
			Height--;
		}
	}
}
