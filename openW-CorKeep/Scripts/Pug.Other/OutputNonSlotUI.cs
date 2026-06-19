using System.Collections.Generic;
using UnityEngine;

public class OutputNonSlotUI : SlotUIBase
{
	private CraftingType _craftingType;

	public ObjectCategoryTag _extractObjectCategoryTag;

	public Sprite outputIntoWorldSprite;

	public override void UpdateSlot()
	{
		CraftingHandler activeCraftingHandler = Manager.main.player.activeCraftingHandler;
		if (activeCraftingHandler != null)
		{
			_craftingType = activeCraftingHandler.craftingType;
			if (UIManager.GetCraftingBuilding() is Extractor extractor)
			{
				icon.sprite = outputIntoWorldSprite;
				if (extractor.overrideOutputSprite != null)
				{
					icon.sprite = extractor.overrideOutputSprite;
				}
			}
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
		if (_craftingType == CraftingType.Extract)
		{
			textAndFormatFields.text = "OutputIntoWorld";
		}
		else
		{
			textAndFormatFields.text = "OutputTrash";
		}
		return textAndFormatFields;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		if (_craftingType == CraftingType.Extract)
		{
			textAndFormatFields.text = "OutputIntoWorldDesc";
			textAndFormatFields.color = Color.white * 0.99f;
		}
		else
		{
			textAndFormatFields.text = "OutputTrashDesc";
			textAndFormatFields.color = Color.red * 0.99f;
		}
		return new List<TextAndFormatFields> { textAndFormatFields };
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
