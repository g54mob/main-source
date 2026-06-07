using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	[RequireComponent(typeof(NetworkObject))]
	public class ItemDeliveryService : NetworkBehaviour
	{
		public static ItemDeliveryService Instance { get; private set; }

		public event Action<ulong, string, string> OnDeliverySucceeded
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

		public event Action<ulong, string, string, string> OnDeliveryFailed
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

		[Rpc(SendTo.Server)]
		public void RequestDeliveryRpc(string npcId, string questId, RpcParams rpcParams = default(RpcParams))
		{
		}

		private void SendSuccess(ulong clientId, string npcId, string questId)
		{
		}

		private void SendFailure(ulong clientId, string npcId, string questId, string reason)
		{
		}

		private void SendDeliverySuccess(ulong clientId, string npcId, string questId, string progressMessage, bool stepComplete)
		{
		}

		[ClientRpc]
		private void DeliverySuccessClientRpc(string npcId, string questId, string progressMessage, bool stepComplete, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void DeliveryResultClientRpc(bool success, string message, string npcId, string questId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_54570178(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_180280469(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1127986524(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
