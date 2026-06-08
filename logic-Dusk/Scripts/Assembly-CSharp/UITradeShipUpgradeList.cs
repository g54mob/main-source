using System.Collections.Generic;

public class UITradeShipUpgradeList : UIShipUpgradeSellableList
{
	public override void Refresh()
	{
		if (GalaxyMapManager.Instance.SelectedDungeon is TradingPostInfo)
		{
			isNonPlayerList = true;
			sourceInventoryDict = new Dictionary<InventoryTypeEnum, Inventory>();
			sourceInventoryDict.Add(InventoryTypeEnum.Loose, ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory);
			base.Refresh();
		}
	}
}
