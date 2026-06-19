using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotsUIContainer : UIelement
{
	public int windowIndex;

	public bool isFaded;

	public float fadeMultiplier = 1f;

	protected int categoryWindowStartSlotIndex;

	public List<SlotUIBase> itemSlots;

	public List<ISlotHoverProxy> itemHoverProxies = new List<ISlotHoverProxy>();

	public SlotUIBase itemSlotPrefab;

	public SlotUIBase hotbarItemSlotPrefab;

	public float spread = 1f;

	public int inventoryIndex;

	private const int MAX_WINDOWS = 3;

	public GameObject itemSlotsRoot;

	public ItemSlotsUIContainerType containerType;

	public bool keepSlotsEnabledAfterInit;

	public bool autoPositionSlots = true;

	public SpriteRenderer backgroundSR;

	public BoxCollider backgroundBlockCollider;

	public SpriteRenderer[] additionalBackgroundSRs;

	public UIScrollWindow scrollWindow;

	public bool dontShowLockedIcon;

	[NonSerialized]
	public UIManager.ObjectCategoryTagColor overrideSlotsBackgroundColor;

	private int currentCategoryIndex;

	protected bool initDone;

	private int activeSlotIndex = -1;

	public virtual int startSlotIndex => MAX_SLOTS * windowIndex + categoryWindowStartSlotIndex;

	public virtual int MAX_ROWS => 5;

	public virtual int MAX_COLUMNS => 8;

	public int MAX_SLOTS => MAX_ROWS * MAX_COLUMNS;

	public int visibleRows { get; protected set; }

	public int visibleColumns { get; protected set; }

	public int totalVisibleSlots => visibleRows * visibleColumns;

	public bool isPlayerInventory
	{
		get
		{
			if (containerType != ItemSlotsUIContainerType.PlayerInventory)
			{
				return containerType == ItemSlotsUIContainerType.PlayerEquipment;
			}
			return true;
		}
	}

	public bool isPouchInventory => containerType == ItemSlotsUIContainerType.PouchInventory;

	public override bool isShowing => itemSlotsRoot.gameObject.activeInHierarchy;

	public SlotUIBase firstSlot { get; protected set; }

	private PlayerController player => Manager.main.player;

	protected CraftingBuilding.CraftingCategoryWindowInfo GetCategoryWindowInfo()
	{
		InteractableObject currentInteractableObject = Manager.main.player.GetCurrentInteractableObject();
		if (currentInteractableObject != null && Manager.main.player.activeCraftingHandler != Manager.main.player.playerCraftingHandler)
		{
			CraftingBuilding component = currentInteractableObject.transform.parent.GetComponent<CraftingBuilding>();
			if (component != null && component.entityExist)
			{
				return component.GetCraftingCategoryWindowInfo(currentCategoryIndex);
			}
		}
		return null;
	}

	protected virtual void Awake()
	{
		Init();
		if (scrollWindow != null)
		{
			scrollWindow.enabled = false;
		}
	}

	protected override void LateUpdate()
	{
		itemSlotsRoot.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public virtual void Init()
	{
		if (!initDone)
		{
			visibleRows = MAX_ROWS;
			visibleColumns = MAX_COLUMNS;
			InstantiateItemSlots();
			itemSlotsRoot.SetActive(keepSlotsEnabledAfterInit);
			initDone = true;
		}
	}

	protected void InstantiateItemSlots()
	{
		itemSlots = new List<SlotUIBase>(MAX_ROWS * MAX_COLUMNS);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < MAX_ROWS; i++)
		{
			for (int j = 0; j < MAX_COLUMNS; j++)
			{
				SlotUIBase slotUIBase = UnityEngine.Object.Instantiate((hotbarItemSlotPrefab != null && num2 < 10) ? hotbarItemSlotPrefab : itemSlotPrefab, itemSlotsRoot.transform);
				slotUIBase.uiSlotXPosition = j;
				slotUIBase.uiSlotYPosition = i;
				slotUIBase.visibleSlotIndex = num2;
				slotUIBase.Init(this);
				itemSlots.Add(slotUIBase);
				slotUIBase.gameObject.SetActive(keepSlotsEnabledAfterInit);
				if (i == 0 && j == 0)
				{
					firstSlot = slotUIBase;
				}
				num++;
				num2++;
			}
		}
	}

	protected void UpdateBackgroundSize(float paddingX = 0f, float paddingY = 0f)
	{
		Vector2 size = new Vector2((float)visibleColumns * spread + paddingX, (float)visibleRows * spread + paddingY);
		if (backgroundSR != null)
		{
			backgroundSR.size = size;
		}
		if (backgroundBlockCollider != null)
		{
			backgroundBlockCollider.size = new Vector3(size.x, size.y, 0.1f);
		}
	}

	public virtual void ShowContainerUI()
	{
		itemSlotsRoot.gameObject.SetActive(value: true);
		if (scrollWindow != null)
		{
			scrollWindow.enabled = true;
		}
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			if (itemSlot.gameObject.activeInHierarchy)
			{
				itemSlot.UpdateSlot();
			}
		}
	}

	public virtual void HideContainerUI()
	{
		itemSlotsRoot.gameObject.SetActive(value: false);
		if (scrollWindow != null)
		{
			scrollWindow.enabled = false;
		}
	}

	public virtual void OnSlotUpdated(int visibleSlotIndex)
	{
		int index = VisibleSlotIndexToInternalSlotIndex(visibleSlotIndex);
		if (itemSlots[index].gameObject.activeInHierarchy)
		{
			itemSlots[index].UpdateSlot();
		}
	}

	public int VisibleSlotIndexToInternalSlotIndex(int visibleSlotIndex)
	{
		int num = visibleSlotIndex / visibleColumns;
		return visibleSlotIndex % visibleColumns + num * MAX_COLUMNS;
	}

	public void OnEquipmentSlotActivated(int index)
	{
		if (activeSlotIndex >= 0)
		{
			itemSlots[activeSlotIndex].OnSetSlotInactivate();
		}
		activeSlotIndex = index;
		itemSlots[index].OnSetSlotActive();
	}

	public InventoryHandler GetInventoryHandler()
	{
		if (player == null)
		{
			return null;
		}
		switch (containerType)
		{
		case ItemSlotsUIContainerType.ChestInventory:
			return player.activeInventoryHandler;
		case ItemSlotsUIContainerType.PlayerInventory:
		case ItemSlotsUIContainerType.PlayerEquipment:
			return player.playerInventoryHandler;
		case ItemSlotsUIContainerType.CraftingInventory:
			return player.activeCraftingHandler.inventoryHandler;
		case ItemSlotsUIContainerType.Output:
			return player.activeCraftingHandler.outputInventoryHandler;
		case ItemSlotsUIContainerType.PlayerSellSlots:
			return player.sellSlotsHandler.sellSlotsInventoryHandler;
		case ItemSlotsUIContainerType.BuyInventory:
			return player.activeBuyInventoryHandler;
		case ItemSlotsUIContainerType.TrashCan:
			return player.trashCanHandler.inventoryHandler;
		case ItemSlotsUIContainerType.UpgradeForge:
			return player.upgradeSlotHandler.inventoryHandler;
		case ItemSlotsUIContainerType.PouchInventory:
			return player.equipmentHandler.pouchInventorySlotsHandlers[inventoryIndex];
		default:
			Debug.LogError("Could not find any matching inventory handler for containerType " + containerType);
			return null;
		}
	}

	public override UIelement GetClosestUIElement(Vector3 position)
	{
		UIelement result = null;
		float num = 2.1474836E+09f;
		for (int i = 0; i < totalVisibleSlots; i++)
		{
			int index = VisibleSlotIndexToInternalSlotIndex(i);
			if (itemSlots[index].isShowing && itemSlots[index].isVisibleOnScreen)
			{
				float sqrMagnitude = (position - itemSlots[index].transform.position).sqrMagnitude;
				if (!(sqrMagnitude > num))
				{
					num = sqrMagnitude;
					result = itemSlots[index];
				}
			}
		}
		return result;
	}

	public void QuickStack()
	{
		InventoryHandler inventoryHandler = GetInventoryHandler();
		PlayerController playerController = player;
		if (inventoryHandler != null && player != null)
		{
			playerController.playerInventoryHandler.QuickStack(player, inventoryHandler);
		}
	}

	public void Sort()
	{
		InventoryHandler inventoryHandler = GetInventoryHandler();
		if (inventoryHandler != null && Manager.main.player != null)
		{
			inventoryHandler.Sort(Manager.main.player, isPlayerInventory);
			AudioManager.Sfx(SfxTableID.inventorySFXSort, base.transform.position);
		}
	}

	public void QuickStackToNearbyChests()
	{
		InventoryHandler inventoryHandler = GetInventoryHandler();
		if (inventoryHandler != null && Manager.main.player != null)
		{
			inventoryHandler.QuickStackToNearbyChests(Manager.main.player);
			AudioManager.Sfx(SfxTableID.inventorySFXSort, base.transform.position);
		}
	}

	public void ToggleLocking()
	{
		Manager.ui.mouse.ToggleLockingMouseMode();
	}

	public void ToggleQuickTrash()
	{
		Manager.ui.mouse.ToggleQuickTrashMouseMode();
	}
}
