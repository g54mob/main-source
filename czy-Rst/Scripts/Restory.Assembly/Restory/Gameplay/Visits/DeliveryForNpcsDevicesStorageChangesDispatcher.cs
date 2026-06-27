using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Gameplay.DeviceSales;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Visits
{
	public class DeliveryForNpcsDevicesStorageChangesDispatcher : IInitializable, IDisposable
	{
		private readonly FreeSaleShippingDevicesTrackingService devicesForSaleTrackingService;

		private readonly WorkOrdersService workOrdersService;

		private readonly EmailOrdersService emailOrdersService;

		private readonly DecorShippingService decorShippingService;

		private readonly ShipmentService shipmentService;

		private readonly ICoroutineRunner coroutineRunner;

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		public DeliveryForNpcsDevicesStorageChangesDispatcher(FreeSaleShippingDevicesTrackingService devicesForSaleTrackingService, WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService, DecorShippingService decorShippingService, ShipmentService shipmentService, ICoroutineRunner coroutineRunner)
		{
			this.devicesForSaleTrackingService = devicesForSaleTrackingService;
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
			this.decorShippingService = decorShippingService;
			this.shipmentService = shipmentService;
			this.coroutineRunner = coroutineRunner;
		}

		public void Initialize()
		{
			shipmentService.OnShipmentStorageContentChanged += ResolveStorageContentsChanged;
		}

		public void Dispose()
		{
			shipmentService.OnShipmentStorageContentChanged -= ResolveStorageContentsChanged;
			if (coroutineRunner != null && doCallbackAfterEndOfFrameCoroutine != null)
			{
				coroutineRunner.Stop(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		private void ResolveStorageContentsChanged()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = coroutineRunner.Run(DoCallbackAfterEndOfFrameCoroutine(ProcessStorageChanges));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			doCallbackAfterEndOfFrameCoroutine = null;
			callback?.Invoke();
		}

		private void ProcessStorageChanges()
		{
			List<DeviceContainer> list = CollectionPool<List<DeviceContainer>, DeviceContainer>.Get();
			List<ShipmentDevicePack> list2 = CollectionPool<List<ShipmentDevicePack>, ShipmentDevicePack>.Get();
			List<DeviceContainer> list3 = CollectionPool<List<DeviceContainer>, DeviceContainer>.Get();
			List<DecorShipmentPack> list4 = CollectionPool<List<DecorShipmentPack>, DecorShipmentPack>.Get();
			foreach (IShipmentPack item3 in shipmentService.ShipmentStorageContent)
			{
				if (item3 != null)
				{
					if (!(item3 is ShipmentDevicePack shipmentDevicePack))
					{
						if (item3 is DecorShipmentPack item)
						{
							list4.Add(item);
						}
						continue;
					}
					if (workOrdersService.DoesOrderExistForDevice(shipmentDevicePack.DeviceContainer))
					{
						list.Add(shipmentDevicePack.DeviceContainer);
						continue;
					}
					ShipmentDevicePack shipmentDevicePack2 = shipmentDevicePack;
					if (emailOrdersService.DoesOrderExistForDevice(shipmentDevicePack2.DeviceContainer))
					{
						list3.Add(shipmentDevicePack2.DeviceContainer);
						continue;
					}
					ShipmentDevicePack item2 = shipmentDevicePack;
					list2.Add(item2);
				}
				else
				{
					Debug.LogError("package: is null on shipment storage processing");
				}
			}
			workOrdersService.ProcessShipmentStorageChanged(list);
			devicesForSaleTrackingService.ProcessDeliveryToNpcsStorageChanged(list2);
			emailOrdersService.ProcessShipmentStorageChanged(list3);
			decorShippingService.ProcessShipmentStorageChanged(list4);
			CollectionPool<List<DeviceContainer>, DeviceContainer>.Release(list);
			CollectionPool<List<ShipmentDevicePack>, ShipmentDevicePack>.Release(list2);
			CollectionPool<List<DeviceContainer>, DeviceContainer>.Release(list3);
			CollectionPool<List<DecorShipmentPack>, DecorShipmentPack>.Release(list4);
		}
	}
}
