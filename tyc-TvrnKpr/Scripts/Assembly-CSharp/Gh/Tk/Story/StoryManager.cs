using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Structure;
using UnityEngine.Scripting;
using Utils;

namespace Gh.Tk.Story
{
	[PersistenceOptIn]
	[InitializeOnGameStarted]
	public class StoryManager : IPersistable
	{
		[Serializable]
		public class StoryTriggeredLog
		{
			public int lastTriggeredProfileSecondsPlayed;

			public string storyId;

			public int triggeredCounter;

			protected StoryTriggeredLog()
			{
			}

			public StoryTriggeredLog(string storyId)
			{
			}

			public StoryTriggeredLog Clone()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		private RollingList<string> _triggeredStoryLog;

		public const string StoryCreatedByChaosEventMarkerKey = "StoryCreatedByChaosEvent";

		[PersistenceOptIn]
		private float _suspendEconomyEventsUntilGameTime;

		[PersistenceOptIn]
		private List<string> _previousOutOfStockTemplateIds;

		[PersistenceOptIn]
		private float _fireBrigadeDisabledNextSpawn;

		private static float[] _chaosEffectPercentageToProbabilityTable;

		private const float _chaosProbabilityBalanceAdjustment = 0.8f;

		[PersistenceOptIn]
		private float _randomStoriesCooldown;

		private static readonly StoryComplexity[] _storyComplexityValues;

		[PersistenceOptIn]
		private List<string> _last5RandomStoryGroupIds;

		private const float StoryRepeatSecondsUntilFactorIsBackAt1 = 43200f;

		private const string BaseActorData_KeyTemplate = "basic-actor-data-{0}";

		private static float[] goldScale;

		private const string StaffWageData_KeyTemplate = "staff-wage-data-{0}";

		public static StoryManager Instance => null;

		public List<StoryGraph> AllStoryGraphs { get; private set; }

		public Dictionary<string, StoryNode> AllStoryNodes { get; private set; }

		public List<ScenarioStoryStartNode> ScenarioStoryStartNodes { get; private set; }

		public List<FreeplayStartNode> FreeplayStartNodes { get; private set; }

		public List<BasicStoryStartNode> BasicStoryStartNodes { get; private set; }

		public List<RandomStoryStartNode> RandomStoryNodes { get; private set; }

		[PersistenceOptIn]
		public DataStore StoryFlags { get; private set; }

		[PersistenceOptIn]
		public DataStore LevelTemporaryStoryFlags { get; private set; }

		[PersistenceOptIn]
		public Dictionary<string, List<string>> GatherNodeHits { get; protected set; }

		[PersistenceOptIn]
		public List<ActiveStory> ActiveStories { get; private set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string ScenarioId { get; set; }

		[PersistenceOptIn]
		public bool IsFreeplay { get; set; }

		[PersistenceOptIn]
		public Dictionary<string, StoryTriggeredLog> LevelTriggeredStories { get; set; }

		[PersistenceOptIn]
		public Dictionary<string, int> CreatedPatronDataIds { get; set; }

		[PersistenceOptIn]
		public List<int> ActorsPreviouslyUsedInStories { get; set; }

		[PersistenceOptIn]
		public string ActiveLevelStory { get; set; }

		public static event EventHandler<EventArgs<ActiveStory>> StoryTriggered
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

		public static event EventHandler<EventArgs<ActiveStory>> StoryRemoved
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

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnDayChanged(object sender, EventArgs e)
		{
		}

		static StoryManager()
		{
		}

		private StoryManager()
		{
		}

		private void AddStoryGraph(StoryGraph storyGraph)
		{
		}

		private void LoadStoryGraphs()
		{
		}

		private void CollectStoriesForCurrentScenario()
		{
		}

		private bool IsRandomStoryValid(RandomStoryStartNode node)
		{
			return false;
		}

		private bool IsBasicStartNodeValid(BasicStoryStartNode node)
		{
			return false;
		}

		private bool IsNodeValidForScenario(StoryNode node)
		{
			return false;
		}

		public void OnActiveStoriesChanged(ActiveStory storyRemovedOrAdded = null)
		{
		}

		public void RemoveActiveStory(ActiveStory story)
		{
		}

		private void AddActiveStory(ActiveStory activeStory)
		{
		}

		public ActiveStory TriggerNextNode(StoryNode node, ActiveStory parentNode)
		{
			return null;
		}

		private void TriggerStoryInternal(StoryNode node, ActiveStory activeStory)
		{
		}

		public ActiveStory TriggerStory(StoryNode story, params Actor[] targetActors)
		{
			return null;
		}

		private ActiveStory TriggerStory(StoryNode story, Action<ActiveStory> initAction, params Actor[] targetActors)
		{
			return null;
		}

		private void LogNodeTriggered(StoryNode story)
		{
		}

		private static void RaiseStoryTriggeredEvent(ActiveStory story)
		{
		}

		private static void RaiseStoryRemovedEvent(ActiveStory story)
		{
		}

		private void UpdateActiveStories()
		{
		}

		public void Init()
		{
		}

		public void PostLoadInit()
		{
		}

		public void AddStoryToTriggeredLog(ActiveStory story)
		{
		}

		public bool HasStoryTriggered(StoryNode node)
		{
			return false;
		}

		public void Update()
		{
		}

		public void TriggerUniqueStaffStory(Staff staff)
		{
		}

		public void KillStaffStory(Staff staff)
		{
		}

		private void OnPropRemoved(Prop prop)
		{
		}

		public static bool ShouldUpdateStoryTimers()
		{
			return false;
		}

		public void TriggerChaosEvent(bool fromStoryBook = false)
		{
		}

		private void SpawnRandomTimelineEvents()
		{
		}

		private void SpawnRandomEconomyEvents()
		{
		}

		private void SpawnRandomGroupRequests()
		{
		}

		private void SpawnRandomNeedIncreaseEvents()
		{
		}

		private static void SpawnGroups(int numberOfGroups, bool vip)
		{
		}

		public static void SpawnNewGroupRequest(bool vip)
		{
		}

		private void SpawnFireBrigadeUnavailableEvents()
		{
		}

		public void InitStoryTeller()
		{
		}

		private void StartLevelStory(string scenarioId)
		{
		}

		private void StartBasicStories()
		{
		}

		public void OnLevelStoryFinished(ActiveStory story, ScenarioStoryStartNode node)
		{
		}

		private void CommitTriggeredStoriesToProfile()
		{
		}

		private static void ComputeChaosEffectProbabilityTable()
		{
		}

		private void UpdateStoryTeller()
		{
		}

		private void EnsureCooldown(IStoryNodeHasComplexity node)
		{
		}

		public void EnsureMinimumCooldown(StoryComplexity complexity)
		{
		}

		private static StoryComplexity GetClosestComplexityMatch(StoryComplexity complexity)
		{
			return default(StoryComplexity);
		}

		public void EnsureMinimumCooldown(float cooldownInDays)
		{
		}

		private bool TryTriggerRandomStory()
		{
			return false;
		}

		private void OnStoryIsTriggering(ActiveStory story)
		{
		}

		private void CommitLevelStoryFlagsToProfile()
		{
		}

		public static List<DataStore> GetBasicStoryData(ActiveStory story)
		{
			return null;
		}

		public static DataStore GetWageChangeData(ActiveStory story, int staffId)
		{
			return null;
		}

		public static List<DataStore> GetWageChangeData(ActiveStory story)
		{
			return null;
		}
	}
}
