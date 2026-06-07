using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

namespace BrewGame.Player
{
	public class StuckRecoveryController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CExecuteRecoverySequence_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StuckRecoveryController _003C_003E4__this;

			public ulong clientId;

			private Vector3 _003CspawnPos_003E5__2;

			private Quaternion _003CspawnRot_003E5__3;

			private bool _003ChadError_003E5__4;

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
			public _003CExecuteRecoverySequence_003Ed__16(int _003C_003E1__state)
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

		[Header("Cooldown")]
		[Tooltip("Cooldown in seconds between uses")]
		[SerializeField]
		private float cooldownSeconds;

		[Header("Timing")]
		[Tooltip("Delay after vehicle/moped exit before teleporting (seconds)")]
		[SerializeField]
		private float postExitDelay;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private float _lastRecoveryTime;

		private float _clientLastRecoveryTime;

		private bool _recoveryInProgress;

		private CharacterController _characterController;

		private NetworkTransform _networkTransform;

		private bool AreCheatsEnabled => false;

		public bool IsReady => false;

		private void Awake()
		{
		}

		public float GetRemainingCooldown()
		{
			return 0f;
		}

		public void RequestStuckRecovery()
		{
		}

		[ServerRpc]
		private void RequestStuckRecoveryServerRpc(bool clientCheatsEnabled, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[IteratorStateMachine(typeof(_003CExecuteRecoverySequence_003Ed__16))]
		private IEnumerator ExecuteRecoverySequence(ulong clientId)
		{
			return null;
		}

		[ClientRpc]
		private void TeleportAndRestoreClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		[ClientRpc]
		private void RecoveryDeniedClientRpc()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3264727139(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_980840215(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_411859834(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
