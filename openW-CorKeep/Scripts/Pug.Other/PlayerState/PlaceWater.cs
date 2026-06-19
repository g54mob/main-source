using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

namespace PlayerState
{
	public static class PlaceWater
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref PlaceWaterStateCD valueRW = ref changePlayerStateAspect.placeWaterStateCD.ValueRW;
			int3 bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.entity).ValueRO.Position;
			changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(bestPositionToPlaceAt - position);
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = true;
			PlayerController.PlayAnimationTrigger(-1386071255, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			valueRW.placeWaterDuration.Start(changePlayerStateShared.currentTick);
			valueRW.particleDelay.Start(changePlayerStateShared.currentTick);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			PlayerStateCommon.ExitPoppedState(changePlayerStateAspect, changePlayerStateShared);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref PlaceWaterStateCD valueRW = ref stateUpdateAspect.placeWaterStateCD.ValueRW;
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
						effectID = EffectID.PlaceWater,
						position1 = valueRW.bestPositionToPlaceAt + (new float3(0f, 1f, 0f) + -new float3(0f, 0f, 1f)) * 0.01f,
						value1 = valueRW.tileset
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
			}
			if (valueRW.placeWaterDuration.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.PlaceWater);
			}
		}
	}
}
