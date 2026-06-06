using Brewery.Stations.Components.Interfaces;
using Brewery.Systems;

namespace Brewery.Stations.Components.Adapters
{
	public sealed class StationUpgradeProviderAdapter : IStationUpgradeProvider
	{
		private readonly StationUpgradeManager upgradeManager;

		private readonly BreweryMetadataManager metadataManager;

		public bool HasTier1 => false;

		public bool HasTier2 => false;

		public StationUpgradeProviderAdapter(StationUpgradeManager upgradeManager)
		{
		}

		public StationUpgradeData GetUpgradeData()
		{
			return default(StationUpgradeData);
		}

		public void SaveUpgradeData(StationUpgradeData data)
		{
		}
	}
}
