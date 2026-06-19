using System;
using System.Collections.Generic;
using I2.Loc;
using Inventory;
using Pug.Automation;
using Pug.RP;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugMod;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UIMouse : MonoBehaviour
{
	public enum MouseMode
	{
		Normal = 0,
		Repair = 1,
		Reinforce = 2,
		Aim = 3,
		Locking = 4,
		MortarPlacement = 5,
		MinionTargeting = 6,
		FilterPicking = 7,
		QuickTrash = 8
	}

	[Serializable]
	public class HoverTitleIcon
	{
		public Sprite sprite;

		public Color color;
	}

	[Serializable]
	public class FilteredObject
	{
		public GameObject container;

		public PugText text;

		public SpriteRenderer SR;

		public ColorReplacer colorReplacer;
	}

	public Transform pointer;

	public SpriteObject pointerSR;

	public SpriteObject controllerMapAimSR;

	public Sprite missingItemSprite;

	public SpriteRenderer grabbedItemSR;

	public SpriteRenderer grabbedItemOverlaySR;

	public SpriteRenderer grabbedItemUnderlaySR;

	public ColorReplacer colorReplacer;

	public PugText amountGrabbedNumber;

	public PugText amountGrabbedNumberOutline;

	public GameObject hoverTextContainer;

	public GameObject hoverTopLeft;

	public SpriteRenderer hoverTextBackground;

	public SpriteRenderer hoverTextBlackBackground;

	private Vector2 hoverBackgroundBounds = new Vector2(14.625f, 8.125f);

	public PugText hoverTitle;

	public SpriteRenderer hoverTitleIcon;

	public GameObject descriptionsContainer;

	public List<PugText> hoverDescriptions;

	public PugText descriptionTextPrefab;

	public Color descriptionsDefaultColor;

	public PugText statsTitle;

	public PugText statsTitle2;

	public GameObject statsContainer;

	public List<HoverConditionUIElement> hoverStats;

	public HoverConditionUIElement statsTextPrefab;

	public GameObject setBonusesContainer;

	public PugText setBonusesTitle;

	public List<PugText> setBonusesPieces;

	public List<PugText> setBonusesStats;

	public GameObject hoverMaterialsContainer;

	public PugText hoverMaterialsTitle;

	public List<HoverRequiredMaterialUIElement> hoverMaterials;

	public GameObject hoverFiltersContainer;

	public PugText hoverFilterTitle;

	public FilteredObject filteredObject;

	public List<PugText> tagsTexts;

	public GameObject tagsContainer;

	public PugText tagPrefab;

	public PugText durabilityText;

	public PugText levelText;

	public GameObject coinTextContainer;

	public PugText coinText;

	public SpriteRenderer coinIcon;

	public Color canBeCookedColor;

	public LocalizedString requiresElectricityTerm;

	public LocalizedString canBeCookedTerm;

	public LocalizedString valuableTerm;

	public LocalizedString canBePaintedTerm;

	public LocalizedString canBeEquippedInOffhandTerm;

	public LocalizedString uniqueCraftingComponentTerm;

	public LocalizedString durabilityTerm;

	public LocalizedString fullnessTerm;

	public const string experienceTerm = "experience";

	public const string levelTerm = "level";

	public const string maxLevelTerm = "maxLevel";

	public const string keyItemTerm = "keyItem";

	public const string instrumentItemTerm = "instrumentItem";

	public const string musicSheetItemTerm = "musicSheetItem";

	private const string priceTerm = "price";

	private const string valueTerm = "value";

	private const string materialsTerm = "materials";

	private const string ingredientsTerm = "ingredients";

	private const string repairCostTerm = "repairCost";

	private const string reinforceCostTerm = "reinforceCost";

	private const string requiresNearbyObjectTerm = "requiresNearbyObject";

	private const string useItemTerm = "useItemTerm";

	private const string petEggTerm = "petEgg";

	private const string petCandyTerm = "petCandy";

	private const string items = "Items/";

	private const string whenEatenTerm = "whenEaten";

	private const string permanentWhenEatenTerm = "permanentWhenEaten";

	private const string buffsOwnerTitle = "buffsOwnerTitle";

	private const string itemLevelTerm = "ItemLevel";

	private const string plusOneTerm = "PlusOne";

	private const string anyCommonEdibleObject = "anyCommonEdibleObject";

	private const string anyRareEdibleObject = "anyRareEdibleObject";

	private const string anySandObject = "anySandObject";

	private const string habitableIdolTerm = "habitableIdol";

	public SetBonusesTable setBonusesTable;

	public List<HoverTitleIcon> hoverTitleIcons;

	public List<DataBlockRef<SpriteAsset>> mouseIcons;

	private Vector2 _consoleMousePosition;

	private Vector2 _previousTouchPosition;

	private SlotUIBase lastSlotHovered;

	private ObjectInfo lastHoverObject;

	private int _lastGrabbedSlotIndex;

	private bool _releaseGrabbedItemQueued;

	public static readonly Color mouseDownColor = Color.white * 0.7f;

	private TimerSimple controllerUIElementMoveCooldown = new TimerSimple(0.15f);

	private bool hasDoneMouseUpdateThisFrame;

	private bool leftMouseButtonWasUsedInAnyInteractionThisFrame;

	private bool rightMouseButtonWasUsedInAnyInteractionThisFrame;

	private Vector3 prevPointerPosition;

	private const float MAX_HOVER_DESCRIPTION_WIDTH = 9.5625f;

	private float lastRenderedMaxWidth;

	private ObjectID lastRenderedObject;

	public MouseMode mouseMode { get; private set; }

	private PlayerController player => Manager.main.player;

	public InventoryHandler mouseInventory
	{
		get
		{
			if (!(player != null))
			{
				return null;
			}
			return player.mouseInventoryHandler;
		}
	}

	private int lastGrabbedSlotIndex
	{
		get
		{
			if (!mouseInventory.HasObject(0))
			{
				return -1;
			}
			return _lastGrabbedSlotIndex;
		}
		set
		{
			_lastGrabbedSlotIndex = value;
		}
	}

	public bool isHoldingAnyEntity
	{
		get
		{
			if (player != null)
			{
				return mouseInventory.HasObject(0);
			}
			return false;
		}
	}

	public void SetMouseMode(MouseMode newMouseMode, int sfx = -1)
	{
		mouseMode = newMouseMode;
		if (sfx != -1)
		{
			AudioManager.Sfx(sfx, base.transform.position);
		}
	}

	public void ToggleLockingMouseMode()
	{
		if (mouseMode != MouseMode.Locking)
		{
			SetMouseMode(MouseMode.Locking, SfxTableID.inventorySFXLockModeOn);
		}
		else
		{
			SetMouseMode(MouseMode.Normal, SfxTableID.inventorySFXLockModeOff);
		}
	}

	public void ToggleQuickTrashMouseMode()
	{
		if (mouseMode != MouseMode.QuickTrash)
		{
			SetMouseMode(MouseMode.QuickTrash, SfxTableID.uiBinToggleOnSfx);
		}
		else
		{
			SetMouseMode(MouseMode.Normal, SfxTableID.uiBinToggleOffSfx);
		}
	}

	public void ToggleFilterPickingMouseMode()
	{
		if (mouseMode != MouseMode.FilterPicking)
		{
			SetMouseMode(MouseMode.FilterPicking, SfxTableID.inventorySFXLockModeOn);
		}
		else
		{
			SetMouseMode(MouseMode.Normal, SfxTableID.inventorySFXLockModeOff);
		}
	}

	private void Awake()
	{
		pointer.gameObject.SetActive(value: false);
		grabbedItemSR.sprite = null;
		grabbedItemOverlaySR.gameObject.SetActive(value: false);
		grabbedItemUnderlaySR.gameObject.SetActive(value: false);
		lastGrabbedSlotIndex = -1;
	}

	private void UpdateGrabbedItem()
	{
		if (!isHoldingAnyEntity || Manager.menu.IsAnyMenuActive())
		{
			_releaseGrabbedItemQueued = false;
			grabbedItemSR.sprite = null;
			grabbedItemOverlaySR.gameObject.SetActive(value: false);
			grabbedItemUnderlaySR.gameObject.SetActive(value: false);
			amountGrabbedNumber.Render(string.Empty);
			amountGrabbedNumberOutline.Render(string.Empty);
			return;
		}
		ContainedObjectsBuffer containedObjectData = mouseInventory.GetContainedObjectData(0);
		if (!PugDatabase.TryGetObjectInfo(containedObjectData.objectID, out var objectInfo, containedObjectData.variation))
		{
			grabbedItemSR.sprite = missingItemSprite;
			grabbedItemOverlaySR.gameObject.SetActive(value: false);
			grabbedItemUnderlaySR.gameObject.SetActive(value: false);
			amountGrabbedNumber.Render(string.Empty);
			amountGrabbedNumberOutline.Render(string.Empty);
			return;
		}
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObjectData.objectData, getSmallIcon: false);
		grabbedItemSR.sprite = ((iconOverride != null) ? iconOverride : objectInfo?.icon);
		Manager.ui.ApplyAnyIconGradientMap(containedObjectData, grabbedItemSR);
		bool active = Manager.ui.ShouldShowCageOverlay(containedObjectData);
		grabbedItemOverlaySR.gameObject.SetActive(active);
		grabbedItemUnderlaySR.gameObject.SetActive(active);
		if (containedObjectData.amount <= 0 && PugDatabase.HasComponent<DurabilityCD>(containedObjectData.objectID))
		{
			grabbedItemSR.color = Manager.ui.brokenColor;
		}
		else
		{
			grabbedItemSR.color = Color.white;
		}
		colorReplacer.UpdateColorReplacerFromObjectData(containedObjectData);
		string text = ((objectInfo != null && objectInfo.isStackable) ? containedObjectData.amount.ToString() : "");
		if (amountGrabbedNumber.displayedTextString != text)
		{
			amountGrabbedNumber.Render((containedObjectData.amount > 1) ? text : string.Empty);
			amountGrabbedNumberOutline.Render((containedObjectData.amount > 1) ? text : string.Empty);
		}
	}

	private void Update()
	{
		if (Manager.main != null && Manager.input != null && Manager.ui != null && Manager.ecs.ClientWorld == null)
		{
			bool showMouseIcon = Manager.input.SystemPrefersKeyboardAndMouse() || (Manager.ui.currentSelectedUIElement != null && !Manager.ui.currentSelectedUIElement.keepMouseActiveButHiddenOnHoverWhenUsingController);
			UpdateMouseVisibility(showControllerMapAim: false, showMouseIcon);
		}
		UpdateMouseMode();
		UpdateMouseUIInput(out var _, out var _);
		UpdateGrabbedItem();
	}

	private void LateUpdate()
	{
		if (pointer.gameObject.activeInHierarchy)
		{
			UpdateHoverText(attemptToUsePrevWidth: true);
			UpdateSlotHighlights();
		}
		hasDoneMouseUpdateThisFrame = false;
		leftMouseButtonWasUsedInAnyInteractionThisFrame = false;
		rightMouseButtonWasUsedInAnyInteractionThisFrame = false;
		bool flag = Manager.input.LeftClickPressed() || Manager.input.RightClickPressed();
		pointerSR.color = (flag ? mouseDownColor : Color.white);
		Color color = pointerSR.color;
		color.a = Manager.ui.CalcMouseFadeValue();
		pointerSR.color = color;
		if (Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame && !Manager.menu.IsAnyMenuActive())
		{
			pointerSR.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		}
		else
		{
			pointerSR.transform.localScale = Vector3.one;
		}
		UpdateMouseIcon();
		controllerMapAimSR.transform.localScale = pointerSR.transform.localScale;
	}

	public void UpdateMouseVisibility(bool showControllerMapAim, bool showMouseIcon)
	{
		controllerMapAimSR.enabled = showControllerMapAim;
		pointerSR.enabled = !showControllerMapAim && showMouseIcon;
	}

	private void UpdateMouseIcon()
	{
		pointerSR.asset = mouseIcons[(int)mouseMode].Get();
	}

	private void UpdateMouseMode()
	{
		AimIndicatorCachedStatesCD value;
		MouseMode mouseMode;
		if (this.mouseMode == MouseMode.Repair || this.mouseMode == MouseMode.Reinforce)
		{
			if (!Manager.ui.isSalvageAndRepairUIShowing || (Manager.input.singleplayerInputModule != null && Manager.input.singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_ITEMS)))
			{
				SetMouseMode(MouseMode.Normal);
			}
			else if (mouseInventory != null && mouseInventory.HasObject(0))
			{
				ReleaseGrabbedItemBackToInventory();
			}
		}
		else if (player != null && player.isLocal && Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame && !Manager.menu.IsAnyMenuActive() && !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && EntityUtility.TryGetComponentData<AimIndicatorCachedStatesCD>(player.entity, player.world, out value) && value.hasAimValidStateAndIntactWeapon && value.hasAnyAimIndicatorActive)
		{
			if (value.isCommandMinion)
			{
				SetMouseMode(MouseMode.MinionTargeting);
			}
			else if (value.isMortar)
			{
				SetMouseMode(MouseMode.MortarPlacement);
			}
			else if (value.isRanged)
			{
				SetMouseMode(MouseMode.Aim);
			}
			else if (value.isBeamWeapon)
			{
				SetMouseMode(MouseMode.Aim);
			}
		}
		else
		{
			mouseMode = this.mouseMode;
			if (mouseMode == MouseMode.Aim || mouseMode == MouseMode.MortarPlacement || mouseMode == MouseMode.MinionTargeting)
			{
				SetMouseMode(MouseMode.Normal);
			}
			else if ((this.mouseMode == MouseMode.Locking || this.mouseMode == MouseMode.QuickTrash) && (!Manager.ui.isPlayerInventoryShowing || (Manager.input.singleplayerInputModule != null && Manager.input.singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_ITEMS))))
			{
				SetMouseMode(MouseMode.Normal);
			}
			else if (this.mouseMode == MouseMode.FilterPicking && !Manager.ui.filteringUI.isShowing)
			{
				SetMouseMode(MouseMode.Normal);
			}
		}
		Transform parent = pointerSR.transform.parent;
		mouseMode = this.mouseMode;
		parent.localPosition = ((mouseMode == MouseMode.Aim || mouseMode == MouseMode.MortarPlacement || mouseMode == MouseMode.MinionTargeting) ? Vector3.zero : new Vector3(0.25f, -0.25f, 0f));
	}

	public void PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick()
	{
		if (!Manager.input.SystemPrefersKeyboardAndMouse() && Manager.ui.currentSelectedUIElement != null)
		{
			pointer.position = Manager.ui.currentSelectedUIElement.transform.position;
		}
	}

	public bool UpdateMouseUIInput(out bool leftClickWasUsed, out bool rightClickWasUsed)
	{
		leftClickWasUsed = leftMouseButtonWasUsedInAnyInteractionThisFrame;
		rightClickWasUsed = rightMouseButtonWasUsedInAnyInteractionThisFrame;
		if (hasDoneMouseUpdateThisFrame)
		{
			if (!leftMouseButtonWasUsedInAnyInteractionThisFrame)
			{
				return rightMouseButtonWasUsedInAnyInteractionThisFrame;
			}
			return true;
		}
		hasDoneMouseUpdateThisFrame = true;
		leftMouseButtonWasUsedInAnyInteractionThisFrame = false;
		rightMouseButtonWasUsedInAnyInteractionThisFrame = false;
		pointer.gameObject.SetActive(Manager.ui.isMouseShowing);
		if (Manager.ui.isMouseShowing)
		{
			if (Manager.input.touchpadInUse && Manager.ui.inventoryOrMapWasActiveThisFrame && player != null && player.inputModule != null && (player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_DOWN) || player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_UP) || player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_LEFT) || player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_RIGHT)))
			{
				Manager.input.touchpadInUse = false;
			}
			bool flag = !Manager.input.SystemPrefersKeyboardAndMouse();
			bool flag2 = false;
			if (!flag)
			{
				pointer.localPosition = RoundToPixelPerfectPosition.RoundPosition(GetMouseUIViewPosition());
			}
			else if (Manager.ui.isShowingMap)
			{
				pointer.localPosition = Vector3.zero;
			}
			else
			{
				if (Manager.ui.currentSelectedUIElement == null || Manager.ui.currentSelectedUIElement is BlockingUIElement)
				{
					if (Manager.ui.isChestInventoryUIShowing)
					{
						pointer.position = Manager.ui.chestInventoryUI.firstSlot.transform.position;
					}
					else if (Manager.ui.isPlayerInventoryShowing)
					{
						pointer.position = Manager.ui.playerInventoryUI.firstSlot.transform.position;
					}
				}
				if (Manager.ui.currentSelectedUIElement != null)
				{
					PlayerController playerController = player;
					if ((object)playerController != null && playerController.inputModule != null && (!controllerUIElementMoveCooldown.isRunning || controllerUIElementMoveCooldown.isTimerElapsed))
					{
						Direction.Id id = Direction.Id.zero;
						UIelement uIelement = null;
						if (player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_DOWN))
						{
							id = Direction.Id.back;
						}
						else if (player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_UP))
						{
							id = Direction.Id.forward;
						}
						if (player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_RIGHT))
						{
							id = Direction.Id.right;
						}
						else if (player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MENU_LEFT))
						{
							id = Direction.Id.left;
						}
						if (id != Direction.Id.zero)
						{
							uIelement = Manager.ui.currentSelectedUIElement.GetAdjacentUIElement(id, Manager.ui.currentSelectedUIElement.transform.position);
						}
						if (uIelement != null)
						{
							controllerUIElementMoveCooldown.Start();
							pointer.position = uIelement.transform.position;
							TrySelectNewElement(uIelement, interactDownThisFrame: false);
							flag2 = true;
						}
					}
				}
			}
			if (Manager.menu.isConsoleActive)
			{
				return false;
			}
			if (Manager.main.player != null && Manager.main.player.LocalPlayerIsTryingToAttack())
			{
				if (!leftMouseButtonWasUsedInAnyInteractionThisFrame)
				{
					return rightMouseButtonWasUsedInAnyInteractionThisFrame;
				}
				return true;
			}
			if (!flag2 && Manager.input.textInputIsActive && Manager.input.IsMenuMouseInteractButtonDown() && Manager.input.activeInputField is TextInputField textInputField)
			{
				Manager.input.activeInputField.Deactivate(textInputField.triggerOnInputFieldDoneWhenCanceling);
			}
			RaycastHit[] hits;
			int num = Manager.physics.RaycastNonAlloc(pointer.transform.position + Vector3.back * 5f, Vector3.forward, 10f, includeTriggers: true, ObjectLayerID.UILayerMask, out hits);
			UIelement uIelement2 = null;
			float num2 = 2.1474836E+09f;
			for (int i = 0; i < num; i++)
			{
				float distance = hits[i].distance;
				UIelement component = hits[i].collider.GetComponent<UIelement>();
				if (num2 > distance && component != null && component.isVisibleOnScreen)
				{
					num2 = distance;
					uIelement2 = component;
				}
			}
			PlayerInput singleplayerInputModule = Manager.input.singleplayerInputModule;
			bool flag3 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.UI_INTERACT);
			bool flag4 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.UI_INTERACT);
			bool flag5 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.UI_SECOND_INTERACT);
			bool flag6 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.UI_SECOND_INTERACT);
			bool flag7 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.PICK_UP_ALL_ITEMS);
			bool flag8 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_ALL_ITEMS);
			bool flag9 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.DROP_SELECTED_ITEM);
			bool flag10 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.QUICK_MOVE_ITEMS);
			bool flag11 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.PICK_UP_ITEMS);
			bool flag12 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_ITEMS);
			bool flag13 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_10);
			bool flag14 = singleplayerInputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_HALF);
			bool flag15 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.TRASH_ITEM);
			if (singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.UI_INTERACT))
			{
				Manager.input.touchpadInUse = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.TOUCHPAD);
			}
			bool flag16 = singleplayerInputModule.PrefersKeyboardAndMouse();
			if (!flag16)
			{
				flag13 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.PICK_UP_10);
				flag14 = singleplayerInputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.PICK_UP_HALF);
			}
			if (flag11 && (flag13 || flag14))
			{
				flag7 = false;
			}
			if (Manager.menu.IsAnyMenuActive())
			{
				flag3 = Manager.input.IsMenuMouseInteractButtonDown();
				flag4 = Manager.input.IsMenuMouseInteractButtonPressed();
				flag5 = false;
			}
			if (!flag2 && (flag || flag3 || prevPointerPosition != pointer.localPosition || Manager.ui.currentSelectedUIElement == null || !Manager.ui.currentSelectedUIElement.isVisibleOnScreen || uIelement2 == null))
			{
				TrySelectNewElement(uIelement2, flag3);
				prevPointerPosition = pointer.localPosition;
			}
			leftMouseButtonWasUsedInAnyInteractionThisFrame = uIelement2 != null;
			rightMouseButtonWasUsedInAnyInteractionThisFrame = uIelement2 != null;
			leftClickWasUsed = leftMouseButtonWasUsedInAnyInteractionThisFrame;
			rightClickWasUsed = rightMouseButtonWasUsedInAnyInteractionThisFrame;
			if (Manager.ui.currentSelectedUIElement != null)
			{
				if (Manager.ui.currentSelectedUIElement is InventorySlotUI inventorySlotUI)
				{
					if (flag10 && flag9)
					{
						if (player.activeInventoryHandler == null || player.activeInventoryHandler == player.playerInventoryHandler)
						{
							flag10 = false;
						}
						else
						{
							flag9 = false;
						}
					}
					if (flag3 && (mouseMode == MouseMode.Repair || mouseMode == MouseMode.Reinforce) && player.activeCraftingHandler != null)
					{
						InventoryHandler inventoryHandler = inventorySlotUI.GetInventoryHandler();
						player.activeCraftingHandler.RepairOrReinforce(player, inventorySlotUI.inventorySlotIndex, inventoryHandler, mouseMode == MouseMode.Reinforce);
					}
					else if (flag3 && mouseMode == MouseMode.QuickTrash)
					{
						TrySendItemToTrash(inventorySlotUI);
					}
					else if (flag3 && mouseMode == MouseMode.Locking)
					{
						InventoryHandler inventoryHandler2 = inventorySlotUI.GetInventoryHandler();
						if (inventoryHandler2 != null && (inventorySlotUI.isPlayerPouchSlot || inventorySlotUI.isPlayerInventorySlot) && inventorySlotUI.GetObjectData().objectID != ObjectID.None)
						{
							inventoryHandler2.ToggleLock(player, inventorySlotUI.inventorySlotIndex);
							if (EntityUtility.TryGetBuffer(inventoryHandler2.inventoryEntity, Manager.ecs.ClientWorld, out DynamicBuffer<LockedObjectsBuffer> value))
							{
								if (value[inventorySlotUI.inventorySlotIndex + inventoryHandler2.startPosInBuffer].Value)
								{
									AudioManager.Sfx(SfxTableID.inventorySFXSlotUnlock, base.transform.position);
								}
								else
								{
									AudioManager.Sfx(SfxTableID.inventorySFXSlotLock, base.transform.position);
								}
							}
						}
					}
					else if (flag3 && mouseMode == MouseMode.FilterPicking)
					{
						IFilteringBuilding activeFilteringBuilding = player.GetActiveFilteringBuilding();
						InventoryHandler inventoryHandler3 = inventorySlotUI.GetInventoryHandler();
						if (activeFilteringBuilding != null && inventoryHandler3 != null && inventorySlotUI.GetObjectData().objectID != ObjectID.None)
						{
							ObjectDataCD objectData = inventorySlotUI.GetObjectData();
							EntityMonoBehaviour entityMonoBehaviour = activeFilteringBuilding as EntityMonoBehaviour;
							player.QueueInputAction(new UIInputActionData
							{
								action = UIInputAction.InventoryChange,
								inventoryChangeData = Create.AddFilter(entityMonoBehaviour.entity, objectData.objectID, objectData.variation)
							});
							AudioManager.Sfx(SfxTableID.inventorySFXSlotLock, base.transform.position);
							SetMouseMode(MouseMode.Normal);
						}
					}
					else if (flag7)
					{
						if (flag10)
						{
							inventorySlotUI.TryToSendItemToOtherInventoryOrEquip();
						}
						else if (flag9)
						{
							DropSelectedObjectToWorld(inventorySlotUI);
						}
						else
						{
							inventorySlotUI.LeftClick(flag13, flag14);
						}
					}
					else if ((flag16 && flag11) || (!flag16 && (flag11 || flag14 || flag13)))
					{
						inventorySlotUI.RightClick(flag13, flag14);
					}
					if (flag8)
					{
						inventorySlotUI.LeftClickHeldDown(flag13, flag14);
					}
					if (flag12)
					{
						inventorySlotUI.RightClickHeldDown(flag13, flag14);
					}
					if (flag15)
					{
						TrySendItemToTrash(inventorySlotUI);
					}
				}
				else
				{
					if (flag3)
					{
						Manager.ui.currentSelectedUIElement?.LeftClick(flag13, flag14);
					}
					if (flag4)
					{
						Manager.ui.currentSelectedUIElement?.LeftClickHeldDown(flag13, flag14);
					}
					if (flag5)
					{
						Manager.ui.currentSelectedUIElement?.RightClick(flag13, flag14);
					}
					if (flag6)
					{
						Manager.ui.currentSelectedUIElement?.RightClickHeldDown(flag13, flag14);
					}
				}
				if (Manager.ui.currentSelectedUIElement is InventorySlotUI slotToSwapWith)
				{
					for (int j = 0; j < 10; j++)
					{
						if (singleplayerInputModule.WasSlotButtonPressedDownThisFrame(j))
						{
							UIDropSound();
							SwapHotBarItemSlot(slotToSwapWith, j);
						}
					}
				}
			}
			else if ((flag3 || flag5) && isHoldingAnyEntity)
			{
				ReleaseGrabbedItemToWorld(flag3);
				leftMouseButtonWasUsedInAnyInteractionThisFrame = flag3;
				rightMouseButtonWasUsedInAnyInteractionThisFrame = !flag3;
				leftClickWasUsed = leftMouseButtonWasUsedInAnyInteractionThisFrame;
				rightClickWasUsed = rightMouseButtonWasUsedInAnyInteractionThisFrame;
			}
		}
		else if (isHoldingAnyEntity && !_releaseGrabbedItemQueued)
		{
			_releaseGrabbedItemQueued = true;
			ReleaseGrabbedItemBackToInventory();
		}
		if (!leftMouseButtonWasUsedInAnyInteractionThisFrame)
		{
			return rightMouseButtonWasUsedInAnyInteractionThisFrame;
		}
		return true;
	}

	private void TrySendItemToTrash(InventorySlotUI itemSlot)
	{
		InventoryHandler inventoryHandler = itemSlot.GetInventoryHandler();
		if (inventoryHandler == null)
		{
			return;
		}
		bool flag = false;
		if (inventoryHandler.isBuyInventory)
		{
			return;
		}
		if (EntityUtility.TryGetBuffer(inventoryHandler.inventoryEntity, Manager.ecs.ClientWorld, out DynamicBuffer<LockedObjectsBuffer> value))
		{
			flag = value[itemSlot.inventorySlotIndex + inventoryHandler.startPosInBuffer].Value;
		}
		if (flag || inventoryHandler.objectsGetLockedInPlace)
		{
			AudioManager.Sfx(SfxTableID.uiBinLockedClickSfx, base.transform.position);
			return;
		}
		bool flag2 = false;
		if (player.trashCanHandler.inventoryHandler.HasObject(0))
		{
			Manager.ui.trashCanUI.TrashItemInSlot();
			flag2 = true;
		}
		ObjectDataCD objectData = itemSlot.GetObjectData();
		if (objectData.objectID != ObjectID.None && !((InventorySlotUI)Manager.ui.trashCanUI.firstSlot).TryingToPlaceItemShouldShowError(objectData))
		{
			inventoryHandler.MoveTo(player, itemSlot.inventorySlotIndex, player.trashCanHandler.inventoryHandler, objectData.amount, 0);
			if (!flag2)
			{
				AudioManager.Sfx(SfxTableID.uiBinMoveSfx, base.transform.position);
			}
		}
	}

	private void TrySelectNewElement(UIelement selectedUIElement, bool interactDownThisFrame)
	{
		if ((UIelement)Manager.input.activeInputField != selectedUIElement && Manager.input.textInputIsActive && interactDownThisFrame)
		{
			Manager.input.activeInputField.Deactivate(commit: false);
		}
		if (selectedUIElement == null || selectedUIElement != Manager.ui.currentSelectedUIElement)
		{
			Manager.ui.DeselectAnySelectedUIElement();
		}
		if (selectedUIElement != null)
		{
			selectedUIElement.Select();
		}
	}

	public void OnInventorySlotLeftClicked(InventorySlotUI itemSlot, bool tryToSendToOtherInventory, bool allowPlacingStuff = true, int amount = -1, bool destroyAnyExistingItem = false)
	{
		DoMove(itemSlot, amount, tryToSendToOtherInventory, allowPlacingStuff, preferToMoveToHand: false, destroyAnyExistingItem);
	}

	private void DoMove(InventorySlotUI itemSlot, int amount, bool tryToSendToOtherInventory, bool allowPlacingStuff = true, bool preferToMoveToHand = false, bool destroyAnyExistingItem = false)
	{
		InventoryHandler inventoryHandler = itemSlot.GetInventoryHandler();
		InventoryHandler otherActiveInventory = GetOtherActiveInventory(itemSlot);
		ObjectID objectID = itemSlot.GetObjectData().objectID;
		if ((objectID == ObjectID.None && mouseInventory.GetObjectData(0).objectID == ObjectID.None) || (inventoryHandler.objectsGetLockedInPlace && objectID != ObjectID.None))
		{
			return;
		}
		if (tryToSendToOtherInventory && otherActiveInventory != null)
		{
			ObjectID objectID2 = itemSlot.GetObjectData().objectID;
			if (objectID2 == ObjectID.None || !otherActiveInventory.HasValidInventorySlotRequirementBuffer() || !otherActiveInventory.ObjectIsValidToPutInInventory(objectID2))
			{
				return;
			}
			if (otherActiveInventory.canOnlyContainOneItemPerSlot)
			{
				if (!otherActiveInventory.HasRoomForObject(player, itemSlot.GetContainedObjectData()))
				{
					return;
				}
				amount = 1;
			}
			if (amount == -1)
			{
				inventoryHandler.MoveAllToOrDrop(player, itemSlot.inventorySlotIndex, otherActiveInventory, player.transform.position);
			}
			else
			{
				inventoryHandler.TryMoveTo(player, itemSlot.inventorySlotIndex, otherActiveInventory, -1, amount);
			}
			UIDropSound();
		}
		else
		{
			if (tryToSendToOtherInventory)
			{
				return;
			}
			if (inventoryHandler.canOnlyContainOneItemPerSlot)
			{
				amount = 1;
			}
			ObjectDataCD objectData = mouseInventory.GetObjectData(0);
			ObjectDataCD objectData2 = itemSlot.GetObjectData();
			if (objectData.objectID == ObjectID.None)
			{
				if (amount == -1)
				{
					itemSlot.GetInventoryHandler().Swap(player, itemSlot.inventorySlotIndex, mouseInventory, 0);
				}
				else
				{
					itemSlot.GetInventoryHandler().TryMoveTo(player, itemSlot.inventorySlotIndex, mouseInventory, -1, amount);
				}
				lastGrabbedSlotIndex = itemSlot.inventorySlotIndex;
				UIPickUpSound();
			}
			else if (objectData2.objectID == ObjectID.None && allowPlacingStuff)
			{
				if (itemSlot.GetInventoryHandler().ObjectIsValidToPutInInventory(mouseInventory.GetObjectData(0).objectID, itemSlot.inventorySlotIndex))
				{
					if (amount == -1)
					{
						mouseInventory.Swap(player, 0, itemSlot.GetInventoryHandler(), itemSlot.inventorySlotIndex);
					}
					else
					{
						mouseInventory.TryMoveTo(player, 0, itemSlot.GetInventoryHandler(), itemSlot.inventorySlotIndex, amount);
					}
					UIDropSound();
				}
			}
			else if ((allowPlacingStuff && itemSlot.GetInventoryHandler().CanPlaceInSlot(objectData, itemSlot.inventorySlotIndex)) || (!allowPlacingStuff && mouseInventory.CanPlaceInSlot(itemSlot.GetObjectData(), 0)))
			{
				if (amount == -1)
				{
					if (allowPlacingStuff)
					{
						if (inventoryHandler.canOnlyContainOneItemPerSlot)
						{
							return;
						}
						mouseInventory.TryMoveTo(player, 0, inventoryHandler, itemSlot.inventorySlotIndex);
					}
					else
					{
						itemSlot.GetInventoryHandler().TryMoveTo(player, itemSlot.inventorySlotIndex, mouseInventory);
					}
					UIDropSound();
				}
				else if (!inventoryHandler.canOnlyContainOneItemPerSlot)
				{
					if (preferToMoveToHand)
					{
						itemSlot.GetInventoryHandler().TryMoveTo(player, itemSlot.inventorySlotIndex, mouseInventory, -1, amount);
					}
					else
					{
						mouseInventory.TryMoveTo(player, 0, inventoryHandler, itemSlot.inventorySlotIndex, amount);
					}
					UIPickUpSound();
				}
			}
			else
			{
				if (!inventoryHandler.ObjectIsValidToPutInInventory(mouseInventory.GetObjectData(0).objectID, itemSlot.inventorySlotIndex))
				{
					return;
				}
				if (allowPlacingStuff)
				{
					if (inventoryHandler.canOnlyContainOneItemPerSlot && mouseInventory.GetObjectData(0).amount > 1)
					{
						InventoryHandler.MoveAllOrDropThenTryMove(player, inventoryHandler, itemSlot.inventorySlotIndex, player.playerInventoryHandler, player.transform.position, mouseInventory, 0, 1);
					}
					else if (destroyAnyExistingItem)
					{
						mouseInventory.MoveToAndDestroyAnyExisting(player, 0, inventoryHandler, itemSlot.inventorySlotIndex);
					}
					else
					{
						inventoryHandler.Swap(player, itemSlot.inventorySlotIndex, mouseInventory, 0);
					}
				}
				UIPickUpSound();
			}
		}
	}

	public void OnInventorySlotRightClicked(InventorySlotUI itemSlot, bool allowPlacingStuff, int amount)
	{
		itemSlot.GetObjectData();
		DoMove(itemSlot, amount, tryToSendToOtherInventory: false, allowPlacingStuff, preferToMoveToHand: true);
		UpdateGrabbedItem();
	}

	private void DropSelectedObjectToWorld(InventorySlotUI itemSlot)
	{
		InventoryHandler inventoryHandler = itemSlot.GetInventoryHandler();
		if (inventoryHandler != null && !inventoryHandler.objectsGetLockedInPlace && !inventoryHandler.isBuyInventory)
		{
			inventoryHandler.DropItem(player, itemSlot.inventorySlotIndex, EntityMonoBehaviour.ToWorldFromRender(player.transform.position), player.entity);
		}
	}

	public void ReleaseGrabbedItemToWorld(bool leftClick)
	{
		mouseInventory.GetObjectData(0);
		Vector3 vector = (Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse() ? new Vector3(pointer.localPosition.x, 0f, pointer.localPosition.y).normalized : Vector3.zero);
		if (vector == Vector3.zero)
		{
			vector = Manager.main.player.facingDirection.vec3;
		}
		Vector3 worldPosition = EntityMonoBehaviour.ToWorldFromRender(Manager.main.player.RenderPosition + vector * 0.4f);
		if (leftClick)
		{
			mouseInventory.DropItem(player, 0, worldPosition, player.entity);
		}
		else
		{
			mouseInventory.DropItem(player, 0, 1, worldPosition, player.entity);
		}
		UpdateGrabbedItem();
	}

	public void ReleaseGrabbedItemBackToInventory()
	{
		int indexToHint = ((lastGrabbedSlotIndex != -1) ? lastGrabbedSlotIndex : 0);
		mouseInventory.MoveAllToOrDropIgnoreGuestMode(player, 0, player.playerInventoryHandler, player.transform.position, indexToHint);
		UpdateGrabbedItem();
	}

	private InventoryHandler GetOtherActiveInventory(InventorySlotUI itemSlot)
	{
		if (Manager.ui.isPlayerInventoryShowing && (Manager.ui.isCraftingUIShowing || Manager.ui.isChestInventoryUIShowing || Manager.ui.isSellUIShowing || Manager.ui.isSalvageAndRepairUIShowing || Manager.ui.isVanitySlotsShowing || Manager.ui.isUpgradeForgeUIShowing))
		{
			if (itemSlot.isPlayerInventorySlot || itemSlot.isPlayerPouchSlot)
			{
				InventoryHandler inventoryHandler = ((Manager.ui.isCraftingUIShowing || Manager.ui.isSalvageAndRepairUIShowing) ? player.activeCraftingHandler.inventoryHandler : (Manager.ui.isUpgradeForgeUIShowing ? player.upgradeSlotHandler.inventoryHandler : player.activeInventoryHandler));
				if (inventoryHandler != player.playerInventoryHandler)
				{
					return inventoryHandler;
				}
				return null;
			}
			return player.playerInventoryHandler;
		}
		return null;
	}

	private void SwapHotBarItemSlot(InventorySlotUI slotToSwapWith, int equipmentSlotIndex)
	{
		InventorySlotUI equipmentSlot = Manager.ui.itemSlotsBar.GetEquipmentSlot(equipmentSlotIndex);
		ObjectDataCD objectData = equipmentSlot.GetObjectData();
		InventoryHandler inventoryHandler = slotToSwapWith.GetInventoryHandler();
		if (inventoryHandler != null && !inventoryHandler.isBuyInventory && !inventoryHandler.canOnlyContainOneItemPerSlot && !(slotToSwapWith is OutputSlotUI))
		{
			if (inventoryHandler.ObjectIsValidToPutInInventory(objectData.objectID, slotToSwapWith.inventorySlotIndex) && !slotToSwapWith.TryingToPlaceItemShouldShowError(objectData) && inventoryHandler.ObjectIsValidToPutInInventory(slotToSwapWith.GetContainedObject().objectID, equipmentSlot.inventorySlotIndex))
			{
				player.playerInventoryHandler.Swap(player, equipmentSlot.inventorySlotIndex, inventoryHandler, slotToSwapWith.inventorySlotIndex);
				Manager.ui.playerInventoryUI.OnSlotUpdated(equipmentSlotIndex);
			}
			else
			{
				slotToSwapWith.PlayErrorEffect();
			}
		}
	}

	private void UpdateHoverText(bool attemptToUsePrevWidth, float maxWidthToUse = 9.5625f)
	{
		if (Manager.ui.currentSelectedUIElement != null)
		{
			hoverTextContainer.SetActive(value: true);
			this.hoverTitleIcon.enabled = false;
			Manager.ui.currentSelectedUIElement.GetContainedObject();
			ObjectID objectID = Manager.ui.currentSelectedUIElement.GetContainedObject().objectID;
			ObjectInfo objectInfo = ((objectID != ObjectID.None) ? PugDatabase.GetObjectInfo(objectID) : null);
			bool flag = Manager.ui.currentSelectedUIElement is SlotUIBase slotUIBase && slotUIBase.isVanitySlot;
			if (objectID != ObjectID.None && lastRenderedObject == objectID && lastRenderedMaxWidth > 0f && attemptToUsePrevWidth)
			{
				maxWidthToUse = lastRenderedMaxWidth;
			}
			lastRenderedObject = objectID;
			TextAndFormatFields textAndFormatFields = Manager.ui.currentSelectedUIElement.GetHoverTitle();
			bool flag2 = textAndFormatFields != null;
			hoverTitle.gameObject.SetActive(flag2);
			Vector3 vector = new Vector3(0.25f, -0.125f, 0f);
			float num = 0f;
			if (flag2)
			{
				hoverTitle.localize = !textAndFormatFields.dontLocalize;
				hoverTitle.formatFields = textAndFormatFields.formatFields;
				hoverTitle.checkForProfanity = textAndFormatFields.profanityFilter;
				hoverTitle.Render(textAndFormatFields.text);
				hoverTitle.SetTempColor(textAndFormatFields.color);
				vector = UpdatePositionOfHoverText(hoverTitle, vector);
				HoverTitleIconType hoverTitleIconType = Manager.ui.currentSelectedUIElement.GetHoverTitleIconType();
				float num2 = 0f;
				if (hoverTitleIconType != HoverTitleIconType.None)
				{
					num2 = 0.5f;
					this.hoverTitleIcon.enabled = true;
					HoverTitleIcon hoverTitleIcon = hoverTitleIcons[(int)hoverTitleIconType];
					this.hoverTitleIcon.sprite = hoverTitleIcon.sprite;
					this.hoverTitleIcon.color = hoverTitleIcon.color;
				}
				num = hoverTitle.dimensions.width + num2;
			}
			float num3 = (flag2 ? Mathf.Max(num, maxWidthToUse) : maxWidthToUse);
			bool flag3 = Manager.ui.currentSelectedUIElement.CanBeRepaired(Manager.ui.mouse.mouseMode == MouseMode.Reinforce);
			bool flag4 = Manager.ui.mouse.mouseMode == MouseMode.Repair && flag3;
			bool flag5 = Manager.ui.mouse.mouseMode == MouseMode.Reinforce && flag3;
			float extraSpacingFromPrevious = 0.125f;
			List<TextAndFormatFields> list = Manager.ui.currentSelectedUIElement.GetHoverStats(flag5);
			bool flag6 = list != null;
			statsContainer.SetActive(flag6);
			if (flag6)
			{
				List<TextAndFormatFields> list2 = new List<TextAndFormatFields>();
				List<TextAndFormatFields> list3 = new List<TextAndFormatFields>();
				foreach (TextAndFormatFields item4 in list)
				{
					if (item4.isPermanent)
					{
						list3.Add(item4);
					}
					else
					{
						list2.Add(item4);
					}
				}
				for (int i = 0; i < hoverStats.Count; i++)
				{
					hoverStats[i].gameObject.SetActive(value: false);
				}
				int num4 = 0;
				List<List<TextAndFormatFields>> list4 = new List<List<TextAndFormatFields>>();
				list4.Add(list2);
				list4.Add(list3);
				for (int j = 0; j < list4.Count; j++)
				{
					List<TextAndFormatFields> list5 = list4[j];
					PugText pugText = ((j == 0) ? statsTitle : statsTitle2);
					bool flag7 = Manager.ui.currentSelectedUIElement.GetHoverTitleIconType() == HoverTitleIconType.Edible;
					ContainedObjectsBuffer containedObject = Manager.ui.currentSelectedUIElement.GetContainedObject();
					bool flag8 = PugDatabase.HasComponent<PetCD>(containedObject.objectID) && PugDatabase.GetComponent<PetCD>(containedObject.objectID).petType == PetType.Buff;
					if (PugDatabase.HasComponent<LevelEntitiesBuffer>(containedObject.objectID) && PugDatabase.HasComponent<ObjectCategoryTagsCD>(containedObject.objectID) && ObjectCategoryTagsCD.HasTag(PugDatabase.GetComponent<ObjectCategoryTagsCD>(containedObject.objectID).tagsBitMask, ObjectCategoryTag.CanBeUpgraded))
					{
						if (j == 0)
						{
							if (list5.Count > 0)
							{
								int level = PugDatabase.GetComponent<LevelCD>(containedObject.objectID).level;
								level = ((containedObject.variation > 0) ? containedObject.variation : level);
								bool flag9 = Manager.ui.currentSelectedUIElement is UpgradePreviewSlotUI;
								level += (flag9 ? 1 : 0);
								statsTitle.gameObject.SetActive(value: true);
								statsTitle.formatFields = new string[1] { level.ToString() };
								statsTitle.Render("ItemLevel");
								statsTitle.SetTempColor(Manager.ui.itemLevelColor);
								float num5 = statsTitle.dimensions.height / 2f;
								float num6 = ((num5 % 0.0625f > 0f) ? (0.0625f - num5 % 0.0625f) : 0f);
								statsTitle.transform.localPosition = vector - new Vector3(0f, num5 + num6 + 0.0625f, 0f);
								vector -= new Vector3(0f, statsTitle.dimensions.height + 0.0625f, 0f);
								float num7 = statsTitle.dimensions.width + 0.3125f;
								num = ((num7 > num) ? num7 : num);
								if (flag9)
								{
									statsTitle2.gameObject.SetActive(value: true);
									statsTitle2.Render("PlusOne");
									statsTitle2.SetTempColor(Manager.ui.previewReinforcedColor);
									float num8 = 0.25f;
									statsTitle2.transform.localPosition = statsTitle.transform.localPosition + Vector3.right * (statsTitle.dimensions.width + num8);
									float num9 = statsTitle.dimensions.width + num8 + statsTitle2.dimensions.width + 0.3125f;
									num = ((num9 > num) ? num9 : num);
								}
								else
								{
									statsTitle2.gameObject.SetActive(value: false);
								}
							}
							else
							{
								statsTitle.gameObject.SetActive(value: false);
								statsTitle2.gameObject.SetActive(value: false);
							}
						}
					}
					else if (list5.Count > 0 && (flag7 || flag8))
					{
						pugText.gameObject.SetActive(value: true);
						string text = ((!flag7) ? "buffsOwnerTitle" : ((j == 0) ? "whenEaten" : "permanentWhenEaten"));
						pugText.formatFields = null;
						pugText.localize = true;
						pugText.Render(text);
						pugText.SetTempColor(new Color(0.8301887f, 0.7381867f, 0.5756497f));
						float num10 = pugText.dimensions.height / 2f;
						float num11 = ((num10 % 0.0625f > 0f) ? (0.0625f - num10 % 0.0625f) : 0f);
						pugText.transform.localPosition = vector - new Vector3(0f, num10 + num11 + 0.0625f, 0f);
						vector -= new Vector3(0f, pugText.dimensions.height + 0.0625f, 0f);
						float num12 = pugText.dimensions.width + 0.3125f;
						num = ((num12 > num) ? num12 : num);
					}
					else
					{
						pugText.gameObject.SetActive(value: false);
					}
					for (int k = 0; k < list5.Count; k++)
					{
						if (hoverStats.Count <= num4)
						{
							Debug.LogWarning("Too few stat texts in UIMouse. Adding more.");
							HoverConditionUIElement item = UnityEngine.Object.Instantiate(statsTextPrefab, statsContainer.transform);
							hoverStats.Add(item);
						}
						hoverStats[num4].gameObject.SetActive(value: true);
						hoverStats[num4].statText.maxWidth = num3;
						hoverStats[num4].statText.formatFields = list5[k].formatFields;
						hoverStats[num4].statText.Render(list5[k].text);
						hoverStats[num4].statText.SetTempColor(list5[k].color);
						vector = UpdatePositionOfHoverText(hoverStats[num4].statText, vector);
						if (!string.IsNullOrEmpty(list5[k].additionalText))
						{
							hoverStats[num4].additionalStatText.formatFields = new string[1] { list5[k].additionalText };
							hoverStats[num4].additionalStatText.Render("nonLocalizedPlaceholder");
							hoverStats[num4].additionalStatText.transform.localPosition = hoverStats[num4].statText.transform.localPosition + new Vector3(hoverStats[num4].statText.dimensions.width + 0.375f, 0f);
							hoverStats[num4].additionalStatText.SetTempColor(list5[k].additionalTextColor);
						}
						else
						{
							hoverStats[num4].additionalStatText.Render("");
						}
						float num13 = hoverStats[num4].statText.dimensions.width + hoverStats[num4].additionalStatText.dimensions.width + 0.375f;
						num = ((num13 > num) ? num13 : num);
						num4++;
					}
				}
			}
			SetBonusID setBonusID = ((objectID != ObjectID.None) ? setBonusesTable.GetSetBonusID(objectID) : SetBonusID.None);
			bool flag10 = setBonusID != SetBonusID.None && !flag;
			SetBonusInfo setBonusInfo = (flag10 ? setBonusesTable.GetSetBonusInfo(setBonusID) : null);
			bool flag11 = setBonusInfo != null;
			setBonusesContainer.SetActive(flag10 && flag11);
			if (flag10 && flag11)
			{
				vector -= new Vector3(0f, 0.125f, 0f);
				int num14 = 0;
				for (int l = 0; l < setBonusInfo.availablePieces.Count; l++)
				{
					ObjectID objectID2 = setBonusInfo.availablePieces[l];
					if (Manager.main.player != null && Manager.main.player.equipmentHandler.HasNonBrokenGearPieceEquipped(objectID2))
					{
						num14++;
					}
				}
				float num15 = 0.25f;
				for (int m = 0; m < setBonusesStats.Count; m++)
				{
					setBonusesStats[m].gameObject.SetActive(value: false);
				}
				for (int n = 0; n < setBonusInfo.setBonusDatas.Count; n++)
				{
					SetBonusData setBonusData = setBonusInfo.setBonusDatas[n];
					int requiredPieces = setBonusData.requiredPieces;
					if (setBonusesStats.Count <= n)
					{
						Debug.LogError("Too many conditions in set bonus " + setBonusID);
						break;
					}
					ConditionID conditionID = setBonusData.conditionData.conditionID;
					string conditionValueString = ConditionUI.GetConditionValueString(setBonusData.conditionData.conditionID, setBonusData.conditionData.value, showPlusSign: true);
					PugText pugText2 = setBonusesStats[n];
					pugText2.gameObject.SetActive(value: true);
					pugText2.maxWidth = num3;
					string text2 = PugText.ProcessText("Conditions/" + conditionID, new string[1] { conditionValueString }, shouldLocalize: true, shouldLocalizeFormatFields: false);
					pugText2.formatFields = new string[2]
					{
						requiredPieces.ToString(),
						text2
					};
					pugText2.Render("set");
					pugText2.SetTempColor((requiredPieces <= num14) ? Color.yellow : (Color.yellow * 0.5f));
					vector = UpdatePositionOfHoverText(pugText2, vector);
					float width = pugText2.dimensions.width;
					num = ((width > num) ? width : num);
				}
				for (int num16 = 0; num16 < setBonusesPieces.Count; num16++)
				{
					setBonusesPieces[num16].gameObject.SetActive(value: false);
				}
				float num17 = 0f;
				Vector3 previousTextBottom = vector;
				for (int num18 = 0; num18 < setBonusInfo.availablePieces.Count; num18++)
				{
					if (setBonusesPieces.Count <= num18)
					{
						Debug.LogError("Too many gear pieces in set bonus " + setBonusID);
						break;
					}
					ObjectID objectID3 = setBonusInfo.availablePieces[num18];
					PugText pugText3 = setBonusesPieces[num18];
					pugText3.gameObject.SetActive(value: true);
					pugText3.maxWidth = num3;
					string text3 = "Items/" + objectID3;
					pugText3.localize = true;
					string language = Manager.prefs.language;
					pugText3.Render(text3);
					bool flag12 = Manager.main.player != null && Manager.main.player.equipmentHandler.HasNonBrokenGearPieceEquipped(objectID3);
					pugText3.SetTempColor(flag12 ? Color.white : Color.gray);
					if ((language == "zh-CN" || language == "zh-TW") && num17 + pugText3.dimensions.width < num3 && num18 < setBonusInfo.availablePieces.Count - 1)
					{
						previousTextBottom = UpdatePositionOfHoverText(pugText3, vector);
						float num19 = ((num17 == 0f) ? 0f : 0.375f);
						pugText3.transform.localPosition += new Vector3(num17 + num19, 0f, 0f);
						num17 += pugText3.dimensions.width + num19;
					}
					else
					{
						vector = UpdatePositionOfHoverText(pugText3, previousTextBottom);
						previousTextBottom = vector;
						num17 = 0f;
					}
					float num20 = pugText3.dimensions.width + num15;
					num = ((num20 > num) ? num20 : num);
				}
			}
			List<TextAndFormatFields> list6 = new List<TextAndFormatFields>();
			if (objectID != ObjectID.None && PugDatabase.HasComponent<CastItemCD>(objectID))
			{
				string term = PugDatabase.GetComponent<CastItemCD>(objectID).useType.ToString();
				list6.Add(new TextAndFormatFields
				{
					text = "useItemTerm",
					formatFields = new string[1] { LocalizationManager.GetTranslation(term) }
				});
			}
			ObjectID objectID4 = ((objectID != ObjectID.None && PugDatabase.HasComponent<ParchmentRecipeCD>(objectID)) ? PugDatabase.GetComponent<ParchmentRecipeCD>(objectID).requiresNearbyObject : ObjectID.None);
			if (objectID4 != ObjectID.None)
			{
				bool flag13 = player.IsAtRequiredObject(objectID4);
				string text4 = objectID4.ToString();
				if (API.Authoring.ObjectProperties.TryGetPropertyString(objectID4, "name", out var value))
				{
					text4 = value;
				}
				list6.Add(new TextAndFormatFields
				{
					text = "requiresNearbyObject",
					formatFields = new string[1] { LocalizationManager.GetTranslation("Items/" + text4) },
					color = (flag13 ? Constants.GOOD_GREEN : Constants.BAD_RED)
				});
			}
			if (objectInfo != null && PugDatabase.TryGetComponent<ElectricityCD>(objectInfo.objectID, out var component) && component.ShouldDisplayedRequireElectricity())
			{
				list6.Add(new TextAndFormatFields
				{
					text = requiresElectricityTerm.mTerm,
					color = Manager.ui.electricityColor
				});
			}
			if (objectID != ObjectID.None && PugDatabase.HasComponent<CookingIngredientCD>(objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = canBeCookedTerm.mTerm,
					color = canBeCookedColor
				});
			}
			if (objectInfo != null && objectInfo.rarity == Rarity.Poor)
			{
				list6.Add(new TextAndFormatFields
				{
					text = valuableTerm.mTerm
				});
			}
			if (objectID != ObjectID.None && PugDatabase.HasComponent<PaintableObjectCD>(objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = canBePaintedTerm.mTerm
				});
			}
			if (objectInfo != null && objectInfo.objectType == ObjectType.Offhand)
			{
				list6.Add(new TextAndFormatFields
				{
					text = canBeEquippedInOffhandTerm.mTerm
				});
			}
			if (objectInfo != null && objectInfo.objectType == ObjectType.UniqueCraftingComponent)
			{
				list6.Add(new TextAndFormatFields
				{
					text = uniqueCraftingComponentTerm.mTerm
				});
			}
			if (objectInfo != null && objectInfo.objectType == ObjectType.KeyItem)
			{
				list6.Add(new TextAndFormatFields
				{
					text = "keyItem"
				});
			}
			if (objectInfo != null && PugDatabase.HasComponent<InstrumentCD>(objectInfo.objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = "instrumentItem"
				});
			}
			if (objectInfo != null && PugDatabase.HasComponent<InstrumentSongInfoCD>(objectInfo.objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = "musicSheetItem"
				});
			}
			if (objectInfo != null && PugDatabase.HasComponent<ObjectCategoryTagsCD>(objectInfo.objectID) && ObjectCategoryTagsCD.HasTag(PugDatabase.GetComponent<ObjectCategoryTagsCD>(objectInfo.objectID).tagsBitMask, ObjectCategoryTag.PetEgg))
			{
				list6.Add(new TextAndFormatFields
				{
					text = "petEgg"
				});
			}
			if (objectInfo != null && PugDatabase.HasComponent<PetCandyCD>(objectInfo.objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = "petCandy",
					formatFields = new string[1] { PugDatabase.GetComponent<PetCandyCD>(objectInfo.objectID).xp.ToString() }
				});
			}
			if (objectInfo != null && PugDatabase.HasComponent<IsHabitableIdolCD>(objectInfo.objectID))
			{
				list6.Add(new TextAndFormatFields
				{
					text = "habitableIdol"
				});
			}
			bool flag14 = list6.Count > 0;
			tagsContainer.SetActive(flag14);
			if (flag14)
			{
				for (int num21 = 0; num21 < tagsTexts.Count; num21++)
				{
					tagsTexts[num21].gameObject.SetActive(value: false);
				}
				for (int num22 = 0; num22 < list6.Count; num22++)
				{
					if (tagsTexts.Count <= num22)
					{
						Debug.LogWarning("Too few tags texts in UIMouse. Adding more.");
						PugText item2 = UnityEngine.Object.Instantiate(tagPrefab, tagsContainer.transform);
						tagsTexts.Add(item2);
					}
					tagsTexts[num22].gameObject.SetActive(value: true);
					tagsTexts[num22].maxWidth = num3;
					tagsTexts[num22].formatFields = list6[num22].formatFields;
					tagsTexts[num22].Render(list6[num22].text);
					if (list6[num22].color != default(Color))
					{
						tagsTexts[num22].SetTempColor(list6[num22].color);
					}
					vector = UpdatePositionOfHoverText(tagsTexts[num22], vector);
					float width2 = tagsTexts[num22].dimensions.width;
					num = ((width2 > num) ? width2 : num);
				}
			}
			int level3;
			bool isMaxLevel;
			bool level2 = Manager.ui.currentSelectedUIElement.GetLevel(out level3, out isMaxLevel);
			levelText.gameObject.SetActive(level2);
			if (level2)
			{
				levelText.maxWidth = num3;
				levelText.formatFields = new string[1] { level3.ToString() };
				levelText.Render(isMaxLevel ? "maxLevel" : "level");
				levelText.SetTempColor(Manager.ui.xpAndLevelTextColor);
				float extraSpacingFromPrevious2 = (flag2 ? 0.125f : 0f);
				vector = UpdatePositionOfHoverText(levelText, vector, extraSpacingFromPrevious2);
				float width3 = levelText.dimensions.width;
				num = ((width3 > num) ? width3 : num);
			}
			int durability;
			int maxDurability;
			AmountType amountType;
			bool durabilityOrFullnessOrXp = Manager.ui.currentSelectedUIElement.GetDurabilityOrFullnessOrXp(out durability, out maxDurability, out amountType);
			durabilityText.gameObject.SetActive(durabilityOrFullnessOrXp);
			if (durabilityOrFullnessOrXp)
			{
				durabilityText.maxWidth = num3;
				string text5 = amountType switch
				{
					AmountType.Experience => "experience", 
					AmountType.Fullness => fullnessTerm.mTerm, 
					_ => durabilityTerm.mTerm, 
				};
				if (durabilityText.formatFields == null || durabilityText.formatFields.Length != 2)
				{
					durabilityText.formatFields = new string[2];
				}
				int num23 = (flag5 ? ((int)math.round((float)maxDurability * 2f)) : durability);
				durabilityText.formatFields[0] = num23.ToString();
				durabilityText.formatFields[1] = maxDurability.ToString();
				durabilityText.Render(text5);
				if (amountType == AmountType.Experience)
				{
					durabilityText.SetTempColor(Manager.ui.xpAndLevelTextColor);
				}
				else if (flag5 && (float)durability < (float)maxDurability * 2f)
				{
					durabilityText.SetTempColor(Manager.ui.previewReinforcedColor);
				}
				else if (durability <= 0)
				{
					durabilityText.SetTempColor(Manager.ui.brokenColor);
				}
				else if (durability > maxDurability)
				{
					durabilityText.SetTempColor(Manager.ui.reinforcedColor);
				}
				float extraSpacingFromPrevious3 = ((flag2 && !level2) ? 0.125f : 0f);
				vector = UpdatePositionOfHoverText(durabilityText, vector, extraSpacingFromPrevious3);
				float width4 = durabilityText.dimensions.width;
				num = ((width4 > num) ? width4 : num);
			}
			List<TextAndFormatFields> hoverDescription = Manager.ui.currentSelectedUIElement.GetHoverDescription();
			bool flag15 = hoverDescription != null && hoverDescription.Count > 0;
			descriptionsContainer.SetActive(flag15);
			if (flag15)
			{
				for (int num24 = 0; num24 < hoverDescriptions.Count; num24++)
				{
					hoverDescriptions[num24].gameObject.SetActive(value: false);
				}
				for (int num25 = 0; num25 < hoverDescription.Count; num25++)
				{
					if (hoverDescription[num25].dontLocalize || !string.IsNullOrEmpty(LocalizationManager.GetTranslation(hoverDescription[num25].text)))
					{
						if (hoverDescriptions.Count <= num25)
						{
							Debug.LogWarning("Too few description texts in UIMouse. Adding more.");
							PugText item3 = UnityEngine.Object.Instantiate(descriptionTextPrefab, descriptionsContainer.transform);
							hoverDescriptions.Add(item3);
						}
						hoverDescriptions[num25].gameObject.SetActive(value: true);
						hoverDescriptions[num25].maxWidth = num3;
						hoverDescriptions[num25].localize = !hoverDescription[num25].dontLocalize;
						hoverDescriptions[num25].localizePlaceholders = !hoverDescription[num25].dontLocalizeFormatFields;
						hoverDescriptions[num25].formatFields = hoverDescription[num25].formatFields;
						hoverDescriptions[num25].Render(hoverDescription[num25].text);
						Color color = ((hoverDescription[num25].color != Color.white) ? hoverDescription[num25].color : descriptionsDefaultColor);
						hoverDescriptions[num25].SetTempColor(color);
						vector = UpdatePositionOfHoverText(hoverDescriptions[num25], vector);
						vector = new Vector3(vector.x, vector.y - hoverDescription[num25].paddingBeneath, vector.z);
						float width5 = hoverDescriptions[num25].dimensions.width;
						num = ((width5 > num) ? width5 : num);
					}
				}
			}
			CraftingSettings craftingSettings = Manager.ui.currentSelectedUIElement.GetCraftingSettings();
			List<PugDatabase.MaterialInfo> requiredMaterials = Manager.ui.currentSelectedUIElement.GetRequiredMaterials(flag4, flag5);
			bool flag16 = craftingSettings.canOnlyUseAnyMaterialsWithTag != ObjectCategoryTag.None || (requiredMaterials != null && requiredMaterials.Count > 0);
			hoverMaterialsContainer.SetActive(flag16);
			if (flag16)
			{
				bool flag17 = PugDatabase.HasComponent<ParchmentRecipeCD>(objectID);
				bool flag18 = Manager.ui.currentSelectedUIElement.ShowRequiredMaterialsAmountNumberColor();
				vector -= new Vector3(0f, 0.125f, 0f);
				bool flag19 = Manager.ui.currentSelectedUIElement.MaterialsAreIngredients();
				if (flag5)
				{
					hoverMaterialsTitle.Render("reinforceCost");
				}
				else if (flag4)
				{
					hoverMaterialsTitle.Render("repairCost");
				}
				else if (flag19)
				{
					hoverMaterialsTitle.Render("ingredients");
				}
				else
				{
					hoverMaterialsTitle.Render("materials");
				}
				float num26 = hoverMaterialsTitle.dimensions.height / 2f;
				float num27 = ((num26 % 0.0625f > 0f) ? (0.0625f - num26 % 0.0625f) : 0f);
				hoverMaterialsTitle.transform.localPosition = vector - new Vector3(0f, num26 + num27, 0f);
				vector -= new Vector3(0f, hoverMaterialsTitle.dimensions.height, 0f);
				float num28 = hoverMaterialsTitle.dimensions.width + 0.3125f;
				num = ((num28 > num) ? num28 : num);
				for (int num29 = 0; num29 < hoverMaterials.Count; num29++)
				{
					hoverMaterials[num29].container.SetActive(value: false);
				}
				if (craftingSettings.canOnlyUseAnyMaterialsWithTag == ObjectCategoryTag.None)
				{
					for (int num30 = 0; num30 < requiredMaterials.Count; num30++)
					{
						if (hoverMaterials.Count <= num30)
						{
							Debug.LogError("Too many required materials for item to render, add more hoverMaterials in UIMouse.");
							break;
						}
						if (PugDatabase.HasObject(requiredMaterials[num30].objectID))
						{
							hoverMaterials[num30].container.SetActive(value: true);
							hoverMaterials[num30].text.maxWidth = num3;
							ObjectID anyObjectIDReplaceForNameAndDesc = PlayerController.GetAnyObjectIDReplaceForNameAndDesc(requiredMaterials[num30].objectID);
							if (!API.Authoring.ObjectProperties.TryGetPropertyString(anyObjectIDReplaceForNameAndDesc, "name", out var value2))
							{
								value2 = anyObjectIDReplaceForNameAndDesc.ToString();
							}
							string text6 = "Items/" + value2;
							hoverMaterials[num30].text.Render(text6);
							bool flag20 = objectInfo != null && objectInfo.isStackable && !flag17 && !flag4 && !flag5 && player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.PICK_UP_10);
							int num31 = (flag19 ? requiredMaterials[num30].amountAvailable : (requiredMaterials[num30].amountNeeded * ((!flag20) ? 1 : 10)));
							string text7 = num31.ToString();
							hoverMaterials[num30].amountNumber.Render(text7);
							hoverMaterials[num30].amountNumberShadow.Render(text7);
							hoverMaterials[num30].amountNumberShadow2.Render(text7);
							Color color2 = ((!flag18) ? Color.white : ((requiredMaterials[num30].amountNeeded <= requiredMaterials[num30].amountAvailable) ? Manager.text.goodColor : Manager.text.badColor));
							hoverMaterials[num30].amountNumber.SetTempColor(color2);
							hoverMaterials[num30].SR.color = Color.white;
							hoverMaterials[num30].SR.sprite = PugDatabase.GetObjectInfo(requiredMaterials[num30].objectID).smallIcon;
							float num32 = 0f;
							if (requiredMaterials[num30].nearbyChestWithMaterial != Entity.Null)
							{
								num32 = 2.1875f;
								Sprite nearbyChestIcon = requiredMaterials[num30].nearbyChestIcon;
								hoverMaterials[num30].chestIcon.sprite = nearbyChestIcon;
								hoverMaterials[num30].chestIcon.transform.localPosition = new Vector3(hoverMaterials[num30].text.dimensions.width + num32, 0f, 0f);
								string text8 = ((requiredMaterials[num30].amountAvailable <= 9999) ? $"({requiredMaterials[num30].amountAvailable})" : "(9999+)");
								hoverMaterials[num30].chestAmountNumber.Render(text8);
								hoverMaterials[num30].chestAmountNumberShadow.Render(text8);
								hoverMaterials[num30].chestAmountNumberShadow2.Render(text8);
								hoverMaterials[num30].chestAmountNumber.SetTempColor(new Color(0.7f, 0.7f, 0.7f));
								num32 += 1.25f;
								num32 += ((requiredMaterials[num30].amountAvailable >= 1000) ? 0.375f : 0f);
							}
							else
							{
								hoverMaterials[num30].chestIcon.sprite = null;
								hoverMaterials[num30].chestAmountNumber.Render("");
								hoverMaterials[num30].chestAmountNumberShadow.Render("");
								hoverMaterials[num30].chestAmountNumberShadow2.Render("");
							}
							vector = UpdatePositionOfHoverText(hoverMaterials[num30].text, vector, extraSpacingFromPrevious, hoverMaterials[num30].container);
							float num33 = ((num31 >= 1000) ? 0.375f : 0f);
							Vector3 localPosition = hoverMaterials[num30].container.transform.localPosition;
							hoverMaterials[num30].container.transform.localPosition = new Vector3(num33 + ((hoverMaterials[num30].SR.sprite == null) ? (-0.4375f) : 0.25f), localPosition.y, localPosition.z);
							num28 = hoverMaterials[num30].text.dimensions.width + 1.125f + num32 + num33;
							num = ((num28 > num) ? num28 : num);
						}
					}
				}
				else
				{
					string text9 = craftingSettings.canOnlyUseAnyMaterialsWithTag switch
					{
						ObjectCategoryTag.Sand => "anySandObject", 
						ObjectCategoryTag.UncommonOrLowerCookedFood => "anyCommonEdibleObject", 
						_ => "anyRareEdibleObject", 
					};
					hoverMaterials[0].container.SetActive(value: true);
					hoverMaterials[0].text.maxWidth = num3;
					hoverMaterials[0].text.Render(text9);
					hoverMaterials[0].amountNumber.Render("");
					hoverMaterials[0].amountNumberShadow.Render("");
					hoverMaterials[0].amountNumberShadow2.Render("");
					hoverMaterials[0].SR.color = hoverTitleIcons[(int)craftingSettings.iconType].color;
					hoverMaterials[0].SR.sprite = hoverTitleIcons[(int)craftingSettings.iconType].sprite;
					hoverMaterials[0].chestIcon.sprite = null;
					hoverMaterials[0].chestAmountNumber.Render("");
					hoverMaterials[0].chestAmountNumberShadow.Render("");
					hoverMaterials[0].chestAmountNumberShadow2.Render("");
					vector = UpdatePositionOfHoverText(hoverMaterials[0].text, vector, extraSpacingFromPrevious, hoverMaterials[0].container);
					Vector3 localPosition2 = hoverMaterials[0].container.transform.localPosition;
					hoverMaterials[0].container.transform.localPosition = new Vector3((hoverMaterials[0].SR.sprite == null) ? (-0.4375f) : 0.25f, localPosition2.y, localPosition2.z);
					num28 = hoverMaterials[0].text.dimensions.width + 1.125f;
					num = ((num28 > num) ? num28 : num);
				}
				vector -= new Vector3(0f, 0.1875f, 0f);
			}
			ObjectID filteredObjectID;
			int filteredVariation;
			bool flag21 = TryGetCurrentSelectedItemsFilteredObject(out filteredObjectID, out filteredVariation);
			hoverFiltersContainer.SetActive(flag21);
			if (flag21)
			{
				vector -= new Vector3(0f, 0.125f, 0f);
				float num34 = hoverFilterTitle.dimensions.height / 2f;
				float num35 = ((num34 % 0.0625f > 0f) ? (0.0625f - num34 % 0.0625f) : 0f);
				hoverFilterTitle.transform.localPosition = vector - new Vector3(0f, num34 + num35, 0f);
				vector -= new Vector3(0f, hoverFilterTitle.dimensions.height, 0f);
				float num36 = hoverFilterTitle.dimensions.width + 0.3125f;
				num = ((num36 > num) ? num36 : num);
				filteredObject.container.SetActive(value: true);
				filteredObject.text.maxWidth = num3;
				ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(filteredObjectID, filteredVariation);
				ContainedObjectsBuffer containedObject2 = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = filteredObjectID,
						variation = filteredVariation
					}
				};
				TextAndFormatFields objectName = PlayerController.GetObjectName(containedObject2, localize: false);
				filteredObject.text.localize = !objectName.dontLocalize;
				filteredObject.text.formatFields = objectName.formatFields;
				filteredObject.text.checkForProfanity = objectName.profanityFilter;
				filteredObject.text.Render(objectName.text);
				filteredObject.SR.color = Color.white;
				Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject2.objectData, getSmallIcon: true);
				Sprite sprite = ((iconOverride != null) ? iconOverride : objectInfo2.smallIcon);
				filteredObject.SR.sprite = sprite;
				Manager.ui.ApplyAnyIconGradientMap(containedObject2, filteredObject.SR);
				filteredObject.colorReplacer.UpdateColorReplacerFromObjectData(containedObject2);
				vector = UpdatePositionOfHoverText(filteredObject.text, vector, extraSpacingFromPrevious, filteredObject.container);
				Vector3 localPosition3 = filteredObject.container.transform.localPosition;
				filteredObject.container.transform.localPosition = new Vector3((filteredObject.SR.sprite == null) ? (-0.4375f) : 0.25f, localPosition3.y, localPosition3.z);
				num36 = filteredObject.text.dimensions.width + 1.125f;
				num = ((num36 > num) ? num36 : num);
				vector -= new Vector3(0f, 0.1875f, 0f);
			}
			int num37 = 0;
			bool flag22 = false;
			if (Manager.ui.currentSelectedUIElement is InventorySlotUI inventorySlotUI && (Manager.ui.isSellUIShowing || (Manager.ui.isBuyUIShowing && inventorySlotUI.slotType == ItemSlotsUIType.BuySlot)))
			{
				ObjectDataCD objectData = inventorySlotUI.GetObjectData();
				ObjectInfo objectInfo3 = null;
				if (objectData.objectID != ObjectID.None)
				{
					objectInfo3 = PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation);
				}
				flag22 = objectData.objectID != ObjectID.None && !PugDatabase.HasComponent<CantBeSoldCD>(objectData) && (objectInfo3 == null || objectInfo3.rarity != Rarity.Legendary);
				num37 = inventorySlotUI.GetCoinValue();
			}
			coinTextContainer.SetActive(flag22);
			if (flag22)
			{
				string text10 = "";
				text10 = ((!Manager.ui.currentSelectedUIElement.CoinValueIsBuyPrice()) ? "value" : "price");
				coinText.localize = true;
				coinText.formatFields = new string[1] { num37.ToString() };
				coinText.Render(text10);
				coinIcon.transform.localPosition = coinText.transform.localPosition + new Vector3(coinText.dimensions.width + 0.3125f, 0f, 0f);
				vector = UpdatePositionOfHoverText(coinText, vector, extraSpacingFromPrevious, coinTextContainer);
				float num38 = coinText.dimensions.width + 1.125f;
				num = ((num38 > num) ? num38 : num);
			}
			bool flag23 = flag2 || flag15 || flag6 || flag16 || flag22 || flag14;
			hoverTextBackground.gameObject.SetActive(flag23);
			if (flag23)
			{
				if (flag16 && craftingSettings.canOnlyUseAnyMaterialsWithTag == ObjectCategoryTag.None)
				{
					TryMakeMaterialsRightAligned(num);
				}
				float num39 = num;
				num39 += 0.5625f;
				if (num39 % 0.125f != 0f)
				{
					num39 += 0.0625f;
				}
				float num40 = Mathf.Abs(vector.y) + 0.125f;
				if (num40 % 0.125f != 0f)
				{
					num40 += 0.0625f;
				}
				if (num40 > 16.5f && maxWidthToUse + 4f < 30f)
				{
					UpdateHoverText(attemptToUsePrevWidth: false, maxWidthToUse + 4f);
					return;
				}
				HoverWindowAlignment hoverWindowAlignment = Manager.ui.currentSelectedUIElement.GetHoverWindowAlignment();
				switch (hoverWindowAlignment)
				{
				case HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR:
					hoverTopLeft.transform.localPosition = new Vector3(0.5f, -0.5f, 0f);
					break;
				case HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN:
					hoverTopLeft.transform.position = new Vector3(base.transform.position.x + 15f, (0f - (base.transform.position.y + 135f)) * 0.0625f, 0f);
					break;
				case HoverWindowAlignment.TOP_LEFT_OF_CURSOR:
					hoverTopLeft.transform.localPosition = new Vector3(0f - num39, num40, 0f);
					break;
				}
				float num41 = num39 / 2f;
				float num42 = num40 / 2f;
				float num43 = ((num41 % 0.0625f > 0f) ? (0.0625f - num41 % 0.0625f) : 0f);
				float num44 = ((num42 % 0.0625f > 0f) ? (0.0625f - num42 % 0.0625f) : 0f);
				hoverTextBackground.transform.localPosition = new Vector2(num41 + num43, 0f - (num42 + num44));
				hoverTextBackground.size = new Vector2(num39, num40);
				hoverTextBlackBackground.size = hoverTextBackground.size;
				Vector3 localPosition4 = hoverTopLeft.transform.localPosition;
				switch (hoverWindowAlignment)
				{
				case HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR:
				case HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN:
				{
					Vector2 position2 = new Vector2(pointer.transform.localPosition.x + hoverTopLeft.transform.localPosition.x, pointer.transform.localPosition.y + hoverTopLeft.transform.localPosition.y - hoverTextBackground.size.y);
					Rect rect2 = new Rect(position2, hoverTextBackground.size);
					if (rect2.min.y < 0f - hoverBackgroundBounds.y)
					{
						localPosition4.y -= Mathf.Abs(hoverBackgroundBounds.y) - Mathf.Abs(rect2.min.y);
					}
					if (rect2.max.x > hoverBackgroundBounds.x)
					{
						localPosition4.x += Mathf.Abs(hoverBackgroundBounds.x) - Mathf.Abs(rect2.max.x);
					}
					break;
				}
				case HoverWindowAlignment.TOP_LEFT_OF_CURSOR:
				{
					Vector2 position = new Vector2(pointer.transform.localPosition.x + hoverTopLeft.transform.localPosition.x, pointer.transform.localPosition.y + hoverTopLeft.transform.localPosition.y - hoverTextBackground.size.y);
					Rect rect = new Rect(position, hoverTextBackground.size);
					if (rect.max.y > hoverBackgroundBounds.y)
					{
						localPosition4.y -= Mathf.Abs(rect.max.y) - Mathf.Abs(hoverBackgroundBounds.y);
					}
					if (rect.min.x < 0f - hoverBackgroundBounds.x)
					{
						localPosition4.x += Mathf.Abs(rect.min.x) - Mathf.Abs(hoverBackgroundBounds.x);
					}
					break;
				}
				}
				hoverTopLeft.transform.localPosition = localPosition4;
			}
			if (this.hoverTitleIcon.enabled)
			{
				this.hoverTitleIcon.transform.localPosition = hoverTextBackground.size / 2f - new Vector2(0.5f, 0.5f);
			}
			lastRenderedMaxWidth = maxWidthToUse;
		}
		else
		{
			hoverTextContainer.SetActive(value: false);
		}
	}

	private void TryMakeMaterialsRightAligned(float widestWidth)
	{
		float num = 0f;
		for (int i = 0; i < hoverMaterials.Count; i++)
		{
			if (hoverMaterials[i].chestIcon.sprite != null)
			{
				num = Mathf.Max(hoverMaterials[i].chestAmountNumber.dimensions.width, num);
			}
		}
		for (int j = 0; j < hoverMaterials.Count; j++)
		{
			float x = hoverMaterials[j].container.transform.localPosition.x;
			float num2 = num + 0.3125f;
			Vector3 localPosition = hoverMaterials[j].chestIcon.transform.localPosition;
			localPosition.x = widestWidth - x - num2;
			hoverMaterials[j].chestIcon.transform.localPosition = localPosition;
		}
	}

	private bool TryGetCurrentSelectedItemsFilteredObject(out ObjectID filteredObjectID, out int filteredVariation)
	{
		filteredObjectID = ObjectID.None;
		filteredVariation = 0;
		if (Manager.ui.currentSelectedUIElement is FilteringSlotUI filteringSlotUI)
		{
			return filteringSlotUI.TryGetFilteredObject(out filteredObjectID, out filteredVariation);
		}
		return false;
	}

	private void UpdateSlotHighlights()
	{
		bool flag = Manager.ui.currentSelectedUIElement is InventorySlotUI;
		bool flag2 = Manager.ui.currentSelectedUIElement is CookBookRecipe;
		bool flag3 = Manager.ui.currentSelectedUIElement is RecipeSlotUI;
		bool flag4 = Manager.ui.currentSelectedUIElement is RecipeCategorySlotUI;
		if (flag || flag2 || flag3 || flag4)
		{
			ObjectID objectID = Manager.ui.currentSelectedUIElement.GetContainedObject().objectID;
			ObjectInfo objectInfo = ((objectID != ObjectID.None) ? PugDatabase.GetObjectInfo(objectID) : null);
			if (lastSlotHovered == (SlotUIBase)Manager.ui.currentSelectedUIElement && objectInfo == lastHoverObject)
			{
				return;
			}
			lastHoverObject = objectInfo;
			lastSlotHovered = (SlotUIBase)Manager.ui.currentSelectedUIElement;
			if (flag)
			{
				HightlightByMatchingEquipmentSlots();
				return;
			}
			ClearEquipmentSlotHighlights();
			if (flag2)
			{
				HighlightByMatchingCookBookRecipeMaterials();
			}
			else if (flag3)
			{
				HighlightByMatchingRecipeMaterials();
			}
			else
			{
				HighlightByMatchingRecipeCategoryMaterials();
			}
		}
		else
		{
			if (!(lastSlotHovered != null))
			{
				return;
			}
			foreach (SlotUIBase itemSlot in Manager.ui.playerInventoryUI.itemSlots)
			{
				itemSlot.highlightBorder.gameObject.SetActive(value: false);
			}
			ClearEquipmentSlotHighlights();
			lastHoverObject = null;
			lastSlotHovered = null;
		}
	}

	private void HightlightByMatchingEquipmentSlots()
	{
		if (lastSlotHovered.slotType == ItemSlotsUIType.PlayerInventorySlot)
		{
			PugDatabase.TryGetObjectInfo(lastSlotHovered.GetContainedObject().objectID, out var objectInfo);
			foreach (SlotUIBase itemSlot in Manager.ui.equipmentInventoryUI.itemSlots)
			{
				bool active = objectInfo != null && InventoryUtility.ItemMatchesSlot(itemSlot, objectInfo);
				itemSlot.highlightBorder.gameObject.SetActive(active);
			}
			{
				foreach (ISlotHoverProxy itemHoverProxy in Manager.ui.equipmentInventoryUI.itemHoverProxies)
				{
					bool flag = false;
					foreach (SlotUIBase proxySlot in itemHoverProxy.GetProxySlots())
					{
						flag |= objectInfo != null && !proxySlot.gameObject.activeInHierarchy && InventoryUtility.ItemMatchesSlot(proxySlot, objectInfo);
					}
					itemHoverProxy.SetHighliged(flag);
				}
				return;
			}
		}
		foreach (SlotUIBase itemSlot2 in Manager.ui.playerInventoryUI.itemSlots)
		{
			if (itemSlot2.gameObject.activeInHierarchy)
			{
				PugDatabase.TryGetObjectInfo(itemSlot2.GetContainedObject().objectID, out var objectInfo2);
				bool active2 = objectInfo2 != null && InventoryUtility.ItemMatchesSlot(lastSlotHovered, objectInfo2);
				itemSlot2.highlightBorder.gameObject.SetActive(active2);
			}
		}
	}

	private void HighlightByMatchingCookBookRecipeMaterials()
	{
		List<PugDatabase.MaterialInfo> requiredMaterials = ((CookBookRecipe)lastSlotHovered).GetRequiredMaterials(isRepairing: false, isReinforcing: false);
		foreach (SlotUIBase itemSlot in Manager.ui.playerInventoryUI.itemSlots)
		{
			if (!itemSlot.gameObject.activeInHierarchy)
			{
				continue;
			}
			ContainedObjectsBuffer containedObject = itemSlot.GetContainedObject();
			bool active = false;
			foreach (PugDatabase.MaterialInfo item in requiredMaterials)
			{
				if (item.objectID == containedObject.objectID)
				{
					active = true;
					break;
				}
			}
			itemSlot.highlightBorder.gameObject.SetActive(active);
		}
	}

	private void HighlightByMatchingRecipeMaterials()
	{
		List<PugDatabase.MaterialInfo> requiredMaterials = ((RecipeSlotUI)lastSlotHovered).GetRequiredMaterials(isRepairing: false, isReinforcing: false);
		foreach (SlotUIBase itemSlot in Manager.ui.playerInventoryUI.itemSlots)
		{
			if (!itemSlot.gameObject.activeInHierarchy)
			{
				continue;
			}
			ContainedObjectsBuffer containedObject = itemSlot.GetContainedObject();
			bool active = false;
			if (requiredMaterials != null)
			{
				foreach (PugDatabase.MaterialInfo item in requiredMaterials)
				{
					if (item.objectID == containedObject.objectID)
					{
						active = true;
						break;
					}
				}
			}
			itemSlot.highlightBorder.gameObject.SetActive(active);
		}
	}

	private void HighlightByMatchingRecipeCategoryMaterials()
	{
		ObjectCategoryTag recipeRequiredCategoryTag = ((RecipeCategorySlotUI)lastSlotHovered).GetRecipeRequiredCategoryTag();
		foreach (SlotUIBase itemSlot in Manager.ui.playerInventoryUI.itemSlots)
		{
			if (itemSlot.gameObject.activeInHierarchy)
			{
				ContainedObjectsBuffer containedObject = itemSlot.GetContainedObject();
				PugDatabase.TryGetObjectInfo(containedObject.objectID, out var objectInfo);
				bool active = objectInfo != null && objectInfo.tags.Contains(recipeRequiredCategoryTag) && PugDatabase.HasComponent<ExtractableCD>(containedObject.objectID);
				itemSlot.highlightBorder.gameObject.SetActive(active);
			}
		}
	}

	private void ClearEquipmentSlotHighlights()
	{
		foreach (SlotUIBase itemSlot in Manager.ui.equipmentInventoryUI.itemSlots)
		{
			itemSlot.highlightBorder.gameObject.SetActive(value: false);
		}
		foreach (ISlotHoverProxy itemHoverProxy in Manager.ui.equipmentInventoryUI.itemHoverProxies)
		{
			itemHoverProxy.SetHighliged(anySlotShouldBeProxied: false);
		}
	}

	private Vector3 UpdatePositionOfHoverText(PugText text, Vector3 previousTextBottom, float extraSpacingFromPrevious = 0f, GameObject optionalContainer = null)
	{
		Transform obj = ((optionalContainer != null) ? optionalContainer.transform : text.transform);
		float num = Math.Max(1f, 2f * (float)text.displayedTextStringLinesAmount);
		float num2 = text.dimensions.height / num;
		float num3 = ((num2 % 0.0625f > 0f) ? (0.0625f - num2 % 0.0625f) : 0f);
		obj.localPosition = previousTextBottom - new Vector3(0f, num2 + num3 + extraSpacingFromPrevious, 0f);
		previousTextBottom -= new Vector3(0f, text.dimensions.height + extraSpacingFromPrevious, 0f);
		if (num3 > 0f)
		{
			previousTextBottom -= new Vector3(0f, 0.0625f, 0f);
		}
		return previousTextBottom;
	}

	private void UIPickUpSound()
	{
		AudioManager.SfxUI(SfxID.uiPickup, 1.1f, reuse: true, 1f, 0.2f);
	}

	private void UIDropSound()
	{
		AudioManager.SfxUI(SfxID.uiPickup, 0.4f, reuse: true, 1f, 0.1f);
	}

	public Vector3 GetMouseGameViewPosition()
	{
		Vector2 mouseViewPosition = GetMouseViewPosition(Manager.camera.gameCamera);
		Vector3 localPosition = Manager.camera.gameCamera.transform.parent.localPosition;
		return new Vector3(mouseViewPosition.x, 0f, mouseViewPosition.y) + new Vector3(localPosition.x, 0f, localPosition.z + 20f);
	}

	public Vector2 ToMouseViewSpace(Vector3 viewPosition)
	{
		Vector3 localPosition = Manager.camera.gameCamera.transform.parent.localPosition;
		return viewPosition.XZ() - new Vector2(localPosition.x, localPosition.z + 20f);
	}

	public Vector2 GetMouseUIViewPosition()
	{
		return GetMouseViewPosition(Manager.camera.gameCamera);
	}

	private Vector2 GetMouseViewPosition(Camera camera)
	{
		PugCamera pugCamera = camera.GetPugCamera();
		Vector2 mousePosition = Input.mousePosition;
		return pugCamera.TransformMousePosition(mousePosition) / 16f;
	}
}
