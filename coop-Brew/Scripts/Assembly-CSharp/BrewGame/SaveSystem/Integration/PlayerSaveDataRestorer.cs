using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Data;
using Player.Customization;
using Unity.Netcode;
using UnityEngine;

namespace BrewGame.SaveSystem.Integration
{
	[DefaultExecutionOrder(-100)]
	public class PlayerSaveDataRestorer : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndRestorePosition_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerSaveDataRestorer _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			private float _003CsteamIdWait_003E5__3;

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
			public _003CWaitAndRestorePosition_003Ed__7(int _003C_003E1__state)
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

		[Header("Settings")]
		[Tooltip("Maximum time to wait for save data to load (seconds)")]
		[SerializeField]
		private float maxWaitTime;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool _hasRestoredPosition;

		private bool _hasRestoredCustomization;

		private bool _hasRestoredInventory;

		public override void OnNetworkSpawn()
		{
		}

		[ServerRpc]
		private void RegisterSteamIdServerRpc(ulong steamId, ServerRpcParams serverRpcParams = default(ServerRpcParams))
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndRestorePosition_003Ed__7))]
		private IEnumerator WaitAndRestorePosition()
		{
			return null;
		}

		private void RestorePlayerPosition()
		{
		}

		private void RestoreCharacterCustomization(PlayerSaveData playerData)
		{
		}

		private void RestoreInventory(PlayerSaveData playerData)
		{
		}

		[ClientRpc]
		private void RestoreCustomizationClientRpc(CharacterCustomization customization)
		{
		}

		[ClientRpc]
		private void TeleportToPositionClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		private PlayerSaveData GetPlayerDataForClient(SaveGameData saveData, ulong clientId)
		{
			return null;
		}

		private string GetSteamIdForClient(ulong clientId)
		{
			return null;
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

		private static void __rpc_handler_3620400964(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1313110046(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3023029601(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
