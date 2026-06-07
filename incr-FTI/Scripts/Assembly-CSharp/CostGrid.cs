using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CostGrid : MonoBehaviour
{
	public LayoutGroup layoutGroup;

	public readonly Dictionary<EntityId, CostIcon> inputIcons = new Dictionary<EntityId, CostIcon>();

	public readonly Dictionary<EntityId, CostIcon> outputIcons = new Dictionary<EntityId, CostIcon>();

	public readonly List<CostIcon> rewardIcons = new List<CostIcon>();

	[NonSerialized]
	public ImageButton craftArrow;

	private Image craftArrowImage;

	public LayoutElement layoutElement;

	public UnityAction craftArrowDelegate;

	private ListItemPool<CostIcon> costIconWideSliderPool;

	private ListItemPool<CostIcon> costIconSliderPool;

	private ListItemPool<CostIcon> costIconPool;

	private int placementIndex;

	private float placementCursorPosition;

	private const int margin = 3;

	private const int spacing = 4;

	private const int iconWidth = 40;

	private const int wideSliderWidth = 60;

	private const int craftArrowWidth = 48;

	private const int craftArrowMargin = 2;

	public int fixedSpacing;

	public bool useWideIcon;

	public static bool costGridDebug;

	public static bool debugPlacement;

	public void Clear()
	{
		craftArrowDelegate = null;
		costIconWideSliderPool?.Reset();
		costIconSliderPool?.Reset();
		costIconPool?.Reset();
		placementIndex = 0;
		if (null != craftArrow)
		{
			craftArrow.gameObject.SetActive(value: false);
		}
		inputIcons.Clear();
		outputIcons.Clear();
		rewardIcons.Clear();
		placementCursorPosition = 3f;
		if (null != layoutGroup)
		{
			_ = base.gameObject;
			layoutGroup.enabled = false;
		}
	}

	public void HideBackground()
	{
		if (base.gameObject.TryGetComponent<Image>(out var component))
		{
			component.enabled = false;
		}
	}

	public void AddStaticCost(Cost c)
	{
		foreach (var (state, cost) in c.entries)
		{
			AddStaticCost(state, cost);
		}
		PerformLayout();
	}

	public void PerformLayout()
	{
		if (null == layoutElement)
		{
			layoutElement = GetComponent<LayoutElement>();
			if (null == layoutElement)
			{
				layoutElement = base.gameObject.AddComponent<LayoutElement>();
			}
		}
		int num = -1;
		layoutElement.minWidth = placementCursorPosition + (float)num;
		_ = debugPlacement;
		((RectTransform)base.transform).SetWidth(layoutElement.minWidth);
	}

	public void SetAmount(EntityId id, double amount)
	{
		if (inputIcons.TryGetValue(id, out var value) && GameUtility.NotEquals(value.displayedAmount, amount))
		{
			value.displayedAmount = amount;
			if (GameUtility.IsNearlyZero(amount))
			{
				value.label.enabled = false;
				value.iconImage.color = new Color(1f, 1f, 1f, 0.5f);
			}
			else
			{
				value.label.enabled = true;
				value.iconImage.color = Color.white;
				TextDisplay.SetNumber(value.label, amount);
			}
		}
	}

	public void AddEntity(EntityId id, double amount)
	{
		CostIcon costIcon = GetCostIcon();
		costIcon.tooltipEntity = id;
		costIcon.iconImage.sprite = IconManager.SpriteForEntity(id);
		costIcon.showGuideWhenClicked = true;
		if (amount > 0.0)
		{
			costIcon.label.enabled = true;
			TextDisplay.SetNumber(costIcon.label, amount);
		}
		else
		{
			costIcon.label.enabled = false;
		}
		rewardIcons.Add(costIcon);
	}

	public void AddReward(EntityId id, int level, double amount)
	{
		CostIcon costIcon = GetCostIcon();
		costIcon.tooltipEntity = id;
		costIcon.tooltipModifier = TooltipModifier.QuestReward;
		costIcon.tooltipLevel = level;
		costIcon.iconImage.sprite = IconManager.SpriteForEntity(id);
		costIcon.showGuideWhenClicked = id.UsesTooltipPanel();
		rewardIcons.Add(costIcon);
		if (id.TryAsItem(out var i) && i == ItemType.UtilityIdleRewardBoost)
		{
			costIcon.label.enabled = false;
		}
		else if (amount > 0.0)
		{
			costIcon.label.enabled = true;
			costIcon.label.text = TextDisplay.LocalizedNumber(amount);
		}
		else
		{
			costIcon.label.enabled = false;
		}
	}

	private CostIcon GetCostIcon()
	{
		if (costIconPool == null)
		{
			if (useWideIcon)
			{
				costIconPool = new ListItemPool<CostIcon>(MenuManager.Instance.costIconWidePrefab);
			}
			else
			{
				costIconPool = new ListItemPool<CostIcon>(MenuManager.Instance.costIconPrefab);
			}
		}
		CostIcon item = costIconPool.GetItem(placementIndex, layoutGroup.transform);
		item.ResetState();
		((RectTransform)item.transform).SetPosX(placementCursorPosition);
		placementCursorPosition += 44f;
		placementIndex++;
		return item;
	}

	private CostIcon GetCostSliderIcon(ConsumableState state)
	{
		bool flag = false;
		bool expandBasicIcon = false;
		if (state is ItemState itemState)
		{
			flag = Item.IsCurrency(itemState.type);
			if (flag && itemState.type != ItemType.TownExperiencePoint)
			{
				expandBasicIcon = true;
			}
		}
		return GetCostSliderIcon(flag, expandBasicIcon);
	}

	private CostIcon GetCostSliderIcon(bool forceThinIcon = false, bool expandBasicIcon = false)
	{
		_ = debugPlacement;
		bool flag = useWideIcon && !forceThinIcon;
		int num = ((fixedSpacing > 0) ? fixedSpacing : ((!(flag || expandBasicIcon)) ? 40 : 60));
		CostIcon item;
		if (flag)
		{
			if (costIconWideSliderPool == null)
			{
				costIconWideSliderPool = new ListItemPool<CostIcon>(MenuManager.Instance.costIconWideSliderPrefab);
			}
			item = costIconWideSliderPool.GetItem(placementIndex, layoutGroup.transform);
		}
		else
		{
			if (costIconSliderPool == null)
			{
				costIconSliderPool = new ListItemPool<CostIcon>(MenuManager.Instance.costIconSliderPrefab);
			}
			item = costIconSliderPool.GetItem(placementIndex, layoutGroup.transform);
		}
		((RectTransform)item.transform).SetWidth(num);
		item.ResetState();
		((RectTransform)item.transform).SetPosX(placementCursorPosition);
		placementCursorPosition += num + 4;
		_ = debugPlacement;
		placementIndex++;
		return item;
	}

	public void AddDisplayIcon(ItemRateData itemRateData)
	{
		CostIcon costSliderIcon = GetCostSliderIcon();
		costSliderIcon.useProductionRatio = true;
		costSliderIcon.LoadItemRate(itemRateData);
		costSliderIcon.iconImage.raycastTarget = false;
		costSliderIcon.label.text = string.Empty;
		inputIcons[itemRateData.state.AsEntity()] = costSliderIcon;
	}

	public void AddStaticCost(CountableState state, double cost)
	{
		CostIcon costIcon = GetCostIcon();
		costIcon.LoadStaticCost(state, cost);
		EntityId key = state.AsEntity();
		inputIcons[key] = costIcon;
	}

	public void AddInput(ItemRateData itemRateData)
	{
		ConsumableState state = itemRateData.state;
		CostIcon costSliderIcon = GetCostSliderIcon(state);
		costSliderIcon.useProductionRatio = true;
		costSliderIcon.LoadItemRate(itemRateData);
		EntityId key = state.AsEntity();
		inputIcons[key] = costSliderIcon;
	}

	public void AddOutput(ItemRateData itemRateData)
	{
		ConsumableState state = itemRateData.state;
		CostIcon costSliderIcon = GetCostSliderIcon(state);
		costSliderIcon.useProductionRatio = false;
		costSliderIcon.LoadItemRate(itemRateData);
		EntityId key = state.AsEntity();
		outputIcons[key] = costSliderIcon;
	}

	public void AddNoTradeIcon(ItemType t)
	{
		Sprite s = IconManager.SpriteForItem(t);
		ConfirmCraftArrowSprite(s);
		craftArrow.interactable = false;
		craftArrow.transform.SetSiblingIndex(placementIndex);
		craftArrow.gameObject.SetActive(value: true);
		((RectTransform)craftArrow.transform).SetPosX(placementCursorPosition);
		placementCursorPosition += 52f;
		placementIndex++;
	}

	private void OnCraftArrowPressed()
	{
		craftArrowDelegate?.Invoke();
	}

	private void ConfirmCraftArrowSprite(Sprite s)
	{
		if (null == craftArrow)
		{
			GameObject menuObject = MenuManager.GetMenuObject(MenuManager.Instance.spacerArrowPrefab, layoutGroup.transform);
			craftArrow = menuObject.GetComponent<ImageButton>();
			craftArrowImage = craftArrow.iconImage;
			craftArrow.AddPointerDownTrigger(OnCraftArrowPressed);
		}
		if (craftArrowImage.sprite != s)
		{
			craftArrowImage.sprite = s;
			if (s == IconManager.Instance.productionArrow)
			{
				((RectTransform)craftArrow.transform).SetWidth(16f);
			}
			else
			{
				((RectTransform)craftArrow.transform).SetWidth(32f);
			}
		}
	}

	public void AddSpacerArrow()
	{
		_ = debugPlacement;
		ConfirmCraftArrowSprite(IconManager.Instance.productionArrow);
		craftArrow.interactable = true;
		craftArrow.transform.SetSiblingIndex(placementIndex);
		craftArrow.gameObject.SetActive(value: true);
		placementCursorPosition += 2f;
		((RectTransform)craftArrow.transform).SetPosX(placementCursorPosition);
		placementCursorPosition += 52f;
		placementCursorPosition += 2f;
		placementIndex++;
		craftArrow.buttonState = CustomButtonState.Background;
		craftArrow.AnimateInstant();
	}

	public void UpdateDynamicAffordability()
	{
		foreach (CostIcon value in inputIcons.Values)
		{
			if (value.IsDynamic())
			{
				value.UpdateLabelColorFromStateIndicator();
				value.UpdateSliderColorFromInventoryDelta();
				value.UpdateSliderFillFromCapacity();
			}
			else
			{
				value.UpdateSinglePurchaseAffordability();
			}
		}
		foreach (CostIcon value2 in outputIcons.Values)
		{
			value2.UpdateLabelColorFromStateIndicator();
			value2.UpdateSliderColorFromInventoryDelta();
			value2.UpdateSliderFillFromCapacity();
		}
	}

	public void UpdateSinglePurchaseAffordability()
	{
		foreach (KeyValuePair<EntityId, CostIcon> inputIcon in inputIcons)
		{
			inputIcon.Value.UpdateSinglePurchaseAffordability();
		}
	}

	public void UpdateColors()
	{
		if (TryGetComponent<Image>(out var component))
		{
			component.color = ColorManager.biomePlainsBackgroundDark;
		}
		foreach (CostIcon value in inputIcons.Values)
		{
			if (null != value.stateImage)
			{
				value.stateImage.color = ColorManager.biomePlainsBackgroundMed;
			}
		}
		foreach (CostIcon value2 in outputIcons.Values)
		{
			if (null != value2.stateImage)
			{
				value2.stateImage.color = ColorManager.biomePlainsBackgroundMed;
			}
		}
	}

	public void SetSpacerFlashing(bool nextState)
	{
		if (null != craftArrow)
		{
			craftArrow.buttonState = (nextState ? CustomButtonState.HighlightFlashing : CustomButtonState.Background);
			craftArrow.AnimateInstant();
		}
	}
}
