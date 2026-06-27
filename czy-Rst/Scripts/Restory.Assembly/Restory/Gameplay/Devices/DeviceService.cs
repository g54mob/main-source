using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Devices.Condition;
using Restory.Data.Devices.Quality;
using Restory.Data.Elements;
using Restory.Data.Identifications;
using Restory.Data.SaveLoad.Containers;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.GameView;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Storages;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DeviceService : MonoBehaviour, IInitializable, IDisposable
	{
		private DisassembleStateMachine disassembleStateMachine;

		private DeviceRegistry deviceRegistry;

		private DeviceFactory deviceFactory;

		private DevicePacker devicePacker;

		private LicensesService licensesService;

		private DeviceInfoDatabase deviceInfoDatabase;

		private StorageSpaces storageSpaces;

		private WorkSurface workSurface;

		private DeviceSpotLight deviceSpotLight;

		private ElementService elementService;

		private WorkOrdersService workOrdersService;

		private EmailOrdersService emailOrdersService;

		private PlacedElementsHandler placedElementsHandler;

		private VfxService vfxService;

		private DeviceContainer placedDeviceContainer;

		public DeviceContainer PlacedDeviceContainer
		{
			get
			{
				return placedDeviceContainer;
			}
			private set
			{
				if ((bool)placedDeviceContainer)
				{
					placedDeviceContainer.OnQualityChanged -= ResolveDeviceQualityChanged;
					if ((bool)value)
					{
						Debug.LogError("Another device " + placedDeviceContainer.Device.Info.ID + " placed already");
					}
				}
				placedDeviceContainer = value;
				deviceSpotLight.gameObject.SetActive(placedDeviceContainer);
				this.OnPlacedDeviceChanged?.Invoke();
				if ((bool)placedDeviceContainer)
				{
					placedDeviceContainer.OnQualityChanged += ResolveDeviceQualityChanged;
				}
			}
		}

		public event Action OnPlacedDeviceChanged;

		public event Action OnPlacedDeviceQualityChanged;

		[Inject]
		public void Construct(DisassembleStateMachine disassembleStateMachine, DeviceRegistry deviceRegistry, DeviceFactory deviceFactory, DevicePacker devicePacker, LicensesService licensesService, DeviceInfoDatabase deviceInfoDatabase, StorageSpaces storageSpaces, WorkSurface workSurface, DeviceSpotLight deviceSpotLight, ElementService elementService, WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService, PlacedElementsHandler placedElementsHandler, VfxService vfxService)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.deviceRegistry = deviceRegistry;
			this.deviceFactory = deviceFactory;
			this.devicePacker = devicePacker;
			this.licensesService = licensesService;
			this.deviceInfoDatabase = deviceInfoDatabase;
			this.storageSpaces = storageSpaces;
			this.workSurface = workSurface;
			this.deviceSpotLight = deviceSpotLight;
			this.elementService = elementService;
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
			this.placedElementsHandler = placedElementsHandler;
			this.vfxService = vfxService;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			deviceSpotLight.gameObject.SetActive(PlacedDeviceContainer);
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			deviceRegistry = null;
			deviceFactory = null;
			devicePacker = null;
		}

		public DeviceData CreateDeviceData(IDeviceCondition deviceCondition, Transform deviceTransform, params InteractiveObjectAdditionalProperty[] additionalDeviceProperties)
		{
			IDeviceCondition deviceCondition2;
			if (!(deviceCondition is DeviceCondition original))
			{
				deviceCondition2 = deviceCondition;
			}
			else
			{
				IDeviceCondition deviceCondition3 = UnityEngine.Object.Instantiate(original);
				deviceCondition2 = deviceCondition3;
			}
			IDeviceCondition deviceCondition4 = deviceCondition2;
			ElementData[] array = elementService.CreateElementsData(deviceCondition4);
			InteractiveObjectAdditionalProperties interactiveObjectAdditionalProperties = new InteractiveObjectAdditionalProperties(additionalDeviceProperties);
			interactiveObjectAdditionalProperties.TryToAddProperty(new InitialDeviceConditionProperty(deviceCondition));
			if (!licensesService.IsLicensed(deviceCondition.DeviceInfo))
			{
				interactiveObjectAdditionalProperties.TryToAddProperty(new PackedAsUnlicensedObjectProperty());
			}
			PlacedElementsData placedElementsData = new PlacedElementsData();
			if (deviceCondition.IsPartOfCompetition)
			{
				ElementData[] array2 = array;
				foreach (ElementData elementData in array2)
				{
					ElementTransformData item = new ElementTransformData
					{
						ElementData = elementData,
						ElementTransform = new SerializableTransform()
					};
					if (elementData.Info.Category == ElementCategory.Small)
					{
						placedElementsData.ElementsInBin.Add(item);
					}
					else
					{
						placedElementsData.ElementsOnSurface.Add(item);
					}
				}
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = null;
				}
			}
			return new DeviceData
			{
				DeviceInfo = deviceCondition.DeviceInfo,
				DeviceTransform = new SerializableTransform(deviceTransform),
				InstalledElements = array,
				PlacedElements = placedElementsData,
				PrevKnownQuality = null,
				Quality = null,
				InteractiveObjectAdditionalProperties = interactiveObjectAdditionalProperties
			};
		}

		public DeviceData CreateDeviceData(DeviceContainer device)
		{
			PlacedElementsData placedElementsData = ((device.State == InteractiveObjectState.Placed && !device.IsPacked) ? placedElementsHandler.GetPlacedElementsData() : device.CachedPlacedElements);
			if (placedElementsData == null)
			{
				Debug.LogError("placedElementsData cannot be null");
				placedElementsData = new PlacedElementsData();
			}
			DevicesStorage devicesStorage = ((device.State == InteractiveObjectState.Stored) ? device.GetComponentInParent<DevicesStorage>() : null);
			PaintableDevice component;
			Identificator component2;
			return new DeviceData
			{
				UniqueID = device.UniqueId,
				DeviceInfo = device.Device.Info,
				DeviceTransform = device.CachedTransform,
				DeviceState = device.State,
				InstalledElements = device.CachedInstalledElements,
				PlacedElements = placedElementsData,
				PaintTextureId = (device.Device.TryGetComponent<PaintableDevice>(out component) ? component.PaintTextureId : 0),
				PrevKnownQuality = device.PrevKnownQuality,
				Quality = device.Quality,
				InteractiveObjectAdditionalProperties = (device.AdditionalProperties.Clone() as InteractiveObjectAdditionalProperties),
				StorageID = (((bool)devicesStorage && devicesStorage.TryGetComponent<Identificator>(out component2)) ? component2.ID : string.Empty)
			};
		}

		public DeviceData CreateEmptyDeviceData(string deviceNameKey)
		{
			DeviceInfo deviceInfo = null;
			foreach (IDeviceInfo device in deviceInfoDatabase.Devices)
			{
				if (!(device.NameLocalizationKey != deviceNameKey))
				{
					deviceInfo = device as DeviceInfo;
					break;
				}
			}
			if (!deviceInfo)
			{
				Debug.LogError("Failed to find device " + deviceNameKey + " in deviceInfoDatabase");
				return null;
			}
			return new DeviceData
			{
				DeviceInfo = deviceInfo,
				DeviceTransform = new SerializableTransform(),
				InstalledElements = new ElementData[deviceInfo.Sockets.Count],
				PlacedElements = new PlacedElementsData(),
				InteractiveObjectAdditionalProperties = new InteractiveObjectAdditionalProperties()
			};
		}

		public DeviceContainer CreateStoredDeviceContainer(DeviceData deviceData, Transform deviceContainerParent = null)
		{
			DeviceContainer deviceContainer = deviceFactory.CreateDeviceContainer(deviceData, deviceContainerParent ? deviceContainerParent : storageSpaces.transform);
			deviceRegistry.Register(deviceContainer);
			deviceContainer.SetStoragePoint();
			deviceContainer.SetState(InteractiveObjectState.Stored);
			if (deviceContainer.Device.CheckIntegrity() && deviceData.PlacedElements.IsEmpty)
			{
				return deviceContainer;
			}
			if (deviceData.InteractiveObjectAdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition)
			{
				CompetitionDevicePack competitionDevicePack = devicePacker.PackStoredCompetitionDeviceContainer(deviceContainer, deviceData.PlacedElements);
				competitionDevicePack.IsInteractable = true;
				deviceContainer.CoupleSmallElements(competitionDevicePack.PlacedElements);
				deviceContainer.CachePlacedElements(competitionDevicePack.PlacedElements);
			}
			else
			{
				DismantledDevicePack dismantledDevicePack = devicePacker.PackStoredDismantledDeviceContainer(deviceContainer, deviceData.PlacedElements);
				dismantledDevicePack.IsInteractable = true;
				deviceContainer.CoupleSmallElements(dismantledDevicePack.PlacedElements);
				deviceContainer.CachePlacedElements(dismantledDevicePack.PlacedElements);
			}
			deviceContainer.gameObject.SetActive(value: false);
			return deviceContainer;
		}

		public CompetitionDevicePack CreateInitialCompetitionPackedDeviceContainer(DeviceData deviceData, Transform spawnPoint)
		{
			DeviceContainer deviceContainer = deviceFactory.CreateDeviceContainer(deviceData, spawnPoint);
			placedElementsHandler.SetPerfectConditionToAllPlacedElements(deviceData.PlacedElements);
			CompetitionDevicePack competitionDevicePack = devicePacker.PackStoredCompetitionDeviceContainer(deviceContainer, deviceData.PlacedElements);
			competitionDevicePack.IsInteractable = true;
			deviceContainer.CoupleSmallElements(competitionDevicePack.PlacedElements);
			deviceContainer.CachePlacedElements(competitionDevicePack.PlacedElements);
			deviceContainer.gameObject.SetActive(value: false);
			return competitionDevicePack;
		}

		public DeviceContainer CreateEmptyDeviceContainer(string deviceNameKey)
		{
			DeviceData deviceData = CreateEmptyDeviceData(deviceNameKey);
			PlacedElements placedElements = placedElementsHandler.CreateAndPlaceSmallElements(deviceData);
			DeviceContainer deviceContainer = deviceFactory.CreateDeviceContainer(deviceData, workSurface.DeviceSpawnPoint);
			deviceContainer.CoupleSmallElements(placedElements);
			deviceContainer.CachePlacedElements(placedElements);
			deviceRegistry.Register(deviceContainer);
			PlaceDeviceContainer(deviceContainer);
			return deviceContainer;
		}

		public void PlaceNewDeviceContainer(DeviceData deviceData)
		{
			DeviceContainer deviceContainer = deviceFactory.CreateDeviceContainer(deviceData, workSurface.DeviceSpawnPoint);
			deviceRegistry.Register(deviceContainer);
			PlaceDeviceContainer(deviceContainer);
			if (!deviceData.PlacedElements.IsEmpty)
			{
				PlacedElements placedElements = placedElementsHandler.CreatePlacedElements(deviceData.PlacedElements);
				deviceContainer.CoupleSmallElements(placedElements);
				deviceContainer.CachePlacedElements(placedElements);
			}
			if (!deviceContainer.Device.HasAnyInstalledElement() && (!deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) || !foundProperty.DeviceCondition.IsPartOfCompetition))
			{
				devicePacker.PackPlacedDismantledDeviceContainer(PlacedDeviceContainer);
				deviceContainer.gameObject.SetActive(value: false);
			}
		}

		public void PlaceDeviceContainer(DeviceContainer deviceContainer)
		{
			PlacedDeviceContainer = deviceContainer;
			PlacedDeviceContainer.transform.position = workSurface.DeviceSpawnPoint.position;
			PlacedDeviceContainer.transform.parent = workSurface.transform;
			PlacedDeviceContainer.SetState(InteractiveObjectState.Placed);
		}

		public void PlaceDeviceContainer(DevicePack devicePack)
		{
			DeviceContainer deviceContainer = devicePack.DeviceContainer;
			if (deviceContainer.Device.HasAnyInstalledElement() || (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition))
			{
				devicePacker.UnpackDeviceContainer(devicePack);
				deviceContainer.CompleteDrag();
				PlaceDeviceContainer(deviceContainer);
			}
			else
			{
				PlacedDeviceContainer = deviceContainer;
				devicePack.CompleteDrag();
				devicePack.transform.position = workSurface.DeviceSpawnPoint.position;
				devicePack.transform.parent = workSurface.transform;
				devicePack.SetState(InteractiveObjectState.Placed);
			}
		}

		public DeviceContainer UnpackDevice(DevicePack devicePack)
		{
			return devicePacker.UnpackDeviceContainer(devicePack);
		}

		public InteractiveObject GrabPlacedDeviceContainer()
		{
			if (!PlacedDeviceContainer)
			{
				Debug.LogError("PlacedDeviceContainer was lost");
				return null;
			}
			DeviceContainer deviceContainer = PlacedDeviceContainer;
			PlacedDeviceContainer = null;
			if (deviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out var component))
			{
				return component;
			}
			if (IsPlacedDeviceShouldBePacked(deviceContainer))
			{
				if (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition)
				{
					CompetitionDevicePack result = devicePacker.PackPlacedCompetitionDeviceContainer(deviceContainer);
					deviceContainer.gameObject.SetActive(value: false);
					return result;
				}
				DismantledDevicePack result2 = devicePacker.PackPlacedDismantledDeviceContainer(deviceContainer);
				deviceContainer.gameObject.SetActive(value: false);
				return result2;
			}
			deviceContainer.CachedPlacedElements.ElementsOnSurface.Clear();
			deviceContainer.CachedPlacedElements.ElementsInBin.Clear();
			return deviceContainer;
		}

		public bool IsPlacedDeviceShouldBePacked(DeviceContainer deviceContainer)
		{
			if (deviceContainer.Device.CheckAssembleStatus() == Device.AssembleStatus.Assembled)
			{
				return workSurface.PlacedElements.Count > 0;
			}
			return true;
		}

		public bool TryToGetPackedDeviceForShipment(DeviceContainer deviceContainer, out ShipmentDevicePack devicePack)
		{
			devicePack = null;
			if (CheckDeviceReadyForShipment(deviceContainer) == CheckDeviceReadyForShipmentResult.Success)
			{
				devicePack = devicePacker.PackStoredDeviceContainerForDelivery(deviceContainer);
				return true;
			}
			return false;
		}

		public CheckDeviceReadyForShipmentResult CheckDeviceReadyForShipment(DeviceContainer deviceContainer)
		{
			if (workOrdersService.TryToGetWorkOrderForDeviceContainer(deviceContainer, out var workOrder) && !workOrdersService.IsAllWorkTypesCompleted(workOrder))
			{
				return CheckDeviceReadyForShipmentResult.Fail_NotAllDeviceWorkTypesCompleted;
			}
			if (emailOrdersService.TryToGetOrderForDeviceContainer(deviceContainer, out var trackedOrder) && !emailOrdersService.IsAllWorkTypesCompleted(trackedOrder))
			{
				return CheckDeviceReadyForShipmentResult.Fail_NotAllDeviceWorkTypesCompleted;
			}
			if (deviceContainer.Quality is UnknownDeviceQuality)
			{
				return CheckDeviceReadyForShipmentResult.Fail_DeviceQualityUnknown;
			}
			if (!(deviceContainer.Quality is IdealDeviceQuality))
			{
				return CheckDeviceReadyForShipmentResult.Fail_DeviceFromOrderIsNotOfIdealQuality;
			}
			if (workOrdersService.IsAnotherDeviceFromSameWorkOrderAlreadyPackedForShipment(deviceContainer))
			{
				return CheckDeviceReadyForShipmentResult.Fail_DeviceIsPartOfAWorkOrderWithAnotherDeviceAlreadyInShipment;
			}
			if (deviceContainer.AdditionalProperties.ContainsProperty<NonSellableInteractiveObjectProperty>())
			{
				return CheckDeviceReadyForShipmentResult.Fail_DeviceIsUniqueAndNotForSale;
			}
			return CheckDeviceReadyForShipmentResult.Success;
		}

		public bool IsUniqueDeviceRegistered(DeviceCondition deviceCondition)
		{
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.AdditionalProperties.TryToGetProperty<NonSellableInteractiveObjectProperty>(out var foundProperty) && foundProperty.SourceInteractiveObjectInfo.ID == deviceCondition.ID)
				{
					return true;
				}
			}
			return false;
		}

		public void TurnNonSellableDeviceIntoRegularDevice(DeviceCondition deviceCondition)
		{
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.AdditionalProperties.TryToGetProperty<NonSellableInteractiveObjectProperty>(out var foundProperty) && foundProperty.SourceInteractiveObjectInfo.ID == deviceCondition.ID)
				{
					item.AdditionalProperties.RemoveProperty(foundProperty);
					break;
				}
			}
		}

		public void DestroyDeviceContainer()
		{
			if ((bool)PlacedDeviceContainer)
			{
				workSurface.ClearElements();
				deviceRegistry.Unregister(PlacedDeviceContainer);
				deviceFactory.DestroyDeviceContainer(PlacedDeviceContainer);
				PlacedDeviceContainer = null;
			}
		}

		public void DestroyDeviceContainer(DeviceContainer deviceContainer)
		{
			if (deviceContainer == PlacedDeviceContainer)
			{
				DestroyDeviceContainer();
				return;
			}
			DevicesStorage componentInParent = deviceContainer.GetComponentInParent<DevicesStorage>();
			if ((bool)componentInParent)
			{
				componentInParent.RemoveDeviceFromStorage(deviceContainer);
			}
			deviceRegistry.Unregister(deviceContainer);
			deviceFactory.DestroyDeviceContainer(deviceContainer);
		}

		public void DestroyDeviceContainerIfEmpty(DeviceContainer deviceContainer)
		{
			if (deviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out var component) && !deviceContainer.Device.HasAnyInstalledElement() && deviceContainer.CachedPlacedElements.ElementsOnSurface.Count <= 0)
			{
				vfxService.PlayDestroyEffect(component.transform);
				DestroyPackedDeviceContainer(component);
			}
		}

		public void DestroyRegisteredNonSellableDeviceContainer(DeviceCondition deviceCondition)
		{
			foreach (DeviceContainer item in deviceRegistry.All)
			{
				if (item.AdditionalProperties.TryToGetProperty<NonSellableInteractiveObjectProperty>(out var foundProperty) && foundProperty.SourceInteractiveObjectInfo.ID == deviceCondition.ID)
				{
					DestroyDeviceContainer(item);
					break;
				}
			}
		}

		public void DestroyPackedDeviceContainer(DevicePack devicePack)
		{
			DevicesStorage componentInParent = devicePack.GetComponentInParent<DevicesStorage>();
			if ((bool)componentInParent)
			{
				componentInParent.RemoveDeviceFromStorage(devicePack);
			}
			deviceRegistry.Unregister(devicePack.DeviceContainer);
			deviceFactory.DestroyPackedDeviceContainer(devicePack);
		}

		public bool IsPlacedDeviceCompletelyDisassembled()
		{
			if (!PlacedDeviceContainer)
			{
				Debug.LogError("PlacedDeviceContainer was lost");
				return false;
			}
			if (PlacedDeviceContainer.HasCustomer || PlacedDeviceContainer.Device.HasAnyInstalledElement())
			{
				return false;
			}
			foreach (ElementBase placedElement in workSurface.PlacedElements)
			{
				if (placedElement.Info.Category != ElementCategory.Small)
				{
					return false;
				}
			}
			return true;
		}

		public List<ElementSocket> GetAvailableSockets(ElementBase targetElement)
		{
			List<ElementSocket> list = new List<ElementSocket>();
			if (!targetElement)
			{
				Debug.LogError("targetElement was lost");
				return list;
			}
			if (!targetElement.Info)
			{
				Debug.LogError("Info not attached to element " + targetElement.name);
				return list;
			}
			if (!PlacedDeviceContainer || !PlacedDeviceContainer.Device)
			{
				Debug.LogError("Device was lost");
				return list;
			}
			foreach (ElementSocket elementSocket in PlacedDeviceContainer.Device.ElementSockets)
			{
				if (elementSocket.CompatibleElementInfo == targetElement.Info && elementSocket.IsAvailable)
				{
					list.Add(elementSocket);
				}
			}
			return list;
		}

		private void ResolveDisassembleStateChanged()
		{
			if (!PlacedDeviceContainer)
			{
				return;
			}
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is TransitionToCleaningDisassembleState || activeState is DisabledDisassembleState || activeState is CheckDeviceDisassembleState || activeState is PaintingDisassembleState)
			{
				PlacedDeviceContainer.Device.Deactivate(disassembleStateMachine.ActiveState is CheckDeviceDisassembleState);
				workSurface.DeactivatePlacedElements();
				if (disassembleStateMachine.ActiveState is DisabledDisassembleState && !PlacedDeviceContainer.Device.HasAnyInstalledElement() && (!placedDeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) || !foundProperty.DeviceCondition.IsPartOfCompetition))
				{
					DismantledDevicePack dismantledDevicePack = devicePacker.PackPlacedDismantledDeviceContainer(PlacedDeviceContainer);
					PlacedDeviceContainer.CachePlacedElements(dismantledDevicePack.PlacedElements);
					dismantledDevicePack.CompleteDrag();
				}
			}
			else if (disassembleStateMachine.ActiveState is DetectionDisassembleState && !PlacedDeviceContainer.Device.IsActivated)
			{
				PlacedDeviceContainer.Device.Activate();
				workSurface.ActivatePlacedElements();
			}
		}

		private void ResolveDeviceQualityChanged()
		{
			if (!PlacedDeviceContainer)
			{
				Debug.LogError("PlacedDeviceContainer was lost");
			}
			else
			{
				this.OnPlacedDeviceQualityChanged?.Invoke();
			}
		}
	}
}
