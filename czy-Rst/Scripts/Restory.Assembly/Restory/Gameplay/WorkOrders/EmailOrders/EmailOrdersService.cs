using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.Delivery;
using Restory.Gameplay.Devices;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Visits;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public class EmailOrdersService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent, IShipmentClaimingVisitRequester
	{
		private DeliveryService deliveryService;

		private ShipmentService shipmentService;

		private DeviceService deviceService;

		private DeviceRegistry deviceRegistry;

		private CurrentDayVisitsQueueService currentDayVisitsQueueService;

		private CashMoneyService cashMoneyService;

		private GameCalendar gameCalendar;

		private GameStatisticsService gameStatistics;

		private readonly List<TrackedEmailOrder> trackedOrders = new List<TrackedEmailOrder>();

		private readonly List<EmailLetterOrderRecord> lastTimeShippedOrders = new List<EmailLetterOrderRecord>();

		private int nextOrderID;

		public List<TrackedEmailOrder> TrackedOrders => trackedOrders;

		public List<EmailLetterOrderRecord> LastTimeShippedOrders => lastTimeShippedOrders;

		public event Action OnOrdersDelivered;

		public event Action OnOrdersShipped;

		public event Action<TrackedEmailOrder> OnOrderDelivered;

		public event Action<EmailLetterOrderRecord> OnOrderShipped;

		[Inject]
		private void Construct(DeliveryService deliveryService, ShipmentService shipmentService, DeviceService deviceService, DeviceRegistry deviceRegistry, CashMoneyService cashMoneyService, GameCalendar gameCalendar, CurrentDayVisitsQueueService currentDayVisitsQueueService, GameStatisticsService gameStatistics)
		{
			this.gameCalendar = gameCalendar;
			this.cashMoneyService = cashMoneyService;
			this.deliveryService = deliveryService;
			this.shipmentService = shipmentService;
			this.deviceService = deviceService;
			this.deviceRegistry = deviceRegistry;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
			this.gameStatistics = gameStatistics;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)deliveryService && (bool)currentDayVisitsQueueService)
			{
				Init();
			}
		}

		private void Init()
		{
			deliveryService.OnDeliveryArrived += ResolveDeliveryArrived;
			deviceRegistry.OnDeviceRegistered += ResolveNewDeviceRegistered;
			currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
		}

		private void OnDisable()
		{
			if (deliveryService.MonoShellExists())
			{
				deliveryService.OnDeliveryArrived -= ResolveDeliveryArrived;
			}
			if (deviceRegistry != null)
			{
				deviceRegistry.OnDeviceRegistered -= ResolveNewDeviceRegistered;
			}
			if (currentDayVisitsQueueService.MonoShellExists())
			{
				currentDayVisitsQueueService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			}
		}

		public void SendToDelivery(EmailLetterOrderRecord order)
		{
			if (order == null)
			{
				return;
			}
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder.Order == order)
				{
					return;
				}
			}
			int num = nextOrderID;
			trackedOrders.Add(new TrackedEmailOrder
			{
				ID = num,
				Order = order
			});
			gameStatistics.ProcessAssignedEmailOrder(num);
			deliveryService.SendToDelivery(order.DeviceCondition, new PartOfEmailOrderInteractiveObjectProperty(num, order.WorkTypes), new GeneratedDeviceProperty(order.DeviceCondition.ID, order.Payment));
			SetNewNextOrderID();
		}

		public bool TryToGetOrderForDeviceContainer(DeviceContainer deviceContainer, out TrackedEmailOrder trackedOrder)
		{
			trackedOrder = null;
			foreach (TrackedEmailOrder trackedOrder2 in trackedOrders)
			{
				if (trackedOrder2 != null && (bool)trackedOrder2.DeviceContainer && !(trackedOrder2.DeviceContainer != deviceContainer))
				{
					trackedOrder = trackedOrder2;
					return true;
				}
			}
			return false;
		}

		public bool DoesOrderExistForDevice(DeviceContainer deviceContainer)
		{
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder.DeviceContainer == deviceContainer)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAllWorkTypesCompleted(TrackedEmailOrder trackedOrder)
		{
			if (trackedOrder == null)
			{
				return false;
			}
			if (trackedOrder.DeviceContainer != null && DeviceWorkTypeExtensions.IsAllWorkTypesCompleted(trackedOrder.DeviceContainer, trackedOrder.Order.WorkTypes))
			{
				return true;
			}
			return false;
		}

		private void SetNewNextOrderID()
		{
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder.ID >= nextOrderID)
				{
					nextOrderID = trackedOrder.ID + 1;
				}
			}
		}

		private void ResolveDeliveryArrived()
		{
			bool flag = false;
			foreach (ContainedInteractiveObject item in deliveryService.DeliveryBox.Content)
			{
				if (!(item.InteractiveObjectInfo is RandomlyGeneratedDeviceCondition randomlyGeneratedDeviceCondition))
				{
					continue;
				}
				foreach (TrackedEmailOrder trackedOrder in trackedOrders)
				{
					if (trackedOrder.Order.DeviceCondition.ID == randomlyGeneratedDeviceCondition.ID && trackedOrder.Order.DeviceDeliveredToStoreDateTime > gameCalendar.CurrentDateTime)
					{
						trackedOrder.Order.DeviceDeliveredToStoreDateTime = gameCalendar.CurrentDateTime;
						flag = true;
						this.OnOrderDelivered?.Invoke(trackedOrder);
					}
				}
			}
			if (flag)
			{
				this.OnOrdersDelivered?.Invoke();
			}
		}

		public void ProcessShipmentStorageChanged(IList<DeviceContainer> devicesInShipmentStorage)
		{
			CheckOrdersCompletion(devicesInShipmentStorage);
		}

		public bool IsOrderAwaitingDeliveryFromClient(EmailLetterOrderRecord emailOrder)
		{
			return deliveryService.IsGeneratedDeviceAwaitingDelivery(emailOrder.DeviceCondition);
		}

		public bool IsOverdueOrder(EmailLetterOrderRecord emailOrder)
		{
			return (gameCalendar.CurrentDateTime - emailOrder.DeviceDeliveredToStoreDateTime).Days + 1 > emailOrder.NumberDaysToComplete;
		}

		public bool TryToGetClientNameByDeviceContainer(DeviceContainer deviceContainer, out string clientNameLocalizationKey)
		{
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder != null && (bool)trackedOrder.DeviceContainer && trackedOrder.DeviceContainer == deviceContainer)
				{
					clientNameLocalizationKey = trackedOrder.Order.SenderContactInfo.NameLocalizationKey;
					return true;
				}
			}
			clientNameLocalizationKey = string.Empty;
			return false;
		}

		public bool TryToGetEmailAddressByDeviceContainer(DeviceContainer deviceContainer, out string emailAddress)
		{
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder != null && (bool)trackedOrder.DeviceContainer && trackedOrder.DeviceContainer == deviceContainer)
				{
					emailAddress = trackedOrder.Order.SenderContactInfo.EmailAddress;
					return true;
				}
			}
			emailAddress = string.Empty;
			return false;
		}

		private void CheckOrdersCompletion(IList<DeviceContainer> devicesInShipmentStorage)
		{
			bool flag = false;
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				bool flag2 = false;
				foreach (DeviceContainer item in devicesInShipmentStorage)
				{
					if (item == trackedOrder.DeviceContainer)
					{
						flag2 = true;
						if (!trackedOrder.IsReadyToShipAndMarkedForCourierPickUp)
						{
							trackedOrder.IsReadyToShipAndMarkedForCourierPickUp = true;
							flag = true;
						}
						break;
					}
				}
				if (!flag2)
				{
					trackedOrder.IsReadyToShipAndMarkedForCourierPickUp = false;
				}
			}
			if (flag)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
		}

		private void ResolveNewDeviceRegistered(DeviceContainer registeredDevice)
		{
			TryToAssignDeviceContainerToRelevantTrackedOrder(registeredDevice);
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (!(currentDayVisitsQueueService.VisitCurrentlyInProgress.Visit is FreeSaleClaimingNpcVisit) || !currentDayVisitsQueueService.VisitCurrentlyInProgress.DidInteractionHappen)
			{
				return;
			}
			bool flag = false;
			for (int num = trackedOrders.Count - 1; num >= 0; num--)
			{
				TrackedEmailOrder trackedEmailOrder = trackedOrders[num];
				if ((bool)trackedEmailOrder.DeviceContainer && trackedEmailOrder.IsReadyToShipAndMarkedForCourierPickUp)
				{
					if (!flag)
					{
						lastTimeShippedOrders.Clear();
					}
					cashMoneyService.AddMoneyFromNpcToWindowSpace(trackedEmailOrder.Order.Payment);
					gameStatistics.ProcessClaimedEmailOrder(trackedEmailOrder);
					DestroyDeviceContainer(trackedEmailOrder.DeviceContainer);
					trackedOrders.RemoveAt(num);
					lastTimeShippedOrders.Add(trackedEmailOrder.Order);
					this.OnOrderShipped?.Invoke(trackedEmailOrder.Order);
					flag = true;
				}
			}
			if (flag)
			{
				shipmentService.UpdateShipmentStorageState();
				this.OnOrdersShipped?.Invoke();
			}
		}

		private void DestroyDeviceContainer(DeviceContainer targetDeviceContainer)
		{
			DevicePack componentInParent = targetDeviceContainer.GetComponentInParent<DevicePack>();
			if ((bool)componentInParent)
			{
				deviceService.DestroyPackedDeviceContainer(componentInParent);
			}
			else
			{
				deviceService.DestroyDeviceContainer(targetDeviceContainer);
			}
		}

		private bool TryToAssignDeviceContainerToRelevantTrackedOrder(DeviceContainer registeredDevice)
		{
			if (!registeredDevice.AdditionalProperties.TryToGetProperty<GeneratedDeviceProperty>(out var foundProperty))
			{
				return false;
			}
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if (trackedOrder.Order.DeviceCondition.ID == foundProperty.RandomlyGeneratedDeviceConditionID)
				{
					trackedOrder.DeviceContainer = registeredDevice;
					return true;
				}
			}
			return false;
		}

		public object CaptureState()
		{
			try
			{
				return new EmailOrdersServiceSaveData
				{
					TrackedOrders = trackedOrders.ToArray()
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
				EmailOrdersServiceSaveData emailOrdersServiceSaveData = DataMigrationWizard.Migrate<EmailOrdersServiceSaveData>(state, base.gameObject);
				trackedOrders.Clear();
				trackedOrders.AddRange(emailOrdersServiceSaveData.TrackedOrders);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			bool flag = false;
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				TryToAssignDeviceContainerToRelevantTrackedOrder(item);
			}
			foreach (TrackedEmailOrder trackedOrder in trackedOrders)
			{
				if ((bool)trackedOrder.DeviceContainer)
				{
					DismantledDevicePack component;
					if (trackedOrder.IsReadyToShipAndMarkedForCourierPickUp)
					{
						shipmentService.RestoreDevicePackInShipmentStorage(trackedOrder.DeviceContainer);
						flag = true;
					}
					else if (trackedOrder.DeviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out component))
					{
						component.RestorePackLabel(OrderCategory.EmailOrder);
					}
					this.OnOrderDelivered?.Invoke(trackedOrder);
				}
			}
			if (flag)
			{
				currentDayVisitsQueueService.TryToAddFreeSaleClaimingVisitToClosestTimePossible(this);
			}
			SetNewNextOrderID();
		}
	}
}
