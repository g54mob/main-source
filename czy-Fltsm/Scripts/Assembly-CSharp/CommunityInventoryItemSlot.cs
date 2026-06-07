using UnityEngine;

public class CommunityInventoryItemSlot : MonoBehaviour
{
	[SerializeField]
	private InventoryPanelItemSlot _itemSlot;

	private ItemProperties _itemProperties;

	private SubInventoryType _subInventoryType;

	private bool _includeReserved;

	private void OnEnable()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateInventory);
		UpdateInventory();
	}

	private void OnDisable()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateInventory);
	}

	public void Initialize(ItemProperties itemProperties, SubInventoryType subInventoryType = SubInventoryType.Storage, bool includeReserved = false)
	{
		_itemProperties = itemProperties;
		_subInventoryType = subInventoryType;
		_includeReserved = includeReserved;
		_itemSlot.Initialize(_itemProperties, GetCount());
		UpdateInventory();
	}

	private void UpdateInventory()
	{
		if (!(_itemProperties == null))
		{
			_itemSlot.SetCount(GetCount());
		}
	}

	private int GetCount()
	{
		return Community.PlayerCommunity.Inventory.ReturnCount(_itemProperties, _subInventoryType, _includeReserved);
	}
}
