using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

namespace PlayerState
{
	public static class UseOffHand
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.useOffHandStateCD.ValueRW.shieldedAmount = 0f;
			ContainedObjectsBuffer containedObjectsBuffer = changePlayerStateAspect.containedObjectsBuffer[changePlayerStateAspect.equipmentCD.ValueRO.offHandIndex];
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, changePlayerStateShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
			float seconds = 0.5f;
			if (changePlayerStateLookup.cooldownLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				seconds = componentData.cooldown;
			}
			_ = ref changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRO;
			changePlayerStateAspect.useOffHandStateCD.ValueRW.offHandCooldownTimer.Start(changePlayerStateShared.currentTick, seconds, changePlayerStateShared.tickRate);
			changePlayerStateAspect.useOffHandStateCD.ValueRW.useDashNextUpdate = false;
			if (changePlayerStateLookup.offHandLookup.TryGetComponent(primaryPrefabEntity, out var componentData2))
			{
				switch (componentData2.mechanic)
				{
				case OffHandMechanic.Shield:
					StartShieldingRoutine(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup, componentData2);
					break;
				case OffHandMechanic.Dash:
					changePlayerStateAspect.useOffHandStateCD.ValueRW.useDashNextUpdate = true;
					break;
				case OffHandMechanic.Teleport:
					StartTeleport(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case OffHandMechanic.MinionDetonation:
					changePlayerStateAspect.useOffHandStateCD.ValueRW.useMinionDetonationNextUpdate = true;
					break;
				case OffHandMechanic.RemoteDetonator:
					changePlayerStateAspect.useOffHandStateCD.ValueRW.useRemoteDetonatorNextUpdate = true;
					break;
				default:
					changePlayerStateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
					break;
				}
			}
			else
			{
				changePlayerStateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
		}

		private static void StartShieldingRoutine(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup, OffHandCD offHandCD)
		{
			PlayerController.PlayAnimationTrigger(513004264, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			changePlayerStateAspect.useOffHandStateCD.ValueRW.shieldedAmount = offHandCD.mechanicValue;
			changePlayerStateAspect.useOffHandStateCD.ValueRW.minShieldTimer.Start(changePlayerStateShared.currentTick, 0.2f, changePlayerStateShared.tickRate);
			changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Shielding;
			float seconds = (changePlayerStateAspect.characterTypeCD.ValueRO.IsCasual() ? 0.4f : 0.2f);
			changePlayerStateAspect.useOffHandStateCD.ValueRW.parryTimer.Start(changePlayerStateShared.currentTick, seconds, changePlayerStateShared.tickRate);
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRO.Position;
			changePlayerStateAspect.effectEventBuffer.AddToRingBuffer(ref changePlayerStateAspect.effectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.ShieldOffHandSfx,
					position1 = position
				}
			});
		}

		private static void StartMinionDetonationRoutine(StateUpdateAspect changePlayerStateAspect, SharedStateUpdateData changePlayerStateShared, LookupStateUpdateData changePlayerStateLookup)
		{
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRO.Position;
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = changePlayerStateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref changePlayerStateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.MinionDetonation,
					position1 = position
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.MinionDetonating;
			float seconds = 0.5f;
			changePlayerStateAspect.useOffHandStateCD.ValueRW.minionDetonationTimer.Start(changePlayerStateShared.currentTick, seconds, changePlayerStateShared.tickRate);
		}

		private static void StartRemoteDetonatorRoutine(StateUpdateAspect changePlayerStateAspect, SharedStateUpdateData changePlayerStateShared, LookupStateUpdateData changePlayerStateLookup)
		{
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRO.Position;
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = changePlayerStateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref changePlayerStateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.RemoteDetonation,
					position1 = position
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.RemoteDetonation;
			float seconds = 0.5f;
			changePlayerStateAspect.useOffHandStateCD.ValueRW.remoteDetonatorTimer.Start(changePlayerStateShared.currentTick, seconds, changePlayerStateShared.tickRate);
			changePlayerStateAspect.useOffHandStateCD.ValueRW.remoteDetonatorHadAnyTriggered = false;
		}

		private static void StartDashingRoutine(StateUpdateAspect changePlayerStateAspect, SharedStateUpdateData changePlayerStateShared, LookupStateUpdateData changePlayerStateLookup)
		{
			float3 float5 = changePlayerStateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity.ToFloat3();
			float3 x = math.normalizesafe(float5);
			if (math.length(x) == 0f)
			{
				x = changePlayerStateAspect.animationOrientationCD.ValueRO.facingDirection.vec3;
			}
			changePlayerStateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref changePlayerStateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.Dash,
					vector1 = new float3(x.x, 0f, x.z)
				}
			});
			float num = 1f + (float)changePlayerStateLookup.summarizedConditionsLookup[changePlayerStateAspect.entity][205].value / 100f * 0.7f;
			changePlayerStateAspect.useOffHandStateCD.ValueRW.moveTimer.Start(changePlayerStateShared.currentTick, 0.15f * num, changePlayerStateShared.tickRate);
			ref UseOffHandStateCD valueRW = ref changePlayerStateAspect.useOffHandStateCD.ValueRW;
			valueRW.initialDashDirection = float5;
			if (math.length(valueRW.initialDashDirection) == 0f)
			{
				valueRW.initialDashDirection = changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection.vec3;
			}
			else if (math.length(valueRW.initialDashDirection) < 1f)
			{
				valueRW.initialDashDirection = math.normalizesafe(valueRW.initialDashDirection);
			}
			changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Dashing;
		}

		private static void StartTeleport(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			float2 targetMovementVelocity = changePlayerStateAspect.playerMovementCD.ValueRO.targetMovementVelocity;
			ref UseOffHandStateCD valueRW = ref changePlayerStateAspect.useOffHandStateCD.ValueRW;
			valueRW.initialDashDirection = targetMovementVelocity.ToFloat3();
			if (math.length(valueRW.initialDashDirection) == 0f)
			{
				valueRW.initialDashDirection = changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection.vec3;
			}
			else if (math.length(valueRW.initialDashDirection) < 1f)
			{
				valueRW.initialDashDirection = math.normalizesafe(valueRW.initialDashDirection);
			}
			float3 initialDashDirection = valueRW.initialDashDirection;
			float num = 4f;
			float3 float5 = initialDashDirection * num;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRO.Position;
			float3 float6 = position + new float3(0f, 0.5f, 0f);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1u
			};
			RaycastInput input = new RaycastInput
			{
				Start = float6,
				End = float6 + initialDashDirection * num,
				Filter = filter
			};
			NetworkTick currentTick = changePlayerStateShared.currentTick;
			currentTick.Decrement();
			changePlayerStateShared.physicsWorldHistory.GetCollisionWorldFromTick(currentTick, 0u, ref changePlayerStateShared.physicsWorld, out var collWorld);
			float3 float7 = position;
			if (collWorld.CastRay(input, out var closestHit))
			{
				if (!changePlayerStateLookup.tileLookup.HasComponent(closestHit.Entity))
				{
					num = math.length(float6 - closestHit.Position);
					float5 = initialDashDirection * (num - 1f);
					float7 = position + float5;
				}
			}
			else
			{
				float7 = position + float5;
			}
			bool flag = false;
			for (int i = 0; (float)i < num * 2.25f; i++)
			{
				float3 float8 = position + initialDashDirection * i * 0.5f;
				int2 worldPosition = float8.RoundToInt2();
				TileType topType = changePlayerStateShared.tileAccessor.GetTopType(worldPosition);
				if (topType.IsWallTile())
				{
					break;
				}
				if (!topType.IsBlockingTile())
				{
					float7 = float8;
					flag = true;
				}
			}
			if (!flag)
			{
				float7 = position;
			}
			changePlayerStateAspect.effectEventBuffer.AddToRingBuffer(ref changePlayerStateAspect.effectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.ShortTeleportStart,
					position1 = position
				}
			});
			position = float7;
			changePlayerStateAspect.effectEventBuffer.AddToRingBuffer(ref changePlayerStateAspect.effectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					effectID = EffectID.ShortTeleportEnd,
					position1 = position
				}
			});
			changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position = position;
			if (changePlayerStateShared.isFinalFullPredictionTick)
			{
				changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
			}
			changePlayerStateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			if (stateUpdateAspect.useOffHandStateCD.ValueRO.useDashNextUpdate)
			{
				stateUpdateAspect.useOffHandStateCD.ValueRW.useDashNextUpdate = false;
				StartDashingRoutine(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
			}
			if (stateUpdateAspect.useOffHandStateCD.ValueRO.useMinionDetonationNextUpdate)
			{
				stateUpdateAspect.useOffHandStateCD.ValueRW.useMinionDetonationNextUpdate = false;
				StartMinionDetonationRoutine(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
			}
			if (stateUpdateAspect.useOffHandStateCD.ValueRO.useRemoteDetonatorNextUpdate)
			{
				stateUpdateAspect.useOffHandStateCD.ValueRW.useRemoteDetonatorNextUpdate = false;
				StartRemoteDetonatorRoutine(stateUpdateAspect, sharedStateUpdateData, lookupStateUpdateData);
			}
			PlayerRoutines activeRoutine = stateUpdateAspect.playerRoutineCD.ValueRW.activeRoutine;
			if (activeRoutine != PlayerRoutines.Shielding && activeRoutine != PlayerRoutines.Dashing)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
			changePlayerStateAspect.useOffHandStateCD.ValueRW.shieldedAmount = 0f;
			PlayerRoutines activeRoutine = changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine;
			if (activeRoutine == PlayerRoutines.Shielding || activeRoutine == PlayerRoutines.Dashing)
			{
				changePlayerStateAspect.playerRoutineCD.ValueRW.activeRoutine = PlayerRoutines.Inactive;
			}
			if (changePlayerStateAspect.playerStateCD.ValueRW.nextState != PlayerStateEnum.Walk)
			{
				changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
			}
			changePlayerStateAspect.useOffHandStateCD.ValueRW.parryTimer.ClearStart();
		}
	}
}
