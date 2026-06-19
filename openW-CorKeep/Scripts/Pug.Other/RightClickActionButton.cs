using PlayerEquipment;
using UnityEngine;

public class RightClickActionButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public Sprite eatSprite;

	public Sprite pickUpSprite;

	public Sprite placeSprite;

	public Sprite castingSprite;

	public Sprite instrumentSprite;

	public GameObject textContainer;

	public override bool isButtonActive => textContainer.activeSelf;

	private Sprite GetSpriteForEquipmentSlotType()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return null;
		}
		EntityUtility.TryGetComponentData<EquipmentSlotCD>(player.entity, player.world, out var value);
		if (value.slotType == EquipmentSlotType.NonUsableSlot)
		{
			return null;
		}
		switch (value.slotType)
		{
		case EquipmentSlotType.EatableSlot:
			return eatSprite;
		case EquipmentSlotType.PlaceObjectSlot:
		case EquipmentSlotType.PaintToolSlot:
		case EquipmentSlotType.FishingRodSlot:
		case EquipmentSlotType.SeederSlot:
			return placeSprite;
		case EquipmentSlotType.WaterCanSlot:
		{
			EntityUtility.TryGetComponentData<EquippedObjectCD>(player.entity, player.world, out var value3);
			if (WaterCanSlot.CanPickUpWater(value3.containedObject.objectData))
			{
				return pickUpSprite;
			}
			return placeSprite;
		}
		case EquipmentSlotType.BucketSlot:
		{
			EntityUtility.TryGetComponentData<EquippedObjectCD>(player.entity, player.world, out var value2);
			if (BucketSlot.CanPickUpWater(value2.containedObject.objectData))
			{
				return pickUpSprite;
			}
			return placeSprite;
		}
		case EquipmentSlotType.ShovelSlot:
			return pickUpSprite;
		case EquipmentSlotType.HoeSlot:
			if (EntityUtility.GetComponentData<PlacementCD>(player.entity, player.world).canPlaceGround)
			{
				return placeSprite;
			}
			return pickUpSprite;
		case EquipmentSlotType.CastingSlot:
			return castingSprite;
		case EquipmentSlotType.InstrumentSlot:
			return instrumentSprite;
		case EquipmentSlotType.RoofingToolSlot:
			if (EntityUtility.GetComponentData<PlacementCD>(player.entity, player.world).canPlaceRoofHole)
			{
				return placeSprite;
			}
			return pickUpSprite;
		default:
			return null;
		}
	}

	public override void UpdateVisuals()
	{
		PlayerController player = Manager.main.player;
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		icon.sprite = ((Manager.ui.isAnyInventoryShowing || Manager.ui.isShowingMap || player == null || player.guestMode || player.instrumentHandler.IsPlayingInstrument || !player.CurrentStateAllowInteractions(isTryingToUseSecondInteract: true)) ? null : GetSpriteForEquipmentSlotType());
		bool flag = icon.sprite != null;
		if (textContainer.activeInHierarchy != flag)
		{
			textContainer.SetActive(flag);
		}
		base.LateUpdate();
	}

	public override void OnDeselected(bool playEffect = true)
	{
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
	}
}
