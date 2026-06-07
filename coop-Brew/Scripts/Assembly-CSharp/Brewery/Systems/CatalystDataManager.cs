using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Data;
using Brewery.Items;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Systems
{
	public class CatalystDataManager : NetworkBehaviour, ISaveable
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly Dictionary<ulong, CatalystPlayerDataContainer> playerData;

		private CatalystPlayerStats cachedClientStats;

		private List<CatalystBrewRecord> cachedClientHistory;

		private Dictionary<int, CatalystDiscoveryEntry> cachedClientDiscoveries;

		private int cachedTotalPossibleDiscoveries;

		public static CatalystDataManager Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<ulong, CatalystBrewRecord, bool> OnBrewRecorded
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

		public event Action<ulong, CatalystPlayerStats> OnStatsUpdated
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

		public event Action<ulong, int, bool> OnFavoriteToggled
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

		public event Action<ulong> OnDataSynced
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

		public override void OnDestroy()
		{
		}

		private void OnClientDisconnect(ulong clientId)
		{
		}

		public CatalystPlayerDataContainer GetOrCreatePlayerData(ulong playerId)
		{
			return null;
		}

		public CatalystBrewRecord RecordBrew(ulong playerId, BeerDataSnapshot snapshot, int quantity = 1)
		{
			return default(CatalystBrewRecord);
		}

		public bool ToggleFavorite(ulong playerId, int recordId)
		{
			return false;
		}

		public CatalystPlayerStats GetStats(ulong playerId)
		{
			return default(CatalystPlayerStats);
		}

		public List<CatalystBrewRecord> GetHistory(ulong playerId)
		{
			return null;
		}

		public Dictionary<int, CatalystDiscoveryEntry> GetDiscoveries(ulong playerId)
		{
			return null;
		}

		public HashSet<string> GetEncounteredCatalysts(ulong playerId)
		{
			return null;
		}

		private int CalculateTotalPossibleDiscoveries()
		{
			return 0;
		}

		public int GetTotalPossibleDiscoveries()
		{
			return 0;
		}

		[ClientRpc]
		private void SyncBrewToClientRpc(CatalystBrewRecord record, CatalystPlayerStats stats, bool isNewDiscovery, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncFavoriteToggleClientRpc(int recordId, bool isFavorite, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncFullDataClientRpc(CatalystPlayerStats stats, int historyCount, int discoveryCount, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[Rpc(SendTo.Server)]
		public void RequestFullDataSyncRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Server)]
		public void RequestToggleFavoriteRpc(int recordId, RpcParams rpcParams = default(RpcParams))
		{
		}

		private ClientRpcParams GetTargetRpcParams(ulong clientId)
		{
			return default(ClientRpcParams);
		}

		private void Log(string message)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		private Dictionary<string, object> CaptureStats(CatalystPlayerStats stats)
		{
			return null;
		}

		private List<Dictionary<string, object>> CaptureHistory(List<CatalystBrewRecord> history)
		{
			return null;
		}

		private List<Dictionary<string, object>> CaptureDiscoveries(Dictionary<int, CatalystDiscoveryEntry> discoveries)
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private Dictionary<string, object> ConvertToDictionary(object obj)
		{
			return null;
		}

		private List<object> ConvertToList(object obj)
		{
			return null;
		}

		private void RestoreStats(CatalystPlayerStats stats, Dictionary<string, object> statsDict)
		{
		}

		private void RestoreHistory(List<CatalystBrewRecord> history, List<object> historyList)
		{
		}

		private void RestoreDiscoveries(Dictionary<int, CatalystDiscoveryEntry> discoveries, List<object> discList)
		{
		}

		public bool IsDiscovered(ulong playerId, BaseType baseType, string cat1, string cat2, string cat3)
		{
			return false;
		}

		public CatalystBrewRecord? GetLastCreatedBrew(ulong playerId)
		{
			return null;
		}

		public List<CatalystBrewRecord> GetFavorites(ulong playerId)
		{
			return null;
		}

		public CatalystBrewRecord? GetRecordById(ulong playerId, int recordId)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_614131234(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2788236455(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_193473172(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_678990576(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2416791404(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
