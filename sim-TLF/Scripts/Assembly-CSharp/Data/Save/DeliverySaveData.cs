using System;
using System.Collections.Generic;
using Computer.Sites.Services.Delivery;

namespace Data.Save
{
	[Serializable]
	public struct DeliverySaveData
	{
		public List<DeliveryOrder> ActiveOrders;

		public List<DeliveryOrder> CompletedOrders;
	}
}
