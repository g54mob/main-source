using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Battle;
using Factory.FieldData;
using Libs;
using SaveData;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public static class Context
	{
		public record ProductWithLevel(eLuggage Luggage, int Level)
		{
			[CompilerGenerated]
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
			}

			public eLuggage Luggage { get; set; }

			public int Level { get; set; }

			[CompilerGenerated]
			public override string ToString()
			{
				return null;
			}

			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				return false;
			}

			[CompilerGenerated]
			public virtual bool Equals(ProductWithLevel? other)
			{
				return false;
			}

			[CompilerGenerated]
			protected ProductWithLevel(ProductWithLevel original)
			{
			}

			[CompilerGenerated]
			public void Deconstruct(out eLuggage Luggage, out int Level)
			{
				Luggage = default(eLuggage);
				Level = default(int);
			}
		}

		public class DebugMenuEvent : UnityEvent<bool>
		{
		}

		public const string DebugMenuEnablePath = "Development/DebugMenu最初からON";

		public const string additionalPadSuffix = "_gamepad";

		public const string additionalSwitchMouseSuffix = "_switch_mouse";

		public const string additionalPS5Suffix = "_ps5";

		public const string additionalSwitchSuffix = "_switch";

		private static PseudoQueue<eLuggage> _product;

		private static PseudoQueue<ProductWithLevel> _productWithLevel;

		private static PseudoQueue<eLuggage> _manufacture;

		private static eTutorialSectionId _lobbyTutorialSection;

		private static eStageId _playStageId;

		private static InGameData _inGameData;

		public static OutGameData _outGameData;

		public static ProfileSummaryData _summaryData;

		private static UnifiedSettingData _unifiedSettingData;

		private static bool _isProhibitSettingDialog;

		private static bool _isReadTitleTrialMessage;

		private static bool _isSetNewSettings;

		private static bool _debugMenuEnable;

		public static readonly DebugMenuEvent OnDebugMenuChanged;

		public static int SpiritEnergy => 0;

		public static FactoryContext.AltarOfSpiritType AltarOfSpiritType => default(FactoryContext.AltarOfSpiritType);

		public static int SpiritEnergyUnitOrParts => 0;

		public static int SpiritEnergyShigen => 0;

		public static double BoostByAltarOfSpirit => 0.0;

		public static eWriterId WriterId
		{
			get
			{
				return default(eWriterId);
			}
			set
			{
			}
		}

		public static eChallengeId ChallengeId
		{
			get
			{
				return default(eChallengeId);
			}
			set
			{
			}
		}

		public static bool isContinuousPlay { get; set; }

		public static bool IsTutorial => false;

		public static eTutorialSectionId LobbyTutorialSection
		{
			get
			{
				return default(eTutorialSectionId);
			}
			set
			{
			}
		}

		public static eStageId PlayStageId
		{
			get
			{
				return default(eStageId);
			}
			set
			{
			}
		}

		public static InGameData InGameInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static OutGameData OutGameInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static ProfileSummaryData SummaryData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool CompletedIntroduction
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static List<eTutorialSectionId> CompletedTutorials => null;

		public static bool IsAllClearTutorial => false;

		public static PlayAuthorData PlayAuthorInfo => null;

		public static PlayChallengeData PlayChallengeInfo => null;

		public static PlayOutGameShopData PlayOutGameShopInfo => null;

		public static PlayArchiveData PlayArchiveDataInfo => null;

		public static bool ExistsDemoVerSaveData => false;

		public static List<eUnlockId> CompletedUnlockIds => null;

		public static SettingData SettingDataInfo => null;

		private static SettingData OldSettingDataInfo => null;

		public static List<eMachine> FavoritePaletteData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static int KnowledgePoint => 0;

		public static int AscensionLevel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static bool LobbyFreeControlMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsProhibitSettingDialog
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsPauseDialog => false;

		public static bool IsReadTitleTrialMessage
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsSetNewSettings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private static BattleContext _bc => null;

		public static bool ProhibitedScrollExpansion => false;

		public static int WaveCount => 0;

		public static Dictionary<eLuggage, PlayUnlockData> PlayLuggageInfo => null;

		public static bool IsConcentration => false;

		public static bool EnableLastBattle => false;

		public static bool IsEnableCompleteRemoveMachine => false;

		private static FactoryContext _fc => null;

		public static double TimeSinceStartup => 0.0;

		public static double DeltaTime => 0.0;

		public static bool IsProhibitFactory
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsProhibitRemoveMachine
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool IsProhibitRulerMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static int CountSweetsEffectedMinion => 0;

		public static int CountAllMinion => 0;

		public static int CountStatues => 0;

		public static Dictionary<string, List<Sprite>> gifSpritePathMap { get; set; }

		public static bool DebugMenuEnable
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public static void AddProduct(eLuggage[] products)
		{
		}

		public static eLuggage[] GetNewProduct()
		{
			return null;
		}

		public static void GCProduct()
		{
		}

		public static int CountNewProduct(Func<eLuggage, bool> condition)
		{
			return 0;
		}

		public static void AddProductWithLevel(ProductWithLevel[] products)
		{
		}

		public static ProductWithLevel[] GetNewProductWithLevel()
		{
			return null;
		}

		public static void GCProductWithLevel()
		{
		}

		public static void AddManufacture(eLuggage[] manufactures)
		{
		}

		public static eLuggage[] GetNewManufacture()
		{
			return null;
		}

		public static void GCManufacture()
		{
		}

		public static void LoadOrInitOutGameInfo()
		{
		}

		public static bool CheckPermanentUnlock(eArchiveCategory category, string key)
		{
			return false;
		}

		public static bool HasAchivement(eSteamAchivementId id)
		{
			return false;
		}

		public static bool CheckUnlockedPair(List<eUnlockId> pair)
		{
			return false;
		}

		public static void LoadOrInitSettingData()
		{
		}

		public static bool SaveSettingData(bool withSaveLocal = false)
		{
			return false;
		}

		public static bool CheckUpdateSettingData()
		{
			return false;
		}

		public static string GetInputDataJson()
		{
			return null;
		}

		public static void SetInputData(string json)
		{
		}

		public static void AddKnowledgePoint(int point)
		{
		}

		public static PlayUnlockData GetPlayUnlockData(eLuggage luggage)
		{
			return null;
		}

		public static void UseableChuchuhouse(bool on)
		{
		}

		public static void PlayTutorial(MstTutorialSectionEntities tutorialData)
		{
		}

		private static bool GetEnableLastBattleBeforeBattleInitialize()
		{
			return false;
		}

		public static void GetCompleteRemoveMachineBonus()
		{
		}

		public static int GetMiniascapeLevel()
		{
			return 0;
		}

		public static void AddInventory(StructureInventory inv)
		{
		}

		public static void AddAttachment(eAttachment attachment, string[] param, bool refresh = true)
		{
		}

		public static StructureInventory GetStructureInventory(eMachine machineId)
		{
			return null;
		}

		public static void ChangeSpeedGear(double gear)
		{
		}

		public static float GetTotalPlayTime()
		{
			return 0f;
		}

		[Conditional("INHOUSE_WITH_ANALYZE_SECRETLY")]
		public static void SaveTotalPlayTime()
		{
		}

		public static bool SaveFactory(bool withSave = true, bool withLocal = false)
		{
			return false;
		}

		public static void Initialize(bool exceptLocalData = false)
		{
		}

		public static void LobbyInitialize()
		{
		}

		public static bool ToggleDebugMenu()
		{
			return false;
		}
	}
}
