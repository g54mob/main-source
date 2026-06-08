namespace KitchenData
{
	public interface IUpgrade
	{
		int ID { get; }

		int MaximumUpgradeCount { get; }

		string UpgradeName { get; }

		string UpgradeDescription { get; }
	}
}
