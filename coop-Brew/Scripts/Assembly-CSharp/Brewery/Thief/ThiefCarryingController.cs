using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class ThiefCarryingController : NetworkBehaviour
	{
		[Header("Duffle Bag")]
		[Tooltip("Reference to the duffle bag GameObject (pre-assigned child of thief)")]
		[SerializeField]
		private GameObject duffleBag;

		[Header("Animation")]
		[Tooltip("Duration of show/hide animation")]
		[SerializeField]
		private float animationDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> hasLoot;

		private StealerBrain stealerBrain;

		public bool HasLoot => false;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void SetHasLoot(bool value)
		{
		}

		public void ShowLoot()
		{
		}

		public void HideLoot()
		{
		}

		private void HandleItemStolen(string itemId, int quantity)
		{
		}

		private void HandleLootCleared()
		{
		}

		private void OnHasLootChanged(bool previous, bool current)
		{
		}

		private void UpdateDuffleBagVisibility(bool visible, bool animate)
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
