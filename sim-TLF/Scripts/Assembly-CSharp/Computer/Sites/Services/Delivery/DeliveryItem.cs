using System;

namespace Computer.Sites.Services.Delivery
{
	[Serializable]
	public class DeliveryItem
	{
		public string ItemName;

		public int Quantity;

		public string AssetReferenceID;
	}
}
