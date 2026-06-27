using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices.Condition;
using Restory.Data.InteractiveObjects;
using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Storages
{
	public class DevicesFromNpcsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[SerializeField]
		private InteractiveObjectInfo devicesBoxInfo;

		private DevicesFromNpcsSpawnPoints devicesSpawnPoints;

		private DeliveryZoneBoxesSpawnPoints boxesSpawnPoints;

		private DeviceService deviceService;

		private DeviceRegistry deviceRegistry;

		private InteractiveObjectService interactiveObjectService;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private RegularPaymentObjectService regularPaymentObjectService;

		private RegularPaymentObjectRegistry regularPaymentObjectRegistry;

		private BoxContainersCreationService boxContainersCreationService;

		private StorageSpaces storageSpaces;

		private DragObjectRegistrator dragObjectRegistrator;

		private InteractiveObjectBoxContainer devicesBoxContainer;

		private DevicesFromNpcsSpawnerSaveData restoredState;

		private InteractiveObject draggedObjectFromSpawnPoint;

		public IReadOnlyList<ContainedInteractiveObject> ObjectsInsideDeliveryBox
		{
			get
			{
				if (!devicesBoxContainer)
				{
					return Array.Empty<ContainedInteractiveObject>();
				}
				return devicesBoxContainer.Content;
			}
		}

		public event Action<InteractiveObject> OnInteractiveObjectAdded;

		public event Action<InteractiveObject> OnInteractiveObjectUnregisterFromSpawnPoint;

		[Inject]
		private void Construct(DevicesFromNpcsSpawnPoints devicesSpawnPoints, DeliveryZoneBoxesSpawnPoints boxesSpawnPoints, DeviceService deviceService, DeviceRegistry deviceRegistry, InteractiveObjectService interactiveObjectService, InteractiveObjectRegistry interactiveObjectRegistry, DragObjectRegistrator dragObjectRegistrator, RegularPaymentObjectService regularPaymentObjectService, RegularPaymentObjectRegistry regularPaymentObjectRegistry, BoxContainersCreationService boxContainersCreationService, StorageSpaces storageSpaces)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.boxContainersCreationService = boxContainersCreationService;
			this.boxesSpawnPoints = boxesSpawnPoints;
			this.devicesSpawnPoints = devicesSpawnPoints;
			this.deviceService = deviceService;
			this.deviceRegistry = deviceRegistry;
			this.interactiveObjectService = interactiveObjectService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.regularPaymentObjectService = regularPaymentObjectService;
			this.regularPaymentObjectRegistry = regularPaymentObjectRegistry;
			this.storageSpaces = storageSpaces;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if (dragObjectRegistrator != null)
			{
				Init();
			}
		}

		private void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveObjectStartedDragging;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveObjectStoppedDragging;
		}

		private void OnDisable()
		{
			if (dragObjectRegistrator != null)
			{
				dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveObjectStartedDragging;
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveObjectStoppedDragging;
			}
		}

		public InteractiveObject AddInteractiveObject(InteractiveObjectInfo interactiveObjectInfo, params InteractiveObjectAdditionalProperty[] interactiveObjectAdditionalProperties)
		{
			if (!devicesSpawnPoints.TryToGetVacantSpawnPoint(out var spawnPoint))
			{
				PutInteractiveObjectIntoTheBox(interactiveObjectInfo, interactiveObjectAdditionalProperties);
				return null;
			}
			InteractiveObject interactiveObject = CreateInteractiveObject(interactiveObjectInfo, spawnPoint, interactiveObjectAdditionalProperties);
			interactiveObject.CompleteDrag();
			devicesSpawnPoints.TryToRegisterDeviceAtSpawnPoint(interactiveObject, spawnPoint);
			this.OnInteractiveObjectAdded?.Invoke(interactiveObject);
			return interactiveObject;
		}

		private InteractiveObject CreateInteractiveObject(InteractiveObjectInfo interactiveObjectInfo, Transform deviceSpawnPoint, params InteractiveObjectAdditionalProperty[] interactiveObjectAdditionalProperties)
		{
			if (!(interactiveObjectInfo is DeviceCondition deviceCondition))
			{
				if (interactiveObjectInfo is RegularPaymentInfo regularPaymentInfo)
				{
					return regularPaymentObjectService.Create(regularPaymentInfo, deviceSpawnPoint, interactiveObjectAdditionalProperties).InteractiveObject;
				}
				return interactiveObjectService.CreateNewInteractiveObject(interactiveObjectInfo, deviceSpawnPoint);
			}
			DeviceData deviceData = deviceService.CreateDeviceData(deviceCondition, deviceSpawnPoint, interactiveObjectAdditionalProperties);
			DeviceContainer deviceContainer = deviceService.CreateStoredDeviceContainer(deviceData);
			deviceContainer.SetState(InteractiveObjectState.Delivery);
			return deviceContainer;
		}

		public bool TryToTurnNonSellableInteractiveObjectInsideDeliveryBoxIntoRegularObject(InteractiveObjectInfo objectInfo)
		{
			if (!devicesBoxContainer)
			{
				return false;
			}
			foreach (ContainedInteractiveObject item in devicesBoxContainer.Content)
			{
				if (item?.InteractiveObjectInfo != null && !(item.InteractiveObjectInfo.ID != objectInfo.ID) && item.Properties.ContainsProperty<NonSellableInteractiveObjectProperty>())
				{
					item.Properties.RemoveProperty<NonSellableInteractiveObjectProperty>();
					return true;
				}
			}
			return false;
		}

		public void TurnWorkOrderDevicesInsideDeliveryBoxIntoRegularDevices(int workOrderID)
		{
			if (!devicesBoxContainer)
			{
				return;
			}
			foreach (ContainedInteractiveObject item in devicesBoxContainer.Content)
			{
				if (item != null && item.Properties.TryToGetProperty<PartOfWorkOrderInteractiveObjectProperty>(out var foundProperty) && foundProperty.WorkOrderID == workOrderID)
				{
					item.Properties.RemoveProperty(foundProperty);
				}
			}
		}

		public bool TryToRemoveInteractiveObjectFromDeliveryBox(InteractiveObjectInfo objectInfo)
		{
			ContainedInteractiveObject objectFromContainer;
			return devicesBoxContainer.TryToFindAndSilentlyRemoveContainedObject(objectInfo, out objectFromContainer);
		}

		public bool IsInteractiveObjectInsideDeliveryBox(InteractiveObjectInfo deviceCondition)
		{
			foreach (ContainedInteractiveObject item in devicesBoxContainer.Content)
			{
				if (item != null && item.InteractiveObjectInfo != null && item.InteractiveObjectInfo.ID == deviceCondition.ID)
				{
					return true;
				}
			}
			return false;
		}

		private void PutInteractiveObjectIntoTheBox(InteractiveObjectInfo objectInfo, params InteractiveObjectAdditionalProperty[] interactiveObjectAdditionalProperties)
		{
			if (!devicesBoxContainer || devicesBoxContainer.InteractiveObject.HasChanged)
			{
				ReplaceBox();
			}
			devicesBoxContainer.TryToAddObject(objectInfo, interactiveObjectAdditionalProperties);
		}

		private void ReplaceBox()
		{
			devicesBoxContainer = boxContainersCreationService.TryToCreateOrReplaceBox(devicesBoxContainer, devicesBoxInfo, boxesSpawnPoints.DevicesBoxSpawnPoint, InteractiveObjectState.Delivery);
		}

		private void ResolveObjectStartedDragging()
		{
			if (devicesSpawnPoints.DevicesAtSpawnPoints.Contains(dragObjectRegistrator.DraggingObject))
			{
				draggedObjectFromSpawnPoint = dragObjectRegistrator.DraggingObject;
				draggedObjectFromSpawnPoint.OnDragComplete += ResolveDraggedObjectMovedFromSpawnPoint;
				draggedObjectFromSpawnPoint.OnRemove += ResolveDraggedObjectRemoved;
			}
		}

		private void ResolveObjectStoppedDragging()
		{
			if ((bool)draggedObjectFromSpawnPoint)
			{
				draggedObjectFromSpawnPoint.OnDragComplete -= ResolveDraggedObjectMovedFromSpawnPoint;
				draggedObjectFromSpawnPoint.OnRemove -= ResolveDraggedObjectRemoved;
				draggedObjectFromSpawnPoint = null;
			}
		}

		private void ResolveDraggedObjectRemoved()
		{
			UnregisterDraggedObjectFromSpawnPoint();
		}

		private void ResolveDraggedObjectMovedFromSpawnPoint()
		{
			UnregisterDraggedObjectFromSpawnPoint();
		}

		private void UnregisterDraggedObjectFromSpawnPoint()
		{
			if (devicesSpawnPoints.UnregisterDeviceFromSpawnPoint(draggedObjectFromSpawnPoint))
			{
				this.OnInteractiveObjectUnregisterFromSpawnPoint?.Invoke(draggedObjectFromSpawnPoint);
			}
			draggedObjectFromSpawnPoint.OnDragComplete -= ResolveDraggedObjectMovedFromSpawnPoint;
			draggedObjectFromSpawnPoint.OnRemove -= ResolveDraggedObjectRemoved;
			draggedObjectFromSpawnPoint = null;
		}

		public object CaptureState()
		{
			try
			{
				DevicesFromNpcsSpawnerSaveData devicesFromNpcsSpawnerSaveData = new DevicesFromNpcsSpawnerSaveData();
				string[] array = new string[devicesSpawnPoints.DevicesAtSpawnPoints.Count];
				for (int i = 0; i < array.Length; i++)
				{
					InteractiveObject interactiveObject = devicesSpawnPoints.DevicesAtSpawnPoints[i];
					array[i] = (interactiveObject ? interactiveObject.UniqueId : string.Empty);
				}
				devicesFromNpcsSpawnerSaveData.InteractiveObjectsAtSpawnPointsIds = array;
				if ((bool)devicesBoxContainer)
				{
					devicesFromNpcsSpawnerSaveData.DevicesBoxData = new InteractiveObjectData
					{
						InteractiveObjectInfo = devicesBoxInfo,
						InteractiveObjectTransform = new SerializableTransform(devicesBoxContainer.transform),
						State = devicesBoxContainer.InteractiveObject.State,
						UniqueId = devicesBoxContainer.InteractiveObject.UniqueId,
						HasChanged = devicesBoxContainer.InteractiveObject.HasChanged
					};
					devicesFromNpcsSpawnerSaveData.ItemsInBox = devicesBoxContainer.Content.ToArray();
				}
				return devicesFromNpcsSpawnerSaveData;
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
				restoredState = DataMigrationWizard.Migrate<DevicesFromNpcsSpawnerSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState != null)
			{
				RestoreDevicesAtSpawnPoints(restoredState.InteractiveObjectsAtSpawnPointsIds);
				RestoreDevicesBox(restoredState.DevicesBoxData);
				RestoreDevicesInBox(restoredState.ItemsInBox);
			}
		}

		private void RestoreDevicesAtSpawnPoints(string[] restoredStateDevicesAtSpawnPoints)
		{
			InteractiveObject[] array = new InteractiveObject[restoredStateDevicesAtSpawnPoints.Length];
			for (int i = 0; i < restoredStateDevicesAtSpawnPoints.Length; i++)
			{
				string text = restoredState.InteractiveObjectsAtSpawnPointsIds[i];
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				foreach (DeviceContainer item in deviceRegistry.All)
				{
					if (item.UniqueId == text)
					{
						array[i] = item;
						break;
					}
				}
				foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
				{
					if (key.UniqueId == text)
					{
						array[i] = key;
						break;
					}
				}
				foreach (RegularPaymentObject item2 in regularPaymentObjectRegistry.All)
				{
					if (item2.InteractiveObject.UniqueId == text)
					{
						array[i] = item2.InteractiveObject;
						break;
					}
				}
			}
			devicesSpawnPoints.AttachRestoredDevicesToSpawnPoints(array);
		}

		private void RestoreDevicesBox(InteractiveObjectData boxData)
		{
			devicesBoxContainer = boxContainersCreationService.RestoreBox(boxData, boxesSpawnPoints.DevicesBoxSpawnPoint, storageSpaces.transform);
		}

		private void RestoreDevicesInBox(ContainedInteractiveObject[] itemsInBox)
		{
			if ((bool)devicesBoxContainer && itemsInBox != null && itemsInBox.Length != 0)
			{
				devicesBoxContainer.Init(itemsInBox);
			}
		}
	}
}
