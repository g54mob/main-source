using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	public class HandshakeCoordinator : NetworkBehaviour
	{
		[SerializeField]
		private bool showDebugLogs;

		private InteractionReachIK reachIK;

		private void Awake()
		{
		}

		public void RequestHandshake(NetworkObject targetPlayer)
		{
		}

		[ServerRpc]
		private void RequestHandshakeServerRpc(ulong targetNetworkObjectId)
		{
		}

		[ClientRpc]
		private void TriggerHandshakeClientRpc(ulong player1NetworkId, ulong player2NetworkId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3800331608(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1463159983(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
