using System;
using Interaction;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class BoatRiding
	{
		private struct NearbyLocation : IComparable<NearbyLocation>
		{
			public float distance;

			public float3 position;

			public int CompareTo(NearbyLocation other)
			{
				return distance.CompareTo(other.distance);
			}
		}

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.boatRidingStateCD.ValueRW.previousVelocity = float3.zero;
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = false;
			PlayerController.PlayAnimationTrigger(-343041212, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			changePlayerStateAspect.receivePushbackCD.ValueRW.ClearPushback();
			if (ControllingStateCommon.TryStartControllingControllableElseLeaveState(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateAspect.playerStateCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup, changePlayerStateLookup.boatLookup, changePlayerStateShared.isPartialTick))
			{
				changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.controllingOtherEntityCD.ValueRO.controlledEntity).ValueRO.Position;
				if (changePlayerStateShared.isFinalFullPredictionTick)
				{
					changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
				}
			}
		}

		public static void ResetState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			PlayerController.PlayAnimationTrigger(-343041212, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			_ = ref changePlayerStateAspect.boatRidingStateCD.ValueRW;
			ControllingStateCommon.ReleaseControlledEntity(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup);
			RefRW<LocalTransform> refRW = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity);
			NetworkTick currentTick = changePlayerStateShared.currentTick;
			currentTick.Decrement();
			changePlayerStateShared.physicsWorldHistory.GetCollisionWorldFromTick(currentTick, 0u, ref changePlayerStateShared.physicsWorld, out var collWorld);
			if (AttemptToLeaveBoat(in refRW.ValueRO, in changePlayerStateAspect.playerColliderCD.ValueRO, in changePlayerStateShared.tileAccessor, ref collWorld, out var leavePosition))
			{
				refRW.ValueRW.Position = leavePosition;
				if (changePlayerStateShared.isFinalFullPredictionTick)
				{
					changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
				}
			}
			changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = true;
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref BoatRidingStateCD valueRW = ref stateUpdateAspect.boatRidingStateCD.ValueRW;
			Entity controlledEntity = stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			if (!lookupStateUpdateData.entityDestroyedLookup.HasComponent(controlledEntity) || lookupStateUpdateData.entityDestroyedLookup.IsComponentEnabled(controlledEntity))
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			stateUpdateAspect.controllingOtherEntityCD.ValueRW.requestToBeControlledEntity = controlledEntity;
			if (ControllingStateCommon.TryStartControllingControllableElseLeaveState(stateUpdateAspect.entity, stateUpdateAspect.controllingOtherEntityCD, stateUpdateAspect.playerStateCD, lookupStateUpdateData.controlledByOtherEntityLookup, lookupStateUpdateData.simulateLookup, lookupStateUpdateData.boatLookup, sharedStateUpdateData.isPartialTick))
			{
				float2 adjustedMovementVelocity = stateUpdateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity;
				float3 start = adjustedMovementVelocity.ToFloat3();
				float t = math.pow(0.87f, 20f / (float)sharedStateUpdateData.tickRate);
				start = math.lerp(start, valueRW.previousVelocity, t);
				if (math.length(start) < 0.2f && math.length(adjustedMovementVelocity) < 0.1f)
				{
					start = Vector3.zero;
				}
				float3 value = start * stateUpdateAspect.playerMovementCD.ValueRO.movementSpeed;
				stateUpdateAspect.playerMovementForceCD.ValueRW.Value = value;
				valueRW.previousVelocity = start;
			}
		}

		public static void UpdateStateAfterPhysics(Entity entity, ref InteractorCD interactorCD, ref PlayerStateCD playerStateCD, in EffectiveVelocityCD effectiveVelocityCD, in LocalTransform localTransform, in PlayerColliderCD playerColliderCD, DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, NetworkTick currentTick, in TileAccessor tileAccessor, ref PhysicsWorld physicsWorld)
		{
			if (interactorCD.CanConsumeInteract() && !effectiveVelocityCD.IsBarelyMoving)
			{
				if (AttemptToLeaveBoat(in localTransform, in playerColliderCD, in tileAccessor, ref physicsWorld.CollisionWorld, out var _))
				{
					interactorCD.TryConsumeInteract();
					playerStateCD.SetNextState(PlayerStateEnum.Walk);
					return;
				}
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						localOnlyEffect = 1,
						effectID = EffectID.Emote,
						value1 = 16
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
		}

		public static bool AttemptToLeaveBoat(in LocalTransform localTransform, in PlayerColliderCD playerColliderCD, in TileAccessor tileAccessor, ref CollisionWorld collisionWorld, out float3 leavePosition)
		{
			float3 position = localTransform.Position;
			float3 float5 = math.round(position);
			using NativeList<NearbyLocation> list = new NativeList<NearbyLocation>(Direction.allFourClockwise.Length, Allocator.Temp);
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				Direction direction = Direction.allFourClockwise[i];
				float3 float6 = math.round(float5 + direction.f3);
				float distance = math.length(position - float6);
				list.Add(new NearbyLocation
				{
					distance = distance,
					position = float6
				});
			}
			list.Sort();
			leavePosition = float3.zero;
			CollisionFilter collisionFilter = playerColliderCD.defaultCollider.Value.GetCollisionFilter();
			foreach (NearbyLocation item in list)
			{
				if (tileAccessor.GetTop(item.position.RoundToInt2()).tileType.IsWalkableTile() && !collisionWorld.CheckSphere(item.position + new float3(0f, 1f, 0f) * 0.5f, 0.17999999f, collisionFilter))
				{
					leavePosition = item.position;
					return true;
				}
			}
			return false;
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			playerController.shadow.gameObject.SetActive(value: false);
			Boat boat = Manager.memory.GetEntityMono(changePlayerStatePresentationAspect.controllingOtherEntityCD.ValueRO.controlledEntity) as Boat;
			if (boat != null)
			{
				boat.prevSpeed = 0f;
				WaterSim.AddImpulse(boat.waterSimAffector.transform.position);
				playerController.SetAnimSROffset(boat.visualSitPosition.localPosition);
			}
		}

		public static void ExitStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			playerController.shadow.gameObject.SetActive(value: true);
			Boat boat = Manager.memory.GetEntityMono(changePlayerStatePresentationAspect.controllingOtherEntityCD.ValueRO.controlledEntity) as Boat;
			if (boat != null)
			{
				WaterSim.AddImpulse(boat.waterSimAffector.transform.position);
			}
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController)
		{
			Boat boat = Manager.memory.GetEntityMono(stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity) as Boat;
			if (boat != null)
			{
				playerController.SetAnimSROffset(boat.visualSitPosition.localPosition);
			}
		}
	}
}
