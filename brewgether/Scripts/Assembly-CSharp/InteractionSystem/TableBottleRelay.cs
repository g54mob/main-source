using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	public class TableBottleRelay : NetworkBehaviour
	{
		private TableCleanableController[] _allTables;

		private void Start()
		{
		}

		public void RefreshTableList()
		{
		}

		public void SyncTable(TableCleanableController table)
		{
		}

		public void TriggerIKReach(ulong clientId, Transform target, float duration)
		{
		}

		[ClientRpc]
		private void SyncTableClientRpc(int tableIndex, int bottleCount, Vector3[] positions)
		{
		}

		[ClientRpc]
		private void TriggerIKReachClientRpc(ulong interactingClientId, int tableIndex, float duration)
		{
		}

		private int GetTableIndex(TableCleanableController table)
		{
			return 0;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2854985752(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3632407634(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
