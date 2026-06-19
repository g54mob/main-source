using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[BurstCompile]
public struct RangeAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(LocalTransform),
		typeof(AnimationOrientationCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer)
	})]
	private struct RangeAttackStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AttackCooldownTimerCD> __AttackCooldownTimerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__AttackCooldownTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AttackCooldownTimerCD>();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AttackCooldownTimerCD_RW_ComponentTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackCooldownTimerCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref RangeAttackStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RangeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RangeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RangeAttackStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RangeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RangeAttackStateJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> nearbyEntitiesBuffer;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup;

		[ReadOnly]
		public ComponentLookup<DamageTakenTriggerCD> damageTakenTriggerLookup;

		public Entity effectEventBufferSingleton;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public ConditionsTableCD conditionsTable;

		public Unity.Mathematics.Random rnd;

		public NetworkTick currentTick;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<StateInfoCD> stateInfoRef, RefRW<RangeAttackStateCD> rangeStateRef, RefRW<AttackCooldownTimerCD> cooldownTimerRef, in BehaviourTagsCD attackTags)
		{
			LocalTransform transform = attackHelper.localTransformLookup[entity];
			DynamicBuffer<AnimationBuffer> animation = attackHelper.animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			ref StateInfoCD valueRW2 = ref stateInfoRef.ValueRW;
			ref RangeAttackStateCD valueRW3 = ref rangeStateRef.ValueRW;
			ref AttackCooldownTimerCD valueRW4 = ref cooldownTimerRef.ValueRW;
			ref AnimationOrientationCD valueRW5 = ref attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
			if (!valueRW2.IsCurrentState(StateID.RangeAttack))
			{
				return;
			}
			if (valueRW3.isDisabled)
			{
				valueRW2.LeaveState();
				return;
			}
			bool num = valueRW3.aimingAtEntity != Entity.Null && attackHelper.localTransformLookup.HasComponent(valueRW3.aimingAtEntity);
			bool flag = valueRW3.internalState == RangeAttackInternalState.Anticipating;
			bool num2 = flag;
			RangeAttackStateCD rangeAttackStateCD = valueRW3;
			flag = num2 | (!rangeAttackStateCD.dontAllowReAimingDuringAntipation && rangeAttackStateCD.internalState == RangeAttackInternalState.PreparingToShoot);
			bool num3 = flag;
			rangeAttackStateCD = valueRW3;
			flag = num3 | (rangeAttackStateCD.allowReAimingWhileShooting && rangeAttackStateCD.internalState == RangeAttackInternalState.Shooting);
			if (num && flag)
			{
				AimAtEntity(ref valueRW3, ref valueRW5, in transform, attackHelper.localTransformLookup, playerGhostExtrapolatedLookup, ref rnd);
			}
			switch (valueRW3.internalState)
			{
			case RangeAttackInternalState.Anticipating:
				if (!valueRW3.internalTimer.isRunning)
				{
					UpdateAnticipating(ref valueRW3, ref animation, ref valueRW);
				}
				break;
			case RangeAttackInternalState.PreparingToShoot:
				if (valueRW3.internalTimer.isRunning && valueRW3.internalTimer.IsTimerElapsed(time))
				{
					UpdatePreparingToShoot(entity, ref valueRW3);
				}
				break;
			case RangeAttackInternalState.Shooting:
				if (valueRW3.internalTimer.isRunning)
				{
					UpdateShooting(entity, ref valueRW3, ref valueRW5, ref transform, in attackTags, ref animation, ref valueRW);
				}
				break;
			case RangeAttackInternalState.CeasingToShoot:
				if (valueRW3.internalTimer.isRunning && valueRW3.internalTimer.IsTimerElapsed(time))
				{
					UpdateCeasingToShoot(entity, ref valueRW3, ref valueRW4, ref valueRW2);
				}
				break;
			}
		}

		private void UpdateAnticipating(ref RangeAttackStateCD rangeAttackState, ref DynamicBuffer<AnimationBuffer> animation, ref AnimationBufferPointer animationBufferPointer)
		{
			AnimationUtilities.TriggerAnimation((rangeAttackState.animOverride == 0) ? (-1014102059) : rangeAttackState.animOverride, currentTick, animation, ref animationBufferPointer);
			rangeAttackState.internalTimer.Start(time, rangeAttackState.anticipationDuration);
			rangeAttackState.internalState = RangeAttackInternalState.PreparingToShoot;
		}

		private void UpdatePreparingToShoot(Entity entity, ref RangeAttackStateCD rangeAttackState)
		{
			rangeAttackState.internalTimer.Start(time, rangeAttackState.attackDuration);
			rangeAttackState.internalState = RangeAttackInternalState.Shooting;
			Entity entity2 = rangeAttackState.aimingAtEntity;
			if (playerGhostExtrapolatedLookup.TryGetComponent(rangeAttackState.aimingAtEntity, out var componentData))
			{
				entity2 = componentData.playerGhost;
			}
			if (attackHelper.newCombatantsBufferLookup.HasComponent(entity2))
			{
				ecb.AppendToBuffer(entity2, new NewCombatantsBuffer
				{
					Target = entity
				});
			}
		}

		private void UpdateShooting(Entity entity, ref RangeAttackStateCD rangeAttackState, ref AnimationOrientationCD orientation, ref LocalTransform transform, in BehaviourTagsCD attackTags, ref DynamicBuffer<AnimationBuffer> animation, ref AnimationBufferPointer animationBufferPointer)
		{
			bool flag = rangeAttackState.interruptOnDamageTaken && !rangeAttackState.internalTimer.IsTimerElapsed(time) && damageTakenTriggerLookup.HasAndIsComponentEnabled(entity);
			if (rangeAttackState.internalTimer.IsTimerElapsed(time) || flag)
			{
				if (rangeAttackState.ceasingToShootID != 0)
				{
					AnimationUtilities.TriggerAnimation(rangeAttackState.ceasingToShootID, currentTick, animation, ref animationBufferPointer);
				}
				rangeAttackState.internalState = RangeAttackInternalState.CeasingToShoot;
				rangeAttackState.internalTimer.Start(time, rangeAttackState.endDuration);
				rangeAttackState.shotsDone = -1;
				return;
			}
			RangeAttackStateCD rangeAttackStateCD = rangeAttackState;
			if ((rangeAttackStateCD.timeBetweenShots != 0f || rangeAttackStateCD.shotsDone <= 0) && (!rangeAttackState.shootTimer.isRunning || rangeAttackState.shootTimer.IsTimerElapsed(time)))
			{
				int spreadShotsCount = 0;
				for (int i = 0; i < rangeAttackState.projectilesPerShot; i++)
				{
					AimAndShootProjectile(entity, ref rangeAttackState, ref orientation, ref transform, in attackTags, ref spreadShotsCount);
				}
				rangeAttackState.shootTimer.Start(time, rangeAttackState.timeBetweenShots);
				if (rangeAttackState.animPerShotID != 0)
				{
					AnimationUtilities.TriggerAnimation(rangeAttackState.animPerShotID, currentTick, animation, ref animationBufferPointer);
				}
			}
		}

		private void AimAndShootProjectile(Entity entity, ref RangeAttackStateCD rangeAttackState, ref AnimationOrientationCD orientation, ref LocalTransform transform, in BehaviourTagsCD attackTags, ref int spreadShotsCount)
		{
			if (!rangeAttackState.projectileTargetsSelf && rangeAttackState.shootNewRandomTargetsPerProjectile && nearbyEntitiesBuffer.HasComponent(entity) && nearbyEntitiesBuffer[entity].Length > 0)
			{
				rangeAttackState.aimingAtEntity = nearbyEntitiesBuffer[entity][rnd.NextInt(nearbyEntitiesBuffer[entity].Length)].entity;
				AimAtEntity(ref rangeAttackState, ref orientation, in transform, attackHelper.localTransformLookup, playerGhostExtrapolatedLookup, ref rnd);
			}
			float3 float5 = rangeAttackState.shootDirection;
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(rangeAttackState.projectileID, databaseBankCD.databaseBankBlob, rangeAttackState.projectileVariation);
			if (!attackHelper.projectileLookup.HasComponent(primaryPrefabEntity))
			{
				return;
			}
			attackHelper.factionLookup.TryGetComponent(entity, out var componentData);
			if (rangeAttackState.spreadAngle > 0f && rangeAttackState.spreadType != ProjectileSpreadType.None)
			{
				if (rangeAttackState.spreadType == ProjectileSpreadType.Random)
				{
					float5 = math.mul(quaternion.RotateY(math.radians(rnd.NextFloat(0f - rangeAttackState.spreadAngle, rangeAttackState.spreadAngle))), float5);
				}
				else if (rangeAttackState.spreadType == ProjectileSpreadType.BackAndForth)
				{
					if (spreadShotsCount != 0)
					{
						float5 = math.mul(quaternion.RotateY(math.radians(rangeAttackState.startSpreadAngleOffset + rangeAttackState.spreadAngle * (float)((spreadShotsCount % 2 == 0) ? (-(spreadShotsCount - 1)) : spreadShotsCount))), float5);
					}
					spreadShotsCount++;
				}
				else if (rangeAttackState.spreadType == ProjectileSpreadType.Spiral || rangeAttackState.spreadType == ProjectileSpreadType.SpiralDouble)
				{
					float5 = math.mul(quaternion.RotateY(math.radians(rangeAttackState.startSpreadAngleOffset + rangeAttackState.spreadAngle * (float)rangeAttackState.shotsDone)), float5);
				}
				else if (rangeAttackState.spreadType == ProjectileSpreadType.SpiralPingPong)
				{
					int num = (int)(rangeAttackState.maxSpreadAngle / rangeAttackState.spreadAngle) + 1;
					int num2 = rangeAttackState.shotsDone / num;
					float num3 = (float)(rangeAttackState.shotsDone % num) * rangeAttackState.spreadAngle;
					float5 = math.mul(quaternion.RotateY(math.radians(((num2 % 2 == 0) ? num3 : (rangeAttackState.maxSpreadAngle - num3)) + rangeAttackState.startSpreadAngleOffset + (0f - rangeAttackState.maxSpreadAngle) / 2f)), float5);
				}
				if (rangeAttackState.spawnDirectionType == ProjectileSpawnDirectionType.Free)
				{
					rangeAttackState.aimDirection = float5;
					float num4 = rangeAttackState.spawnAtDistanceInfront + rnd.NextFloat(0f - rangeAttackState.spawnAtDistanceInfrontDeviation, rangeAttackState.spawnAtDistanceInfrontDeviation);
					rangeAttackState.relativePositionToShootFrom = rangeAttackState.aimDirection * num4 + rangeAttackState.spawnOffset;
				}
			}
			if (rangeAttackState.projectileTargetsSelf)
			{
				for (int i = 0; i < 5; i++)
				{
					float num5 = rangeAttackState.spawnAtDistanceInfront + rnd.NextFloat(0f - rangeAttackState.spawnAtDistanceInfrontDeviation, rangeAttackState.spawnAtDistanceInfrontDeviation);
					rangeAttackState.relativePositionToShootFrom = float5 * num5 + rangeAttackState.spawnOffset;
					bool flag = false;
					CollisionFilter filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 3u
					};
					if (attackHelper.physicsWorld.CollisionWorld.SphereCast(transform.Position + rangeAttackState.relativePositionToShootFrom + new float3(0f, 0.5f, 0f), 0.49f, float3.zero, 0f, filter))
					{
						flag = true;
					}
					if (!flag)
					{
						int2 worldPosition = (transform.Position + rangeAttackState.relativePositionToShootFrom).RoundToInt2();
						flag = attackHelper.tileAccessor.GetTopType(worldPosition).IsBlockingTile(includeLowColliders: false);
					}
					if (!flag)
					{
						break;
					}
					float5 = math.mul(quaternion.RotateY(math.radians(rnd.NextFloat(0f - rangeAttackState.spreadAngle, rangeAttackState.spreadAngle))), float5);
				}
			}
			Entity entityToFollow = (rangeAttackState.projectileFollowsTarget ? rangeAttackState.aimingAtEntity : Entity.Null);
			if (rangeAttackState.aimDegreesMax != 0f)
			{
				float5 = directionBasedOnVariationLookup[entity].direction.ToFloat3();
			}
			RefRW<RandomCD> refRWOptional = attackHelper.randomLookup.GetRefRWOptional(entity);
			float speedCurveBlendValue = rnd.NextFloat();
			float num6 = rangeAttackState.speedMultiplier;
			if (rangeAttackState.modifyBaseSpeedByTargetDistance && attackHelper.localTransformLookup.TryGetComponent(rangeAttackState.aimingAtEntity, out var componentData2))
			{
				float x = math.distance(transform.Position, componentData2.Position);
				float valueToClamp = math.unlerp(rangeAttackState.minMaxDistanceForBaseSpeedMultiplier.x, rangeAttackState.minMaxDistanceForBaseSpeedMultiplier.y, x);
				valueToClamp = math.clamp(valueToClamp, 0f, 1f);
				num6 *= math.lerp(rangeAttackState.minMaxBaseSpeedMultiplierByTargetDistance.x, rangeAttackState.minMaxBaseSpeedMultiplierByTargetDistance.y, valueToClamp);
			}
			EntityUtility.SpawnProjectile(ecb, transform.Position + rangeAttackState.relativePositionToShootFrom, databaseBankCD.databaseBankBlob, rangeAttackState.projectileID, rangeAttackState.rangeDamage, rangeAttackState.sameFactionHealingPercentage, float5, speedCurveBlendValue, entity, attackTags, attackHelper.summarizeConiditionsLookup, componentData, conditionsTable, refRWOptional, attackHelper.piercingProjectileLookup, rangeAttackState.projectileVariation, num6, entityToFollow);
			if (rangeAttackState.spreadType == ProjectileSpreadType.SpiralDouble)
			{
				EntityUtility.SpawnProjectile(ecb, transform.Position - rangeAttackState.relativePositionToShootFrom, databaseBankCD.databaseBankBlob, rangeAttackState.projectileID, rangeAttackState.rangeDamage, rangeAttackState.sameFactionHealingPercentage, -float5, speedCurveBlendValue, entity, attackTags, attackHelper.summarizeConiditionsLookup, componentData, conditionsTable, refRWOptional, attackHelper.piercingProjectileLookup, rangeAttackState.projectileVariation, num6, entityToFollow);
			}
			if (rangeAttackState.meleeDamageRadiusAtEntity > 0f)
			{
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					attackOffset = 0,
					radius = rangeAttackState.meleeDamageRadiusAtEntity,
					damage = rangeAttackState.rangeDamage,
					playerDamage = rangeAttackState.rangeDamage,
					skipWallAndRootsLootDropOnDestroy = true,
					behaviourTags = attackTags
				};
				attackHelper.Attack(ecb, in p);
			}
			rangeAttackState.shotsDone++;
		}

		private void UpdateCeasingToShoot(Entity entity, ref RangeAttackStateCD rangeAttackState, ref AttackCooldownTimerCD cooldownTimer, ref StateInfoCD stateInfo)
		{
			float num = 1f / (1f + (attackHelper.summarizedConditionEffectsBufferLookup.HasComponent(entity) ? ((float)attackHelper.summarizedConditionEffectsBufferLookup[entity][41].value / 1000f + (float)attackHelper.summarizedConditionEffectsBufferLookup[entity][65].value / 1000f) : 0f));
			float newLifespan = rnd.NextFloat(rangeAttackState.minCooldown, rangeAttackState.maxCooldown) * num;
			cooldownTimer.Value.Start(time, newLifespan);
			stateInfo.LeaveState();
		}

		private static void AimAtEntity(ref RangeAttackStateCD rangeAttackState, ref AnimationOrientationCD orientationRW, in LocalTransform transform, ComponentLookup<LocalTransform> transformGroup, ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedGroup, ref Unity.Mathematics.Random rnd)
		{
			if (!transformGroup.HasComponent(rangeAttackState.aimingAtEntity))
			{
				return;
			}
			float3 float5 = transformGroup[rangeAttackState.aimingAtEntity].Position;
			if (rangeAttackState.maxExtrapolatedAimDistanceSq > 0f && rangeAttackState.minExtrapolatedAimDistanceSq <= rangeAttackState.maxExtrapolatedAimDistanceSq && playerGhostExtrapolatedGroup.HasComponent(rangeAttackState.aimingAtEntity))
			{
				Entity playerGhost = playerGhostExtrapolatedGroup[rangeAttackState.aimingAtEntity].playerGhost;
				if (transformGroup.HasComponent(playerGhost))
				{
					float3 end = float5;
					float3 position = transformGroup[playerGhost].Position;
					float t = math.clamp((math.distancesq(position, transform.Position) - rangeAttackState.minExtrapolatedAimDistanceSq) / (rangeAttackState.maxExtrapolatedAimDistanceSq - rangeAttackState.minExtrapolatedAimDistanceSq), 0f, 1f);
					float5 = math.lerp(position, end, t);
				}
			}
			float3 x = float5 - transform.Position;
			rangeAttackState.aimDirection = math.normalizesafe(x, new float3(0f, 0f, -1f));
			orientationRW.SetFacingDirectionFromVector(rangeAttackState.aimDirection);
			float num = rangeAttackState.spawnAtDistanceInfront + rnd.NextFloat(0f - rangeAttackState.spawnAtDistanceInfrontDeviation, rangeAttackState.spawnAtDistanceInfrontDeviation);
			rangeAttackState.relativePositionToShootFrom = ((rangeAttackState.spawnDirectionType == ProjectileSpawnDirectionType.HorizontalAndVertical) ? MathUtilities.DominantSideF3(rangeAttackState.aimDirection) : rangeAttackState.aimDirection) * num + rangeAttackState.spawnOffset;
			float3 x2 = float5 - (transform.Position + rangeAttackState.relativePositionToShootFrom);
			rangeAttackState.shootDirection = math.normalizesafe(x2, new float3(0f, 0f, -1f));
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AttackCooldownTimerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<RangeAttackStateCD> refRW2 = InternalCompilerInterface.GetRefRW<RangeAttackStateCD>(ptr2, i);
					RefRW<AttackCooldownTimerCD> refRW3 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, i);
					Execute(entity, refRW, refRW2, refRW3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						RefRW<StateInfoCD> refRW4 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<RangeAttackStateCD> refRW5 = InternalCompilerInterface.GetRefRW<RangeAttackStateCD>(ptr2, nextRangeBegin);
						RefRW<AttackCooldownTimerCD> refRW6 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, nextRangeBegin);
						Execute(entity2, refRW4, refRW5, refRW6, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					RefRW<StateInfoCD> refRW7 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<RangeAttackStateCD> refRW8 = InternalCompilerInterface.GetRefRW<RangeAttackStateCD>(ptr2, j);
					RefRW<AttackCooldownTimerCD> refRW9 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, j);
					Execute(entity3, refRW7, refRW8, refRW9, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					RefRW<StateInfoCD> refRW10 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<RangeAttackStateCD> refRW11 = InternalCompilerInterface.GetRefRW<RangeAttackStateCD>(ptr2, k);
					RefRW<AttackCooldownTimerCD> refRW12 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, k);
					Execute(entity4, refRW10, refRW11, refRW12, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageTakenTriggerCD> __DamageTakenTriggerCD_RO_ComponentLookup;

		public RangeAttackStateJob.InternalCompilerQueryAndHandleData __RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			__DamageTakenTriggerCD_RO_ComponentLookup = state.GetComponentLookup<DamageTakenTriggerCD>(isReadOnly: true);
			__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003CD1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003CD1_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003CD1_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003CD2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003CD2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003CD2_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_00003CD3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00003CD3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00003CD3_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00003CD4_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003CD4_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003CD4_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00003CD5_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003CD5_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003CD5_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1506752907_0;

	private EntityQuery __query_1506752907_1;

	private EntityQuery __query_1506752907_2;

	private EntityQuery __query_1506752907_3;

	private EntityQuery __query_1506752907_4;

	private EntityQuery __query_1506752907_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<RangeAttackStateCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_1506752907_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		if (!_attackHelper.isCreated)
		{
			_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		}
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = __query_1506752907_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		__query_1506752907_2.TryGetSingleton<NetworkTime>(out var value);
		if (!__query_1506752907_0.TryGetSingleton<ClientServerTickRate>(out var value2))
		{
			value2.ResolveDefaults();
		}
		_attackHelper.Update(ref state, value.ServerTick, (uint)value2.SimulationTickRate);
		__ScheduleViaJobChunkExtension_0(new RangeAttackStateJob
		{
			attackHelper = _attackHelper,
			nearbyEntitiesBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			directionBasedOnVariationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state),
			damageTakenTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageTakenTriggerCD_RO_ComponentLookup, ref state),
			effectEventBufferSingleton = __query_1506752907_3.GetSingletonEntity(),
			databaseBankCD = __query_1506752907_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			conditionsTable = __query_1506752907_5.GetSingleton<ConditionsTableCD>(),
			rnd = PugRandom.GetRng(),
			currentTick = value.ServerTick,
			ecb = ecb,
			time = elapsedTime
		}, __TypeHandle.__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(RangeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__RangeAttackStateSystem_RangeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1506752907_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_00003CD1_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003CD2_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00003CD3_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003CD4_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003CD5_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RangeAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
