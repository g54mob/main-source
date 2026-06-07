using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.CabControls.VRTK;
using DV.Items;
using DV.UI;
using DV.UI.Inventory;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

namespace DV.InventorySystem
{
	public class InventoryViewVR : InventoryViewBase
	{
		private static InventoryViewVR _instance;

		public GameObject wristAccessPrefab;

		[NonSerialized]
		public ItemBeltVR beltVR;

		private InventoryInputVR inventoryInputVR;

		private VRTK_InteractGrab_DV leftGrab;

		private VRTK_InteractGrab_DV rightGrab;

		private ControllerPointerDetectorInventoryStash wristStashLeft;

		private ControllerPointerDetectorInventoryStash wristStashRight;

		private ItemBase disabledItemOnPauseLeft;

		private ItemBase disabledItemOnPauseRight;

		private HashSet<SDK_BaseController.ControllerHand> longPressControllers = new HashSet<SDK_BaseController.ControllerHand>();

		public new static InventoryViewVR Instance
		{
			get
			{
				if (_instance == null && SingletonBehaviour<InventoryViewBase>.Instance is InventoryViewVR)
				{
					_instance = (InventoryViewVR)SingletonBehaviour<InventoryViewBase>.Instance;
				}
				return _instance;
			}
		}

		public static bool IsPointingAtUI
		{
			get
			{
				if (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance == null)
				{
					return false;
				}
				if (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointer == null)
				{
					return false;
				}
				PointerEventData pointerEventData = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointer.relatedPointer.pointerEventData;
				if (pointerEventData != null)
				{
					return pointerEventData.pointerEnter != null;
				}
				return false;
			}
		}

		public override bool IsVR => true;

		public override bool BigInventoryOpen
		{
			get
			{
				if (inventoryUI != null)
				{
					return inventoryUI.IsOpen;
				}
				return false;
			}
		}

		public InventoryInputVR Input => inventoryInputVR;

		public ItemBase ItemGrabbedRight { get; set; }

		public ItemBase ItemGrabbedLeft { get; set; }

		protected override void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			inventoryInputVR = base.gameObject.GetComponent<InventoryInputVR>();
			beltVR = GetComponent<ItemBeltVR>();
			SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
			base.Awake();
		}

		private void Start()
		{
			if (SetupDeviceSpecificControls.AreControlsSetRight)
			{
				OnControlsSet(SDK_BaseController.ControllerHand.Right);
			}
			if (SetupDeviceSpecificControls.AreControlsSetLeft)
			{
				OnControlsSet(SDK_BaseController.ControllerHand.Left);
			}
			if (!SetupDeviceSpecificControls.AreControlsSetLeft || !SetupDeviceSpecificControls.AreControlsSetRight)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			}
			SetupListeners(on: true);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SetupListeners(on: false);
			_instance = null;
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				inventoryInputVR.ShortClickRequested += OnShortClickPressed;
				inventoryInputVR.LongPressOn += OnLongPressOn;
				inventoryInputVR.LongPressOff += OnLongPressOff;
				inventoryInputVR.LongPressCancel += OnLongPressCancel;
				inventoryUI.OpenedOrClosed += InventoryUIOnOpenedOrClosed;
				inventoryUI.SlotClicked += InventoryUIOnSlotClicked;
				inventoryUI.ContainerAccessClicked += OnContainerAccessClicked;
				inventoryUI.BackpackAccessClicked += OnBackpackAccessClicked;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.MagazineItemDropped += OnMagazineItemDropped;
				SingletonBehaviour<AppUtil>.Instance.GamePaused += OnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnGameUnpaused;
				return;
			}
			if (!UnloadWatcher.isUnloading)
			{
				inventoryInputVR.ShortClickRequested -= OnShortClickPressed;
				inventoryInputVR.LongPressOn -= OnLongPressOn;
				inventoryInputVR.LongPressOff -= OnLongPressOff;
				inventoryInputVR.LongPressCancel -= OnLongPressCancel;
				inventoryUI.OpenedOrClosed -= InventoryUIOnOpenedOrClosed;
				inventoryUI.SlotClicked -= InventoryUIOnSlotClicked;
				inventoryUI.ContainerAccessClicked -= OnContainerAccessClicked;
				inventoryUI.BackpackAccessClicked -= OnBackpackAccessClicked;
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerChanged -= OnActivePointerChanged;
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.MagazineItemDropped -= OnMagazineItemDropped;
				if (leftGrab != null)
				{
					leftGrab.ControllerGrabInteractableObject -= OnItemGrabbedLeft;
					leftGrab.ControllerStartUngrabInteractableObject -= OnItemUngrabbed;
				}
				if (rightGrab != null)
				{
					rightGrab.ControllerGrabInteractableObject -= OnItemGrabbedRight;
					rightGrab.ControllerStartUngrabInteractableObject -= OnItemUngrabbed;
				}
			}
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}

		private void OnMagazineItemDropped(GameObject item)
		{
			ItemVRTK itemVRTK = ((item != null) ? item.GetComponent<ItemVRTK>() : null);
			if (!(itemVRTK == null))
			{
				Transform forceDropTransform = itemVRTK.ForceDropTransform;
				if (!(forceDropTransform == null))
				{
					AdjustItemTransformOnUnstash(item, null, forceDropTransform);
				}
			}
		}

		private void OnActivePointerChanged()
		{
			if (BigInventoryOpen)
			{
				OverrideUIDragData();
			}
		}

		private void OverrideUIDragData(bool clear = false)
		{
			SDK_BaseController.ControllerHand activePointerHand = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand;
			if (activePointerHand == SDK_BaseController.ControllerHand.None)
			{
				inventoryUI.OverrideDragAndContainerClickInteraction(-1, null);
				return;
			}
			int equipSlot = (clear ? (-1) : ((activePointerHand == SDK_BaseController.ControllerHand.Right) ? 1 : 0));
			PointerEventData pointerEventData = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointer.relatedPointer.pointerEventData;
			inventoryUI.OverrideDragAndContainerClickInteraction(equipSlot, pointerEventData);
		}

		private void OnContainerAccessClicked(AItemContainer container, bool isForceDragging)
		{
			if (!isForceDragging)
			{
				return;
			}
			if (container == null)
			{
				Debug.LogError("InventoryViewVR: Container is null when container access is clicked. This should not happen.", this);
				return;
			}
			ItemBase itemBase;
			switch (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand)
			{
			case SDK_BaseController.ControllerHand.None:
				Debug.LogError("InventoryViewVR: Active pointer hand is none when container access is clicked. This should not happen.", this);
				return;
			default:
				itemBase = ItemGrabbedLeft;
				break;
			case SDK_BaseController.ControllerHand.Right:
				itemBase = ItemGrabbedRight;
				break;
			}
			ItemBase itemBase2 = itemBase;
			if (itemBase2 == null)
			{
				Debug.LogError("InventoryViewVR: No item grabbed when conatainer access is clicked. This should not happen.", this);
			}
			else
			{
				if (!container.ValidItem(itemBase2.gameObject))
				{
					return;
				}
				int firstFreeSlot = container.GetFirstFreeSlot();
				if (firstFreeSlot < 0)
				{
					ItemMagazine itemMagazine = container as ItemMagazine;
					if (!(itemMagazine == null) && itemMagazine.QuickDropAllowed)
					{
						GameObject item = itemMagazine[0];
						AItemContainer item2 = itemMagazine.NestedIn.firstNest;
						int num = ((item2 != null && item2.ValidItem(item)) ? item2.GetFirstFreeSlot() : (-1));
						if (num >= 0)
						{
							itemMagazine.RemoveItem(0, activateItem: false, dropItem: false);
							item2.AddItem(item, num);
						}
						else if (SingletonBehaviour<Inventory>.Instance.CanAddItem(item))
						{
							itemMagazine.RemoveItem(0, activateItem: false, dropItem: false);
							SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item);
						}
						else
						{
							itemMagazine.RemoveItem(0, activateItem: true, dropItem: true);
						}
						SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemBase2.gameObject);
						itemMagazine.AddItem(itemBase2.gameObject, 0);
					}
				}
				else
				{
					SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemBase2.gameObject);
					container.AddItem(itemBase2.gameObject, firstFreeSlot);
				}
			}
		}

		private void OnBackpackAccessClicked(bool isForceDragging)
		{
			if (!isForceDragging)
			{
				return;
			}
			ItemBase itemBase;
			switch (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand)
			{
			case SDK_BaseController.ControllerHand.None:
				Debug.LogError("InventoryViewVR: Active pointer hand is none when backpack access is clicked. This should not happen.", this);
				return;
			default:
				itemBase = ItemGrabbedLeft;
				break;
			case SDK_BaseController.ControllerHand.Right:
				itemBase = ItemGrabbedRight;
				break;
			}
			ItemBase itemBase2 = itemBase;
			if (itemBase2 == null)
			{
				Debug.LogError("InventoryViewVR: No item grabbed when backpack access is clicked. This should not happen.", this);
				return;
			}
			AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
			if (activeContainer == null)
			{
				Debug.LogError("InventoryViewVR: Active container is null when backpack access is clicked. This should not happen.", this);
				return;
			}
			AItemContainer item = activeContainer.NestedIn.firstNest;
			int num = ((item != null && item.ValidItem(itemBase2.gameObject)) ? item.GetFirstFreeSlot() : (-1));
			if (num >= 0)
			{
				SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemBase2.gameObject);
				item.AddItem(itemBase2.gameObject, num);
				return;
			}
			num = SingletonBehaviour<Inventory>.Instance.GetFirstFreeBackpackSlot();
			if (num >= 0)
			{
				SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(itemBase2.gameObject);
				SingletonBehaviour<Inventory>.Instance.AddItemToInventory(itemBase2.gameObject, num);
			}
		}

		private void OnLongPressCancel(SDK_BaseController.ControllerHand hand)
		{
			longPressControllers.Remove(hand);
		}

		private void OnLongPressOn(SDK_BaseController.ControllerHand hand)
		{
			longPressControllers.Add(hand);
			CheckLongPress();
		}

		private void OnLongPressOff(SDK_BaseController.ControllerHand hand)
		{
			longPressControllers.Remove(hand);
			TryStashUnstashHandPointer(hand);
			CheckLongPress();
		}

		private void CheckLongPress()
		{
			bool flag = longPressControllers.Count != 0;
			bool flag2 = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Inventory);
			if (flag != flag2)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Inventory, flag);
			}
		}

		private void OnGamePaused()
		{
			DoHand(right: true);
			DoHand(right: false);
			void DoHand(bool right)
			{
				ItemBase itemBase = (right ? ItemGrabbedRight : ItemGrabbedLeft);
				ItemBase itemBase2 = (right ? ItemGrabbedLeft : ItemGrabbedRight);
				if (!(itemBase == null) && (right || !(itemBase == itemBase2)))
				{
					if (right)
					{
						disabledItemOnPauseRight = itemBase;
					}
					else
					{
						disabledItemOnPauseLeft = itemBase;
					}
					if (SingletonBehaviour<Inventory>.Instance.CanAddItem(itemBase.gameObject))
					{
						SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: true, right ? 1 : 0);
					}
					else
					{
						itemBase.ForceEndInteraction();
						StartCoroutine(DelayedItemDisableOnPause(itemBase));
					}
				}
			}
		}

		private IEnumerator DelayedItemDisableOnPause(ItemBase item)
		{
			yield return null;
			item.gameObject.SetActive(value: false);
		}

		private void OnGameUnpaused()
		{
			DoHand(right: true);
			DoHand(right: false);
			disabledItemOnPauseLeft = null;
			disabledItemOnPauseRight = null;
			void DoHand(bool right)
			{
				ItemBase itemBase = (right ? disabledItemOnPauseRight : disabledItemOnPauseLeft);
				if ((bool)itemBase)
				{
					if (SingletonBehaviour<Inventory>.Instance.IndexOf(itemBase.gameObject) < 0)
					{
						itemBase.gameObject.SetActive(value: true);
					}
					SingletonBehaviour<Inventory>.Instance.EquipItem(itemBase.gameObject, right ? 1 : 0);
				}
			}
		}

		private void OnControlsSet(SDK_BaseController.ControllerHand givenControllerHand)
		{
			bool num = givenControllerHand == SDK_BaseController.ControllerHand.Right;
			VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(givenControllerHand);
			if (num)
			{
				rightGrab = controllerReferenceForHand.actual.GetComponentInChildren<VRTK_InteractGrab_DV>();
				rightGrab.ControllerGrabInteractableObject += OnItemGrabbedRight;
				rightGrab.ControllerUngrabInteractableObject += OnItemUngrabbed;
				wristStashRight = ControllerAddonInstantiator.InstantiateControllerAddon(wristAccessPrefab, controllerReferenceForHand)?.GetComponent<ControllerPointerDetectorInventoryStash>();
			}
			else
			{
				leftGrab = controllerReferenceForHand.actual.GetComponentInChildren<VRTK_InteractGrab_DV>();
				leftGrab.ControllerGrabInteractableObject += OnItemGrabbedLeft;
				leftGrab.ControllerUngrabInteractableObject += OnItemUngrabbed;
				wristStashLeft = ControllerAddonInstantiator.InstantiateControllerAddon(wristAccessPrefab, controllerReferenceForHand)?.GetComponent<ControllerPointerDetectorInventoryStash>();
			}
			if (SetupDeviceSpecificControls.AreControlsSetRight && SetupDeviceSpecificControls.AreControlsSetLeft)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			}
		}

		private void InventoryUIOnSlotClicked(int index)
		{
			bool num = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand == SDK_BaseController.ControllerHand.Right;
			GameObject grabbedObject = (num ? VRTK_DeviceFinder.GetControllerRightHand(getActual: true).transform : VRTK_DeviceFinder.GetControllerLeftHand(getActual: true).transform).GetComponentInChildren<VRTK_InteractGrab>().GetGrabbedObject();
			int num2 = (num ? 1 : 0);
			AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
			if (activeContainer != null)
			{
				int num3 = index - 12;
				if (num3.IsInRange(0, activeContainer.Capacity - 1))
				{
					HandleContainerSlotClick(num3, grabbedObject, activeContainer, num2);
					return;
				}
			}
			GameObject gameObject = SingletonBehaviour<Inventory>.Instance.PeekItemAtSlot(index);
			InventoryItemSpec inventoryItemSpec = ((gameObject != null) ? gameObject.GetComponent<InventoryItemSpec>() : null);
			bool slotDroppedState = SingletonBehaviour<Inventory>.Instance.GetSlotDroppedState(index);
			if (grabbedObject == null)
			{
				if (gameObject != null && !slotDroppedState)
				{
					inventoryUI.RequestEquipItem(inventoryItemSpec, num2);
				}
				return;
			}
			int num4 = SingletonBehaviour<Inventory>.Instance.FindReservedSlotForDroppedItem(grabbedObject);
			if (num4 < 0 || (slotDroppedState && num4 != index))
			{
				return;
			}
			inventoryUI.RequestUnequipItem(num2);
			bool slotLockState = SingletonBehaviour<Inventory>.Instance.GetSlotLockState(num4);
			bool slotLockState2 = SingletonBehaviour<Inventory>.Instance.GetSlotLockState(index);
			if (((grabbedObject != null) ? grabbedObject.GetComponent<ItemBase>() : null) == null)
			{
				return;
			}
			if (gameObject == null)
			{
				if (!slotLockState && num4 != index)
				{
					SingletonBehaviour<Inventory>.Instance.MoveItemFromTo(num4, index);
				}
			}
			else if (!(gameObject == grabbedObject) && !slotDroppedState)
			{
				if (slotLockState2)
				{
					inventoryUI.RequestEquipItem(inventoryItemSpec, num2);
				}
				else if (!slotLockState && SingletonBehaviour<Inventory>.Instance.SwapItems(num4, index))
				{
					inventoryUI.RequestEquipItem(inventoryItemSpec, num2);
				}
			}
		}

		private void HandleContainerSlotClick(int containerIndex, GameObject currentlyGrabbed, AItemContainer activeContainer, int targetEquipSlot)
		{
			GameObject gameObject = activeContainer[containerIndex];
			InventoryItemSpec inventoryItemSpec = ((gameObject != null) ? gameObject.GetComponent<InventoryItemSpec>() : null);
			if (currentlyGrabbed == null)
			{
				if (!(inventoryItemSpec == null))
				{
					activeContainer.RemoveItem(containerIndex, activateItem: true, dropItem: true);
					inventoryUI.RequestEquipItem(inventoryItemSpec, targetEquipSlot);
				}
			}
			else if (activeContainer.ValidItem(currentlyGrabbed))
			{
				SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(currentlyGrabbed);
				if (inventoryItemSpec != null)
				{
					activeContainer.RemoveItem(containerIndex, activateItem: true, dropItem: true);
					inventoryUI.RequestEquipItem(inventoryItemSpec, targetEquipSlot);
				}
				activeContainer.AddItem(currentlyGrabbed, containerIndex);
			}
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState targetState, InventoryActionType targetActionType)
		{
			beltVR.OnInventoryStatusChanged(originState, originActionType, targetState, targetActionType);
			if (originActionType.HasAnyIntFlag(InventoryActionType.Equip) && !originState.item.GetComponent<VRTK_InteractableObject>().IsGrabbed())
			{
				VRTK_InteractGrab_DV vRTK_InteractGrab_DV = ((originState.equipSlot == 1) ? rightGrab : leftGrab);
				AdjustItemTransformOnUnstash(originState.item, vRTK_InteractGrab_DV.gameObject);
				vRTK_InteractGrab_DV.ForceGrabInteractable(originState.item);
			}
			if (!originActionType.HasAnyIntFlag(InventoryActionType.Unequip))
			{
				return;
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.Add))
			{
				VRTK_InteractableObject component = originState.item.GetComponent<VRTK_InteractableObject>();
				if (component.IsGrabbed())
				{
					component.ForceStopInteracting();
				}
			}
			else
			{
				VRTK_InteractGrab_DV vRTK_InteractGrab_DV2 = ((originState.equipSlot == 1) ? rightGrab : leftGrab);
				if (vRTK_InteractGrab_DV2.GetGrabbedObject() == originState.item)
				{
					vRTK_InteractGrab_DV2.ForceRelease();
				}
			}
		}

		private void InventoryUIOnOpenedOrClosed(bool open)
		{
			SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerChanged -= OnActivePointerChanged;
			if (open)
			{
				inventoryUI.Toggle(on: true);
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerChanged += OnActivePointerChanged;
			}
			TransmogrifyControllers.RefreshControllerMaterials();
			bool flag = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer != null;
			if (!flag)
			{
				inventorySounds.PlayInventoryOpenOrCloseSound(open);
			}
			if (!open)
			{
				inventoryInputVR.RequestPointer(SDK_BaseController.ControllerHand.None, enablePointer: false);
				if (flag)
				{
					SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer = null;
				}
			}
			OnBigInventoryOpenChanged_Fire();
			OverrideUIDragData();
		}

		private void AdjustItemTransformOnUnstash(GameObject item, GameObject controller, Transform targetTransform = null)
		{
			ItemReparentingBase component = item.GetComponent<ItemReparentingBase>();
			Transform playerTransform = PlayerManager.PlayerTransform;
			if (component == null)
			{
				item.transform.SetParent(playerTransform);
			}
			else
			{
				Rigidbody receiveForcesFrom = TrainCar.Resolve(PlayerManager.PlayerTransform)?.rb;
				component.ParentItemExternal(playerTransform, receiveForcesFrom);
			}
			ItemBase component2 = item.GetComponent<ItemBase>();
			if (controller != null)
			{
				PipaUtils.AlignItemToControllersPipa(component2, controller);
			}
			else if (targetTransform != null)
			{
				if (targetTransform.gameObject.activeInHierarchy)
				{
					item.transform.position = targetTransform.position;
					item.transform.rotation = targetTransform.rotation;
				}
				else
				{
					item.transform.position += Vector3.up * 0.5f;
				}
			}
		}

		private void OnItemGrabbedLeft(object sender, ObjectInteractEventArgs e)
		{
			if (!(e.target == null))
			{
				ItemBase component = e.target.GetComponent<ItemBase>();
				OnItemGrabbed(component, isRight: false);
			}
		}

		private void OnItemGrabbedRight(object sender, ObjectInteractEventArgs e)
		{
			if (!(e.target == null))
			{
				ItemBase component = e.target.GetComponent<ItemBase>();
				OnItemGrabbed(component, isRight: true);
			}
		}

		private void OnItemGrabbed(ItemBase item, bool isRight)
		{
			if (item == null)
			{
				return;
			}
			GameObject gameObject = item.gameObject;
			if (SingletonBehaviour<Inventory>.Instance.Contains(gameObject, includeDropped: false))
			{
				item.ForceEndInteraction();
				if (isRight)
				{
					ItemGrabbedRight = null;
				}
				else
				{
					ItemGrabbedLeft = null;
				}
				SingletonBehaviour<StorageController>.Instance.AddItemToStorageItemList(SingletonBehaviour<StorageController>.Instance.StorageInventory, gameObject);
				return;
			}
			if (isRight)
			{
				ItemGrabbedRight = item;
			}
			else
			{
				ItemGrabbedLeft = item;
			}
			Inventory instance = SingletonBehaviour<Inventory>.Instance;
			if (instance.GetEquipSlotForItem(item.gameObject) < 0 || item.IsTwoHanded)
			{
				instance.EquipItem(item.gameObject, isRight ? 1 : 0);
			}
			if (BigInventoryOpen && inventoryInputVR.IsPointingWith(isRight))
			{
				OverrideUIDragData();
			}
		}

		private void OnItemUngrabbed(object grab, ObjectInteractEventArgs e)
		{
			bool flag;
			ControllerPointerDetectorInventoryStash controllerPointerDetectorInventoryStash;
			if (e.controllerReference.hand == SDK_BaseController.ControllerHand.Right)
			{
				flag = true;
				ItemGrabbedRight = null;
				controllerPointerDetectorInventoryStash = wristStashLeft;
			}
			else
			{
				flag = false;
				ItemGrabbedLeft = null;
				controllerPointerDetectorInventoryStash = wristStashRight;
			}
			bool addToInventory = false;
			if (!((e.target ? e.target.GetComponent<ItemBase>() : null) == null))
			{
				if (controllerPointerDetectorInventoryStash != null && controllerPointerDetectorInventoryStash.IsProperlyTouched(flag) && SingletonBehaviour<Inventory>.Instance.FindReservedSlotForDroppedItem(e.target) >= 0)
				{
					controllerPointerDetectorInventoryStash.ForceUnhighlight();
					addToInventory = true;
				}
				Inventory instance = SingletonBehaviour<Inventory>.Instance;
				int slot = (flag ? 1 : 0);
				if (instance.GetEquippedItemAtSlot(slot) == e.target)
				{
					instance.UnequipItem(addToInventory, flag ? 1 : 0);
				}
				if (BigInventoryOpen && inventoryInputVR.IsPointingWith(flag))
				{
					OverrideUIDragData(clear: true);
				}
			}
		}

		private void OnShortClickPressed(SDK_BaseController.ControllerHand hand)
		{
			if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.PauseMenu))
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: false);
				return;
			}
			if (inventoryUI.IsOpen && longPressControllers.Count == 0)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Inventory, on: false);
				return;
			}
			bool flag = hand == SDK_BaseController.ControllerHand.Right;
			GameObject gameObject = (flag ? rightGrab.GetGrabbedObject() : leftGrab.GetGrabbedObject());
			if (((gameObject != null) ? gameObject.GetComponent<ItemBase>() : null) != null && SingletonBehaviour<Inventory>.Instance.CanAddItem(gameObject))
			{
				inventoryUI.RequestUnequipItem(flag ? 1 : 0);
			}
			else if (longPressControllers.Count == 0)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Inventory, on: true);
				inventoryInputVR.RequestPointer(hand, enablePointer: true);
			}
		}

		private void TryStashUnstashHandPointer(SDK_BaseController.ControllerHand hand)
		{
			if (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointerHand != hand)
			{
				return;
			}
			GameObject grabbedObject = ((hand == SDK_BaseController.ControllerHand.Right) ? rightGrab : leftGrab).GetGrabbedObject();
			ItemBase itemBase = ((grabbedObject != null) ? grabbedObject.GetComponent<ItemBase>() : null);
			bool flag = grabbedObject == null || itemBase != null;
			VRTK_UIPointer relatedPointer = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.ActivePointer.relatedPointer;
			if (!(relatedPointer != null && flag))
			{
				return;
			}
			GameObject pointerEnter = relatedPointer.pointerEventData.pointerEnter;
			InventoryGridElement inventoryGridElement = ((pointerEnter != null) ? pointerEnter.GetComponentInParent<InventoryGridElement>() : null);
			InventoryItemDropZone inventoryItemDropZone = ((pointerEnter != null) ? pointerEnter.GetComponentInParent<InventoryItemDropZone>() : null);
			if (inventoryItemDropZone != null && itemBase != null)
			{
				if (inventoryItemDropZone.ItemContainerDropZone)
				{
					InventorySlotDisplayData inventorySlotDisplayData = ((inventoryGridElement != null) ? inventoryGridElement.Data : null);
					if (inventorySlotDisplayData?.Spec == null)
					{
						Debug.LogError("InventoryViewVR: Missing data or spec for InventoryItemDropZone. This should not happen.", inventoryItemDropZone);
						return;
					}
					if (inventorySlotDisplayData.IsGhost)
					{
						return;
					}
				}
				inventoryItemDropZone.GetComponentInParent<IClickable>()?.Click();
			}
			else if (inventoryGridElement != null)
			{
				InventorySectionController componentInParent = inventoryGridElement.GetComponentInParent<InventorySectionController>();
				bool num = componentInParent != null && componentInParent.section != InventorySectionController.InventorySection.Hand;
				bool flag2 = itemBase != null;
				bool flag3 = inventoryGridElement.Data.Spec == null;
				if (num && (flag2 || !flag3))
				{
					inventoryGridElement.GetComponent<IClickable>()?.Click();
				}
			}
		}

		public bool IsInteracting(SDK_BaseController.ControllerHand hand)
		{
			if (IsPointingAtUI)
			{
				return inventoryInputVR.IsInteractionButtonPressed(hand);
			}
			return false;
		}
	}
}
