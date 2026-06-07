using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story;
using Gh.Tk.Story.Config;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	public class SpawnPatron : MonoBehaviour, IPersistable, IUpdateable
	{
		private LevelConfig _levelConfig;

		[PersistenceOptIn]
		private int _maxHourCalculated;

		[PersistenceOptIn]
		private List<PatronPopulationData> _population;

		[PersistenceOptIn]
		private List<PatronPopulationData> _pawnSpawnCandidates;

		private static readonly int[] _hours;

		[PersistenceOptIn]
		private float _revealClarity;

		[PersistenceOptIn]
		private float _timeClarity;

		[PersistenceOptIn]
		private float _lastClarityUpdateTimestamp;

		public const float MINIMUM_TIME_CLARITY = 0f;

		public const float MINIMUM_REVEAL_CLARITY = 0f;

		private const float _timeClarityLostPerGameHour = 1f / 12f;

		private const float _revealClarityLostPerGameHour = 0.0020833334f;

		public IEnumerable<PatronPopulationData> Population => null;

		public float TimeClarity => 0f;

		public float RevealClarity => 0f;

		public static event EventHandler PopulationChanged
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

		private void Start()
		{
		}

		private void TimeController_HourChanged(object sender, EventArgs e)
		{
		}

		public void AddPawns(IEnumerable<PatronPopulationData> pawns)
		{
		}

		public void AddPawnInRandomPosition(PatronPopulationData pawn)
		{
		}

		public void RemovePawn(PatronPopulationData pawn)
		{
		}

		public void RemovePawns(IEnumerable<PatronPopulationData> pawns)
		{
		}

		private void RaisePopulationChangedEvent()
		{
		}

		private void RecalculatePawnsForCurrentHour()
		{
		}

		private static void MakePawnHistoric(PatronPopulationData pawn)
		{
		}

		public void UpdateObject()
		{
		}

		public void UpdateSpawnCandidates(bool forceSpawnLeftovers = false)
		{
		}

		public void SpawnScheduledPatron(PatronData patronData)
		{
		}

		private void SpawnGroupPawn(PatronPopulationData pawn)
		{
		}

		internal Patron SpawnPawn(PatronPopulationData pawn)
		{
			return null;
		}

		public PatronNeedConfigNode GetOptionalPatronNeed(Patron patron, Func<PatronNeedConfigNode, bool> filter = null)
		{
			return null;
		}

		private PatronData TryFetchReturnVisitor(string race, int tier, string prefab, string gender)
		{
			return null;
		}

		public static LevelConfigNode GetLevelConfigNode()
		{
			return null;
		}

		private static (string, int)[] GetRaceDistributionPercentages(LevelConfigNode levelConfig = null)
		{
			return null;
		}

		public static PatronNeedConfigNode[] GetPatronNeedConfigNodes()
		{
			return null;
		}

		private List<PatronPopulationData> Calculate24HourPopulation()
		{
			return null;
		}

		private void TryToAdjustForMinimumAttendance(List<PatronPopulationData> result, PatronNeedConfigNode[] needConfigNodes)
		{
		}

		public PatronPopulationData GeneratePawnData(int hour, int minTier = 1, int maxTier = 5, string raceOverride = null, bool addRevealClarityRequirement = true, bool vip = false)
		{
			return null;
		}

		private static PatronTypeConfigNode[] GetPatronTypeConfigNodes()
		{
			return null;
		}

		private static void TryAddGroup(ref List<PatronPopulationData> result, PatronPopulationData leader, PatronTypeConfigNode patronType)
		{
		}

		public static PatronPopulationData[] GenerateGroup(PatronPopulationData leader, int groupSize)
		{
			return null;
		}

		private static void AddFakes(List<PatronPopulationData> result, int[] tierPopulations)
		{
		}

		private static int[] CalculateRacePopulation(int targetPopulation, PatronTypeConfigNode[] patronTypes, (string race, int distribution)[] raceDistributionPercentage, int tier)
		{
			return null;
		}

		private static Dictionary<PatronTypeConfigNode, int> GetPopulationPerPatronType(int population, List<PatronTypeConfigNode> patronTypes)
		{
			return null;
		}

		private int[] GetTargetPopulationPerHour(int population, AnimationCurve dayCurve)
		{
			return null;
		}

		public PatronPopulationData ScheduleStoryPatron(PatronData patronData, int hoursTillSpawn, StoryPatronConfig config)
		{
			return null;
		}

		private void UpdatePatronNeedsBasedPatronConfig(PatronPopulationData pawn, int hourOfDay, PatronData patronData, StoryPatronConfig config)
		{
		}

		private static PatronPopulationData GeneratePawnData(int hour, int tier, string race, PatronTypeConfigNode patronType, PatronNeedConfigNode[] potentialNeeds, bool vip = false)
		{
			return null;
		}

		public static int GetRevealDifficulty(int tier)
		{
			return 0;
		}

		public int GetEffectiveTimeClarity()
		{
			return 0;
		}

		public void ChangeTimeClarity(int delta)
		{
		}

		public void ChangeRevealClarity(float delta)
		{
		}

		internal void UpdateClarityValues()
		{
		}

		public bool WillVisitTavern(PatronPopulationData candidate)
		{
			return false;
		}

		private float GetSumOfDayCurve(AnimationCurve curve)
		{
			return 0f;
		}

		public void InitLevel()
		{
		}

		public void DeletePopulation()
		{
		}

		internal void Reset()
		{
		}

		private void ForwardHours(int hours)
		{
		}

		private void AddMorePopulation()
		{
		}

		public Patron Spawn(PatronData patronData, bool isPriorityPatron)
		{
			return null;
		}

		private GameObject InstantiatePatron(PatronData patronData)
		{
			return null;
		}

		public void EnsurePopulationExists(int endHour)
		{
		}

		public void ModifyPatrons(IEnumerable<PatronPopulationData> patrons, IPatronPawnModifyingConfig config)
		{
		}

		private void AddSecondaryNeed(PatronPopulationData pawn, SecondaryNeedConfig secondaryNeedConfig)
		{
		}

		private void AddTraits(PatronPopulationData pawn, string[] traits)
		{
		}

		private void ForceNeed(PatronPopulationData pawn, PatronNeedConfigNode needToAdd)
		{
		}

		private ListPoolX.DisposablePooledList<PatronPopulationData> GetAffectedPatrons(IEnumerable<PatronPopulationData> patrons, IPatronPawnModifyingFilterConfig config)
		{
			return null;
		}

		public IEnumerable<PatronPopulationData> GeneratePawns(IAddPatronsPawnsConfig config)
		{
			return null;
		}

		public void BackFillNeed(string needType)
		{
		}
	}
}
