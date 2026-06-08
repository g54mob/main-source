public class Pickup : Character
{
	public Data.Resource resourceType;

	public int resourceAmount = 1;

	public string grantItemId;

	public int grantAmount = 1;

	public int grantLevel = 1;

	public ItemData.Element grantItemElement;

	public string sfxOnPickup;

	protected override void Start()
	{
		base.Start();
		if (sortTiebreaker < 0)
		{
			sortTiebreaker = 7;
		}
	}

	public virtual void ExecutePickUp(Character whoIsPickingUp)
	{
		SfxController.singleton.Play(sfxOnPickup);
		if (grantItemId != null && grantItemId != "")
		{
			Item item = Inventory.Singleton.MakeReward(grantItemId, grantLevel, grantItemElement, 0);
			GameStates.Singleton.AddItemFromPickup(item, grantAmount);
		}
		else
		{
			InventoryResources.singleton.AddResourceOfType(resourceType, resourceAmount);
		}
		if (resourceAmount > 0 && (grantItemId == null || grantItemId == ""))
		{
			string resourceCostFormatted = MoneyUI.GetResourceCostFormatted(resourceType, resourceAmount);
			whoIsPickingUp.ShowFloatingText(resourceCostFormatted);
		}
		Die(DeathReason.DecorationCleanup);
	}
}
