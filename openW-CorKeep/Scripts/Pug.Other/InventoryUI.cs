#define PUG_ACHIEVEMENTS
using System.Collections.Generic;
using System.Collections.Immutable;
using Unity.Mathematics;
using UnityEngine;

public class InventoryUI : ItemSlotsUIContainer, IScrollable
{
	public GameObject mainInventorySlotsContainer;

	public List<InventoryUI> pouchSlotsContainers;

	private int previousInventorySize = -1;

	private UIMouse.MouseMode _previousMouseMode;

	public bool extendSlotsDownwards;

	public bool keepBackgroundPositionAndSizeTheSame;

	private Vector3 originalPosition;

	public ButtonUIElement optionalQuickStackButton;

	public ButtonUIElement optionalSortButton;

	public ButtonUIElement quickStackToNearbyButton;

	private int amountOfActiveSlots;

	private ObjectCategoryTag currentRequirementTag;

	public override int MAX_COLUMNS
	{
		get
		{
			if (containerType != ItemSlotsUIContainerType.PlayerInventory)
			{
				if (!base.isPouchInventory)
				{
					return 12;
				}
				return 10;
			}
			return 10;
		}
	}

	public override int MAX_ROWS
	{
		get
		{
			if (!base.isPouchInventory)
			{
				return base.MAX_ROWS;
			}
			return 1;
		}
	}

	protected override void Awake()
	{
		originalPosition = base.transform.localPosition;
		base.Awake();
	}

	public override void ShowContainerUI()
	{
		UpdateContainerSize();
		if (quickStackToNearbyButton != null)
		{
			bool flag = Manager.ui != null && Manager.ui.isChestInventoryUIShowing;
			quickStackToNearbyButton.gameObject.SetActive(!flag);
		}
		base.ShowContainerUI();
	}

	private void Update()
	{
		if (isShowing && autoPositionSlots)
		{
			UpdateContainerSize();
			TriggerInventoryAchievements();
			if (SlotsNeedsRefresh())
			{
				MarkSlotsAsDirty();
				UpdateAnyPouchSlotColors();
			}
			if (base.isPlayerInventory)
			{
				ApplyUIStateColors();
			}
		}
	}

	private void ApplyUIStateColors()
	{
		if (backgroundSR == null || Manager.ui?.mouse == null)
		{
			return;
		}
		UIMouse.MouseMode mouseMode = Manager.ui.mouse.mouseMode;
		if (mouseMode == _previousMouseMode)
		{
			return;
		}
		_previousMouseMode = mouseMode;
		UIManager.InventoryUIStateThemeType inventoryUIStateThemeType;
		SpriteRenderer[] array;
		switch (mouseMode)
		{
		case UIMouse.MouseMode.Normal:
		{
			backgroundSR.color = Color.white;
			array = additionalBackgroundSRs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = Color.white;
			}
			foreach (SlotUIBase itemSlot in itemSlots)
			{
				if (itemSlot.darkBackground != null)
				{
					itemSlot.darkBackground.color = Manager.ui.GetInventoryUIStateTheme(UIManager.InventoryUIStateThemeType.Default).slotBackgroundColor;
				}
				itemSlot.UpdateSlot();
			}
			for (int j = 0; j < pouchSlotsContainers.Count; j++)
			{
				pouchSlotsContainers[j].additionalBackgroundSRs[0].color = Color.white;
			}
			MarkSlotsAsDirty();
			return;
		}
		case UIMouse.MouseMode.QuickTrash:
			inventoryUIStateThemeType = UIManager.InventoryUIStateThemeType.QuickTrash;
			break;
		case UIMouse.MouseMode.Locking:
			inventoryUIStateThemeType = UIManager.InventoryUIStateThemeType.Locking;
			break;
		default:
			inventoryUIStateThemeType = UIManager.InventoryUIStateThemeType.Default;
			break;
		}
		UIManager.InventoryUIStateThemeType inventoryUIStateThemeType2 = inventoryUIStateThemeType;
		UIManager.InventoryUIStateTheme inventoryUIStateTheme = Manager.ui.GetInventoryUIStateTheme(inventoryUIStateThemeType2);
		backgroundSR.color = inventoryUIStateTheme.backgroundColor;
		array = additionalBackgroundSRs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = inventoryUIStateTheme.backgroundColor;
		}
		foreach (SlotUIBase itemSlot2 in itemSlots)
		{
			if (itemSlot2.darkBackground != null)
			{
				itemSlot2.darkBackground.color = inventoryUIStateTheme.slotBackgroundColor;
			}
			if (itemSlot2.background != null)
			{
				itemSlot2.background.color = inventoryUIStateTheme.slotBorderColor;
			}
		}
		for (int k = 0; k < pouchSlotsContainers.Count; k++)
		{
			pouchSlotsContainers[k].additionalBackgroundSRs[0].color = inventoryUIStateTheme.backgroundColor;
		}
	}

	protected virtual void UpdateContainerSize()
	{
		if (Manager.main.player == null)
		{
			return;
		}
		InventoryHandler inventoryHandler = GetInventoryHandler();
		if (inventoryHandler == null)
		{
			return;
		}
		int num = inventoryHandler.size;
		if (pouchSlotsContainers != null && pouchSlotsContainers.Count > 0)
		{
			for (int i = 0; i < pouchSlotsContainers.Count; i++)
			{
				num += Manager.main.player.equipmentHandler.pouchInventorySlotsHandlers[i].size;
			}
		}
		if (previousInventorySize == num)
		{
			return;
		}
		previousInventorySize = num;
		base.visibleRows = Mathf.CeilToInt((float)inventoryHandler.size / (float)inventoryHandler.columns);
		base.visibleColumns = inventoryHandler.columns;
		float sideStartPosition = GetSideStartPosition(base.visibleColumns);
		float num2 = 0f - GetSideStartPosition(base.visibleRows);
		if (extendSlotsDownwards && !base.isPlayerInventory)
		{
			base.transform.localPosition = originalPosition - new Vector3(0f, num2, 0f);
		}
		int num3 = 0;
		int num4 = amountOfActiveSlots;
		amountOfActiveSlots = 0;
		for (int j = 0; j < MAX_ROWS; j++)
		{
			for (int k = 0; k < MAX_COLUMNS; k++)
			{
				if (j < base.visibleRows && k < base.visibleColumns && amountOfActiveSlots < inventoryHandler.size)
				{
					itemSlots[num3].visibleSlotIndex = amountOfActiveSlots;
					if (base.isPlayerInventory)
					{
						if (num3 < MAX_COLUMNS)
						{
							itemSlots[num3].transform.parent = itemSlotsRoot.transform;
							itemSlots[num3].transform.localPosition = new Vector3(sideStartPosition + (float)k * spread, 0f, 0f);
						}
						else
						{
							itemSlots[num3].transform.parent = mainInventorySlotsContainer.transform;
							itemSlots[num3].transform.localPosition = new Vector3(sideStartPosition + (float)k * spread, (float)(-(j - 1)) * spread, 0f);
						}
					}
					else
					{
						itemSlots[num3].transform.localPosition = new Vector3(sideStartPosition + (float)k * spread, num2 - (float)j * spread, 0f);
					}
					itemSlots[num3].gameObject.SetActive(value: true);
					itemSlots[num3].UpdateSlot();
					amountOfActiveSlots++;
				}
				else
				{
					itemSlots[num3].gameObject.SetActive(value: false);
				}
				num3++;
			}
		}
		if (num4 != amountOfActiveSlots)
		{
			MarkSlotsAsDirty();
		}
		int num5 = base.visibleRows;
		float num6 = (float)(base.visibleRows - 1) * spread;
		if (pouchSlotsContainers != null)
		{
			int num7 = 1;
			for (int l = 0; l < pouchSlotsContainers.Count; l++)
			{
				bool num8 = Manager.main.player.equipmentHandler.pouchInventorySlotsHandlers[l].size > 0;
				InventoryUI inventoryUI = pouchSlotsContainers[l];
				if (num8)
				{
					bool flag = !inventoryUI.gameObject.activeSelf;
					inventoryUI.gameObject.SetActive(value: true);
					if (flag)
					{
						inventoryUI.previousInventorySize = -1;
						inventoryUI.currentRequirementTag = ObjectCategoryTag.None;
					}
					inventoryUI.transform.localPosition = new Vector3(0f, (float)(-(num5 - 1)) * spread - (float)num7 * 0.0625f * 2f, 0f);
					num5++;
					num6 += spread + 0.125f;
					num7++;
				}
				else
				{
					inventoryUI.gameObject.SetActive(value: false);
				}
			}
		}
		if (!keepBackgroundPositionAndSizeTheSame)
		{
			UpdateBackgroundSize((inventoryHandler.entityMonoBehaviour is Chest) ? 0.25f : 0f, (inventoryHandler.entityMonoBehaviour is Chest) ? 0.375f : 0f);
		}
		if (containerType == ItemSlotsUIContainerType.PlayerInventory)
		{
			UpdatePlayerInventoryBackground(num6);
		}
		if (inventoryHandler.entityMonoBehaviour == null)
		{
			return;
		}
		if (inventoryHandler.entityMonoBehaviour is Chest { showSortAndQuickStackButtons: not false })
		{
			if (optionalQuickStackButton != null)
			{
				optionalQuickStackButton.transform.localPosition = new Vector3(0f - GetSideStartPosition(base.visibleColumns) + 1.5f, optionalQuickStackButton.transform.localPosition.y, optionalQuickStackButton.transform.localPosition.z);
				optionalQuickStackButton.gameObject.SetActive(value: true);
			}
			if (optionalSortButton != null)
			{
				optionalSortButton.transform.localPosition = new Vector3(0f - GetSideStartPosition(base.visibleColumns) + 1.5f, optionalSortButton.transform.localPosition.y, optionalSortButton.transform.localPosition.z);
				optionalSortButton.gameObject.SetActive(value: true);
			}
		}
		else if (inventoryHandler.entityMonoBehaviour is PlayerController)
		{
			if (optionalSortButton != null)
			{
				optionalSortButton.gameObject.SetActive(value: true);
			}
		}
		else
		{
			if (optionalQuickStackButton != null)
			{
				optionalQuickStackButton.gameObject.SetActive(value: false);
			}
			if (optionalSortButton != null)
			{
				optionalSortButton.gameObject.SetActive(value: false);
			}
		}
		UpdateAnyPouchSlotColors();
	}

	private void UpdatePlayerInventoryBackground(float height)
	{
		height = math.min(height, 6.125f);
		height += 0.25f;
		Vector2 size = new Vector2(backgroundSR.size.x, height);
		backgroundSR.transform.localPosition = new Vector3(0f, -0.9375f - height / 2f, 0f);
		if (backgroundSR != null)
		{
			backgroundSR.size = size;
		}
		if (backgroundBlockCollider != null)
		{
			backgroundBlockCollider.size = new Vector3(size.x, size.y, 0.1f);
		}
	}

	private bool SlotsNeedsRefresh()
	{
		InventoryHandler inventoryHandler = GetInventoryHandler();
		if (inventoryHandler == null)
		{
			return false;
		}
		List<ObjectCategoryTag> inventoryRequirementTags = inventoryHandler.GetInventoryRequirementTags();
		ObjectCategoryTag objectCategoryTag = ((inventoryRequirementTags != null && inventoryRequirementTags.Count > 0) ? inventoryRequirementTags[0] : ObjectCategoryTag.None);
		if (objectCategoryTag != currentRequirementTag)
		{
			currentRequirementTag = objectCategoryTag;
			return true;
		}
		return false;
	}

	private void MarkSlotsAsDirty()
	{
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			if (itemSlot.isShowing)
			{
				((InventorySlotUI)itemSlot).dirty = true;
			}
		}
	}

	private void UpdateAnyPouchSlotColors()
	{
		if (!base.isPouchInventory)
		{
			return;
		}
		List<ObjectCategoryTag> inventoryRequirementTags = GetInventoryHandler().GetInventoryRequirementTags();
		if (inventoryRequirementTags == null || inventoryRequirementTags.Count == 0)
		{
			return;
		}
		UIManager.ObjectCategoryTagColor objectCategoryTagColors = Manager.ui.GetObjectCategoryTagColors(inventoryRequirementTags[0]);
		if (objectCategoryTagColors == null)
		{
			Debug.LogError("Missing pouch colors for " + inventoryRequirementTags[0]);
			return;
		}
		overrideSlotsBackgroundColor = objectCategoryTagColors;
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.darkBackground.color = objectCategoryTagColors.backgroundColor;
		}
	}

	private static ObjectID GetPetObjectIDCategory(ObjectID objectID)
	{
		switch (objectID)
		{
		case ObjectID.PetSlimeBlob:
		case ObjectID.PetSlipperySlimeBlob:
		case ObjectID.PetPoisonSlimeBlob:
		case ObjectID.PetLavaSlimeBlob:
		case ObjectID.PetPrinceSlimeBlob:
			return ObjectID.PetSlimeBlob;
		default:
			return objectID;
		}
	}

	private void TriggerInventoryAchievements()
	{
		if (containerType != ItemSlotsUIContainerType.ChestInventory || Manager.achievements.HasTriggeredAchievement(AchievementID.PetColors))
		{
			return;
		}
		Dictionary<ObjectID, HashSet<int>> dictionary = new Dictionary<ObjectID, HashSet<int>>();
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			if (!itemSlot.isShowing)
			{
				continue;
			}
			ContainedObjectsBuffer containedObject = itemSlot.GetContainedObject();
			ObjectID objectID = containedObject.objectID;
			if (InventoryHandler.TryGetExtraInventoryData<PetSkinCD>(containedObject.auxDataIndex, out var data))
			{
				ObjectID petObjectIDCategory = GetPetObjectIDCategory(objectID);
				if (!dictionary.ContainsKey(petObjectIDCategory))
				{
					dictionary.Add(petObjectIDCategory, new HashSet<int>());
				}
				dictionary[petObjectIDCategory].Add((petObjectIDCategory == ObjectID.PetSlimeBlob) ? ((int)objectID) : data.skinIndex);
			}
		}
		foreach (KeyValuePair<ObjectID, HashSet<int>> item in dictionary)
		{
			ObjectID key = item.Key;
			HashSet<int> value = item.Value;
			PetInfosTable.PetSkinInfo petSkinInfo = Manager.ui.petInfosTable.GetPetSkinInfo(key);
			if (petSkinInfo != null)
			{
				int count = value.Count;
				int num = ((key == ObjectID.PetSlimeBlob) ? 5 : petSkinInfo.skins.Count);
				if (count >= num)
				{
					Manager.achievements.TriggerAchievement(AchievementID.PetColors);
					break;
				}
			}
		}
	}

	protected float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		bool flag = false;
		if (pouchSlotsContainers != null && pouchSlotsContainers.Count > 0)
		{
			ImmutableArray<InventoryHandler> pouchInventorySlotsHandlers = Manager.main.player.equipmentHandler.pouchInventorySlotsHandlers;
			for (int num = pouchInventorySlotsHandlers.Length - 1; num >= 0; num--)
			{
				InventoryHandler inventoryHandler = pouchInventorySlotsHandlers[num];
				flag = inventoryHandler.size > 0;
				for (int i = 0; i < inventoryHandler.size; i++)
				{
					if (pouchSlotsContainers[num].itemSlots[i] == Manager.ui.currentSelectedUIElement)
					{
						return true;
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		if (!flag)
		{
			int num2 = math.max(0, amountOfActiveSlots - 1) / MAX_COLUMNS * MAX_COLUMNS;
			for (int j = num2; j < amountOfActiveSlots; j++)
			{
				if (j >= num2 && itemSlots[j] == Manager.ui.currentSelectedUIElement)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int num = 10 + MAX_COLUMNS;
		for (int i = 10; i < num; i++)
		{
			if (itemSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (itemSlots.Count > 0 && amountOfActiveSlots > 0 && Manager.main.player != null)
		{
			float y = itemSlots[amountOfActiveSlots - 1].transform.localPosition.y;
			ImmutableArray<InventoryHandler> pouchInventorySlotsHandlers = Manager.main.player.equipmentHandler.pouchInventorySlotsHandlers;
			for (int num = pouchInventorySlotsHandlers.Length - 1; num >= 0; num--)
			{
				if (pouchInventorySlotsHandlers[num].size > 0)
				{
					y = pouchSlotsContainers[num].transform.localPosition.y;
					break;
				}
			}
			return itemSlots[10].transform.localPosition.y - y + spread + 0.125f;
		}
		return 0f;
	}
}
