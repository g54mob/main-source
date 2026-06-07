using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class DisplayedLootItem : NetworkBehaviour
	{
		[Header("Display State")]
		[SerializeField]
		private int stolenItemIndex;

		[Header("References (Set at runtime)")]
		[SerializeField]
		private CampLootDisplay ownerDisplay;

		[SerializeField]
		private LootDisplayPoint displayPoint;

		private ItemPickup disabledPickup;

		private Rigidbody itemRigidbody;

		private bool hasSettled;

		private float settleTimer;

		private const float SETTLE_TIME = 2f;

		public int StolenItemIndex => 0;

		public CampLootDisplay OwnerDisplay => null;

		public LootDisplayPoint DisplayPoint => null;

		public bool HasSettled => false;

		public void Initialize(int itemIndex, CampLootDisplay owner, LootDisplayPoint point)
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void SettleItem()
		{
		}

		public void SetDisplayPoint(LootDisplayPoint point)
		{
		}

		public void OnRemovedFromDisplay()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnDrawGizmos()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
