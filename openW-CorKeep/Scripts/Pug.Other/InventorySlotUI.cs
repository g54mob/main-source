using System;
using System.Collections.Generic;
using PlayerEquipment;
using Pug.UnityExtensions;
using PugMod;
using Unity.Mathematics;
using UnityEngine;

public class InventorySlotUI : SlotUIBase
{
	public PugText buttonNumber;

	private TimerSimple holdDownBuyTimer;

	private const float TIME_BETWEEN_BUYS_SPEED1 = 0.35f;

	private const float TIME_BETWEEN_BUYS_SPEED2 = 0.1f;

	private const int INCREASE_PICKUP_EVERY = 20;

	private float timeBetweenBuysWhenHolding;

	private int buysDoneWhileHolding;

	private const float FADED_ALPHA = 0.4f;

	private const float DEACTIVATED_ALPHA = 0.1f;

	private bool initialized;

	public GameObject hintContainer;

	public PugText amountNeededNumber;

	public PugText amountNeededNumberOutline;

	public SpriteRenderer hintIcon;

	public ColorReplacer colorReplacer;

	public ColorReplacer hintColorReplacer;

	public bool useWhiteColoredBorderForCommonItems;

	public SpriteRenderer backgroundIcon;

	public GameObject barContainer;

	public Transform barPivot;

	public SpriteRenderer bar;

	public GameObject reinforceBarContainer;

	public Transform reinforceBarPivot;

	public SpriteRenderer reinforceBar;

	public Transform cooldownPivot;

	public Color waterBarColor;

	public Color xpBarColor;

	public Color fullDurabilityBarColor;

	public Color lowDurabilityBarColor;

	public Color fullReinforceBarColor;

	public Color lowReinforceBarColor;

	public bool showSillhouette;

	public bool dontOverrideHintColor;

	public SpriteRenderer vanitySlotVisibilityHiddenSR;

	public SpriteRenderer lockedIcon;

	public GameObject loopEffect;

	private static readonly string[] ButtonNumbers = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

	protected ObjectID currentObjectIDHint;

	protected bool shouldShowSilhouetteOfHint;

	protected bool itemIsRequired;

	private bool deactivated;

	[NonSerialized]
	public float backgroundDefaultAlpha;

	[NonSerialized]
	public float darkBackgroundDefaultAlpha;

	private int previousVariationShown;

	private ContainedObjectsBuffer? _cachedContainedObject;

	private bool? _cachedCanAfford;

	private float? _cachedCooldown;

	private ItemSlotsUIContainer _cachedSlotsUIContainer;

	private int? _cachedVisibleSlotIndex;

	private ItemSlotsUIType? _cachedSlotType;

	private bool? _cachedUseWhiteColoredBorderForCommonItems;

	private int? _cachedSkinIndex;

	private ObjectID? _cachedHintToShow;

	private bool? _cachedIsLockedObject;

	[NonSerialized]
	public bool dirty;

	private const string requiresItem = "requiresItem";

	public bool isPlayerInventorySlot => slotType == ItemSlotsUIType.PlayerInventorySlot;

	public bool isPlayerPouchSlot => slotType == ItemSlotsUIType.PouchInventorySlot;

	public bool showLockedBorder
	{
		get
		{
			if (slotsUIContainer != null)
			{
				return !slotsUIContainer.dontShowLockedIcon;
			}
			return false;
		}
	}

	private InventoryHandler inventoryHandler => GetInventoryHandler();

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y + ((slotsUIContainer != null && slotsUIContainer.isPouchInventory) ? (slotsUIContainer.transform.localPosition.y + slotsUIContainer.transform.parent.parent.localPosition.y) : 0f);

	private bool showHoverWindow
	{
		get
		{
			if (!(slotsUIContainer == null) && !(slotsUIContainer.scrollWindow == null) && visibleSlotIndex >= 10)
			{
				return slotsUIContainer.scrollWindow.IsShowingPosition(localScrollPosition, background.size.y / 2f);
			}
			return true;
		}
	}

	public override bool isVisibleOnScreen
	{
		get
		{
			if (showHoverWindow)
			{
				return base.isVisibleOnScreen;
			}
			return false;
		}
	}

	public override UIScrollWindow uiScrollWindow
	{
		get
		{
			if (!(slotsUIContainer != null))
			{
				return null;
			}
			if (!isPlayerPouchSlot)
			{
				return slotsUIContainer.scrollWindow;
			}
			return Manager.ui.playerInventoryUI.scrollWindow;
		}
	}

	private bool ShouldShowSilhouetteOfHint(ObjectDataCD objectData)
	{
		if (showSillhouette)
		{
			return !Manager.saves.HasDiscoveredObject(objectData.objectID, objectData.variation);
		}
		return false;
	}

	public int GetCoinValue()
	{
		return GetInventoryHandler()?.GetCoinValue(Manager.main.player, slotType == ItemSlotsUIType.BuySlot, base.inventorySlotIndex) ?? 0;
	}

	private bool CanAffordItem()
	{
		return GetCoinValue() <= Manager.main.player.playerInventoryHandler.GetExistingAmountOfObject(ObjectID.AncientCoin);
	}

	protected override void Awake()
	{
		if (hintContainer != null)
		{
			hintContainer.SetActive(value: false);
		}
		if (barContainer != null)
		{
			barContainer.SetActive(value: false);
		}
		if (cooldownPivot != null)
		{
			cooldownPivot.localScale = Vector3.zero;
		}
		if (lockedIcon != null)
		{
			lockedIcon.gameObject.SetActive(value: false);
		}
		if (background != null)
		{
			backgroundDefaultAlpha = background.color.a;
		}
		if (darkBackground != null)
		{
			darkBackgroundDefaultAlpha = darkBackground.color.a;
		}
		base.Awake();
		initialized = true;
	}

	public ObjectDataCD GetObjectData()
	{
		if (inventoryHandler == null)
		{
			return default(ObjectDataCD);
		}
		return inventoryHandler.GetObjectData(base.inventorySlotIndex);
	}

	public ContainedObjectsBuffer GetContainedObjectData()
	{
		if (inventoryHandler == null)
		{
			return default(ContainedObjectsBuffer);
		}
		return inventoryHandler.GetContainedObjectData(base.inventorySlotIndex);
	}

	public bool HasObject()
	{
		if (inventoryHandler == null)
		{
			return false;
		}
		return inventoryHandler.HasObject(base.inventorySlotIndex);
	}

	public void ShowHint(ObjectDataCD objectData, bool showSilhouette, bool _itemIsRequired = false, Sprite overrideSprite = null, float overrideAlpha = 0f)
	{
		if (hintIcon == null)
		{
			return;
		}
		currentObjectIDHint = objectData.objectID;
		shouldShowSilhouetteOfHint = showSilhouette && ShouldShowSilhouetteOfHint(objectData);
		itemIsRequired = _itemIsRequired;
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
		if (icon.sprite == null)
		{
			hintIcon.sprite = ((overrideSprite != null) ? overrideSprite : objectInfo.icon);
			hintIcon.transform.localPosition = ((overrideSprite != null) ? Vector2.zero : objectInfo.iconOffset);
			if (hintColorReplacer != null)
			{
				hintColorReplacer.UpdateColorReplacerFromObjectData(new ContainedObjectsBuffer
				{
					objectData = objectData
				});
			}
			if (!dontOverrideHintColor)
			{
				if (shouldShowSilhouetteOfHint)
				{
					hintIcon.color = Color.black;
				}
				else
				{
					hintIcon.color = Color.white;
				}
				if (overrideAlpha > 0f)
				{
					hintIcon.SetAlpha(overrideAlpha);
				}
				else
				{
					hintIcon.SetAlpha(itemIsRequired ? 0.1f : 0.5f);
				}
			}
		}
		else
		{
			hintIcon.sprite = null;
		}
		hintContainer.SetActive(value: true);
	}

	public void HideHint()
	{
		if (hintIcon != null)
		{
			hintIcon.sprite = null;
		}
		if (hintIcon != null)
		{
			hintContainer.SetActive(value: false);
		}
		currentObjectIDHint = ObjectID.None;
	}

	private bool ShouldRefreshRarityBorder()
	{
		if (Manager.ui.mouse.mouseMode == UIMouse.MouseMode.QuickTrash || Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Locking)
		{
			return slotType != ItemSlotsUIType.PlayerInventorySlot;
		}
		return true;
	}

	private bool IsRarityBorderApplicableToSlot()
	{
		if (slotType != ItemSlotsUIType.BreastSlot && slotType != ItemSlotsUIType.ChestSlot && slotType != ItemSlotsUIType.HelmSlot && slotType != ItemSlotsUIType.NecklaceSlot && slotType != ItemSlotsUIType.PantsSlot && slotType != ItemSlotsUIType.RingSlot1 && slotType != ItemSlotsUIType.RingSlot2 && slotType != ItemSlotsUIType.OffhandSlot && slotType != ItemSlotsUIType.BagSlot && slotType != ItemSlotsUIType.PetSlot && slotType != ItemSlotsUIType.LanternSlot && slotType != ItemSlotsUIType.PlayerInventorySlot && slotType != ItemSlotsUIType.PlayerSellSlot && slotType != ItemSlotsUIType.BuySlot && slotType != ItemSlotsUIType.HelmVanitySlot && slotType != ItemSlotsUIType.BreastVanitySlot && slotType != ItemSlotsUIType.PantsVanitySlot && slotType != ItemSlotsUIType.PouchInventorySlot && slotType != ItemSlotsUIType.Pouch1 && slotType != ItemSlotsUIType.Pouch2 && slotType != ItemSlotsUIType.Pouch3)
		{
			return slotType == ItemSlotsUIType.Pouch4;
		}
		return true;
	}

	public override void UpdateSlot()
	{
		if (inventoryHandler == null)
		{
			return;
		}
		if (!initialized)
		{
			Awake();
		}
		ContainedObjectsBuffer containedObjectsBuffer = (deactivated ? default(ContainedObjectsBuffer) : GetContainedObjectData());
		bool flag = slotType == ItemSlotsUIType.BuySlot && CanAffordItem();
		int num = 0;
		ObjectID objectID = ObjectID.None;
		if (PugDatabase.HasComponent<PetCD>(containedObjectsBuffer.objectID))
		{
			if (InventoryHandler.TryGetExtraInventoryData<PetSkinCD>(containedObjectsBuffer, out var data))
			{
				num = data.skinIndex;
			}
			else
			{
				containedObjectsBuffer = default(ContainedObjectsBuffer);
			}
		}
		if (containedObjectsBuffer.objectID == ObjectID.None && EntityUtility.HasComponentData<ChangeVariationWhenContainingObjectCD>(inventoryHandler.entityMonoBehaviour.entity, base.world))
		{
			objectID = EntityUtility.GetComponentData<ChangeVariationWhenContainingObjectCD>(inventoryHandler.entityMonoBehaviour.entity, base.world).objectID;
		}
		bool flag2 = lockedIcon != null && (isPlayerInventorySlot || isPlayerPouchSlot) && showLockedBorder && inventoryHandler.IsLockedObject(base.inventorySlotIndex);
		bool num2 = !_cachedContainedObject.HasValue || !_cachedContainedObject.Value.EqualsExact(containedObjectsBuffer);
		bool flag3 = !_cachedCanAfford.HasValue || _cachedCanAfford.Value != flag;
		bool flag4 = _cachedSlotsUIContainer != slotsUIContainer;
		bool flag5 = !_cachedVisibleSlotIndex.HasValue || _cachedVisibleSlotIndex.Value != visibleSlotIndex;
		bool flag6 = !_cachedSlotType.HasValue || _cachedSlotType.Value != slotType;
		bool flag7 = !_cachedUseWhiteColoredBorderForCommonItems.HasValue || _cachedUseWhiteColoredBorderForCommonItems.Value != useWhiteColoredBorderForCommonItems;
		bool flag8 = !_cachedSkinIndex.HasValue || _cachedSkinIndex.Value != num;
		bool flag9 = !_cachedHintToShow.HasValue || _cachedHintToShow.Value != objectID;
		bool flag10 = !_cachedIsLockedObject.HasValue || _cachedIsLockedObject.Value != flag2;
		float num3 = 0f;
		if (cooldownPivot != null && slotType == ItemSlotsUIType.PlayerInventorySlot && slotsUIContainer.keepSlotsEnabledAfterInit)
		{
			float num4;
			if (!_cachedContainedObject.HasValue)
			{
				num4 = 0f;
			}
			else
			{
				ContainedObjectsBuffer value = _cachedContainedObject.Value;
				num4 = EquipmentSlot.GetNormalizedCooldownRemainingForItem(in value.objectData);
			}
			num3 = num4;
		}
		bool flag11 = !_cachedCooldown.HasValue || Math.Abs(_cachedCooldown.Value - num3) > 1.1920929E-07f;
		if (cooldownPivot != null && flag11)
		{
			cooldownPivot.localScale = new Vector3(1f, num3, 1f);
		}
		_cachedCooldown = num3;
		if (base.leftClickIsHeldDown && slotType == ItemSlotsUIType.BuySlot)
		{
			if (!holdDownBuyTimer.isRunning || holdDownBuyTimer.isTimerElapsed)
			{
				if (buysDoneWhileHolding > 0)
				{
					timeBetweenBuysWhenHolding = 0.1f;
				}
				holdDownBuyTimer.Start(timeBetweenBuysWhenHolding);
				if (buysDoneWhileHolding > 0)
				{
					AttemptToBuyItem(playErrorOnFail: false);
				}
				buysDoneWhileHolding++;
			}
		}
		else if (base.rightClickIsHeldDown)
		{
			if (!holdDownBuyTimer.isRunning || holdDownBuyTimer.isTimerElapsed)
			{
				if (buysDoneWhileHolding > 0)
				{
					timeBetweenBuysWhenHolding = 0.1f;
				}
				holdDownBuyTimer.Start(timeBetweenBuysWhenHolding);
				if (buysDoneWhileHolding > 0)
				{
					OnRightClicked(base.mod1IsHeldDown, base.mod2IsHeldDown, 1 + buysDoneWhileHolding / 20);
				}
				buysDoneWhileHolding++;
			}
		}
		else
		{
			holdDownBuyTimer.Stop();
			timeBetweenBuysWhenHolding = 0.35f;
			buysDoneWhileHolding = 0;
		}
		RenderButtonNumber();
		if (loopEffect != null)
		{
			bool active = false;
			CraftingHandler craftingHandler = Manager.main.player?.activeCraftingHandler;
			if (craftingHandler != null)
			{
				active = craftingHandler.HasStartedCrafting(base.inventorySlotIndex) && craftingHandler.IsCrafting(base.inventorySlotIndex) && EntityUtility.TryGetComponentData<CraftingVisualCD>(craftingHandler.craftingEntity, base.world, out var value2) && value2.showLoopEffectOnOutputSlot;
			}
			loopEffect.SetActive(active);
		}
		if (!num2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7 && !flag8 && !flag9 && !flag10 && !dirty)
		{
			return;
		}
		_cachedContainedObject = containedObjectsBuffer;
		_cachedCanAfford = flag;
		_cachedSlotsUIContainer = slotsUIContainer;
		_cachedVisibleSlotIndex = visibleSlotIndex;
		_cachedSlotType = slotType;
		_cachedUseWhiteColoredBorderForCommonItems = useWhiteColoredBorderForCommonItems;
		_cachedSkinIndex = num;
		_cachedHintToShow = objectID;
		_cachedIsLockedObject = flag2;
		dirty = false;
		if (slotType == ItemSlotsUIType.BuySlot)
		{
			if (flag)
			{
				icon.color = Color.white;
			}
			else
			{
				icon.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
			}
			if (darkBackground != null)
			{
				darkBackground.enabled = false;
			}
		}
		else
		{
			if (darkBackground != null)
			{
				darkBackground.enabled = true;
			}
			if (PugDatabase.GetObjectInfo(containedObjectsBuffer.objectID, containedObjectsBuffer.variation) != null && containedObjectsBuffer.amount <= 0 && PugDatabase.HasComponent<DurabilityCD>(containedObjectsBuffer.objectID) && !base.isVanitySlot)
			{
				icon.color = Manager.ui.brokenColor;
			}
			else
			{
				icon.color = Color.white;
			}
		}
		bool flag12 = false;
		UIManager.ObjectCategoryTagColor objectCategoryTagColor = ((slotsUIContainer != null && slotsUIContainer.overrideSlotsBackgroundColor != null) ? slotsUIContainer.overrideSlotsBackgroundColor : null);
		Color white = Color.white;
		if (ShouldRefreshRarityBorder())
		{
			if (IsRarityBorderApplicableToSlot())
			{
				background.color = Manager.ui.GetSlotBorderRarityColor(Rarity.Common, useWhiteColoredBorderForCommonItems, white);
			}
			else
			{
				background.color = white;
			}
		}
		if (objectCategoryTagColor != null)
		{
			darkBackground.color = objectCategoryTagColor.backgroundColor;
		}
		bool active2 = Manager.ui.ShouldShowCageOverlay(containedObjectsBuffer);
		if (overlayIcon != null)
		{
			overlayIcon.gameObject.SetActive(active2);
		}
		if (underlayIcon != null)
		{
			underlayIcon.gameObject.SetActive(active2);
		}
		if (vanitySlotVisibilityHiddenSR != null)
		{
			vanitySlotVisibilityHiddenSR.gameObject.SetActive(base.isVanitySlot && containedObjectsBuffer.objectID == ObjectID.None && containedObjectsBuffer.amount < 0);
		}
		ObjectInfo objectInfo;
		if (containedObjectsBuffer.objectID == ObjectID.None)
		{
			Sprite sprite = null;
			float overrideAlpha = 0f;
			if (EntityUtility.HasComponentData<InventorySlotRequirementBuffer>(inventoryHandler.entityMonoBehaviour.entity, base.world))
			{
				List<InventorySlotRequirementBuffer> inventoryRequirements = inventoryHandler.GetInventoryRequirements();
				if (base.inventorySlotIndex < inventoryRequirements.Count || (inventoryRequirements.Count == 1 && inventoryRequirements[0].requirementAppliesToAllSlots))
				{
					InventorySlotRequirementBuffer inventorySlotRequirementBuffer = (inventoryRequirements[0].requirementAppliesToAllSlots ? inventoryRequirements[0] : inventoryRequirements[base.inventorySlotIndex]);
					if (!inventorySlotRequirementBuffer.dontShowAnyHint)
					{
						if (inventorySlotRequirementBuffer.acceptsObjectIds.Length == 1)
						{
							objectID = inventorySlotRequirementBuffer.acceptsObjectIds[0];
						}
						else if (inventorySlotRequirementBuffer.acceptsObjectsWithTags != 0L)
						{
							List<ObjectCategoryTag> list = ObjectCategoryTagsCD.ConvertToList(inventorySlotRequirementBuffer.acceptsObjectsWithTags);
							if (list.Count > 0)
							{
								sprite = Manager.ui.GetCategoryTagSprite(list[0]);
								overrideAlpha = 1f;
							}
						}
					}
				}
			}
			flag12 = icon.sprite != null;
			SetEmptyIcon();
			if (objectID != ObjectID.None || sprite != null)
			{
				ShowHint(new ObjectDataCD
				{
					objectID = objectID,
					amount = 1
				}, showSilhouette: false, _itemIsRequired: true, sprite, overrideAlpha);
			}
			else
			{
				HideHint();
			}
		}
		else if (!PugDatabase.TryGetObjectInfo(containedObjectsBuffer.objectID, out objectInfo, containedObjectsBuffer.variation) || objectInfo.icon == null)
		{
			SetMissingIcon();
			HideHint();
		}
		else
		{
			Sprite sprite2 = GetIcon(objectInfo, containedObjectsBuffer.objectData);
			flag12 = icon.sprite != sprite2;
			icon.sprite = sprite2;
			Manager.ui.ApplyAnyIconGradientMap(containedObjectsBuffer, icon);
			icon.transform.localPosition = objectInfo.iconOffset;
			if (ShouldRefreshRarityBorder() && IsRarityBorderApplicableToSlot())
			{
				background.color = Manager.ui.GetSlotBorderRarityColor(objectInfo.rarity, useWhiteColoredBorderForCommonItems, white);
			}
			HideHint();
		}
		if (backgroundIcon != null)
		{
			backgroundIcon.enabled = icon.sprite == null;
		}
		float num5 = (deactivated ? 0.1f : 0.4f);
		if ((slotsUIContainer != null && slotsUIContainer.isFaded) || deactivated)
		{
			num5 *= slotsUIContainer.fadeMultiplier;
			if ((bool)icon)
			{
				icon.SetAlpha(num5);
			}
			if ((bool)background)
			{
				background.SetAlpha(num5);
			}
			if ((bool)darkBackground)
			{
				darkBackground.SetAlpha(num5);
			}
			if ((bool)overlayIcon)
			{
				overlayIcon.SetAlpha(num5);
			}
			if ((bool)underlayIcon)
			{
				underlayIcon.SetAlpha(num5);
			}
		}
		else
		{
			SetBackgroundsAlpha(1f, reset: true);
		}
		int amount = containedObjectsBuffer.amount;
		if (RenderAmountNumber(amount) || flag12 || previousVariationShown != containedObjectsBuffer.variation)
		{
			SetAnimationTrigger(-1023692900);
			if (colorReplacer != null)
			{
				colorReplacer.UpdateColorReplacerFromObjectData(containedObjectsBuffer);
			}
		}
		previousVariationShown = containedObjectsBuffer.variation;
		if (barContainer != null)
		{
			if (containedObjectsBuffer.objectID != ObjectID.None && AmountIsShownAsBar() && ShouldShowBar() && !base.isVanitySlot)
			{
				barContainer.SetActive(value: true);
				float num6 = Mathf.Clamp01((float)(PugDatabase.HasComponent<PetCD>(containedObjectsBuffer.objectID) ? PetExtensions.GetCurrentXpForCurrentLevel(containedObjectsBuffer.amount) : containedObjectsBuffer.amount) / GetProgressBarMaxValue(isReinforced: false));
				float num7 = num6 % 0.0625f;
				if (num7 > 0f)
				{
					num6 = math.min(1f, num6 + (0.0625f - num7));
				}
				barPivot.localScale = new Vector3(num6, 1f, 1f);
				bar.color = GetProgressBarColor(num6, isReinforced: false);
				int num8 = 100;
				bool num9 = PugDatabase.HasComponent<DurabilityCD>(containedObjectsBuffer.objectID);
				if (num9)
				{
					num8 = PugDatabase.GetComponent<DurabilityCD>(containedObjectsBuffer.objectID).maxDurability;
				}
				float num10 = Mathf.Clamp01((float)(containedObjectsBuffer.amount - num8) / GetProgressBarMaxValue(isReinforced: true));
				if (!num9 || num10 <= 0f)
				{
					reinforceBarContainer.SetActive(value: false);
				}
				else
				{
					float num11 = num10 % 0.0625f;
					if (num11 > 0f)
					{
						num10 = math.min(1f, num10 + (0.0625f - num11));
					}
					reinforceBarPivot.localScale = new Vector3(num10, 1f, 1f);
					reinforceBar.color = GetProgressBarColor(num10, isReinforced: true);
					reinforceBarContainer.SetActive(value: true);
				}
			}
			else
			{
				barContainer.SetActive(value: false);
			}
		}
		if (lockedIcon != null)
		{
			lockedIcon.gameObject.SetActive(flag2);
		}
		UpdateUpgradeIcon(containedObjectsBuffer);
	}

	private void RenderButtonNumber()
	{
		if (buttonNumber == null)
		{
			return;
		}
		if (!deactivated && slotsUIContainer != null && slotsUIContainer.containerType == ItemSlotsUIContainerType.PlayerInventory && visibleSlotIndex < 10 && Manager.prefs.ShowHotbarKeyboardNumbers && visibleSlotIndex >= 0 && visibleSlotIndex < ButtonNumbers.Length)
		{
			buttonNumber.gameObject.SetActive(value: true);
			if (buttonNumber.displayedTextString != ButtonNumbers[visibleSlotIndex])
			{
				buttonNumber.Render(ButtonNumbers[visibleSlotIndex]);
			}
		}
		else
		{
			buttonNumber.gameObject.SetActive(value: false);
		}
	}

	private Color GetProgressBarColor(float barValue, bool isReinforced)
	{
		ObjectDataCD objectData = GetObjectData();
		if (PugDatabase.HasComponent<FullnessCD>(objectData))
		{
			return waterBarColor;
		}
		if (PugDatabase.HasComponent<PetCD>(objectData.objectID))
		{
			return xpBarColor;
		}
		if (isReinforced)
		{
			return Color.Lerp(lowReinforceBarColor, fullReinforceBarColor, barValue);
		}
		return Color.Lerp(lowDurabilityBarColor, fullDurabilityBarColor, barValue);
	}

	public override void OnSelected()
	{
		if (slotsUIContainer != null && ((slotsUIContainer.scrollWindow != null && base.uiSlotIndex >= 10) || slotsUIContainer.isPouchInventory))
		{
			Manager.ui.playerInventoryUI.scrollWindow.MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f);
		}
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public bool TryingToPlaceHeldItemShouldShowError()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			return TryingToPlaceItemShouldShowError(player.mouseInventoryHandler.GetObjectData(0));
		}
		return false;
	}

	public bool TryingToPlaceItemShouldShowError(ObjectDataCD objectBeingPlaced)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		if (objectBeingPlaced.objectID == ObjectID.None)
		{
			return false;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectBeingPlaced.objectID);
		if (objectInfo == null)
		{
			return false;
		}
		switch (slotType)
		{
		case ItemSlotsUIType.ChestSlot:
			return player.activeInventoryHandler.ShouldShowErrorWhenTryingToPlaceInInventory(objectBeingPlaced, base.inventorySlotIndex);
		case ItemSlotsUIType.MaterialSlot:
			return player.activeCraftingHandler.inventoryHandler.ShouldShowErrorWhenTryingToPlaceInInventory(objectBeingPlaced, base.inventorySlotIndex);
		case ItemSlotsUIType.HelmSlot:
		case ItemSlotsUIType.HelmVanitySlot:
			return objectInfo.objectType != ObjectType.Helm;
		case ItemSlotsUIType.BreastSlot:
		case ItemSlotsUIType.BreastVanitySlot:
			return objectInfo.objectType != ObjectType.BreastArmor;
		case ItemSlotsUIType.PantsSlot:
		case ItemSlotsUIType.PantsVanitySlot:
			return objectInfo.objectType != ObjectType.PantsArmor;
		case ItemSlotsUIType.NecklaceSlot:
			return objectInfo.objectType != ObjectType.Necklace;
		case ItemSlotsUIType.RingSlot1:
		case ItemSlotsUIType.RingSlot2:
			return objectInfo.objectType != ObjectType.Ring;
		case ItemSlotsUIType.OffhandSlot:
			return objectInfo.objectType != ObjectType.Offhand;
		case ItemSlotsUIType.BagSlot:
			return objectInfo.objectType != ObjectType.Bag;
		case ItemSlotsUIType.PetSlot:
			return objectInfo.objectType != ObjectType.Pet;
		case ItemSlotsUIType.LanternSlot:
			return objectInfo.objectType != ObjectType.Lantern;
		case ItemSlotsUIType.TrashCanSlot:
			if (objectInfo.rarity == Rarity.Legendary)
			{
				return !Manager.saves.IsCreativeModeCharacter();
			}
			return false;
		case ItemSlotsUIType.UpgradeSlot:
			if (PugDatabase.HasComponent<ObjectCategoryTagsCD>(objectInfo.objectID))
			{
				return !ObjectCategoryTagsCD.HasTag(PugDatabase.GetComponent<ObjectCategoryTagsCD>(objectInfo.objectID).tagsBitMask, ObjectCategoryTag.CanBeUpgraded);
			}
			return true;
		case ItemSlotsUIType.Pouch1:
		case ItemSlotsUIType.Pouch2:
		case ItemSlotsUIType.Pouch3:
		case ItemSlotsUIType.Pouch4:
			return objectInfo.objectType != ObjectType.Pouch;
		case ItemSlotsUIType.PouchInventorySlot:
			return player.equipmentHandler.pouchInventorySlotsHandlers[slotsUIContainer.inventoryIndex].ShouldShowErrorWhenTryingToPlaceInInventory(objectBeingPlaced, base.inventorySlotIndex);
		default:
			return false;
		}
	}

	public void AE_ErrorSound()
	{
		AudioManager.Sfx(SfxID.menu_denied, base.transform.position, 0.7f, 1.15f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: false);
	}

	public void PlayErrorEffect()
	{
		SetAnimationTrigger(1574812785);
	}

	private bool ClickingSlotSelectsOrUsesIt()
	{
		return slotsUIContainer is ItemSlotsBarUI;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (deactivated)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (ClickingSlotSelectsOrUsesIt())
		{
			if (Manager.ui.mouse.isHoldingAnyEntity)
			{
				Manager.ui.mouse.OnInventorySlotLeftClicked(this, tryToSendToOtherInventory: false);
			}
			else
			{
				player.EquipSlot(visibleSlotIndex + player.hotbarStartIndex);
			}
		}
		else if (slotType == ItemSlotsUIType.BuySlot)
		{
			AttemptToBuyItem(playErrorOnFail: true);
		}
		else if (base.isVanitySlot && GetObjectData().objectID == ObjectID.None && player.mouseInventoryHandler.GetObjectData(0).objectID == ObjectID.None)
		{
			ToggleVisibilityOfVanitySlot();
		}
		else if (TryingToPlaceHeldItemShouldShowError())
		{
			PlayErrorEffect();
		}
		else
		{
			Manager.ui.mouse.OnInventorySlotLeftClicked(this, tryToSendToOtherInventory: false);
		}
	}

	public bool TryToSendItemToOtherInventoryOrEquip()
	{
		if ((slotType == ItemSlotsUIType.PlayerInventorySlot || slotType == ItemSlotsUIType.PouchInventorySlot) && (Manager.ui.isPlayerEquipmentShowing || Manager.ui.isVanitySlotsShowing) && !Manager.ui.isSalvageAndRepairUIShowing && !Manager.ui.isUpgradeForgeUIShowing)
		{
			if (Manager.ui.AttemptToEquipItem(inventoryHandler, base.inventorySlotIndex, Manager.ui.isVanitySlotsShowing))
			{
				AudioManager.SfxUI(SfxID.uiPickup, 0.4f, reuse: true, 1f, 0.1f);
				return true;
			}
			if (Manager.ui.AttemptToMoveToHotbar(inventoryHandler, base.inventorySlotIndex))
			{
				return true;
			}
			return false;
		}
		if (slotType == ItemSlotsUIType.BuySlot)
		{
			return false;
		}
		if (TryingToPlaceHeldItemShouldShowError())
		{
			PlayErrorEffect();
		}
		else
		{
			if (Manager.ui.isUpgradeForgeUIShowing)
			{
				ObjectDataCD objectData = GetObjectData();
				if (objectData.objectID != ObjectID.None && PugDatabase.HasComponent<ObjectCategoryTagsCD>(objectData.objectID) && !ObjectCategoryTagsCD.HasTag(PugDatabase.GetComponent<ObjectCategoryTagsCD>(objectData.objectID).tagsBitMask, ObjectCategoryTag.CanBeUpgraded))
				{
					return false;
				}
			}
			IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(GetObjectData().amount, tryingToMoveToMouse: false);
			Manager.ui.mouse.OnInventorySlotLeftClicked(this, tryToSendToOtherInventory: true);
		}
		return false;
	}

	private void AttemptToBuyItem(bool playErrorOnFail)
	{
		PlayerController player = Manager.main.player;
		if (GetObjectData().objectID != ObjectID.None)
		{
			if (CanAffordItem())
			{
				player.mouseInventoryHandler.Buy(player, GetInventoryHandler(), base.inventorySlotIndex);
			}
			else if (playErrorOnFail)
			{
				PlayErrorEffect();
			}
		}
	}

	private void ToggleVisibilityOfVanitySlot()
	{
		ObjectDataCD objectData = GetObjectData();
		InventoryHandler inventoryHandler = this.inventoryHandler;
		if (base.isVanitySlot && objectData.objectID == ObjectID.None && inventoryHandler != null)
		{
			if (objectData.amount < 0)
			{
				inventoryHandler.SetAmount(Manager.main.player, 0, ObjectID.None, 0);
			}
			else
			{
				inventoryHandler.SetAmount(Manager.main.player, 0, ObjectID.None, -1);
			}
		}
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
		OnRightClicked(mod1, mod2, 1);
	}

	public void OnRightClicked(bool mod1, bool mod2, int amountScale)
	{
		if (deactivated)
		{
			return;
		}
		if (ClickingSlotSelectsOrUsesIt())
		{
			PlayerController player = Manager.main.player;
			player.EquipSlot(visibleSlotIndex + player.hotbarStartIndex);
			EquipmentSlot equippedSlot = player.GetEquippedSlot();
			if (equippedSlot != null && (equippedSlot.GetSlotType() == EquipmentSlotType.EatableSlot || equippedSlot.GetSlotType() == EquipmentSlotType.CastingSlot || equippedSlot.GetSlotType() == EquipmentSlotType.EquipGearSlot) && player.CurrentStateAllowInteractions(isTryingToUseSecondInteract: true) && !player.isInteractionBlocked)
			{
				ClientInputHistoryCD componentData = EntityUtility.GetComponentData<ClientInputHistoryCD>(player.entity, player.world);
				componentData.secondInteractUITriggered = true;
				EntityUtility.SetComponentData(player.entity, player.world, componentData);
			}
		}
		else if (slotType == ItemSlotsUIType.BuySlot)
		{
			AttemptToBuyItem(playErrorOnFail: true);
		}
		else if (TryingToPlaceHeldItemShouldShowError())
		{
			PlayErrorEffect();
		}
		else
		{
			int amount = amountScale;
			if (mod2)
			{
				amount = ((inventoryHandler.GetObjectData(base.inventorySlotIndex).objectID != ObjectID.None) ? ((inventoryHandler.GetObjectData(base.inventorySlotIndex).amount + 1) / 2) : ((Manager.main.player.mouseInventoryHandler.GetObjectData(0).amount + 1) / 2));
			}
			else if (mod1)
			{
				amount = 10 * amountScale;
			}
			Manager.ui.mouse.OnInventorySlotRightClicked(this, allowPlacingStuff: true, amount);
		}
	}

	protected void IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(int amount, bool tryingToMoveToMouse)
	{
		PlayerController player = Manager.main.player;
		if (slotType != ItemSlotsUIType.OutputSlot || !Manager.ui.cookingCraftingUI.isShowing || amount <= 0 || player == null)
		{
			return;
		}
		ObjectDataCD objectData = GetObjectData();
		if (PugDatabase.GetObjectInfo(objectData.objectID) == null || !PugDatabase.HasComponent<CookedFoodCD>(objectData))
		{
			return;
		}
		if (tryingToMoveToMouse)
		{
			InventoryHandler mouseInventory = Manager.ui.mouse.mouseInventory;
			if (mouseInventory == null)
			{
				return;
			}
			ObjectDataCD objectData2 = mouseInventory.GetObjectData(0);
			if (objectData2.objectID != ObjectID.None && (objectData.objectID != objectData2.objectID || objectData.variation != objectData2.variation))
			{
				return;
			}
			amount = math.min(amount, 9999 - objectData2.amount);
		}
		player.playerCommandSystem.AddSkillValue(player.entity, SkillID.Cooking, amount);
		float num = (float)EntityUtility.GetConditionEffectValue(ConditionEffect.ChanceToGainExtraCookedFood, player.entity, player.world) / 1000f;
		float num2 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceForExtraCookedFoodToBeRare, player.entity, player.world) / 100f;
		ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(objectData.variation);
		ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(objectData.variation);
		bool flag = false;
		if (PugDatabase.HasComponent<FlowerCD>(primaryIngredientFromVariation))
		{
			flag = PugDatabase.GetObjectInfo(primaryIngredientFromVariation).rarity == Rarity.Rare;
		}
		if (!flag && PugDatabase.HasComponent<FlowerCD>(secondaryIngredientFromVariation))
		{
			flag = PugDatabase.GetObjectInfo(secondaryIngredientFromVariation).rarity == Rarity.Rare;
		}
		if (!flag && (PugDatabase.GetObjectInfo(primaryIngredientFromVariation).rarity == Rarity.Legendary || PugDatabase.GetObjectInfo(secondaryIngredientFromVariation).rarity == Rarity.Legendary))
		{
			flag = true;
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < amount; i++)
		{
			if (!(UnityEngine.Random.value < num))
			{
				continue;
			}
			if (UnityEngine.Random.value < num2)
			{
				if (flag)
				{
					num5++;
				}
				else
				{
					num4++;
				}
			}
			else if (flag)
			{
				num4++;
			}
			else
			{
				num3++;
			}
		}
		if (!PugDatabase.HasComponent<CookedFoodCD>(objectData))
		{
			return;
		}
		if (num3 > 0)
		{
			player.playerCommandSystem.CreateAndDropEntity(objectData.objectID, player.WorldPosition, num3, player.entity, objectData.variation);
			string[] formatFields = new string[2]
			{
				num3.ToString(),
				PlayerController.GetObjectName(new ContainedObjectsBuffer
				{
					objectData = objectData
				}, localize: true).text
			};
			Manager.ui.chatWindow.AddInfoText(formatFields, Rarity.Uncommon, ChatWindow.MessageTextType.AdditionalItemGained);
		}
		if (num4 > 0)
		{
			ObjectID rareVersion = PugDatabase.GetComponent<CookedFoodCD>(objectData).rareVersion;
			if (rareVersion != ObjectID.None && PugDatabase.HasComponent<CookedFoodCD>(rareVersion))
			{
				objectData.objectID = rareVersion;
				player.playerCommandSystem.CreateAndDropEntity(rareVersion, player.WorldPosition, num4, player.entity, objectData.variation);
				string[] formatFields2 = new string[2]
				{
					num4.ToString(),
					PlayerController.GetObjectName(new ContainedObjectsBuffer
					{
						objectData = objectData
					}, localize: true).text
				};
				Manager.ui.chatWindow.AddInfoText(formatFields2, Rarity.Rare, ChatWindow.MessageTextType.AdditionalItemGained);
			}
		}
		if (num5 > 0)
		{
			ObjectID epicVersion = PugDatabase.GetComponent<CookedFoodCD>(objectData).epicVersion;
			if (epicVersion != ObjectID.None && PugDatabase.HasComponent<CookedFoodCD>(epicVersion))
			{
				objectData.objectID = epicVersion;
				player.playerCommandSystem.CreateAndDropEntity(epicVersion, player.WorldPosition, num5, player.entity, objectData.variation);
				string[] formatFields3 = new string[2]
				{
					num5.ToString(),
					PlayerController.GetObjectName(new ContainedObjectsBuffer
					{
						objectData = objectData
					}, localize: true).text
				};
				Manager.ui.chatWindow.AddInfoText(formatFields3, Rarity.Epic, ChatWindow.MessageTextType.AdditionalItemGained);
			}
		}
	}

	public InventoryHandler GetInventoryHandler()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return null;
		}
		switch (slotType)
		{
		case ItemSlotsUIType.ChestSlot:
			return player.activeInventoryHandler;
		case ItemSlotsUIType.PlayerInventorySlot:
			return player.playerInventoryHandler;
		case ItemSlotsUIType.MaterialSlot:
			return player.activeCraftingHandler?.inventoryHandler;
		case ItemSlotsUIType.OutputSlot:
			return player.activeCraftingHandler?.outputInventoryHandler;
		case ItemSlotsUIType.HelmSlot:
			return player.equipmentHandler.helmInventoryHandler;
		case ItemSlotsUIType.BreastSlot:
			return player.equipmentHandler.breastInventoryHandler;
		case ItemSlotsUIType.PantsSlot:
			return player.equipmentHandler.pantsInventoryHandler;
		case ItemSlotsUIType.NecklaceSlot:
			return player.equipmentHandler.necklaceInventoryHandler;
		case ItemSlotsUIType.RingSlot1:
			return player.equipmentHandler.ring1InventoryHandler;
		case ItemSlotsUIType.RingSlot2:
			return player.equipmentHandler.ring2InventoryHandler;
		case ItemSlotsUIType.OffhandSlot:
			return player.equipmentHandler.offHandInventoryHandler;
		case ItemSlotsUIType.BagSlot:
			return player.equipmentHandler.bagInventoryHandler;
		case ItemSlotsUIType.PetSlot:
			return player.equipmentHandler.petInventoryHandler;
		case ItemSlotsUIType.LanternSlot:
			return player.equipmentHandler.lanternInventoryHandler;
		case ItemSlotsUIType.PlayerSellSlot:
			return player.sellSlotsHandler.sellSlotsInventoryHandler;
		case ItemSlotsUIType.BuySlot:
			return player.activeBuyInventoryHandler;
		case ItemSlotsUIType.TrashCanSlot:
			return player.trashCanHandler.inventoryHandler;
		case ItemSlotsUIType.HelmVanitySlot:
			return player.vanitySlotsHandler.helmVanitySlotInventoryHandler;
		case ItemSlotsUIType.BreastVanitySlot:
			return player.vanitySlotsHandler.breastVanitySlotInventoryHandler;
		case ItemSlotsUIType.PantsVanitySlot:
			return player.vanitySlotsHandler.pantsVanitySlotInventoryHandler;
		case ItemSlotsUIType.UpgradeSlot:
			return player.upgradeSlotHandler.inventoryHandler;
		case ItemSlotsUIType.Pouch1:
			return player.equipmentHandler.pouchInventoryHandlers[0];
		case ItemSlotsUIType.Pouch2:
			return player.equipmentHandler.pouchInventoryHandlers[1];
		case ItemSlotsUIType.Pouch3:
			return player.equipmentHandler.pouchInventoryHandlers[2];
		case ItemSlotsUIType.Pouch4:
			return player.equipmentHandler.pouchInventoryHandlers[3];
		case ItemSlotsUIType.PouchInventorySlot:
			return player.equipmentHandler.pouchInventorySlotsHandlers[slotsUIContainer.inventoryIndex];
		default:
			Debug.LogError("Could not find any matching slot for containerType " + slotType);
			return null;
		}
	}

	private ObjectDataCD GetCookedFoodObjectData()
	{
		InventoryHandler obj = Manager.main.player.activeCraftingHandler.inventoryHandler;
		ObjectID objectID = obj.GetObjectData(0).objectID;
		ObjectID objectID2 = obj.GetObjectData(1).objectID;
		if (objectID != ObjectID.None && objectID2 != ObjectID.None)
		{
			return new ObjectDataCD
			{
				objectID = currentObjectIDHint,
				variation = CookedFoodCD.GetFoodVariation(objectID, objectID2)
			};
		}
		return default(ObjectDataCD);
	}

	private bool CurrentObjectHintIsCookedFood()
	{
		PlayerController player = Manager.main.player;
		if (PugDatabase.HasComponent<CookedFoodCD>(currentObjectIDHint) && (bool)player && player.activeCraftingHandler != null)
		{
			return player.activeCraftingHandler.craftingType == CraftingType.Cooking;
		}
		return false;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (deactivated)
		{
			return null;
		}
		if (!showHoverWindow)
		{
			return null;
		}
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (inventoryHandler != null && slotObject.objectID == ObjectID.None)
		{
			TextAndFormatFields anyRequirementInfoText = inventoryHandler.GetAnyRequirementInfoText(base.inventorySlotIndex);
			if (anyRequirementInfoText != null)
			{
				return anyRequirementInfoText;
			}
		}
		if (currentObjectIDHint != ObjectID.None)
		{
			TextAndFormatFields textAndFormatFields = null;
			ContainedObjectsBuffer containedObject = (CurrentObjectHintIsCookedFood() ? new ContainedObjectsBuffer
			{
				objectData = GetCookedFoodObjectData()
			} : GetContainedObjectData());
			if (shouldShowSilhouetteOfHint)
			{
				return null;
			}
			if (CurrentObjectHintIsCookedFood())
			{
				textAndFormatFields = PlayerController.GetObjectName(containedObject, localize: false);
			}
			else
			{
				textAndFormatFields = PlayerController.GetObjectName(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = currentObjectIDHint
					}
				}, localize: false);
				if (itemIsRequired)
				{
					textAndFormatFields.formatFields = new string[1] { PugText.ProcessText(textAndFormatFields.text, textAndFormatFields.formatFields, shouldLocalize: true, shouldLocalizeFormatFields: false) };
					textAndFormatFields.text = "requiresItem";
				}
			}
			if (textAndFormatFields != null)
			{
				textAndFormatFields.color = Manager.text.GetRarityColor(PugDatabase.GetObjectInfo(currentObjectIDHint).rarity);
			}
			return textAndFormatFields;
		}
		return base.GetHoverTitle();
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (deactivated)
		{
			return null;
		}
		if (!showHoverWindow)
		{
			return null;
		}
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (inventoryHandler != null && slotObject.objectID == ObjectID.None)
		{
			TextAndFormatFields anyRequirementInfoText = inventoryHandler.GetAnyRequirementInfoText(base.inventorySlotIndex, getDesc: true);
			if (anyRequirementInfoText != null)
			{
				return new List<TextAndFormatFields> { anyRequirementInfoText };
			}
		}
		if (currentObjectIDHint != ObjectID.None)
		{
			ObjectDataCD objectDataCD = (CurrentObjectHintIsCookedFood() ? GetCookedFoodObjectData() : GetObjectData());
			ObjectID anyObjectIDReplaceForNameAndDesc = PlayerController.GetAnyObjectIDReplaceForNameAndDesc(objectDataCD.objectID);
			if (!API.Authoring.ObjectProperties.TryGetPropertyString(anyObjectIDReplaceForNameAndDesc, "name", out var value))
			{
				value = anyObjectIDReplaceForNameAndDesc.ToString();
			}
			string nameTermOverride = Manager.ui.itemOverridesTable.GetNameTermOverride(objectDataCD);
			if (nameTermOverride != null)
			{
				value = nameTermOverride;
			}
			if (shouldShowSilhouetteOfHint)
			{
				return null;
			}
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "Items/" + value + "Desc"
				}
			};
		}
		return base.GetHoverDescription();
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (deactivated)
		{
			return null;
		}
		if (base.isVanitySlot)
		{
			return null;
		}
		if (!showHoverWindow)
		{
			return null;
		}
		if (currentObjectIDHint != ObjectID.None)
		{
			ContainedObjectsBuffer containedObject = (CurrentObjectHintIsCookedFood() ? new ContainedObjectsBuffer
			{
				objectData = GetCookedFoodObjectData()
			} : GetContainedObjectData());
			if (shouldShowSilhouetteOfHint)
			{
				return null;
			}
			return GetHoverStats(containedObject, previewReinforced, previewUpgraded: false);
		}
		return base.GetHoverStats(previewReinforced);
	}

	public override bool CanBeRepaired(bool isReinforcing)
	{
		if (Manager.main.player == null)
		{
			return false;
		}
		CraftingHandler activeCraftingHandler = Manager.main.player.activeCraftingHandler;
		InventoryHandler inventoryHandler = this.inventoryHandler;
		if (activeCraftingHandler != null && inventoryHandler != null)
		{
			return activeCraftingHandler.CanBeRepaired(visibleSlotIndex, inventoryHandler, isReinforcing);
		}
		return false;
	}

	public void Activate()
	{
		deactivated = false;
		SetBackgroundsAlpha(1f, reset: true);
	}

	public void Deactivate()
	{
		deactivated = true;
		SetBackgroundsAlpha(0.1f, reset: false);
	}

	private void SetBackgroundsAlpha(float alpha, bool reset)
	{
		if (background != null)
		{
			background.SetAlpha(reset ? backgroundDefaultAlpha : alpha);
		}
		if (darkBackground != null)
		{
			darkBackground.SetAlpha(reset ? darkBackgroundDefaultAlpha : alpha);
		}
	}
}
