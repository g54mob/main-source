using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class LobbyPlayerData : NetworkBehaviour
	{
		[Header("Player Data")]
		private NetworkVariable<ulong> steamId;

		private NetworkVariable<bool> isReady;

		private NetworkVariable<FixedString64Bytes> playerName;

		internal static readonly List<LobbyPlayerData> ActivePlayers;

		private static readonly object ActivePlayersLock;

		public ulong SteamId => 0uL;

		public bool IsReady => false;

		public string PlayerName => null;

		public event Action<ulong, bool> OnReadyStateChanged
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

		public event Action<ulong, string> OnPlayerNameChanged
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

		internal static void CopyActivePlayers(List<LobbyPlayerData> destination)
		{
		}

		internal static LobbyPlayerData FindLocalPlayer(ulong clientId)
		{
			return null;
		}

		internal static void ClearActivePlayers()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void InitializeLocalPlayer()
		{
		}

		public void ToggleReady()
		{
		}

		public void SetReady(bool ready)
		{
		}

		private void OnSteamIdChanged(ulong previousValue, ulong newValue)
		{
		}

		private void OnReadyChanged(bool previousValue, bool newValue)
		{
		}

		private void OnNameChanged(FixedString64Bytes previousValue, FixedString64Bytes newValue)
		{
		}

		private void NotifyUI()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void KickPlayerServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2070442468(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
