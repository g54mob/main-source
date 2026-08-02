using DG.Tweening;
using UnityEngine;

public class AxeController : FPSWeaponBase
{
	public TsPlayerHitManager playerHitManager;

	public override void Hit(float delay)
	{
		EastUpPlayerItemManager component = playerHitManager.GetComponent<EastUpPlayerItemManager>();
		if (component != null && component.lastSelectedSlot != null)
		{
			InventoryItem inventoryItem = component.lastSelectedSlot.InventoryItem;
			if (inventoryItem != null && !inventoryItem.CanUse())
			{
				return;
			}
		}
		base.Hit(delay);
		DOVirtual.DelayedCall(delay * 2f, delegate
		{
			if (playerHitManager.CheckAxeHit(hitDamage))
			{
				DecreaseDurability();
			}
		});
	}

	private void DecreaseDurability()
	{
		EastUpPlayerItemManager component = playerHitManager.GetComponent<EastUpPlayerItemManager>();
		if (!(component == null) && !(component.lastSelectedSlot == null))
		{
			InventoryItem inventoryItem = component.lastSelectedSlot.InventoryItem;
			if (!(inventoryItem == null))
			{
				inventoryItem.DecreaseDurability();
			}
		}
	}

	public override void Recoil()
	{
		Debug.Log("Recoil");
	}

	public override void Equip()
	{
		Debug.Log("Equip");
	}

	public override void UnEquip()
	{
		Debug.Log("Unequip");
	}
}
