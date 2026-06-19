using Pug.UnityExtensions;
using Unity.Mathematics;

namespace PlayerState
{
	public static class PlaceObject
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref PlaceObjectPlayerStateCD valueRW = ref changePlayerStateAspect.placeObjectStateCD.ValueRW;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.entity).ValueRO.Position;
			changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(valueRW.positionToPlaceAt - position);
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = true;
			valueRW.placeDuration.Start(changePlayerStateShared.currentTick, 0.05f, changePlayerStateShared.tickRate);
			int animID = -34540245;
			ObjectDataCD objectData = changePlayerStateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
			if (PugDatabase.GetEntityObjectInfo(objectData.objectID, changePlayerStateShared.databaseBankCD.databaseBankBlob, objectData.variation).objectType == ObjectType.PaintTool)
			{
				animID = 1467646999;
			}
			PlayerController.PlayAnimationTrigger(animID, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			PlayerStateCommon.ExitPoppedState(changePlayerStateAspect, changePlayerStateShared);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			if (stateUpdateAspect.placeObjectStateCD.ValueRW.placeDuration.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.PlaceObject);
			}
		}
	}
}
