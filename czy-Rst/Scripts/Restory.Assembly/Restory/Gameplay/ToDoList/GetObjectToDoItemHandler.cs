using Restory.Data.Devices;
using Restory.Data.Devices.Condition;
using Restory.Data.Equipment;
using Restory.Data.InteractiveObjects;
using Restory.Data.ToDoList;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public class GetObjectToDoItemHandler : ToDoItemHandler
	{
		private GetObjectToDoItem getObjectToDoItem;

		private DeviceRegistry deviceRegistry;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private AvailableToolsTrackingService availableToolsTrackingService;

		[Inject]
		private void Construct(InteractiveObjectRegistry interactiveObjectRegistry, DeviceRegistry deviceRegistry, AvailableToolsTrackingService availableToolsTrackingService)
		{
			this.availableToolsTrackingService = availableToolsTrackingService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.deviceRegistry = deviceRegistry;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			if (!(item is GetObjectToDoItem getObjectToDoItem))
			{
				Debug.LogError("[GetObjectToDoItemHandler] tried to initialize, but the supplied item is not [GetObjectToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.getObjectToDoItem = getObjectToDoItem;
			base.Initialize(item, toDoListService);
			interactiveObjectRegistry.OnInteractiveObjectRegistered += ResolveInteractiveObjectRegistered;
			deviceRegistry.OnDeviceRegistered += ResolveDeviceRegistered;
			availableToolsTrackingService.OnToolsListChanged += ResolveAvailableToolsListChanged;
		}

		public override void Dispose()
		{
			base.Dispose();
			interactiveObjectRegistry.OnInteractiveObjectRegistered -= ResolveInteractiveObjectRegistered;
			deviceRegistry.OnDeviceRegistered -= ResolveDeviceRegistered;
			availableToolsTrackingService.OnToolsListChanged -= ResolveAvailableToolsListChanged;
		}

		public override void ForceCheckCompletionConditions()
		{
			base.ForceCheckCompletionConditions();
			if (TryToFindTargetObjectInScene())
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}

		private bool TryToFindTargetObjectInScene()
		{
			if (getObjectToDoItem.ObjectInfoToTrack is ToolInfo toolToCheck)
			{
				return availableToolsTrackingService.IsToolAvailable(toolToCheck);
			}
			if (getObjectToDoItem.ObjectInfoToTrack is DeviceCondition deviceCondition)
			{
				foreach (DeviceContainer item in deviceRegistry.All)
				{
					if ((bool)item && item.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.ID == deviceCondition.ID)
					{
						return true;
					}
				}
			}
			if (getObjectToDoItem.ObjectInfoToTrack is InteractiveObjectInfo interactiveObjectInfo)
			{
				foreach (InteractiveObjectInfo value in interactiveObjectRegistry.All.Values)
				{
					if ((bool)value && value.ID == interactiveObjectInfo.ID)
					{
						return true;
					}
				}
			}
			if (getObjectToDoItem.ObjectInfoToTrack is DeviceInfo deviceInfo)
			{
				foreach (DeviceContainer item2 in deviceRegistry.All)
				{
					if ((bool)item2 && item2.Device.Info.ID == deviceInfo.ID)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void ResolveInteractiveObjectRegistered(InteractiveObject newInteractiveObject)
		{
			if (interactiveObjectRegistry.All.TryGetValue(newInteractiveObject, out var value) && getObjectToDoItem.ObjectInfoToTrack.ID == value.ID)
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}

		private void ResolveDeviceRegistered(DeviceContainer newDeviceContainer)
		{
			InitialDeviceConditionProperty foundProperty;
			if (getObjectToDoItem.ObjectInfoToTrack is DeviceInfo deviceInfo)
			{
				if (newDeviceContainer.Device.Info.ID == deviceInfo.ID)
				{
					base.ToDoListService.CompleteItem(base.Item);
				}
			}
			else if (getObjectToDoItem.ObjectInfoToTrack is DeviceCondition deviceCondition && newDeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out foundProperty) && foundProperty.DeviceCondition.ID == deviceCondition.ID)
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}

		private void ResolveAvailableToolsListChanged()
		{
			if (getObjectToDoItem.ObjectInfoToTrack is ToolInfo toolToCheck && availableToolsTrackingService.IsToolAvailable(toolToCheck))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
