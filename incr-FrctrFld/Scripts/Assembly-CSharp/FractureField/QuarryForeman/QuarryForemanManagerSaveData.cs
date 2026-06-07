using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.QuarryForeman
{
	public class QuarryForemanManagerSaveData : IConvertableSaveData
	{
		public RBool IsUnlocked { get; set; }

		public RBool IsEnabled { get; set; }

		public Dictionary<QuarryForemanAutomationType, RBool> IsEnabledForType { get; set; }

		public Dictionary<RockLayerType, RBool> IsEnabledForRockLayerType { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		protected QuarryForemanManagerSaveData Save(QuarryForemanManager data)
		{
			return null;
		}
	}
}
