using UnityEngine;
using UniversalInventorySystem;

public class DefaultDropBehaviour : DropBehaviour
{
	public GameObject droppedItemObj;

	public override void OnDropItem(object sender, InventoryHandler.DropItemEventArgs e)
	{
		if (droppedItemObj == null)
		{
			droppedItemObj = new GameObject();
		}
		int durability = e.inv[e.slot].durability;
		e.inv.RemoveItemInSlot(e.slot, e.amount);
		DroppedItem component = Object.Instantiate(droppedItemObj, new Vector3(e.positionDropped.x, e.positionDropped.y, 0f), Quaternion.identity).GetComponent<DroppedItem>();
		if (e.item.hasDurability)
		{
			component.SetSprite(InventoryUI.GetNearestSprite(e.item, durability));
		}
		else
		{
			component.SetSprite(e.item.sprite);
		}
		component.SetAmount(e.amount);
	}
}
