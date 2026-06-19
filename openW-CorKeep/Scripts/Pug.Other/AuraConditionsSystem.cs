using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(ConditionEffectsUpdateSystemGroup))]
public struct AuraConditionsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(HasAuraConditionCD) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct AddAuraToNearbyAffectedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HasAuraConditionCD>();
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
			public void Run(ref AddAuraToNearbyAffectedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AddAuraToNearbyAffectedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AddAuraToNearbyAffectedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AddAuraToNearbyAffectedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AddAuraToNearbyAffectedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AddAuraToNearbyAffectedJob job, EntityManager entityManager)
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
		public ComponentLookup<AuraDistanceOverrideCD> auraDistanceOverrideLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		public BufferLookup<IsAffectedByAurasFromEntitiesBuffer> isAffectedByAuraEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> merchantLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> critterLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		public WorldInfoCD worldInfo;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers)
		{
			AuraDistanceOverrideCD componentData;
			float radius = (auraDistanceOverrideLookup.TryGetComponent(entity, out componentData) ? componentData.distance : 5f);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 26u
			};
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (!collisionWorld.OverlapSphere(transform.Position, radius, ref outHits, filter))
			{
				return;
			}
			factionLookup.TryGetComponent(entity, out var componentData2);
			for (int i = 0; i < outHits.Length; i++)
			{
				Entity entity2 = outHits[i].Entity;
				if (entityPartLookup.TryGetComponent(entity2, out var componentData3))
				{
					entity2 = componentData3.mainEntity;
				}
				bool flag = minionLookup.HasComponent(entity2);
				if ((simulateLookup.HasAndIsComponentDisabled(entity2) && !flag) || !isAffectedByAuraEntitiesBufferLookup.TryGetBuffer(entity2, out var bufferData) || disablePhysicsLookup.HasAndIsComponentEnabled(entity2))
				{
					continue;
				}
				bool hasAuraAffectingEnemies = summarizedConditionsBuffers[77].value != 0 || summarizedConditionsBuffers[160].value != 0 || summarizedConditionsBuffers[163].value != 0 || summarizedConditionsBuffers[206].value != 0 || summarizedConditionsBuffers[248].value != 0;
				bool hasAuraAffectingAllies = summarizedConditionsBuffers[144].value != 0 || summarizedConditionsBuffers[146].value != 0 || summarizedConditionsBuffers[250].value != 0;
				factionLookup.TryGetComponent(entity2, out var componentData4);
				if (!ShouldAffectWithAura(componentData2, componentData4, hasAuraAffectingEnemies, hasAuraAffectingAllies, entity2, merchantLookup, critterLookup, worldInfo))
				{
					continue;
				}
				bool flag2 = false;
				for (int j = 0; j < bufferData.Length; j++)
				{
					if (bufferData[j].affectedByAuraFromEntity == entity)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					bufferData.Add(new IsAffectedByAurasFromEntitiesBuffer
					{
						affectedByAuraFromEntity = entity
					});
				}
				isAffectedByAuraEntitiesBufferLookup.SetComponentEnabled(entity2, value: true);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), bufferAccessor[i]);
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), bufferAccessor[j]);
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), bufferAccessor[k]);
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

	[BurstCompile]
	[WithAll(new Type[] { typeof(IsAffectedByAurasFromEntitiesBuffer) })]
	private struct UpdateAuraAffectedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsAffectedByAurasFromEntitiesBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionTickTimerBuffer>();
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
			public void Run(ref UpdateAuraAffectedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateAuraAffectedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateAuraAffectedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateAuraAffectedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateAuraAffectedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateAuraAffectedJob job, EntityManager entityManager)
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
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<AuraDistanceOverrideCD> auraDistanceOverrideLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<HasAuraConditionCD> hasAuraConditionLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> merchantLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> critterLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		public ComponentLookup<RadioActiveConditionCD> radioActiveConditionLookup;

		public ComponentLookup<VoidDamageConditionCD> voidDamageConditionLookup;

		public BufferLookup<IsAffectedByAurasFromEntitiesBuffer> isAffectedByEntitiesBufferLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public WorldInfoCD worldInfo;

		public ConditionsTableCD conditionsTableCD;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in LocalTransform transform, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer)
		{
			DynamicBuffer<IsAffectedByAurasFromEntitiesBuffer> dynamicBuffer = isAffectedByEntitiesBufferLookup[entity];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			factionLookup.TryGetComponent(entity, out var componentData);
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				Entity affectedByAuraFromEntity = dynamicBuffer[i].affectedByAuraFromEntity;
				bool flag = false;
				if (affectedByAuraFromEntity != Entity.Null && entityDestroyedLookup.HasAndIsComponentDisabled(affectedByAuraFromEntity))
				{
					AuraDistanceOverrideCD componentData2;
					float num9 = (auraDistanceOverrideLookup.TryGetComponent(affectedByAuraFromEntity, out componentData2) ? componentData2.distance : 5f);
					LocalTransform componentData3;
					bool num10 = (localTransformLookup.TryGetComponent(affectedByAuraFromEntity, out componentData3) ? math.distance(componentData3.Position, transform.Position) : 10000f) <= num9;
					bool flag2 = hasAuraConditionLookup.HasComponent(affectedByAuraFromEntity);
					bool flag3 = summarizedConditionsBufferLookup.HasComponent(affectedByAuraFromEntity);
					bool flag4 = !disablePhysicsLookup.HasComponent(entity) || !disablePhysicsLookup.IsComponentEnabled(entity);
					if (num10 && flag2 && flag3 && flag4)
					{
						flag = true;
					}
				}
				factionLookup.TryGetComponent(affectedByAuraFromEntity, out var componentData4);
				bool flag5 = CanAffectEnemyWithAura(in componentData, in componentData4, entity, merchantLookup, critterLookup, in worldInfo);
				bool flag6 = CanAffectAllyWithAura(in componentData, in componentData4, in worldInfo);
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = 0;
				int num16 = 0;
				int num17 = 0;
				int num18 = 0;
				if (summarizedConditionsBufferLookup[entity][187].value > 0 || summarizedConditionsBufferLookup[entity][81].value > 0)
				{
					flag = false;
				}
				if (flag)
				{
					bool flag7 = healthLookup.HasComponent(entity);
					if (flag5)
					{
						num11 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][77].value;
						if (num11 < num)
						{
							num = num11;
						}
						num12 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][160].value;
						if (num12 < num4)
						{
							num4 = num12;
						}
						if (flag7)
						{
							num13 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][163].value;
							int num19 = (int)math.round((float)(num13 * summarizedConditionsBufferLookup[affectedByAuraFromEntity][314].value) / 100f);
							num13 += num19;
							if (num13 > num5)
							{
								num5 = num13;
							}
							num14 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][206].value;
							if (num14 > num6)
							{
								num6 = num14;
							}
							num17 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][248].value;
							if (num17 < num7)
							{
								num7 = num17;
							}
						}
					}
					if (flag6)
					{
						num15 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][144].value;
						if (num15 > num2)
						{
							num2 = num15;
						}
						num18 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][250].value;
						if (num18 > num8)
						{
							num8 = num18;
						}
						if (flag7)
						{
							num16 = summarizedConditionsBufferLookup[affectedByAuraFromEntity][146].value;
							if (num16 > num3)
							{
								num3 = num16;
							}
						}
					}
				}
				if (num11 == 0 && num15 == 0 && num16 == 0 && num12 == 0 && num13 == 0 && num14 == 0 && num17 == 0 && num18 == 0)
				{
					dynamicBuffer.RemoveAtSwapBack(i);
					i--;
				}
			}
			DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = summarizedConditionsBufferLookup[entity];
			if (num < 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraMovementSpeedDecrease,
					value = num,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraMovementSpeedDecrease, conditionsBuffer);
			}
			if (num2 > 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraDamageIncrease,
					value = num2,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraDamageIncrease, conditionsBuffer);
			}
			if (num3 > 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraHealingOverTime,
					value = num3,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraHealingOverTime, conditionsBuffer);
			}
			if (num4 < 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraDamageDecrease,
					value = num4,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraDamageDecrease, conditionsBuffer);
			}
			if (num5 > summarizedConditionsBuffer[29].value && summarizedConditionsBuffer[159].value == 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.Burning,
					value = num5,
					valueMultiplier = 1f,
					duration = 8.4f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			if (num6 > 0 && summarizedConditionsBuffer[243].value == 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraRadioactiveDamageOverTime,
					value = num6,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				if (!radioActiveConditionLookup.IsComponentEnabled(entity))
				{
					radioActiveConditionLookup.SetComponentEnabled(entity, value: true);
					ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AuraRadioactiveDamageOverTime);
				}
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraRadioactiveDamageOverTime, conditionsBuffer);
				if (radioActiveConditionLookup.IsComponentEnabled(entity))
				{
					radioActiveConditionLookup.SetComponentEnabled(entity, value: false);
					ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.AuraRadioactiveDamageOverTime);
				}
			}
			if (num7 < 0 && summarizedConditionsBuffer[251].value == 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.AuraVoidDamagePercentageOverTime,
					value = num7,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				if (!voidDamageConditionLookup.IsComponentEnabled(entity))
				{
					voidDamageConditionLookup.SetComponentEnabled(entity, value: true);
					ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AuraVoidDamagePercentageOverTime);
				}
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.AuraVoidDamagePercentageOverTime, conditionsBuffer);
				if (voidDamageConditionLookup.IsComponentEnabled(entity))
				{
					voidDamageConditionLookup.SetComponentEnabled(entity, value: false);
					ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.AuraVoidDamagePercentageOverTime);
				}
			}
			if (num8 > 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.ImmuneToVoidDamageOverTime,
					value = 1,
					valueMultiplier = 1f
				}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.ImmuneToVoidDamageOverTime, conditionsBuffer);
			}
			if (dynamicBuffer.Length == 0)
			{
				isAffectedByEntitiesBufferLookup.SetComponentEnabled(entity, value: false);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor[i];
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor2[i];
					Execute(entity, ref conditionsBuffer, in transform, ref conditionTickTimerBuffer);
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
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor[nextRangeBegin];
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref conditionsBuffer2, in transform2, ref conditionTickTimerBuffer2);
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
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor[j];
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref conditionsBuffer3, in transform3, ref conditionTickTimerBuffer3);
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
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor[k];
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref conditionsBuffer4, in transform4, ref conditionTickTimerBuffer4);
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
		public ComponentLookup<AuraDistanceOverrideCD> __AuraDistanceOverrideCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		public BufferLookup<IsAffectedByAurasFromEntitiesBuffer> __IsAffectedByAurasFromEntitiesBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> __MerchantCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> __CritterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

		public ComponentLookup<MinionCD> __MinionCD_RW_ComponentLookup;

		public AddAuraToNearbyAffectedJob.InternalCompilerQueryAndHandleData __AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HasAuraConditionCD> __HasAuraConditionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public ComponentLookup<RadioActiveConditionCD> __RadioActiveConditionCD_RW_ComponentLookup;

		public ComponentLookup<VoidDamageConditionCD> __VoidDamageConditionCD_RW_ComponentLookup;

		public UpdateAuraAffectedJob.InternalCompilerQueryAndHandleData __AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__AuraDistanceOverrideCD_RO_ComponentLookup = state.GetComponentLookup<AuraDistanceOverrideCD>(isReadOnly: true);
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__IsAffectedByAurasFromEntitiesBuffer_RW_BufferLookup = state.GetBufferLookup<IsAffectedByAurasFromEntitiesBuffer>();
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__MerchantCD_RO_ComponentLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
			__CritterCD_RO_ComponentLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
			__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			__MinionCD_RW_ComponentLookup = state.GetComponentLookup<MinionCD>();
			__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__HasAuraConditionCD_RO_ComponentLookup = state.GetComponentLookup<HasAuraConditionCD>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__RadioActiveConditionCD_RW_ComponentLookup = state.GetComponentLookup<RadioActiveConditionCD>();
			__VoidDamageConditionCD_RW_ComponentLookup = state.GetComponentLookup<VoidDamageConditionCD>();
			__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000039B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000039B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000039B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000039C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000039C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000039C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1043403435_0;

	private EntityQuery __query_1043403435_1;

	private EntityQuery __query_1043403435_2;

	private EntityQuery __query_1043403435_3;

	private EntityQuery __query_1043403435_4;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool ShouldAffectWithAura(FactionCD entityFaction, FactionCD nearbyEntityFaction, bool hasAuraAffectingEnemies, bool hasAuraAffectingAllies, Entity nearbyEntity, ComponentLookup<MerchantCD> merchantLookup, ComponentLookup<CritterCD> critterLookup, WorldInfoCD worldInfo)
	{
		if (!hasAuraAffectingEnemies || !CanAffectEnemyWithAura(in entityFaction, in nearbyEntityFaction, nearbyEntity, merchantLookup, critterLookup, in worldInfo))
		{
			if (hasAuraAffectingAllies)
			{
				return CanAffectAllyWithAura(in entityFaction, in nearbyEntityFaction, in worldInfo);
			}
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool CanAffectEnemyWithAura(in FactionCD entityFaction, in FactionCD nearbyEntityFaction, Entity nearbyEntity, ComponentLookup<MerchantCD> merchantLookup, ComponentLookup<CritterCD> critterLookup, in WorldInfoCD worldInfo)
	{
		if (entityFaction.CanAttack(nearbyEntityFaction, worldInfo) && !merchantLookup.HasComponent(nearbyEntity))
		{
			return !critterLookup.HasComponent(nearbyEntity);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool CanAffectAllyWithAura(in FactionCD entityFaction, in FactionCD nearbyEntityFaction, in WorldInfoCD worldInfo)
	{
		if (!entityFaction.CanAttack(nearbyEntityFaction, worldInfo))
		{
			return entityFaction.faction == nearbyEntityFaction.faction;
		}
		return false;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1043403435_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 5, 4f))
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new AddAuraToNearbyAffectedJob
			{
				auraDistanceOverrideLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AuraDistanceOverrideCD_RO_ComponentLookup, ref state),
				entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
				isAffectedByAuraEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__IsAffectedByAurasFromEntitiesBuffer_RW_BufferLookup, ref state),
				disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				merchantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MerchantCD_RO_ComponentLookup, ref state),
				critterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state),
				simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
				collisionWorld = __query_1043403435_1.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				worldInfo = __query_1043403435_2.GetSingleton<WorldInfoCD>(),
				minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RW_ComponentLookup, ref state)
			}, __TypeHandle.__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new UpdateAuraAffectedJob
			{
				entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				auraDistanceOverrideLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AuraDistanceOverrideCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				hasAuraConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasAuraConditionCD_RO_ComponentLookup, ref state),
				summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
				disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
				merchantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MerchantCD_RO_ComponentLookup, ref state),
				critterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state),
				healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
				radioActiveConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RadioActiveConditionCD_RW_ComponentLookup, ref state),
				voidDamageConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VoidDamageConditionCD_RW_ComponentLookup, ref state),
				isAffectedByEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__IsAffectedByAurasFromEntitiesBuffer_RW_BufferLookup, ref state),
				currentTick = value.ServerTick,
				tickRate = (uint)__query_1043403435_3.GetSingleton<ClientServerTickRate>().SimulationTickRate,
				worldInfo = __query_1043403435_2.GetSingleton<WorldInfoCD>(),
				conditionsTableCD = __query_1043403435_4.GetSingleton<ConditionsTableCD>()
			}, __TypeHandle.__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(AddAuraToNearbyAffectedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__AuraConditionsSystem_AddAuraToNearbyAffectedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(UpdateAuraAffectedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__AuraConditionsSystem_UpdateAuraAffectedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1043403435_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1043403435_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1043403435_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1043403435_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1043403435_4 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000039B_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000039C_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((AuraConditionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AuraConditionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AuraConditionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
