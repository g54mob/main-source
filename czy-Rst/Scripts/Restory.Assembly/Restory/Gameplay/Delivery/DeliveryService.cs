using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.InteractiveObjects;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Visits;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Shops.Devices;
using Restory.Gameplay.Storages;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Scripts.Restory.Gameplay.Storages;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Delivery
{
	public class DeliveryService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private InteractiveObjectInfo deliveryBoxInfo;

		private readonly List<InteractiveObjectInfo> purchasedObjects = new List<InteractiveObjectInfo>();

		private readonly HeldElements purchasedElements = new HeldElements();

		private readonly List<PaintingPaletteInfo> purchasedPalettes = new List<PaintingPaletteInfo>();

		private readonly List<ElementsBoxData> purchasedElementsBoxes = new List<ElementsBoxData>();

		private readonly List<GeneratedDeviceForDelivery> generatedDevices = new List<GeneratedDeviceForDelivery>();

		private StorageSpaces storageSpaces;

		private DeliveryZoneBoxesSpawnPoints boxesSpawnPoints;

		private BoxContainersCreationService boxContainersCreationService;

		private CurrentDayVisitsQueueService currentDayVisitsService;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private ElementsAndPalettesAndInteractiveObjectsBoxContainer deliveryBox;

		public bool IsThereAnythingToDeliver
		{
			get
			{
				if (purchasedObjects.Count <= 0 && purchasedElements.AllHeldElements.Count <= 0 && purchasedPalettes.Count <= 0 && generatedDevices.Count <= 0)
				{
					return purchasedElementsBoxes.Count > 0;
				}
				return true;
			}
		}

		public ElementsAndPalettesAndInteractiveObjectsBoxContainer DeliveryBox => deliveryBox;

		public IReadOnlyCollection<InteractiveObjectInfo> PurchasedObjects => purchasedObjects;

		public event Action<DeliveryService> OnDeliveryBoxCreated;

		public event Action OnDeliveryArrived;

		[Inject]
		private void Construct(StorageSpaces storageSpaces, DeliveryZoneBoxesSpawnPoints boxesSpawnPoints, BoxContainersCreationService boxContainersCreationService, CurrentDayVisitsQueueService currentDayVisitsService, InteractiveObjectRegistry interactiveObjectRegistry)
		{
			this.boxContainersCreationService = boxContainersCreationService;
			this.boxesSpawnPoints = boxesSpawnPoints;
			this.storageSpaces = storageSpaces;
			this.currentDayVisitsService = currentDayVisitsService;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)currentDayVisitsService)
			{
				Init();
			}
		}

		private void Init()
		{
			currentDayVisitsService.OnNpcStartedLeavingStoreWindow += ResolveNpcStartedLeavingStoreWindow;
		}

		private void OnDisable()
		{
			if (currentDayVisitsService.MonoShellExists())
			{
				currentDayVisitsService.OnNpcStartedLeavingStoreWindow -= ResolveNpcStartedLeavingStoreWindow;
			}
			if ((bool)deliveryBox)
			{
				deliveryBox.InteractiveObject.OnRemove -= ResolveDeliveryBoxOnRemove;
				deliveryBox.InteractiveObject.OnDragComplete -= ResolveDeliveryBoxDragComplete;
			}
		}

		public void SendToDelivery(InteractiveObjectInfo objectInfo)
		{
			if ((bool)objectInfo)
			{
				purchasedObjects.Add(objectInfo);
				TryToEnqueueDeliveryVisit();
			}
		}

		public void SendToDelivery(ElementData elementData, int amount = 1)
		{
			if (elementData != null && amount > 0)
			{
				purchasedElements.AddElement(elementData, amount);
				TryToEnqueueDeliveryVisit();
			}
		}

		public bool ContainsInPurchasedObjectsOrDeliveryBox(InteractiveObjectInfo objectInfo)
		{
			if (purchasedObjects.Contains(objectInfo))
			{
				return true;
			}
			if ((bool)deliveryBox)
			{
				foreach (ContainedInteractiveObject item in deliveryBox.Content)
				{
					if (item.InteractiveObjectInfo == objectInfo)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool ContainsInPurchasedObjectsOrDeliveryBox(PaintingPaletteInfo palette)
		{
			if (purchasedPalettes.Contains(palette))
			{
				return true;
			}
			if ((bool)deliveryBox)
			{
				foreach (PaintingPaletteInfo containedPaintingPalette in deliveryBox.ContainedPaintingPalettes)
				{
					if (containedPaintingPalette.ID == palette.ID)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void SendToDelivery(RandomlyGeneratedDeviceCondition generatedDevice, params InteractiveObjectAdditionalProperty[] deviceAdditionalProperty)
		{
			if (generatedDevice != null)
			{
				generatedDevices.Add(new GeneratedDeviceForDelivery
				{
					GeneratedDeviceCondition = generatedDevice,
					AdditionalProperties = deviceAdditionalProperty
				});
				TryToEnqueueDeliveryVisit();
			}
		}

		public void SendToDelivery(PaintingPaletteInfo paintingPalette)
		{
			if (!paintingPalette)
			{
				return;
			}
			foreach (PaintingPaletteInfo purchasedPalette in purchasedPalettes)
			{
				if ((bool)purchasedPalette && purchasedPalette.ID == paintingPalette.ID)
				{
					return;
				}
			}
			purchasedPalettes.Add(paintingPalette);
			TryToEnqueueDeliveryVisit();
		}

		public void SendToDelivery(ElementsBoxData elementsBoxData)
		{
			if (elementsBoxData != null && !purchasedElementsBoxes.Contains(elementsBoxData))
			{
				purchasedElementsBoxes.Add(elementsBoxData);
				TryToEnqueueDeliveryVisit();
			}
		}

		public bool IsGeneratedDeviceAwaitingDelivery(RandomlyGeneratedDeviceCondition generatedDevice)
		{
			foreach (GeneratedDeviceForDelivery generatedDevice2 in generatedDevices)
			{
				if (generatedDevice2.GeneratedDeviceCondition.ID == generatedDevice.ID)
				{
					return true;
				}
			}
			return false;
		}

		public void ForcedDelivery(IEnumerable<PaintingPaletteInfo> paletts)
		{
			if ((!deliveryBox || deliveryBox.InteractiveObject.HasChanged) && !TryToReplaceDeliveryBox())
			{
				return;
			}
			foreach (PaintingPaletteInfo palett in paletts)
			{
				deliveryBox.AddPalette(palett);
			}
			this.OnDeliveryArrived?.Invoke();
		}

		public void ForcedDelivery(IEnumerable<HeldElement> elements)
		{
			if ((!deliveryBox || deliveryBox.InteractiveObject.HasChanged) && !TryToReplaceDeliveryBox())
			{
				return;
			}
			foreach (HeldElement element in elements)
			{
				deliveryBox.AddElement(element);
			}
			this.OnDeliveryArrived?.Invoke();
		}

		public void ForcedDelivery(ElementsBoxData elementsBoxData)
		{
			if (elementsBoxData != null)
			{
				deliveryBox.AddElementsBox(elementsBoxData);
				this.OnDeliveryArrived?.Invoke();
			}
		}

		private bool TryToEnqueueDeliveryVisit()
		{
			return currentDayVisitsService.TryToAddDeliveryVisitToClosestTimePossible();
		}

		private void ResolveNpcStartedLeavingStoreWindow()
		{
			if (currentDayVisitsService.VisitCurrentlyInProgress.Visit is DeliveryNpcVisit)
			{
				DeliverEverything();
			}
		}

		private void ResolveDeliveryBoxDragComplete()
		{
			if (!deliveryBox)
			{
				Debug.LogError("Reference to deliveryBox was lost");
				return;
			}
			deliveryBox.InteractiveObject.OnRemove -= ResolveDeliveryBoxOnRemove;
			deliveryBox.InteractiveObject.OnDragComplete -= ResolveDeliveryBoxDragComplete;
			interactiveObjectRegistry.Register(deliveryBox.InteractiveObject, deliveryBoxInfo);
			deliveryBox = null;
		}

		private void ResolveDeliveryBoxOnRemove()
		{
			if (!deliveryBox)
			{
				Debug.LogError("Reference to deliveryBox was lost");
				return;
			}
			deliveryBox.InteractiveObject.OnRemove -= ResolveDeliveryBoxOnRemove;
			deliveryBox.InteractiveObject.OnDragComplete -= ResolveDeliveryBoxDragComplete;
			deliveryBox = null;
		}

		private void DeliverEverything()
		{
			if (!IsThereAnythingToDeliver || ((!deliveryBox || deliveryBox.InteractiveObject.HasChanged) && !TryToReplaceDeliveryBox()))
			{
				return;
			}
			foreach (InteractiveObjectInfo purchasedObject in purchasedObjects)
			{
				deliveryBox.TryToAddObject(purchasedObject);
			}
			foreach (HeldElement allHeldElement in purchasedElements.AllHeldElements)
			{
				deliveryBox.AddElement(allHeldElement);
			}
			foreach (GeneratedDeviceForDelivery generatedDevice in generatedDevices)
			{
				deliveryBox.TryToAddObject(generatedDevice.GeneratedDeviceCondition, generatedDevice.AdditionalProperties);
			}
			foreach (PaintingPaletteInfo purchasedPalette in purchasedPalettes)
			{
				deliveryBox.AddPalette(purchasedPalette);
			}
			foreach (ElementsBoxData purchasedElementsBox in purchasedElementsBoxes)
			{
				deliveryBox.AddElementsBox(purchasedElementsBox);
			}
			purchasedObjects.Clear();
			purchasedElements.Clear();
			generatedDevices.Clear();
			purchasedPalettes.Clear();
			purchasedElementsBoxes.Clear();
			this.OnDeliveryArrived?.Invoke();
		}

		private bool TryToReplaceDeliveryBox()
		{
			deliveryBox = boxContainersCreationService.TryToCreateOrReplaceBox(deliveryBox, deliveryBoxInfo, boxesSpawnPoints.DeliveryBoxSpawnPoint, InteractiveObjectState.Delivery) as ElementsAndPalettesAndInteractiveObjectsBoxContainer;
			if ((bool)deliveryBox)
			{
				deliveryBox.InteractiveObject.OnRemove += ResolveDeliveryBoxOnRemove;
				deliveryBox.InteractiveObject.OnDragComplete += ResolveDeliveryBoxDragComplete;
				this.OnDeliveryBoxCreated?.Invoke(this);
				return true;
			}
			deliveryBox = null;
			return false;
		}

		public void RestoreState(object state)
		{
			try
			{
				DeliveryServiceSaveData deliveryServiceSaveData = DataMigrationWizard.Migrate<DeliveryServiceSaveData>(state, base.gameObject);
				purchasedObjects.Clear();
				foreach (InteractiveObjectInfo purchasedObject in deliveryServiceSaveData.PurchasedObjects)
				{
					purchasedObjects.Add(purchasedObject);
				}
				purchasedElements.Clear();
				foreach (HeldElement allHeldElement in deliveryServiceSaveData.PurchasedElements.AllHeldElements)
				{
					purchasedElements.AddElement(allHeldElement);
				}
				generatedDevices.Clear();
				foreach (GeneratedDeviceForDelivery generatedDevice in deliveryServiceSaveData.GeneratedDevices)
				{
					generatedDevices.Add(generatedDevice);
				}
				purchasedPalettes.Clear();
				purchasedPalettes.AddRange(deliveryServiceSaveData.PurchasedPalettes);
				purchasedElementsBoxes.Clear();
				purchasedElementsBoxes.AddRange(deliveryServiceSaveData.PurchasedElementsBoxes);
				deliveryBox = RestoreDeliveryBox(deliveryServiceSaveData.DeliveryBoxData) as ElementsAndPalettesAndInteractiveObjectsBoxContainer;
				if ((bool)deliveryBox)
				{
					deliveryBox.InteractiveObject.OnRemove += ResolveDeliveryBoxOnRemove;
					deliveryBox.InteractiveObject.OnDragComplete += ResolveDeliveryBoxDragComplete;
				}
				if ((deliveryServiceSaveData.DeliveryBoxContent == null || deliveryServiceSaveData.DeliveryBoxContent.Count <= 0) && (deliveryServiceSaveData.ElementsInBox == null || deliveryServiceSaveData.ElementsInBox.AllHeldElements.Count <= 0) && (deliveryServiceSaveData.PalettesInBox == null || deliveryServiceSaveData.PalettesInBox.Count <= 0))
				{
					return;
				}
				if ((!deliveryBox || deliveryBox.InteractiveObject.HasChanged) && !TryToReplaceDeliveryBox())
				{
					Debug.LogError("deliveryBox is removed, while should has content");
					return;
				}
				if (deliveryServiceSaveData.DeliveryBoxContent != null && deliveryServiceSaveData.DeliveryBoxContent.Count > 0)
				{
					deliveryBox.Init(deliveryServiceSaveData.DeliveryBoxContent);
				}
				if (deliveryServiceSaveData.ElementsInBox != null && deliveryServiceSaveData.ElementsInBox.AllHeldElements.Count > 0)
				{
					deliveryBox.SetUpElements(deliveryServiceSaveData.ElementsInBox.AllHeldElements);
				}
				List<PaintingPaletteInfo> palettesInBox = deliveryServiceSaveData.PalettesInBox;
				if (palettesInBox != null && palettesInBox.Count > 0)
				{
					deliveryBox.SetUpPalettes(deliveryServiceSaveData.PalettesInBox);
				}
				this.OnDeliveryBoxCreated?.Invoke(this);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				DeliveryServiceSaveData deliveryServiceSaveData = new DeliveryServiceSaveData
				{
					PurchasedObjects = new List<InteractiveObjectInfo>(purchasedObjects),
					PurchasedElements = purchasedElements,
					PurchasedPalettes = new List<PaintingPaletteInfo>(purchasedPalettes),
					GeneratedDevices = new List<GeneratedDeviceForDelivery>(generatedDevices),
					PurchasedElementsBoxes = new List<ElementsBoxData>(purchasedElementsBoxes)
				};
				if ((bool)deliveryBox)
				{
					deliveryServiceSaveData.DeliveryBoxContent = new List<ContainedInteractiveObject>(deliveryBox.Content);
					deliveryServiceSaveData.ElementsInBox = new HeldElements();
					foreach (HeldElement containedElement in deliveryBox.ContainedElements)
					{
						deliveryServiceSaveData.ElementsInBox.AddElement(containedElement);
					}
					deliveryServiceSaveData.PalettesInBox = new List<PaintingPaletteInfo>();
					deliveryServiceSaveData.PalettesInBox.AddRange(deliveryBox.ContainedPaintingPalettes);
					deliveryServiceSaveData.DeliveryBoxData = new InteractiveObjectData
					{
						InteractiveObjectInfo = deliveryBoxInfo,
						InteractiveObjectTransform = new SerializableTransform(deliveryBox.transform),
						State = deliveryBox.InteractiveObject.State,
						UniqueId = deliveryBox.InteractiveObject.UniqueId,
						HasChanged = deliveryBox.InteractiveObject.HasChanged
					};
				}
				return deliveryServiceSaveData;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		private InteractiveObjectBoxContainer RestoreDeliveryBox(InteractiveObjectData interactiveObjectData)
		{
			return boxContainersCreationService.RestoreBox(interactiveObjectData, boxesSpawnPoints.DeliveryBoxSpawnPoint, storageSpaces.transform);
		}
	}
}
