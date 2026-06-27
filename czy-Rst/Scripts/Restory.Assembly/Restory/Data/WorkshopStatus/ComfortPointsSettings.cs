using UnityEngine;

namespace Restory.Data.WorkshopStatus
{
	[CreateAssetMenu(menuName = "Restory/WorkshopStatus/ComfortPointsSettings", fileName = "ComfortPointsSettings")]
	public class ComfortPointsSettings : ScriptableObject
	{
		[SerializeField]
		[Min(0f)]
		private int pointsPerRecycle = 1;

		[SerializeField]
		[Min(0f)]
		private int pointsForUnpaidBills = -30;

		public int PointsPerRecycle => pointsPerRecycle;

		public int PointsForUnpaidBills => pointsForUnpaidBills;
	}
}
