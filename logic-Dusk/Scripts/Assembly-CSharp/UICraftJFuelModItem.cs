public class UICraftJFuelModItem : UIModItemConfigurable
{
	private IInventory sourceInventory;

	public override void Refresh(IInventory sourceInventory)
	{
		this.sourceInventory = sourceInventory;
		base.Tag = 2;
		SetCost(20);
		if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap >= 20)
		{
			SetActive();
		}
		else
		{
			SetInactive();
		}
	}

	public override void Remove()
	{
		sourceInventory.Scrap += 20;
	}
}
