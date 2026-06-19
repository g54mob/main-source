using System.Collections.Generic;
using PugMod;
using UnityEngine;

public class CraftingSelectorSlot : SlotUIBase
{
	public ColorReplacer colorReplacer;

	public ObjectData ObjectData { get; private set; }

	public override float localScrollPosition => base.transform.localPosition.y + base.transform.parent.localPosition.y;

	private CraftingSelectorUI CraftingSelectorUI => (CraftingSelectorUI)slotsUIContainer;

	private bool ShowHoverWindow
	{
		get
		{
			if (CraftingSelectorUI != null)
			{
				return CraftingSelectorUI.uiScrollWindow.IsShowingPosition(localScrollPosition, background.size.y / 2f);
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

	public void SetObjectData(ObjectData objectData, CraftingSelectorUI craftingSelectorUI)
	{
		ObjectData = objectData;
		slotsUIContainer = craftingSelectorUI;
		if (objectData.objectID == ObjectID.None)
		{
			SetEmptyIcon();
			return;
		}
		if (!PugDatabase.TryGetObjectInfo(objectData.objectID, out var objectInfo, objectData.variation) || objectInfo.icon == null)
		{
			SetMissingIcon();
			return;
		}
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(objectData, getSmallIcon: false);
		icon.sprite = ((iconOverride != null) ? iconOverride : objectInfo.icon);
		icon.transform.localPosition = objectInfo.iconOffset;
		ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
		{
			objectData = objectData
		};
		colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
		Manager.ui.ApplyAnyIconGradientMap(containedObject, icon);
		background.color = Manager.ui.GetSlotBorderRarityColor(objectInfo.rarity, useDefaultColorForCommon: false, Color.white);
	}

	public override void OnSelected()
	{
		((CraftingSelectorUI)slotsUIContainer).uiScrollWindow.MoveScrollToIncludePosition(localScrollPosition, background.size.y / 2f);
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && player.mouseInventoryHandler != null && ObjectData.objectID != ObjectID.None)
		{
			int amount = ((!(PugDatabase.GetObjectInfo(ObjectData.objectID, ObjectData.variation).isStackable && mod1)) ? 1 : 10);
			player.playerCommandSystem.CreateAndDropEntity(ObjectData.objectID, player.WorldPosition, amount, player.entity, ObjectData.variation);
			AudioManager.Sfx(SfxID.twitch, base.transform.position, 0.1f, 0.55f, 0.1f, reuse: true);
			SetAnimationTrigger(-1023692900);
		}
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		return null;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		TextAndFormatFields objectName = PlayerController.GetObjectName(new ContainedObjectsBuffer
		{
			objectData = ObjectData
		}, localize: false);
		objectName.color = Manager.text.GetRarityColor(PugDatabase.GetObjectInfo(ObjectData.objectID).rarity);
		return objectName;
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		if (!API.Authoring.ObjectProperties.TryGetPropertyString(ObjectData.objectID, "name", out var value))
		{
			value = ObjectData.objectID.ToString();
		}
		string nameTermOverride = Manager.ui.itemOverridesTable.GetNameTermOverride(new ObjectDataCD
		{
			objectID = ObjectData.objectID,
			variation = ObjectData.variation
		});
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

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		return GetHoverStats(new ContainedObjectsBuffer
		{
			objectData = ObjectData
		}, previewReinforced, previewUpgraded: false);
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_SCREEN;
	}

	protected override ContainedObjectsBuffer GetSlotObject()
	{
		return new ContainedObjectsBuffer
		{
			objectData = ObjectData
		};
	}

	public override bool GetDurabilityOrFullnessOrXp(out int durability, out int maxDurability, out AmountType amountType)
	{
		durability = 0;
		maxDurability = 0;
		amountType = AmountType.Durability;
		if (PugDatabase.HasComponent<FullnessCD>(ObjectData))
		{
			amountType = AmountType.Fullness;
			maxDurability = PugDatabase.GetComponent<FullnessCD>(ObjectData).maxFullness;
			durability = PugDatabase.GetObjectInfo(ObjectData.objectID, ObjectData.variation).initialAmount;
			return true;
		}
		return base.GetDurabilityOrFullnessOrXp(out durability, out maxDurability, out amountType);
	}
}
