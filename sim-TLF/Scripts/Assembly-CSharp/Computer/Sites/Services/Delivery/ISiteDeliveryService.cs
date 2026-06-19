using System.Collections.Generic;

namespace Computer.Sites.Services.Delivery
{
	public interface ISiteDeliveryService
	{
		List<DeliveryOrder> ActiveOrders { get; }

		List<DeliveryOrder> CompletedOrders { get; }

		void CreateNewOrder(DeliveryOrder order);

		void RemoveFromActiveOrders(string orderId);

		void RestoreCompletedOrder(DeliveryOrder order);
	}
}
