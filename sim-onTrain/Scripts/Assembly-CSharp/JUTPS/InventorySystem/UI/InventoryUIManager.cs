using System.Collections.Generic;
using System.Linq;
using JUTPS.CameraSystems;
using JUTPS.ItemSystem;
using JUTPS.JUInputSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.InventorySystem.UI
{
	public class InventoryUIManager : MonoBehaviour
	{
		[JUHeader("Inventory Settings")]
		public GameObject InventoryScreen;

		public JUInventory TargetInventory;

		public InventorySlotUI SlotPrefab;

		public bool HideCursorWhenExitInventory;

		public bool LockCursorWhenExitInventory;

		public bool ShowCursorWhenOpenInventory = true;

		[JUHeader("Slots Settings")]
		public bool FilterLeftHandItems = true;

		public int SlotsQuantity = -1;

		public GridLayoutGroup InventoryScrollViewContent;

		public List<InventorySlotUI> Slots = new List<InventorySlotUI>();

		private RectTransform inventoryScrollViewRectTransform;

		[JUHeader("Loot View Settings")]
		public bool IsLootView;

		public Transform Player;

		public string PlayerTag = "Player";

		public LayerMask CharacterLayer;

		public float CheckLootRadius = 1f;

		private JUInventory LootToGetItems;

		private void Awake()
		{
			if (InventoryScrollViewContent != null)
			{
				inventoryScrollViewRectTransform = InventoryScrollViewContent.GetComponent<RectTransform>();
			}
			if (IsLootView)
			{
				if (Player == null && GameObject.FindGameObjectWithTag(PlayerTag) != null)
				{
					Player = GameObject.FindGameObjectWithTag(PlayerTag).transform;
				}
				return;
			}
			if (TargetInventory == null)
			{
				JUInventory component = GameObject.FindGameObjectWithTag("Player").GetComponent<JUInventory>();
				TargetInventory = component;
			}
			if (TargetInventory == null)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			if (Slots.Count == 0)
			{
				CreateInventorySlots(ref Slots, SlotsQuantity, TargetInventory, SlotPrefab, InventoryScrollViewContent);
				SetSlots(ref Slots, TargetInventory);
			}
			else
			{
				SetSlots(ref Slots, TargetInventory);
			}
			InvokeRepeating("RefreshInventory", 1f, 1f);
			if (Slots.Count > 0)
			{
				RenameAllSlotWithIndex(Slots);
			}
		}

		private void Update()
		{
			if (InventoryScreen == null || InventoryScrollViewContent == null)
			{
				return;
			}
			inventoryScrollViewRectTransform.sizeDelta = new Vector3(inventoryScrollViewRectTransform.sizeDelta.x, (float)Slots.Count * InventoryScrollViewContent.cellSize.y);
			if (IsLootView)
			{
				if (Player == null)
				{
					return;
				}
				Collider[] array = Physics.OverlapBox(Player.position, new Vector3(CheckLootRadius, CheckLootRadius, CheckLootRadius), Quaternion.identity, CharacterLayer);
				if (array.Length > 1)
				{
					Collider[] array2 = array;
					foreach (Collider collider in array2)
					{
						if (collider.gameObject != Player.gameObject && collider.gameObject != null && LootToGetItems == null && collider.TryGetComponent<JUInventory>(out var component) && component.IsALoot && component != LootToGetItems)
						{
							LootToGetItems = component;
							TargetInventory = component;
							OpenInventory();
							CreateInventorySlots(ref Slots, component.AllItems.Length, component, SlotPrefab, InventoryScrollViewContent);
							SetActiveSlotsOptions(enabled: false);
						}
						if (collider.gameObject == null)
						{
							ClearAllSlots();
							LootToGetItems = null;
							ExitInventory();
						}
					}
				}
				else if (InventoryScreen.activeInHierarchy)
				{
					ClearAllSlots();
					LootToGetItems = null;
					ExitInventory();
				}
			}
			else if (JUInput.GetButtonDown(JUInput.Buttons.OpenInventory))
			{
				if (!InventoryScreen.activeInHierarchy)
				{
					OpenInventory();
				}
				else
				{
					ExitInventory();
				}
			}
		}

		public void OpenInventory()
		{
			if (!(InventoryScreen == null))
			{
				InventoryScreen.SetActive(value: true);
				if (!IsLootView && ShowCursorWhenOpenInventory)
				{
					JUCameraController.LockMouse(Lock: false, Hide: false);
				}
			}
		}

		public void ExitInventory()
		{
			if (!(InventoryScreen == null))
			{
				InventoryScreen.SetActive(value: false);
				if (!IsLootView)
				{
					JUCameraController.LockMouse(LockCursorWhenExitInventory, HideCursorWhenExitInventory);
				}
			}
		}

		public static void CreateInventorySlots(ref List<InventorySlotUI> SlotsList, int SlotQuantity, JUInventory inventory, InventorySlotUI slotPrefab, GridLayoutGroup scrollViewContentGridLayout)
		{
			if (SlotQuantity <= 0)
			{
				for (int i = 0; i < inventory.AllItems.Length; i++)
				{
					InventorySlotUI item = InstantiateSlot(slotPrefab, InventorySlotUI.ItemArePlacedIn.AllBody, i, scrollViewContentGridLayout.transform);
					SlotsList.Add(item);
				}
			}
			else
			{
				for (int j = 0; j < SlotQuantity; j++)
				{
					InventorySlotUI item2 = InstantiateSlot(slotPrefab, InventorySlotUI.ItemArePlacedIn.AllBody, j, scrollViewContentGridLayout.transform);
					SlotsList.Add(item2);
				}
			}
			RenameAllSlotWithIndex(SlotsList);
		}

		private static InventorySlotUI InstantiateSlot(InventorySlotUI SlotPrefab, InventorySlotUI.ItemArePlacedIn PlacedIn, int IDToDraw, Transform parent)
		{
			InventorySlotUI inventorySlotUI = Object.Instantiate(SlotPrefab, parent);
			inventorySlotUI.PlacedIn = PlacedIn;
			inventorySlotUI.ItemIDToDraw = IDToDraw;
			return inventorySlotUI;
		}

		private static void RenameAllSlotWithIndex(List<InventorySlotUI> SlotsList)
		{
			int num = 0;
			foreach (InventorySlotUI Slots in SlotsList)
			{
				Slots.gameObject.name = "Slot " + num;
				num++;
			}
		}

		public static void CreateInventorySlots(int SlotQuantity, InventorySlotUI slotPrefab, GridLayoutGroup scrollViewContentGridLayout)
		{
			if (SlotQuantity > 0)
			{
				for (int i = 0; i < SlotQuantity; i++)
				{
					Object.Instantiate(slotPrefab, scrollViewContentGridLayout.transform).ItemIDToDraw = -1;
				}
			}
		}

		public static void SetSlots(ref List<InventorySlotUI> SlotsList, JUInventory inventory)
		{
			for (int i = 0; i < inventory.AllItems.Length; i++)
			{
				SlotsList[i].ItemIDToDraw = i;
				SlotsList[i].RefreshSlot();
			}
		}

		public void SetActiveSlotsOptions(bool enabled)
		{
			foreach (InventorySlotUI slot in Slots)
			{
				slot.HideOptions();
				slot.EnableOptions = enabled;
			}
		}

		public void RefreshAllSlots()
		{
			foreach (InventorySlotUI slot in Slots)
			{
				slot.RefreshSlot();
				foreach (InventorySlotUI slot2 in Slots)
				{
					if (slot != slot2 && slot.ItemIDToDraw == slot2.ItemIDToDraw)
					{
						slot2.ItemIDToDraw = -2;
						slot2.RefreshSlot();
					}
				}
			}
			SetupNonDrawedItemsInSlots(GetNonDrawedItems(TargetInventory.AllItems, Slots, FilterLeftHandItems), this);
		}

		public static void SetupNonDrawedItemsInSlots(List<Item> nonDrawedItems, InventoryUIManager inventory)
		{
			if (nonDrawedItems.Count == 0 || inventory == null || inventory.Slots.Count == 0)
			{
				return;
			}
			foreach (Item nonDrawedItem in nonDrawedItems)
			{
				InventorySlotUI firstEmptySlot = GetFirstEmptySlot(inventory.Slots);
				if (firstEmptySlot == null)
				{
					break;
				}
				firstEmptySlot.ItemIDToDraw = JUInventory.GetGlobalItemSwitchID(nonDrawedItem, inventory.TargetInventory);
				firstEmptySlot.RefreshSlot();
				firstEmptySlot.IsEmpty = false;
			}
		}

		public static List<Item> GetNonDrawedItems(Item[] items, List<InventorySlotUI> slots, bool filterLeftHandItems)
		{
			List<Item> list = items.ToList();
			foreach (Item item in items)
			{
				if (item is HoldableItem && filterLeftHandItems)
				{
					if ((item as HoldableItem).IsLeftHandItem)
					{
						list.Remove(item);
					}
					else if (IsItemDrawingInSomeSlots(item, slots, filterLeftHandItems))
					{
						list.Remove(item);
					}
				}
				else if (IsItemDrawingInSomeSlots(item, slots, filterLeftHandItems))
				{
					list.Remove(item);
				}
			}
			return list;
		}

		public static bool IsItemDrawingInSomeSlots(Item item, List<InventorySlotUI> slots, bool filterLeftHandItems)
		{
			bool result = false;
			InventorySlotUI[] array = slots.ToArray();
			foreach (InventorySlotUI inventorySlotUI in array)
			{
				if (filterLeftHandItems)
				{
					if (item is HoldableItem)
					{
						if ((item as HoldableItem).IsLeftHandItem)
						{
							return false;
						}
						if (item == inventorySlotUI.CurrentSlotItem())
						{
							return true;
						}
					}
					else if (item == inventorySlotUI.CurrentSlotItem())
					{
						return true;
					}
				}
				else if (item == inventorySlotUI.CurrentSlotItem())
				{
					return true;
				}
			}
			return result;
		}

		public static InventorySlotUI GetFirstEmptySlot(List<InventorySlotUI> slots)
		{
			for (int i = 0; i < slots.Count; i++)
			{
				if (slots[i].ItemIDToDraw < 0)
				{
					return slots[i];
				}
			}
			Debug.LogWarning("Cannot find an empty slot in the list");
			return null;
		}

		public List<InventorySlotUI> GetSlots()
		{
			new List<InventorySlotUI>();
			return base.gameObject.GetComponentsInChildren<InventorySlotUI>().ToList();
		}

		public void ClearAllSlots()
		{
			foreach (InventorySlotUI slot in Slots)
			{
				Object.Destroy(slot.gameObject);
			}
			Slots.Clear();
		}

		public static void EmptyAllSlots(List<InventorySlotUI> SlotList)
		{
			foreach (InventorySlotUI Slot in SlotList)
			{
				Slot.ItemIDToDraw = -2;
				Slot.RefreshSlot();
			}
		}

		public void FilterSlots(List<InventorySlotUI> slotList)
		{
			foreach (InventorySlotUI item in slotList.ToList())
			{
				if (item.CurrentSlotItem() is HoldableItem && (item.CurrentSlotItem() as HoldableItem).IsLeftHandItem)
				{
					item.ItemIDToDraw = -2;
					item.RefreshSlot();
				}
			}
		}

		public static void Move<T>(List<T> list, int oldIndex, int newIndex)
		{
			T item = list[oldIndex];
			list.RemoveAt(oldIndex);
			list.Insert(newIndex, item);
		}

		public void RefreshInventory()
		{
			RefreshAllSlots();
			if (FilterLeftHandItems)
			{
				FilterSlots(Slots);
			}
		}
	}
}
