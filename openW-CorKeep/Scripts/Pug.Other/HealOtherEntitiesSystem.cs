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
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(UpdateHealthSystemGroup))]
[UpdateBefore(typeof(UpdateHealthFromBufferSystem))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct HealOtherEntitiesSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct HealNearbyEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealNearbyEntitiesCD> __HealNearbyEntitiesCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HealNearbyEntitiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealNearbyEntitiesCD>(isReadOnly: true);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HealNearbyEntitiesCD_RO_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealNearbyEntitiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<NearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
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
			public void Run(ref HealNearbyEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HealNearbyEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HealNearbyEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HealNearbyEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HealNearbyEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HealNearbyEntitiesJob job, EntityManager entityManager)
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

		public BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> isBeingHealedByOtherEntitiesBufferLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in HealNearbyEntitiesCD healNearby, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities, in LocalTransform transform)
		{
			if (!healNearby.isActive)
			{
				return;
			}
			for (int i = 0; i < nearbyEntities.Length; i++)
			{
				Entity entity2 = nearbyEntities[i].entity;
				if (!isBeingHealedByOtherEntitiesBufferLookup.HasComponent(entity2))
				{
					continue;
				}
				factionLookup.TryGetComponent(entity2, out var componentData);
				FactionID faction = componentData.faction;
				if (healNearby.healsTargetsOfFaction != faction || !localTransformLookup.TryGetComponent(entity2, out var componentData2) || math.distance(componentData2.Position, transform.Position) > healNearby.radius)
				{
					continue;
				}
				DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> dynamicBuffer = isBeingHealedByOtherEntitiesBufferLookup[entity2];
				bool flag = false;
				for (int j = 0; j < dynamicBuffer.Length; j++)
				{
					if (dynamicBuffer[j].entityHealing == entity)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					dynamicBuffer.Add(new IsBeingBeHealedByOtherEntitiesBuffer
					{
						entityHealing = entity,
						amountPerSecond = healNearby.healthPerSecond
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealNearbyEntitiesCD_RO_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealNearbyEntitiesCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealNearbyEntitiesCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealNearbyEntitiesCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealNearbyEntitiesCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
		typeof(LocalTransform),
		typeof(Simulate)
	})]
	private struct ReceiveHealthPerSecondFromOtherJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<IsBeingBeHealedByOtherEntitiesCD> __IsBeingBeHealedByOtherEntitiesCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<IsBeingBeHealedByOtherEntitiesBuffer> __IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__IsBeingBeHealedByOtherEntitiesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<IsBeingBeHealedByOtherEntitiesCD>();
					__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<IsBeingBeHealedByOtherEntitiesBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__IsBeingBeHealedByOtherEntitiesCD_RW_ComponentTypeHandle.Update(ref state);
					__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<IsBeingBeHealedByOtherEntitiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<IsBeingBeHealedByOtherEntitiesBuffer>();
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
			public void Run(ref ReceiveHealthPerSecondFromOtherJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ReceiveHealthPerSecondFromOtherJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ReceiveHealthPerSecondFromOtherJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ReceiveHealthPerSecondFromOtherJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ReceiveHealthPerSecondFromOtherJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ReceiveHealthPerSecondFromOtherJob job, EntityManager entityManager)
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

		private const float defaultHealRange = 20f;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<HealNearbyEntitiesCD> healNearbyEntitiesLookup;

		[ReadOnly]
		public BufferLookup<EntitiesHealedBuffer> entitiesHealedBufferLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		public Entity healthChangeBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref IsBeingBeHealedByOtherEntitiesCD healedByEntitiesCD, ref DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> healedByEntitiesBuffer)
		{
			if (healedByEntitiesCD.timer.isRunning && !healedByEntitiesCD.timer.IsTimerElapsed(currentTick))
			{
				healedByEntitiesCD.isBeingHealed = healedByEntitiesBuffer.Length > 0;
				return;
			}
			LocalTransform localTransform = localTransformLookup[entity];
			healedByEntitiesCD.timer.Start(currentTick, 1f, tickRate);
			int num = 0;
			for (int num2 = healedByEntitiesBuffer.Length - 1; num2 >= 0; num2--)
			{
				Entity entityHealing = healedByEntitiesBuffer[num2].entityHealing;
				bool flag = false;
				if (entityHealing != Entity.Null && !entityDestroyedLookup.HasAndIsComponentEnabled(entityHealing) && localTransformLookup.TryGetComponent(entityHealing, out var componentData))
				{
					float num3 = math.distance(componentData.Position, localTransform.Position);
					HealNearbyEntitiesCD componentData2;
					float num4 = (healNearbyEntitiesLookup.TryGetComponent(entityHealing, out componentData2) ? componentData2.radius : 20f);
					bool flag2 = num3 <= num4;
					bool flag3 = true;
					if (entitiesHealedBufferLookup.TryGetBuffer(entityHealing, out var bufferData))
					{
						flag3 = false;
						for (int i = 0; i < bufferData.Length; i++)
						{
							if (bufferData[i].entity == entity)
							{
								flag3 = true;
								break;
							}
						}
					}
					if (flag2 && flag3)
					{
						flag = true;
						num += healedByEntitiesBuffer[num2].amountPerSecond;
					}
				}
				if (!flag)
				{
					healedByEntitiesBuffer.RemoveAtSwapBack(num2);
				}
			}
			if (num > 0)
			{
				healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entity,
						amount = num,
						causedByEntity = entity
					}
				});
			}
			healedByEntitiesCD.isBeingHealed = healedByEntitiesBuffer.Length > 0;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__IsBeingBeHealedByOtherEntitiesCD_RW_ComponentTypeHandle);
			BufferAccessor<IsBeingBeHealedByOtherEntitiesBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref IsBeingBeHealedByOtherEntitiesCD healedByEntitiesCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsBeingBeHealedByOtherEntitiesCD>(nativeArrayPtr2, i);
					DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> healedByEntitiesBuffer = bufferAccessor[i];
					Execute(entity, ref healedByEntitiesCD, ref healedByEntitiesBuffer);
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
						ref IsBeingBeHealedByOtherEntitiesCD healedByEntitiesCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsBeingBeHealedByOtherEntitiesCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> healedByEntitiesBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref healedByEntitiesCD2, ref healedByEntitiesBuffer2);
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
					ref IsBeingBeHealedByOtherEntitiesCD healedByEntitiesCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsBeingBeHealedByOtherEntitiesCD>(nativeArrayPtr2, j);
					DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> healedByEntitiesBuffer3 = bufferAccessor[j];
					Execute(entity3, ref healedByEntitiesCD3, ref healedByEntitiesBuffer3);
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
					ref IsBeingBeHealedByOtherEntitiesCD healedByEntitiesCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsBeingBeHealedByOtherEntitiesCD>(nativeArrayPtr2, k);
					DynamicBuffer<IsBeingBeHealedByOtherEntitiesBuffer> healedByEntitiesBuffer4 = bufferAccessor[k];
					Execute(entity4, ref healedByEntitiesCD4, ref healedByEntitiesBuffer4);
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
		public BufferLookup<IsBeingBeHealedByOtherEntitiesBuffer> __IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		public HealNearbyEntitiesJob.InternalCompilerQueryAndHandleData __HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<EntitiesHealedBuffer> __EntitiesHealedBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<HealNearbyEntitiesCD> __HealNearbyEntitiesCD_RO_ComponentLookup;

		public ReceiveHealthPerSecondFromOtherJob.InternalCompilerQueryAndHandleData __HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup = state.GetBufferLookup<IsBeingBeHealedByOtherEntitiesBuffer>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__EntitiesHealedBuffer_RO_BufferLookup = state.GetBufferLookup<EntitiesHealedBuffer>(isReadOnly: true);
			__HealNearbyEntitiesCD_RO_ComponentLookup = state.GetComponentLookup<HealNearbyEntitiesCD>(isReadOnly: true);
			__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000204E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000204E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000204E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000204F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000204F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000204F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_726050215_0;

	private EntityQuery __query_726050215_1;

	private EntityQuery __query_726050215_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<HealthChangeBuffer>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Dependency = __ScheduleViaJobChunkExtension_0(new HealNearbyEntitiesJob
		{
			isBeingHealedByOtherEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__IsBeingBeHealedByOtherEntitiesBuffer_RW_BufferLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state)
		}, __TypeHandle.__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		__query_726050215_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new ReceiveHealthPerSecondFromOtherJob
		{
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			healthChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state),
			healthChangeBufferEntity = __query_726050215_1.GetSingletonEntity(),
			entitiesHealedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__EntitiesHealedBuffer_RO_BufferLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			healNearbyEntitiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealNearbyEntitiesCD_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			tickRate = (uint)__query_726050215_2.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(HealNearbyEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HealOtherEntitiesSystem_HealNearbyEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(ReceiveHealthPerSecondFromOtherJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HealOtherEntitiesSystem_ReceiveHealthPerSecondFromOtherJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_726050215_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_726050215_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_726050215_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000204E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000204F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((HealOtherEntitiesSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HealOtherEntitiesSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HealOtherEntitiesSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
