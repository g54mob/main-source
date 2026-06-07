using System.Collections.Generic;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Prestige.WorldFracture
{
	public class WorldFractureManagerSaveData : IConvertableSaveData
	{
		public RBool IsUnlocked { get; set; }

		public RInt Count { get; set; }

		public RInt CountAllTime { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		public RLong TimeInWorldFracture { get; set; }

		public RFloat AdditionalPendingCoreFragments { get; set; }

		protected WorldFractureManagerSaveData Save(WorldFractureManager data)
		{
			return null;
		}
	}
}
