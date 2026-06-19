using System;
using System.Collections.Generic;

namespace Computer.Sites.Services.Delivery
{
	[Serializable]
	public class DeliveryOrder
	{
		public string OrderId;

		public DateTime OrderDate;

		public bool DestinationSet;

		public bool InProgress;

		public bool Completed;

		public bool Tracked;

		public float Progress;

		public List<DeliveryItem> Items;
	}
}
