using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Prestige.WorldFracture
{
	public class WorldFractureManager : WorldFractureManagerSaveData, ISaveData<WorldFractureManager, WorldFractureManagerSaveData>
	{
		private long _lastTimeInWorldFractureCheck;

		public const RockLayerType MinLayerType = RockLayerType.Sandstone;

		public const RockLayerType MaxPrimalRockLayerType = RockLayerType.Diamond;

		public CFloat PendingCoreFragments;

		public UpgradeManager UpgradeManager { get; }

		private static Dictionary<RockLayerType, (float Currency, float PendingAmount)> PendingCoreFragmentsCache { get; }

		public RLong LastTimeInWorldFracture { get; set; }

		public WorldFractureManager Load()
		{
			return null;
		}

		public WorldFractureManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void UpdateTimeInWorldFracture()
		{
		}

		private void InitializeUpgradeManager()
		{
		}

		private static float CalculatePendingCoreFragmentsFor(RockLayerType rockLayerType)
		{
			return 0f;
		}

		public void DoWorldFracture()
		{
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
