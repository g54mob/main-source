using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveDesk : GroundFurniture
	{
		[Header("Workshop")]
		[SerializeField]
		private ReserveDeskWorkshop m_workshop;

		public ReserveDeskWorkshop Workshop => m_workshop;
	}
}
