using UnityEngine;
using UnityEngine.UI;

public class InventoryViewSelectable : Selectable
{
	[Header("Inventory View Selectable")]
	[SerializeField]
	private InventoryPanelItemSlot _slot;

	public ItemProperties ItemProperties
	{
		get
		{
			if (!_slot)
			{
				return null;
			}
			return _slot.ItemProperties;
		}
	}
}
