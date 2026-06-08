public class UITradeFuelList : UIFuelList
{
	public override void Refresh()
	{
		sourceInventory = ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory;
		base.Refresh();
	}
}
