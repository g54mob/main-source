using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace MyStuff.CharacterCustomizer
{
	public class CustomizerReadyCoordinator : NetworkBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkList<ulong> readyPlayerIds;

		private NetworkList<ulong> knownPlayerSteamIds;

		private bool hasTriggeredAllReady;

		public static CustomizerReadyCoordinator Instance { get; private set; }

		public int ReadyPlayerCount => 0;

		public int TotalPlayerCount => 0;

		public bool AllPlayersReady => false;

		public bool HasKnownPlayers => false;

		public bool IsLocalPlayerReady => false;

		public event Action<int, int> OnReadyCountChanged
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

		public event Action OnAllPlayersReady
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

		public event Action<ulong, bool> OnPlayerReadyStateChanged
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

		public override void OnDestroy()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void SetReady(bool ready)
		{
		}

		public void ToggleReady()
		{
		}

		public (int, int) GetReadyCounts()
		{
			return default((int, int));
		}

		public bool IsPlayerReady(ulong clientId)
		{
			return false;
		}

		public void ForceCheckAllReady()
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void SetReadyServerRpc(ulong clientId, bool ready, RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void PlayerReadyStateChangedClientRpc(ulong clientId, bool isReady)
		{
		}

		[ClientRpc]
		private void AllPlayersReadyClientRpc()
		{
		}

		private void PopulateKnownPlayerSteamIds()
		{
		}

		public bool IsPlayerKnown(ulong steamId)
		{
			return false;
		}

		private void OnReadyListChanged(NetworkListEvent<ulong> changeEvent)
		{
		}

		private void BroadcastReadyCount()
		{
		}

		private void CheckAndTriggerAllReady()
		{
		}

		private void OnClientDisconnect(ulong clientId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_16366218(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_267286656(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2505752496(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
