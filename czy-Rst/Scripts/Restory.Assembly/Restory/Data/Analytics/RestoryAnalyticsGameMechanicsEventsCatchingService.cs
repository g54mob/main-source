using System;
using Restory.Data.Devices.Condition;
using Restory.Data.ToDoList;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Storages;
using Restory.Gameplay.ToDoList;
using Restory.Gameplay.WorkOrders;
using Restory.Utils;
using Zenject;

namespace Restory.Data.Analytics
{
	public class RestoryAnalyticsGameMechanicsEventsCatchingService : IInitializable, IDisposable
	{
		private RestoryAnalyticsService analyticsService;

		private ToDoListService toDoListService;

		private WorkOrdersService workOrdersService;

		private DevicesFromNpcsService devicesFromNpcsService;

		public RestoryAnalyticsGameMechanicsEventsCatchingService(RestoryAnalyticsService analyticsService, ToDoListService toDoListService, WorkOrdersService workOrdersService, DevicesFromNpcsService devicesFromNpcsService)
		{
			this.devicesFromNpcsService = devicesFromNpcsService;
			this.workOrdersService = workOrdersService;
			this.toDoListService = toDoListService;
			this.analyticsService = analyticsService;
		}

		public void Initialize()
		{
			toDoListService.OnAdded += ResolveToDoItemAdded;
			toDoListService.OnCompleted += ResolveToDoItemCompleted;
			workOrdersService.OnOrderAdded += ResolveWorkOrderAdded;
			workOrdersService.OnOrderCompleted += ResolveWorkOrderCompleted;
		}

		public void Dispose()
		{
			if (toDoListService.MonoShellExists())
			{
				toDoListService.OnAdded -= ResolveToDoItemAdded;
				toDoListService.OnCompleted -= ResolveToDoItemCompleted;
			}
			if (workOrdersService.MonoShellExists())
			{
				workOrdersService.OnOrderAdded -= ResolveWorkOrderAdded;
				workOrdersService.OnOrderCompleted -= ResolveWorkOrderCompleted;
			}
		}

		private void ResolveToDoItemAdded(ToDoListService _, ToDoItem addedItem)
		{
			analyticsService.SendCustomEvent("ToDoItemAdded", new AnalyticsParameterString
			{
				ParameterName = "toDoItemInfoID",
				ParameterValue = addedItem.ID
			});
		}

		private void ResolveToDoItemCompleted(ToDoListService _, ToDoItem completedItem)
		{
			analyticsService.SendCustomEvent("ToDoItemCompleted", new AnalyticsParameterString
			{
				ParameterName = "toDoItemInfoID",
				ParameterValue = completedItem.ID
			});
		}

		private void ResolveWorkOrderAdded(WorkOrdersService _, WorkOrderBase addedWorkOrder)
		{
			string text = string.Empty;
			InitialDeviceConditionProperty foundProperty2;
			if (!(addedWorkOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
			{
				if (!(addedWorkOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
				{
					throw new NotImplementedException();
				}
				foreach (DeviceInWorkOrder device in cleanAndRepairAnyOfTheDevicesWorkOrder.Devices)
				{
					if (device != null && (bool)device.DeviceContainer && device.DeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty))
					{
						text = foundProperty.DeviceCondition.ID;
						break;
					}
				}
			}
			else if (cleanAndRepairSingleDeviceWorkOrder.Device != null && (bool)cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer && cleanAndRepairSingleDeviceWorkOrder.Device.DeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out foundProperty2))
			{
				text = foundProperty2.DeviceCondition.ID;
			}
			if (string.IsNullOrEmpty(text))
			{
				foreach (ContainedInteractiveObject item in devicesFromNpcsService.ObjectsInsideDeliveryBox)
				{
					if (item.Properties.TryToGetProperty<PartOfWorkOrderInteractiveObjectProperty>(out var foundProperty3) && workOrdersService.TryToGetWorkOrderByID(foundProperty3.WorkOrderID, out var registeredWorkOrder) && registeredWorkOrder == addedWorkOrder && item.InteractiveObjectInfo is IDeviceCondition deviceCondition)
					{
						text = deviceCondition.ID;
					}
				}
			}
			analyticsService.SendCustomEvent("WorkOrderAdded", new AnalyticsParameterString
			{
				ParameterName = "deviceConditionID",
				ParameterValue = text
			}, new AnalyticsParameterString
			{
				ParameterName = "npcID",
				ParameterValue = addedWorkOrder.NpcOriginalCustomer.ID
			});
		}

		private void ResolveWorkOrderCompleted(WorkOrdersService _, WorkOrderBase completedWorkOrder)
		{
			string parameterValue = string.Empty;
			InitialDeviceConditionProperty foundProperty3;
			if (!(completedWorkOrder is CleanAndRepairSingleDeviceWorkOrder cleanAndRepairSingleDeviceWorkOrder))
			{
				InitialDeviceConditionProperty foundProperty2;
				if (!(completedWorkOrder is CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder))
				{
					if (!(completedWorkOrder is CleanAndRepairAnyOfTheDevicesWorkOrder cleanAndRepairAnyOfTheDevicesWorkOrder))
					{
						throw new NotImplementedException();
					}
					if (cleanAndRepairAnyOfTheDevicesWorkOrder.SavedGivenDeviceData.InteractiveObjectAdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty))
					{
						parameterValue = foundProperty.DeviceCondition.ID;
					}
				}
				else if (cleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder.SavedGivenDeviceData.InteractiveObjectAdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out foundProperty2))
				{
					parameterValue = foundProperty2.DeviceCondition.ID;
				}
			}
			else if (cleanAndRepairSingleDeviceWorkOrder.SavedGivenDeviceData.InteractiveObjectAdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out foundProperty3))
			{
				parameterValue = foundProperty3.DeviceCondition.ID;
			}
			analyticsService.SendCustomEvent("WorkOrderCompleted", new AnalyticsParameterString
			{
				ParameterName = "deviceConditionID",
				ParameterValue = parameterValue
			}, new AnalyticsParameterString
			{
				ParameterName = "npcID",
				ParameterValue = completedWorkOrder.NpcOriginalCustomer.ID
			});
		}
	}
}
