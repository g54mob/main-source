using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Quest;
using InventorySystem;
using Player;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class TradingManager : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CEnumerateCatalystRewards_003Ed__53 : IEnumerable<(string, int)>, IEnumerable, IEnumerator<(string, int)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (string id, int qty) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private TradeOffer offer;

			public TradeOffer _003C_003E3__offer;

			private List<ItemReward>.Enumerator _003C_003E7__wrap1;

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
			public _003CEnumerateCatalystRewards_003Ed__53(int _003C_003E1__state)
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

		[Header("Configuration")]
		[Tooltip("All NPC trading profiles in the game")]
		[SerializeField]
		private List<TradingProfile> tradingProfiles;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<string, NPCTradingState> npcStates;

		public NetworkList<FixedString64Bytes> PurchasedLockedTrades;

		private Dictionary<string, int> expansionPurchaseCounts;

		public NetworkList<FixedString128Bytes> ExpansionPurchaseData;

		private Dictionary<string, int> _catalystCompletionsToday;

		public NetworkList<CatalystUsedEntry> CatalystUsedTodaySync;

		private Dictionary<string, NPCTradingState> clientNPCCache;

		private int lastKnownDayIndex;

		private Dictionary<string, TradingNPCController> registeredNPCs;

		[Header("Spawn Points")]
		[Tooltip("All NPC spawn points in the scene — drag them here instead of relying on FindObjectsByType")]
		[SerializeField]
		private List<TradingNPCSpawnPoint> spawnPoints;

		private Dictionary<string, NetworkObject> spawnedNPCs;

		public const int MaxExpansionPriceDoublings = 2;

		public static TradingManager Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<string, string> OnTradeCompleted
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

		public event Action OnDailyReset
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

		public event Action<string, string> OnLockedTradePurchased
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

		public event Action<string> OnNPCStateReceived
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

		private void InitializeServer()
		{
		}

		private float GenerateRandomMultiplier(float variationRange)
		{
			return 0f;
		}

		private List<string> GenerateDailyCatalysts(List<string> preferredCatalysts, int tier)
		{
			return null;
		}

		private void GenerateDailyCatalystsForNPC(string npcId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ExecuteTradeServerRpc(string npcId, string tradeId, ulong clientId)
		{
		}

		private int CountMatchingCatalyzedDrinks(InventoryManager inventory, BaseType baseType, List<string> requiredCatalysts)
		{
			return 0;
		}

		private bool TryConsumeCatalyzedDrinks(InventoryManager inventory, BaseType baseType, List<string> requiredCatalysts, int quantity)
		{
			return false;
		}

		private string FormatCatalyzedDrinkName(BaseType baseType, List<string> catalysts)
		{
			return null;
		}

		private bool CanAffordTrade(TradeInstance trade, InventoryManager inventory, PlayerCurrency currency, out string missingReason, string profileName = null, ulong clientId = 0uL)
		{
			missingReason = null;
			return false;
		}

		private void DeductTradeCosts(TradeInstance trade, InventoryManager inventory, PlayerCurrency currency, string profileName = null, ulong clientId = 0uL)
		{
		}

		private bool TryGetSpawnLocation(string npcId, out Vector3 position, out Quaternion rotation)
		{
			position = default(Vector3);
			rotation = default(Quaternion);
			return false;
		}

		private void SpawnItemReward(Item item, int quantity, Vector3 position, Quaternion rotation, TradingProfile profile = null)
		{
		}

		private void SpawnSingleItem(Item item, int quantity, Vector3 position, Quaternion rotation)
		{
		}

		private void SpawnItemGrid(Item item, int count, Vector3 origin, Quaternion rotation, float gridSpacing = 1.5f, int gridRowSize = 5)
		{
		}

		private void GiveTradeRewards(TradeInstance trade, InventoryManager inventory, PlayerCurrency currency, string npcId, ulong clientId = 0uL)
		{
		}

		[ClientRpc]
		private void SendTradeFailedClientRpc(string reason, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendTradeSuccessClientRpc(string tradeName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncTradeCompletionClientRpc(string npcId, string tradeId, int newCompletionCount)
		{
		}

		private void OnDayChanged()
		{
		}

		[ClientRpc]
		private void BroadcastDailyResetClientRpc()
		{
		}

		[IteratorStateMachine(typeof(_003CEnumerateCatalystRewards_003Ed__53))]
		private static IEnumerable<(string, int)> EnumerateCatalystRewards(TradeOffer offer)
		{
			return null;
		}

		public int GetCatalystDailyLimit(string catalystId)
		{
			return 0;
		}

		public int GetCatalystUsedToday(string catalystId)
		{
			return 0;
		}

		public int GetCatalystRemainingToday(string catalystId)
		{
			return 0;
		}

		private void SyncCatalystUsedEntry(string catalystId, int usedToday)
		{
		}

		private void RebuildCatalystUsedSync()
		{
		}

		public float ComputeCatalystCostMultiplier(TradeOffer offer)
		{
			return 0f;
		}

		private bool CheckCatalystLimits(TradeInstance trade, out string message)
		{
			message = null;
			return false;
		}

		public NPCTradingState GetNPCState(string npcId)
		{
			return null;
		}

		public TradingProfile GetProfile(string npcId)
		{
			return null;
		}

		public string FindNpcIdSellingItem(string itemId)
		{
			return null;
		}

		public int GetEffectiveMaxTrades(string npcId, string tradeId)
		{
			return 0;
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestNPCStateServerRpc(string npcId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void SyncNPCStateToClientRpc(NPCStateData data, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private NPCStateData SerializeNPCState(NPCTradingState state)
		{
			return default(NPCStateData);
		}

		private NPCTradingState DeserializeNPCState(NPCStateData data)
		{
			return null;
		}

		public bool IsLockedTradePurchased(string tradeId)
		{
			return false;
		}

		public bool IsLockedTradeUnlocked(LockedTrade trade, string npcId)
		{
			return false;
		}

		private bool AreAllQuestChainsCompleted(string[] chainIds)
		{
			return false;
		}

		public LockedTradeStatus GetLockedTradeStatus(LockedTrade trade, string npcId)
		{
			return default(LockedTradeStatus);
		}

		public int GetExpansionPurchaseCount(string npcId, string tradeId)
		{
			return 0;
		}

		public int GetExpansionTradePrice(string npcId, LockedTrade trade)
		{
			return 0;
		}

		private void IncrementExpansionPurchaseCount(string npcId, string tradeId)
		{
		}

		private void SyncExpansionPurchaseToNetworkList(string npcId, string tradeId, int count)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ExecuteLockedTradeServerRpc(string npcId, string tradeId, ulong clientId)
		{
		}

		private void TriggerLockedTradeAchievements(LockedTrade trade, string tradeId, ulong clientId)
		{
		}

		private void StartPostPurchaseQuest(QuestChain questChain, string npcId)
		{
		}

		private void SpawnLockedTradeReward(LockedTrade trade, NetworkObject playerObj, string npcId, string tradeId)
		{
		}

		private void SpawnVehicleAtPosition(GameObject prefab, Vector3 position, Quaternion rotation, string tradeId = null, string npcId = null)
		{
		}

		private string GenerateVehicleId(string prefabName, string tradeId, string npcId)
		{
			return null;
		}

		private void AssignVehicleUniqueId(GameObject instance, string uniqueId)
		{
		}

		private void RegisterVehicleForPersistence(string uniqueId, GameObject prefab)
		{
		}

		public TradingNPCController GetRegisteredNPC(string npcId)
		{
			return null;
		}

		private GameObject FindNpcById(string npcId)
		{
			return null;
		}

		private GameObject FindSpawnPointByName(string pointName)
		{
			return null;
		}

		private Vector3 GetFallbackSpawnPosition(NetworkObject playerObj, LockedTrade trade, string npcId, out Quaternion rotation)
		{
			rotation = default(Quaternion);
			return default(Vector3);
		}

		[ClientRpc]
		private void SendLockedTradeFailedClientRpc(string reason, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncLockedTradePurchasedClientRpc(string npcId, string tradeId)
		{
		}

		public List<LockedTrade> GetLockedTradesForQuestChain(string questChainId, string npcId = null)
		{
			return null;
		}

		public string GetQuestChainDisplayName(string questChainId)
		{
			return null;
		}

		public void RegisterNPC(TradingNPCController controller)
		{
		}

		public void UnregisterNPC(TradingNPCController controller)
		{
		}

		private void SpawnAllNPCs()
		{
		}

		private void SpawnNPCAtPoint(TradingNPCSpawnPoint spawnPoint)
		{
		}

		public static bool SnapNPCToGround(Transform npcTransform, float maxRayDistance = 5f, float groundOffset = 0.01f)
		{
			return false;
		}

		public void SnapAllNPCsToGround()
		{
		}

		[ContextMenu("Force Daily Reset")]
		private void ForceDailyReset()
		{
		}

		[ContextMenu("Print All States")]
		private void PrintAllStates()
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

		private static void __rpc_handler_2959514188(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_760359605(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2637800242(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2896371501(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_565521679(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2719973756(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_644416885(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2869910227(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3278556964(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_425170578(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
