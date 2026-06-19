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
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct FishingNetVisualUpdateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithChangeFilter(new Type[] { typeof(ContainedObjectsBuffer) })]
	[WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
	private struct FishingNetVisualUpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<FishingNetSlotVisualBuffer> __FishingNetSlotVisualBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<FishingNetVisualCD> __FishingNetVisualCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__FishingNetSlotVisualBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<FishingNetSlotVisualBuffer>();
					__FishingNetVisualCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<FishingNetVisualCD>();
					__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__FishingNetSlotVisualBuffer_RW_BufferTypeHandle.Update(ref state);
					__FishingNetVisualCD_RW_ComponentTypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetSlotVisualBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetVisualCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(ContainedObjectsBuffer))
				});
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
			public void Run(ref FishingNetVisualUpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FishingNetVisualUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FishingNetVisualUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FishingNetVisualUpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FishingNetVisualUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FishingNetVisualUpdateJob job, EntityManager entityManager)
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
		public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer, EnabledRefRW<FishingNetVisualCD> fishingNetVisualEnabled, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer)
		{
			bool flag = false;
			for (int i = 0; i < containedObjectsBuffer.Length; i++)
			{
				CheckHasFishOrBait(containedObjectsBuffer[i], out var hasFish, out var hasBait);
				fishingNetSlotVisualBuffer.ElementAt(i).hasFish = hasFish;
				fishingNetSlotVisualBuffer.ElementAt(i).hasBait = hasBait;
				flag = flag || hasFish;
			}
			if (fishingNetVisualEnabled.ValueRO != flag)
			{
				fishingNetVisualEnabled.ValueRW = flag;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CheckHasFishOrBait(in ContainedObjectsBuffer containedObject, out bool hasFish, out bool hasBait)
		{
			hasFish = false;
			hasBait = false;
			if (containedObject.objectID != ObjectID.None)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObject.objectID, databaseBankCD.databaseBankBlob, containedObject.variation);
				if (!(primaryPrefabEntity == Entity.Null) && objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
				{
					hasFish = ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.Fish);
					hasBait = !hasFish;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<FishingNetSlotVisualBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__FishingNetSlotVisualBuffer_RW_BufferTypeHandle);
			EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__FishingNetVisualCD_RW_ComponentTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer = bufferAccessor[i];
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = bufferAccessor2[i];
					Execute(ref fishingNetSlotVisualBuffer, enabledMask.GetEnabledRefRW<FishingNetVisualCD>(i), in containedObjectsBuffer);
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
						DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(ref fishingNetSlotVisualBuffer2, enabledMask.GetEnabledRefRW<FishingNetVisualCD>(nextRangeBegin), in containedObjectsBuffer2);
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
					DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer3 = bufferAccessor[j];
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer3 = bufferAccessor2[j];
					Execute(ref fishingNetSlotVisualBuffer3, enabledMask.GetEnabledRefRW<FishingNetVisualCD>(j), in containedObjectsBuffer3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer4 = bufferAccessor[k];
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer4 = bufferAccessor2[k];
					Execute(ref fishingNetSlotVisualBuffer4, enabledMask.GetEnabledRefRW<FishingNetVisualCD>(k), in containedObjectsBuffer4);
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
	private struct FishingNetVisualPlayEffectUpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<FishingNetVisualCD> __FishingNetVisualCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<FishingNetSlotVisualBuffer> __FishingNetSlotVisualBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__FishingNetVisualCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<FishingNetVisualCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__FishingNetSlotVisualBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<FishingNetSlotVisualBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__FishingNetVisualCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__FishingNetSlotVisualBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<FishingNetSlotVisualBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetVisualCD>();
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
			public void Run(ref FishingNetVisualPlayEffectUpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FishingNetVisualPlayEffectUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FishingNetVisualPlayEffectUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FishingNetVisualPlayEffectUpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FishingNetVisualPlayEffectUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FishingNetVisualPlayEffectUpdateJob job, EntityManager entityManager)
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

		public BufferLookup<EffectEventBuffer> effectEventBufferLookup;

		public Entity effectEventBufferEntity;

		public NativeList<int> cachedSplashSlots;

		public double elapsedTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref FishingNetVisualCD fishingNetVisualCD, in LocalTransform localTransform, in DynamicBuffer<FishingNetSlotVisualBuffer> fishingNetSlotVisualBuffer)
		{
			if (elapsedTime < (double)fishingNetVisualCD.nextSplashTime)
			{
				return;
			}
			Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)math.round(elapsedTime * 1000000.0) ^ (uint)entity.Index ^ (uint)entity.Version);
			cachedSplashSlots.Clear();
			for (int i = 0; i < fishingNetSlotVisualBuffer.Length; i++)
			{
				if (fishingNetSlotVisualBuffer[i].hasFish)
				{
					cachedSplashSlots.Add(in i);
				}
			}
			if (cachedSplashSlots.Length != 0)
			{
				int index = random.NextInt(0, cachedSplashSlots.Length);
				FishingNetSlotVisualBuffer fishingNetSlotVisualBuffer2 = fishingNetSlotVisualBuffer[cachedSplashSlots[index]];
				effectEventBufferLookup[effectEventBufferEntity].Add(new EffectEventBuffer
				{
					Value = new EffectEventCD
					{
						effectID = (random.NextBool() ? EffectID.WaterSplash : EffectID.SmallWaterSplash),
						position1 = localTransform.Position + fishingNetSlotVisualBuffer2.visualOffset.ToFloat3()
					}
				});
			}
			ref FishingNetTimerData value = ref fishingNetVisualCD.fishingNetTimerData.Value;
			float2 float5 = math.lerp(value.minMaxSplashTimerSingle, value.minMaxSplashTimerFull, (float)(cachedSplashSlots.Length - 1) / (float)(fishingNetSlotVisualBuffer.Length - 1));
			fishingNetVisualCD.nextSplashTime = (float)elapsedTime + random.NextFloat(float5.x, float5.y);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__FishingNetVisualCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<FishingNetSlotVisualBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__FishingNetSlotVisualBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), bufferAccessor[i]);
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), bufferAccessor[j]);
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), bufferAccessor[k]);
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
	private struct FishingNetCheckForLavaJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<FishingNetInitCheckForLavaCD> __FishingNetInitCheckForLavaCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<FishingNetVisualCD> __FishingNetVisualCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__FishingNetInitCheckForLavaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<FishingNetInitCheckForLavaCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__FishingNetVisualCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<FishingNetVisualCD>();
				}

				public void Update(ref SystemState state)
				{
					__FishingNetInitCheckForLavaCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__FishingNetVisualCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetInitCheckForLavaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetVisualCD>();
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
			public void Run(ref FishingNetCheckForLavaJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FishingNetCheckForLavaJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FishingNetCheckForLavaJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FishingNetCheckForLavaJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FishingNetCheckForLavaJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FishingNetCheckForLavaJob job, EntityManager entityManager)
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

		public TileAccessor tileAccessor;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(EnabledRefRW<FishingNetInitCheckForLavaCD> fishingNetInitCheckForLavaEnabled, in LocalTransform localTransform, ref FishingNetVisualCD fishingNetVisualCD)
		{
			TileCD top = tileAccessor.GetTop(localTransform.Position.RoundToInt2());
			if (top.tileType != TileAccessor.DefaultTile.tileType || top.tileset != TileAccessor.DefaultTile.tileset)
			{
				fishingNetInitCheckForLavaEnabled.ValueRW = false;
				fishingNetVisualCD.isInLava = top.tileType == TileType.water && top.tileset == 3;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__FishingNetInitCheckForLavaCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__FishingNetVisualCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i);
					ref FishingNetVisualCD fishingNetVisualCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, i);
					Execute(enabledMask.GetEnabledRefRW<FishingNetInitCheckForLavaCD>(i), in localTransform, ref fishingNetVisualCD);
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
						ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin);
						ref FishingNetVisualCD fishingNetVisualCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, nextRangeBegin);
						Execute(enabledMask.GetEnabledRefRW<FishingNetInitCheckForLavaCD>(nextRangeBegin), in localTransform2, ref fishingNetVisualCD2);
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
					ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j);
					ref FishingNetVisualCD fishingNetVisualCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, j);
					Execute(enabledMask.GetEnabledRefRW<FishingNetInitCheckForLavaCD>(j), in localTransform3, ref fishingNetVisualCD3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k);
					ref FishingNetVisualCD fishingNetVisualCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FishingNetVisualCD>(nativeArrayPtr2, k);
					Execute(enabledMask.GetEnabledRefRW<FishingNetInitCheckForLavaCD>(k), in localTransform4, ref fishingNetVisualCD4);
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
		public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

		public FishingNetVisualUpdateJob.InternalCompilerQueryAndHandleData __FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		public BufferLookup<EffectEventBuffer> __EffectEventBuffer_RW_BufferLookup;

		public FishingNetVisualPlayEffectUpdateJob.InternalCompilerQueryAndHandleData __FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		public FishingNetCheckForLavaJob.InternalCompilerQueryAndHandleData __FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<EffectEventBuffer>();
			__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001F12_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001F12_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001F12_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001F13_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001F13_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001F13_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00001F14_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00001F14_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00001F14_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2021340702_0;

	private EntityQuery __query_2021340702_1;

	private EntityQuery __query_2021340702_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
	}

	[BurstCompile]
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
		state.Dependency = __ScheduleViaJobChunkExtension_0(new FishingNetVisualUpdateJob
		{
			objectCategoryTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
			databaseBankCD = __query_2021340702_1.GetSingleton<PugDatabase.DatabaseBankCD>()
		}, __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new FishingNetVisualPlayEffectUpdateJob
		{
			effectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__EffectEventBuffer_RW_BufferLookup, ref state),
			effectEventBufferEntity = __query_2021340702_2.GetSingletonEntity(),
			cachedSplashSlots = new NativeList<int>(4, state.WorldUpdateAllocator),
			elapsedTime = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new FishingNetCheckForLavaJob
		{
			tileAccessor = _tileAccessor
		}, __query_2021340702_0, state.Dependency, ref state, hasUserDefinedQuery: true);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(FishingNetVisualUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(FishingNetVisualPlayEffectUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetVisualPlayEffectUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(FishingNetCheckForLavaJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__FishingNetVisualUpdateSystem_FishingNetCheckForLavaJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<FishingNetInitCheckForLavaCD, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithPresent<FishingNetVisualCD>();
		__query_2021340702_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2021340702_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2021340702_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001F12_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001F13_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00001F14_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((FishingNetVisualUpdateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((FishingNetVisualUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((FishingNetVisualUpdateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((FishingNetVisualUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((FishingNetVisualUpdateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
