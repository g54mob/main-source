using System;

[Serializable]
public class UpgradeableCollectableItems
{
	public CollectableItemData mainItem;

	public CollectableItemData upgradedItem;

	public int upgradedCount = 1;

	public float upgradeTime = 10f;
}
