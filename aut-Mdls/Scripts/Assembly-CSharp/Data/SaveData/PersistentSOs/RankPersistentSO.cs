using Presentation.Locators;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Rank", fileName = "RankPersistentSO")]
	public class RankPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private RankConfigSO _rankConfig;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		private bool _waitingForRichPresenceReady;

		public override void ResetToDefaults()
		{
			_rankConfig.ResetXP();
			_waitingForRichPresenceReady = false;
			_integrationManagerLocator.Integration.ClearSocialPresence();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new RankSaveData(_rankConfig.CurrentXp);
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			ResetToDefaults();
			_rankConfig.SetXP(((RankSaveData)saveData).CurrentXP, shouldExecuteBehaviors: false);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<RankSaveData>(fullPath);
		}
	}
}
