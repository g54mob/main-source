using System;
using Restory.Gameplay.Devices;
using Restory.Gameplay.EmailSystems;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	[Serializable]
	public class TrackedEmailOrder
	{
		public int ID;

		public EmailLetterOrderRecord Order;

		public DeviceContainer DeviceContainer;

		public bool IsReadyToShipAndMarkedForCourierPickUp;
	}
}
