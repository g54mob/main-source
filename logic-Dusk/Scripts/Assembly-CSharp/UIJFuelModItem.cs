public class UIJFuelModItem : UIModItemConfigurable
{
	private IInventory sourceInventory;

	public override void Refresh(IInventory sourceInventory)
	{
		this.sourceInventory = sourceInventory;
		base.Tag = 1;
		SetCost(15);
		if (sourceInventory.JumpFuel > 0)
		{
			SetActive();
			SetQtyOfStock(sourceInventory.JumpFuel);
		}
		else
		{
			SetInactive();
			SetQtyOfStock(0);
		}
	}

	public override void Remove()
	{
		sourceInventory.JumpFuel--;
		sourceInventory.Scrap += 15;
	}
}
