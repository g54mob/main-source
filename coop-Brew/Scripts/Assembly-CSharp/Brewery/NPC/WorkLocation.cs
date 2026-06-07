using UnityEngine;

namespace Brewery.NPC
{
	[DisallowMultipleComponent]
	public class WorkLocation : MonoBehaviour
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this work location")]
		[SerializeField]
		private string locationId;

		[Tooltip("Role required to use this work location (only NPCs with this role can work here)")]
		[SerializeField]
		private NPCRoles requiredRole;

		[Header("Anchors")]
		[Tooltip("Primary desk/work position where the NPC stands/sits")]
		[SerializeField]
		private Transform deskAnchor;

		[Tooltip("Optional waypoints for NPC to patrol/idle between (if not set, stays at desk)")]
		[SerializeField]
		private Transform[] idleWaypoints;

		[Header("Capacity")]
		[Tooltip("Maximum number of NPCs that can work at this location simultaneously")]
		[SerializeField]
		private int capacity;

		private bool[] slotsOccupied;

		private int currentOccupancy;

		public string LocationId => null;

		public NPCRoles RequiredRole => default(NPCRoles);

		public Transform DeskAnchor => null;

		public Transform[] IdleWaypoints => null;

		public int Capacity => 0;

		public int CurrentOccupancy => 0;

		public bool IsFull => false;

		private void Awake()
		{
		}

		public bool TryReserve(out int slotIndex)
		{
			slotIndex = default(int);
			return false;
		}

		public void Release(int slotIndex)
		{
		}

		private void OnValidate()
		{
		}
	}
}
