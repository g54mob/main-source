public class CraftableDroneUpgrade : ICraftableItem
{
	private string _guiScrap = string.Empty;

	public string DisplayName { get; private set; }

	public string guiScrap
	{
		get
		{
			if (_guiScrap == string.Empty)
			{
				_guiScrap = string.Format(" ({0} Scrap)", ScrapCost);
			}
			return _guiScrap;
		}
	}

	public int ScrapCost { get; private set; }

	public DroneUpgradeType UpgradeType { get; private set; }

	public CraftableDroneUpgrade(string name, int cost, DroneUpgradeType upgradeType)
	{
		DisplayName = name;
		ScrapCost = cost;
		UpgradeType = upgradeType;
	}
}
