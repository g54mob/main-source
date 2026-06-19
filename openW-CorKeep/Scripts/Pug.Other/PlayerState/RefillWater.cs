using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

namespace PlayerState
{
	public static class RefillWater
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref RefillWaterStateCD valueRW = ref changePlayerStateAspect.refillWaterStateCD.ValueRW;
			float3 float5 = changePlayerStateAspect.placementCD.ValueRO.bestPositionToPlaceAt;
			bool flag = changePlayerStateAspect.equipmentSlotCD.ValueRO.slotType == EquipmentSlotType.WaterCanSlot;
			if (valueRW.waterSourceEntity != Entity.Null && changePlayerStateLookup.waterSourceLookup.TryGetComponent(valueRW.waterSourceEntity, out var componentData) && changePlayerStateLookup.localTransformLookup.TryGetComponent(valueRW.waterSourceEntity, out var componentData2))
			{
				float5 = componentData2.Position + componentData.splashPosition;
				if (flag)
				{
					valueRW.tileset = (int)componentData.waterTileset;
				}
			}
			else if (flag)
			{
				valueRW.tileset = changePlayerStateShared.tileAccessor.GetTop(float5.RoundToInt2()).tileset;
			}
			valueRW.pickupWorldPosition = float5;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.entity).ValueRO.Position;
			changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(float5 - position);
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = true;
			PlayerController.PlayAnimationTrigger(-718605529, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			valueRW.refillWaterDuration.Start(changePlayerStateShared.currentTick);
			valueRW.particleDelay.Start(changePlayerStateShared.currentTick);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			PlayerStateCommon.ExitPoppedState(changePlayerStateAspect, changePlayerStateShared);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref RefillWaterStateCD valueRW = ref stateUpdateAspect.refillWaterStateCD.ValueRW;
			if (valueRW.particleDelay.isRunning && valueRW.particleDelay.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				valueRW.particleDelay.Stop(sharedStateUpdateData.currentTick);
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW2 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						entity = stateUpdateAspect.entity,
						effectID = EffectID.RefillWater,
						position1 = valueRW.pickupWorldPosition,
						value1 = valueRW.tileset
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
			}
			if (valueRW.refillWaterDuration.isRunning && valueRW.refillWaterDuration.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				valueRW.refillWaterDuration.Stop(sharedStateUpdateData.currentTick);
				stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.RefillWater);
			}
		}
	}
}
