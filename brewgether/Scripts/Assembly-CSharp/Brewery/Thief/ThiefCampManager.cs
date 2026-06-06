using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using InventorySystem;
using MyStuff.Environment;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class ThiefCampManager : NetworkBehaviour, ITimeEventListener, ISaveable
	{
		[Serializable]
		private struct CompactStolenItem
		{
			public string id;

			public int q;

			public ulong src;

			public int si;

			public float ts;

			public ulong th;

			public string bm;

			public string rm;

			public string cm;

			public string cbm;

			public string crm;

			public float v;

			public static CompactStolenItem FromStolenItemData(StolenItemData data)
			{
				return default(CompactStolenItem);
			}

			public StolenItemData ToStolenItemData()
			{
				return default(StolenItemData);
			}
		}

		[Serializable]
		private struct StolenInventorySnapshot
		{
			public CompactStolenItem[] i;
		}

		private const string THIEF_RESPAWN_EVENT_TAG = "ThiefPoolRespawn";

		private const string CAMP_RELOCATION_EVENT_TAG = "ThiefCampRelocation";

		[Header("Configuration")]
		[Tooltip("Thief camp configuration asset (contains prefab, pool settings, etc).")]
		[SerializeField]
		private ThiefCampConfig config;

		[Header("Camp Relocation")]
		[Tooltip("Pre-set camp positions in the scene. Create empty GameObjects at desired locations. Camp cycles through these positions every relocationIntervalDays.")]
		[SerializeField]
		private Transform[] campPositions;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("DEBUG ONLY: Spawn a thief immediately on start, IGNORING day threshold.")]
		[SerializeField]
		private bool spawnThiefOnStart;

		[Tooltip("DEBUG ONLY: Spawn camp with test stolen items for UI testing. Add items like empty_bottle, grain, etc. to test the camp stash UI.")]
		[SerializeField]
		private bool spawnWithTestItems;

		private NetworkVariable<ThiefCampState> campState;

		private NetworkVariable<FixedString4096Bytes> stolenInventoryState;

		private NetworkVariable<bool> allThievesDefeatedSync;

		private readonly List<StolenItemData> stolenItems;

		private NetworkVariable<CampSuppressionState> suppressionState;

		private NetworkVariable<int> activeStealingCountSync;

		private NetworkVariable<byte> thiefAlertTypeSync;

		private readonly List<NetworkObject> activeThieves;

		private float nextThiefSpawnTime;

		private float gameStartTime;

		private readonly HashSet<ulong> playersInCampRadius;

		private float lastCampDefenseCheckTime;

		private const float CAMP_DEFENSE_CHECK_INTERVAL = 0.5f;

		private readonly List<StealerBrain> stealers;

		private readonly List<DefenderBrain> defenders;

		private int defeatedToday;

		private bool poolSpawnedToday;

		private int currentTierIndex;

		private int lastTierCheckDayIndex;

		private int activeStealSlots;

		private TimeOfDayEventScheduler eventScheduler;

		private Guid respawnEventGuid;

		private int lastCheckedDayIndex;

		private bool respawnedThisDay;

		private float lastStealerRespawnRealtime;

		private float lastDefenderRespawnRealtime;

		private Guid relocationEventGuid;

		private int lastRelocationDayIndex;

		private bool relocationQueued;

		private int queuedTargetPositionIndex;

		private float nextRelocationRetryTime;

		private int currentCampPositionIndex;

		private int lastRelocationCheckDayIndex;

		private bool relocatedThisInterval;

		private CampLootDisplay campLootDisplay;

		public static ThiefCampManager Instance { get; private set; }

		public CampStatus Status => default(CampStatus);

		public bool IsActive => false;

		public int ActiveThiefCount => 0;

		public float TotalStolenValue => 0f;

		public Vector3 CampPosition => default(Vector3);

		public ThiefCampConfig Config => null;

		public int StolenItemCount => 0;

		public int CurrentTierIndex => 0;

		public int ActiveStealingCount => 0;

		public ThiefAlertType CurrentAlertType => default(ThiefAlertType);

		public int AvailableDefenders => 0;

		public int DefeatedToday => 0;

		public bool PoolSpawnedToday => false;

		public int PoolCount => 0;

		public bool AreAllThievesDefeated => false;

		public bool IsSuppressed => false;

		public bool IsCampDormant => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<CampStatus> OnCampStatusChanged
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

		public event Action<StolenItemData> OnItemStolen
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

		public event Action<NetworkObject> OnThiefSpawned
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

		public event Action<ulong> OnCampRaided
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

		public event Action<StolenItemData, int> OnStolenItemAdded
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

		public event Action<int> OnStolenItemRemoved
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

		public event Action OnStolenItemsCleared
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

		public event Action OnStolenItemsChanged
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

		public event Action<Vector3, Vector3> OnCampRelocated
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

		public event Action<int, int> OnActiveStealingCountChanged
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

		public event Action<ThiefAlertType> OnThiefAlertTypeChanged
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

		public int GetActiveDefenderCount()
		{
			return 0;
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

		private void Update()
		{
		}

		public override void OnDestroy()
		{
		}

		private void InitializeServer()
		{
		}

		private void RegisterTimeEvents()
		{
		}

		private void OnRespawnEventFired(TimeEventContext context)
		{
		}

		private void ValidatePrefabs()
		{
		}

		private void ValidateConfigTiers()
		{
		}

		private bool ValidatePrefab(GameObject prefab, string prefabName)
		{
			return false;
		}

		private void UpdateServer()
		{
		}

		private void UpdateActiveState()
		{
		}

		private void UpdateRegeneratingState()
		{
		}

		private void CheckTimePollingRespawn()
		{
		}

		private void CheckTimePollingRelocation()
		{
		}

		private void CheckDayBasedTierProgression()
		{
		}

		private void HandleTierChange(int oldTierIndex, int newTierIndex)
		{
		}

		private void DespawnStealersOnly()
		{
		}

		private void AdjustPoolForTier(ThiefTierConfig tier)
		{
		}

		private void SpawnAdditionalThieves(int stealerCount, int defenderCount)
		{
		}

		private void TrySpawnThief()
		{
		}

		private Vector3 GetRandomSpawnPosition()
		{
			return default(Vector3);
		}

		private void BroadcastStolenInventorySnapshot()
		{
		}

		[ClientRpc]
		private void SyncStolenInventoryClientRpc(string snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void OnStolenInventoryStateChanged(FixedString4096Bytes previousValue, FixedString4096Bytes newValue)
		{
		}

		private void ApplyStolenInventorySnapshot(string snapshot)
		{
		}

		public void AddStolenItem(StolenItemData stolenItem)
		{
		}

		public IReadOnlyList<StolenItemData> GetStolenItems()
		{
			return null;
		}

		public List<StolenItemData> GetStolenItemsFromStorage(ulong storageNetworkId)
		{
			return null;
		}

		public List<StolenItemData> GetStolenItemsList()
		{
			return null;
		}

		public bool TryTakeStolenItem(int index, InventoryManager playerInventory)
		{
			return false;
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		public void RequestTakeStolenItemRpc(int index, ulong playerInventoryNetworkId, RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Everyone)]
		private void NotifyTakeItemFailedClientRpc(ulong targetClientId)
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		public void RequestTakeAllStolenItemsRpc(ulong playerInventoryNetworkId, RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Everyone)]
		private void NotifyTakeAllResultClientRpc(int itemsTaken, int itemsRemaining, bool inventoryFull, ulong targetClientId)
		{
		}

		private void CleanupExpiredItems()
		{
		}

		public void OnAllDefendersDefeated(ulong raiderClientId)
		{
		}

		private void UpdateDefenderCount()
		{
		}

		public void CollectStolenItems(ulong collectorClientId)
		{
		}

		private void RespawnCamp()
		{
		}

		[ClientRpc]
		private void NotifyCampRespawnedClientRpc()
		{
		}

		public void OnThiefDefeated(NetworkObject thief)
		{
		}

		public void OnThiefReturnedToCamp(NetworkObject thief)
		{
		}

		private void CleanupDestroyedThieves()
		{
		}

		private void CleanupAllThieves()
		{
		}

		private void CheckCampDefense()
		{
		}

		private void TriggerCampDefense(Transform intruder)
		{
		}

		public void AlertCampToCombat(Transform attacker)
		{
		}

		public void OnRevengeComplete()
		{
		}

		private Transform FindRandomPlayer()
		{
			return null;
		}

		private List<Transform> FindAllPlayers()
		{
			return null;
		}

		public bool HasValidTheftTarget()
		{
			return false;
		}

		public TheftTarget FindBestTheftTarget()
		{
			return default(TheftTarget);
		}

		private int GetStorageItemCount(InventorySlot[] slots)
		{
			return 0;
		}

		private bool IsPlayerNearStorage(Vector3 position)
		{
			return false;
		}

		private void OnCampStateChanged(ThiefCampState previousValue, ThiefCampState newValue)
		{
		}

		private void OnSuppressionStateChanged(CampSuppressionState prev, CampSuppressionState next)
		{
		}

		private void SyncAllThievesDefeatedState()
		{
		}

		public void SpawnPool()
		{
		}

		private void DespawnPool()
		{
		}

		public void OnStealerDefeated(StealerBrain stealer)
		{
		}

		public void OnDefenderDefeated(DefenderBrain defender)
		{
		}

		private void CheckAllThievesDefeated()
		{
		}

		public void RespawnPool()
		{
		}

		private void RefillPool()
		{
		}

		private void SpawnAdditionalStealers(int count)
		{
		}

		private void SpawnAdditionalDefenders(int count)
		{
		}

		public bool RequestStealSlot(StealerBrain stealer)
		{
			return false;
		}

		public void ReleaseStealSlot(StealerBrain stealer)
		{
		}

		private void HandleActiveStealingCountChanged(int oldVal, int newVal)
		{
		}

		private void HandleThiefAlertTypeChanged(byte oldVal, byte newVal)
		{
		}

		private void UpdateThiefAlertType()
		{
		}

		public void SetCampSuppressed(bool suppressed, int suppressionDays)
		{
		}

		public void DespawnSuppressedCamp()
		{
		}

		public void RespawnFromDormant()
		{
		}

		public int FindValidRespawnPosition(float proximityRadius)
		{
			return 0;
		}

		public void RespawnAtPosition(int positionIndex)
		{
		}

		[ClientRpc]
		private void RespawnAtPositionClientRpc(Vector3 position, Quaternion rotation, int positionIndex)
		{
		}

		private void CheckSuppressionEnd()
		{
		}

		private void ForceStealersReturn()
		{
		}

		public bool AreAllThievesAtCamp()
		{
			return false;
		}

		public (int, int) GetLivingThiefCounts()
		{
			return default((int, int));
		}

		private void RestoreStealersActive()
		{
		}

		private void SetStealersPanicking(bool panicking)
		{
		}

		private void SetDefendersPanicking(bool panicking)
		{
		}

		public string GetEventTagFilter()
		{
			return null;
		}

		public void OnTimeEventTriggered(TimeEventContext context)
		{
		}

		private void SpawnTestStolenItems()
		{
		}

		[ContextMenu("Debug: Add Test Stolen Items")]
		private void DebugAddTestItems()
		{
		}

		[ContextMenu("Debug: Spawn Test Thief")]
		private void DebugSpawnThief()
		{
		}

		[ContextMenu("Debug: Spawn Pool")]
		private void DebugSpawnPool()
		{
		}

		[ContextMenu("Debug: Respawn Pool (Daily Reset)")]
		private void DebugRespawnPool()
		{
		}

		[ContextMenu("Debug: Force Raid Camp")]
		private void DebugRaidCamp()
		{
		}

		[ContextMenu("Debug: Log Camp Status")]
		private void DebugLogStatus()
		{
		}

		[ContextMenu("Debug: Log Config Tier Values")]
		private void DebugLogConfigTiers()
		{
		}

		[ContextMenu("Debug: Recalculate Tier & Respawn Pool")]
		private void DebugRecalculateAndRespawn()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void OnRelocationEventFired(TimeEventContext context)
		{
		}

		private bool TryExecuteRelocation(int targetPositionIndex)
		{
			return false;
		}

		private bool IsAnyPlayerWithinRadius(Vector3 position, float radius)
		{
			return false;
		}

		private int GetNextCampPositionIndex()
		{
			return 0;
		}

		private void ExecuteRelocation(int targetPositionIndex)
		{
		}

		private void QueueRelocation(int targetIndex)
		{
		}

		private void UpdateQueuedRelocation()
		{
		}

		private void NotifyThievesOfRelocation(Vector3 oldPos, Vector3 newPos)
		{
		}

		private void TeleportThievesAtCamp(Vector3 oldPos, Vector3 newPos)
		{
		}

		[ContextMenu("Debug: Force Relocate Camp")]
		private void DebugForceRelocate()
		{
		}

		[ContextMenu("Debug: Log Camp Positions")]
		private void DebugLogCampPositions()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4245067581(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1225420711(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2663864727(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2087138719(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_526159527(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_479703187(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_70499290(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
