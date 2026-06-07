using System.Collections.Generic;
using FractureField.Upgrades;

namespace FractureField.PlayerStats
{
	public class PlayerStatsManagerSaveData : IConvertableSaveData
	{
		public List<UpgradeState> UpgradeStates { get; set; }

		protected PlayerStatsManagerSaveData Save(PlayerStatsManager data)
		{
			return null;
		}
	}
}
