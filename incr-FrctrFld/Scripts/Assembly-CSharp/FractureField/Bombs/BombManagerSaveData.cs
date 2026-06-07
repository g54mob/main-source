using System.Collections.Generic;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Bombs
{
	public class BombManagerSaveData : IConvertableSaveData
	{
		public RInt CurrentCharges { get; set; }

		public RList<float> PendingChargeTimers { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		protected BombManagerSaveData Save(BombManager data)
		{
			return null;
		}
	}
}
