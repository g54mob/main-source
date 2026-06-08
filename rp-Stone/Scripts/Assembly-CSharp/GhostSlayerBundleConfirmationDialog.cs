public class GhostSlayerBundleConfirmationDialog : LimitedTimeBundleConfirmationDialog
{
	public override void Setup(ShopData.Entry entryData, Item inventoryItem = null)
	{
		if (LimitedTimeBundlesController.singleton.purchaseCount == 1)
		{
			entryData.percentOff = 20;
		}
		else if (LimitedTimeBundlesController.singleton.purchaseCount >= 2)
		{
			entryData.percentOff = 30;
		}
		else
		{
			entryData.percentOff = 0;
		}
		base.Setup(entryData, inventoryItem);
	}
}
