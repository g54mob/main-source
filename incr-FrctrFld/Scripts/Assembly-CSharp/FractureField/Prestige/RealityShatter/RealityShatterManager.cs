using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Prestige.RealityShatter
{
	public class RealityShatterManager : RealityShatterManagerSaveData, ISaveData<RealityShatterManager, RealityShatterManagerSaveData>
	{
		private long _lastTimeInRealityShatterCheck;

		public const RockLayerType MinLayerType = RockLayerType.Silver;

		public CFloat PendingRealityShards;

		public UpgradeManager UpgradeManager { get; }

		private static Dictionary<RockLayerType, (float Currency, float PendingAmount)> PendingRealityShardsCache { get; }

		public RLong LastTimeInRealityShatter { get; set; }

		public RealityShatterManager Load()
		{
			return null;
		}

		public RealityShatterManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void UpdateTimeInRealityShatter()
		{
		}

		private void InitializeUpgradeManager()
		{
		}

		private static float CalculatePendingRealityShardsFor(RockLayerType rockLayerType)
		{
			return 0f;
		}

		public void DoRealityShatter()
		{
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
