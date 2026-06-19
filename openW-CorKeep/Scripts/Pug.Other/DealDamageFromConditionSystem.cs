using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
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
public struct DealDamageFromConditionSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(BurningConditionCD),
		typeof(HealthCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct BurningJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BurningConditionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionTickTimerBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
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
			public void Run(ref BurningJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BurningJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BurningJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BurningJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BurningJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BurningJob job, EntityManager entityManager)
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
		public ComponentLookup<DisablePhysicsCD> physicsExcludeLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> physicsColliderLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public ComponentLookup<BurningConditionCD> burningConditionLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public Entity healthChangeBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer)
		{
			ref TickTimer orCreateTickTimer = ref ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.Burning);
			if (!orCreateTickTimer.isRunning)
			{
				orCreateTickTimer.Start(currentTick, 1f, tickRate);
			}
			bool flag = (entityDestroyedLookup.HasComponent(entity) && entityDestroyedLookup.IsComponentEnabled(entity)) || physicsExcludeLookup.HasAndIsComponentEnabled(entity) || !physicsColliderLookup.HasComponent(entity);
			if (orCreateTickTimer.IsTimerElapsed(currentTick) && !flag)
			{
				orCreateTickTimer.Start(currentTick, 2f, tickRate);
				float num = (float)summarizedConditionsBuffer[336].value / 100f;
				int num2 = (int)math.round((float)summarizedConditionEffectsBuffers[16].value * (1f + num));
				healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = -num2,
						bypassMaxDamagePerHit = true
					}
				});
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						effectID = EffectID.FireDamage,
						value1 = num2,
						value2 = ((num > 0f) ? 1 : 0)
					}
				};
				buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
			if (flag || summarizedConditionEffectsBuffers[63].value > 0)
			{
				burningConditionLookup.SetComponentEnabled(entity, value: false);
				ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.Burning);
				EntityUtility.OnBurningRemoved(ref conditionsBuffer, in summarizedConditionsBuffer);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor5 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers = bufferAccessor[i];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor2[i];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor3[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor4[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor5[i];
					Execute(entity, in summarizedConditionEffectsBuffers, in summarizedConditionsBuffer, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, ref conditionTickTimerBuffer, ref conditionsBuffer);
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
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor3[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor4[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor5[nextRangeBegin];
						Execute(entity2, in summarizedConditionEffectsBuffers2, in summarizedConditionsBuffer2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, ref conditionTickTimerBuffer2, ref conditionsBuffer2);
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
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers3 = bufferAccessor[j];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor2[j];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor3[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor4[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor5[j];
					Execute(entity3, in summarizedConditionEffectsBuffers3, in summarizedConditionsBuffer3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, ref conditionTickTimerBuffer3, ref conditionsBuffer3);
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
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers4 = bufferAccessor[k];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor2[k];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor3[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor4[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor5[k];
					Execute(entity4, in summarizedConditionEffectsBuffers4, in summarizedConditionsBuffer4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, ref conditionTickTimerBuffer4, ref conditionsBuffer4);
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
	[WithPresent(new Type[] { typeof(BurningConditionCD) })]
	[WithAll(new Type[] { typeof(SummarizedConditionsBuffer) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct OilCombustJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<OilCombustByConditionsCD> __OilCombustByConditionsCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<RemoveConditionsBuffer> __RemoveConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<NewConditionsBuffer> __NewConditionsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__OilCombustByConditionsCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<OilCombustByConditionsCD>();
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__RemoveConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RemoveConditionsBuffer>();
					__NewConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<NewConditionsBuffer>();
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__OilCombustByConditionsCD_RW_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__RemoveConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__NewConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithPresent<BurningConditionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OilCombustByConditionsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RemoveConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NewConditionsBuffer>();
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
			public void Run(ref OilCombustJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref OilCombustJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref OilCombustJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref OilCombustJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref OilCombustJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref OilCombustJob job, EntityManager entityManager)
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
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public bool isFirstTimeFullyPredictingTick;

		[ReadOnly]
		public ConditionsTableCD conditionsTableCD;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref OilCombustByConditionsCD oilCombustByConditionsCD, ref RandomCD randomCD, ref DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer, ref DynamicBuffer<NewConditionsBuffer> newConditionsBuffer, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers, in LocalTransform localTransform)
		{
			DynamicBuffer<SummarizedConditionsBuffer> dynamicBuffer = summarizedConditionsBufferLookup[entity];
			bool num = dynamicBuffer[336].value > 0;
			bool flag = dynamicBuffer[29].value > 0;
			bool flag2 = num && flag;
			if (oilCombustByConditionsCD.hadOilAndBurning == flag2)
			{
				return;
			}
			oilCombustByConditionsCD.hadOilAndBurning = flag2;
			if (isFirstTimeFullyPredictingTick && flag2)
			{
				int damage = summarizedConditionEffectsBuffers[16].value * 4;
				Entity prefabEntity;
				Entity e = EntityUtility.SpawnExplosion(ecb, localTransform.Position, databaseBankCD.databaseBankBlob, ObjectID.OilCombustExplosion, damage, 0, Entity.Null, 2f, conditionsTableCD, ref randomCD.Value, factionLookup, behaviourTagsLookup, summarizedConditionsBufferLookup, summarizedConditionEffectsBufferLookup, out prefabEntity, ObjectID.None, 0, ExplosionPushbackLevel.None);
				if (summarizedConditionsBufferLookup.HasBuffer(prefabEntity))
				{
					int value = dynamicBuffer[29].value;
					ecb.AppendToBuffer(e, new ConditionsBuffer
					{
						condition = new Condition
						{
							conditionData = new ConditionData
							{
								conditionID = ConditionID.ApplyBurning,
								duration = -1f,
								value = value
							}
						}
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__OilCombustByConditionsCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			BufferAccessor<RemoveConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__RemoveConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<NewConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NewConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref OilCombustByConditionsCD oilCombustByConditionsCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OilCombustByConditionsCD>(nativeArrayPtr2, i);
					ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, i);
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer = bufferAccessor2[i];
					Execute(entity, ref oilCombustByConditionsCD, ref randomCD, ref removeConditionsBuffer, ref newConditionsBuffer, bufferAccessor3[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
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
						ref OilCombustByConditionsCD oilCombustByConditionsCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OilCombustByConditionsCD>(nativeArrayPtr2, nextRangeBegin);
						ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<NewConditionsBuffer> newConditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref oilCombustByConditionsCD2, ref randomCD2, ref removeConditionsBuffer2, ref newConditionsBuffer2, bufferAccessor3[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin));
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
					ref OilCombustByConditionsCD oilCombustByConditionsCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OilCombustByConditionsCD>(nativeArrayPtr2, j);
					ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, j);
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref oilCombustByConditionsCD3, ref randomCD3, ref removeConditionsBuffer3, ref newConditionsBuffer3, bufferAccessor3[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
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
					ref OilCombustByConditionsCD oilCombustByConditionsCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OilCombustByConditionsCD>(nativeArrayPtr2, k);
					ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, k);
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref oilCombustByConditionsCD4, ref randomCD4, ref removeConditionsBuffer4, ref newConditionsBuffer4, bufferAccessor3[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
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
	[WithAll(new Type[] { typeof(PlayerGhost) })]
	[WithAll(new Type[] { typeof(SummarizedConditionsBuffer) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct AmassThenReciprocateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<AmassThenReciprocateCD> __AmassThenReciprocateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__AmassThenReciprocateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AmassThenReciprocateCD>();
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__AmassThenReciprocateCD_RW_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AmassThenReciprocateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
			public void Run(ref AmassThenReciprocateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AmassThenReciprocateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AmassThenReciprocateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AmassThenReciprocateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AmassThenReciprocateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AmassThenReciprocateJob job, EntityManager entityManager)
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
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		[ReadOnly]
		public ConditionsTableCD conditionsTableCD;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref AmassThenReciprocateCD amassThenReciprocateCD, ref RandomCD randomCD, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers, in LocalTransform localTransform, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, in PlayerStateCD playerStateCD)
		{
			if (PlayerController.IsDyingOrDead(playerStateCD))
			{
				return;
			}
			int value = summarizedConditionEffectsBuffers[125].value;
			bool flag = value > 0;
			if (flag)
			{
				amassThenReciprocateCD.damage = value;
			}
			if (amassThenReciprocateCD.isAmassing != flag && isFirstTimeFullyPredictingTick)
			{
				if (!flag && amassThenReciprocateCD.isAmassing)
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							entity = entity,
							effectID = EffectID.AmassingDamage,
							position1 = localTransform.Position
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
				if (!flag && amassThenReciprocateCD.isAmassing)
				{
					EntityUtility.SpawnExplosion(ecb, localTransform.Position, databaseBankCD.databaseBankBlob, ObjectID.VoidFusedExplosion, amassThenReciprocateCD.damage, 0, entity, 5f, conditionsTableCD, ref randomCD.Value, factionLookup, behaviourTagsLookup, summarizedConditionsBufferLookup, summarizedConditionEffectsBufferLookup, out var _);
					amassThenReciprocateCD.damage = 0;
				}
				amassThenReciprocateCD.isAmassing = flag;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AmassThenReciprocateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref AmassThenReciprocateCD amassThenReciprocateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AmassThenReciprocateCD>(nativeArrayPtr2, i);
					ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, i);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers = bufferAccessor[i];
					ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor2[i];
					Execute(entity, ref amassThenReciprocateCD, ref randomCD, in summarizedConditionEffectsBuffers, in localTransform, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, i));
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
						ref AmassThenReciprocateCD amassThenReciprocateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AmassThenReciprocateCD>(nativeArrayPtr2, nextRangeBegin);
						ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers2 = bufferAccessor[nextRangeBegin];
						ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref amassThenReciprocateCD2, ref randomCD2, in summarizedConditionEffectsBuffers2, in localTransform2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref AmassThenReciprocateCD amassThenReciprocateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AmassThenReciprocateCD>(nativeArrayPtr2, j);
					ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, j);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers3 = bufferAccessor[j];
					ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref amassThenReciprocateCD3, ref randomCD3, in summarizedConditionEffectsBuffers3, in localTransform3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, j));
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
					ref AmassThenReciprocateCD amassThenReciprocateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AmassThenReciprocateCD>(nativeArrayPtr2, k);
					ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, k);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffers4 = bufferAccessor[k];
					ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref amassThenReciprocateCD4, ref randomCD4, in summarizedConditionEffectsBuffers4, in localTransform4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr6, k));
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
	[WithAll(new Type[]
	{
		typeof(RadioActiveConditionCD),
		typeof(HealthCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct RadioActiveJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RadioActiveConditionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
			public void Run(ref RadioActiveJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RadioActiveJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RadioActiveJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RadioActiveJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RadioActiveJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RadioActiveJob job, EntityManager entityManager)
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
		public ComponentLookup<HealthCD> entityHealthLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> physicsExcludeLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> physicsColliderLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public ComponentLookup<RadioActiveConditionCD> radioActiveConditionLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public Entity healthChangeBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer)
		{
			ref TickTimer orCreateTickTimer = ref ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AuraRadioactiveDamageOverTime);
			if (!orCreateTickTimer.isRunning)
			{
				orCreateTickTimer.Start(currentTick, 1f, tickRate);
			}
			bool flag = (entityDestroyedLookup.HasComponent(entity) && entityDestroyedLookup.IsComponentEnabled(entity)) || physicsExcludeLookup.HasAndIsComponentEnabled(entity) || !physicsColliderLookup.HasComponent(entity) || !entityHealthLookup.HasComponent(entity);
			if (orCreateTickTimer.IsTimerElapsed(currentTick) && !flag)
			{
				orCreateTickTimer.Start(currentTick, 2f, tickRate);
				int value = summarizedConditionsBuffer[207].value;
				healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = -value,
						bypassMaxDamagePerHit = true
					}
				});
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						effectID = EffectID.FireDamage,
						value1 = value
					}
				};
				buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
			if (flag || summarizedConditionEffectsBuffer[96].value > 0)
			{
				radioActiveConditionLookup.SetComponentEnabled(entity, value: false);
				ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.AuraRadioactiveDamageOverTime);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer = bufferAccessor2[i];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor3[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor4[i];
					Execute(entity, in summarizedConditionsBuffer, in summarizedConditionEffectsBuffer, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, ref conditionTickTimerBuffer);
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
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer2 = bufferAccessor2[nextRangeBegin];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor3[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor4[nextRangeBegin];
						Execute(entity2, in summarizedConditionsBuffer2, in summarizedConditionEffectsBuffer2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, ref conditionTickTimerBuffer2);
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
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer3 = bufferAccessor2[j];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor3[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor4[j];
					Execute(entity3, in summarizedConditionsBuffer3, in summarizedConditionEffectsBuffer3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, ref conditionTickTimerBuffer3);
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
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer4 = bufferAccessor2[k];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor3[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor4[k];
					Execute(entity4, in summarizedConditionsBuffer4, in summarizedConditionEffectsBuffer4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, ref conditionTickTimerBuffer4);
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
	[WithAll(new Type[]
	{
		typeof(AffectedByAcidConditionCD),
		typeof(Simulate),
		typeof(HealthCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct AcidJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AffectedByAcidConditionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
			public void Run(ref AcidJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref AcidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref AcidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref AcidJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref AcidJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref AcidJob job, EntityManager entityManager)
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
		public ComponentLookup<DisablePhysicsCD> physicsExcludeLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> physicsColliderLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public ComponentLookup<AffectedByAcidConditionCD> acidConditionLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public Entity healthChangeBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer)
		{
			ref TickTimer orCreateTickTimer = ref ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AcidDamage);
			if (!orCreateTickTimer.isRunning)
			{
				orCreateTickTimer.Start(currentTick, 0.5f, tickRate);
			}
			bool flag = (entityDestroyedLookup.HasComponent(entity) && entityDestroyedLookup.IsComponentEnabled(entity)) || physicsExcludeLookup.HasAndIsComponentEnabled(entity) || !physicsColliderLookup.HasComponent(entity);
			if (orCreateTickTimer.IsTimerElapsed(currentTick) && !flag)
			{
				orCreateTickTimer.Start(currentTick, 1f, tickRate);
				int value = summarizedConditionEffectsBuffer[14].value;
				healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = -value,
						bypassMaxDamagePerHit = true
					}
				});
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						effectID = EffectID.RedDamageNumber,
						value1 = value,
						value2 = 0
					}
				};
				buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer = bufferAccessor[i];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor2[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor3[i];
					Execute(entity, in summarizedConditionEffectsBuffer, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, ref conditionTickTimerBuffer);
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
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor2[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor3[nextRangeBegin];
						Execute(entity2, in summarizedConditionEffectsBuffer2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, ref conditionTickTimerBuffer2);
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
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer3 = bufferAccessor[j];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor2[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor3[j];
					Execute(entity3, in summarizedConditionEffectsBuffer3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, ref conditionTickTimerBuffer3);
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
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer4 = bufferAccessor[k];
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor2[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor3[k];
					Execute(entity4, in summarizedConditionEffectsBuffer4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, ref conditionTickTimerBuffer4);
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
	[WithAll(new Type[]
	{
		typeof(VoidDamageConditionCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct VoidDamageJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<VoidDamageConditionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
			public void Run(ref VoidDamageJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref VoidDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref VoidDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref VoidDamageJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref VoidDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref VoidDamageJob job, EntityManager entityManager)
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
		public ComponentLookup<DisablePhysicsCD> physicsExcludeLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> physicsColliderLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public ComponentLookup<VoidDamageConditionCD> voidDamageConditionLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public Entity healthChangeBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditions, in HealthCD health, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer)
		{
			ref TickTimer orCreateTickTimer = ref ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.AuraVoidDamagePercentageOverTime);
			if (!orCreateTickTimer.isRunning)
			{
				orCreateTickTimer.Start(currentTick, 0.5f, tickRate);
			}
			bool flag = (entityDestroyedLookup.HasComponent(entity) && entityDestroyedLookup.IsComponentEnabled(entity)) || physicsExcludeLookup.HasAndIsComponentEnabled(entity) || !physicsColliderLookup.HasComponent(entity);
			if (orCreateTickTimer.IsTimerElapsed(currentTick) && !flag)
			{
				orCreateTickTimer.Start(currentTick, 1f, tickRate);
				int num = -(int)math.round((float)summarizedConditionsBuffer[249].value / 100f * (float)health.GetMaxHealthWithConditions(sumConditions));
				healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = -num,
						bypassMaxDamagePerHit = true
					}
				});
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						entity = entity,
						effectID = EffectID.FireDamage,
						value1 = num
					}
				};
				buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditions = bufferAccessor2[i];
					ref HealthCD health = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor3[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr3, i);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor4[i];
					Execute(entity, in summarizedConditionsBuffer, in sumConditions, in health, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, ref conditionTickTimerBuffer);
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
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditions2 = bufferAccessor2[nextRangeBegin];
						ref HealthCD health2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor3[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor4[nextRangeBegin];
						Execute(entity2, in summarizedConditionsBuffer2, in sumConditions2, in health2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, ref conditionTickTimerBuffer2);
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
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditions3 = bufferAccessor2[j];
					ref HealthCD health3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor3[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr3, j);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor4[j];
					Execute(entity3, in summarizedConditionsBuffer3, in sumConditions3, in health3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, ref conditionTickTimerBuffer3);
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
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditions4 = bufferAccessor2[k];
					ref HealthCD health4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor3[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr3, k);
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor4[k];
					Execute(entity4, in summarizedConditionsBuffer4, in sumConditions4, in health4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, ref conditionTickTimerBuffer4);
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
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		public ComponentLookup<MinionCD> __MinionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerRoutineCD> __PlayerRoutineCD_RO_ComponentLookup;

		public ComponentLookup<BurningConditionCD> __BurningConditionCD_RW_ComponentLookup;

		public BurningJob.InternalCompilerQueryAndHandleData __DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		public AmassThenReciprocateJob.InternalCompilerQueryAndHandleData __DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<RadioActiveConditionCD> __RadioActiveConditionCD_RW_ComponentLookup;

		public RadioActiveJob.InternalCompilerQueryAndHandleData __DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<AffectedByAcidConditionCD> __AffectedByAcidConditionCD_RW_ComponentLookup;

		public AcidJob.InternalCompilerQueryAndHandleData __DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<VoidDamageConditionCD> __VoidDamageConditionCD_RW_ComponentLookup;

		public VoidDamageJob.InternalCompilerQueryAndHandleData __DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__Unity_Physics_PhysicsCollider_RO_ComponentLookup = state.GetComponentLookup<PhysicsCollider>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__MinionCD_RW_ComponentLookup = state.GetComponentLookup<MinionCD>();
			__PlayerRoutineCD_RO_ComponentLookup = state.GetComponentLookup<PlayerRoutineCD>(isReadOnly: true);
			__BurningConditionCD_RW_ComponentLookup = state.GetComponentLookup<BurningConditionCD>();
			__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__RadioActiveConditionCD_RW_ComponentLookup = state.GetComponentLookup<RadioActiveConditionCD>();
			__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__AffectedByAcidConditionCD_RW_ComponentLookup = state.GetComponentLookup<AffectedByAcidConditionCD>();
			__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__VoidDamageConditionCD_RW_ComponentLookup = state.GetComponentLookup<VoidDamageConditionCD>();
			__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001335_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001335_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001335_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001336_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001336_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001336_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_401220199_0;

	private EntityQuery __query_401220199_1;

	private EntityQuery __query_401220199_2;

	private EntityQuery __query_401220199_3;

	private EntityQuery __query_401220199_4;

	private EntityQuery __query_401220199_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<HealthChangeBuffer>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<EffectEventBuffer>();
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		ComponentLookup<EntityDestroyedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state);
		ComponentLookup<DisablePhysicsCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state);
		ComponentLookup<PhysicsCollider> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RO_ComponentLookup, ref state);
		ComponentLookup<HealthCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state);
		BufferLookup<HealthChangeBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state);
		__query_401220199_0.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		Entity singletonEntity = __query_401220199_1.GetSingletonEntity();
		uint simulationTickRate = (uint)__query_401220199_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state);
		InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RW_ComponentLookup, ref state);
		InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerRoutineCD_RO_ComponentLookup, ref state);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new BurningJob
		{
			entityDestroyedLookup = componentLookup,
			physicsExcludeLookup = componentLookup2,
			physicsColliderLookup = componentLookup3,
			burningConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BurningConditionCD_RW_ComponentLookup, ref state),
			healthChangeBufferLookup = bufferLookup,
			currentTick = serverTick,
			tickRate = simulationTickRate,
			healthChangeBufferEntity = singletonEntity
		}, __TypeHandle.__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new AmassThenReciprocateJob
		{
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			behaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			summarizedConditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			ecb = __query_401220199_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged),
			databaseBankCD = __query_401220199_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			conditionsTableCD = __query_401220199_5.GetSingleton<ConditionsTableCD>()
		}, __TypeHandle.__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new RadioActiveJob
		{
			entityHealthLookup = componentLookup4,
			entityDestroyedLookup = componentLookup,
			physicsExcludeLookup = componentLookup2,
			physicsColliderLookup = componentLookup3,
			radioActiveConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RadioActiveConditionCD_RW_ComponentLookup, ref state),
			healthChangeBufferLookup = bufferLookup,
			currentTick = serverTick,
			tickRate = simulationTickRate,
			healthChangeBufferEntity = singletonEntity
		}, __TypeHandle.__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new AcidJob
		{
			entityDestroyedLookup = componentLookup,
			physicsExcludeLookup = componentLookup2,
			physicsColliderLookup = componentLookup3,
			acidConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectedByAcidConditionCD_RW_ComponentLookup, ref state),
			healthChangeBufferLookup = bufferLookup,
			currentTick = serverTick,
			tickRate = simulationTickRate,
			healthChangeBufferEntity = singletonEntity
		}, __TypeHandle.__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new VoidDamageJob
		{
			entityDestroyedLookup = componentLookup,
			physicsExcludeLookup = componentLookup2,
			physicsColliderLookup = componentLookup3,
			voidDamageConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VoidDamageConditionCD_RW_ComponentLookup, ref state),
			healthChangeBufferLookup = bufferLookup,
			currentTick = serverTick,
			tickRate = simulationTickRate,
			healthChangeBufferEntity = singletonEntity
		}, __TypeHandle.__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(BurningJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DealDamageFromConditionSystem_BurningJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(AmassThenReciprocateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DealDamageFromConditionSystem_AmassThenReciprocateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(RadioActiveJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DealDamageFromConditionSystem_RadioActiveJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(AcidJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DealDamageFromConditionSystem_AcidJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(VoidDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DealDamageFromConditionSystem_VoidDamageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_401220199_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001335_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001336_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((DealDamageFromConditionSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((DealDamageFromConditionSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DealDamageFromConditionSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DealDamageFromConditionSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DealDamageFromConditionSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
