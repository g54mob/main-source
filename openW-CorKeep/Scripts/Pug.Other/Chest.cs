using UnityEngine;

public class Chest : WorldLabel
{
	public bool showSortAndQuickStackButtons;

	public InventoryHandler inventoryHandler { get; private set; }

	public override void OnOccupied()
	{
		base.OnOccupied();
		inventoryHandler = new InventoryHandler(this, base.world);
	}

	public override void OnFree()
	{
		OnPlayerLeftChest();
		base.OnFree();
	}

	public virtual void Use()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			bool flag = worldLabel != null && base.world.EntityManager.HasBuffer<DescriptionBuffer>(base.entity);
			player.SetActiveWorldLabel(flag ? this : null);
			Manager.main.player.SetActiveInventoryHandler(inventoryHandler);
			Manager.ui.OnChestInventoryOpen();
		}
	}

	public void Close()
	{
	}

	public void OnPlayerLeftChest()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && hasInteractable && player.activeInventoryHandler == inventoryHandler)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveWorldLabel(null);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		UpdateWorldText("");
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, center - Vector3.up * 0.5f, 8);
		OnPlayerLeftChest();
	}
}
