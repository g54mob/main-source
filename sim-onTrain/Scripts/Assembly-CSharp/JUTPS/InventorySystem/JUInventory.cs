using System;
using JUTPS.ArmorSystem;
using JUTPS.CharacterBrain;
using JUTPS.ItemSystem;
using JUTPS.JUInputSystem;
using JUTPS.WeaponSystem;
using JUTPSEditor.JUHeader;
using Mirror;
using UnityEngine;

namespace JUTPS.InventorySystem
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/Inventory")]
	public class JUInventory : NetworkBehaviour
	{
		public enum SequentialSlotsEnum
		{
			first = 0,
			second = 1,
			third = 2,
			fourth = 3,
			fifth = 4,
			sixth = 5,
			seventh = 6,
			eighth = 7,
			ninth = 8,
			tenth = 9
		}

		[Serializable]
		public class SequentialSlot
		{
			public SequentialSlotsEnum SelectedSlot;

			public Item ItemInThisSlot;

			public SequentialSlot(SequentialSlotsEnum slot, Item itemToSlot)
			{
				SelectedSlot = slot;
				ItemInThisSlot = itemToSlot;
			}
		}

		private JUCharacterBrain JUCharacter;

		[JUHeader("Settings")]
		public bool UpdateOnBodyItemsVisibility;

		public bool DisableAllItemsOnStart = true;

		public bool IsALoot;

		[JUHeader("Items")]
		public HoldableItem[] HoldableItensRightHand;

		public HoldableItem[] HoldableItensLeftHand;

		[HideInInspector]
		public HoldableItem[] AllHoldableItems;

		public Item[] AllItems;

		[JUHeader("Sequential Items")]
		public SequentialSlot[] SequenceSlot = new SequentialSlot[10]
		{
			new SequentialSlot(SequentialSlotsEnum.first, null),
			new SequentialSlot(SequentialSlotsEnum.second, null),
			new SequentialSlot(SequentialSlotsEnum.third, null),
			new SequentialSlot(SequentialSlotsEnum.fourth, null),
			new SequentialSlot(SequentialSlotsEnum.fifth, null),
			new SequentialSlot(SequentialSlotsEnum.sixth, null),
			new SequentialSlot(SequentialSlotsEnum.seventh, null),
			new SequentialSlot(SequentialSlotsEnum.eighth, null),
			new SequentialSlot(SequentialSlotsEnum.ninth, null),
			new SequentialSlot(SequentialSlotsEnum.tenth, null)
		};

		[JUHeader("PickUp System")]
		public bool EnablePickup = true;

		public LayerMask ItemLayer;

		public Vector3 CheckerOffset;

		public float CheckerRadious = 1f;

		public bool UseDefaultInputToPickUp = true;

		public bool AutoEquipPickedUpItems = true;

		[Range(0f, 1f)]
		public float HoldTimeToPickUp = 0.1f;

		private float CurrentHoldTimeToPickUp;

		private float CurrentTimeToDisablePickingUpState;

		[HideInInspector]
		public Item ItemToPickUp;

		[HideInInspector]
		public Collider[] ItemsAround;

		[HideInInspector]
		public Weapon[] WeaponsRightHand;

		[HideInInspector]
		public Weapon[] WeaponsLeftHand;

		[HideInInspector]
		public HoldableItem HoldableItemInUseInRightHand;

		[HideInInspector]
		public HoldableItem HoldableItemInUseInLeftHand;

		[HideInInspector]
		public Weapon WeaponInUseInRightHand;

		[HideInInspector]
		public Weapon WeaponInUseInLeftHand;

		[HideInInspector]
		public MeleeWeapon MeleeWeaponInUseInRightHand;

		[HideInInspector]
		public MeleeWeapon MeleeWeaponInUseInLeftHand;

		[HideInInspector]
		public int CurrentRightHandItemID = -1;

		[HideInInspector]
		public int CurrentLeftHandItemID = -1;

		[JUHeader("States")]
		public bool IsItemSelected;

		public bool DualWielding;

		public bool IsPickingItem;

		public bool isPickedEmpty;

		[HideInInspector]
		public ItemType equipedItemType = ItemType.Empty;

		private GameObject lastEquippedItem;

		private void Start()
		{
			if (ItemLayer.value == 0)
			{
				ItemLayer = LayerMask.GetMask("Item");
			}
			JUCharacter = GetComponent<JUCharacterBrain>();
			SetupItens();
			CorrectSwitchIDs(HoldableItensLeftHand);
			CorrectSwitchIDs(HoldableItensRightHand);
			Item[] allItems = AllItems;
			for (int i = 0; i < allItems.Length; i++)
			{
				DisableItemPhysics(allItems[i].gameObject);
			}
			if (!DisableAllItemsOnStart)
			{
				return;
			}
			allItems = AllItems;
			foreach (Item item in allItems)
			{
				if (item is HoldableItem)
				{
					(item as HoldableItem).RefreshItemDependencies();
				}
				item.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			CheckItemsAround();
			if (HoldableItemInUseInRightHand != null || HoldableItemInUseInLeftHand != null)
			{
				IsItemSelected = true;
			}
			if (HoldableItemInUseInRightHand != null && HoldableItemInUseInLeftHand != null)
			{
				DualWielding = true;
			}
			if (HoldableItemInUseInLeftHand != null && (HoldableItemInUseInLeftHand.ItemQuantity == 0 || !HoldableItemInUseInLeftHand.Unlocked))
			{
				UnequipItem(GetGlobalItemSwitchID(HoldableItemInUseInLeftHand, this));
			}
			if (HoldableItemInUseInRightHand != null && (HoldableItemInUseInRightHand.ItemQuantity == 0 || !HoldableItemInUseInRightHand.Unlocked))
			{
				UnequipItem(GetGlobalItemSwitchID(HoldableItemInUseInRightHand, this));
			}
			if (JUCharacter != null && JUCharacter.IsDead && !IsALoot)
			{
				IsALoot = true;
			}
		}

		[ContextMenu(" >>> Setup Itens", false, 100)]
		public void SetupItens()
		{
			if (IsALoot)
			{
				AllHoldableItems = GetComponentsInChildren<HoldableItem>();
				HoldableItensLeftHand = GetAllItemsOnCharacterHand(base.gameObject, RightHand: false);
				HoldableItensRightHand = GetAllItemsOnCharacterHand(base.gameObject);
				AllItems = GetComponentsInChildren<Item>();
				return;
			}
			if (JUCharacter == null)
			{
				JUCharacter = GetComponent<JUCharacterBrain>();
			}
			if (JUCharacter != null)
			{
				if (JUCharacter.anim == null)
				{
					JUCharacter.anim = GetComponent<Animator>();
				}
				if (!(JUCharacter.anim != null))
				{
					return;
				}
				if (JUCharacter.anim.GetBoneTransform(HumanBodyBones.RightHand) == null || JUCharacter.anim.GetBoneTransform(HumanBodyBones.RightHand) == null)
				{
					if (IsInvoking("SetupItens"))
					{
						Debug.LogWarning("Unable to setup items on this character on game start as there was a problem with the character's rig, inventory will try again soon");
						Invoke("SetupItens", 0.1f);
					}
				}
				else
				{
					AllHoldableItems = GetComponentsInChildren<HoldableItem>();
					HoldableItensLeftHand = GetAllItemsOnCharacterHand(base.gameObject, RightHand: false);
					HoldableItensRightHand = GetAllItemsOnCharacterHand(base.gameObject);
					AllItems = GetComponentsInChildren<Item>();
				}
			}
			else
			{
				Debug.LogError("No JU Character Controller/Brain");
			}
		}

		public static void CorrectSwitchIDs(HoldableItem[] ItemsArray)
		{
			if (ItemsArray == null)
			{
				return;
			}
			for (int i = 0; i < ItemsArray.Length; i++)
			{
				if (ItemsArray[i].ItemSwitchID != i)
				{
					ItemsArray[i].ItemSwitchID = i;
				}
			}
		}

		private void CheckItemsAround()
		{
			if (!EnablePickup || (double)CheckerRadious < 0.0001)
			{
				return;
			}
			ItemsAround = Physics.OverlapSphere(base.transform.TransformPoint(CheckerOffset), 1f, ItemLayer);
			if (ItemsAround.Length != 0 && ItemToPickUp == null)
			{
				ItemToPickUp = ((ItemsAround[0].GetComponent<Item>() == null) ? null : ItemsAround[0].GetComponent<Item>());
			}
			if (ItemToPickUp != null && ItemsAround.Length == 0)
			{
				ItemToPickUp = null;
			}
			if (JUInput.GetButton(JUInput.Buttons.PickupButton) && ItemToPickUp != null)
			{
				CurrentHoldTimeToPickUp += Time.deltaTime;
				if (CurrentHoldTimeToPickUp >= HoldTimeToPickUp)
				{
					Debug.Log("Trying pickup");
					PickUp();
				}
			}
			if (IsPickingItem)
			{
				CurrentTimeToDisablePickingUpState += Time.deltaTime;
				if (CurrentTimeToDisablePickingUpState >= 0.4f)
				{
					IsPickingItem = false;
				}
			}
			else
			{
				CurrentTimeToDisablePickingUpState = 0f;
			}
		}

		public static HoldableItem[] GetAllItemsOnCharacterHand(GameObject character, bool RightHand = true)
		{
			Animator component = character.GetComponent<Animator>();
			if (component == null)
			{
				Debug.LogError("Unable to find items in hands because there is no animator");
				return null;
			}
			if (!component.isHuman)
			{
				Debug.LogError("Unable to find items in hands because the animator is not a humanoid");
				return null;
			}
			if (component.GetBoneTransform(HumanBodyBones.RightHand) == null)
			{
				Debug.LogWarning("Unable to find items in hands because the animator is not a humanoid");
				return null;
			}
			return (RightHand ? component.GetBoneTransform(HumanBodyBones.RightHand) : component.GetBoneTransform(HumanBodyBones.LeftHand)).GetComponentsInChildren<HoldableItem>();
		}

		public static void DisableItemPhysics(GameObject item)
		{
			Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
			Rigidbody[] componentsInChildren2 = item.GetComponentsInChildren<Rigidbody>();
			Collider[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			Rigidbody[] array2 = componentsInChildren2;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].isKinematic = true;
			}
		}

		public static void EnableItemPhysic(GameObject item)
		{
			Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
			Rigidbody[] componentsInChildren2 = item.GetComponentsInChildren<Rigidbody>();
			Collider[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
			Rigidbody[] array2 = componentsInChildren2;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].isKinematic = false;
			}
		}

		public static void PickUpNearbyItem(JUInventory InventoryToAddItem)
		{
			if (InventoryToAddItem.ItemToPickUp != null)
			{
				if (InventoryToAddItem.ItemToPickUp is HoldableItem)
				{
					HoldableItem component = InventoryToAddItem.ItemToPickUp.GetComponent<HoldableItem>();
					HoldableItem[] allHoldableItems = InventoryToAddItem.AllHoldableItems;
					foreach (HoldableItem holdableItem in allHoldableItems)
					{
						if (holdableItem.ItemName == component.ItemName && holdableItem.IsLeftHandItem == component.IsLeftHandItem)
						{
							holdableItem.AddItem();
							holdableItem.Unlocked = true;
							InventoryToAddItem.AddPickedItemData(holdableItem, component);
							InventoryToAddItem.RefreshInBodyItemVisibility();
							UnityEngine.Object.Destroy(component.gameObject);
							InventoryToAddItem.IsPickingItem = true;
							if (InventoryToAddItem.AutoEquipPickedUpItems)
							{
								InventoryToAddItem.JUCharacter.SwitchToItem(holdableItem.ItemSwitchID, !holdableItem.IsLeftHandItem);
							}
							break;
						}
					}
					return;
				}
				Item[] allItems = InventoryToAddItem.AllItems;
				foreach (Item item in allItems)
				{
					Item itemToPickUp = InventoryToAddItem.ItemToPickUp;
					if (item.ItemSwitchID == itemToPickUp.ItemSwitchID && item.ItemName == itemToPickUp.ItemName)
					{
						InventoryToAddItem.AddPickedItemData(item, itemToPickUp);
						InventoryToAddItem.RefreshInBodyItemVisibility();
						UnityEngine.Object.Destroy(itemToPickUp.gameObject);
						Debug.Log(InventoryToAddItem.gameObject.name + " picked the item: " + item.ItemName);
						InventoryToAddItem.IsPickingItem = true;
						break;
					}
				}
			}
			else
			{
				Debug.LogError("It was not possible to pick up the item because ItemToPickUp variable is null");
			}
		}

		public static HoldableItem GetCurrentHoldableItemInUsing(JUInventory inventory, bool RightHand = true)
		{
			HoldableItem result = null;
			if (RightHand)
			{
				HoldableItem[] holdableItensRightHand = inventory.HoldableItensRightHand;
				foreach (HoldableItem holdableItem in holdableItensRightHand)
				{
					if (holdableItem.ItemSwitchID == inventory.CurrentRightHandItemID)
					{
						result = holdableItem;
					}
				}
			}
			else
			{
				HoldableItem[] holdableItensRightHand = inventory.HoldableItensLeftHand;
				foreach (HoldableItem holdableItem2 in holdableItensRightHand)
				{
					if (holdableItem2.ItemSwitchID == inventory.CurrentLeftHandItemID)
					{
						result = holdableItem2;
					}
				}
			}
			return result;
		}

		protected virtual void RefreshItemsVisibility()
		{
			for (int i = 0; i < HoldableItensRightHand.Length; i++)
			{
				if (CurrentRightHandItemID > -1)
				{
					if (i != CurrentRightHandItemID)
					{
						HoldableItensRightHand[i].gameObject.SetActive(value: false);
					}
					else if (HoldableItensRightHand[i].Unlocked)
					{
						HoldableItemInUseInRightHand = HoldableItensRightHand[i];
						if (base.isLocalPlayer)
						{
							GetComponentInChildren<NetworkObjectSpawner>().SetActiveObject(i, visibility: true);
						}
						if (HoldableItemInUseInRightHand is Weapon)
						{
							WeaponInUseInRightHand = HoldableItemInUseInRightHand.GetComponent<Weapon>();
						}
					}
					else
					{
						HoldableItemInUseInRightHand = null;
						WeaponInUseInRightHand = null;
					}
				}
				else
				{
					if (base.isLocalPlayer)
					{
						GetComponentInChildren<NetworkObjectSpawner>().SetActiveObject(i, visibility: false);
					}
					HoldableItensRightHand[i].gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j < HoldableItensLeftHand.Length; j++)
			{
				if (CurrentLeftHandItemID > -1)
				{
					if (j != CurrentLeftHandItemID)
					{
						HoldableItensLeftHand[j].gameObject.SetActive(value: false);
					}
					else if (HoldableItensLeftHand[j].Unlocked)
					{
						HoldableItemInUseInLeftHand = HoldableItensLeftHand[j];
						HoldableItensLeftHand[j].gameObject.SetActive(value: true);
						if (HoldableItemInUseInLeftHand is Weapon)
						{
							WeaponInUseInLeftHand = HoldableItemInUseInLeftHand.GetComponent<Weapon>();
						}
					}
					else
					{
						HoldableItemInUseInLeftHand = null;
						WeaponInUseInLeftHand = null;
					}
				}
				else
				{
					HoldableItensLeftHand[j].gameObject.SetActive(value: false);
				}
			}
		}

		public void SwitchToItem(int id = -1, bool RightHand = true)
		{
			if (RightHand)
			{
				if (id < -1)
				{
					CurrentRightHandItemID = HoldableItensRightHand.Length - 1;
					HoldableItemInUseInRightHand = HoldableItensRightHand[HoldableItensRightHand.Length - 1];
				}
				if (id == HoldableItensRightHand.Length)
				{
					CurrentRightHandItemID = -1;
					WeaponInUseInRightHand = null;
					HoldableItemInUseInRightHand = null;
					IsItemSelected = false;
				}
			}
			else
			{
				if (id < -1)
				{
					CurrentLeftHandItemID = HoldableItensLeftHand.Length - 1;
					HoldableItemInUseInLeftHand = HoldableItensLeftHand[HoldableItensLeftHand.Length - 1];
				}
				if (id == HoldableItensLeftHand.Length)
				{
					CurrentLeftHandItemID = -1;
					WeaponInUseInLeftHand = null;
					HoldableItemInUseInLeftHand = null;
					IsItemSelected = false;
				}
			}
			if (RightHand)
			{
				HoldableItem[] holdableItensRightHand = HoldableItensRightHand;
				foreach (HoldableItem holdableItem in holdableItensRightHand)
				{
					if (id < 0)
					{
						CurrentRightHandItemID = -1;
						WeaponInUseInRightHand = null;
						HoldableItemInUseInRightHand = null;
						IsItemSelected = false;
					}
					else if (holdableItem.ItemSwitchID == id)
					{
						if (HoldableItemInUseInRightHand == holdableItem)
						{
							return;
						}
						HoldableItemInUseInRightHand = holdableItem;
						if (holdableItem is Weapon)
						{
							WeaponInUseInRightHand = holdableItem.GetComponent<Weapon>();
						}
						else
						{
							WeaponInUseInRightHand = null;
						}
						if (holdableItem is MeleeWeapon)
						{
							MeleeWeaponInUseInRightHand = holdableItem.GetComponent<MeleeWeapon>();
						}
						else
						{
							MeleeWeaponInUseInRightHand = null;
						}
						CurrentRightHandItemID = id;
					}
				}
			}
			if (!RightHand)
			{
				HoldableItem[] holdableItensRightHand = HoldableItensLeftHand;
				foreach (HoldableItem holdableItem2 in holdableItensRightHand)
				{
					if (id < 0)
					{
						CurrentLeftHandItemID = id;
						WeaponInUseInLeftHand = null;
						HoldableItemInUseInLeftHand = null;
						IsItemSelected = false;
					}
					else if (holdableItem2.ItemSwitchID == id)
					{
						if (HoldableItemInUseInLeftHand == holdableItem2)
						{
							return;
						}
						HoldableItemInUseInLeftHand = holdableItem2;
						if (holdableItem2 is Weapon)
						{
							WeaponInUseInLeftHand = holdableItem2.GetComponent<Weapon>();
						}
						else
						{
							WeaponInUseInLeftHand = null;
						}
						if (holdableItem2 is MeleeWeapon)
						{
							MeleeWeaponInUseInLeftHand = holdableItem2.GetComponent<MeleeWeapon>();
						}
						else
						{
							MeleeWeaponInUseInLeftHand = null;
						}
						CurrentLeftHandItemID = id;
					}
				}
			}
			UpdateItemInUse();
			RefreshItemsVisibility();
			RefreshInBodyItemVisibility();
		}

		public static int GetGlobalItemSwitchID(Item item, JUInventory inventory)
		{
			int result = -3;
			if (item == null)
			{
				return result;
			}
			for (int i = 0; i < inventory.AllItems.Length; i++)
			{
				if (inventory.AllItems[i].ItemName == item.ItemName)
				{
					result = i;
				}
			}
			return result;
		}

		public int GetNextUnlockedItemID(int CurrentID, bool LocalID = true, bool RightHand = true)
		{
			if (LocalID)
			{
				if (RightHand)
				{
					return NextUnlockedItemLocalIndexRightHand(CurrentID);
				}
				return NextUnlockedItemLocalIndexLeftHand(CurrentID);
			}
			if (RightHand)
			{
				return GetGlobalItemSwitchID(HoldableItensRightHand[NextUnlockedItemLocalIndexRightHand(CurrentID)], this);
			}
			return GetGlobalItemSwitchID(HoldableItensLeftHand[NextUnlockedItemLocalIndexLeftHand(CurrentID)], this);
		}

		public int GetPreviousUnlockedItemID(int CurrentID, bool LocalID = true, bool RightHand = true)
		{
			if (LocalID)
			{
				if (RightHand)
				{
					return PreviousUnlockedItemLocalIndexRightHand(CurrentID);
				}
				return PreviousUnlockedItemLocalIndexLeftHand(CurrentID);
			}
			if (RightHand)
			{
				return GetGlobalItemSwitchID(HoldableItensRightHand[PreviousUnlockedItemLocalIndexRightHand(CurrentID)], this);
			}
			return GetGlobalItemSwitchID(HoldableItensLeftHand[PreviousUnlockedItemLocalIndexLeftHand(CurrentID)], this);
		}

		public void SetSequentialSlotItem(SequentialSlotsEnum slot, Item item)
		{
			SequentialSlot[] sequenceSlot = SequenceSlot;
			foreach (SequentialSlot sequentialSlot in sequenceSlot)
			{
				if (sequentialSlot.SelectedSlot == slot)
				{
					sequentialSlot.ItemInThisSlot = item;
					if (item != null)
					{
						Debug.Log(slot.ToString() + "Slot now has the item : " + item.ItemName);
					}
				}
			}
		}

		public Item GetSequentialSlotItem(SequentialSlotsEnum slot)
		{
			Item result = null;
			SequentialSlot[] sequenceSlot = SequenceSlot;
			foreach (SequentialSlot sequentialSlot in sequenceSlot)
			{
				if (sequentialSlot.SelectedSlot == slot)
				{
					result = sequentialSlot.ItemInThisSlot;
				}
			}
			return result;
		}

		protected int NextUnlockedItemLocalIndexRightHand(int CurrentID)
		{
			int result = -1;
			for (int i = CurrentID; i < HoldableItensRightHand.Length; i++)
			{
				if (i > -1 && i != CurrentID && HoldableItensRightHand[i].Unlocked)
				{
					result = HoldableItensRightHand[i].ItemSwitchID;
					return HoldableItensRightHand[i].ItemSwitchID;
				}
			}
			return result;
		}

		protected int NextUnlockedItemLocalIndexLeftHand(int CurrentID)
		{
			int result = -1;
			for (int i = CurrentID; i < HoldableItensLeftHand.Length; i++)
			{
				if (i > -1 && i != CurrentID && HoldableItensLeftHand[i].Unlocked)
				{
					result = HoldableItensLeftHand[i].ItemSwitchID;
					return HoldableItensLeftHand[i].ItemSwitchID;
				}
			}
			return result;
		}

		protected int PreviousUnlockedItemLocalIndexRightHand(int CurrentID)
		{
			int result = -1;
			for (int num = CurrentID; num > -1; num--)
			{
				if (num > -1 && num != CurrentID && HoldableItensRightHand[num].Unlocked)
				{
					result = HoldableItensRightHand[num].ItemSwitchID;
					return HoldableItensRightHand[num].ItemSwitchID;
				}
			}
			return result;
		}

		protected int PreviousUnlockedItemLocalIndexLeftHand(int CurrentID)
		{
			int result = -1;
			for (int num = CurrentID; num > -1; num--)
			{
				if (num > -1 && num != CurrentID && HoldableItensLeftHand[num].Unlocked)
				{
					result = HoldableItensLeftHand[num].ItemSwitchID;
					return HoldableItensLeftHand[num].ItemSwitchID;
				}
			}
			return result;
		}

		public void RefreshInBodyItemVisibility()
		{
			if (!UpdateOnBodyItemsVisibility)
			{
				return;
			}
			for (int num = HoldableItensRightHand.Length - 1; num > -1; num--)
			{
				if (num != CurrentRightHandItemID)
				{
					if (HoldableItensRightHand[num].Unlocked && HoldableItensRightHand[num].ItemModelInBody != null)
					{
						HoldableItensRightHand[num].ItemModelInBody.gameObject.SetActive(value: true);
					}
					else if (HoldableItensRightHand[num].ItemModelInBody != null)
					{
						HoldableItensRightHand[num].ItemModelInBody.gameObject.SetActive(value: false);
					}
				}
				else if (HoldableItensRightHand[num].Unlocked && HoldableItensRightHand[num].ItemModelInBody != null)
				{
					HoldableItensRightHand[num].ItemModelInBody.gameObject.SetActive(value: false);
				}
			}
		}

		public void PickUp()
		{
			if (!(ItemToPickUp == null))
			{
				PickUpNearbyItem(this);
			}
		}

		public void AddPickedItemData(Item OnInventoryItem, Item ItemToPickup)
		{
			GetLootItem(OnInventoryItem, ItemToPickUp);
		}

		public void GetLootItem(Item itemOnThisInventory, Item itemOnLoot)
		{
			itemOnThisInventory.ItemQuantity = (itemOnThisInventory.Unlocked ? (itemOnThisInventory.ItemQuantity + itemOnLoot.ItemQuantity) : itemOnLoot.ItemQuantity);
			itemOnThisInventory.ItemQuantity = Mathf.Clamp(itemOnThisInventory.ItemQuantity, 0, itemOnThisInventory.MaxItemQuantity);
			if (itemOnThisInventory is Weapon)
			{
				Weapon weapon = itemOnThisInventory as Weapon;
				Weapon weapon2 = itemOnLoot as Weapon;
				weapon.TotalBullets = (weapon.Unlocked ? (weapon.TotalBullets + weapon2.TotalBullets) : weapon2.TotalBullets);
				if (!weapon.Unlocked)
				{
					weapon.TotalBullets = weapon2.TotalBullets;
					weapon.BulletsAmounts = weapon2.BulletsAmounts;
					weapon.Unlocked = true;
					weapon2.Unlocked = false;
				}
				else
				{
					weapon.TotalBullets += weapon2.TotalBullets + weapon2.BulletsAmounts;
					weapon.BulletsAmounts = weapon2.BulletsAmounts;
					weapon2.TotalBullets = 0;
					weapon2.BulletsAmounts = 0;
				}
			}
			if (itemOnThisInventory is MeleeWeapon)
			{
				MeleeWeapon meleeWeapon = itemOnThisInventory as MeleeWeapon;
				MeleeWeapon meleeWeapon2 = itemOnLoot as MeleeWeapon;
				if (!meleeWeapon.Unlocked)
				{
					meleeWeapon.MeleeWeaponHealth = meleeWeapon2.MeleeWeaponHealth;
					meleeWeapon.Unlocked = true;
					meleeWeapon2.Unlocked = false;
				}
				else
				{
					float meleeWeaponHealth = meleeWeapon.MeleeWeaponHealth;
					meleeWeapon.MeleeWeaponHealth = meleeWeapon2.MeleeWeaponHealth;
					meleeWeapon2.MeleeWeaponHealth = meleeWeaponHealth;
				}
			}
			if (itemOnThisInventory is Armor)
			{
				Armor armor = itemOnThisInventory as Armor;
				Armor armor2 = itemOnLoot as Armor;
				if (!armor.Unlocked)
				{
					armor.Health = armor2.Health;
					armor.Unlocked = true;
					armor2.Unlocked = false;
				}
				else
				{
					float health = armor.Health;
					armor.Health = armor2.Health;
					armor2.Health = health;
				}
			}
		}

		public void DropItem(int ID, bool IsRightHandItem = true)
		{
			Vector3 position = base.transform.position + base.transform.forward * 0.2f + base.transform.up * 0.5f;
			if (IsRightHandItem)
			{
				if (!HoldableItensRightHand[ID].Unlocked)
				{
					return;
				}
				Vector3 lossyScale = HoldableItensRightHand[ID].transform.lossyScale;
				GameObject obj = UnityEngine.Object.Instantiate(HoldableItensRightHand[ID].gameObject, position, Quaternion.identity);
				obj.transform.localScale = lossyScale;
				EnableItemPhysic(obj);
				obj.SetActive(value: true);
				obj.layer = 14;
				HoldableItensRightHand[ID].RemoveItem();
				if (JUCharacter == null)
				{
					SwitchToItem();
				}
				else
				{
					JUCharacter.SwitchToItem();
				}
			}
			else
			{
				if (!HoldableItensRightHand[ID].Unlocked)
				{
					return;
				}
				GameObject obj2 = UnityEngine.Object.Instantiate(HoldableItensLeftHand[ID].gameObject, position, Quaternion.identity);
				EnableItemPhysic(obj2);
				obj2.layer = 14;
				HoldableItensLeftHand[ID].RemoveItem();
				if (JUCharacter == null)
				{
					SwitchToItem(-1, RightHand: false);
				}
				else
				{
					JUCharacter.SwitchToItem(-1, RightHand: false);
				}
			}
			RefreshInBodyItemVisibility();
		}

		public void DropItem(int ID)
		{
			Vector3 position = base.transform.position + base.transform.forward * 0.2f + base.transform.up * 0.5f;
			if (ID < 0 || ID > AllItems.Length || !AllItems[ID].Unlocked)
			{
				return;
			}
			Vector3 lossyScale = AllItems[ID].transform.lossyScale;
			if (AllItems[ID] is Armor)
			{
				GameObject[] parts = (AllItems[ID] as Armor).Parts;
				for (int i = 0; i < parts.Length; i++)
				{
					parts[i].transform.parent = AllItems[ID].transform;
				}
			}
			GameObject obj = UnityEngine.Object.Instantiate(AllItems[ID].gameObject, position, Quaternion.identity);
			obj.transform.localScale = lossyScale;
			EnableItemPhysic(obj);
			obj.SetActive(value: true);
			obj.layer = 14;
			AllItems[ID].RemoveItem();
			if (AllItems[ID] is Armor && AllItems[ID].gameObject.activeInHierarchy)
			{
				AllItems[ID].gameObject.SetActive(value: false);
			}
			if (AllItems[ID] is HoldableItem && AllItems[ID].gameObject.activeInHierarchy)
			{
				if (JUCharacter == null)
				{
					SwitchToItem();
				}
				else
				{
					JUCharacter.SwitchToItem();
				}
			}
			RefreshInBodyItemVisibility();
		}

		public GameObject GetLastEquippedItem()
		{
			return lastEquippedItem;
		}

		public void EquipItem(int ID)
		{
			if (ID < 0 || ID > AllItems.Length || !AllItems[ID].Unlocked || AllItems[ID] is Armor)
			{
				return;
			}
			if (!AllItems[ID].GetType().IsSubclassOf(typeof(HoldableItem)))
			{
				Debug.Log("holdable item");
				lastEquippedItem = AllItems[ID].gameObject;
				return;
			}
			HoldableItem holdableItem = AllItems[ID] as HoldableItem;
			if (JUCharacter == null)
			{
				SwitchToItem(AllItems[ID].ItemSwitchID, !holdableItem.IsLeftHandItem);
				lastEquippedItem = AllItems[ID].gameObject;
			}
			else
			{
				JUCharacter.SwitchToItem(AllItems[ID].ItemSwitchID, !holdableItem.IsLeftHandItem);
				lastEquippedItem = AllItems[ID].gameObject;
			}
		}

		public void SetActiveWeaponState(int index, bool visibility)
		{
			HoldableItensRightHand[index].gameObject.SetActive(visibility);
		}

		public void UnequipItem(int ID)
		{
			if (ID < 0 || ID > AllItems.Length || AllItems[ID] == null)
			{
				return;
			}
			if (AllItems[ID] is Armor)
			{
				AllItems[ID].gameObject.SetActive(value: false);
				Debug.Log("Unequiped " + AllItems[ID].gameObject.name);
			}
			else if (!AllItems[ID].GetType().IsSubclassOf(typeof(HoldableItem)))
			{
				AllItems[ID].gameObject.SetActive(value: false);
				lastEquippedItem = null;
				if (!(AllItems[ID] as HoldableItem).IsLeftHandItem)
				{
					HoldableItemInUseInRightHand = null;
				}
				else
				{
					HoldableItemInUseInLeftHand = null;
				}
				Debug.Log("Unequiped " + AllItems[ID].gameObject.name);
			}
			else if (!(AllItems[ID] as HoldableItem).IsLeftHandItem)
			{
				if (JUCharacter == null)
				{
					SwitchToItem();
				}
				else
				{
					JUCharacter.SwitchToItem();
				}
			}
			else if (JUCharacter == null)
			{
				SwitchToItem(-1, RightHand: false);
			}
			else
			{
				JUCharacter.SwitchToItem(-1, RightHand: false);
			}
		}

		protected void UpdateItemInUse()
		{
			HoldableItemInUseInLeftHand = GetCurrentHoldableItemInUsing(this, RightHand: false);
			HoldableItemInUseInRightHand = GetCurrentHoldableItemInUsing(this);
			if (HoldableItemInUseInLeftHand is Weapon)
			{
				WeaponInUseInLeftHand = (Weapon)HoldableItemInUseInLeftHand;
			}
			else
			{
				WeaponInUseInLeftHand = null;
			}
			if (HoldableItemInUseInRightHand is Weapon)
			{
				WeaponInUseInRightHand = (Weapon)HoldableItemInUseInRightHand;
			}
			else
			{
				WeaponInUseInRightHand = null;
			}
			if (HoldableItemInUseInLeftHand is MeleeWeapon)
			{
				MeleeWeaponInUseInLeftHand = (MeleeWeapon)HoldableItemInUseInLeftHand;
			}
			else
			{
				MeleeWeaponInUseInLeftHand = null;
			}
			if (HoldableItemInUseInRightHand is MeleeWeapon)
			{
				MeleeWeaponInUseInRightHand = (MeleeWeapon)HoldableItemInUseInRightHand;
			}
			else
			{
				MeleeWeaponInUseInRightHand = null;
			}
		}

		private void OnDrawGizmos()
		{
			if (EnablePickup)
			{
				Gizmos.DrawWireSphere(base.transform.TransformPoint(CheckerOffset), CheckerRadious);
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
