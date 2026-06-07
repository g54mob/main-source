using System.Collections.Generic;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.PlayerStats
{
	public class PlayerStatsManager : PlayerStatsManagerSaveData, ISaveData<PlayerStatsManager, PlayerStatsManagerSaveData>
	{
		public const float BaseFracture = 1f;

		public CFloat Fracture;

		public const float BaseHitSpeed = 0.75f;

		public CFloat HitSpeed;

		public const float BasePierce = 1f;

		public CFloat Pierce;

		public const float BaseCritChance = 0.01f;

		public CFloat CritChance;

		public const float BaseCritMultiplier = 2f;

		public CFloat CritMultiplier;

		public UpgradeManager UpgradeManager { get; private set; }

		public PlayerStatsManager Load()
		{
			return null;
		}

		public PlayerStatsManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		public Upgrade GetUpgrade(string upgradeId)
		{
			return null;
		}

		public List<UpgradeState> GetAllUpgradeStates()
		{
			return null;
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
