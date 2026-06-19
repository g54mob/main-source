using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
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

[BurstCompile]
[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct ChargeAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(PhysicsVelocity),
		typeof(LocalTransform),
		typeof(AnimationOrientationCD),
		typeof(AnimationBuffer)
	})]
	private struct ChargeAttackStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ChargeAttackStateCD> __ChargeAttackStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__ChargeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChargeAttackStateCD>();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__ChargeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChargeAttackStateCD>();
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
			public void Run(ref ChargeAttackStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ChargeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ChargeAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ChargeAttackStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ChargeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ChargeAttackStateJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedGroup;

		[ReadOnly]
		public ComponentLookup<DetectCollisionCD> detectCollisionGroup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> newCombatantsBuffer;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		public AttackSystem.Helper attackHelper;

		public Entity effectEventBufferSingleton;

		public Entity tileDamageBufferEntity;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public float deltaTime;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, ref ChargeAttackStateCD chargeState, in BehaviourTagsCD attackTags, in ObjectPropertiesCD objectPropertiesRO)
		{
			if (stateInfo.IsCurrentState(StateID.Charge))
			{
				DynamicBuffer<AnimationBuffer> animationBuffer = attackHelper.animationBufferLookup[entity];
				ref AnimationBufferPointer valueRW = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
				ObjectPropertiesCD properties = objectPropertiesRO;
				ref AnimationOrientationCD valueRW2 = ref attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
				bool hasVulnerableState = properties.Get<float>(1336944225) != 0f;
				float num = properties.Get<float>(-1177298868);
				float num2 = properties.Get<float>(-512471965) * num;
				if (chargeState.internalState == ChargeAttackInternalState.ChargeAnticipation)
				{
					UpdateChargeAnticipation(ref chargeState, in properties, ref animationBuffer, ref valueRW);
				}
				if (chargeState.internalState == ChargeAttackInternalState.StartCharging && chargeState.internalTimer.GetElapsedTime(time) <= num2)
				{
					UpdateStartChargingDirection(entity, ref chargeState, in properties, ref valueRW2);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.StartCharging && chargeState.internalTimer.IsTimerElapsed(time))
				{
					UpdateStartCharging(entity, ref chargeState, in properties, ref animationBuffer, ref valueRW);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.Charging)
				{
					UpdateCharging(entity, ref chargeState, in properties, in attackTags, ref valueRW2, ref animationBuffer, ref valueRW, hasVulnerableState);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.EndOfChargeAnticipation)
				{
					UpdateEndOfChargeAnticipation(entity, ref chargeState, in properties, ref animationBuffer, ref valueRW);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.EndOfChargeAttack)
				{
					UpdateEndOfChargeAttack(entity, ref chargeState, in properties, in attackTags);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.PendingCollided && chargeState.internalTimer.IsTimerElapsed(time))
				{
					UpdatePendingCollided(entity, ref chargeState, in properties, ref animationBuffer, ref valueRW, hasVulnerableState);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.End && chargeState.internalTimer.IsTimerElapsed(time))
				{
					UpdateEnd(ref chargeState, ref stateInfo, in properties, ref animationBuffer, ref valueRW, hasVulnerableState);
				}
				else if (chargeState.internalState == ChargeAttackInternalState.LeaveState && chargeState.internalTimer.IsTimerElapsed(time))
				{
					stateInfo.LeaveState();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateChargeAnticipation(ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			AnimationUtilities.TriggerAnimation(-1634423587, currentTick, animationBuffer, ref animationBufferPointer);
			chargeState.internalTimer.Start(time, properties.Get<float>(-512471965));
			chargeState.internalState = ChargeAttackInternalState.StartCharging;
			chargeState.chargeConnected = false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateStartChargingDirection(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref AnimationOrientationCD orientationCD)
		{
			if (attackHelper.localTransformLookup.HasComponent(entity) && attackHelper.localTransformLookup.HasComponent(chargeState.targetEntity))
			{
				float3 ourPos = attackHelper.localTransformLookup[entity].Position;
				float3 targetPos = attackHelper.localTransformLookup[chargeState.targetEntity].Position;
				ChargeAttackRotateToTargetType rotateToTargetType = properties.Get<ChargeAttackRotateToTargetType>(1933512735);
				float radiansPerSecond = properties.Get<float>(-520905137);
				UpdateDirection(ref chargeState, in properties, ref orientationCD, in ourPos, in targetPos, rotateToTargetType, radiansPerSecond);
			}
		}

		private void UpdateDirection(ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref AnimationOrientationCD orientationCD, in float3 ourPos, in float3 targetPos, ChargeAttackRotateToTargetType rotateToTargetType, float radiansPerSecond)
		{
			chargeState.targetDirection = GetRotateToTargetDirection(in chargeState, in properties, rotateToTargetType, radiansPerSecond, in ourPos, in targetPos);
			float3 float5 = chargeState.targetDirection;
			if (properties.Has(2030721080))
			{
				float5 = ((math.abs(float5.x) > math.abs(float5.z)) ? new float3(math.sign(float5.x), 0f, 0f) : new float3(0f, 0f, math.sign(float5.z)));
			}
			chargeState.hitDirection = math.normalizesafe(float5);
			orientationCD.SetFacingDirectionFromVector(float5);
		}

		private float3 GetRotateToTargetDirection(in ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ChargeAttackRotateToTargetType chargeAttackRotateToTargetType, float radiansPerSecond, in float3 ourPos, in float3 targetPos)
		{
			if (chargeAttackRotateToTargetType != ChargeAttackRotateToTargetType.FullAim && chargeAttackRotateToTargetType == ChargeAttackRotateToTargetType.DegreesPerSecond)
			{
				float num = radiansPerSecond * deltaTime;
				float3 targetDirection = chargeState.targetDirection;
				float3 float5 = math.normalizesafe(targetPos - ourPos);
				if (math.acos(math.clamp(math.dot(targetDirection, float5), -1f, 1f)) < num)
				{
					return float5;
				}
				float num2 = math.sign(math.cross(targetDirection, float5).y);
				return math.mul(quaternion.AxisAngle(math.up(), num2 * num), targetDirection);
			}
			return math.normalizesafe(targetPos - ourPos);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateStartCharging(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			chargeState.endChargeAlreadyAttacked = false;
			AnimationUtilities.TriggerAnimation(1433117748, currentTick, animationBuffer, ref animationBufferPointer);
			chargeState.internalTimer.Start(time, properties.Get<float>(-540712434));
			chargeState.internalState = ChargeAttackInternalState.Charging;
			Entity entity2 = (playerGhostExtrapolatedLookup.HasComponent(chargeState.targetEntity) ? playerGhostExtrapolatedLookup[chargeState.targetEntity].playerGhost : chargeState.targetEntity);
			if (newCombatantsBuffer.HasComponent(entity2))
			{
				ecb.AppendToBuffer(entity2, new NewCombatantsBuffer
				{
					Target = entity
				});
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateCharging(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, in BehaviourTagsCD attackTags, ref AnimationOrientationCD orientationCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, bool hasVulnerableState)
		{
			if (properties.Has(-1692041522) && attackHelper.localTransformLookup.TryGetComponent(entity, out var componentData) && attackHelper.localTransformLookup.TryGetComponent(chargeState.targetEntity, out var componentData2))
			{
				float3 ourPos = componentData.Position;
				float3 targetPos = componentData2.Position;
				float3 x = targetPos - ourPos;
				float num = math.length(x);
				float num2 = properties.Get<float>(-1511209060);
				float num3 = properties.Get<float>(1304975179);
				if (num > num2 && math.dot(chargeState.targetDirection, math.normalizesafe(x)) > num3)
				{
					ChargeAttackRotateToTargetType rotateToTargetType = properties.Get<ChargeAttackRotateToTargetType>(-1665717828);
					float radiansPerSecond = properties.Get<float>(-1587421259);
					UpdateDirection(ref chargeState, in properties, ref orientationCD, in ourPos, in targetPos, rotateToTargetType, radiansPerSecond);
				}
			}
			float num4 = properties.Get<float>(-1152518709);
			bool flag = properties.Has(-139217693);
			PhysicsVelocity velocityData = attackHelper.GetVelocity(entity);
			velocityData.AddLinear2D(chargeState.targetDirection * movementSpeedGroup[entity].speed * num4 * deltaTime);
			ecb.SetComponent(entity, velocityData);
			bool flag2 = false;
			LocalTransform componentData3;
			LocalTransform componentData4;
			if (!chargeState.attackTimer.isRunning)
			{
				chargeState.attackTimer.Start(time, 0.1f);
			}
			else if (properties.Has(368706065) && attackHelper.localTransformLookup.TryGetComponent(entity, out componentData3) && attackHelper.localTransformLookup.TryGetComponent(chargeState.targetEntity, out componentData4))
			{
				float3 position = componentData3.Position;
				if (math.distance(componentData4.Position, position) < properties.Get<float>(1819839510))
				{
					chargeState.internalState = ChargeAttackInternalState.EndOfChargeAnticipation;
					chargeState.internalTimer.Start(time, properties.Get<float>(-641861890));
				}
			}
			else if (chargeState.attackTimer.IsTimerElapsed(time))
			{
				chargeState.attackTimer.Start(time, 0.01f);
				AttackSystem.Helper.Parameters p = GetAttackParams(entity, in chargeState, properties, effectEventBufferSingleton, attackTags, -1997722203);
				if (attackHelper.Attack(ecb, in p) && !flag)
				{
					flag2 = true;
				}
			}
			if (properties.Has(726753430) && chargeState.internalTimer.IsTimerElapsed(time))
			{
				ChargeAttackInternalState internalState = chargeState.internalState;
				if (internalState != ChargeAttackInternalState.End && internalState != ChargeAttackInternalState.EndOfChargeAnticipation)
				{
					chargeState.internalState = ChargeAttackInternalState.EndOfChargeAnticipation;
					chargeState.internalTimer.Start(time, properties.Get<float>(-641861890));
				}
			}
			if (chargeState.internalTimer.IsTimerElapsed(time))
			{
				ChargeAttackInternalState internalState = chargeState.internalState;
				if (internalState != ChargeAttackInternalState.End && internalState != ChargeAttackInternalState.EndOfChargeAnticipation)
				{
					chargeState.internalState = ChargeAttackInternalState.End;
					chargeState.internalTimer.Start(time, properties.Get<float>(-321386873));
					bool flag3 = properties.Has(1307229275);
					if (hasVulnerableState || flag3)
					{
						AnimationUtilities.TriggerAnimation(198769013, currentTick, animationBuffer, ref animationBufferPointer);
					}
				}
			}
			float num5 = ((num4 > 12f) ? 0.2f : 0.5f);
			if (!flag && !flag2 && detectCollisionGroup.HasComponent(entity) && chargeState.internalTimer.GetElapsedTime(time) > num5 && !detectCollisionGroup[entity].isTriggerEvent && detectCollisionGroup[entity].hitEntity != Entity.Null && math.dot(detectCollisionGroup[entity].Normal, chargeState.targetDirection) < 0f - math.sin(0.34906584f))
			{
				flag2 = true;
			}
			if (flag2)
			{
				AnimationUtilities.TriggerAnimation(-1997722203, currentTick, animationBuffer, ref animationBufferPointer);
				chargeState.internalTimer.Start(time, properties.Get<float>(1862184488));
				chargeState.internalState = ChargeAttackInternalState.PendingCollided;
				chargeState.chargeConnected = true;
				if (properties.Has(2130508658))
				{
					int tileDamage = properties.Get<int>(1689738466);
					AttackSystem.Helper.Parameters endAttackParams = GetEndAttackParams(entity, chargeState, properties, effectEventBufferSingleton, attackTags);
					endAttackParams.boxHalfHorizontalWidth = 0f;
					endAttackParams.boxHalfVerticalWidth = 0f;
					DamageTiles(entity, ecb, attackHelper.localTransformLookup[entity], endAttackParams, tileDamageBufferEntity, tileDamage);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateEndOfChargeAnticipation(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (!chargeState.endChargeAlreadyAttacked)
			{
				chargeState.endChargeAlreadyAttacked = true;
				AnimationUtilities.TriggerAnimation(-596588359, currentTick, animationBuffer, ref animationBufferPointer);
				PhysicsVelocity velocityData = attackHelper.GetVelocity(entity);
				velocityData.AddLinear2D(chargeState.targetDirection * properties.Get<float>(1185638923));
				ecb.SetComponent(entity, velocityData);
			}
			if (chargeState.internalTimer.IsTimerElapsed(time))
			{
				chargeState.internalState = ChargeAttackInternalState.EndOfChargeAttack;
				chargeState.internalTimer.Start(time, properties.Get<float>(410966414));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateEndOfChargeAttack(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, in BehaviourTagsCD attackTags)
		{
			float newLifespan = properties.Get<float>(-321386873);
			bool num = properties.Has(355493884);
			int tileDamage = properties.Get<int>(1689738466);
			chargeState.internalState = ChargeAttackInternalState.End;
			if (chargeState.internalTimer.IsTimerElapsed(time))
			{
				chargeState.internalTimer.Start(time, newLifespan);
			}
			AttackSystem.Helper.Parameters p = GetEndAttackParams(entity, chargeState, properties, effectEventBufferSingleton, attackTags);
			attackHelper.Attack(ecb, in p);
			if (num)
			{
				DamageTiles(entity, ecb, attackHelper.localTransformLookup[entity], p, tileDamageBufferEntity, tileDamage);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdatePendingCollided(Entity entity, ref ChargeAttackStateCD chargeState, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, bool hasVulnerableState)
		{
			chargeState.internalState = ChargeAttackInternalState.End;
			if (!hasVulnerableState)
			{
				float newLifespan = properties.Get<float>(-321386873);
				chargeState.internalTimer.Start(time, newLifespan);
				return;
			}
			chargeState.internalTimer.Start(time, properties.Get<float>(1336944225));
			if (attackHelper.damageReductionLookup.HasComponent(entity))
			{
				AnimationUtilities.TriggerAnimation(425101933, currentTick, animationBuffer, ref animationBufferPointer);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateEnd(ref ChargeAttackStateCD chargeState, ref StateInfoCD stateInfo, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, bool hasVulnerableState)
		{
			if (hasVulnerableState)
			{
				AnimationUtilities.TriggerAnimation(1004185915, currentTick, animationBuffer, ref animationBufferPointer);
				chargeState.internalState = ChargeAttackInternalState.LeaveState;
				float newLifespan = properties.Get<float>(-321386873);
				chargeState.internalTimer.Start(time, newLifespan);
			}
			else
			{
				stateInfo.LeaveState();
			}
		}

		private void SetChargeDirection(ref ChargeAttackStateCD chargeState, Entity entity, AttackSystem.Helper attackHelper, bool hitInDiscreteDirections)
		{
			float3 position = attackHelper.localTransformLookup[entity].Position;
			float3 position2 = attackHelper.localTransformLookup[chargeState.targetEntity].Position;
			chargeState.targetDirection = math.normalizesafe(position2 - position);
			float3 x = chargeState.targetDirection;
			if (hitInDiscreteDirections)
			{
				x = ((math.abs(x.x) > math.abs(x.z)) ? new float3(math.sign(x.x), 0f, 0f) : new float3(0f, 0f, math.sign(x.z)));
			}
			chargeState.hitDirection = math.normalizesafe(x);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChargeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, k));
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
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DetectCollisionCD> __DetectCollisionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> __NewCombatantsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		public ChargeAttackStateJob.InternalCompilerQueryAndHandleData __ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
			__DetectCollisionCD_RO_ComponentLookup = state.GetComponentLookup<DetectCollisionCD>(isReadOnly: true);
			__NewCombatantsBuffer_RO_BufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000394E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000394E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000394E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000394F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000394F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000394F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00003950_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003950_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003950_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_935232219_0;

	private EntityQuery __query_935232219_1;

	private EntityQuery __query_935232219_2;

	private EntityQuery __query_935232219_3;

	private EntityQuery __query_935232219_4;

	private EntityQuery __query_935232219_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate(__query_935232219_0);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		int simulationTickRate = __query_935232219_1.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper = new AttackSystem.Helper(ref state, simulationTickRate);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_935232219_2.TryGetSingleton<NetworkTime>(out var value);
		uint simulationTickRate = (uint)__query_935232219_1.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper.Update(ref state, value.ServerTick, simulationTickRate);
		EntityCommandBuffer ecb = __query_935232219_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new ChargeAttackStateJob
		{
			movementSpeedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
			detectCollisionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DetectCollisionCD_RO_ComponentLookup, ref state),
			newCombatantsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NewCombatantsBuffer_RO_BufferLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			attackHelper = _attackHelper,
			effectEventBufferSingleton = __query_935232219_4.GetSingletonEntity(),
			tileDamageBufferEntity = __query_935232219_5.GetSingletonEntity(),
			ecb = ecb,
			currentTick = value.ServerTick,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static void DamageTiles(Entity entity, EntityCommandBuffer ecb, LocalTransform transform, AttackSystem.Helper.Parameters attackParams, Entity tileDamageBufferEntity, int tileDamage)
	{
		float3 float5 = transform.Position + attackParams.attackOffset;
		bool num = attackParams.boxHalfHorizontalWidth > 0f;
		float num2 = (num ? attackParams.boxHalfHorizontalWidth : attackParams.radius);
		float num3 = (num ? attackParams.boxHalfVerticalWidth : attackParams.radius);
		int2 int5 = new float3(float5.x - num2, 0f, float5.z - num3).RoundToInt2();
		int2 int6 = new float3(float5.x + num2, 0f, float5.z + num3).RoundToInt2();
		NativeList<int2> nativeList = new NativeList<int2>(Allocator.Temp);
		for (int i = int5.x; i <= int6.x; i++)
		{
			for (int j = int5.y; j <= int6.y; j++)
			{
				nativeList.Add(new int2(i, j));
			}
		}
		for (int k = 0; k < nativeList.Length; k++)
		{
			int2 position = nativeList[k];
			ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
			{
				damage = tileDamage,
				position = position,
				skipWallAndRootsLootDropOnDestroy = true,
				canHitGround = false,
				causedByEntity = entity,
				dontHitBridges = true,
				canHitLowColliders = true,
				dontHitWalkableTiles = true
			});
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static AttackSystem.Helper.Parameters GetAttackParams(Entity entity, in ChargeAttackStateCD chargeAttackState, ObjectPropertiesCD properties, Entity effectEventBufferSingleton, BehaviourTagsCD attackTags, int collideAnimID)
	{
		float radius = properties.Get<float>(-643367631);
		int num = properties.Get<int>(-15637100);
		float pushback = properties.Get<float>(-1830327829);
		float reversePushback = properties.Get<float>(-2096660710);
		bool flag = properties.Has(-139217693);
		return new AttackSystem.Helper.Parameters
		{
			effectEventBufferSingleton = effectEventBufferSingleton,
			attacker = entity,
			attackOffset = float3.zero,
			radius = radius,
			damage = num,
			playerDamage = num,
			pushback = pushback,
			reversePushback = reversePushback,
			castDirection = chargeAttackState.targetDirection,
			triggerAnimationOnClientHit = ((!flag) ? collideAnimID : 0),
			skipWallAndRootsLootDropOnDestroy = true,
			behaviourTags = attackTags
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static AttackSystem.Helper.Parameters GetEndAttackParams(Entity entity, ChargeAttackStateCD chargeState, ObjectPropertiesCD properties, Entity effectEventBufferSingleton, BehaviourTagsCD attackTags)
	{
		float num = properties.Get<float>(1313543880);
		float3 float5 = properties.Get<float3>(-1143973445);
		float num2 = properties.Get<float>(-859250850);
		float num3 = properties.Get<float>(-295879974);
		float radius = properties.Get<float>(-643367631);
		int num4 = properties.Get<int>(-15637100);
		float pushback = properties.Get<float>(-1830327829);
		bool flag = properties.Has(1136787668);
		float3 attackOffset = new float3(0f, 0.5f, 0f) + chargeState.hitDirection * num + float5;
		float boxHalfHorizontalWidth = 0f;
		float boxHalfVerticalWidth = 0f;
		if (num2 > 0f && num3 > 0f)
		{
			bool num5 = math.abs(chargeState.hitDirection.x) > math.abs(chargeState.hitDirection.z);
			boxHalfHorizontalWidth = (num5 ? num2 : num3);
			boxHalfVerticalWidth = (num5 ? num3 : num2);
		}
		return new AttackSystem.Helper.Parameters
		{
			effectEventBufferSingleton = effectEventBufferSingleton,
			attacker = entity,
			attackOffset = attackOffset,
			radius = radius,
			boxHalfHorizontalWidth = boxHalfHorizontalWidth,
			boxHalfVerticalWidth = boxHalfVerticalWidth,
			damage = num4,
			playerDamage = num4,
			pushback = pushback,
			castDirection = chargeState.targetDirection,
			skipWallAndRootsLootDropOnDestroy = true,
			canHitLowTriggers = !flag,
			behaviourTags = attackTags
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ChargeAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ChargeAttackStateSystem_ChargeAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD, ChargeAttackStateCD, BehaviourTagsCD, ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity, LocalTransform, AnimationOrientationCD, AnimationBuffer>();
		__query_935232219_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_935232219_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_935232219_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_935232219_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_935232219_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_935232219_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000394E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000394F_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003950_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((ChargeAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ChargeAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChargeAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChargeAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChargeAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
