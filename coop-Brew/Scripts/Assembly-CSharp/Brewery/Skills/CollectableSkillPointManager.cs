using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Skills
{
	[RequireComponent(typeof(NetworkObject))]
	public class CollectableSkillPointManager : NetworkBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CReadyFallback_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CollectableSkillPointManager _003C_003E4__this;

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
			public _003CReadyFallback_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CRequestReadyFromServer_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CollectableSkillPointManager _003C_003E4__this;

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
			public _003CRequestReadyFromServer_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CSyncAfterDelay_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CollectableSkillPointManager _003C_003E4__this;

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
			public _003CSyncAfterDelay_003Ed__34(int _003C_003E1__state)
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

		[Header("Stars")]
		[Tooltip("All collectable stars in the scene. Use the context menu to assign IDs.")]
		[SerializeField]
		private CollectableSkillPoint[] allStars;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly Dictionary<string, CollectableSkillPoint> registeredStars;

		private readonly Dictionary<string, HashSet<string>> collectedStarsPerPlayer;

		private readonly HashSet<string> localCollectedIds;

		private bool isReady;

		public static CollectableSkillPointManager Instance { get; private set; }

		public bool IsReady => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CReadyFallback_003Ed__20))]
		private IEnumerator ReadyFallback()
		{
			return null;
		}

		private void SetReady()
		{
		}

		private void EnableAllStarColliders()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private new void OnDestroy()
		{
		}

		public void RegisterStar(CollectableSkillPoint star)
		{
		}

		public void UnregisterStar(CollectableSkillPoint star)
		{
		}

		public void RequestCollect(string starId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCollectServerRpc(string starId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void ConfirmCollectClientRpc(string starId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void RejectCollectClientRpc(string starId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[IteratorStateMachine(typeof(_003CRequestReadyFromServer_003Ed__31))]
		private IEnumerator RequestReadyFromServer()
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestReadyServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		[IteratorStateMachine(typeof(_003CSyncAfterDelay_003Ed__34))]
		private IEnumerator SyncAfterDelay(ulong clientId)
		{
			return null;
		}

		private void SyncCollectedStarsToPlayer(ulong clientId)
		{
		}

		[ClientRpc]
		private void MarkClientReadyClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SyncCollectedListClientRpc(string commaSeparatedIds, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private string GetPlayerSaveId(ulong clientId)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2528364206(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_428576109(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1546323305(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_457969902(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_817202257(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2947089126(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
