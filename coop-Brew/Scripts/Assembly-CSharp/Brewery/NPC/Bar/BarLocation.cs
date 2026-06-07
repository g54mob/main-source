using InventorySystem;
using UnityEngine;

namespace Brewery.NPC.Bar
{
	[DisallowMultipleComponent]
	public class BarLocation : MonoBehaviour
	{
		[SerializeField]
		private string barId;

		[SerializeField]
		private BarInventoryManager barInventory;

		[SerializeField]
		private Transform entrancePoint;

		[SerializeField]
		private Transform servicePoint;

		[SerializeField]
		private Transform[] hangoutSpots;

		[SerializeField]
		private Transform[] parkingSpots;

		[SerializeField]
		private NPCTravelMode supportedModes;

		[SerializeField]
		private float minHangoutSeconds;

		[SerializeField]
		private float maxHangoutSeconds;

		private bool[] hangoutOccupied;

		private bool[] parkingOccupied;

		public string BarId => null;

		public BarInventoryManager Inventory => null;

		public Transform EntrancePoint => null;

		public Transform ServicePoint => null;

		public NPCTravelMode SupportedModes => default(NPCTravelMode);

		public float MinHangoutSeconds => 0f;

		public float MaxHangoutSeconds => 0f;

		private void Awake()
		{
		}

		public bool TryReserveHangout(out Transform spot, out int index)
		{
			spot = null;
			index = default(int);
			return false;
		}

		public void ReleaseHangout(int index)
		{
		}

		public bool TryReserveParking(out Transform spot, out int index)
		{
			spot = null;
			index = default(int);
			return false;
		}

		public void ReleaseParking(int index)
		{
		}
	}
}
