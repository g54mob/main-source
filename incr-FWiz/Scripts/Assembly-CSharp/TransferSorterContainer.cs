using UnityEngine;

public class TransferSorterContainer : TransferContainer
{
	public ItemStack FilterItemStack;

	[SerializeField]
	private TransferSorterItemTypeUI _sorterItemUI;

	[SerializeField]
	private DropCollector _sorterTypeDropCollector;

	[SerializeField]
	private PickupSupplier _sorterTypePickupSupplier;

	public ItemType FilterItemType => null;

	public override void Initiate()
	{
	}

	public override void OnDestroy()
	{
	}

	public override bool CanCollect(ItemType itemType)
	{
		return false;
	}

	public bool CanCollectSorterTypeItem(ItemType itemType)
	{
		return false;
	}

	public ItemType PeekSorterTypeItem()
	{
		return null;
	}

	public bool IsItemPreferred(ItemType itemType)
	{
		return false;
	}

	public bool RemoveItemSorterTypeItem()
	{
		return false;
	}

	public void AddSorterTypeItem(ItemType itemType)
	{
	}
}
