using Brewery.Data;
using Unity.Netcode;

namespace Brewery.Items
{
	public class BeverageItemData : NetworkBehaviour
	{
		private readonly NetworkVariable<BeerDataSnapshot> snapshot;

		public bool HasSnapshot => false;

		public BeerDataSnapshot Snapshot => default(BeerDataSnapshot);

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnSnapshotChanged(BeerDataSnapshot prev, BeerDataSnapshot current)
		{
		}

		private void ApplyVisual(BeerDataSnapshot data)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SetSnapshotServerRpc(BeerDataSnapshot value)
		{
		}

		public BeerDataSnapshot GetSnapshot()
		{
			return default(BeerDataSnapshot);
		}

		public string BuildTooltip()
		{
			return null;
		}

		public static BeerDataSnapshot CreateSnapshot(BrewingResult result)
		{
			return default(BeerDataSnapshot);
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_489783863(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
