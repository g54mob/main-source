public class TradingPostInfo : DungeonInfo
{
	private string groupKey = string.Empty;

	public Inventory Inventory { get; private set; }

	protected TradingPostInfo()
	{
	}

	public TradingPostInfo(StarSystemInfo parentStarSysInfo, int id)
		: base(parentStarSysInfo, id)
	{
		Inventory = new Inventory(100, base.GroupKey, true);
		Inventory.CanHaveScrap = false;
	}
}
