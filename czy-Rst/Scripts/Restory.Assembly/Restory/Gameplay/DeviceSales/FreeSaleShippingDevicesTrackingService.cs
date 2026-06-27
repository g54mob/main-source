using System;
using System.Collections.Generic;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.Devices;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.Visits;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.DeviceSales
{
	public class FreeSaleShippingDevicesTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent, IShipmentClaimingVisitRequester
	{
		private CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private CashMoneyService cashMoneyService;

		private DeviceService deviceService;

		private GameStatisticsService gameStatistics;

		private DeviceRegistry deviceRegistry;

		private ShipmentService shipmentService;

		private readonly List<ShipmentDevicePack> trackedDeliveryDevicePacks = new List<ShipmentDevicePack>();

		private FreeSaleShippingDevicesTrackingServiceSaveData restoredState;

		public event Action<ShipmentDevicePack> OnPreDevicePackClaimedByNpc;

		[Inject]
		private void Construct(CurrentDayVisitsQueueService currentDayVisitsQueueService, CashMoneyService cashMoneyService, DeviceService deviceService, GameStatisticsService gameStatistics, DeviceRegistry deviceRegistry, ShipmentService shipmentService)
		{
			this.deviceService = deviceService;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.cashMoneyService = cashMoneyService;
			this.gameStatistics = gameStatistics;
			this.deviceRegistry = deviceRegistry;
			this.shipmentService = shipmentService;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)currentDayVisitsQueueService)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (currentDayVisitsQueueService.MonoShellExists())
			{
				currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			}
		}

		private void Init()
		{
			currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
		}

		public void ProcessDeliveryToNpcsStorageChanged(ICollection<ShipmentDevicePack> devicesInStorageReadyForDelivery)
		{
			RefreshDeliverySchedulingStatus(devicesInStorageReadyForDelivery);
		}

		private void RefreshDeliverySchedulingStatus(ICollection<ShipmentDevicePack> devicesInStorageReadyForDelivery)
		{
			UntrackPacksNotInDeliveryStorage(devicesInStorageReadyForDelivery);
			TrackNewPacksInStorage(devicesInStorageReadyForDelivery);
			RefreshFreeSaleClaimingVisit();
		}

		private void RefreshFreeSaleClaimingVisit()
		{
			if (trackedDeliveryDevicePacks.Count > 0)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
			else
			{
				currentDayVisitsQueueService.TryToRemoveFreeSaleClaimingVisits(this);
			}
		}

		private void TrackNewPacksInStorage(ICollection<ShipmentDevicePack> devicesInStorageReadyForDelivery)
		{
			foreach (ShipmentDevicePack item in devicesInStorageReadyForDelivery)
			{
				bool flag = false;
				foreach (ShipmentDevicePack trackedDeliveryDevicePack in trackedDeliveryDevicePacks)
				{
					if (trackedDeliveryDevicePack == item)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
					trackedDeliveryDevicePacks.Add(item);
				}
			}
		}

		private void UntrackPacksNotInDeliveryStorage(ICollection<ShipmentDevicePack> devicesInStorageReadyForDelivery)
		{
			for (int i = 0; i < trackedDeliveryDevicePacks.Count; i++)
			{
				ShipmentDevicePack shipmentDevicePack = trackedDeliveryDevicePacks[i];
				bool flag = false;
				foreach (ShipmentDevicePack item in devicesInStorageReadyForDelivery)
				{
					if (item == shipmentDevicePack)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					trackedDeliveryDevicePacks.RemoveAt(i);
					i--;
				}
			}
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (!(currentDayVisitsQueueService.VisitCurrentlyInProgress.Visit is FreeSaleClaimingNpcVisit) || !currentDayVisitsQueueService.VisitCurrentlyInProgress.DidInteractionHappen)
			{
				return;
			}
			foreach (ShipmentDevicePack trackedDeliveryDevicePack in trackedDeliveryDevicePacks)
			{
				this.OnPreDevicePackClaimedByNpc?.Invoke(trackedDeliveryDevicePack);
				cashMoneyService.AddMoneyFromNpcToWindowSpace(trackedDeliveryDevicePack.DevicePrice);
				gameStatistics.ProcessCompletedFreeSale(trackedDeliveryDevicePack.DevicePrice, trackedDeliveryDevicePack.DeviceContainer);
				DestroyDeviceContainer(trackedDeliveryDevicePack);
			}
			trackedDeliveryDevicePacks.Clear();
			shipmentService.UpdateShipmentStorageState();
		}

		private void DestroyDeviceContainer(ShipmentDevicePack targetDevicePack)
		{
			deviceService.DestroyPackedDeviceContainer(targetDevicePack);
		}

		public object CaptureState()
		{
			try
			{
				string[] array = new string[trackedDeliveryDevicePacks.Count];
				for (int i = 0; i < trackedDeliveryDevicePacks.Count; i++)
				{
					array[i] = trackedDeliveryDevicePacks[i].DeviceContainer.UniqueId;
				}
				return new FreeSaleShippingDevicesTrackingServiceSaveData
				{
					DeviceContainersIds = array
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<FreeSaleShippingDevicesTrackingServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			trackedDeliveryDevicePacks.Clear();
			if (restoredState == null)
			{
				return;
			}
			string[] deviceContainersIds = restoredState.DeviceContainersIds;
			foreach (string text in deviceContainersIds)
			{
				if (!TryToGetDeviceContainerById(text, out var deviceContainer))
				{
					Debug.LogError("[FreeSaleShippingDevicesTrackingService] tried to load saved data, but Device Container with ID '" + text + "', does not exist in the deices registry!");
					return;
				}
				shipmentService.RestoreDevicePackInShipmentStorage(deviceContainer);
				deviceContainer.transform.parent.TryGetComponent<ShipmentDevicePack>(out var component);
				if (!component)
				{
					Debug.LogError("[FreeSaleShippingDevicesTrackingService] tried to load saved data, but Device Container with ID '" + text + "', is not inside a DevicePack!");
					return;
				}
				trackedDeliveryDevicePacks.Add(component);
			}
			if (trackedDeliveryDevicePacks.Count > 0)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
		}

		private bool TryToGetDeviceContainerById(string ID, out DeviceContainer deviceContainer)
		{
			deviceContainer = null;
			bool result = false;
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.UniqueId == ID)
				{
					deviceContainer = item;
					result = true;
					break;
				}
			}
			return result;
		}
	}
}
