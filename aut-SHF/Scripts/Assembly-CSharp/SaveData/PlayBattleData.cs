using System;
using System.Collections.Generic;
using Battle;
using Libs;
using UI;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class PlayBattleData : ISerializationCallbackReceiver
	{
		public eWriterId writerId;

		public eStageId stageId;

		public List<eCustomRuleId> customRules;

		public eWaveGroup overwriteWaveGroup;

		public int ascensionLevel;

		[SerializeField]
		private bool freeControlMode;

		public ePhase lastPhase;

		public bool onStandby;

		public int lastWave;

		public int battleRandomSeed;

		public int clearDivision;

		public List<eStageDivision> stageStructure;

		public eLastBattleKey lastBattleKey;

		public eOrdealWisdom selectedWisdomOrdeal;

		public List<string> selectedRouteIds;

		public List<ChoiceRouteCtrl.RouteNode> routeList;

		public List<ChoiceRouteCtrl.RouteBranch> branchList;

		public SRandom rewardRandomState;

		public bool isUsableChuchuHouse;

		public eRouteEvent processingEvent;

		public List<WaveLog> historyList;

		public int currentHp;

		public int maxHp;

		public double nextSwitchTime;

		public double battleTimeSinceStartupAsDouble;

		public int longthinkTimeCount;

		public double remainLongThinkTime;

		public double chargeLongThinkTime;

		public int lastLevel;

		[SerializeField]
		private JDictionary<eLuggage, PlayUnlockData> _playUnitInfo;

		public List<ShopData> shopData;

		[SerializeField]
		private JDictionary<eResearchCategory, PlayResearchTreeDataGroup> _researchTreeDatas;

		public List<PriceRevision> standbyPriceRevision;

		public int researchPointGreen;

		public int researchPointRed;

		public int keen;

		public int machineCostPool1;

		public int machineCostPool2;

		public float machineCostPool1Remain;

		public int exp;

		public List<UseToGetPoint> useGreenToGetPoint;

		public int returnMana;

		[SerializeField]
		private JDictionary<eUpgradeKind, PlayBattlePassiveData> _passiveDB;

		public BuffSet<ePlayerBuff> playerBuff;

		public float difficultyIncrease;

		public List<int> addNamedToBossStages;

		public List<int> additionalEnemyPool;

		[SerializeField]
		private JDictionary<eEnemy, BuffSet<eEnemyBuff>> _enemiesBuff;

		public List<MiracleInfo> miracleInfos;

		public int selectedMiracleIdx;

		public int selectedHeroInfoIdx;

		public bool heroInfoAutoMode;

		public int freeReloadCount;

		public bool enableChageFactoryReload;

		public bool enableFirstResearchReload;

		public List<eRouteEvent> firstUpgradeRewards;

		public List<eUnlockId> waitUnlockDirectionIds;

		public bool ascensionUp;

		public List<LevelupAbility> eachLevelupSkill;

		public int score;

		[SerializeField]
		private JDictionary<eScoreRecord, ScoreDetailModel> _lastScoreDetails;

		public int spiritEnergy;

		public bool FreeControlMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public JDictionary<eLuggage, PlayUnlockData> PlayUnitInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eResearchCategory, PlayResearchTreeDataGroup> PlayResearchTreeDatas
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eUpgradeKind, PlayBattlePassiveData> PassiveDB
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eEnemy, BuffSet<eEnemyBuff>> EnemiesBuff
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JDictionary<eScoreRecord, ScoreDetailModel> LastScoreDetails
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int GetTotalManaAll => 0;

		public int GetUseManaAll => 0;

		public int GetTotalKeenAll => 0;

		public int GetUseKeenAll => 0;

		public int GetTotalResearchAll => 0;

		public int GetUseResearchAll => 0;

		public int GetTotalRedResearchAll => 0;

		public int GetUseRedResearchAll => 0;

		public int GetKnowledgeAll => 0;

		public void Init(eWriterId writerId, MstBattleDataEntities stageData, int acensionLevel, bool freeControlMode)
		{
		}

		private void InitPlayUnit(MstBattleDataEntities battleData)
		{
		}

		private void OpenAllRecipeAndUpgrade(List<eCustomRuleId> customRules)
		{
		}

		private void InitShopData()
		{
		}

		private void InitResearchTreeData(MstBattleDataEntities battleData)
		{
		}

		public void UnlockResearch(eResearchCategory category)
		{
		}

		private void TakeEffectResearch(ResearchTreeDataUnit data, bool isFreeUnlock)
		{
		}

		private bool CustomResearchTreeItemFilter(MstResearchTreeDataEntities entity)
		{
			return false;
		}

		private void SetInitialPoints(MstBattleDataEntities stageData)
		{
		}

		public Dictionary<eLuggage, int> AllLuggageDeliveryCount()
		{
			return null;
		}

		public void AddPassiveData(eUpgradeKind kind, List<string> param, eArchiveCategory category, string id)
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
