using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace PlayerState
{
	public static class MinecartRiding
	{
		private const float PLAYER_INPUT_FORCE = 1000f;

		private const float FRICTION = 600f;

		private const float MAX_SPEED_TO_DO_ALIGNING = 80f;

		private const float MIN_SPEED_TO_KEEP_ADDING_PLAYER_INPUT_FORCE = 200f;

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref MinecartRidingStateCD valueRW = ref changePlayerStateAspect.minecartRidingStateCD.ValueRW;
			valueRW.activeVelocity = float2.zero;
			valueRW.isBreaking = false;
			valueRW.hasAPlannedTurningPointSet = false;
			valueRW.canTurn = true;
			valueRW.nextPlannedTurningWorldTilePos = int2.zero;
			valueRW.lastTurnedTile = int2.zero;
			valueRW.vectorToNextPlannedTurningWorldTilePos = int2.zero;
			valueRW.timeSinceBreakingTimer.ClearStart();
			changePlayerStateAspect.receivePushbackCD.ValueRW.ClearPushback();
			PlayerController.PlayAnimationTrigger(-1193264516, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = false;
			if (changePlayerStateLookup.localTransformLookup.TryGetComponent(changePlayerStateAspect.controllingOtherEntityCD.ValueRO.requestToBeControlledEntity, out var componentData))
			{
				changePlayerStateLookup.localTransformLookup[changePlayerStateAspect.entity] = componentData;
			}
			if (changePlayerStateShared.isFinalFullPredictionTick)
			{
				changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
			}
			ControllingStateCommon.TryStartControllingControllableElseLeaveState(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateAspect.playerStateCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup, changePlayerStateLookup.minecartLookup, changePlayerStateShared.isPartialTick);
		}

		public static void ResetState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			PlayerController.PlayAnimationTrigger(-1193264516, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			ControllingStateCommon.ReleaseControlledEntity(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup);
			changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = true;
			changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position += new float3(0f, 0f, -0.4f);
			if (changePlayerStateShared.isFinalFullPredictionTick)
			{
				changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
			}
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref MinecartRidingStateCD valueRW = ref stateUpdateAspect.minecartRidingStateCD.ValueRW;
			Entity controlledEntity = stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			if (!lookupStateUpdateData.entityDestroyedLookup.HasComponent(controlledEntity) || lookupStateUpdateData.entityDestroyedLookup.IsComponentEnabled(controlledEntity))
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			if (stateUpdateAspect.interactorCD.ValueRW.TryConsumeInteract() && !valueRW.IsMoving)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			stateUpdateAspect.controllingOtherEntityCD.ValueRW.requestToBeControlledEntity = controlledEntity;
			if (!ControllingStateCommon.TryStartControllingControllableElseLeaveState(stateUpdateAspect.entity, stateUpdateAspect.controllingOtherEntityCD, stateUpdateAspect.playerStateCD, lookupStateUpdateData.controlledByOtherEntityLookup, lookupStateUpdateData.simulateLookup, lookupStateUpdateData.minecartLookup, sharedStateUpdateData.isPartialTick))
			{
				return;
			}
			float3 float5 = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position;
			float3 float6 = float5;
			float2 float7 = new float2(float6.x, float6.z);
			int2 int5 = math.normalizesafe(valueRW.activeVelocity, float2.zero).RoundToInt2();
			TileAccessor tileAccessor = sharedStateUpdateData.tileAccessor;
			if (valueRW.hasAPlannedTurningPointSet)
			{
				float2 float8 = new float2(float5.x, float5.z);
				int2 int6 = math.normalizesafe(valueRW.nextPlannedTurningWorldTilePos - float8, float2.zero).RoundToInt2();
				if (math.any(int6 != valueRW.vectorToNextPlannedTurningWorldTilePos) && math.any(int6 != int2.zero))
				{
					float7 = valueRW.nextPlannedTurningWorldTilePos;
					float5 = new float3(valueRW.nextPlannedTurningWorldTilePos.x, 0f, valueRW.nextPlannedTurningWorldTilePos.y);
				}
			}
			if (tileAccessor.GetTop(float7.RoundToInt2()).tileType != TileType.rail)
			{
				stateUpdateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
				return;
			}
			if (math.any(valueRW.lastTurnedTile != float5.RoundToInt2()))
			{
				valueRW.canTurn = true;
			}
			float3 float9 = stateUpdateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity.ToFloat3();
			float2 x = float2.zero;
			Direction[] allFourClockwise = Direction.allFourClockwise;
			using NativeList<int2> nativeList = new NativeList<int2>(allFourClockwise.Length, Allocator.Temp);
			for (int i = 0; i < allFourClockwise.Length; i++)
			{
				float2 float10 = (float2)allFourClockwise[i].i2 * (0.5f + valueRW.Margin);
				TileCD top = tileAccessor.GetTop((int2)math.round(float7 + float10));
				bool flag = math.any(int5 != int2.zero) && math.dot(allFourClockwise[i].i2, int5) == 0;
				if (top.tileType == TileType.rail && (!flag || valueRW.canTurn))
				{
					nativeList.Add(allFourClockwise[i].i2);
					float2 float11 = float2.zero;
					if ((allFourClockwise[i].id == Direction.Id.forward && float9.z > 0f) || (allFourClockwise[i].id == Direction.Id.back && float9.z < 0f))
					{
						float11 = new float2(0f, float9.z);
					}
					else if ((allFourClockwise[i].id == Direction.Id.right && float9.x > 0f) || (allFourClockwise[i].id == Direction.Id.left && float9.x < 0f))
					{
						float11 = new float2(float9.x, 0f);
					}
					if (math.length(x) < math.length(float11))
					{
						x = float11;
					}
				}
				else if (top.tileType != TileType.rail)
				{
					if ((allFourClockwise[i].id == Direction.Id.forward && float5.z > math.round(float5.z)) || (allFourClockwise[i].id == Direction.Id.back && float5.z < math.round(float5.z)))
					{
						float5.z = math.round(float5.z);
					}
					else if ((allFourClockwise[i].id == Direction.Id.right && float5.x > math.round(float5.x)) || (allFourClockwise[i].id == Direction.Id.left && float5.x < math.round(float5.x)))
					{
						float5.x = math.round(float5.x);
					}
				}
			}
			float num = math.length(valueRW.activeVelocity);
			x = math.normalizesafe(x, float2.zero).RoundToInt2();
			int2 int7 = x.RoundToInt2();
			bool flag2 = math.all(int7 == int2.zero);
			bool flag3 = math.any(int7 != int2.zero) && math.all(int7 + int5 == int2.zero);
			if (flag3)
			{
				valueRW.timeSinceBreakingTimer.Start(sharedStateUpdateData.currentTick);
			}
			if (num < 80f)
			{
				int2 int8 = int2.zero;
				bool flag4 = false;
				if (!flag2)
				{
					int8 = float7.RoundToInt2();
					flag4 = true;
				}
				else if (math.length(float9) > 0f)
				{
					Direction direction = Direction.FromVector(float9, 0f);
					float2 float12 = direction.nextClockwise.f2 * 0.49f;
					int2 int9 = (float7 + float12).RoundToInt2();
					int2 worldPosition = (float7 + float12 + direction.i2).RoundToInt2();
					float2 float13 = direction.nextCounterClockwise.f2 * 0.49f;
					int2 int10 = (float7 + float13).RoundToInt2();
					int2 worldPosition2 = (float7 + float13 + direction.i2).RoundToInt2();
					if (tileAccessor.GetTop(int9).tileType == TileType.rail && tileAccessor.GetTop(worldPosition).tileType == TileType.rail)
					{
						int8 = int9;
						flag4 = true;
						x = direction.f2;
					}
					else if (tileAccessor.GetTop(int10).tileType == TileType.rail && tileAccessor.GetTop(worldPosition2).tileType == TileType.rail)
					{
						int8 = int10;
						flag4 = true;
						x = direction.f2;
					}
				}
				if (flag4)
				{
					bool flag5 = math.abs(x.x) > 0f;
					if (((flag5 && math.abs((float)int8.y - float7.y) > valueRW.Margin) || (!flag5 && math.abs((float)int8.x - float7.x) > valueRW.Margin)) && math.distance(float7, int8) >= valueRW.Margin)
					{
						x = math.normalizesafe((flag5 ? new float2(float7.x, int8.y) : new float2(int8.x, float7.y)) - float7, float2.zero).RoundToInt2();
						int7 = x.RoundToInt2();
						flag3 = math.any(int7 != int2.zero) && math.all(int7 + int5 == int2.zero);
						flag2 = false;
					}
				}
			}
			bool flag6 = !flag2 && math.any(int5 != float2.zero) && math.dot(int7, int5) == 0;
			if (!flag2 && flag6 && math.distance(float7, float7.RoundToInt2()) >= valueRW.Margin)
			{
				x = float2.zero;
				flag3 = false;
				flag2 = true;
			}
			float num2 = 0f;
			lookupStateUpdateData.minecartLookup.TryGetComponent(controlledEntity, out var componentData);
			float maxSpeed = componentData.maxSpeed;
			float valueToClamp = ((num > maxSpeed * 0.9f && (!valueRW.timeSinceBreakingTimer.isRunning || valueRW.timeSinceBreakingTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))) ? 0f : (600f * sharedStateUpdateData.deltaTime));
			int2 int11 = int2.zero;
			valueRW.isBreaking = false;
			if (flag2 || flag3)
			{
				if (num > 0f)
				{
					if (flag3)
					{
						valueToClamp = 1000f * sharedStateUpdateData.deltaTime;
						valueRW.isBreaking = true;
					}
					bool flag7 = false;
					foreach (int2 item in nativeList)
					{
						if (math.all(int5 == item))
						{
							int11 = item;
							flag7 = true;
							break;
						}
					}
					if (!flag7)
					{
						foreach (int2 item2 in nativeList)
						{
							if (math.any(int5 != int2.zero) && math.dot(item2, int5) == 0)
							{
								if (flag7)
								{
									flag7 = false;
									break;
								}
								int11 = item2;
								flag7 = true;
							}
						}
					}
					if (!flag7)
					{
						int11 = int2.zero;
					}
					else if (!flag3 && num > 200f)
					{
						num2 = 1000f * math.length(float9) * sharedStateUpdateData.deltaTime;
					}
				}
			}
			else
			{
				int11 = x.RoundToInt2();
				num2 = 1000f * math.length(float9) * sharedStateUpdateData.deltaTime;
			}
			if (lookupStateUpdateData.simulateLookup.IsComponentEnabled(controlledEntity))
			{
				lookupStateUpdateData.minecartLookup.GetRefRW(controlledEntity).ValueRW.isBreaking = valueRW.isBreaking;
			}
			if (math.any(int11 != int2.zero) && math.any(int5 != int2.zero) && math.dot(int11, int5) == 0)
			{
				valueRW.canTurn = false;
				valueRW.lastTurnedTile = float5.RoundToInt2();
			}
			valueToClamp = math.clamp(valueToClamp, 0f, math.length(valueRW.activeVelocity));
			valueRW.activeVelocity = (float2)int11 * math.clamp(math.length(valueRW.activeVelocity) + num2 - valueToClamp, 0f, maxSpeed);
			float3 value = new float3(valueRW.activeVelocity.x, 0f, valueRW.activeVelocity.y);
			stateUpdateAspect.playerMovementForceCD.ValueRW.Value = value;
			int5 = math.normalizesafe(valueRW.activeVelocity, float2.zero).RoundToInt2();
			if (math.abs(int11.x) > 0 && math.length(float5.z - math.round(float5.z)) <= valueRW.Margin)
			{
				float5.z = math.round(float5.z);
			}
			else if (math.abs(int11.y) > 0 && math.length(float5.x - math.round(float5.x)) <= valueRW.Margin)
			{
				float5.x = math.round(float5.x);
			}
			lookupStateUpdateData.localTransformLookup.GetRefRW(stateUpdateAspect.entity).ValueRW.Position = float5;
			int2 int12 = math.normalizesafe(valueRW.activeVelocity, float2.zero).RoundToInt2();
			int2 int13 = (valueRW.nextPlannedTurningWorldTilePos = new int2((int)math.round(float5.x), (int)math.round(float5.z)));
			float2 float14 = float5.ToFloat2();
			if (math.any(int12 != int2.zero))
			{
				for (int j = 0; j <= 2; j++)
				{
					int2 int14 = int13 + int12 * j;
					int2 int15 = int14;
					if (tileAccessor.GetTop(int15).tileType != TileType.rail)
					{
						break;
					}
					bool flag8 = false;
					for (int k = 0; k < allFourClockwise.Length; k++)
					{
						float2 float15 = (float2)allFourClockwise[k].i2 * (0.5f + valueRW.Margin);
						int2 worldPosition3 = (int2)math.round(int15 + float15);
						TileCD top2 = tileAccessor.GetTop(worldPosition3);
						bool flag9 = math.any(int12 != int2.zero) && math.dot(allFourClockwise[k].i2, int12) == 0;
						int2 int16 = math.normalizesafe(int15 - float14, float2.zero).RoundToInt2();
						bool flag10 = math.any(int5 != int2.zero) && math.any(int16 != int2.zero) && math.all(int5 == int16);
						if (top2.tileType == TileType.rail && flag9 && valueRW.canTurn && flag10)
						{
							Direction.Id id = allFourClockwise[k].id;
							if ((id == Direction.Id.forward && float9.z > 0f) || (id == Direction.Id.back && float9.z < 0f) || (id == Direction.Id.right && float9.x > 0f) || (id == Direction.Id.left && float9.x < 0f))
							{
								flag8 = true;
								break;
							}
						}
					}
					valueRW.nextPlannedTurningWorldTilePos = int14;
					valueRW.vectorToNextPlannedTurningWorldTilePos = math.normalizesafe(int14 - float5.ToFloat2(), float2.zero).RoundToInt2();
					if (flag8)
					{
						break;
					}
				}
				valueRW.hasAPlannedTurningPointSet = true;
			}
			else
			{
				valueRW.hasAPlannedTurningPointSet = false;
			}
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (playerController.isLocal)
			{
				playerController.SmoothSpeed = 7f;
			}
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				playerController.SmoothSpeed = 3.5f;
			}
		}
	}
}
