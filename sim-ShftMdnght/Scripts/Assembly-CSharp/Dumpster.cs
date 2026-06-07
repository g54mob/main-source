public class Dumpster : ConstrictedInteractable
{
	public new PlayerManager curPlayerMan;

	public override void Interact(PlayerManager playerMan)
	{
		if (!interactable || !constrictionAllows)
		{
			return;
		}
		curPlayerMan = playerMan;
		base.Interact(playerMan);
		base.StopLookAt();
		if (!(playerMan == ClientPlayer.Instance.playerMan))
		{
			return;
		}
		if (playerMan.inventoryMan.holdingIndex == 6)
		{
			StoreManager.Instance.ChangeRevenue("Thrown Trash", (float)playerMan.inventoryMan.trash[playerMan.inventoryMan.curInventorySlot] * 0.2f);
			playerMan.inventoryMan.DropObject();
			StoreManager.Instance.SetAlert("Trash thrown out!", "green");
		}
		else if (playerMan.inventoryMan.holdingIndex == 13)
		{
			if (base.isServer)
			{
				playerMan.inventoryMan.GotARatRpc();
			}
			else
			{
				playerMan.inventoryMan.GotARatCmd();
			}
			StoreManager.Instance.ChangeRevenue("Thrown Rat", 5f);
			playerMan.inventoryMan.DestroyObject();
			StoreManager.Instance.SetAlert("Trash thrown out!", "green");
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
