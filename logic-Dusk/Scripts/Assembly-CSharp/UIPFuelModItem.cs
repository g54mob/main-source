public class UIPFuelModItem : UIModItemConfigurable
{
	private IInventory sourceInventory;

	public override void Refresh(IInventory sourceInventory)
	{
		this.sourceInventory = sourceInventory;
		base.Tag = 0;
		SetCost(5);
		if (sourceInventory.PropulsionFuelReserve > 0)
		{
			SetActive();
			SetQtyOfStock(sourceInventory.PropulsionFuelReserve);
		}
		else
		{
			SetInactive();
			SetQtyOfStock(0);
		}
	}

	public override void Remove()
	{
		sourceInventory.PropulsionFuelReserve--;
		sourceInventory.Scrap += 5;
	}
}
