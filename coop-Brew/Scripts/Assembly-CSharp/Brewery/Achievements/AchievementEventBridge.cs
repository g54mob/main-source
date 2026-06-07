using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Bar.Brawl;
using Brewery.NPC.Simple;
using Brewery.Quest;
using Player;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Achievements
{
	[RequireComponent(typeof(NetworkObject))]
	public class AchievementEventBridge : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCheckCompletionistRetroactive_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AchievementEventBridge _003C_003E4__this;

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
			public _003CCheckCompletionistRetroactive_003Ed__32(int _003C_003E1__state)
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
		private sealed class _003CWaitForAchievementManager_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AchievementEventBridge _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CWaitForAchievementManager_003Ed__21(int _003C_003E1__state)
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

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private SteamAchievementManager achievementManager;

		private AchievementProgressTracker progressTracker;

		private int totalBrawlsParticipated;

		private int totalBrawlsStarted;

		private HashSet<ulong> brawlParticipantClients;

		private int sessionBrewCount;

		private float sessionStartTime;

		private const float SESSION_BREW_WINDOW = 3600f;

		private List<float> recentTradeTimes;

		private const float SPEED_TRADE_WINDOW = 300f;

		private const int SPEED_TRADE_COUNT = 10;

		private HashSet<PlayerCurrency> subscribedCurrencyControllers;

		private HashSet<BarBrawlManager> subscribedBrawlManagers;

		private const string COMPLETIONIST_ACHIEVEMENT_ID = "SECRET_COMPLETIONIST";

		private static readonly Dictionary<string, (string statName, string achievementId)> FactionStatMapping;

		private static readonly Dictionary<string, string> BarFactionStatMapping;

		public static AchievementEventBridge Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForAchievementManager_003Ed__21))]
		private IEnumerator WaitForAchievementManager()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		private void SubscribeToGameEvents()
		{
		}

		private void UnsubscribeFromGameEvents()
		{
		}

		private void SubscribeToQuestEvents()
		{
		}

		private void SubscribeToBrawlManagers()
		{
		}

		public void SubscribeToBrawlManager(BarBrawlManager manager)
		{
		}

		private void SubscribeToCurrencyEvents()
		{
		}

		private void SubscribeToBarEvents()
		{
		}

		private void SubscribeToReputationEvents()
		{
		}

		private void SubscribeToAchievementEvents()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckCompletionistRetroactive_003Ed__32))]
		private IEnumerator CheckCompletionistRetroactive()
		{
			return null;
		}

		public void SubscribeToPlayerCurrency(PlayerCurrency currency)
		{
		}

		private void HandleBrawlStarted(BarBrawlManager manager)
		{
		}

		private void HandleBrawlEnded(BarBrawlManager manager)
		{
		}

		private void HandleParticipantAdded(NPCBrawlAgent agent)
		{
		}

		private void HandleParticipantRemoved(NPCBrawlAgent agent)
		{
		}

		private void HandleQuestEventWithPlayer(QuestEventType eventType, string context, ulong clientId)
		{
		}

		private bool IsRealNpcQuest(string questId)
		{
			return false;
		}

		private void HandleQuestAccepted(string questId, QuestChain chain)
		{
		}

		private void HandleQuestCompleted(string questId, QuestChain chain)
		{
		}

		private void HandleCurrencyChangedForPlayer(float newValue, ulong clientId)
		{
		}

		private void HandleAchievementUnlocked(AchievementDefinition unlockedAchievement)
		{
		}

		private void CheckCompletionist()
		{
		}

		public void TriggerBrawlWin(ulong clientId)
		{
		}

		public void TriggerBrawlLoss(ulong clientId)
		{
		}

		public void TriggerBrawlHitLanded(ulong clientId)
		{
		}

		public void TriggerBrewCompleted(string beverageType, ulong clientId, bool isLegendary = false, List<string> tags = null)
		{
		}

		public void TriggerPerfectBrew(ulong clientId)
		{
		}

		public void TriggerBarFullyUpgraded()
		{
		}

		public void TriggerAllBuffsActive(ulong clientId)
		{
		}

		public void TriggerStandFullyUpgraded()
		{
		}

		public void TriggerEmployeeHired(ulong clientId)
		{
		}

		public void TriggerAntennaRepaired()
		{
		}

		public void TriggerHouseBuilt(string houseId, ulong clientId)
		{
		}

		public void TriggerNPCResurrected(string npcId, ulong clientId)
		{
		}

		public void TriggerBarFactionSale(string factionName, ulong clientId)
		{
		}

		public void TriggerNPCTrade(string npcId, ulong clientId)
		{
		}

		public void TriggerStationUsed(string stationType, ulong clientId)
		{
		}

		public void TriggerCatalystApplied(int catalystCount, ulong clientId)
		{
		}

		public void TriggerBrewDiscovered(string recipeId, ulong clientId)
		{
		}

		public void TriggerFactionTrade(string factionName, float multiplier, ulong clientId)
		{
		}

		public void TriggerCurrencyMilestone(float newTotal, ulong clientId)
		{
		}

		public void TriggerLocationUnlocked(string locationId, ulong clientId)
		{
		}

		public void TriggerAchievementEvent(AchievementTriggerType triggerType, string context, ulong clientId)
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ReportBrawlWinServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ReportBrawlLossServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ReportBrewCompletedServerRpc(string beverageType, bool isLegendary, string tagsCommaSeparated, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ReportStationUsedServerRpc(string stationType, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(InvokePermission = RpcInvokePermission.Everyone)]
		public void ReportFactionTradeServerRpc(string factionName, float multiplier, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void PushFactionTradeStat(string factionName)
		{
		}

		private void PushBarFactionSaleStat(string factionName)
		{
		}

		private void Log(string message)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_641241591(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3850156478(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2363200433(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3997523164(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3079433494(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
