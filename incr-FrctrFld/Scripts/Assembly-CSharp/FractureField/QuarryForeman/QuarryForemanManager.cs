using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;

namespace FractureField.QuarryForeman
{
	public class QuarryForemanManager : QuarryForemanManagerSaveData, ISaveData<QuarryForemanManager, QuarryForemanManagerSaveData>
	{
		private long _lastPlayerUpgrades;

		private long _lastDroneUpgrades;

		private long _lastBombUpgrades;

		private long _lastToolUpgrades;

		private long _lastWorldFractureUpgrades;

		private long _lastDroneHubUpgrades;

		private long _lastQuarryForemanUpgrades;

		private long _lastRealityShatterUpgrades;

		public UpgradeManager UpgradeManager { get; private set; }

		private bool ShouldRun => false;

		private Dictionary<RockLayerType, long> LastUpgradeForRockLayer { get; }

		public QuarryForemanManager Load()
		{
			return null;
		}

		public QuarryForemanManagerSaveData Save()
		{
			return null;
		}

		private void LoadDictionaries()
		{
		}

		public void Init()
		{
		}

		private void InitializeUpgradeManager()
		{
		}

		public void EndFrame_FixedTick()
		{
		}

		private void DoPlayerUpgrades()
		{
		}

		private void DoDroneUpgrades()
		{
		}

		private void DoBombUpgrades()
		{
		}

		private void DoToolUpgrades()
		{
		}

		private void DoRockLayerUpgrades()
		{
		}

		private void DoWorldFractureUpgrades()
		{
		}

		private void DoDroneHubUpgrades()
		{
		}

		private void DoQuarryForemanUpgrades()
		{
		}

		private void DoRealityShatterUpgrades()
		{
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
