using System;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Gameplay.WorkOrders.EmailOrders;

namespace Restory.Gameplay.EmailSystems
{
	[Serializable]
	public class EmailLetterOrderRecord : EmailLetterRecord
	{
		public RandomlyGeneratedDeviceCondition DeviceCondition;

		public DeviceWorkType[] WorkTypes = new DeviceWorkType[0];

		public DateTime DeviceDeliveredToStoreDateTime = DateTime.MaxValue;

		public int NumberDaysToComplete = 3;

		public int Payment;
	}
}
