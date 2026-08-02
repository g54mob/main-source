using System.Collections.Generic;
using JUTPS.ArmorSystem;
using JUTPS.ItemSystem;
using JUTPS.WeaponSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JUTPS.InventorySystem.UI
{
	public class InventorySlotUI : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
	{
		public enum ItemArePlacedIn
		{
			AllBody = 0,
			RightHand = 1,
			LeftHand = 2
		}

		private Canvas canvas;

		private InventoryUIManager inventoryManager;

		private int mSlotIndex;

		[JUHeader("Settings")]
		public JUInventory inventory;

		public int ItemIDToDraw = -2;

		[JUHeader("Sequential Item Switch")]
		public bool DrawSequentialItem;

		public JUInventory.SequentialSlotsEnum SequentialToDraw;

		public bool SetSequentialOnDrop;

		[JUHeader("Visual and FX Settings")]
		public Image SlotItemImage;

		public Image SlotHealthBar;

		public Sprite ItemWithoutIconSprite;

		public Sprite EmptySlotSprite;

		public Text ItemQuantityText;

		public GameObject Outline;

		[JUHeader("Options Settings")]
		public bool EnableOptions = true;

		public bool AutoEquipOnDrop;

		public bool IsLootSlot;

		public string[] AllowItemsWithTags = new string[11]
		{
			"General", "Weapon", "Melee Weapon", "Primary Weapon", "Secundary Weapon", "Tertiary Weapon", "Hand Gun", "Hat", "TShirt", "Pants",
			"Shoes"
		};

		public bool AllowAnyItem;

		public GameObject OptionsPanel;

		public Button EquipButton;

		public Button UnequipButton;

		public Button UseButton;

		public Button DropButton;

		[JUHeader("States")]
		public bool IsEmpty = true;

		public bool IsDragging;

		public ItemArePlacedIn PlacedIn;

		public Item[] RespectiveItemList;

		private Item slotItem;

		private void Awake()
		{
			if (EquipButton != null)
			{
				EquipButton.onClick.AddListener(Equip);
			}
			if (UnequipButton != null)
			{
				UnequipButton.onClick.AddListener(Unequip);
			}
			if (UseButton != null)
			{
				UseButton.onClick.AddListener(Use);
			}
			if (DropButton != null)
			{
				DropButton.onClick.AddListener(Drop);
			}
		}

		private void Start()
		{
			inventoryManager = base.gameObject.GetComponentInParent<InventoryUIManager>();
			inventory = inventoryManager.TargetInventory;
			canvas = GetComponent<Canvas>();
			RespectiveItemList = inventory.AllItems;
			slotItem = CurrentSlotItem();
			mSlotIndex = ((inventoryManager.Slots.IndexOf(this) != -1) ? inventoryManager.Slots.IndexOf(this) : 0);
			RefreshSlot();
			DisableOverriding();
		}

		private void OnDisable()
		{
			Outline.SetActive(value: false);
		}

		private void OnEnable()
		{
			RefreshSlot();
		}

		public Item CurrentSlotItem()
		{
			if (inventory == null)
			{
				inventory = base.gameObject.GetComponentInParent<InventoryUIManager>().TargetInventory;
				_ = inventory == null;
				return null;
			}
			Item item = null;
			if (!DrawSequentialItem)
			{
				if (ItemIDToDraw < inventory.AllItems.Length && ItemIDToDraw > -1)
				{
					item = inventory.AllItems[ItemIDToDraw];
				}
			}
			else
			{
				item = inventory.GetSequentialSlotItem(SequentialToDraw);
				ItemIDToDraw = JUInventory.GetGlobalItemSwitchID(item, inventory);
			}
			return item;
		}

		public void ShowOptions()
		{
			RefreshSlot();
			if (ItemIDToDraw < 0 || !EnableOptions)
			{
				OptionsPanel.SetActive(value: false);
				return;
			}
			OptionsPanel.SetActive(value: true);
			if (slotItem != null)
			{
				if (slotItem.ItemQuantity <= 0 || !slotItem.Unlocked)
				{
					OptionsPanel.SetActive(value: false);
				}
				if (slotItem is HoldableItem || slotItem is Armor)
				{
					UseButton.gameObject.SetActive(value: false);
					if (!slotItem.gameObject.activeInHierarchy)
					{
						EquipButton.gameObject.SetActive(value: true);
						UnequipButton.gameObject.SetActive(value: false);
					}
					else
					{
						UnequipButton.gameObject.SetActive(value: true);
						EquipButton.gameObject.SetActive(value: false);
					}
				}
				else
				{
					UseButton.gameObject.SetActive(value: true);
					UnequipButton.gameObject.SetActive(value: false);
					EquipButton.gameObject.SetActive(value: false);
				}
			}
			else
			{
				OptionsPanel.SetActive(value: false);
			}
		}

		public void HideOptions()
		{
			OptionsPanel.SetActive(value: false);
		}

		public void RefreshSlot()
		{
			if (EmptySlotSprite == null)
			{
				EmptySlotSprite = SlotItemImage.sprite;
			}
			slotItem = CurrentSlotItem();
			SlotItemImage.sprite = EmptySlotSprite;
			if (inventory == null)
			{
				inventory = base.gameObject.GetComponentInParent<InventoryUIManager>().TargetInventory;
			}
			if (inventory == null)
			{
				return;
			}
			if (SlotHealthBar != null && slotItem == null)
			{
				SlotHealthBar.gameObject.SetActive(value: false);
			}
			if (SlotHealthBar != null)
			{
				if (slotItem != null)
				{
					if (slotItem.Unlocked)
					{
						SlotHealthBar.gameObject.SetActive(value: true);
						DoHealthBarFillAmout(slotItem, SlotHealthBar);
					}
					else
					{
						SlotHealthBar.gameObject.SetActive(value: false);
					}
				}
				else
				{
					SlotHealthBar.gameObject.SetActive(value: false);
				}
			}
			if (ItemQuantityText != null)
			{
				ItemQuantityText.gameObject.SetActive(value: false);
			}
			if (slotItem == null || ItemIDToDraw < 0 || ItemIDToDraw > RespectiveItemList.Length)
			{
				IsEmpty = true;
				return;
			}
			if (!slotItem.Unlocked)
			{
				IsEmpty = true;
				return;
			}
			if (!IsItemAllowedOnThisSlot(slotItem))
			{
				MoveToACloserSlot(this, inventoryManager.Slots);
				return;
			}
			if (CurrentSlotItem().ItemIcon == null)
			{
				SlotItemImage.sprite = ItemWithoutIconSprite;
				return;
			}
			if (!slotItem.Unlocked || slotItem.ItemQuantity <= 0)
			{
				SlotHealthBar.gameObject.SetActive(value: false);
				SlotItemImage.sprite = EmptySlotSprite;
				IsEmpty = false;
				return;
			}
			if (ItemQuantityText != null)
			{
				ItemQuantityText.gameObject.SetActive(value: true);
				if (slotItem is Weapon)
				{
					ItemQuantityText.text = (slotItem as Weapon).BulletsAmounts + "/" + (slotItem as Weapon).TotalBullets;
				}
				else
				{
					ItemQuantityText.text = slotItem.ItemQuantity + "/" + slotItem.MaxItemQuantity;
				}
			}
			if (slotItem.ItemIcon == null)
			{
				SlotItemImage.sprite = ItemWithoutIconSprite;
			}
			else
			{
				SlotItemImage.sprite = slotItem.ItemIcon;
			}
		}

		public void Equip()
		{
			HideOptions();
			inventory.EquipItem(ItemIDToDraw);
			Debug.Log("Equiped " + slotItem.name);
		}

		public void Unequip()
		{
			HideOptions();
			inventory.UnequipItem(ItemIDToDraw);
			RefreshSlot();
			if (slotItem != null)
			{
				Debug.Log("Unequiped " + slotItem.name);
			}
		}

		public void Use()
		{
			HideOptions();
			slotItem.UseItem();
			Debug.Log("Used " + slotItem.name);
		}

		public void Drop()
		{
			HideOptions();
			inventory.DropItem(ItemIDToDraw);
			ItemIDToDraw = -1;
			RefreshSlot();
		}

		public void DoHealthBarFillAmout(Item item, Image healthBarImage, bool ChangeColor = true, Color FullHPColor = default(Color), Color NoHPColor = default(Color))
		{
			if (item == null)
			{
				return;
			}
			float num = 0f;
			float num2 = 1f;
			if ((object)item != null)
			{
				num = item.ItemQuantity;
				num2 = item.MaxItemQuantity;
			}
			if (item is Armor)
			{
				num = (item as Armor).Health;
				num2 = (item as Armor).MaxHealth;
			}
			if (item is MeleeWeapon)
			{
				num = (item as MeleeWeapon).MeleeWeaponHealth;
				num2 = 100f;
			}
			if (item is Weapon)
			{
				num = (item as Weapon).BulletsAmounts;
				num2 = (item as Weapon).BulletsPerMagazine;
			}
			healthBarImage.fillAmount = Mathf.Lerp(0f, 1f, num / num2);
			if (ChangeColor)
			{
				if (FullHPColor == Color.clear)
				{
					FullHPColor = Color.green;
				}
				if (NoHPColor == Color.clear)
				{
					NoHPColor = Color.red;
				}
				healthBarImage.color = Color.Lerp(NoHPColor, FullHPColor, num / num2);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			EnableOverriding();
			Outline.SetActive(value: false);
			HideOptions();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Outline.SetActive(value: true);
			ShowOptions();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Outline.SetActive(value: false);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Outline.SetActive(value: false);
			DisableOverriding();
			HideOptions();
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (ItemIDToDraw >= 0 && !(slotItem == null) && slotItem.Unlocked)
			{
				EnableOverriding();
				SlotItemImage.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (slotItem == null)
			{
				SlotItemImage.rectTransform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
				Outline.SetActive(value: true);
			}
			else if (slotItem.Unlocked)
			{
				SlotItemImage.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
				SlotItemImage.CrossFadeAlpha(0.7f, 0.3f, ignoreTimeScale: true);
				Outline.SetActive(value: true);
				EnableOverriding();
				IsDragging = true;
			}
			else
			{
				SlotItemImage.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
				SlotItemImage.CrossFadeAlpha(0.2f, 0.3f, ignoreTimeScale: true);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			SlotItemImage.rectTransform.anchoredPosition = Vector2.zero;
			SlotItemImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			SlotItemImage.CrossFadeAlpha(1f, 0.2f, ignoreTimeScale: true);
			IsDragging = false;
			Outline.SetActive(value: false);
			DisableOverriding();
			HideOptions();
		}

		public void OnDrop(PointerEventData eventData)
		{
			HideOptions();
			InventorySlotUI componentInParent = eventData.pointerDrag.GetComponentInParent<InventorySlotUI>();
			if (componentInParent != null)
			{
				if (componentInParent.ItemIDToDraw <= -1 || componentInParent.slotItem == null || !componentInParent.slotItem.Unlocked)
				{
					return;
				}
				if (componentInParent.inventory != inventory)
				{
					if (SetSequentialOnDrop)
					{
						inventory.SetSequentialSlotItem(SequentialToDraw, componentInParent.CurrentSlotItem());
					}
					MoveItemDrawPropertyToThisSlot(componentInParent.slotItem.name);
					PickAndUnlockLootItem(componentInParent.slotItem.name, componentInParent.inventory);
					inventoryManager.RefreshAllSlots();
					if (AutoEquipOnDrop && !EnableOptions)
					{
						Equip();
					}
				}
				else if (IsItemAllowedOnThisSlot(componentInParent.CurrentSlotItem()))
				{
					if (SetSequentialOnDrop)
					{
						inventory.SetSequentialSlotItem(SequentialToDraw, componentInParent.CurrentSlotItem());
					}
					TransferSlotData(componentInParent, this);
					inventoryManager.RefreshAllSlots();
					if (AutoEquipOnDrop && !EnableOptions)
					{
						Equip();
					}
					return;
				}
			}
			Debug.Log("On Droped");
		}

		private void PickAndUnlockLootItem(string itemName, JUInventory lootInventory)
		{
			if (itemName == "" || inventory == lootInventory || !lootInventory.IsALoot)
			{
				return;
			}
			Item item = null;
			Item itemOnLoot = null;
			Item[] allItems = inventory.AllItems;
			foreach (Item item2 in allItems)
			{
				if (item2.name == itemName)
				{
					item = item2;
				}
			}
			allItems = lootInventory.AllItems;
			foreach (Item item3 in allItems)
			{
				if (item3.name == itemName)
				{
					itemOnLoot = item3;
				}
			}
			if (item == null)
			{
				Debug.Log("Não foi possível encontrar o item: " + itemName);
			}
			else
			{
				inventory.GetLootItem(item, itemOnLoot);
			}
		}

		private void MoveItemDrawPropertyToThisSlot(string ItemName)
		{
			foreach (InventorySlotUI slot in inventoryManager.Slots)
			{
				if (slot.slotItem != null && slot.slotItem.name == ItemName)
				{
					TransferSlotData(slot, this);
					RefreshSlot();
					slot.RefreshSlot();
				}
			}
		}

		private void EnableOverriding()
		{
			canvas.overrideSorting = true;
			canvas.sortingOrder = 20;
		}

		private void DisableOverriding()
		{
			canvas.overrideSorting = false;
			canvas.sortingOrder = 0;
		}

		public bool IsItemAllowedOnThisSlot(Item itemSlot)
		{
			bool result = false;
			string[] allowItemsWithTags = AllowItemsWithTags;
			foreach (string text in allowItemsWithTags)
			{
				if (itemSlot != null && itemSlot.ItemFilterTag == text)
				{
					result = true;
				}
			}
			if (AllowAnyItem)
			{
				result = true;
			}
			return result;
		}

		public static void TransferSlotData(InventorySlotUI SlotA, InventorySlotUI SlotB, List<InventorySlotUI> slotList = null)
		{
			if (SlotA.RespectiveItemList != SlotB.RespectiveItemList || SlotA.PlacedIn != SlotB.PlacedIn)
			{
				SlotB.PlacedIn = SlotA.PlacedIn;
				SlotB.RespectiveItemList = SlotA.RespectiveItemList;
			}
			if (SlotA.AutoEquipOnDrop)
			{
				SlotA.Unequip();
			}
			int itemIDToDraw = SlotA.ItemIDToDraw;
			SlotA.ItemIDToDraw = SlotB.ItemIDToDraw;
			SlotB.ItemIDToDraw = itemIDToDraw;
			if (SlotA.ItemIDToDraw == SlotB.ItemIDToDraw)
			{
				ClearSlot(SlotA);
			}
			if (SlotA.DrawSequentialItem)
			{
				SlotA.inventory.SetSequentialSlotItem(SlotA.SequentialToDraw, null);
			}
			SlotB.RefreshSlot();
			SlotA.RefreshSlot();
			if (slotList != null)
			{
				for (int i = 0; i < slotList.Count - 1; i++)
				{
					if (slotList[i].ItemIDToDraw == SlotB.ItemIDToDraw && slotList[i] != SlotB)
					{
						ClearSlot(slotList[i]);
						Debug.Log("Cleaned a duplicated Slot");
					}
				}
			}
			Debug.Log("Tranferred data from " + SlotA.gameObject.name + " to " + SlotB.gameObject.name);
		}

		public static void ClearSlot(InventorySlotUI slotToClear)
		{
			slotToClear.ItemIDToDraw = -1;
			slotToClear.IsEmpty = true;
		}

		public static void MoveToACloserSlot(InventorySlotUI SlotToMoveData, List<InventorySlotUI> slotList)
		{
			if (SlotToMoveData.CurrentSlotItem() == null)
			{
				return;
			}
			for (int i = SlotToMoveData.mSlotIndex; i < slotList.Count - 1; i++)
			{
				if (slotList[i].CurrentSlotItem() == null && slotList[i].IsItemAllowedOnThisSlot(SlotToMoveData.slotItem))
				{
					TransferSlotData(SlotToMoveData, slotList[i]);
					Debug.Log("an item cannot stay in the slot, so it has been moved to a next slot");
					return;
				}
			}
			for (int num = SlotToMoveData.mSlotIndex; num > 0; num--)
			{
				if (slotList[num].CurrentSlotItem() == null && slotList[num].IsItemAllowedOnThisSlot(SlotToMoveData.slotItem))
				{
					TransferSlotData(SlotToMoveData, slotList[num]);
					Debug.Log("an item cannot stay in the slot, so it has been moved to a previous slot");
					return;
				}
			}
			SlotToMoveData.Drop();
			Debug.Log("an item can't stay in the slot, but it couldn't be moved to another one, so it was dropped");
		}
	}
}
