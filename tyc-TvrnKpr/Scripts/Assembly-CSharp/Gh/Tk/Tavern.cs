using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class Tavern : IPersistable, IDisposable, IUpdateable
	{
		public class SatisfactionLogWithTimeStamp
		{
			public SatisfactionStatBase.SatisfactionStatLog Log { get; set; }

			public float TimeStamp { get; set; }
		}

		public enum BankruptcyState
		{
			NotAtRisk = 0,
			AtRisk = 1,
			Critical = 2,
			Bankrupt = 3
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass152_0
		{
			public string promininentCulture;

			public float dayCutOff;
		}

		[CompilerGenerated]
		private sealed class _003CGetKnownCultures_003Ed__153 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Tavern _003C_003E4__this;

			private string[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private IEnumerator<string> _003C_003E7__wrap3;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetKnownCultures_003Ed__153(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetRelevantPatronArchetypes_003Ed__152 : IEnumerable<(string, int)>, IEnumerable, IEnumerator<(string, int)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (string race, int tier) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Tavern _003C_003E4__this;

			private _003C_003Ec__DisplayClass152_0 _003C_003E8__1;

			private float _003CmaxTier_003E5__2;

			private int _003Ctier_003E5__3;

			private string[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			(string, int) IEnumerator<(string, int)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((string, int));
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetRelevantPatronArchetypes_003Ed__152(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<(string, int)> IEnumerable<(string, int)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public string id;

		public string name;

		private int _money;

		public double framesPlayed;

		public string[] ActiveScenarioTraits;

		[PersistenceOptIn]
		private List<string> _freeProps;

		private float _maxStarRating;

		private float _starRating;

		[JsonIgnore]
		public float _nextStarGoal;

		[JsonIgnore]
		public Dictionary<string, StarRatingManager> StarRatingManagers;

		public List<PatronData> patronPool;

		public List<StaffData> staff;

		private int _repairAtDamagePercentage;

		public List<string> introducedHeroes;

		public List<string> establishedTradeRoutes;

		[JsonIgnore]
		private GameObject _level;

		private bool _preventTemporaryClosing;

		private const float _daysInfluencingFame = 2f;

		private List<Tuple<float, float>> _satisfactionLogTimestamped;

		private const string SatisfactionStatKey = "satisfaction_stat";

		public List<string> unaquiredUniqueItems;

		public bool hadGrandOpening;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int firstOpenedOnDay;

		public TavernLog log;

		[PersistenceObjectReference]
		private List<GameItemTemplate> _knownGameItemTemplates;

		private Dictionary<string, LarderSetting> _larderTargetAmounts;

		public float slotMachineWinChance;

		public int slotMachineTotalProfit;

		public int slotMachineJackpot;

		[JsonIgnore]
		private GameStats _tavernStats;

		public List<Tuple<float, string[]>> MissedPatronsTimeAndReasons;

		private Dictionary<string, UnlockState> _unlockStates;

		private float _nextAllowedGiftBoxGameTime;

		public static float IsSatisfiedThreshold;

		public static float IsVeryUnsatisfiedThreshold;

		private StarRatingManagerManualMode _tavernStarManager;

		public bool IsCheatsEnabled { get; set; }

		[JsonIgnore]
		public int Money
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[PersistenceObjectReference]
		public List<Loan> LoansTaken { get; private set; }

		[JsonIgnore]
		public IEnumerable<string> FreeProps => null;

		[JsonIgnore]
		public float StarRating
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int StarRatingAsInt => 0;

		public float MaxStarRating
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int RepairAtDamagePercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public GameObject Level => null;

		[JsonIgnore]
		public bool IsOpen => false;

		public bool IsTemporarilyClosed { get; private set; }

		[JsonIgnore]
		public bool PreventTemporaryClosing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<Recipe> Recipes { get; set; }

		public GameStats TavernStats
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public GameDifficultySettingsData DifficultySettings { get; set; }

		public float GameTimeWithNegativeBalance { get; set; }

		public static event EventHandler<EventArgs> TavernNameChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<int>> MoneyChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs> FreePropsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LoansTakenChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<float>> StarRatingChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<int>> RepairAtDamagePercentageChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler IsTemporarilyClosedStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LarderTargetAmountSettingsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		static Tavern()
		{
		}

		protected Tavern()
		{
		}

		public void UpdateTavernName(string name)
		{
		}

		public static bool CanAfford(int cost)
		{
			return false;
		}

		public bool CanBuildPropFree(string uniqueKey)
		{
			return false;
		}

		public void RemoveFreeProp(string uniqueKey)
		{
		}

		public void AddFreeProp(string uniqueKey)
		{
		}

		public void TakeLoan(Loan loan)
		{
		}

		public void RemoveLoan(Loan loan)
		{
		}

		public void DecreaseStarRating()
		{
		}

		public void CloseTavernTemporarily()
		{
		}

		public void ReopenTavern()
		{
		}

		public bool IsInsideOpeningHours(int hoursFromNow = -1)
		{
			return false;
		}

		public bool WillTavernBeOpen(float hoursFromNow, bool ignoreMinutes)
		{
			return false;
		}

		public bool WillTavernBeOpenAt(float targetHour)
		{
			return false;
		}

		public int[] GetOpenHours()
		{
			return null;
		}

		public void LogTavernRating(float satisfaction)
		{
		}

		private void TrimOldSatisfactionLogs()
		{
		}

		public IEnumerable<int> GetAverageSatisfactionForLast48Hours(int bucketsToDivide = 12)
		{
			return null;
		}

		public int? GetAverageSatisfaction(Func<PatronData, bool> patronFilter = null)
		{
			return null;
		}

		public Dictionary<string, int> GetAverageSatisfactionPerCategory(Func<PatronData, bool> patronFilter = null)
		{
			return null;
		}

		private float GetAverageSatisfaction(int day)
		{
			return 0f;
		}

		public IEnumerable<SatisfactionStatBase.SatisfactionStatLog> GetSatisfactionHistory(Func<PatronData, bool> patronFilter = null)
		{
			return null;
		}

		public IEnumerable<PatronData> GetPatronsWithSatisfactionLogHistory(float? sinceDayF = null, float? tillDayF = null)
		{
			return null;
		}

		public Dictionary<float, Dictionary<string, SatisfactionStatBase.SatisfactionStatLog>> GetRelevantSatisfactionLogHistory(PatronData patronData)
		{
			return null;
		}

		public IEnumerable<Dictionary<string, SatisfactionLogWithTimeStamp>> GetSatisfactionLogHistory(IEnumerable<PatronData> patrons, float sinceDayF)
		{
			return null;
		}

		public IEnumerable<KeyValuePair<float, Dictionary<string, SatisfactionStatBase.SatisfactionStatLog>>> GetSatisfactionLogHistory(PatronData patron, float? sinceDayF = null)
		{
			return null;
		}

		public float GetMinDayInfluencingFameAndSatisfaction()
		{
			return 0f;
		}

		public int GetAvgSatisfactionForCategory(string category, Func<PatronData, bool> filter)
		{
			return 0;
		}

		public (int, int) GetAvgSatisfactionForReputation(string category, int? tier = null, string race = null)
		{
			return default((int, int));
		}

		public int GetAvgSatisfaction(IEnumerable<PatronData> patrons, string category = null, float? sinceDayF = null)
		{
			return 0;
		}

		internal (int, int) GetAvgSatisfactionAndCountOfDataPoints(IEnumerable<PatronData> patrons, string category = null, float? sinceDayF = null)
		{
			return default((int, int));
		}

		public void RefreshKnownGameItems()
		{
		}

		public void AddKnownGameItem(GameItemTemplate template)
		{
		}

		public void RemoveKnownGameItem(GameItemTemplate template)
		{
		}

		public int GetDaysSinceOpening()
		{
			return 0;
		}

		public IEnumerable<GameItemTemplate> GetKnownGameItemTemplates()
		{
			return null;
		}

		public Recipe GetExistingRecipe(string recipeId)
		{
			return null;
		}

		public Recipe GetExistingRecipe(Recipe filter)
		{
			return null;
		}

		public Tavern(bool trick)
		{
		}

		private void OnResearchChanged(object sender, EventArgs e)
		{
		}

		public void SetItemTargetAmount(string templateId, int amount)
		{
		}

		public IEnumerable<string> GetItemTemplateIdsWithTargetAmount()
		{
			return null;
		}

		public IEnumerable<LarderSetting> GetLarderSettings(string itemType)
		{
			return null;
		}

		public LarderSetting GetLarderSetting(string templateId)
		{
			return null;
		}

		public bool IsPropBuilt(CraftProcess process)
		{
			return false;
		}

		public IEnumerable<GameObjectX> GetPossibleProductionTargetsForJob(IngredientTemplate template, Job job)
		{
			return null;
		}

		public bool CanProduceMeal(IngredientTemplate template)
		{
			return false;
		}

		public bool CanProduceCookingPart(IngredientTemplate template)
		{
			return false;
		}

		public bool IsReplenishmentAvailable(GameItemTemplate template)
		{
			return false;
		}

		public GameItem SpawnGameItem(GameItemTemplate gameItem, bool stack = true, Vector3? position = null, Quaternion? rotation = null, bool withPutIntoStorageJob = true)
		{
			return null;
		}

		public void CallWaterDragon()
		{
		}

		public void Dispose()
		{
		}

		public bool IsOnFire(bool ignoreSmallFire = true)
		{
			return false;
		}

		private void _tavernStats_CounterChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		[IteratorStateMachine(typeof(_003CGetRelevantPatronArchetypes_003Ed__152))]
		public IEnumerable<(string, int)> GetRelevantPatronArchetypes()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetKnownCultures_003Ed__153))]
		public IEnumerable<string> GetKnownCultures()
		{
			return null;
		}

		public void UpdateObject()
		{
		}

		public bool AllowBuyingIngredients()
		{
			return false;
		}

		public bool IsBlacksmithUnlockedAndBuildable()
		{
			return false;
		}

		public bool IsLaundryUnlockedAndBuildable()
		{
			return false;
		}

		public bool IsDormUnlockedAndBuildable()
		{
			return false;
		}

		public bool IsShopUnlockedAndBuildable()
		{
			return false;
		}

		public (BankruptcyState, float) GetBankruptcyState()
		{
			return default((BankruptcyState, float));
		}

		public bool IsUnlockState(string key, UnlockState state)
		{
			return false;
		}

		public void SetUnlockState(string key, UnlockState state)
		{
		}

		public bool IsGiftBoxUnlockOffCooldown()
		{
			return false;
		}

		public void SetNextAllowedGiftBoxCooldown()
		{
		}

		public static string GetXStarLocalizedKey(float stars, string objectNameKey)
		{
			return null;
		}

		public static int ConvertGameValueToPercentageInt(float satisfaction)
		{
			return 0;
		}

		public void InitStarRatings()
		{
		}

		private static void OnRatingManagerChanged(object sender, EventArgs e)
		{
		}

		private void CheckForStarUpgrade()
		{
		}

		private void UpgradeTavernStarRating(float targetRating)
		{
		}

		private void CreateTavernRequirements()
		{
		}

		private void CreateAccommodationRequirements()
		{
		}

		internal bool ProvidesNeed(string needType, out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		internal bool ProvidesSecondaryNeed(PatronSecondaryNeed need, out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		private void CreateDrinkRequirements()
		{
		}

		private string GetXPatronsSatisfiedInTierAndCategory(int amount, int tier, string category)
		{
			return null;
		}

		internal (int, TooltipData) GetEffectiveReputation(string category, int? tier, string race, bool createTooltip)
		{
			return default((int, TooltipData));
		}

		internal (int, TooltipData) GetReputationSummary(string category)
		{
			return default((int, TooltipData));
		}

		private (int, TooltipData) GetReputationTierDetails(string category, string race)
		{
			return default((int, TooltipData));
		}

		private void CreateFoodRequirements()
		{
		}

		private void CreateShopRequirements()
		{
		}

		private void CreateServiceRequirements()
		{
		}

		private string GetHavePropLabelKey(string propName)
		{
			return null;
		}

		private string GetMinStarTitleLocalizedKey(string category, float starRating)
		{
			return null;
		}

		public void UpdateCurrentRequirements()
		{
		}

		public string GetStarRatingTooltip()
		{
			return null;
		}
	}
}
