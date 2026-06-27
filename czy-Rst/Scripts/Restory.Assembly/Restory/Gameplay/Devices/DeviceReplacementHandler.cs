using System;
using System.Collections;
using Restory.Constants;
using Restory.Data.Devices;
using Restory.Data.GameWarnings;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.InteractiveObjects;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceReplacementHandler : MonoBehaviour, IInitializable, IDisposable
	{
		private readonly float halfOfSide = 0.5f;

		private readonly RaycastHit[] raycastHits = new RaycastHit[8];

		private DragObjectRegistrator dragObjectRegistrator;

		private DeviceService deviceService;

		private StorageSpaces storages;

		private DevicePrefabProvider prefabProvider;

		private GameWarningService gameWarningService;

		private GameWarningDatabase gameWarningDatabase;

		private LayerMask placementLayerMask;

		private Coroutine searchingCoroutine;

		private StorageBase availableStorage;

		private Vector3 availableStorePosition;

		[Inject]
		private void Construct(DragObjectRegistrator dragObjectRegistrator, DeviceService deviceService, StorageSpaces storages, DevicePrefabProvider prefabProvider, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.deviceService = deviceService;
			this.storages = storages;
			this.prefabProvider = prefabProvider;
			this.gameWarningService = gameWarningService;
			this.gameWarningDatabase = gameWarningDatabase;
			placementLayerMask = ProjectConstants.Layers.InteractiveObjectsMask | ProjectConstants.Layers.ObstaclesMask;
		}

		public void Initialize()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
		}

		public void Dispose()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			StopSearching();
		}

		public bool TryToReplaceDevice()
		{
			if (!availableStorage)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.NotEnoughSpaceInStore);
				return false;
			}
			StopSearching();
			InteractiveObject interactiveObject = deviceService.GrabPlacedDeviceContainer();
			interactiveObject.transform.position = availableStorePosition;
			interactiveObject.transform.rotation = availableStorage.RefinedRotation;
			interactiveObject.transform.SetParent(availableStorage.transform);
			interactiveObject.SetState(InteractiveObjectState.Stored);
			if (interactiveObject is DeviceContainer deviceContainer)
			{
				deviceContainer.SetStoragePoint();
			}
			interactiveObject.CompleteDrag();
			return true;
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if ((bool)deviceService.PlacedDeviceContainer)
			{
				StopSearching();
				InteractiveObject draggingObject = dragObjectRegistrator.DraggingObject;
				if (draggingObject is DeviceContainer || draggingObject is DismantledDevicePack)
				{
					availableStorage = null;
					StartSearchingAvailableStorePosition(deviceService.PlacedDeviceContainer);
				}
			}
		}

		private void StartSearchingAvailableStorePosition(DeviceContainer deviceContainer)
		{
			if (deviceService.IsPlacedDeviceShouldBePacked(deviceContainer))
			{
				DismantledDevicePack prefabForPackedDismantledDevice = prefabProvider.GetPrefabForPackedDismantledDevice(deviceContainer.DevicePreset);
				searchingCoroutine = StartCoroutine(FindAvailableStorePlaceCoroutine(prefabForPackedDismantledDevice.StoreDimensions));
			}
			else
			{
				searchingCoroutine = StartCoroutine(FindAvailableStorePlaceCoroutine(deviceContainer.StoreDimensions));
			}
		}

		private IEnumerator FindAvailableStorePlaceCoroutine(InteractiveObjectStoreDimensions requiredSpace)
		{
			foreach (StorageBase item in storages.FreeStorageSpaceSearchOrder)
			{
				if (TryFindFreeSpaceInStorage(item, requiredSpace))
				{
					break;
				}
				yield return null;
			}
			searchingCoroutine = null;
		}

		private bool TryFindFreeSpaceInStorage(StorageBase storage, InteractiveObjectStoreDimensions requiredSpace)
		{
			foreach (Vector3 storageGridPosition in storage.StorageGridPositions)
			{
				if (Physics.BoxCastNonAlloc(storageGridPosition + requiredSpace.Center, requiredSpace.Size * halfOfSide, Vector3.forward, raycastHits, requiredSpace.Rotation * storage.RefinedRotation, 0f, placementLayerMask) == 0)
				{
					availableStorePosition = storageGridPosition;
					availableStorage = storage;
					return true;
				}
			}
			return false;
		}

		private void StopSearching()
		{
			if (searchingCoroutine != null)
			{
				StopCoroutine(searchingCoroutine);
				searchingCoroutine = null;
			}
		}
	}
}
