using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandStateManager : NetworkBehaviour
	{
		private static StandStateManager _instance;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> _isStandOpen;

		public static StandStateManager Instance => null;

		public bool IsStandOpen => false;

		public event Action<bool> OnStandOpenChanged
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

		[ServerRpc(RequireOwnership = false)]
		public void ToggleStandOpenServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void SetStandOpen(bool open)
		{
		}

		private void HandleStandOpenChanged(bool previousValue, bool newValue)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2422559465(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
