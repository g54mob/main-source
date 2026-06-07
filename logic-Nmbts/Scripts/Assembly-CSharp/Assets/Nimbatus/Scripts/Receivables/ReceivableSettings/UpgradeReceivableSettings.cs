using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class UpgradeReceivableSettings : BaseReceivableSettings
	{
		public bool RandomType;

		[HideIf("RandomType", true)]
		public EMothershipUpgradeType UpgradeType;

		public bool UpOneLevel;

		[HideIf("UpOneLevel", true)]
		public int Level;

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			List<EMothershipUpgradeType> list = new List<EMothershipUpgradeType>
			{
				EMothershipUpgradeType.Bridge,
				EMothershipUpgradeType.Drive,
				EMothershipUpgradeType.DroneFabrication,
				EMothershipUpgradeType.DroneHangar,
				EMothershipUpgradeType.Sensors
			};
			EMothershipUpgradeType eMothershipUpgradeType = (RandomType ? list.RandomItemSeed(seed) : UpgradeType);
			int level = (UpOneLevel ? (SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.GetUpgradeLevel(eMothershipUpgradeType) + 1) : Level);
			return new UpgradeReceivable
			{
				UpgradeType = eMothershipUpgradeType,
				Level = level
			};
		}
	}
}
