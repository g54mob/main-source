public class VendingMachine : EntityMonoBehaviour
{
	public InventoryHandler inventoryHandler { get; private set; }

	public override void OnOccupied()
	{
		base.OnOccupied();
		inventoryHandler = new InventoryHandler(this, base.world, isBuyInventory: true);
	}

	public override void OnFree()
	{
		OnPlayerLeft();
		base.OnFree();
	}

	protected override void OnDeath()
	{
		OnPlayerLeft();
		base.OnDeath();
	}

	public virtual void Interact()
	{
		PlayerController player = Manager.main.player;
		player.SetActiveInventoryHandler(player.sellSlotsHandler.sellSlotsInventoryHandler);
		player.SetActiveBuyInventoryHandler(inventoryHandler);
		Manager.ui.OnBuyWindowOpen();
	}

	public void OnPlayerLeft()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && player.activeInventoryHandler == player.sellSlotsHandler.sellSlotsInventoryHandler)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveBuyInventoryHandler(null);
		}
	}
}
