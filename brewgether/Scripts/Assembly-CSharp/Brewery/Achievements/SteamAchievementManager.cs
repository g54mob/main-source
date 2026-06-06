using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Quest;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Achievements
{
	[RequireComponent(typeof(NetworkObject))]
	public class SteamAchievementManager : NetworkBehaviour, ISaveable
	{
		[Header("Configuration")]
		[Tooltip("Enable achievement system (for testing)")]
		[SerializeField]
		private bool enableAchievements;

		[Tooltip("Show debug logs")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Achievement Definitions")]
		[Tooltip("All achievement definitions")]
		[SerializeField]
		private List<AchievementDefinition> achievementDefinitions;

		private ISteamAchievementService steamService;

		private Dictionary<string, AchievementDefinition> achievementById;

		private Dictionary<AchievementTriggerType, List<AchievementDefinition>> achievementsByTrigger;

		private AchievementProgressTracker progressTracker;

		private Queue<string> pendingUnlocks;

		private float lastUnlockBatchTime;

		private const float UNLOCK_BATCH_INTERVAL = 1f;

		public static SteamAchievementManager Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<AchievementDefinition> OnAchievementUnlocked
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

		public event Action<AchievementDefinition, int, int> OnAchievementProgressUpdated
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

		public event Action<AchievementDefinition, float> OnAchievementNearCompletion
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

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void SyncHashSetBasedAchievements()
		{
		}

		private int GetHashSetCountForAchievement(AchievementDefinition achievement, AchievementProgressTracker.LifetimeStats stats)
		{
			return 0;
		}

		private void SyncLocalWithSteam()
		{
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

		private void InitializeLookupTables()
		{
		}

		private void InitializeSteamService()
		{
		}

		private void SubscribeToGameEvents()
		{
		}

		private void UnsubscribeFromGameEvents()
		{
		}

		private void HandleQuestEvent(QuestEventType type, string context, ulong clientId)
		{
		}

		private AchievementTriggerType MapQuestEventToTrigger(QuestEventType questType)
		{
			return default(AchievementTriggerType);
		}

		private void HandleSteamAchievementUnlocked(string achievementId)
		{
		}

		private void HandleSteamStatsReceived()
		{
		}

		public void TriggerAchievementEvent(AchievementTriggerType triggerType, string context = "", ulong clientId = 0uL)
		{
		}

		private void ProcessAchievementTrigger(AchievementDefinition achievement, AchievementTriggerType triggerType, string context, ulong clientId)
		{
		}

		private void IncrementAndCheck(AchievementDefinition achievement, ulong clientId)
		{
		}

		private void ProcessMilestone(AchievementDefinition achievement, string context, ulong clientId)
		{
		}

		private void ProcessCompoundCondition(AchievementDefinition achievement, AchievementTriggerType triggerType, string context, ulong clientId)
		{
		}

		private void ProcessStreakProgress(AchievementDefinition achievement, AchievementTriggerType triggerType, ulong clientId)
		{
		}

		public void ResetStreak(string achievementId)
		{
		}

		private void UnlockAchievement(AchievementDefinition achievement, ulong clientId)
		{
		}

		[ClientRpc]
		private void UnlockAchievementClientRpc(string achievementId, ulong targetClientId)
		{
		}

		[ClientRpc]
		private void UnlockAchievementForAllClientRpc(string achievementId)
		{
		}

		[ClientRpc]
		private void NotifyNearCompletionClientRpc(string achievementId, float percentage, ulong targetClientId)
		{
		}

		private void ProcessLocalUnlock(string achievementId)
		{
		}

		private void ProcessPendingUnlocks()
		{
		}

		private void ProcessOfflineQueue()
		{
		}

		private void ProcessRetroactiveUnlocks()
		{
		}

		private int GetRelevantStatForAchievement(AchievementDefinition achievement, AchievementProgressTracker.LifetimeStats stats)
		{
			return 0;
		}

		public AchievementDefinition GetAchievement(string achievementId)
		{
			return null;
		}

		public IEnumerable<AchievementDefinition> GetAchievementsByCategory(AchievementCategory category)
		{
			return null;
		}

		public int GetProgress(string achievementId)
		{
			return 0;
		}

		public bool IsUnlocked(string achievementId)
		{
			return false;
		}

		public float GetUnlockPercentage(string achievementId)
		{
			return 0f;
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ManualUnlockServerRpc(string achievementId, ulong clientId)
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void UpdateProgressServerRpc(string achievementId, int delta, ulong clientId)
		{
		}

		public void PushStat(string statName, int value)
		{
		}

		public void SetSteamService(ISteamAchievementService service)
		{
		}

		private void Log(string message)
		{
		}

		public void UnlockAllAchievements_DevOnly()
		{
		}

		public void ResetAllAchievements_DevOnly()
		{
		}

		public void LockAchievement_DevOnly(string achievementId)
		{
		}

		public void UnlockAchievement(string achievementId)
		{
		}

		public AchievementDefinition GetAchievementById(string achievementId)
		{
			return null;
		}

		public IReadOnlyList<AchievementDefinition> GetAllAchievements()
		{
			return null;
		}

		public bool IsAchievementUnlocked(string achievementId)
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4196318769(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3974572975(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_285642407(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1563517210(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1738844664(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
