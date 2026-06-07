using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BarUpgrade;
using BrewGame.SaveSystem.Integration;
using Brewery.NPC.Resurrection;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	[RequireComponent(typeof(NetworkObject))]
	public class QuestManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct EarnedVehicleData
		{
			public string prefabName;

			public Vector3 position;

			public Quaternion rotation;
		}

		[CompilerGenerated]
		private sealed class _003CAutoAdvanceCoroutine_003Ed__124 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public QuestManager _003C_003E4__this;

			public string questId;

			object IEnumerator<object>.Current
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
			public _003CAutoAdvanceCoroutine_003Ed__124(int _003C_003E1__state)
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
		}

		[CompilerGenerated]
		private sealed class _003CRevalidateQuestStepsAfterRestore_003Ed__169 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestManager _003C_003E4__this;

			public List<string> questIds;

			object IEnumerator<object>.Current
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
			public _003CRevalidateQuestStepsAfterRestore_003Ed__169(int _003C_003E1__state)
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
		}

		[CompilerGenerated]
		private sealed class _003CWaitForSaveDataAndTriggerTutorial_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestManager _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			object IEnumerator<object>.Current
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
			public _003CWaitForSaveDataAndTriggerTutorial_003Ed__86(int _003C_003E1__state)
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
		}

		[Header("Quest Registry")]
		[Tooltip("All quest giver profiles in the game")]
		[SerializeField]
		private List<QuestGiverProfile> questGiverProfiles;

		[Header("Milestone Quests")]
		[Tooltip("Quests that trigger automatically based on game milestones (no NPC required)")]
		[SerializeField]
		private List<QuestChain> milestoneQuests;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Vehicle Rewards")]
		[Tooltip("Vehicle prefabs that can be spawned as quest rewards (for respawning on load)")]
		[SerializeField]
		private List<GameObject> vehiclePrefabs;

		public NetworkList<QuestProgress> ActiveQuests;

		public NetworkList<FixedString64Bytes> CompletedQuestIds;

		public NetworkVariable<FixedString64Bytes> ActiveQuestId;

		private Dictionary<string, QuestChain> questChainRegistry;

		private Dictionary<string, QuestGiverProfile> questGiverRegistry;

		private Dictionary<string, Coroutine> autoAdvanceCoroutines;

		private const string BAR_QUEST_ID = "milestone_buy_bar";

		private bool hasTriggeredBarQuest;

		private BarUpgradeManager cachedBarManager;

		private const string DEATH_QUEST_ID = "milestone_npc_death";

		private bool hasTriggeredDeathQuest;

		private List<QuestTargetMarker> deathQuestMarkers;

		private const string HOUSE_QUEST_ID = "milestone_buy_house";

		private bool hasTriggeredHouseQuest;

		private List<QuestTargetMarker> houseQuestMarkers;

		private const string THEFT_QUEST_ID = "milestone_first_theft";

		private bool hasTriggeredTheftQuest;

		private const string SLEEP_QUEST_ID = "milestone_shop_closed_sleep";

		private bool hasTriggeredSleepQuest;

		private List<QuestTargetMarker> sleepQuestMarkers;

		private const string TUTORIAL_QUEST_ID = "tutorial_a_rough_start";

		private bool hasTriggeredTutorialQuest;

		private bool _isWaitingForSaveDataForTutorial;

		private const float MAX_WAIT_FOR_SAVE_DATA = 5f;

		private bool _hasRestoredSaveData;

		private Dictionary<string, int> itemCollectionProgress;

		private Dictionary<string, int> deliveryProgressTracker;

		private Dictionary<string, EarnedVehicleData> earnedVehicles;

		private Dictionary<string, GameObject> vehiclePrefabCache;

		private bool _hasRestoredEarnedVehicles;

		public static QuestManager Instance { get; private set; }

		public bool HasRestoredSaveData => false;

		public QuestStep ActiveQuestCurrentStep => null;

		public QuestChain ActiveQuestChain => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<string, QuestChain> OnQuestAccepted
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

		public event Action<string, int, QuestStep> OnQuestStepChanged
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

		public event Action<string, QuestChain> OnQuestCompleted
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

		public event Action<string> OnActiveQuestChanged
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

		public event Action OnQuestListChanged
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

		public event Action<string, int, int> OnObjectiveCompleted
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

		public event Action OnSaveDataRestored
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

		private static string SafeQuestIdToString(FixedString64Bytes fixedString)
		{
			return null;
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void BuildRegistries()
		{
		}

		private void ResetAllChainRuntimeState(string reason)
		{
		}

		private int ResetChainRuntimeState(QuestChain chain)
		{
			return 0;
		}

		[ContextMenu("Force Reset All Quest Runtime State (Recovery)")]
		public void ForceResetAllQuestRuntimeState()
		{
		}

		[ClientRpc]
		private void ForceResetAllQuestRuntimeStateClientRpc()
		{
		}

		private void InitializeServer()
		{
		}

		private bool TryAutoCompleteRemainingObjectives(string questId, ulong? triggeringClientId = null)
		{
			return false;
		}

		private void HandleQuestEvent(QuestEventType eventType, string context)
		{
		}

		private void ProcessQuestEventOnServer(QuestEventType eventType, string context, ulong? triggeringClientId)
		{
		}

		private void TryCompleteItemCollectedObjectives(string questId, QuestStep step, int stepIndex)
		{
		}

		private void HandleQuestEventWithPlayer(QuestEventType eventType, string context, ulong triggeringClientId)
		{
		}

		private void TryCompleteItemCollectedObjectivesWithPlayer(string questId, QuestStep step, int stepIndex, ulong triggeringClientId)
		{
		}

		private void HandleActiveQuestsChanged(NetworkListEvent<QuestProgress> changeEvent)
		{
		}

		private void HandleCompletedQuestsChanged(NetworkListEvent<FixedString64Bytes> changeEvent)
		{
		}

		private void HandleActiveQuestIdChanged(FixedString64Bytes oldValue, FixedString64Bytes newValue)
		{
		}

		public void TriggerTutorialQuestForNewPlayer()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForSaveDataAndTriggerTutorial_003Ed__86))]
		private IEnumerator WaitForSaveDataAndTriggerTutorial()
		{
			return null;
		}

		private void TriggerTutorialQuestInternal()
		{
		}

		private void TriggerBarQuestAfterTutorial()
		{
		}

		private void TriggerHouseQuestAfterBar()
		{
		}

		public bool TrackItemCollection(string questId, string itemId, int targetCount)
		{
			return false;
		}

		public int GetItemCollectionCount(string questId, string itemId)
		{
			return 0;
		}

		public void ResetItemCollection(string questId)
		{
		}

		public int GetDeliveryProgress(string questId, int stepIndex, string itemId)
		{
			return 0;
		}

		public void IncrementDeliveryProgress(string questId, int stepIndex, string itemId, int amount)
		{
		}

		public void ResetDeliveryProgress(string questId, int stepIndex)
		{
		}

		public void ResetAllDeliveryProgress(string questId)
		{
		}

		[ClientRpc]
		private void SyncDeliveryProgressClientRpc(string key, int value)
		{
		}

		[ClientRpc]
		private void SyncDeliveryProgressResetClientRpc(string prefix)
		{
		}

		private void SyncAllDeliveryProgressToClients()
		{
		}

		public void CheckCurrencyMilestone(float currentCurrency)
		{
		}

		private float GetBarPurchaseCost()
		{
			return 0f;
		}

		public void NotifyResurrectableNPCKilled()
		{
		}

		private void CheckFirstKillMilestone()
		{
		}

		public void CheckFirstTheftMilestone()
		{
		}

		public void CheckShopClosedSleepMilestone()
		{
		}

		private void SetupSleepQuestMarkers()
		{
		}

		private void CleanupSleepQuestMarkers()
		{
		}

		private void SetupMilestoneMarkersForClient(string questId)
		{
		}

		private void SetupDeathQuestMarkers()
		{
		}

		private void PlaceGraveMarker(QuestChain chain, ResurrectionManager resManager)
		{
		}

		private void CleanupDeathQuestMarkers()
		{
		}

		private void SetupHouseQuestMarkers()
		{
		}

		private void HandleHouseQuestStepChanged(string questId, int stepIndex, QuestStep step)
		{
		}

		private void UpdateHouseQuestMarker(int stepIndex)
		{
		}

		private void CleanupHouseQuestMarkers()
		{
		}

		private int GetTotalItemCountAcrossPlayers(string itemId)
		{
			return 0;
		}

		public void AcceptQuest(string questId, string giverNpcId)
		{
		}

		private void AdvanceQuestStep(string questId, ulong? triggeringClientId = null)
		{
		}

		private void CompleteQuest(string questId, int activeIndex, ulong? triggeringClientId = null)
		{
		}

		public void SetActiveQuest(string questId)
		{
		}

		private void CheckAutoAdvance(string questId)
		{
		}

		private void CheckStepAlreadySatisfied(string questId)
		{
		}

		private bool IsEnemyAliveByTag(string tag)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CAutoAdvanceCoroutine_003Ed__124))]
		private IEnumerator AutoAdvanceCoroutine(string questId, float delay)
		{
			return null;
		}

		private void GrantStepReputation(QuestStep step, QuestChain chain)
		{
		}

		private void GrantChainCompletionReputation(string giverNpcId, QuestChain chain)
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestAcceptQuestRpc(string questId, string giverNpcId)
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestSetActiveQuestRpc(string questId)
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestSkipStepRpc(string questId)
		{
		}

		[Rpc(SendTo.Server)]
		private void RelayQuestEventServerRpc(int eventType, string context, RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Server)]
		private void RelayQuestEventWithPlayerServerRpc(int eventType, string context, RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void NotifyInventoryFullClientRpc(string questId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncObjectiveCompletionClientRpc(string questId, int stepIndex, int objectiveIndex)
		{
		}

		private bool CanPlayerReceiveReward(ulong clientId, QuestReward reward)
		{
			return false;
		}

		public QuestChain GetQuestChain(string questId)
		{
			return null;
		}

		public int GetTotalQuestChainCount()
		{
			return 0;
		}

		public void RegisterQuestChain(QuestChain chain)
		{
		}

		public void AutoStartQuest(string questId, string giverNpcId)
		{
		}

		public QuestGiverProfile GetQuestGiver(string npcId)
		{
			return null;
		}

		public QuestProgress? GetQuestProgress(string questId)
		{
			return null;
		}

		private int FindQuestIndex(string questId)
		{
			return 0;
		}

		public bool IsQuestAccepted(string questId)
		{
			return false;
		}

		public bool IsQuestCompleted(string questId)
		{
			return false;
		}

		public int GetQuestStepIndex(string questId)
		{
			return 0;
		}

		public bool IsQuestOnStep(string questId, string eventContext)
		{
			return false;
		}

		public List<string> GetActiveQuestIds()
		{
			return null;
		}

		public List<string> GetCompletedQuestIds()
		{
			return null;
		}

		public bool NPCHasAvailableQuest(string npcId)
		{
			return false;
		}

		public bool NPCHasQuestReadyForTurnIn(string npcId)
		{
			return false;
		}

		public bool NPCIsCurrentStepTarget(string npcId)
		{
			return false;
		}

		public void RequestSkipStep(string questId)
		{
		}

		[ContextMenu("Skip Active Quest Step")]
		public void SkipActiveQuestStep()
		{
		}

		public void RevalidateQuestStep(string questId)
		{
		}

		public void RevalidateAllActiveQuests()
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestRevalidateQuestStepRpc(string questId)
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestRevalidateAllActiveQuestsRpc()
		{
		}

		[ContextMenu("Dump Quest State")]
		public void DumpQuestState()
		{
		}

		[ContextMenu("Reset All Quests")]
		public void ResetAllQuests()
		{
		}

		public void RegisterEarnedVehicle(string uniqueId, GameObject prefab)
		{
		}

		private GameObject GetVehiclePrefab(string prefabName)
		{
			return null;
		}

		private void RespawnEarnedVehicles()
		{
		}

		private GameObject FindEarnedVehicleById(string uniqueId)
		{
			return null;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		[IteratorStateMachine(typeof(_003CRevalidateQuestStepsAfterRestore_003Ed__169))]
		private IEnumerator RevalidateQuestStepsAfterRestore(List<string> questIds)
		{
			return null;
		}

		private void FireSaveDataRestoredEvent()
		{
		}

		private Dictionary<string, List<bool>> DeserializeObjectiveStates(object data)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2100771045(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2423867016(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4281448767(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_129482296(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_767784484(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2515888542(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_826852116(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3780488869(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_461426348(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_644866710(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1949805414(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_540257421(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
