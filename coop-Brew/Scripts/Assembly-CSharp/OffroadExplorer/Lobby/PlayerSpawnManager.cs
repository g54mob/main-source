using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Data;
using Unity.Netcode;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class PlayerSpawnManager : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSpawnAllPlayersWithDelay_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerSpawnManager _003C_003E4__this;

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
			public _003CSpawnAllPlayersWithDelay_003Ed__16(int _003C_003E1__state)
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
		private sealed class _003CValidateLocalPlayerInputAfterSpawn_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerSpawnManager _003C_003E4__this;

			public ulong clientId;

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
			public _003CValidateLocalPlayerInputAfterSpawn_003Ed__24(int _003C_003E1__state)
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

		[Header("Player Settings")]
		[SerializeField]
		private GameObject gamePlayerPrefab;

		[SerializeField]
		private GameObject femalePlayerPrefab;

		[SerializeField]
		private bool spawnOnSceneLoad;

		[Header("Spawn Points")]
		[SerializeField]
		private Transform[] spawnPoints;

		[SerializeField]
		private float spawnPointRadius;

		[SerializeField]
		private bool randomizeSpawnPoints;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<ulong, GameObject> spawnedPlayers;

		private Dictionary<ulong, bool> clientGenders;

		private List<int> availableSpawnIndices;

		public static PlayerSpawnManager Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnAllPlayersWithDelay_003Ed__16))]
		private IEnumerator SpawnAllPlayersWithDelay()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		public override void OnDestroy()
		{
		}

		private void InitializeSpawnPoints()
		{
		}

		private void ShuffleSpawnPoints()
		{
		}

		private void SpawnAllPlayers()
		{
		}

		public void SpawnPlayerForClient(ulong clientId)
		{
		}

		[ClientRpc]
		private void ValidateInputAfterSpawnClientRpc(ulong ownerClientId)
		{
		}

		[IteratorStateMachine(typeof(_003CValidateLocalPlayerInputAfterSpawn_003Ed__24))]
		private IEnumerator ValidateLocalPlayerInputAfterSpawn(ulong clientId)
		{
			return null;
		}

		private PlayerSaveData GetPlayerSaveData(ulong clientId)
		{
			return null;
		}

		private ulong GetSteamIdForClient(ulong clientId)
		{
			return 0uL;
		}

		private bool GetGenderForClient(ulong clientId)
		{
			return false;
		}

		[ClientRpc]
		private void RequestGenderClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void SubmitGenderServerRpc(bool isMale, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void DespawnPlayerForClient(ulong clientId)
		{
		}

		private void OnClientConnectedDuringGame(ulong clientId)
		{
		}

		private Vector3 GetNextSpawnPosition()
		{
			return default(Vector3);
		}

		private Quaternion GetSpawnRotation(Vector3 spawnPosition)
		{
			return default(Quaternion);
		}

		public Vector3 GetSpawnPositionForClient(ulong clientId)
		{
			return default(Vector3);
		}

		public Quaternion GetSpawnRotationForClient(ulong clientId)
		{
			return default(Quaternion);
		}

		public Vector3 GetDeathRespawnPosition()
		{
			return default(Vector3);
		}

		public Quaternion GetDeathRespawnRotation()
		{
			return default(Quaternion);
		}

		public GameObject GetPlayerForClient(ulong clientId)
		{
			return null;
		}

		public List<GameObject> GetAllPlayers()
		{
			return null;
		}

		public int GetSpawnedPlayerCount()
		{
			return 0;
		}

		private void OnDrawGizmos()
		{
		}

		private void DrawCircle(Vector3 center, float radius)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_789716038(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3615380910(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1509144600(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
