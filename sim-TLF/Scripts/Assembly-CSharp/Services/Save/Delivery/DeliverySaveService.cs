using System.Collections.Generic;
using Computer.Sites.Services.Delivery;
using Cysharp.Threading.Tasks;
using Data.Save;
using Zenject;

namespace Services.Save.Delivery
{
	public class DeliverySaveService : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private readonly ISiteDeliveryService _deliveryService;

		public string SaveKey => "DeliveryService";

		public int Priority => 15;

		public DeliverySaveService(ISaveService saveService, ISiteDeliveryService deliveryService)
		{
			_saveService = saveService;
			_deliveryService = deliveryService;
			_saveService.Register(this);
		}

		public void OnSave()
		{
			_saveService.Write(SaveKey, new DeliverySaveData
			{
				ActiveOrders = new List<DeliveryOrder>(_deliveryService.ActiveOrders),
				CompletedOrders = new List<DeliveryOrder>(_deliveryService.CompletedOrders)
			});
		}

		public async UniTask OnLoad()
		{
			if (!_saveService.TryRead<DeliverySaveData>(SaveKey, out var data))
			{
				return;
			}
			foreach (DeliveryOrder item in data.ActiveOrders ?? new List<DeliveryOrder>())
			{
				_deliveryService.ActiveOrders.Clear();
				_deliveryService.CreateNewOrder(item);
			}
			foreach (DeliveryOrder item2 in data.CompletedOrders ?? new List<DeliveryOrder>())
			{
				_deliveryService.CompletedOrders.Clear();
				_deliveryService.RestoreCompletedOrder(item2);
			}
			await UniTask.CompletedTask;
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
