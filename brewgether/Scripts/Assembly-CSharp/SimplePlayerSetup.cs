using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class SimplePlayerSetup : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CKickAnimatorCoroutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Animator anim;

		private AnimatorControllerParameter[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private AnimatorControllerParameter _003Cp_003E5__4;

		private bool _003Cval_003E5__5;

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
		public _003CKickAnimatorCoroutine_003Ed__21(int _003C_003E1__state)
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
	private sealed class _003CSpawnProtectionCoroutine_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SimplePlayerSetup _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private bool _003CgroundFound_003E5__3;

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
		public _003CSpawnProtectionCoroutine_003Ed__17(int _003C_003E1__state)
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

	private NetworkVariable<ulong> networkSteamId;

	private NetworkVariable<FixedString64Bytes> networkDisplayName;

	private NetworkVariable<FixedString64Bytes> networkAuthPlayerId;

	[Header("Spawn Protection")]
	[Tooltip("Maximum time to wait for ground detection before giving up")]
	[SerializeField]
	private float maxGroundWaitTime;

	[Tooltip("Distance to raycast downward to detect ground")]
	[SerializeField]
	private float groundCheckDistance;

	[Tooltip("Layer mask for ground detection (leave empty to use all layers)")]
	[SerializeField]
	private LayerMask groundLayerMask;

	[Tooltip("Enable debug logs for spawn protection")]
	[SerializeField]
	private bool showDebugLogs;

	private CharacterController _characterController;

	private Coroutine _spawnProtectionCoroutine;

	public ulong SteamId => 0uL;

	public string DisplayName => null;

	public string AuthPlayerId => null;

	public override void OnNetworkSpawn()
	{
	}

	public override void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProtectionCoroutine_003Ed__17))]
	private IEnumerator SpawnProtectionCoroutine()
	{
		return null;
	}

	public void RequestAnimatorResync()
	{
	}

	[ServerRpc(RequireOwnership = false)]
	private void RequestAnimatorResyncServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
	{
	}

	[ClientRpc]
	private void KickAnimatorClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
	{
	}

	[IteratorStateMachine(typeof(_003CKickAnimatorCoroutine_003Ed__21))]
	private static IEnumerator KickAnimatorCoroutine(Animator anim)
	{
		return null;
	}

	protected override void __initializeVariables()
	{
	}

	protected override void __initializeRpcs()
	{
	}

	private static void __rpc_handler_4119645272(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	private static void __rpc_handler_1734413334(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	protected internal override string __getTypeName()
	{
		return null;
	}
}
