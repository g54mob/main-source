using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Devices.Condition;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.Condition;
using Restory.Data.Elements.ElementTypes;
using Restory.Data.NPCs;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.Storages;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.WorkOrders
{
	public class WorkOrdersService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[Serializable]
		private class AssignedWorkOrder
		{
			public int ID;

			public WorkOrderBase WorkOrder;
		}

		private DeviceService deviceService;

		private CashMoneyService cashMoneyService;

		private GameStatisticsService gameStatistics;

		private DeviceRegistry deviceRegistry;

		private WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider;

		private ShipmentService shipmentService;

		private DevicesFromNpcsService devicesFromNpcsService;

		private CurrentDayVisitsQueueService currentDayVisitsQueueTracker;

		private GameCalendar gameCalendar;

		private AvailableDevicesWorkTypesTrackingService workTypesService;

		private ElementDirtMaskPresetSelectionService dirtMaskService;

		private MaskPresetInfoBase defaultDirtMaskPreset;

		private readonly List<AssignedWorkOrder> orders = new List<AssignedWorkOrder>();

		private int nextOrderID;

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		private WorkOrdersServiceSaveData restoredState;

		public event Action<WorkOrdersService, WorkOrderBase> OnOrderAdded;

		public event Action<WorkOrdersService, WorkOrderBase> OnOrderCompleted;

		public event Action<WorkOrdersService, WorkOrderBase> OnOrderRestored;

		public event Action<WorkOrderBase> OnOrderShipped;

		[Inject]
		public void Construct(DeviceService deviceService, CurrentDayVisitsQueueService currentDayVisitsQueueTracker, GameCalendar gameCalendar, CashMoneyService cashMoneyService, GameStatisticsService gameStatistics, DeviceRegistry deviceRegistry, WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider, ShipmentService shipmentService, DevicesFromNpcsService devicesFromNpcsService, AvailableDevicesWorkTypesTrackingService workTypesService, ElementDirtMaskPresetSelectionService dirtMaskService, [Inject(Id = "DefaultMaskPreset")] MaskPresetInfoBase defaultDirtMaskPreset)
		{
			this.dirtMaskService = dirtMaskService;
			this.deviceService = deviceService;
			this.currentDayVisitsQueueTracker = currentDayVisitsQueueTracker;
			this.gameCalendar = gameCalendar;
			this.cashMoneyService = cashMoneyService;
			this.gameStatistics = gameStatistics;
			this.deviceRegistry = deviceRegistry;
			this.workOrdersPricesTableProvider = workOrdersPricesTableProvider;
			this.shipmentService = shipmentService;
			this.devicesFromNpcsService = devicesFromNpcsService;
			this.workTypesService = workTypesService;
			this.defaultDirtMaskPreset = defaultDirtMaskPreset;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (currentDayVisitsQueueTracker.MonoShellExists())
			{
				currentDayVisitsQueueTracker.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			}
			if (deviceRegistry != null)
			{
				deviceRegistry.OnDeviceRegistered -= ResolveDeviceRegistered;
			}
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		private void Init()
		{
			currentDayVisitsQueueTracker.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
			deviceRegistry.OnDeviceRegistered += ResolveDeviceRegistered;
		}

		public void ProcessShipmentStorageChanged(ICollection<DeviceContainer> allRelevantDevicesInStorage)
		{
			CheckAllOrdersCompletion(allRelevantDevicesInStorage);
		}

		private void CheckAllOrdersCompletion(ICollection<DeviceContainer> allDevicesToCheck)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				bool flag = false;
				WorkOrderBase workOrder = order.WorkOrder;
				if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
				{
					if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
					{
						throw new NotImplementedException();
					}
					if (cleanAndRepairAnyOfTheDevicesWorkOrder.Devices == null || cleanAndRepairAnyOfTheDevicesWorkOrder.Devices.Count == 0)
					{
						continue;
					}
					bool flag2 = false;
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device == null || !device.DeviceContainer)
						{
							continue;
						}
						foreach (DeviceContainer item in allDevicesToCheck)
						{
							if (!(item == device.DeviceContainer))
							{
								continue;
							}
							flag = true;
							if (DeviceWorkTypeExtensions.IsAllWorkTypesCompleted(device.DeviceContainer, device.WorkTypes))
							{
								if (order.WorkOrder.IsOrderClaimingVisitAlreadyScheduled)
								{
									flag2 = true;
									break;
								}
								currentDayVisitsQueueTracker.AddOrderClaimingVisitToClosestTimePossible(order.WorkOrder.NpcToClaimCompletedOrder, order.ID, order.WorkOrder.OrderClaimingNpcTextureID);
								cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment = device.DeviceContainer;
							}
							else
							{
								currentDayVisitsQueueTracker.RemoveVisitWithAttachedWorkOrder(order.ID);
								cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment = null;
							}
							break;
						}
						if (flag2)
						{
							break;
						}
					}
				}
				else
				{
					if (cleanAndRepairSingleDeviceWorkOrder.Device == null || !cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer)
					{
						continue;
					}
					foreach (DeviceContainer item2 in allDevicesToCheck)
					{
						if (item2 == cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer)
						{
							flag = true;
							if (!DeviceWorkTypeExtensions.IsAllWorkTypesCompleted(cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer, cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes))
							{
								currentDayVisitsQueueTracker.RemoveVisitWithAttachedWorkOrder(order.ID);
								cleanAndRepairSingleDeviceWorkOrder.SetOrderClaimingVisitStatus(isVisitScheduled: false);
								break;
							}
							if (!order.WorkOrder.IsOrderClaimingVisitAlreadyScheduled)
							{
								currentDayVisitsQueueTracker.AddOrderClaimingVisitToClosestTimePossible(order.WorkOrder.NpcToClaimCompletedOrder, order.ID, order.WorkOrder.OrderClaimingNpcTextureID);
								cleanAndRepairSingleDeviceWorkOrder.SetOrderClaimingVisitStatus(isVisitScheduled: true);
								break;
							}
						}
					}
				}
				if (flag || !order.WorkOrder.IsOrderClaimingVisitAlreadyScheduled)
				{
					continue;
				}
				currentDayVisitsQueueTracker.RemoveVisitWithAttachedWorkOrder(order.ID);
				workOrder = order.WorkOrder;
				if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder2))
				{
					if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder2))
					{
						throw new NotImplementedException();
					}
					cleanAndRepairAnyOfTheDevicesWorkOrder2.DevicePackedForShipment = null;
				}
				else
				{
					cleanAndRepairSingleDeviceWorkOrder2.SetOrderClaimingVisitStatus(isVisitScheduled: false);
				}
			}
		}

		public void AddCleanAndRepairSingleDeviceOrder(DeviceCondition deviceCondition, INpcInfo npcCustomer, INpcInfo npcToClaimCompletedOrder, string rewardID, string claimingNpcTextureID = "", params DeviceWorkType[] additionalWorkTypes)
		{
			int num = nextOrderID;
			DeviceContainer deviceContainer = devicesFromNpcsService.AddInteractiveObject(deviceCondition) as DeviceContainer;
			DeviceInWorkOrder deviceInWorkOrder = new DeviceInWorkOrder();
			List<DeviceWorkType> value;
			using (CollectionPool<List<DeviceWorkType>, DeviceWorkType>.Get(out value))
			{
				DeviceWorkType[] workTypesArrayFromInitialDeviceCondition = GetWorkTypesArrayFromInitialDeviceCondition(deviceContainer);
				value.AddRange(workTypesArrayFromInitialDeviceCondition);
				foreach (DeviceWorkType deviceWorkType in additionalWorkTypes)
				{
					if (deviceWorkType == null)
					{
						return;
					}
					value.Add(deviceWorkType);
				}
				deviceInWorkOrder.DeviceContainer = deviceContainer;
				deviceInWorkOrder.WorkTypes = value.ToArray();
			}
			if ((bool)deviceContainer)
			{
				PartOfWorkOrderInteractiveObjectProperty propertyToAdd = new PartOfWorkOrderInteractiveObjectProperty(num, deviceInWorkOrder.WorkTypes);
				deviceContainer.AdditionalProperties.TryToAddProperty(propertyToAdd);
			}
			CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder = new CleanAndRepairSingleDeviceWorkOrder
			{
				Device = deviceInWorkOrder,
				AssignedDateTime = gameCalendar.CurrentDateTime,
				NpcOriginalCustomer = npcCustomer,
				NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
				OrderClaimingNpcTextureID = claimingNpcTextureID,
				RewardID = rewardID
			};
			orders.Add(new AssignedWorkOrder
			{
				ID = num,
				WorkOrder = cleanAndRepairSingleDeviceWorkOrder
			});
			gameStatistics.ProcessAssignedWorkOrder(num);
			SetNewNextOrderID();
			this.OnOrderAdded?.Invoke(this, cleanAndRepairSingleDeviceWorkOrder);
		}

		public void AddCleanAndRepairAnyDeviceOrder(ICollection<DeviceCondition> deviceConditions, INpcInfo npcCustomer, INpcInfo npcToClaimCompletedOrder, string rewardID, string claimingNpcTextureID = "")
		{
			int num = nextOrderID;
			List<DeviceInWorkOrder> list = new List<DeviceInWorkOrder>();
			foreach (DeviceCondition deviceCondition in deviceConditions)
			{
				DeviceContainer deviceContainer = devicesFromNpcsService.AddInteractiveObject(deviceCondition) as DeviceContainer;
				DeviceInWorkOrder deviceInWorkOrder = new DeviceInWorkOrder
				{
					DeviceContainer = deviceContainer,
					WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(deviceContainer)
				};
				if ((bool)deviceContainer)
				{
					PartOfWorkOrderInteractiveObjectProperty propertyToAdd = new PartOfWorkOrderInteractiveObjectProperty(num, deviceInWorkOrder.WorkTypes);
					deviceContainer.AdditionalProperties.TryToAddProperty(propertyToAdd);
				}
				list.Add(deviceInWorkOrder);
			}
			CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder = new CleanAndRepairAnyOfTheDevicesWorkOrder
			{
				Devices = list,
				AssignedDateTime = gameCalendar.CurrentDateTime,
				NpcOriginalCustomer = npcCustomer,
				NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
				OrderClaimingNpcTextureID = claimingNpcTextureID,
				RewardID = rewardID
			};
			orders.Add(new AssignedWorkOrder
			{
				ID = num,
				WorkOrder = cleanAndRepairAnyOfTheDevicesWorkOrder
			});
			gameStatistics.ProcessAssignedWorkOrder(num);
			SetNewNextOrderID();
			this.OnOrderAdded?.Invoke(this, cleanAndRepairAnyOfTheDevicesWorkOrder);
		}

		public void AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(ICollection<DeviceCondition> deviceConditionsToSpawn, ICollection<DeviceCondition> deviceConditionsToTrack, INpcInfo npcCustomer, INpcInfo npcToClaimCompletedOrder, string rewardID, string claimingNpcTextureID = "")
		{
			int num = nextOrderID;
			List<DeviceInWorkOrder> list = new List<DeviceInWorkOrder>();
			foreach (DeviceCondition item in deviceConditionsToSpawn)
			{
				DeviceContainer deviceContainer = devicesFromNpcsService.AddInteractiveObject(item) as DeviceContainer;
				DeviceInWorkOrder deviceInWorkOrder = new DeviceInWorkOrder
				{
					DeviceContainer = deviceContainer,
					WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(deviceContainer)
				};
				if ((bool)deviceContainer)
				{
					PartOfWorkOrderInteractiveObjectProperty propertyToAdd = new PartOfWorkOrderInteractiveObjectProperty(num, deviceInWorkOrder.WorkTypes);
					deviceContainer.AdditionalProperties.TryToAddProperty(propertyToAdd);
				}
				list.Add(deviceInWorkOrder);
			}
			foreach (DeviceContainer item2 in deviceRegistry.All)
			{
				if (item2.AdditionalProperties.ContainsProperty<PartOfWorkOrderInteractiveObjectProperty>() || IsDeviceInDevicesInWorkOrderList(list, item2))
				{
					continue;
				}
				foreach (DeviceCondition item3 in deviceConditionsToTrack)
				{
					if (item2.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && item3.ID == foundProperty.DeviceCondition.ID)
					{
						DeviceInWorkOrder deviceInWorkOrder2 = new DeviceInWorkOrder
						{
							DeviceContainer = item2,
							WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(item2)
						};
						item2.AdditionalProperties.TryToAddProperty(new PartOfWorkOrderInteractiveObjectProperty(num, deviceInWorkOrder2.WorkTypes));
						list.Add(deviceInWorkOrder2);
					}
				}
			}
			CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder = new CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder
			{
				Devices = list,
				DeviceConditions = deviceConditionsToTrack.ToList(),
				AssignedDateTime = gameCalendar.CurrentDateTime,
				NpcOriginalCustomer = npcCustomer,
				NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
				OrderClaimingNpcTextureID = claimingNpcTextureID,
				RewardID = rewardID
			};
			orders.Add(new AssignedWorkOrder
			{
				ID = num,
				WorkOrder = cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder
			});
			gameStatistics.ProcessAssignedWorkOrder(num);
			SetNewNextOrderID();
			this.OnOrderAdded?.Invoke(this, cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder);
		}

		private DeviceWorkType[] GetWorkTypesArrayFromInitialDeviceCondition(DeviceContainer deviceContainer)
		{
			if (!deviceContainer || !deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty))
			{
				return Array.Empty<DeviceWorkType>();
			}
			List<DeviceWorkType> value;
			using (CollectionPool<List<DeviceWorkType>, DeviceWorkType>.Get(out value))
			{
				foreach (ElementData item in foundProperty.DeviceCondition.GetElementsCondition())
				{
					ElementConditionBase condition = item.Condition;
					if (!(condition is DirtyElementCondition))
					{
						if (condition is DamagedElementCondition)
						{
							AddRepairWorkTypeToListIfNotAlreadyAdded(value);
						}
					}
					else
					{
						MaskPresetInfoBase dirtMaskPreset = (item.DirtMaskPresetOverride ? item.DirtMaskPresetOverride : (foundProperty.DeviceCondition.DirtMaskGenerationPreset ? foundProperty.DeviceCondition.DirtMaskGenerationPreset : defaultDirtMaskPreset));
						AddCleanWorkTypesIfNotAlreadyAdded(dirtMaskPreset, value);
					}
				}
				return value.ToArray();
			}
		}

		private void AddCleanWorkTypesIfNotAlreadyAdded(MaskPresetInfoBase dirtMaskPreset, List<DeviceWorkType> workTypes)
		{
			IReadOnlyCollection<DirtType> dirtTypesInMaskPreset = dirtMaskService.GetDirtTypesInMaskPreset(dirtMaskPreset);
			foreach (DeviceWorkType allDeviceWorkType in workTypesService.AllDeviceWorkTypes)
			{
				if (!(allDeviceWorkType is DeviceWorkTypeClean deviceWorkTypeClean) || workTypes.Contains(allDeviceWorkType))
				{
					continue;
				}
				foreach (DirtType item in dirtTypesInMaskPreset)
				{
					if (item == deviceWorkTypeClean.DirtType)
					{
						workTypes.Add(allDeviceWorkType);
						break;
					}
				}
			}
		}

		private bool IsDeviceInDevicesInWorkOrderList(List<DeviceInWorkOrder> devices, DeviceContainer deviceContainer)
		{
			foreach (DeviceInWorkOrder device in devices)
			{
				if (device.DeviceContainer == deviceContainer)
				{
					return true;
				}
			}
			return false;
		}

		public void CancelDeviceOrder(int workOrderID)
		{
			for (int num = orders.Count - 1; num >= 0; num--)
			{
				AssignedWorkOrder assignedWorkOrder = orders[num];
				if (assignedWorkOrder.ID == workOrderID)
				{
					CancelOrGiveDevice(assignedWorkOrder, isCancel: true);
					CancelGiveReward(assignedWorkOrder);
					orders.RemoveAt(num);
					gameStatistics.ProcessCancelledWorkOrder(workOrderID);
					break;
				}
			}
		}

		public bool TryToGetOriginalCustomerNpcByDeviceContainer(DeviceContainer deviceContainer, out INpcInfo customerNpc)
		{
			customerNpc = null;
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.WorkOrder == null)
				{
					continue;
				}
				WorkOrderBase workOrder = order.WorkOrder;
				if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
				{
					if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
					{
						throw new NotImplementedException();
					}
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device != null && (bool)device.DeviceContainer && device.DeviceContainer == deviceContainer)
						{
							customerNpc = cleanAndRepairAnyOfTheDevicesWorkOrder.NpcOriginalCustomer;
							return true;
						}
					}
				}
				else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && (bool)cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer == deviceContainer)
				{
					customerNpc = cleanAndRepairSingleDeviceWorkOrder.NpcOriginalCustomer;
					return true;
				}
			}
			return false;
		}

		public bool TryToGetWorkOrderForDeviceContainer(DeviceContainer deviceContainer, out WorkOrderBase workOrder)
		{
			workOrder = null;
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.WorkOrder == null)
				{
					continue;
				}
				WorkOrderBase workOrder2 = order.WorkOrder;
				if (!(workOrder2 is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
				{
					if (!(workOrder2 is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
					{
						throw new NotImplementedException();
					}
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device != null && (bool)device.DeviceContainer && device.DeviceContainer == deviceContainer)
						{
							workOrder = order.WorkOrder;
							return true;
						}
					}
				}
				else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && (bool)cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer == deviceContainer)
				{
					workOrder = order.WorkOrder;
					return true;
				}
			}
			return false;
		}

		public bool IsAllWorkTypesCompleted(WorkOrderBase workOrder)
		{
			if (workOrder == null)
			{
				return false;
			}
			if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
			{
				if (workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder)
				{
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device != null && device.DeviceContainer != null && DeviceWorkTypeExtensions.IsAllWorkTypesCompleted(device.DeviceContainer, device.WorkTypes))
						{
							return true;
						}
					}
				}
			}
			else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer != null && DeviceWorkTypeExtensions.IsAllWorkTypesCompleted(cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer, cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes))
			{
				return true;
			}
			return false;
		}

		public bool TryToGetWorkOrderByID(int workOrderID, out WorkOrderBase registeredWorkOrder)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order != null && order.ID == workOrderID)
				{
					registeredWorkOrder = order.WorkOrder;
					return true;
				}
			}
			registeredWorkOrder = null;
			return false;
		}

		public bool DoesOrderExistForDevice(DeviceContainer deviceContainer)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.WorkOrder == null)
				{
					continue;
				}
				WorkOrderBase workOrder = order.WorkOrder;
				if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
				{
					if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
					{
						throw new NotImplementedException();
					}
					foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
					{
						if (device != null && (bool)device.DeviceContainer && device.DeviceContainer == deviceContainer)
						{
							return true;
						}
					}
				}
				else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && (bool)cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer == deviceContainer)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnotherDeviceFromSameWorkOrderAlreadyPackedForShipment(DeviceContainer deviceContainer)
		{
			if (!deviceContainer)
			{
				return false;
			}
			foreach (AssignedWorkOrder order in orders)
			{
				if (!(order.WorkOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
				{
					continue;
				}
				if (!cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment || cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment == deviceContainer)
				{
					return false;
				}
				foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
				{
					if (device != null && (bool)device.DeviceContainer && device.DeviceContainer == deviceContainer)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void SetNewNextOrderID()
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID >= nextOrderID)
				{
					nextOrderID = order.ID + 1;
				}
			}
		}

		private void AddRepairWorkTypeToListIfNotAlreadyAdded(List<DeviceWorkType> workTypes)
		{
			bool flag = false;
			foreach (DeviceWorkType workType in workTypes)
			{
				if (workType is DeviceWorkTypeRepair)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return;
			}
			foreach (DeviceWorkType allDeviceWorkType in workTypesService.AllDeviceWorkTypes)
			{
				if (allDeviceWorkType is DeviceWorkTypeRepair)
				{
					workTypes.Add(allDeviceWorkType);
					break;
				}
			}
		}

		private void ResolveDeviceRegistered(DeviceContainer newRegisteredDevice)
		{
			if (!newRegisteredDevice.AdditionalProperties.TryToGetProperty<PartOfWorkOrderInteractiveObjectProperty>(out var foundProperty))
			{
				if (!newRegisteredDevice.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty2))
				{
					return;
				}
				{
					foreach (AssignedWorkOrder order in orders)
					{
						if (!(order.WorkOrder is CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder))
						{
							continue;
						}
						foreach (DeviceCondition deviceCondition in cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.DeviceConditions)
						{
							if (deviceCondition.ID == foundProperty2.DeviceCondition.ID)
							{
								DeviceInWorkOrder deviceInWorkOrder = new DeviceInWorkOrder
								{
									DeviceContainer = newRegisteredDevice,
									WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(newRegisteredDevice)
								};
								cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.Devices.Add(deviceInWorkOrder);
								newRegisteredDevice.AdditionalProperties.TryToAddProperty(new PartOfWorkOrderInteractiveObjectProperty(order.ID, deviceInWorkOrder.WorkTypes));
								return;
							}
						}
					}
					return;
				}
			}
			foreach (AssignedWorkOrder order2 in orders)
			{
				if (order2.WorkOrder == null || order2.ID != foundProperty.WorkOrderID)
				{
					continue;
				}
				WorkOrderBase workOrder = order2.WorkOrder;
				if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
				{
					if (workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder)
					{
						bool flag = false;
						foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
						{
							if (device != null && (bool)device.DeviceContainer && device.DeviceContainer == newRegisteredDevice)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							cleanAndRepairAnyOfTheDevicesWorkOrder.Devices.Add(new DeviceInWorkOrder
							{
								DeviceContainer = newRegisteredDevice,
								WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(newRegisteredDevice)
							});
						}
						break;
					}
					throw new NotImplementedException();
				}
				if (cleanAndRepairSingleDeviceWorkOrder.Device == null)
				{
					cleanAndRepairSingleDeviceWorkOrder.Device = new DeviceInWorkOrder
					{
						DeviceContainer = newRegisteredDevice,
						WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(newRegisteredDevice)
					};
					break;
				}
				if (!cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer)
				{
					cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer = newRegisteredDevice;
				}
				if (cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes == null || cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes.Length == 0)
				{
					cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes = GetWorkTypesArrayFromInitialDeviceCondition(newRegisteredDevice);
				}
				break;
			}
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (!(currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit) || !currentDayVisitsQueueTracker.VisitCurrentlyInProgress.DidInteractionHappen)
			{
				return;
			}
			for (int num = orders.Count - 1; num >= 0; num--)
			{
				AssignedWorkOrder assignedWorkOrder = orders[num];
				if (assignedWorkOrder.WorkOrder != null && assignedWorkOrder.ID == workOrderClaimingNpcVisit.WorkOrderID)
				{
					if (assignedWorkOrder.WorkOrder.SkipVisit)
					{
						assignedWorkOrder.WorkOrder.SkipVisit = false;
						currentDayVisitsQueueTracker.AddImmediateOrderClaimingVisit(assignedWorkOrder.WorkOrder.NpcToClaimCompletedOrder, TimeSpan.FromMinutes(assignedWorkOrder.WorkOrder.SkipDelayBeforeVisit.TotalMinutes), assignedWorkOrder.ID, assignedWorkOrder.WorkOrder.OrderClaimingNpcTextureID);
						break;
					}
					CancelOrGiveDevice(assignedWorkOrder);
					GiveReward(assignedWorkOrder);
					gameStatistics.ProcessClaimedWorkOrder(assignedWorkOrder.ID, assignedWorkOrder.WorkOrder);
					orders.RemoveAt(num);
					this.OnOrderCompleted?.Invoke(this, assignedWorkOrder.WorkOrder);
					break;
				}
			}
		}

		public void SetSkipVisit(int workOrderID, bool skipVisit, float timeInGameMinutes)
		{
			SetSkipVisit(workOrderID, skipVisit, TimeSpan.FromMinutes(timeInGameMinutes));
		}

		public void SetSkipVisit(int workOrderID, bool skipVisit, TimeSpan delayBeforeVisit)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID == workOrderID)
				{
					order.WorkOrder.SkipVisit = skipVisit;
					order.WorkOrder.SkipDelayBeforeVisit = delayBeforeVisit;
					break;
				}
			}
		}

		public void GiveDevice(int workOrderID)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID == workOrderID)
				{
					CancelOrGiveDevice(order);
					break;
				}
			}
		}

		public void CancelGiveDevice(int workOrderID)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID == workOrderID)
				{
					CancelOrGiveDevice(order, isCancel: true);
					break;
				}
			}
		}

		private void CancelOrGiveDevice(AssignedWorkOrder order, bool isCancel = false)
		{
			if (order.WorkOrder == null || order.WorkOrder.DeviceHasBeenGiven)
			{
				return;
			}
			order.WorkOrder.DeviceHasBeenGiven = true;
			WorkOrderBase workOrder = order.WorkOrder;
			if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
			{
				if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
				{
					throw new NotImplementedException();
				}
				if ((bool)cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment)
				{
					order.WorkOrder.SavedGivenDeviceData = deviceService.CreateDeviceData(cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment);
					if (!isCancel)
					{
						DestroyDeviceContainer(cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment);
					}
					cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment = null;
				}
				foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
				{
					if (device != null && (bool)device.DeviceContainer)
					{
						device.DeviceContainer.AdditionalProperties.RemoveProperty<PartOfWorkOrderInteractiveObjectProperty>();
						deviceService.DestroyDeviceContainerIfEmpty(device.DeviceContainer);
					}
				}
				cleanAndRepairAnyOfTheDevicesWorkOrder.Devices.Clear();
				devicesFromNpcsService.TurnWorkOrderDevicesInsideDeliveryBoxIntoRegularDevices(order.ID);
			}
			else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && (bool)cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer)
			{
				order.WorkOrder.SavedGivenDeviceData = deviceService.CreateDeviceData(cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer);
				if (!isCancel)
				{
					DestroyDeviceContainer(cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer);
				}
				cleanAndRepairSingleDeviceWorkOrder.Device = null;
			}
			shipmentService.UpdateShipmentStorageState();
		}

		public void GiveReward(int workOrderID)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID == workOrderID)
				{
					GiveReward(order);
					break;
				}
			}
		}

		private void GiveReward(AssignedWorkOrder order)
		{
			if (order.WorkOrder != null && !order.WorkOrder.RewardHasBeenGiven)
			{
				order.WorkOrder.RewardHasBeenGiven = true;
				if (GetRewardMoneyAmountForOrder(order.WorkOrder, out var rewardMoneyAmount))
				{
					cashMoneyService.AddMoneyFromNpcToWindowSpace(rewardMoneyAmount);
				}
				order.WorkOrder.SavedGivenRewardMoneyAmount = rewardMoneyAmount;
				this.OnOrderShipped?.Invoke(order.WorkOrder);
			}
		}

		public void CancelGiveReward(int workOrderID)
		{
			foreach (AssignedWorkOrder order in orders)
			{
				if (order.ID == workOrderID)
				{
					CancelGiveReward(order);
					break;
				}
			}
		}

		private void CancelGiveReward(AssignedWorkOrder order)
		{
			if (order.WorkOrder != null && !order.WorkOrder.RewardHasBeenGiven)
			{
				order.WorkOrder.RewardHasBeenGiven = true;
				order.WorkOrder.SavedGivenRewardMoneyAmount = 0;
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

		private bool GetRewardMoneyAmountForOrder(WorkOrderBase workOrder, out int rewardMoneyAmount)
		{
			return workOrdersPricesTableProvider.TryGetWorkOrderPaymentAmount(workOrder.RewardID, out rewardMoneyAmount);
		}

		public object CaptureState()
		{
			try
			{
				WorkOrderSaveData[] array = new WorkOrderSaveData[orders.Count];
				for (int i = 0; i < orders.Count; i++)
				{
					AssignedWorkOrder assignedWorkOrder = orders[i];
					if (!(assignedWorkOrder.WorkOrder.NpcOriginalCustomer is StoryNpcInfo npcOriginalCustomer) || !(assignedWorkOrder.WorkOrder.NpcToClaimCompletedOrder is StoryNpcInfo npcToClaimCompletedOrder))
					{
						Debug.LogError("[WorkOrdersService] is unable to save data " + $"for work order with ID '{assignedWorkOrder.ID}', " + "because it references non-story NPCs, which is not yet supported!");
						continue;
					}
					WorkOrderBase workOrder = assignedWorkOrder.WorkOrder;
					if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
					{
						if (!(workOrder is CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder))
						{
							if (workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder)
							{
								List<DeviceInWorkOrderSaveData> list = CollectionPool<List<DeviceInWorkOrderSaveData>, DeviceInWorkOrderSaveData>.Get();
								foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
								{
									if (device != null && (bool)device.DeviceContainer)
									{
										list.Add(new DeviceInWorkOrderSaveData
										{
											DeviceContainerId = device.DeviceContainer.UniqueId,
											WorkTypes = (device.WorkTypes.Clone() as DeviceWorkType[])
										});
									}
								}
								array[i] = new CleanAndRepairAnyOfTheDevicesWorkOrderSaveData
								{
									OrderID = assignedWorkOrder.ID,
									SkipVisit = assignedWorkOrder.WorkOrder.SkipVisit,
									SkipDelayBeforeVisit = assignedWorkOrder.WorkOrder.SkipDelayBeforeVisit,
									AssignedDateTime = assignedWorkOrder.WorkOrder.AssignedDateTime,
									RewardHasBeenGiven = assignedWorkOrder.WorkOrder.RewardHasBeenGiven,
									DeviceHasBeenGiven = assignedWorkOrder.WorkOrder.DeviceHasBeenGiven,
									SavedGivenDeviceData = assignedWorkOrder.WorkOrder.SavedGivenDeviceData,
									SavedGivenRewardMoneyAmount = assignedWorkOrder.WorkOrder.SavedGivenRewardMoneyAmount,
									Devices = list.ToArray(),
									NpcOriginalCustomer = npcOriginalCustomer,
									NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
									ClaimingNpcTextureID = assignedWorkOrder.WorkOrder.OrderClaimingNpcTextureID,
									RewardID = assignedWorkOrder.WorkOrder.RewardID,
									ShippingDeviceContainerID = (cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment.MonoShellExists() ? cleanAndRepairAnyOfTheDevicesWorkOrder.DevicePackedForShipment.UniqueId : string.Empty)
								};
								CollectionPool<List<DeviceInWorkOrderSaveData>, DeviceInWorkOrderSaveData>.Release(list);
								continue;
							}
							throw new NotImplementedException();
						}
						List<DeviceInWorkOrderSaveData> list2 = CollectionPool<List<DeviceInWorkOrderSaveData>, DeviceInWorkOrderSaveData>.Get();
						foreach (DeviceInWorkOrder device2 in cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.Devices)
						{
							if (device2 != null && (bool)device2.DeviceContainer)
							{
								list2.Add(new DeviceInWorkOrderSaveData
								{
									DeviceContainerId = device2.DeviceContainer.UniqueId,
									WorkTypes = (device2.WorkTypes.Clone() as DeviceWorkType[])
								});
							}
						}
						List<DeviceCondition> list3 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
						list3.AddRange(cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.DeviceConditions);
						array[i] = new CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData
						{
							OrderID = assignedWorkOrder.ID,
							SkipVisit = assignedWorkOrder.WorkOrder.SkipVisit,
							SkipDelayBeforeVisit = assignedWorkOrder.WorkOrder.SkipDelayBeforeVisit,
							AssignedDateTime = assignedWorkOrder.WorkOrder.AssignedDateTime,
							RewardHasBeenGiven = assignedWorkOrder.WorkOrder.RewardHasBeenGiven,
							DeviceHasBeenGiven = assignedWorkOrder.WorkOrder.DeviceHasBeenGiven,
							SavedGivenDeviceData = assignedWorkOrder.WorkOrder.SavedGivenDeviceData,
							SavedGivenRewardMoneyAmount = assignedWorkOrder.WorkOrder.SavedGivenRewardMoneyAmount,
							Devices = list2.ToArray(),
							DeviceConditions = list3.ToArray(),
							NpcOriginalCustomer = npcOriginalCustomer,
							NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
							ClaimingNpcTextureID = assignedWorkOrder.WorkOrder.OrderClaimingNpcTextureID,
							RewardID = assignedWorkOrder.WorkOrder.RewardID,
							ShippingDeviceContainerID = (cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.DevicePackedForShipment.MonoShellExists() ? cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.DevicePackedForShipment.UniqueId : string.Empty)
						};
						CollectionPool<List<DeviceInWorkOrderSaveData>, DeviceInWorkOrderSaveData>.Release(list2);
						CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list3);
					}
					else
					{
						array[i] = new CleanAndRepairSingleDeviceWorkOrderSaveData
						{
							OrderID = assignedWorkOrder.ID,
							SkipVisit = assignedWorkOrder.WorkOrder.SkipVisit,
							SkipDelayBeforeVisit = assignedWorkOrder.WorkOrder.SkipDelayBeforeVisit,
							AssignedDateTime = assignedWorkOrder.WorkOrder.AssignedDateTime,
							RewardHasBeenGiven = assignedWorkOrder.WorkOrder.RewardHasBeenGiven,
							DeviceHasBeenGiven = assignedWorkOrder.WorkOrder.DeviceHasBeenGiven,
							SavedGivenDeviceData = assignedWorkOrder.WorkOrder.SavedGivenDeviceData,
							SavedGivenRewardMoneyAmount = assignedWorkOrder.WorkOrder.SavedGivenRewardMoneyAmount,
							Device = ((cleanAndRepairSingleDeviceWorkOrder.Device != null && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer.MonoShellExists()) ? new DeviceInWorkOrderSaveData
							{
								DeviceContainerId = cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer.UniqueId,
								WorkTypes = (cleanAndRepairSingleDeviceWorkOrder.Device.WorkTypes.Clone() as DeviceWorkType[])
							} : null),
							NpcOriginalCustomer = npcOriginalCustomer,
							NpcToClaimCompletedOrder = npcToClaimCompletedOrder,
							ClaimingNpcTextureID = assignedWorkOrder.WorkOrder.OrderClaimingNpcTextureID,
							IsOrderClaimingVisitAlreadyScheduled = assignedWorkOrder.WorkOrder.IsOrderClaimingVisitAlreadyScheduled,
							RewardID = assignedWorkOrder.WorkOrder.RewardID
						};
					}
				}
				return new WorkOrdersServiceSaveData
				{
					Orders = array
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
				restoredState = DataMigrationWizard.Migrate<WorkOrdersServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			orders.Clear();
			if (restoredState == null)
			{
				return;
			}
			WorkOrderSaveData[] array = restoredState.Orders;
			foreach (WorkOrderSaveData workOrderSaveData in array)
			{
				WorkOrderBase workOrderBase = null;
				if (!(workOrderSaveData is CleanAndRepairSingleDeviceWorkOrderSaveData cleanAndRepairSingleDeviceWorkOrderSaveData))
				{
					if (!(workOrderSaveData is CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData))
					{
						if (!(workOrderSaveData is CleanAndRepairAnyOfTheDevicesWorkOrderSaveData cleanAndRepairAnyOfTheDevicesWorkOrderSaveData))
						{
							throw new NotImplementedException();
						}
						List<DeviceInWorkOrder> list = new List<DeviceInWorkOrder>();
						DeviceContainer devicePackedForShipment = null;
						DeviceInWorkOrderSaveData[] devices = cleanAndRepairAnyOfTheDevicesWorkOrderSaveData.Devices;
						foreach (DeviceInWorkOrderSaveData deviceInWorkOrderSaveData in devices)
						{
							if (deviceInWorkOrderSaveData != null && TryToGetDeviceContainerById(deviceInWorkOrderSaveData.DeviceContainerId, out var deviceContainer))
							{
								DismantledDevicePack component;
								if (deviceContainer.UniqueId == cleanAndRepairAnyOfTheDevicesWorkOrderSaveData.ShippingDeviceContainerID)
								{
									shipmentService.RestoreDevicePackInShipmentStorage(deviceContainer);
									devicePackedForShipment = deviceContainer;
								}
								else if (deviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out component))
								{
									component.RestorePackLabel(OrderCategory.WorkOrder, workOrderSaveData.NpcOriginalCustomer.Icon);
								}
								list.Add(new DeviceInWorkOrder
								{
									DeviceContainer = deviceContainer,
									WorkTypes = ((deviceInWorkOrderSaveData.WorkTypes == null) ? Array.Empty<DeviceWorkType>() : (deviceInWorkOrderSaveData.WorkTypes.Clone() as DeviceWorkType[]))
								});
							}
						}
						CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder = new CleanAndRepairAnyOfTheDevicesWorkOrder
						{
							Devices = list,
							DevicePackedForShipment = devicePackedForShipment,
							AssignedDateTime = workOrderSaveData.AssignedDateTime,
							NpcOriginalCustomer = workOrderSaveData.NpcOriginalCustomer,
							NpcToClaimCompletedOrder = workOrderSaveData.NpcToClaimCompletedOrder,
							OrderClaimingNpcTextureID = workOrderSaveData.ClaimingNpcTextureID,
							RewardID = workOrderSaveData.RewardID
						};
						orders.Add(new AssignedWorkOrder
						{
							ID = workOrderSaveData.OrderID,
							WorkOrder = cleanAndRepairAnyOfTheDevicesWorkOrder
						});
						workOrderBase = cleanAndRepairAnyOfTheDevicesWorkOrder;
					}
					else
					{
						List<DeviceInWorkOrder> list2 = new List<DeviceInWorkOrder>();
						List<DeviceCondition> list3 = new List<DeviceCondition>();
						list3.AddRange(cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData.DeviceConditions);
						DeviceContainer devicePackedForShipment2 = null;
						DeviceInWorkOrderSaveData[] devices = cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData.Devices;
						foreach (DeviceInWorkOrderSaveData deviceInWorkOrderSaveData2 in devices)
						{
							if (deviceInWorkOrderSaveData2 != null && TryToGetDeviceContainerById(deviceInWorkOrderSaveData2.DeviceContainerId, out var deviceContainer2))
							{
								DismantledDevicePack component2;
								if (deviceContainer2.UniqueId == cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData.ShippingDeviceContainerID)
								{
									shipmentService.RestoreDevicePackInShipmentStorage(deviceContainer2);
									devicePackedForShipment2 = deviceContainer2;
								}
								else if (deviceContainer2.transform.parent.TryGetComponent<DismantledDevicePack>(out component2))
								{
									component2.RestorePackLabel(OrderCategory.WorkOrder, workOrderSaveData.NpcOriginalCustomer.Icon);
								}
								list2.Add(new DeviceInWorkOrder
								{
									DeviceContainer = deviceContainer2,
									WorkTypes = ((deviceInWorkOrderSaveData2.WorkTypes == null) ? Array.Empty<DeviceWorkType>() : (deviceInWorkOrderSaveData2.WorkTypes.Clone() as DeviceWorkType[]))
								});
							}
						}
						CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder = new CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder
						{
							Devices = list2,
							DeviceConditions = list3,
							DevicePackedForShipment = devicePackedForShipment2,
							AssignedDateTime = workOrderSaveData.AssignedDateTime,
							NpcOriginalCustomer = workOrderSaveData.NpcOriginalCustomer,
							NpcToClaimCompletedOrder = workOrderSaveData.NpcToClaimCompletedOrder,
							OrderClaimingNpcTextureID = workOrderSaveData.ClaimingNpcTextureID,
							RewardID = workOrderSaveData.RewardID
						};
						orders.Add(new AssignedWorkOrder
						{
							ID = workOrderSaveData.OrderID,
							WorkOrder = cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder
						});
						workOrderBase = cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder;
					}
				}
				else
				{
					DeviceInWorkOrder deviceInWorkOrder = null;
					if (cleanAndRepairSingleDeviceWorkOrderSaveData.Device != null)
					{
						deviceInWorkOrder = new DeviceInWorkOrder();
						if (TryToGetDeviceContainerById(cleanAndRepairSingleDeviceWorkOrderSaveData.Device.DeviceContainerId, out var deviceContainer3))
						{
							deviceInWorkOrder.DeviceContainer = deviceContainer3;
							DismantledDevicePack component3;
							if (cleanAndRepairSingleDeviceWorkOrderSaveData.IsOrderClaimingVisitAlreadyScheduled)
							{
								shipmentService.RestoreDevicePackInShipmentStorage(deviceContainer3);
							}
							else if (deviceContainer3.transform.parent.TryGetComponent<DismantledDevicePack>(out component3))
							{
								component3.RestorePackLabel(OrderCategory.WorkOrder, workOrderSaveData.NpcOriginalCustomer.Icon);
							}
						}
						if (cleanAndRepairSingleDeviceWorkOrderSaveData.Device.WorkTypes != null)
						{
							deviceInWorkOrder.WorkTypes = cleanAndRepairSingleDeviceWorkOrderSaveData.Device.WorkTypes.Clone() as DeviceWorkType[];
						}
					}
					CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder = new CleanAndRepairSingleDeviceWorkOrder
					{
						Device = deviceInWorkOrder,
						AssignedDateTime = workOrderSaveData.AssignedDateTime,
						NpcOriginalCustomer = workOrderSaveData.NpcOriginalCustomer,
						NpcToClaimCompletedOrder = workOrderSaveData.NpcToClaimCompletedOrder,
						OrderClaimingNpcTextureID = workOrderSaveData.ClaimingNpcTextureID,
						RewardID = workOrderSaveData.RewardID
					};
					cleanAndRepairSingleDeviceWorkOrder.SetOrderClaimingVisitStatus(cleanAndRepairSingleDeviceWorkOrderSaveData.IsOrderClaimingVisitAlreadyScheduled);
					orders.Add(new AssignedWorkOrder
					{
						ID = workOrderSaveData.OrderID,
						WorkOrder = cleanAndRepairSingleDeviceWorkOrder
					});
					workOrderBase = cleanAndRepairSingleDeviceWorkOrder;
				}
				this.OnOrderRestored?.Invoke(this, workOrderBase);
			}
			SetNewNextOrderID();
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
