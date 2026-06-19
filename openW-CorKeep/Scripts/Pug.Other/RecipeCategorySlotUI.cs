using System.Collections.Generic;
using UnityEngine;

public class RecipeCategorySlotUI : SlotUIBase
{
	public override void UpdateSlot()
	{
		if (Manager.main.player.activeCraftingHandler != null && UIManager.GetCraftingBuilding() is Extractor extractor)
		{
			icon.sprite = extractor.recipeSprite;
			EntityUtility.TryGetComponentData<ExtractorCD>(extractor.entity, extractor.world, out var value);
			int amount = Mathf.RoundToInt(value.defaultMinMaxRandomExtractedOutputAmount.x);
			RenderAmountNumber(amount);
		}
		base.UpdateSlot();
	}

	public override ContainedObjectsBuffer GetContainedObject()
	{
		return default(ContainedObjectsBuffer);
	}

	protected override ContainedObjectsBuffer GetSlotObject()
	{
		return default(ContainedObjectsBuffer);
	}

	public override void OnSelected()
	{
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		if (UIManager.GetCraftingBuilding() is Extractor extractor)
		{
			textAndFormatFields.text = extractor.recipeUITitle.mTerm;
		}
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		if (UIManager.GetCraftingBuilding() is Extractor extractor)
		{
			list.Add(new TextAndFormatFields
			{
				text = extractor.recipeUIHoverDesc.mTerm,
				color = Color.white * 0.99f
			});
		}
		return list;
	}

	protected override bool RenderAmountNumber(int amount)
	{
		if (amountNumber == null)
		{
			return false;
		}
		bool flag = amount > 0;
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

	public ObjectCategoryTag GetRecipeRequiredCategoryTag()
	{
		if (UIManager.GetCraftingBuilding() is Extractor extractor)
		{
			EntityUtility.TryGetComponentData<ExtractorCD>(extractor.entity, extractor.world, out var value);
			return value.extractableType;
		}
		return ObjectCategoryTag.None;
	}
}
