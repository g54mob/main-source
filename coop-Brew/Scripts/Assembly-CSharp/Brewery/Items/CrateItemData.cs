using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Systems;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Items
{
	[RequireComponent(typeof(CrateDisplayController))]
	[RequireComponent(typeof(NetworkObject))]
	public class CrateItemData : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private CrateDisplayController displayController;

		private NetworkVariable<CrateMetadata> networkedMetadata;

		private CrateMetadata currentMetadata;

		private bool hasMetadata;

		private Dictionary<int, BeerDataSnapshot> storedBeverageMetadata;

		private Dictionary<int, BarrelMetadata> storedBarrelMetadata;

		public event Action<CrateMetadata> OnContentsChanged
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

		private void OnNetworkedMetadataChanged(CrateMetadata previousValue, CrateMetadata newValue)
		{
		}

		private void Start()
		{
		}

		public CrateMetadata GetMetadata()
		{
			return default(CrateMetadata);
		}

		public void ApplyMetadataImmediate(CrateMetadata metadata)
		{
		}

		private void UpdateVisuals()
		{
		}

		public void InitializeFromSave(List<(string itemId, int quantity)> contents)
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public int GetTotalItemCount()
		{
			return 0;
		}

		public void StoreCrateItemBeverageMetadata(int crateSlot, BeerDataSnapshot snapshot)
		{
		}

		[ClientRpc]
		private void SyncCrateBeverageMetadataClientRpc(int crateSlot, BeerDataSnapshot snapshot)
		{
		}

		public bool TryGetStoredBeverageMetadata(int crateSlot, out BeerDataSnapshot snapshot)
		{
			snapshot = default(BeerDataSnapshot);
			return false;
		}

		public Dictionary<int, BeerDataSnapshot> GetAllStoredBeverageMetadata()
		{
			return null;
		}

		public void StoreCrateItemBarrelMetadata(int crateSlot, BarrelMetadata metadata)
		{
		}

		public bool TryGetStoredBarrelMetadata(int crateSlot, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public Dictionary<int, BarrelMetadata> GetAllStoredBarrelMetadata()
		{
			return null;
		}

		public void ClearStoredItemMetadata()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2759514857(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
