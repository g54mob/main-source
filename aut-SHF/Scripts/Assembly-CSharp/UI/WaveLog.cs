using System;
using System.Collections.Generic;
using Libs;
using SaveData;
using UnityEngine;

namespace UI
{
	[Serializable]
	public class WaveLog : ISerializationCallbackReceiver
	{
		[Serializable]
		public class SelectedHappeningData
		{
			public int id;

			public string param;
		}

		public int waveCount;

		public int divisionCount;

		public double totalWaitTime;

		public int useConcentrationCount;

		public int receiveDamage;

		public List<string> selectedResearch;

		public List<string> selectedUnlockUnit;

		public List<string> selectedRelic;

		public List<eRelic> usedRelic;

		public List<string> selectedInGameShopItem;

		public List<eUpgradeId> selectedLevelUp;

		public List<eShopId> purchasedGoods;

		public List<eResearchTreeId> unlockedResearchTree;

		public List<eRouteEvent> selectedRouteEvent;

		public List<SelectedHappeningData> selectedHappening;

		public List<eOrdealWisdom> skipOrdealKnowledge;

		public eEnemy selectedEnemy;

		public eEnemy selectedSubEnemy;

		public bool eliminatedElite;

		public bool eliminatedBoss;

		private bool? _isNamedInBattle;

		private bool? _isBossInBattle;

		[SerializeField]
		private JDictionary<eLuggage, int> _countUpLuggage;

		[SerializeField]
		private JDictionary<eLuggage, int> _additionalCountLuggage;

		[SerializeField]
		private JDictionary<eLuggage, int> _countUpManufacture;

		[SerializeField]
		private JDictionary<eLuggage, int> _countUpDamage;

		[SerializeField]
		private JDictionary<eLuggage, int> _countUpSally;

		public int earnedKnowledgePoint;

		public int getTotalMana;

		public int getTotalKeen;

		public int getTotalResearch;

		public int getTotalRedResearch;

		public int useMana;

		public int useKeen;

		public int useResearch;

		public int useRedReseach;

		public int sweetMinionCount;

		public bool isEndless;

		public int remainHp;

		[SerializeField]
		private JDictionary<eScoreRecord, ScoreDetailModel> _scoreDetails;

		public bool IsNamedInBattle => false;

		public bool IsBossInBattle => false;

		public JDictionary<eLuggage, int> CountUpLuggage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eLuggage, int> CountUpPlusLuggage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eLuggage, int> CountUpManufacture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eLuggage, int> CountUpDamage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eLuggage, int> CountUpSally
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eScoreRecord, ScoreDetailModel> ScoreDetails
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WaveLog(int waveCount, int division)
		{
		}

		public void Research(string archiveId)
		{
		}

		public void Relic(string archiveId)
		{
		}

		public void UnlockUnit(string archiveId)
		{
		}

		public void KnowledgePoint(int point)
		{
		}

		public void LevelUp(eUpgradeId id)
		{
		}

		public void PurchaseGoods(eShopId id)
		{
		}

		public void PurchaseInGameShopItem(string archiveId)
		{
		}

		public void UnlockResearch(eResearchTreeId id)
		{
		}

		public void SkipOrdealKnowledge(List<eOrdealWisdom> skipList)
		{
		}

		public void AddUseOrTotalMana(int value)
		{
		}

		public void AddUseOrTotalKeen(int value)
		{
		}

		public void AddUseOrTotalResearch(int value)
		{
		}

		public void AddUseOrTotalRedResearch(int value)
		{
		}

		private void AddUseOrTotalPoint(ref int total, ref int use, int value)
		{
		}

		public void AddCountUpLuggage(eLuggage key, int value)
		{
		}

		public void AddCountUpPlusLuggage(eLuggage key, int value)
		{
		}

		public void AddCountUpManufacture(eLuggage key, int value)
		{
		}

		public void AddCountUpDamage(eLuggage key, int value)
		{
		}

		public void AddCountUpSally(eLuggage key, int value)
		{
		}

		public double GetOutputInterval(eLuggage key)
		{
			return 0.0;
		}

		public int GetAbilityCount(eLuggage key)
		{
			return 0;
		}

		public int GetAbilityCount(List<eLuggage> keys)
		{
			return 0;
		}

		public void AddHappening(int id, string param = "")
		{
		}

		public void AddScoreDetails(eScoreRecord key, int score, bool ascensionBonus = false, float bonusIncrease = 1f, bool zeroDisplay = false)
		{
		}

		public eLuggage GetTopMoreLuggage()
		{
			return default(eLuggage);
		}

		public List<eLuggage> GetUnTopMoreLuggage()
		{
			return null;
		}

		public void UseRelic(eRelic relicId)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
