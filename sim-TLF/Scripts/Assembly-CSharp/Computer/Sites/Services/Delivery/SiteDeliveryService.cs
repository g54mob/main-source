using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Items.AirDrop;
using Items.AirDrop.Services;
using Items.Box;
using Items.Box.Services;
using JSAM;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Computer.Sites.Services.Delivery
{
	public class SiteDeliveryService : ISiteDeliveryService, ITickable
	{
		private List<DeliveryOrder> _activeOrders = new List<DeliveryOrder>();

		private List<DeliveryOrder> _completedOrders = new List<DeliveryOrder>();

		private AirDropSpawnPoint _airDropSpawnPoint;

		[Inject]
		private IAirDropService _airDropService;

		[Inject]
		private IItemBoxFactory _itemBoxFactory;

		List<DeliveryOrder> ISiteDeliveryService.ActiveOrders => _activeOrders;

		List<DeliveryOrder> ISiteDeliveryService.CompletedOrders => _completedOrders;

		public SiteDeliveryService()
		{
			_airDropSpawnPoint = Object.FindFirstObjectByType<AirDropSpawnPoint>();
		}

		void ISiteDeliveryService.CreateNewOrder(DeliveryOrder order)
		{
			_activeOrders.Add(order);
		}

		void ISiteDeliveryService.RemoveFromActiveOrders(string orderId)
		{
			_activeOrders.RemoveAll((DeliveryOrder o) => o.OrderId == orderId);
		}

		void ISiteDeliveryService.RestoreCompletedOrder(DeliveryOrder order)
		{
			_completedOrders.Add(order);
		}

		void ITickable.Tick()
		{
			foreach (DeliveryOrder item in _activeOrders.FindAll((DeliveryOrder o) => o.InProgress))
			{
				if (item.Completed)
				{
					((ISiteDeliveryService)this).RemoveFromActiveOrders(item.OrderId);
				}
				else if (item.DestinationSet)
				{
					item.Progress += 0.03f * Time.deltaTime;
					if (item.Progress >= 1f)
					{
						SpawnAirdropForOrder(item).Forget();
						item.Completed = true;
						item.InProgress = false;
						_completedOrders.Add(item);
						item.Progress = 1f;
					}
				}
			}
		}

		private async UniTaskVoid SpawnAirdropForOrder(DeliveryOrder order)
		{
			List<AssetReference> list = new List<AssetReference>();
			foreach (DeliveryItem item in order.Items)
			{
				for (int i = 0; i < item.Quantity; i++)
				{
					list.Add(new AssetReference(item.AssetReferenceID));
				}
			}
			ItemBoxView box = await _itemBoxFactory.CreateItemBox(new Vector3(0f, 0f, 0f), list);
			Vector3 worldPos = ((_airDropSpawnPoint != null) ? _airDropSpawnPoint.transform.position : (Vector3.zero + Vector3.up * 50f));
			AudioManager.PlaySound(AmbientLibrarySounds.AirdropFlyBy);
			_airDropService.SpawnAirDrop(box, worldPos);
		}
	}
}
