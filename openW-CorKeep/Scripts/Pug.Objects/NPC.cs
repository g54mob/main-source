public class NPC : EntityMonoBehaviour
{
	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public InventoryHandler inventoryHandler { get; private set; }

	protected override float GetAnimSpeed()
	{
		return 0.8f;
	}

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

	public virtual void Interact()
	{
		PlayerController player = Manager.main.player;
		player.SetActiveInventoryHandler(player.sellSlotsHandler.sellSlotsInventoryHandler);
		player.SetActiveBuyInventoryHandler(inventoryHandler);
		Manager.ui.OnVendorOpen();
		PlayInteractSound();
	}

	public void OnPlayerLeft()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && player.activeInventoryHandler == Manager.main.player.sellSlotsHandler.sellSlotsInventoryHandler)
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveBuyInventoryHandler(null);
		}
	}

	public virtual void PlayInteractSound()
	{
	}
}
