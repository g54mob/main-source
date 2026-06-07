namespace App.Data
{
	public class UpgradeStats : BaseShopItem
	{
		public float BlocksSpeedBonus;

		public float ChainSpeedBonus;

		public float ServersCostBonus;

		public int SocketDepthBonus;

		public int ChainThroughputBonus;

		public float QuestUnlock;

		public int MoneyCost;

		public int MemoryBonus;

		public string Tag;

		public int ShowInRoom;

		public void Add(UpgradeStats u)
		{
			SocketDepthBonus += u.SocketDepthBonus;
			BlocksSpeedBonus += u.BlocksSpeedBonus;
			ChainSpeedBonus += u.ChainSpeedBonus;
			ServersCostBonus += u.ServersCostBonus;
			MemoryBonus += u.MemoryBonus;
			ChainThroughputBonus += u.ChainThroughputBonus;
		}

		public UpgradeStats()
		{
			VisibleToPlayer = true;
		}
	}
}
