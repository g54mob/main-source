public class TreasurePickup : Pickup
{
	public Data.ItemInTreasure[] itemsInTreasure;

	public override void ExecutePickUp(Character whoIsPickingUp)
	{
		if (Inventory.Singleton.IsAtTreasurelimit() && TreasureItem.FindBestRarityInItems(itemsInTreasure) == ItemData.Rarity.Type.Common && !IsQuestItem())
		{
			SfxController.singleton.Play("error");
			FloatingText floatingText = ShowFloatingText(Te.xt("TOO MANY TREASURES"));
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.red;
			}
			deathDurationTics = 60;
		}
		else
		{
			SfxController.singleton.Play(sfxOnPickup);
			TreasureItem treasureItem = ItemFactory.singleton.MakeItem(grantItemId) as TreasureItem;
			treasureItem.itemsInTreasure = itemsInTreasure;
			GameStates.Singleton.AddItemFromPickup(treasureItem, 1, offerUpgradeOption: true);
		}
		Die(DeathReason.DecorationCleanup);
	}

	private bool IsQuestItem()
	{
		return tags.Contains("quest");
	}

	private bool IsBlade()
	{
		if (itemsInTreasure.Length != 0)
		{
			return itemsInTreasure[0].id == "blade_of_god";
		}
		return false;
	}
}
