using System;
using System.Collections;
using DV.CabControls;
using DV.CabControls.VRTK;
using DV.Items.Snapping;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.InventorySystem
{
	public class ItemBeltVR : MonoBehaviour
	{
		public delegate void ItemAddedToBeltDelegate(ItemBase item);

		public delegate void ForceSnapOnUngrabRequestedDelegate(ItemSnapPointBase snapPoint, ItemBase item);

		public delegate void ForceSnapOnUngrabRequestCanceledDelegate(ItemSnapPointBase snapPoint);

		public delegate void ItemEquippedFromBeltDelegate(SDK_BaseController.ControllerHand hand);

		[SerializeField]
		private GameObject itemBeltPrefab;

		private ItemSnapPointBelt[] beltSnapPoints;

		private BeltSnapPointAdjuster[] beltSlotAdjusters;

		private AInventoryUIController inventoryProvider;

		private ControllerPointerDetectorBelt[] pointerDetectors;

		public GameObject ItemBelt { get; private set; }

		public int BeltSize
		{
			get
			{
				if (beltSnapPoints == null)
				{
					return -1;
				}
				return beltSnapPoints.Length;
			}
		}

		public event ItemAddedToBeltDelegate ItemAddedToBelt;

		public event ForceSnapOnUngrabRequestedDelegate ForceSnapOnUngrabRequested;

		public event ForceSnapOnUngrabRequestCanceledDelegate ForceSnapOnUngrabRequestCanceled;

		public event ItemEquippedFromBeltDelegate ItemEquippedFromBelt;

		private void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		private IEnumerator Start()
		{
			while (!PlayerManager.PlayerCamera)
			{
				yield return null;
			}
			Transform headOverride = PlayerManager.PlayerCamera.transform;
			Transform playerTransform = PlayerManager.PlayerTransform;
			ItemBelt = UnityEngine.Object.Instantiate(itemBeltPrefab, playerTransform);
			ItemBelt.GetComponent<VRTK_HipTracking>().headOverride = headOverride;
			beltSnapPoints = ItemBelt.GetComponentsInChildren<ItemSnapPointBelt>();
			ItemSnapPointBelt[] array = beltSnapPoints;
			foreach (ItemSnapPointBelt itemSnapPointBelt in array)
			{
				if (!(itemSnapPointBelt == null))
				{
					ItemSnapPointInteractionBelt component = itemSnapPointBelt.GetComponent<ItemSnapPointInteractionBelt>();
					if (component == null)
					{
						Debug.LogError("Missing ItemSnapPointInteractionBelt on " + itemSnapPointBelt.name + ". This should not happen.", itemSnapPointBelt);
					}
					else
					{
						component.Initialize(this);
					}
				}
			}
			beltSlotAdjusters = ItemBelt.GetComponentsInChildren<BeltSnapPointAdjuster>();
			bool shouldEnable = SingletonBehaviour<Inventory>.Instance.DefaultBeltSlotState == BeltSlotState.VisibleAndEnabled;
			array = beltSnapPoints;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ToggleSnapPoint(shouldEnable);
			}
			inventoryProvider = InventoryViewVR.Instance.inventoryUI;
			SetupListeners(on: true);
			ItemBeltSerializer.LoadBeltSlotTransformData(this);
			pointerDetectors = ItemBelt.GetComponentsInChildren<ControllerPointerDetectorBelt>();
			yield return null;
			ItemBeltSerializer.LoadBeltSlotStatesData(this);
			if (inventoryProvider != null)
			{
				inventoryProvider.BeltResetRequested += OnBeltResetRequested;
				inventoryProvider.BeltToggleRequested += OnBeltToggleRequested;
			}
		}

		private void SetupListeners(bool on)
		{
			BeltSnapPointAdjuster[] array;
			ItemSnapPointBelt[] array2;
			if (on)
			{
				array = beltSlotAdjusters;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Ungrabbed += SaveBeltSlotTransformData;
				}
				array2 = beltSnapPoints;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].ItemSnappedChanged += OnItemSnapChanged;
				}
				return;
			}
			array = beltSlotAdjusters;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Ungrabbed -= SaveBeltSlotTransformData;
			}
			array2 = beltSnapPoints;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].ItemSnappedChanged -= OnItemSnapChanged;
			}
			if (inventoryProvider != null)
			{
				inventoryProvider.BeltResetRequested -= OnBeltResetRequested;
				inventoryProvider.BeltToggleRequested -= OnBeltToggleRequested;
			}
		}

		public void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState targetState, InventoryActionType targetActionType)
		{
			int slotIndex = originState.slotIndex;
			int slotIndex2 = targetState.slotIndex;
			GameObject item = originState.item;
			GameObject item2 = targetState.item;
			if (originActionType.HasAnyIntFlag(InventoryActionType.Add))
			{
				if (!originActionType.HasAnyIntFlag(InventoryActionType.Destroy))
				{
					HandleItemAddedToInventory(item, slotIndex);
				}
			}
			else if (originActionType.HasAnyIntFlag(InventoryActionType.Drop))
			{
				HandleItemDrop(item, slotIndex);
			}
			else if (originActionType.HasAnyIntFlag(InventoryActionType.Equip))
			{
				HandleItemEquipped(item, slotIndex);
			}
			else if (originActionType.HasAnyIntFlag(InventoryActionType.Swap))
			{
				HandleItemSwap(item2, slotIndex, item, slotIndex2);
			}
			else if (targetActionType.HasAnyIntFlag(InventoryActionType.Move))
			{
				HandleItemMove(item2, slotIndex, slotIndex2);
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.Purge | InventoryActionType.Reserve | InventoryActionType.Unreserve))
			{
				HandleReserveChange(item, slotIndex, originActionType.HasAnyIntFlag(InventoryActionType.Reserve));
			}
			if (targetActionType.HasAnyIntFlag(InventoryActionType.Purge | InventoryActionType.Reserve | InventoryActionType.Unreserve))
			{
				HandleReserveChange(item2, slotIndex2, targetActionType.HasAnyIntFlag(InventoryActionType.Reserve));
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.BeltVisible | InventoryActionType.BeltHidden | InventoryActionType.BeltDisabled | InventoryActionType.BeltEnabled))
			{
				HandleBeltVisibilityChange(slotIndex, originActionType);
			}
		}

		private void HandleBeltVisibilityChange(int originSlot, InventoryActionType state)
		{
			int num = SingletonBehaviour<Inventory>.Instance.BeltIndexFromInventoryIndex(originSlot);
			if (num >= 0)
			{
				bool flag = state.HasAnyIntFlag(InventoryActionType.BeltVisible);
				bool shouldEnable = flag && state.HasAnyIntFlag(InventoryActionType.BeltEnabled);
				beltSnapPoints[num].ToggleSnapPoint(shouldEnable);
				ItemBeltSerializer.SaveBeltSlotState(this, originSlot, flag);
			}
		}

		private void OnBeltToggleRequested(int index)
		{
			BeltSlotState desiredState;
			switch (SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(index).beltSlotState)
			{
			default:
				return;
			case BeltSlotState.VisibleAndEnabled:
				desiredState = BeltSlotState.HiddenAndEnabled;
				break;
			case BeltSlotState.HiddenAndEnabled:
				desiredState = BeltSlotState.VisibleAndEnabled;
				break;
			}
			SingletonBehaviour<Inventory>.Instance.SetBeltVisibilityState(index, desiredState);
		}

		private void OnBeltResetRequested(int index)
		{
			int num = SingletonBehaviour<Inventory>.Instance.BeltIndexFromInventoryIndex(index);
			if (num >= 0)
			{
				beltSlotAdjusters[num].Reset();
			}
		}

		private void OnItemSnapChanged(ItemSnapPointBase snapPoint, ItemBase item, bool snapped, bool forced)
		{
			if (snapped)
			{
				this.ItemAddedToBelt?.Invoke(item);
			}
		}

		private void HandleReserveChange(GameObject item, int slot, bool reserved)
		{
			int num = SingletonBehaviour<Inventory>.Instance.BeltIndexFromInventoryIndex(slot);
			if (num >= 0)
			{
				ItemBase itemToReserveFor = ((item != null && reserved) ? item.GetComponent<ItemBase>() : null);
				beltSnapPoints[num].ToggleReserved(itemToReserveFor);
			}
		}

		private void HandleItemSwap(GameObject preSwapOriginItem, int originSlot, GameObject preSwapTargetItem, int targetSlot)
		{
			(int beltSlotIndex, BeltSlotState beltSlotState) beltSlotIndexAndState = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(originSlot);
			int item = beltSlotIndexAndState.beltSlotIndex;
			BeltSlotState item2 = beltSlotIndexAndState.beltSlotState;
			(int beltSlotIndex, BeltSlotState beltSlotState) beltSlotIndexAndState2 = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(targetSlot);
			int item3 = beltSlotIndexAndState2.beltSlotIndex;
			BeltSlotState item4 = beltSlotIndexAndState2.beltSlotState;
			bool num = item >= 0;
			bool flag = item3 >= 0;
			if (num && beltSnapPoints[item].SnappedItem != null)
			{
				beltSnapPoints[item].UnsnapItem();
			}
			if (flag && beltSnapPoints[item3].SnappedItem != null)
			{
				beltSnapPoints[item3].UnsnapItem();
			}
			ItemBase component = preSwapTargetItem.GetComponent<ItemBase>();
			ItemBase component2 = preSwapOriginItem.GetComponent<ItemBase>();
			bool flag2 = num && component.IsBeltSnappable;
			bool flag3 = flag && component2.IsBeltSnappable;
			if (num)
			{
				CancelForceSnapRequest(beltSnapPoints[item]);
			}
			if (flag)
			{
				CancelForceSnapRequest(beltSnapPoints[item3]);
			}
			if (flag2)
			{
				ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[item];
				if (component.IsGrabbed())
				{
					RequestForceSnap(itemSnapPointBelt, component);
				}
				else
				{
					itemSnapPointBelt.SnapItem(preSwapTargetItem, forced: true);
				}
			}
			if (flag3)
			{
				ItemSnapPointBelt itemSnapPointBelt2 = beltSnapPoints[item3];
				if (component2.IsGrabbed())
				{
					RequestForceSnap(itemSnapPointBelt2, component2);
				}
				else
				{
					itemSnapPointBelt2.SnapItem(preSwapOriginItem, forced: true);
				}
			}
			if (num)
			{
				UpdateBeltSlotStateOnInventoryStateChange(component, item2, originSlot, stashedOrReserved: true);
			}
			if (flag)
			{
				UpdateBeltSlotStateOnInventoryStateChange(component2, item4, targetSlot, stashedOrReserved: true);
			}
		}

		private void CancelForceSnapRequest(ItemSnapPointBase snapPoint)
		{
			this.ForceSnapOnUngrabRequestCanceled?.Invoke(snapPoint);
		}

		private void RequestForceSnap(ItemSnapPointBase snapPoint, ItemBase item)
		{
			if (snapPoint.SnappedItem != null)
			{
				Debug.LogError("Force snap requested of an occupied snap point " + snapPoint.name, snapPoint);
			}
			else
			{
				this.ForceSnapOnUngrabRequested?.Invoke(snapPoint, item);
			}
		}

		private void HandleItemMove(GameObject item, int originSlot, int targetSlot)
		{
			(int beltSlotIndex, BeltSlotState beltSlotState) beltSlotIndexAndState = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(originSlot);
			int item2 = beltSlotIndexAndState.beltSlotIndex;
			BeltSlotState item3 = beltSlotIndexAndState.beltSlotState;
			(int beltSlotIndex, BeltSlotState beltSlotState) beltSlotIndexAndState2 = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(targetSlot);
			int item4 = beltSlotIndexAndState2.beltSlotIndex;
			BeltSlotState item5 = beltSlotIndexAndState2.beltSlotState;
			ItemBase component = item.GetComponent<ItemBase>();
			bool flag = false;
			bool flag2 = false;
			if (item2 >= 0)
			{
				ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[item2];
				CancelForceSnapRequest(itemSnapPointBelt);
				if (itemSnapPointBelt.SnappedItem != null)
				{
					itemSnapPointBelt.UnsnapItem();
				}
				flag = true;
			}
			if (item4 >= 0)
			{
				if (component.IsBeltSnappable)
				{
					ItemSnapPointBelt itemSnapPointBelt2 = beltSnapPoints[item4];
					if (component.IsGrabbed())
					{
						RequestForceSnap(itemSnapPointBelt2, component);
					}
					else
					{
						itemSnapPointBelt2.SnapItem(item, forced: true);
					}
				}
				flag2 = true;
			}
			if (flag)
			{
				UpdateBeltSlotStateOnInventoryStateChange(component, item3, originSlot, stashedOrReserved: false);
			}
			if (flag2)
			{
				UpdateBeltSlotStateOnInventoryStateChange(component, item5, targetSlot, stashedOrReserved: true);
			}
		}

		private void HandleItemDrop(GameObject item, int slot)
		{
			var (num, currentState) = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(slot);
			if (num >= 0)
			{
				ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[num];
				GameObject gameObject = ((itemSnapPointBelt.SnappedItem != null) ? itemSnapPointBelt.SnappedItem.gameObject : null);
				if (!(gameObject == null) || !(gameObject == item))
				{
					CancelForceSnapRequest(itemSnapPointBelt);
					itemSnapPointBelt.UnsnapItem();
					ItemBase component = item.GetComponent<ItemBase>();
					bool stashedOrReserved = InventoryUtils.IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.IndexOf(item));
					UpdateBeltSlotStateOnInventoryStateChange(component, currentState, slot, stashedOrReserved);
				}
			}
		}

		private void HandleItemAddedToInventory(GameObject item, int slot)
		{
			(int beltSlotIndex, BeltSlotState beltSlotState) beltSlotIndexAndState = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(slot);
			int item2 = beltSlotIndexAndState.beltSlotIndex;
			BeltSlotState item3 = beltSlotIndexAndState.beltSlotState;
			ItemBase component = item.GetComponent<ItemBase>();
			if (component == null)
			{
				Debug.LogError("Item " + item.name + " does not have an itemBase component but was added to inventory.", this);
			}
			else if (item2 >= 0)
			{
				ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[item2];
				if (component.IsGrabbed())
				{
					RequestForceSnap(itemSnapPointBelt, component);
				}
				else
				{
					itemSnapPointBelt.SnapItem(item, forced: true);
				}
				UpdateBeltSlotStateOnInventoryStateChange(component, item3, slot, stashedOrReserved: true);
			}
		}

		private void UpdateBeltSlotStateOnInventoryStateChange(ItemBase itemBase, BeltSlotState currentState, int inventoryIndex, bool stashedOrReserved)
		{
			if (!(itemBase == null))
			{
				bool flag = currentState == BeltSlotState.VisibleAndEnabled || currentState == BeltSlotState.VisibleAndDisabled;
				BeltSlotState beltSlotState = ((!itemBase.IsBeltSnappable && stashedOrReserved) ? (flag ? BeltSlotState.VisibleAndDisabled : BeltSlotState.HiddenAndDisabled) : ((!flag) ? BeltSlotState.HiddenAndEnabled : BeltSlotState.VisibleAndEnabled));
				if (currentState != beltSlotState)
				{
					SingletonBehaviour<Inventory>.Instance.SetBeltVisibilityState(inventoryIndex, beltSlotState);
				}
			}
		}

		private void HandleItemEquipped(GameObject item, int slot)
		{
			var (num, beltSlotState) = SingletonBehaviour<Inventory>.Instance.GetBeltSlotIndexAndState(slot);
			if (beltSlotState == BeltSlotState.InvalidSlot)
			{
				return;
			}
			ItemBase component = item.GetComponent<ItemBase>();
			if (component == null)
			{
				Debug.LogError("Item " + item.name + " does not have an itemBase component but was removed from inventory.", this);
				return;
			}
			ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[num];
			if (itemSnapPointBelt.SnappedItem != null)
			{
				itemSnapPointBelt.UnsnapItem(forced: true);
			}
			UpdateBeltSlotStateOnInventoryStateChange(component, beltSlotState, slot, stashedOrReserved: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SaveBeltSlotTransformData(ControlImplBase _)
		{
			ItemBeltSerializer.SaveBeltSlotTransformData(this);
		}

		public int InventoryIndexFromBeltSlot(ItemSnapPointBase slot)
		{
			if (slot == null)
			{
				Debug.LogError("Invalid belt slot. This should not happen");
				return -1;
			}
			int beltSlotIndex = GetBeltSlotIndex(slot);
			if (beltSlotIndex < 0)
			{
				Debug.LogError("Invalid belt slot index. This should not happen.", this);
				return -1;
			}
			int num = 33 + beltSlotIndex;
			if (!SingletonBehaviour<Inventory>.Instance.IsValidVRBeltIndex(num))
			{
				Debug.LogError("Invalid inventory index for belt. This should not happen", this);
				return -1;
			}
			return num;
		}

		public bool ForceRemoveItemFromBelt(ItemBase item)
		{
			if (item == null)
			{
				Debug.LogError("ItemBeltVR can't remove a null item from belt. Aborting", this);
				return false;
			}
			int slotIndexForItem = GetSlotIndexForItem(item);
			if (slotIndexForItem >= 0 && slotIndexForItem < beltSnapPoints.Length)
			{
				beltSnapPoints[slotIndexForItem].UnsnapItem();
				return true;
			}
			return false;
		}

		public int GetSlotIndexForItem(ItemBase item)
		{
			if (item == null)
			{
				Debug.LogError("ItemBeltVR can't remove a null item from belt. Aborting", this);
				return -1;
			}
			for (int i = 0; i < beltSnapPoints.Length; i++)
			{
				ItemBase snappedItem = beltSnapPoints[i].SnappedItem;
				if (snappedItem != null && snappedItem == item)
				{
					return i;
				}
			}
			return -1;
		}

		public bool ForceAddItemToBelt(GameObject item, int slotIndex)
		{
			if (item == null)
			{
				Debug.LogError("ItemBeltVR can't add a null item.");
				return false;
			}
			if (slotIndex < 0 || slotIndex >= beltSnapPoints.Length)
			{
				return false;
			}
			ItemSnapPointBelt itemSnapPointBelt = beltSnapPoints[slotIndex];
			if (itemSnapPointBelt.SnappedItem != null)
			{
				return false;
			}
			itemSnapPointBelt.SnapItem(item, forced: true);
			return true;
		}

		public int? FirstFreeSlot()
		{
			for (int i = 0; i < beltSnapPoints.Length; i++)
			{
				if (beltSnapPoints[i].SnappedItem == null)
				{
					return i;
				}
			}
			return null;
		}

		public bool ControllerAlreadyTouchingOtherSlots(ControllerPointerDetectorBelt requestingDetector, bool isRight)
		{
			ControllerPointerDetectorBelt[] array = pointerDetectors;
			foreach (ControllerPointerDetectorBelt controllerPointerDetectorBelt in array)
			{
				if (!(controllerPointerDetectorBelt == requestingDetector) && controllerPointerDetectorBelt.IsTouchedByController(isRight))
				{
					return true;
				}
			}
			return false;
		}

		public bool AnySlotTouchedByController(bool isRight)
		{
			ControllerPointerDetectorBelt[] array = pointerDetectors;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].IsTouchedByController(isRight))
				{
					return true;
				}
			}
			return false;
		}

		public int GetBeltSlotIndex(ItemSnapPointBase slot)
		{
			ItemSnapPointBase[] array = beltSnapPoints;
			return Array.IndexOf(array, slot);
		}

		public ItemSnapPointBelt[] GetBeltSlots()
		{
			return beltSnapPoints;
		}

		public BeltSnapPointAdjuster[] GetBeltAdjusters()
		{
			return beltSlotAdjusters;
		}

		public void FireItemEquippedEvent(bool isRight)
		{
			this.ItemEquippedFromBelt?.Invoke((!isRight) ? SDK_BaseController.ControllerHand.Left : SDK_BaseController.ControllerHand.Right);
		}
	}
}
