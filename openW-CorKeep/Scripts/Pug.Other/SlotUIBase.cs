using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using CommandMinion;
using I2.Loc;
using Pug.Automation;
using Pug.UnityExtensions;
using PugMod;
using QFSW.QC;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

public class SlotUIBase : UIelement
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct DisplayDPSKey
	{
	}

	public int visibleSlotIndex;

	public int uiSlotXPosition;

	public int uiSlotYPosition;

	protected int currentlyRenderedAmountNumber = -1;

	public PugText amountNumber;

	public PugText amountNumberShadow;

	public SpriteRenderer icon;

	public Sprite missingIconSprite;

	public SpriteRenderer underlayIcon;

	public SpriteRenderer overlayIcon;

	public SpriteRenderer background;

	public SpriteRenderer tiledDecorationBackground;

	public SpriteRenderer darkBackground;

	public SpriteRenderer hoverBorder;

	public SpriteRenderer activeBorder;

	public SpriteRenderer highlightBorder;

	public bool dontWrapAroundNavigation;

	public SpriteRenderer upgradeIcon;

	public List<Sprite> upgradeSprites;

	public GameObject highlight;

	private const float ANIMATOR_DISABLE_DELAY = 1f;

	[SerializeField]
	private Animator animator;

	public bool autoDisableAnimator;

	private TimerSimple _disableAnimatorTimer;

	public ItemSlotsUIType slotType;

	public LocalizedString hoverTitleWhenEmpty = "";

	protected ItemSlotsUIContainer slotsUIContainer;

	private static readonly SharedStatic<bool> debugDisplayDPS = SharedStatic<bool>.GetOrCreateUnsafe(0u, -5597746709567368609L, 0L);

	protected const string itemsPrefix = "Items/";

	protected const string descPostfix = "Desc";

	protected const string vanityToggleVisibility = "vanityToggleVisibility";

	private readonly string weaponMeleeDamageString = "meleeWeapon";

	private readonly string weaponRangeDamageString = "rangeWeapon";

	private readonly string petMeleeDamageString = "weaponMeleeDamage";

	private readonly string petRangeDamageString = "weaponRangeDamage";

	private readonly string magicWeaponDamageString = "magicWeaponDamage";

	private readonly string physicalWeaponDamageString = "physicalWeaponDamage";

	private readonly string damageString = "damage";

	private readonly string weaponSpeedString = "WeaponSpeed";

	private readonly string explosiveDamageString = "explosiveDamage";

	private readonly string miningDamageString = "ConditionEffect/Mining";

	private readonly string additionalSlotsStatString = "additionalSlotsStat";

	private readonly string additionalSlotsPouchStatString = "additionalSlotsPouchStat";

	private readonly string piercesString = "piercingProjectiles";

	private readonly string bouncesString = "bouncingProjectiles";

	private readonly string offHandUseString = "offHandUse";

	private readonly string offHandMechanicPrefix = "OffHandMechanics/";

	private readonly string cooldownSecString = "CooldownSec";

	private readonly string cooldownMinString = "CooldownMin";

	private readonly string cooldownMinSecString = "CooldownMinSec";

	private readonly string manaCostString = "manaCost";

	private const string weaponSecondaryTerm = "weaponSecondary";

	private const string weaponSecondaryCategory = "WeaponSecondary/";

	private const string commandMinionString = "commandMinion";

	private static readonly string conditionString = "Conditions/";

	protected int uiSlotIndex => uiSlotXPosition + uiSlotYPosition * slotsUIContainer.MAX_COLUMNS;

	public int inventorySlotIndex => visibleSlotIndex + ((slotsUIContainer != null) ? slotsUIContainer.startSlotIndex : 0);

	public override bool isShowing => base.gameObject.activeInHierarchy;

	public bool isVanitySlot
	{
		get
		{
			if (slotType != ItemSlotsUIType.HelmVanitySlot && slotType != ItemSlotsUIType.BreastVanitySlot)
			{
				return slotType == ItemSlotsUIType.PantsVanitySlot;
			}
			return true;
		}
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("DisplayDPSOnItems", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void DisplayDPSOnItems(bool value = true)
	{
		debugDisplayDPS.Data = value;
	}

	protected virtual void Awake()
	{
		if (activeBorder != null)
		{
			activeBorder.gameObject.SetActive(value: false);
		}
		if (hoverBorder != null)
		{
			hoverBorder.gameObject.SetActive(value: false);
		}
		if (highlightBorder != null)
		{
			highlightBorder.gameObject.SetActive(value: false);
		}
		animator.enabled = !autoDisableAnimator;
	}

	public virtual void Init(ItemSlotsUIContainer slotsUIContainer)
	{
		this.slotsUIContainer = slotsUIContainer;
		if (slotsUIContainer.containerType == ItemSlotsUIContainerType.ChestInventory)
		{
			slotType = ItemSlotsUIType.ChestSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.CraftingInventory)
		{
			slotType = ItemSlotsUIType.MaterialSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.PlayerInventory)
		{
			slotType = ItemSlotsUIType.PlayerInventorySlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.RecipeList)
		{
			slotType = ItemSlotsUIType.RecipeSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.PlayerSellSlots)
		{
			slotType = ItemSlotsUIType.PlayerSellSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.BuyInventory)
		{
			slotType = ItemSlotsUIType.BuySlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.TrashCan)
		{
			slotType = ItemSlotsUIType.TrashCanSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.CattleFood)
		{
			slotType = ItemSlotsUIType.CattleFoodSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.UpgradeForge)
		{
			slotType = ItemSlotsUIType.UpgradeSlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.PouchInventory)
		{
			slotType = ItemSlotsUIType.PouchInventorySlot;
		}
		else if (slotsUIContainer.containerType == ItemSlotsUIContainerType.FilterInventory)
		{
			slotType = ItemSlotsUIType.FilterSlot;
		}
	}

	protected override void LateUpdate()
	{
		UpdateSlot();
		if (_disableAnimatorTimer.isRunning && _disableAnimatorTimer.isTimerElapsed && animator.GetCurrentAnimatorStateInfo(0).shortNameHash == -601574123)
		{
			_disableAnimatorTimer.Stop();
			animator.enabled = false;
		}
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public virtual void UpdateSlot()
	{
	}

	protected void UpdateUpgradeIcon(ContainedObjectsBuffer containedObject)
	{
		if (!(upgradeIcon != null))
		{
			return;
		}
		if (containedObject.objectID == ObjectID.None)
		{
			upgradeIcon.gameObject.SetActive(value: false);
			return;
		}
		if (!PugDatabase.HasComponent<ObjectCategoryTagsCD>(containedObject.objectID))
		{
			upgradeIcon.gameObject.SetActive(value: false);
			return;
		}
		if (!ObjectCategoryTagsCD.HasTag(PugDatabase.GetComponent<ObjectCategoryTagsCD>(containedObject.objectID).tagsBitMask, ObjectCategoryTag.CanBeUpgraded))
		{
			upgradeIcon.gameObject.SetActive(value: false);
			return;
		}
		bool flag = containedObject.variation > 0;
		upgradeIcon.gameObject.SetActive(flag);
		if (flag)
		{
			upgradeIcon.sprite = ((containedObject.variation == LevelScaling.GetMaxLevel()) ? upgradeSprites[1] : upgradeSprites[0]);
		}
	}

	protected virtual bool RenderAmountNumber(int amount)
	{
		if (amountNumber == null)
		{
			return false;
		}
		ContainedObjectsBuffer slotObject = GetSlotObject();
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(slotObject.objectID, slotObject.variation);
		bool flag = amount > 1 && !AmountIsShownAsBar() && objectInfo != null && objectInfo.isStackable;
		if (!flag && amountNumber.displayedTextString != "")
		{
			currentlyRenderedAmountNumber = -1;
			amountNumber.Render("");
			if ((bool)amountNumberShadow)
			{
				amountNumberShadow.Render("");
			}
			return true;
		}
		if (flag && currentlyRenderedAmountNumber != amount)
		{
			currentlyRenderedAmountNumber = amount;
			string text = amount.ToString();
			amountNumber.Render(text);
			if ((bool)amountNumberShadow)
			{
				amountNumberShadow.Render(text);
			}
			return true;
		}
		return false;
	}

	protected bool AmountIsShownAsBar()
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		return PugDatabase.AmountIsDurabilityOrFullnessOrXp(slotObject.objectID, slotObject.variation);
	}

	protected bool ShouldShowBar()
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (PugDatabase.HasComponent<PetCD>(slotObject.objectID))
		{
			return !PetExtensions.IsAtMaxLevel(slotObject.amount);
		}
		return true;
	}

	protected float GetProgressBarMaxValue(bool isReinforced)
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		int num = 1;
		if (PugDatabase.HasComponent<DurabilityCD>(slotObject.objectID))
		{
			int maxDurability = PugDatabase.GetComponent<DurabilityCD>(slotObject.objectID).maxDurability;
			num = maxDurability;
			if (isReinforced)
			{
				num = (int)math.round((float)num * 2f) - maxDurability;
			}
		}
		else if (PugDatabase.HasComponent<FullnessCD>(slotObject.objectID))
		{
			num = PugDatabase.GetComponent<FullnessCD>(slotObject.objectID).maxFullness;
		}
		else if (PugDatabase.HasComponent<PetCD>(slotObject.objectID))
		{
			num = PetExtensions.GetTotalXpNeededToLevelUp(slotObject.amount);
		}
		num = Math.Max(num, 1);
		return num;
	}

	public void OnSelectSlot()
	{
		if (hoverBorder != null)
		{
			hoverBorder.gameObject.SetActive(value: true);
		}
	}

	public void OnDeselectSlot()
	{
		if (hoverBorder != null)
		{
			hoverBorder.gameObject.SetActive(value: false);
		}
	}

	public virtual void OnSetSlotActive()
	{
		if (activeBorder != null)
		{
			activeBorder.gameObject.SetActive(value: true);
		}
	}

	public virtual void OnSetSlotInactivate()
	{
		if (activeBorder != null)
		{
			activeBorder.gameObject.SetActive(value: false);
		}
	}

	protected void SetMissingIcon()
	{
		icon.sprite = missingIconSprite;
		icon.transform.localPosition = Vector3.zero;
		icon.color = Color.white;
	}

	protected void SetEmptyIcon()
	{
		icon.sprite = null;
		icon.transform.localPosition = Vector3.zero;
	}

	protected Rarity GetObjectRarity(ObjectDataCD objectData)
	{
		return PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation)?.rarity ?? Rarity.Common;
	}

	protected virtual ContainedObjectsBuffer GetSlotObject()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return default(ContainedObjectsBuffer);
		}
		switch (slotType)
		{
		case ItemSlotsUIType.ChestSlot:
			return player.activeInventoryHandler?.GetContainedObjectData(inventorySlotIndex) ?? default(ContainedObjectsBuffer);
		case ItemSlotsUIType.MaterialSlot:
			return player.activeCraftingHandler?.inventoryHandler.GetContainedObjectData(inventorySlotIndex) ?? default(ContainedObjectsBuffer);
		case ItemSlotsUIType.PlayerInventorySlot:
			return player.playerInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.RecipeSlot:
		{
			CraftingHandler.RecipeInfo recipeInfo = player.activeCraftingHandler?.GetRecipeInfo(inventorySlotIndex) ?? default(CraftingHandler.RecipeInfo);
			return new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = (recipeInfo.isValid ? recipeInfo.objectID : ObjectID.None)
				}
			};
		}
		case ItemSlotsUIType.OutputSlot:
			return player.activeCraftingHandler?.outputInventoryHandler.GetContainedObjectData(inventorySlotIndex) ?? default(ContainedObjectsBuffer);
		case ItemSlotsUIType.HelmSlot:
			return player.equipmentHandler.helmInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.BreastSlot:
			return player.equipmentHandler.breastInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.PantsSlot:
			return player.equipmentHandler.pantsInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.NecklaceSlot:
			return player.equipmentHandler.necklaceInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.RingSlot1:
			return player.equipmentHandler.ring1InventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.RingSlot2:
			return player.equipmentHandler.ring2InventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.OffhandSlot:
			return player.equipmentHandler.offHandInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.BagSlot:
			return player.equipmentHandler.bagInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.PetSlot:
			return player.equipmentHandler.petInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.LanternSlot:
			return player.equipmentHandler.lanternInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.PlayerSellSlot:
			return player.sellSlotsHandler.sellSlotsInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.BuySlot:
			return player.activeBuyInventoryHandler?.GetContainedObjectData(inventorySlotIndex) ?? default(ContainedObjectsBuffer);
		case ItemSlotsUIType.TrashCanSlot:
			return player.trashCanHandler.inventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.HelmVanitySlot:
			return player.vanitySlotsHandler.helmVanitySlotInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.BreastVanitySlot:
			return player.vanitySlotsHandler.breastVanitySlotInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.PantsVanitySlot:
			return player.vanitySlotsHandler.pantsVanitySlotInventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.CattleFoodSlot:
			return player.activeCattle?.GetFood(inventorySlotIndex) ?? default(ContainedObjectsBuffer);
		case ItemSlotsUIType.UpgradeSlot:
			return player.upgradeSlotHandler.inventoryHandler.GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.Pouch1:
			return player.equipmentHandler.pouchInventoryHandlers[0].GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.Pouch2:
			return player.equipmentHandler.pouchInventoryHandlers[1].GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.Pouch3:
			return player.equipmentHandler.pouchInventoryHandlers[2].GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.Pouch4:
			return player.equipmentHandler.pouchInventoryHandlers[3].GetContainedObjectData(inventorySlotIndex);
		case ItemSlotsUIType.PouchInventorySlot:
			return player.equipmentHandler.pouchInventorySlotsHandlers[slotsUIContainer.inventoryIndex].GetContainedObjectData(inventorySlotIndex);
		default:
			return default(ContainedObjectsBuffer);
		}
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		ObjectID objectID = slotObject.objectID;
		TextAndFormatFields textAndFormatFields = null;
		if (objectID != ObjectID.None)
		{
			textAndFormatFields = PlayerController.GetObjectName(slotObject, localize: false);
			Rarity objectRarity = GetObjectRarity(GetSlotObject().objectData);
			textAndFormatFields.color = Manager.text.GetRarityColor(objectRarity);
		}
		else if (hoverTitleWhenEmpty.mTerm != "")
		{
			textAndFormatFields = new TextAndFormatFields
			{
				text = hoverTitleWhenEmpty.mTerm
			};
		}
		return textAndFormatFields;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		if (GetSlotObject().objectID == ObjectID.None)
		{
			return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
		}
		return base.GetHoverWindowAlignment();
	}

	public override HoverTitleIconType GetHoverTitleIconType()
	{
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(GetSlotObject().objectID);
		if (objectInfo != null)
		{
			if (objectInfo.objectType == ObjectType.Eatable)
			{
				return HoverTitleIconType.Edible;
			}
			if (objectInfo.objectType == ObjectType.Valuable)
			{
				return HoverTitleIconType.Valuable;
			}
			if (objectInfo.objectType == ObjectType.KeyItem)
			{
				return HoverTitleIconType.Key;
			}
		}
		return base.GetHoverTitleIconType();
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		ObjectID objectID = slotObject.objectID;
		if (objectID != ObjectID.None)
		{
			objectID = PlayerController.GetAnyObjectIDReplaceForNameAndDesc(objectID);
			if (!API.Authoring.ObjectProperties.TryGetPropertyString(objectID, "name", out var value))
			{
				value = objectID.ToString();
			}
			string nameTermOverride = Manager.ui.itemOverridesTable.GetNameTermOverride(slotObject.objectData);
			if (nameTermOverride != null)
			{
				value = nameTermOverride;
			}
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "Items/" + value + "Desc"
				}
			};
		}
		if (isVanitySlot)
		{
			string[] formatFields = null;
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "vanityToggleVisibility",
					formatFields = formatFields
				}
			};
		}
		return null;
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return GetHoverStats(GetSlotObject(), previewReinforced, previewUpgraded: false);
	}

	public override bool CoinValueIsBuyPrice()
	{
		return slotType == ItemSlotsUIType.BuySlot;
	}

	public List<TextAndFormatFields> GetHoverStats(ContainedObjectsBuffer containedObject, bool previewReinforced, bool previewUpgraded)
	{
		if (PugDatabase.HasComponent<EnemyCD>(containedObject.objectData))
		{
			return null;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObject.objectID, containedObject.variation);
		if (objectInfo == null || objectInfo.prefabInfos.Count == 0)
		{
			return null;
		}
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		if (PugDatabase.HasComponent<ConsumesManaCD>(containedObject.objectData))
		{
			int num = 0;
			Entity levelEntity = EntityUtility.GetLevelEntity(containedObject.objectData);
			num = ((!(levelEntity != Entity.Null)) ? PugDatabase.GetComponent<ConsumesManaCD>(containedObject.objectData).manaCost : EntityUtility.GetComponentData<ConsumesManaCD>(levelEntity, base.world).manaCost);
			int num2 = 0;
			if (previewUpgraded)
			{
				int num3 = ((containedObject.variation > 0) ? containedObject.variation : PugDatabase.GetComponent<LevelCD>(containedObject.objectData).level);
				levelEntity = EntityUtility.GetLevelEntity(new ObjectDataCD
				{
					objectID = containedObject.objectID,
					variation = num3 + 1
				});
				if (levelEntity != Entity.Null)
				{
					int manaCost = EntityUtility.GetComponentData<ConsumesManaCD>(levelEntity, base.world).manaCost;
					num2 = manaCost - num;
					num = manaCost;
				}
			}
			if (num != 0)
			{
				list.Add(new TextAndFormatFields
				{
					text = manaCostString,
					formatFields = new string[1] { num.ToString() },
					color = Manager.ui.manaTextColor,
					additionalText = ((num2 != 0) ? ("(+" + num2 + ")") : ""),
					additionalTextColor = Manager.ui.previewReinforcedColor
				});
			}
		}
		bool flag = PugDatabase.HasComponent<DurabilityCD>(containedObject.objectData) && PugDatabase.GetComponent<DurabilityCD>(containedObject.objectData).IsReinforced(containedObject.amount);
		bool flag2 = (!flag && previewReinforced) || previewUpgraded;
		if (PugDatabase.HasComponent<HasWeaponDamageCD>(containedObject.objectData))
		{
			HasWeaponDamageCD component = PugDatabase.GetComponent<HasWeaponDamageCD>(containedObject.objectData);
			WeaponDamageCD componentData = EntityUtility.GetComponentData<WeaponDamageCD>(EntityUtility.GetLevelEntity(containedObject.objectData), base.world);
			int num4 = componentData.damage;
			int num5 = 0;
			int num6 = 0;
			if (previewReinforced || flag)
			{
				num6 = (int)math.round((float)componentData.damage * 0.14999998f);
				num4 += num6;
			}
			if (previewReinforced)
			{
				num5 = num6;
			}
			if (previewUpgraded)
			{
				int num7 = ((containedObject.variation > 0) ? containedObject.variation : PugDatabase.GetComponent<LevelCD>(containedObject.objectData).level);
				int num8 = EntityUtility.GetComponentData<WeaponDamageCD>(EntityUtility.GetLevelEntity(new ObjectDataCD
				{
					objectID = containedObject.objectID,
					variation = num7 + 1
				}), base.world).damage;
				if (flag)
				{
					num8 += (int)math.round((float)num8 * 0.14999998f);
				}
				num5 = num8 - num4;
				num4 = num8;
			}
			int num9 = (int)((float)num4 * 0.1f);
			string text = PugText.ProcessText(component.isMagic ? magicWeaponDamageString : physicalWeaponDamageString, new string[2]
			{
				(num4 - num9).ToString(),
				(num4 + num9).ToString()
			}, shouldLocalize: true, shouldLocalizeFormatFields: false);
			string text2 = weaponMeleeDamageString;
			string text3 = weaponRangeDamageString;
			if (num4 == 0)
			{
				text2 = "";
				text3 = "";
			}
			list.Add(new TextAndFormatFields
			{
				text = (component.isRange ? text3 : text2),
				formatFields = new string[1] { text },
				color = (flag ? Manager.ui.reinforcedColor : Color.white),
				additionalText = (flag2 ? ("(+" + num5 + ")") : ""),
				additionalTextColor = Manager.ui.previewReinforcedColor
			});
			GetExplosiveHoverStats(list, in containedObject, flag2, flag, previewReinforced, previewUpgraded, out var _);
			bool flag3 = PugDatabase.HasComponent<RangeWeaponCD>(containedObject.objectData);
			float num10 = (flag3 ? 0.6f : 0.4f);
			if (PugDatabase.HasComponent<CooldownCD>(containedObject.objectData))
			{
				num10 = PugDatabase.GetComponent<CooldownCD>(containedObject.objectData).cooldown;
			}
			string text4 = (1f / num10).ToString("F1", CultureInfo.InvariantCulture);
			list.Add(new TextAndFormatFields
			{
				text = weaponSpeedString,
				formatFields = new string[1] { text4 }
			});
			if (flag3)
			{
				ObjectID projectileID = PugDatabase.GetComponent<RangeWeaponCD>(containedObject.objectData).projectileID;
				PiercingProjectileCD obj = (PugDatabase.HasComponent<PiercingProjectileCD>(projectileID) ? PugDatabase.GetComponent<PiercingProjectileCD>(projectileID) : default(PiercingProjectileCD));
				BouncingProjectileCD bouncingProjectileCD = (PugDatabase.HasComponent<BouncingProjectileCD>(projectileID) ? PugDatabase.GetComponent<BouncingProjectileCD>(projectileID) : default(BouncingProjectileCD));
				bool flag4 = PugDatabase.HasComponent<GroundBouncableProjectileCD>(projectileID);
				if (obj.piercesEnemiesAmount > 0)
				{
					list.Add(new TextAndFormatFields
					{
						text = piercesString,
						formatFields = new string[0]
					});
				}
				if (bouncingProjectileCD.maxBounceCount > 0 && !flag4)
				{
					list.Add(new TextAndFormatFields
					{
						text = bouncesString,
						formatFields = new string[0]
					});
				}
			}
		}
		else
		{
			GetExplosiveHoverStats(list, in containedObject, flag2, flag, previewReinforced, previewUpgraded, out var _);
		}
		if (PugDatabase.TryGetComponent<AttackContinuouslyCD>(containedObject.objectData, out var component2))
		{
			int damage = component2.damage;
			int num11 = (int)((float)damage * 0.1f);
			list.Add(new TextAndFormatFields
			{
				text = damageString,
				formatFields = new string[2]
				{
					(damage - num11).ToString(),
					(damage + num11).ToString()
				}
			});
		}
		if (PugDatabase.HasComponent<RangeAttackStateCD>(containedObject.objectData) && !PugDatabase.HasComponent<PetCD>(containedObject.objectData))
		{
			RangeAttackStateCD component3 = PugDatabase.GetComponent<RangeAttackStateCD>(containedObject.objectData);
			int num12 = (int)((float)component3.rangeDamage * 0.1f);
			list.Add(new TextAndFormatFields
			{
				text = weaponRangeDamageString,
				formatFields = new string[2]
				{
					(component3.rangeDamage - num12).ToString(),
					(component3.rangeDamage + num12).ToString()
				}
			});
		}
		if (PugDatabase.HasComponent<PugAutomationMinerConfigCD>(containedObject.objectData))
		{
			PugAutomationMinerConfigCD component4 = PugDatabase.GetComponent<PugAutomationMinerConfigCD>(containedObject.objectData);
			list.Add(new TextAndFormatFields
			{
				text = miningDamageString,
				formatFields = new string[1] { component4.damage.ToString() }
			});
		}
		if (PugDatabase.HasComponent<ExtraInventoryCD>(containedObject.objectData))
		{
			ExtraInventoryCD componentData2 = EntityUtility.GetComponentData<ExtraInventoryCD>(EntityUtility.GetLevelEntity(containedObject.objectData), base.world);
			if (previewUpgraded)
			{
				int num13 = componentData2.nextLevelSize - componentData2.size;
				list.Add(new TextAndFormatFields
				{
					text = (componentData2.isPouch ? additionalSlotsPouchStatString : additionalSlotsStatString),
					formatFields = new string[1] { componentData2.nextLevelSize.ToString() },
					additionalText = "(+" + num13 + ")",
					additionalTextColor = Manager.ui.previewReinforcedColor
				});
			}
			else
			{
				list.Add(new TextAndFormatFields
				{
					text = (componentData2.isPouch ? additionalSlotsPouchStatString : additionalSlotsStatString),
					formatFields = new string[1] { componentData2.size.ToString() }
				});
			}
		}
		if (Manager.main.player != null && PugDatabase.HasComponent<PetCD>(containedObject.objectData) && !PugDatabase.GetComponent<PetCD>(containedObject.objectData).buffsOwner)
		{
			PetType petType = PugDatabase.GetComponent<PetCD>(containedObject.objectData).petType;
			int damage2 = PetExtensions.GetDamage(containedObject.amount, petType);
			int num14 = (int)((float)damage2 * 0.1f);
			bool flag5 = PugDatabase.HasComponent<RangeAttackStateCD>(containedObject.objectData);
			list.Add(new TextAndFormatFields
			{
				text = (flag5 ? petRangeDamageString : petMeleeDamageString),
				formatFields = new string[2]
				{
					(damage2 - num14).ToString(),
					(damage2 + num14).ToString()
				}
			});
		}
		FixedList64Bytes<ObjectDataCD> ingredients = new FixedList64Bytes<ObjectDataCD> { in containedObject.objectData };
		bool isCooked = false;
		if (PugDatabase.HasComponent<CookedFoodCD>(containedObject.objectData))
		{
			isCooked = true;
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(containedObject.variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(containedObject.variation);
			ObjectDataCD item = new ObjectDataCD
			{
				objectID = primaryIngredientFromVariation,
				amount = 1
			};
			ingredients.Add(in item);
			item = new ObjectDataCD
			{
				objectID = secondaryIngredientFromVariation,
				amount = 1
			};
			ingredients.Add(in item);
		}
		Entity entity = ((Manager.main.player != null) ? Manager.main.player.entity : Entity.Null);
		if (entity != Entity.Null)
		{
			PugQuerySystem querySystem = Manager.main.player.querySystem;
			PugDatabase.DatabaseBankCD singleton = querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
			ConditionsTableCD singleton2 = querySystem.GetSingleton<ConditionsTableCD>();
			ComponentLookup<FlowerCD> componentLookup = querySystem.GetComponentLookup<FlowerCD>();
			ComponentLookup<FishCD> componentLookup2 = querySystem.GetComponentLookup<FishCD>();
			BufferLookup<GivesConditionsWhenConsumedBuffer> bufferLookup = querySystem.GetBufferLookup<GivesConditionsWhenConsumedBuffer>();
			EntityUtility.TryGetBuffer(entity, base.world, out DynamicBuffer<SummarizedConditionsBuffer> value);
			using NativeArray<ConditionData> nativeArray = ConditionUIExtensions.GetConditionsOnConsume(containedObject.objectData, ingredients, isCooked, entity, singleton, singleton2, componentLookup, componentLookup2, bufferLookup, value, Allocator.Temp);
			list = AddConditionTexts(containedObject, list, nativeArray, previewReinforced: false, isReinforced: false, previewUpgraded: false);
		}
		list = AddConditionTexts(containedObject, list, ConditionUIExtensions.GetConditionsOnEquip(containedObject.objectData), previewReinforced, flag, previewUpgraded);
		List<ConditionData> conditions = new List<ConditionData>();
		if (PugDatabase.HasComponent<PetTalentPoolBuffer>(containedObject.objectData) && PugDatabase.HasComponent<PetCD>(containedObject.objectData))
		{
			Entity petEntity = Entity.Null;
			if (Manager.main.player.activePet != null)
			{
				petEntity = Manager.main.player.activePet.entity;
			}
			conditions = PetExtensions.GetActiveConditions(containedObject, Manager.ui.petInfosTable, PugDatabase.GetComponent<PetCD>(containedObject.objectData), petEntity);
		}
		List<ConditionData> list2 = new List<ConditionData>();
		if (Manager.main.player != null && Manager.main.player.activePet != null && Manager.main.player.activePet.GetAuxDataIndex() != 0 && Manager.main.player.activePet.GetAuxDataIndex() == containedObject.auxDataIndex)
		{
			DynamicBuffer<ConditionsBuffer> conditions2 = EntityUtility.GetConditions(Manager.main.player.activePet.entity, base.world);
			for (int i = 0; i < conditions2.Length; i++)
			{
				list2.Add(conditions2[i].condition.conditionData);
			}
		}
		else
		{
			list2 = ConditionUIExtensions.GetConditions(containedObject.objectData);
		}
		List<ConditionData> conditions3 = MergeConditionsLists(list2, conditions);
		conditions3 = MergeConditionsWithSameDescriptions(conditions3);
		list = AddConditionTexts(containedObject, list, conditions3, previewReinforced: false, isReinforced: false, previewUpgraded: false);
		if (PugDatabase.HasComponent<OffHandCD>(containedObject.objectData))
		{
			OffHandCD component5 = PugDatabase.GetComponent<OffHandCD>(containedObject.objectData);
			if (component5.mechanic != OffHandMechanic.None && component5.mechanic != OffHandMechanic.Bait)
			{
				string text5 = (component5.mechanicValue * 100f).ToString("F0", CultureInfo.InvariantCulture);
				string text6 = PugText.ProcessText(offHandMechanicPrefix + component5.mechanic, new string[1] { text5 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
				list.Add(new TextAndFormatFields
				{
					text = offHandUseString,
					formatFields = new string[1] { text6 },
					color = Color.yellow
				});
			}
		}
		if (!PugDatabase.HasComponent<HasWeaponDamageCD>(containedObject.objectData) && PugDatabase.TryGetComponent<CooldownCD>(containedObject.objectData, out var component6))
		{
			float num15 = component6.cooldown;
			PlayerController player = Manager.main.player;
			if (player != null && component6.casualCharacterIgnoresCustomCooldown && EntityUtility.GetComponentData<CharacterTypeCD>(player.entity, player.world).characterType == CharacterType.Casual)
			{
				num15 = 0f;
			}
			if (num15 >= 1f)
			{
				string sec;
				string min;
				ConditionUI.DurationFormat durationStrings = ConditionUI.GetDurationStrings(num15, out sec, out min, showDecimal: true);
				string[] formatFields = Array.Empty<string>();
				string text7 = cooldownSecString;
				switch (durationStrings)
				{
				case ConditionUI.DurationFormat.SEC:
					formatFields = new string[1] { sec };
					text7 = cooldownSecString;
					break;
				case ConditionUI.DurationFormat.MIN:
					formatFields = new string[1] { min };
					text7 = cooldownMinString;
					break;
				case ConditionUI.DurationFormat.MIN_AND_SEC:
					formatFields = new string[2] { min, sec };
					text7 = cooldownMinSecString;
					break;
				}
				list.Add(new TextAndFormatFields
				{
					text = text7,
					formatFields = formatFields
				});
			}
		}
		if (objectInfo != null && PugDatabase.HasComponent<CommandMinionWeaponCD>(objectInfo.objectID))
		{
			list.Add(new TextAndFormatFields
			{
				text = "useItemTerm",
				formatFields = new string[1] { PugText.ProcessText("commandMinion", null, shouldLocalize: true, shouldLocalizeFormatFields: false) },
				color = Color.yellow
			});
		}
		SecondaryUseCD secondaryUseCD = ((objectInfo != null && PugDatabase.HasComponent<SecondaryUseCD>(objectInfo.objectID)) ? PugDatabase.GetComponent<SecondaryUseCD>(objectInfo.objectID) : default(SecondaryUseCD));
		if (secondaryUseCD.hasSecondaryUse)
		{
			if (secondaryUseCD.mechanic == SecondaryUseMechanic.WindUp)
			{
				list.Add(new TextAndFormatFields
				{
					text = "weaponSecondary",
					formatFields = new string[1] { PugText.ProcessText("WeaponSecondary/" + secondaryUseCD.useTerm, null, shouldLocalize: true, shouldLocalizeFormatFields: false) },
					color = Color.yellow
				});
			}
			else if (secondaryUseCD.mechanic == SecondaryUseMechanic.SpawnMinion)
			{
				bool previewUpgraded2 = Manager.ui.currentSelectedUIElement is UpgradePreviewSlotUI;
				foreach (TextAndFormatFields item2 in MinionExtensions.GetSummonMinionStatText(secondaryUseCD.minionToSpawn, containedObject.objectData, "weaponSecondary", "WeaponSecondary/", previewUpgraded2))
				{
					list.Add(item2);
				}
			}
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	private void GetExplosiveHoverStats(List<TextAndFormatFields> result, in ContainedObjectsBuffer containedObject, bool showBonusStats, bool isReinforced, bool previewReinforced, bool previewUpgraded, out int explosiveDamage)
	{
		explosiveDamage = 0;
		PugDatabase.TryGetComponent<RangeWeaponCD>(containedObject.objectData, out var component);
		if (!StatsUIUtility.HasExplosiveWeapon(containedObject.objectData, out var isExplosiveCD, base.world))
		{
			return;
		}
		explosiveDamage = isExplosiveCD.damage;
		int num = isExplosiveCD.tileDamage;
		int num2 = 0;
		int num3 = 0;
		int num4 = (int)math.round((float)explosiveDamage * 0.14999998f);
		int num5 = (int)math.round((float)num * 0.14999998f);
		if (isReinforced || previewReinforced)
		{
			explosiveDamage += num4;
			num += num5;
		}
		if (previewReinforced)
		{
			num2 = num4;
			num3 = num5;
		}
		if (previewUpgraded)
		{
			int num6 = ((containedObject.variation > 0) ? containedObject.variation : PugDatabase.GetComponent<LevelCD>(containedObject.objectData).level);
			IsExplosiveCD componentData = EntityUtility.GetComponentData<IsExplosiveCD>(EntityUtility.GetLevelEntity(new ObjectDataCD
			{
				objectID = component.projectileID,
				variation = num6 + 1
			}), base.world);
			if (isReinforced)
			{
				componentData.damage += (int)math.round((float)componentData.damage * 0.14999998f);
				componentData.tileDamage += (int)math.round((float)componentData.tileDamage * 0.14999998f);
			}
			num2 = componentData.damage - explosiveDamage;
			explosiveDamage = componentData.damage;
			num3 = componentData.tileDamage - num;
			num = componentData.tileDamage;
		}
		string text = explosiveDamageString;
		string text2 = miningDamageString;
		if (explosiveDamage == 0)
		{
			text = "";
		}
		if (num == 0)
		{
			text2 = "";
		}
		int num7 = (int)((float)explosiveDamage * 0.1f);
		result.Add(new TextAndFormatFields
		{
			text = text,
			formatFields = new string[2]
			{
				(explosiveDamage - num7).ToString(),
				(explosiveDamage + num7).ToString()
			},
			color = (isReinforced ? Manager.ui.reinforcedColor : Color.white),
			additionalText = (showBonusStats ? (("(+" + (int)math.round(num2)).ToString() + ")") : ""),
			additionalTextColor = Manager.ui.previewReinforcedColor
		});
		result.Add(new TextAndFormatFields
		{
			text = text2,
			formatFields = new string[1] { num.ToString() },
			color = (isReinforced ? Manager.ui.reinforcedColor : Color.white),
			additionalText = (showBonusStats ? ("(+" + (int)math.round(num3) + ")") : ""),
			additionalTextColor = Manager.ui.previewReinforcedColor
		});
	}

	private List<ConditionData> MergeConditionsLists(List<ConditionData> conditions1, List<ConditionData> conditions2)
	{
		foreach (ConditionData condition in conditions2)
		{
			int num = conditions1.FindIndex((ConditionData x) => x.conditionID == condition.conditionID);
			if (num == -1)
			{
				conditions1.Add(condition);
				continue;
			}
			ConditionData value = conditions1[num];
			value.value += condition.value;
			conditions1[num] = value;
		}
		return conditions1;
	}

	private List<ConditionData> MergeConditionsWithSameDescriptions(List<ConditionData> conditions)
	{
		List<ConditionData> list = new List<ConditionData>();
		foreach (ConditionData condition in conditions)
		{
			ConditionInfo conditionInfo = Manager.ui.conditionsIconsTable.GetConditionInfo(condition.conditionID);
			int num = 0;
			for (num = 0; num < list.Count; num++)
			{
				ConditionID conditionID = list[num].conditionID;
				ConditionInfo conditionInfo2 = Manager.ui.conditionsIconsTable.GetConditionInfo(conditionID);
				if ((conditionInfo2.useSameDescAsId != ConditionID.None || conditionInfo.useSameDescAsId != ConditionID.None) && (conditionID == conditionInfo.useSameDescAsId || condition.conditionID == conditionInfo2.useSameDescAsId || conditionInfo2.useSameDescAsId == conditionInfo.useSameDescAsId))
				{
					break;
				}
			}
			if (num != list.Count)
			{
				ConditionData value = list[num];
				value.value += condition.value;
				list[num] = value;
			}
			else
			{
				list.Add(condition);
			}
		}
		return list;
	}

	private List<TextAndFormatFields> AddConditionTexts(ContainedObjectsBuffer containedObject, List<TextAndFormatFields> result, IEnumerable<ConditionData> conditions, bool previewReinforced, bool isReinforced, bool previewUpgraded)
	{
		foreach (ConditionData condition in conditions)
		{
			if (!Manager.ui.conditionsIconsTable.GetConditionInfo(condition.conditionID).skipShowingStatText)
			{
				result.Add(ConditionUI.GetConditionTextAndFormatFields(containedObject, condition, previewReinforced, isReinforced, previewUpgraded));
			}
		}
		return result;
	}

	public override ContainedObjectsBuffer GetContainedObject()
	{
		return GetSlotObject();
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		PlayerController player = Manager.main.player;
		ContainedObjectsBuffer slotObject = GetSlotObject();
		CraftingHandler craftingHandler = ((!(player != null)) ? null : ((player.activeCraftingHandler != null) ? player.activeCraftingHandler : player.playerCraftingHandler));
		if (player != null && craftingHandler != null && slotObject.objectID != ObjectID.None && (PugDatabase.HasComponent<ParchmentRecipeCD>(slotObject.objectID) || ((isRepairing || isReinforcing) && PugDatabase.HasComponent<DurabilityCD>(slotObject.objectID))))
		{
			ObjectDataCD objectDataCD = (PugDatabase.HasComponent<ParchmentRecipeCD>(slotObject.objectID) ? PugDatabase.GetComponent<ParchmentRecipeCD>(slotObject.objectID).objectToCraft : slotObject.objectData);
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectDataCD.objectID);
			CraftingHandler.RecipeInfo recipeInfo = new CraftingHandler.RecipeInfo(objectInfo, objectDataCD.amount);
			List<Entity> nearbyChestsToTakeMaterialsFrom = null;
			if (isRepairing || isReinforcing)
			{
				nearbyChestsToTakeMaterialsFrom = craftingHandler.GetNearbyChests();
			}
			return craftingHandler.GetCraftingMaterialInfosForRecipe(recipeInfo, nearbyChestsToTakeMaterialsFrom, isRepairing, isReinforcing);
		}
		return base.GetRequiredMaterials(isRepairing, isReinforcing);
	}

	public override bool ShowRequiredMaterialsAmountNumberColor()
	{
		return slotType != ItemSlotsUIType.BuySlot;
	}

	public override bool GetDurabilityOrFullnessOrXp(out int durability, out int maxDurability, out AmountType amountType)
	{
		durability = 0;
		maxDurability = 0;
		amountType = AmountType.Durability;
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (slotObject.objectID == ObjectID.None || isVanitySlot)
		{
			return false;
		}
		if (PugDatabase.HasComponent<DurabilityCD>(slotObject.objectData))
		{
			maxDurability = PugDatabase.GetComponent<DurabilityCD>(slotObject.objectData).maxDurability;
			if (slotType == ItemSlotsUIType.BuySlot || slotType == ItemSlotsUIType.RecipeSlot)
			{
				durability = maxDurability;
			}
			else
			{
				durability = slotObject.amount;
			}
			return true;
		}
		if (PugDatabase.HasComponent<FullnessCD>(slotObject.objectData))
		{
			amountType = AmountType.Fullness;
			maxDurability = PugDatabase.GetComponent<FullnessCD>(slotObject.objectData).maxFullness;
			if (slotType == ItemSlotsUIType.BuySlot || slotType == ItemSlotsUIType.RecipeSlot)
			{
				durability = 0;
			}
			else
			{
				durability = slotObject.amount;
			}
			return true;
		}
		if (PugDatabase.HasComponent<PetCD>(slotObject.objectData))
		{
			if (PetExtensions.IsAtMaxLevel(slotObject.amount))
			{
				return false;
			}
			amountType = AmountType.Experience;
			maxDurability = PetExtensions.GetTotalXpNeededToLevelUp(slotObject.amount);
			durability = PetExtensions.GetCurrentXpForCurrentLevel(slotObject.amount);
			return true;
		}
		return false;
	}

	public override bool GetLevel(out int level, out bool isMaxLevel)
	{
		level = 0;
		isMaxLevel = false;
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (slotObject.objectID == ObjectID.None || isVanitySlot)
		{
			return false;
		}
		if (PugDatabase.HasComponent<PetCD>(slotObject.objectData))
		{
			level = PetExtensions.GetLevelFromXP(slotObject.amount);
			isMaxLevel = PetExtensions.IsAtMaxLevel(slotObject.amount);
			return true;
		}
		return false;
	}

	public void Highlight()
	{
		if (highlight != null)
		{
			highlight.SetActive(value: true);
		}
	}

	public void ClearHighlight()
	{
		if (highlight != null)
		{
			highlight.SetActive(value: false);
		}
	}

	public void SetAnimationTrigger(int animationID)
	{
		if (autoDisableAnimator)
		{
			if (!_disableAnimatorTimer.isRunning)
			{
				animator.enabled = true;
			}
			_disableAnimatorTimer.Start(1f);
		}
		animator.SetTrigger(animationID);
	}

	protected Sprite GetIcon(ObjectInfo objectInfo, ObjectDataCD objectData)
	{
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(objectData, getSmallIcon: false);
		if (!(iconOverride != null))
		{
			return objectInfo.icon;
		}
		return iconOverride;
	}

	public override UIelement GetAdjacentUIElement(Direction.Id dir, Vector3 currentPosition)
	{
		UIelement uIelement = base.GetAdjacentUIElement(dir, currentPosition);
		if (uIelement != null && uIelement.isShowing)
		{
			return uIelement;
		}
		if (slotsUIContainer == null)
		{
			return null;
		}
		UIelement adjacentUIElement = slotsUIContainer.GetAdjacentUIElement(dir, currentPosition);
		switch (dir)
		{
		case Direction.Id.back:
		{
			int index3 = uiSlotIndex + slotsUIContainer.MAX_COLUMNS;
			if (uiSlotYPosition == slotsUIContainer.visibleRows - 1)
			{
				if (dontWrapAroundNavigation || adjacentUIElement != null)
				{
					break;
				}
				index3 = uiSlotIndex - (slotsUIContainer.visibleRows - 1) * slotsUIContainer.MAX_COLUMNS;
			}
			uIelement = slotsUIContainer.itemSlots[index3];
			break;
		}
		case Direction.Id.forward:
		{
			int index4 = uiSlotIndex - slotsUIContainer.MAX_COLUMNS;
			if (uiSlotYPosition == 0)
			{
				if (dontWrapAroundNavigation || adjacentUIElement != null)
				{
					break;
				}
				index4 = uiSlotIndex + (slotsUIContainer.visibleRows - 1) * slotsUIContainer.MAX_COLUMNS;
			}
			uIelement = slotsUIContainer.itemSlots[index4];
			break;
		}
		case Direction.Id.left:
		{
			int index2 = uiSlotIndex - 1;
			if (uiSlotXPosition == 0)
			{
				if (dontWrapAroundNavigation || adjacentUIElement != null)
				{
					break;
				}
				index2 = slotsUIContainer.MAX_COLUMNS * uiSlotYPosition + slotsUIContainer.visibleColumns - 1;
			}
			uIelement = slotsUIContainer.itemSlots[index2];
			break;
		}
		case Direction.Id.right:
		{
			int index = uiSlotIndex + 1;
			if (uiSlotXPosition == slotsUIContainer.visibleColumns - 1)
			{
				if (dontWrapAroundNavigation || adjacentUIElement != null)
				{
					break;
				}
				index = slotsUIContainer.MAX_COLUMNS * uiSlotYPosition;
			}
			uIelement = slotsUIContainer.itemSlots[index];
			break;
		}
		}
		if (uIelement == null || !uIelement.isShowing)
		{
			return adjacentUIElement;
		}
		return uIelement;
	}
}
