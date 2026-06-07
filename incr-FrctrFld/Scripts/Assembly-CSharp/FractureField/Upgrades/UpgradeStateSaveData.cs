using System;

namespace FractureField.Upgrades
{
	[Serializable]
	public class UpgradeStateSaveData : UpgradeState, ISaveData<UpgradeStateSaveData, UpgradeState>
	{
		public UpgradeStateSaveData Load()
		{
			return null;
		}

		public UpgradeState Save()
		{
			return null;
		}
	}
}
