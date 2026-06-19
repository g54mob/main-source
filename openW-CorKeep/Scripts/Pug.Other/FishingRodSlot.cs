using PlayerEquipment;
using PlayerState;

public class FishingRodSlot : EquipmentSlot
{
	private const float FISHING_SLOT_COOLDOWN = 0.5f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.FishingRodSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		bool isBroken = equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken;
		if (!secondInteractHeld || isBroken)
		{
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		PlaceItem(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		return true;
	}

	private static void PlaceItem(in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		if (EquipmentSlot.IsItemOnCooldown(in equipmentUpdateAspect.equippedObjectCD.ValueRO, in equipmentUpdateSharedData.databaseBank, in equipmentUpdateLookupData.cooldownLookup, equipmentUpdateAspect.syncedSharedCooldownTimers, in equipmentUpdateSharedData.currentTick))
		{
			return;
		}
		if (equipmentUpdateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.Fishing))
		{
			ref FishingStateCD valueRW = ref equipmentUpdateAspect.fishingStateCD.ValueRW;
			bool flag = valueRW.useFishingMiniGame && equipmentUpdateAspect.fishingMiniGameStateCD.ValueRO.isInFishingMiniGame;
			if (!valueRW.IsPullingUp && !flag)
			{
				Fishing.PullUpData pullUpData = new Fishing.PullUpData
				{
					entity = equipmentUpdateAspect.entity,
					fishingStateCD = equipmentUpdateAspect.fishingStateCD,
					animationBuffer = equipmentUpdateAspect.animationBuffer,
					animationBufferPointerCD = equipmentUpdateAspect.animationBufferPointer,
					ghostEffectEventBufferPointerCD = equipmentUpdateAspect.ghostEffectEventBufferPointerCD,
					playerAimPositionCD = equipmentUpdateAspect.playerAimPositionCD,
					ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer,
					currentTick = equipmentUpdateSharedData.currentTick,
					fishingMiniGameStateCD = equipmentUpdateAspect.fishingMiniGameStateCD,
					clientInput = equipmentUpdateAspect.clientInput
				};
				Fishing.BeginPullUp(in pullUpData);
			}
			else if (valueRW.IsPullingUp && valueRW.pullUpTimer.GetElapsedRatio(equipmentUpdateSharedData.currentTick) > 0.2f)
			{
				valueRW.queueThrowAgain = true;
			}
		}
		else
		{
			equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Fishing);
			EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, 0.5f);
		}
	}
}
