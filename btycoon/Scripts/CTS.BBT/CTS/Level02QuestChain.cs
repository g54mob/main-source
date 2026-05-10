using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Level02QuestChain : QuestChain
	{
		[SerializeField]
		private StringKey _loanToggleId;

		[SerializeField]
		private StringKey _machinesButtonId;

		public MissionBasket MissionBasket
		{
			get
			{
				if (!CTSSingleton<StoreBaskets>.InstanceExists())
				{
					return null;
				}
				return CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			}
		}

		protected override void QuestChainInitialization()
		{
			base.QuestChainInitialization();
			UnlockingManager.AddUnlockKey(EUnlockKey.CheapBarPackage);
			UnlockingManager.AddUnlockKey(EUnlockKey.BloodStorage);
			UnlockingManager.AddUnlockKey(EUnlockKey.BasicBarPackage);
			UnlockingManager.AddUnlockKey(EUnlockKey.VampireBarPackage);
		}

		public void UnlockMachineUI()
		{
			HighlightButton.Highlight(_machinesButtonId);
		}
	}
}
