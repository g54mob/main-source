using System;
using ScheduleOne.GameTime;

namespace ScheduleOne.Cartel
{
	[Serializable]
	public class CartelDealInfo
	{
		public enum EStatus
		{
			Pending = 0,
			Overdue = 1
		}

		public string RequestedProductID;

		public int RequestedProductQuantity;

		public int PaymentAmount;

		public GameDateTime DueTime;

		public EStatus Status;

		public CartelDealInfo(string requestedProductID, int requestedProductQuantity, int payment, GameDateTime dueTime, EStatus status)
		{
		}

		public CartelDealInfo()
		{
		}

		public bool IsValid()
		{
			return false;
		}
	}
}
