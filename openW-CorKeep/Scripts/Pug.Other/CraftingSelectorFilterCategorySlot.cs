using System.Collections.Generic;
using UnityEngine;

public class CraftingSelectorFilterCategorySlot : SlotUIBase
{
	public Sprite blueBorder;

	public Sprite brownBorder;

	private const string ITEM_CATEGORY = "ItemCategory/";

	public ObjectIDCategory Category { get; private set; }

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y;

	private bool ShowHoverWindow
	{
		get
		{
			if (slotsUIContainer != null)
			{
				return slotsUIContainer.uiScrollWindow.IsShowingPosition(localScrollPosition, background.size.y / 2f);
			}
			return false;
		}
	}

	public override bool isVisibleOnScreen
	{
		get
		{
			if (ShowHoverWindow)
			{
				return base.isVisibleOnScreen;
			}
			return false;
		}
	}

	public void SetCategory(ObjectIDCategory category, CraftingSelectorFilterCategoryUI categoryUI, int slotIndex)
	{
		if (!(category == null))
		{
			uiSlotXPosition = 0;
			uiSlotYPosition = slotIndex;
			visibleSlotIndex = slotIndex;
			slotsUIContainer = categoryUI;
			Category = category;
			icon.sprite = category.icon;
			if (categoryUI.IsSubCategory())
			{
				background.sprite = brownBorder;
			}
			else
			{
				background.sprite = blueBorder;
			}
		}
	}

	public override void UpdateSlot()
	{
		CraftingSelectorFilterCategoryUI craftingSelectorFilterCategoryUI = (CraftingSelectorFilterCategoryUI)slotsUIContainer;
		activeBorder.gameObject.SetActive(craftingSelectorFilterCategoryUI != null && craftingSelectorFilterCategoryUI.filter.Category == Category);
		base.UpdateSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (!(slotsUIContainer == null))
		{
			((CraftingSelectorFilterCategoryUI)slotsUIContainer).OnSlotClicked(this);
			AudioManager.Sfx(SfxTableID.inventorySFXCreativeModeCategory, Manager.main.player.transform.position);
		}
	}

	public override void OnSelected()
	{
		if (!(slotsUIContainer == null))
		{
			((CraftingSelectorFilterCategoryUI)slotsUIContainer).uiScrollWindow.MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f + 0.375f);
			OnSelectSlot();
		}
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		return new TextAndFormatFields
		{
			text = "ItemCategory/" + Category.name
		};
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		return null;
	}

	public override ContainedObjectsBuffer GetContainedObject()
	{
		return default(ContainedObjectsBuffer);
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return null;
	}

	public override HoverTitleIconType GetHoverTitleIconType()
	{
		return HoverTitleIconType.None;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN;
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		return null;
	}

	public override bool GetDurabilityOrFullnessOrXp(out int durability, out int maxDurability, out AmountType amountType)
	{
		durability = 0;
		maxDurability = 0;
		amountType = AmountType.Amount;
		return false;
	}

	public override bool GetLevel(out int level, out bool isMaxLevel)
	{
		level = 0;
		isMaxLevel = false;
		return false;
	}
}
