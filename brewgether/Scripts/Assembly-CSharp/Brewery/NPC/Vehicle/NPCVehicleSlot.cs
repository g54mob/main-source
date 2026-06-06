using UnityEngine;

namespace Brewery.NPC.Vehicle
{
	public class NPCVehicleSlot : MonoBehaviour
	{
		[SerializeField]
		private string assignmentId;

		[SerializeField]
		private NPCVehicleAutopilot autopilot;

		[SerializeField]
		private Transform seatTransform;

		[SerializeField]
		private Transform exitTransform;

		[SerializeField]
		private bool startOccupied;

		public string AssignmentId => null;

		public NPCVehicleAutopilot Autopilot => null;

		public Transform SeatTransform => null;

		public Transform ExitTransform => null;

		public bool IsOccupied { get; private set; }

		private void Awake()
		{
		}

		public bool TryClaim()
		{
			return false;
		}

		public void Release()
		{
		}
	}
}
