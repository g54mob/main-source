using PlayerEquipment;
using PlayerState;

public class InstrumentSlot : EquipmentSlot
{
	private const float INSTRUMENT_SLOT_COOLDOWN = 0.2f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.InstrumentSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (equipmentUpdateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.PlayingInstrument) && clientInput.IsButtonStateSet(CommandInputButtonStateNames.StopPlayingInstrument_Pressed))
		{
			equipmentUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.PlayingInstrument);
			return true;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_Pressed) && !equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken && !EquipmentSlot.IsItemOnCooldown(in equipmentUpdateAspect.equippedObjectCD.ValueRO, in equipmentUpdateSharedData.databaseBank, in equipmentUpdateLookupData.cooldownLookup, equipmentUpdateAspect.syncedSharedCooldownTimers, in equipmentUpdateSharedData.currentTick))
		{
			if (!equipmentUpdateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.PlayingInstrument))
			{
				equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.PlayingInstrument);
				EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, 0.2f);
			}
			else
			{
				equipmentUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.PlayingInstrument);
			}
			return true;
		}
		return false;
	}
}
