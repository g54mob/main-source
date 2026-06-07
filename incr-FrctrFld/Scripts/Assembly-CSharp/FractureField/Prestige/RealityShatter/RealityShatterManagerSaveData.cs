using System.Collections.Generic;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Prestige.RealityShatter
{
	public class RealityShatterManagerSaveData : IConvertableSaveData
	{
		public RBool IsUnlocked { get; set; }

		public RInt Count { get; set; }

		public RInt CountAllTime { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		public RLong TimeInRealityShatter { get; set; }

		public RFloat AdditionalPendingRealityShards { get; set; }

		protected RealityShatterManagerSaveData Save(RealityShatterManager data)
		{
			return null;
		}
	}
}
