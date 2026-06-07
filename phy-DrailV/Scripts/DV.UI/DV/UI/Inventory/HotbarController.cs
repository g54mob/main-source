using System;
using System.Collections;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class HotbarController : NullCheckingSingletonBehaviour<HotbarController>
	{
		private const int EQUIP_SLOT_INDEX = 0;

		private const float SELECTION_PREVENTION_TIME = 0.2f;

		private const float MOUSE_SENSITIVITY = 10f;

		private const float MOUSE_DEAD_ZONE = 0.05f;

		private const float ANIMATION_SMOOTHING = 30f;

		[Header("Debug")]
		public bool debugOpen;

		[NullCheck]
		public AHotbarInventoryProvider provider;

		[NullCheck]
		public Transform pointerTransform;

		[NullCheck]
		public RectTransform hotbarRoot;

		[SerializeField]
		[NullCheck]
		private Canvas fullInventoryCanvas;

		private Canvas mainCanvas;

		private Canvas hotbarCanvas;

		private HotbarSlot[] viewSlots;

		private DV.InventorySystem.Inventory inventory;

		private RectTransform pointerRect;

		private HotbarSlotPointerData pointerData;

		private float inventoryToggleTime;

		private int keyboardRequestedSlot = -1;

		public bool IsOpen { get; private set; }

		public bool LoadingFinished { get; private set; }

		public int SelectedSlot { get; private set; } = -1;

		public event Action OpenChanged;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private IEnumerator Start()
		{
			inventory = provider.Inventory;
			mainCanvas = GetComponent<Canvas>();
			hotbarCanvas = hotbarRoot.parent.GetComponent<Canvas>();
			viewSlots = mainCanvas.GetComponentsInChildren<HotbarSlot>();
			pointerRect = pointerTransform.GetComponent<RectTransform>();
			for (int i = 0; i < viewSlots.Length; i++)
			{
				viewSlots[i].gameObject.SetActive(InventoryUtils.IsValidHotbarIndex(i));
			}
			fullInventoryCanvas.enabled = false;
			float width = viewSlots[0].GetComponent<RectTransform>().rect.width;
			float upperLimit = width * 12f;
			pointerData = new HotbarSlotPointerData(width, upperLimit);
			while (!provider.IsGameInitialized)
			{
				yield return null;
			}
			yield return null;
			GameObject[] itemsArray = inventory.GetItemsArray();
			for (int j = 0; j < 36; j++)
			{
				if (!(itemsArray[j] == null))
				{
					HandleAddItem(j);
					RefreshSlot(j);
				}
			}
			GameObject equippedItemAtSlot = inventory.GetEquippedItemAtSlot(0);
			if (equippedItemAtSlot != null)
			{
				int num = inventory.IndexOf(equippedItemAtSlot);
				SelectedSlot = (InventoryUtils.IsValidHotbarIndex(num) ? num : 0);
			}
			SetupListeners(on: true);
			LoadingFinished = true;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				inventory.InventoryStatusChanged += OnInventoryStatusChanged;
				provider.HotbarSelectionChangedInBigInventory += OnSelectionChangedInBigInventory;
				return;
			}
			if ((bool)inventory)
			{
				inventory.InventoryStatusChanged -= OnInventoryStatusChanged;
			}
			provider.HotbarSelectionChangedInBigInventory -= OnSelectionChangedInBigInventory;
		}

		private void OnSelectionChangedInBigInventory(int slot)
		{
			if (InventoryUtils.IsValidHotbarIndex(slot))
			{
				UpdateSelectedSlot(slot, fireEvent: false);
			}
		}

		public void ReactToUnGrab(int slot)
		{
			RefreshSlot(slot);
		}

		public void ReactToGrab(int slot)
		{
			RefreshSlot(slot);
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState targetState, InventoryActionType targetActionType)
		{
			RefreshSlot(originState.slotIndex);
			RefreshSlot(targetState.slotIndex);
			if (originActionType.HasAnyIntFlag(InventoryActionType.Add) && !originActionType.HasAnyIntFlag(InventoryActionType.Destroy))
			{
				HandleAddItem(originState.slotIndex);
			}
			if (targetActionType.HasAnyIntFlag(InventoryActionType.Move | InventoryActionType.Swap))
			{
				if (targetActionType.HasAnyIntFlag(InventoryActionType.Move))
				{
					HandleMoveItem(targetState.item, originState.slotIndex, targetState.slotIndex);
				}
				else if (targetActionType.HasAnyIntFlag(InventoryActionType.Swap))
				{
					HandleSwapItem(originState.item, originState.slotIndex, targetState.item, targetState.slotIndex);
				}
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.Equip))
			{
				if (!InventoryUtils.IsValidHotbarIndex(originState.slotIndex))
				{
					return;
				}
				UpdateSelectedSlot(originState.slotIndex);
			}
			fullInventoryCanvas.enabled = hotbarCanvas.enabled && !inventory.HasFreeSlots();
		}

		private void HandleMoveItem(GameObject item, int originSlot, int targetSlot)
		{
			if (originSlot == SelectedSlot && InventoryUtils.IsValidHotbarIndex(targetSlot))
			{
				UpdateSelectedSlot(targetSlot);
			}
		}

		private void HandleSwapItem(GameObject originItem, int originSlot, GameObject targetItem, int targetSlot)
		{
			bool flag = InventoryUtils.IsValidHotbarIndex(targetSlot) && InventoryUtils.IsValidHotbarIndex(originSlot);
			if (originSlot == SelectedSlot && flag)
			{
				UpdateSelectedSlot(targetSlot);
			}
			else if (targetSlot == SelectedSlot && flag)
			{
				UpdateSelectedSlot(originSlot);
			}
		}

		private void HandleAddItem(int slot)
		{
			UpdateSlotHighlight(slot, slot == SelectedSlot);
		}

		public void UpdateSlotHighlight(int slot, bool highlighted)
		{
			if (InventoryUtils.IsValidHotbarIndex(slot))
			{
				viewSlots[slot].SetHighlight(highlighted);
			}
		}

		private void RefreshSlot(int slot)
		{
			if (InventoryUtils.IsValidHotbarIndex(slot))
			{
				viewSlots[slot].ResetSlotVisuals(inventory.PeekItemAtSlot(slot)?.GetComponent<IInventoryItemSpec>(), slot == SelectedSlot, inventory.GetSlotDroppedState(slot));
			}
		}

		public HotbarSlot GetSlot(int slot)
		{
			return viewSlots[slot];
		}

		private void Update()
		{
			if (Time.deltaTime <= 0f)
			{
				return;
			}
			if (!provider.IsHotbarAllowed)
			{
				if (hotbarCanvas.enabled)
				{
					IsOpen = false;
					hotbarCanvas.enabled = false;
					hotbarRoot.anchoredPosition = Vector2.up * (0f - hotbarRoot.sizeDelta.y);
					pointerTransform.gameObject.SetActive(value: false);
				}
				fullInventoryCanvas.enabled = !inventory.HasFreeSlots() && (IsOpen || provider.IsHotbarButtonHeld);
			}
			else
			{
				if (provider.IsTimePaused)
				{
					return;
				}
				bool hasValue = provider.SlotKey.HasValue;
				bool flag = provider.MouseScroll != 0;
				bool flag2 = Mathf.Abs(provider.GetMouseAxis().x) > 0.05f && Time.timeSinceLevelLoad - inventoryToggleTime > 0.2f;
				bool flag3 = debugOpen || provider.IsHotbarButtonHeld;
				int num = SelectedSlot;
				float num2 = pointerRect.anchoredPosition.x;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				if (hasValue)
				{
					flag4 = true;
					num = provider.SlotKey.Value;
					flag7 = true;
					keyboardRequestedSlot = num;
				}
				else if (IsOpen)
				{
					if (flag)
					{
						flag4 = true;
						num = SelectedSlot - provider.MouseScroll;
						if (num < 0)
						{
							num = 11;
						}
						else if (num >= 12)
						{
							num = 0;
						}
					}
					else if (flag2)
					{
						flag5 = true;
						float x = provider.GetMouseAxis().x;
						Vector2 anchoredPosition = pointerRect.anchoredPosition;
						anchoredPosition.x += x * 10f;
						if (anchoredPosition.x > pointerData.upperLimit)
						{
							anchoredPosition.x = pointerData.upperLimit;
						}
						else if (anchoredPosition.x < 0f)
						{
							anchoredPosition.x = 0f;
						}
						num2 = anchoredPosition.x;
					}
				}
				else if (SelectedSlot == -1)
				{
					flag4 = true;
					num = 0;
				}
				if (flag3 != IsOpen)
				{
					IsOpen = flag3;
					inventoryToggleTime = Time.timeSinceLevelLoad;
					provider.RequestSlowMouse(flag3);
					pointerTransform.gameObject.SetActive(flag3);
					flag6 = true;
					if (!flag3 && keyboardRequestedSlot != num)
					{
						flag7 = true;
					}
					keyboardRequestedSlot = -1;
				}
				if (flag4)
				{
					num2 = GetPointerPositionAtSlot(num);
				}
				else if (flag5)
				{
					num = GetSlotIndexForPointerPosition(num2);
				}
				for (int i = 0; i < 12; i++)
				{
					viewSlots[i].SetHighlight(i == num);
				}
				fullInventoryCanvas.enabled = hotbarCanvas.enabled && provider.IsHotbarButtonHeld && !inventory.HasFreeSlots();
				hotbarRoot.anchoredPosition = Vector2.up * Mathf.Lerp(hotbarRoot.anchoredPosition.y, IsOpen ? 0f : (0f - hotbarRoot.sizeDelta.y), Time.unscaledDeltaTime * 30f);
				hotbarCanvas.enabled = Mathf.Abs(hotbarRoot.anchoredPosition.y + hotbarRoot.sizeDelta.y) > 0.005f;
				pointerRect.anchoredPosition = new Vector2(num2, pointerRect.anchoredPosition.y);
				SelectedSlot = num;
				if (flag6)
				{
					try
					{
						this.OpenChanged?.Invoke();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				if (flag7)
				{
					provider.StashToggle(SelectedSlot);
				}
			}
		}

		private float GetPointerPositionAtSlot(int slot)
		{
			return (float)slot * pointerData.standardSlotWidth + pointerData.standardSlotWidth * 0.5f;
		}

		private void UpdateSelectedSlot(int slot, bool fireEvent = true)
		{
			SelectedSlot = slot;
			pointerRect.anchoredPosition = new Vector2(GetPointerPositionAtSlot(slot), pointerRect.anchoredPosition.y);
			if (fireEvent)
			{
				provider.OnSlotChanged(slot);
			}
		}

		public bool HasStashedItem()
		{
			if (InventoryUtils.IsValidHotbarIndex(SelectedSlot))
			{
				return inventory.HasItemAtSlot(SelectedSlot, includeDropped: false);
			}
			return false;
		}

		public int GetSlotIndexForPointerPosition(float pointerPosition)
		{
			return Mathf.Clamp(Mathf.FloorToInt(pointerPosition / pointerData.standardSlotWidth), 0, viewSlots.Length - 1);
		}

		public string GetLocalizedNameForItem(IInventoryItemSpec item)
		{
			return provider.GetLocalizedNameForItem(item);
		}
	}
}
