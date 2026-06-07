namespace Brewery.Stations.Components.Interfaces
{
	public interface IStationUpgradeProvider
	{
		bool HasTier1 { get; }

		bool HasTier2 { get; }

		StationUpgradeData GetUpgradeData();

		void SaveUpgradeData(StationUpgradeData data);
	}
}
