using Restory.Constants;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Tooltips;
using Restory.Scripts.Restory.Gameplay.Storages;
using Restory.UI.Presenters.RegularPayment;
using UnityEngine;

namespace Restory.Gameplay.Work.Dragging
{
	public class DragHandler
	{
		private readonly InteractiveObjectsTooltipsService interactiveObjectsTooltipsService;

		private readonly ShipmentService shipmentService;

		private readonly ShipmentPackFactory shipmentPackFactory;

		private readonly RaycastHit[] raycastHits;

		private readonly DragObjectInitialDataHolder initialDataHolder;

		private InteractiveObject selectedObject;

		private DragShipmentPack dragShipmentPack;

		public Quaternion SelectedObjectTargetRotation { get; private set; }

		public bool IsOverSurface { get; private set; }

		public bool IsOverShipment { get; private set; }

		public Transform ParentStorage { get; private set; }

		public GUI_RegularPayment GuiRegularPayment { get; private set; }

		public DragHandler(InteractiveObjectsTooltipsService interactiveObjectsTooltipsService, ShipmentService shipmentService, ShipmentPackFactory shipmentPackFactory, RaycastHit[] raycastHits, DragObjectInitialDataHolder initialDataHolder)
		{
			this.interactiveObjectsTooltipsService = interactiveObjectsTooltipsService;
			this.shipmentService = shipmentService;
			this.shipmentPackFactory = shipmentPackFactory;
			this.raycastHits = raycastHits;
			this.initialDataHolder = initialDataHolder;
		}

		public void Init(InteractiveObject selectedObject)
		{
			this.selectedObject = selectedObject;
			SelectedObjectTargetRotation = selectedObject.transform.rotation;
			IsOverSurface = false;
			switch (selectedObject.State)
			{
			case InteractiveObjectState.Stored:
				ParentStorage = selectedObject.transform.parent;
				break;
			case InteractiveObjectState.Shipment:
				ShowDragShipmentPack();
				break;
			}
		}

		public void Cleanup()
		{
			interactiveObjectsTooltipsService.HideTooltipsForTargetObject(selectedObject);
			HideDragShipmentPack();
			selectedObject = null;
			ParentStorage = null;
			GuiRegularPayment = null;
		}

		public void HandleObjectRotation(float deltaTime)
		{
			selectedObject.transform.rotation = Quaternion.RotateTowards(selectedObject.transform.rotation, SelectedObjectTargetRotation, selectedObject.RotationSpeed * deltaTime);
		}

		public void HandleUIDetectionResult(GameObject hitObject)
		{
			if (!selectedObject.TryGetComponent<CashMoneyObject>(out var _))
			{
				GuiRegularPayment = null;
				return;
			}
			GUI_RegularPayment gUI_RegularPayment = ((hitObject == null) ? null : hitObject.GetComponentInParent<GUI_RegularPayment>());
			if (!(GuiRegularPayment != gUI_RegularPayment))
			{
				return;
			}
			if (GuiRegularPayment != null)
			{
				if (gUI_RegularPayment == null)
				{
					selectedObject.gameObject.SetActive(value: true);
				}
				GuiRegularPayment.HideMoney();
			}
			GuiRegularPayment = gUI_RegularPayment;
			if (GuiRegularPayment != null)
			{
				selectedObject.gameObject.SetActive(value: false);
				GuiRegularPayment.ShowMoney();
			}
		}

		public void HandleDetectionResult(int hitCount)
		{
			RaycastHit transferHit = default(RaycastHit);
			RaycastHit storageHit = default(RaycastHit);
			bool isOverSurface = false;
			bool isOverShipment = false;
			bool flag = false;
			for (int i = 0; i < hitCount; i++)
			{
				int layer = raycastHits[i].transform.gameObject.layer;
				if (layer == ProjectConstants.Layers.Transfer)
				{
					if (!transferHit.transform || transferHit.distance > raycastHits[i].distance)
					{
						transferHit = raycastHits[i];
					}
				}
				else if (layer == ProjectConstants.Layers.Storage)
				{
					storageHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.Placement)
				{
					isOverSurface = true;
				}
				else if (layer == ProjectConstants.Layers.Shipment)
				{
					isOverShipment = true;
				}
				else if (layer == ProjectConstants.Layers.StorageBlockers)
				{
					flag = true;
				}
			}
			IsOverSurface = isOverSurface;
			IsOverShipment = isOverShipment;
			if (!IsOverShipment)
			{
				if ((bool)dragShipmentPack)
				{
					HideDragShipmentPack();
					selectedObject.gameObject.SetActive(value: true);
				}
			}
			else if (selectedObject.State == InteractiveObjectState.Shipment)
			{
				ShowDragShipmentPack();
			}
			if ((bool)storageHit.transform && !initialDataHolder.IsNonStorableObject && !flag)
			{
				HandleStorageHit(storageHit);
			}
			else
			{
				HandleTransferHit(transferHit);
			}
		}

		private void HandleStorageHit(RaycastHit storageHit)
		{
			if (!storageHit.transform.TryGetComponent<StorageBase>(out var component))
			{
				Debug.LogError("StorageBase component not found on " + storageHit.transform.name);
				return;
			}
			Vector3 position = new Vector3(storageHit.point.x, component.transform.position.y, storageHit.point.z);
			bool flag = selectedObject.HasCollision();
			selectedObject.DragState = (flag ? InteractiveObjectDragState.Unstorable : InteractiveObjectDragState.Storable);
			selectedObject.transform.position = position;
			SelectedObjectTargetRotation = component.RefinedRotation;
			Transform transform = storageHit.transform;
			if (!ParentStorage)
			{
				interactiveObjectsTooltipsService.HideTooltipsForTargetObject(selectedObject);
				if (selectedObject is DeviceContainer deviceContainer)
				{
					deviceContainer.SetStoragePoint();
				}
			}
			ParentStorage = transform;
		}

		private void HandleTransferHit(RaycastHit transferHit)
		{
			if ((bool)transferHit.transform)
			{
				selectedObject.transform.position = transferHit.point;
				SelectedObjectTargetRotation = Quaternion.identity;
				if ((bool)dragShipmentPack)
				{
					dragShipmentPack.transform.SetPositionAndRotation(selectedObject.transform.position, selectedObject.transform.rotation);
				}
			}
			if ((bool)ParentStorage)
			{
				ParentStorage = null;
				if (selectedObject is DeviceContainer deviceContainer)
				{
					deviceContainer.SetPlacementPoint();
				}
			}
			if (selectedObject.State == InteractiveObjectState.Shipment)
			{
				return;
			}
			if (!IsOverShipment)
			{
				if (selectedObject.DragState != InteractiveObjectDragState.FreeSoared)
				{
					selectedObject.DragState = InteractiveObjectDragState.FreeSoared;
					interactiveObjectsTooltipsService.HideTooltipsForTargetObject(selectedObject);
				}
				return;
			}
			InteractiveObjectDragState dragState = selectedObject.DragState;
			if (dragState != InteractiveObjectDragState.Shippable && dragState != InteractiveObjectDragState.Unshippable)
			{
				if (shipmentService.IsInteractiveObjectCanBeShipped(selectedObject))
				{
					selectedObject.DragState = InteractiveObjectDragState.Shippable;
					ShowDragShipmentPack();
				}
				else
				{
					selectedObject.DragState = InteractiveObjectDragState.Unshippable;
				}
			}
		}

		private void ShowDragShipmentPack()
		{
			if ((bool)selectedObject && !dragShipmentPack)
			{
				selectedObject.gameObject.SetActive(value: false);
				dragShipmentPack = shipmentPackFactory.CreatePack();
				dragShipmentPack.Init(selectedObject);
				ShowTooltip(selectedObject);
			}
		}

		private void HideDragShipmentPack()
		{
			if ((bool)dragShipmentPack)
			{
				interactiveObjectsTooltipsService.HideTooltipsForTargetObject(selectedObject);
				shipmentPackFactory.DestroyPack(dragShipmentPack);
				dragShipmentPack = null;
			}
		}

		private void ShowTooltip(InteractiveObject draggedObject)
		{
			DecorObject component;
			if (draggedObject is DeviceContainer deviceContainer)
			{
				interactiveObjectsTooltipsService.ShowDeviceForShipmentInitialTooltip(deviceContainer);
			}
			else if (draggedObject.TryGetComponent<DecorObject>(out component))
			{
				interactiveObjectsTooltipsService.ShowDecorForShipmentInitialTooltip(component);
			}
		}
	}
}
