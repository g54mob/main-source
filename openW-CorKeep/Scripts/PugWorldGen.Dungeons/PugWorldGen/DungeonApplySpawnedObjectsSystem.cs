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
using Unity.Physics;
using Unity.Transforms;

namespace PugWorldGen
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonGenerateRoomsSystem))]
	public struct DungeonApplySpawnedObjectsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Trigger : IComponentData, IQueryTypeParameter
		{
		}

		[BurstCompile]
		internal struct ReplaceObjectsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<DungeonReplaceObjectsBuffer> __PugWorldGen_DungeonReplaceObjectsBuffer_RO_BufferTypeHandle;

					public BufferTypeHandle<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
						__PugWorldGen_DungeonReplaceObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonReplaceObjectsBuffer>(isReadOnly: true);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonSpawnedObjectBuffer>();
					}

					public void Update(ref SystemState state)
					{
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref state);
						__PugWorldGen_DungeonReplaceObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonReplaceObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonSpawnedObjectBuffer>();
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
				public void Run(ref ReplaceObjectsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ReplaceObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ReplaceObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ReplaceObjectsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ReplaceObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ReplaceObjectsJob job, EntityManager entityManager)
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

			private const uint RNG_SEED = 3448135836u;

			public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in DungeonAreaCD dungeon, in DynamicBuffer<DungeonReplaceObjectsBuffer> replacementRules, ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects)
			{
				Unity.Mathematics.Random rng = new Unity.Mathematics.Random(dungeon.seed ^ 0xCD86609Cu);
				foreach (DungeonReplaceObjectsBuffer replacementRule in replacementRules)
				{
					int randomIndex = GetRandomIndex(ref rng, replacementRule.accumulatedVariationProbability);
					BlobAssetReference<BlobArray<int>> replaceWithVariations = replacementRule.replaceWithVariations;
					int variation = replaceWithVariations.Value[randomIndex];
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(replacementRule.replaceWithID, Database, variation);
					for (int i = 0; i < spawnObjects.Length; i++)
					{
						ref DungeonSpawnedObjectBuffer reference = ref spawnObjects.ElementAt(i);
						if (Matches(reference.objectData, replacementRule))
						{
							reference.objectData.objectID = replacementRule.replaceWithID;
							reference.objectData.variation = variation;
							if (reference.prefabEntity != Entity.Null)
							{
								reference.prefabEntity = primaryPrefabEntity;
							}
						}
					}
				}
			}

			private bool Matches(ObjectData objectData, DungeonReplaceObjectsBuffer replacementRule)
			{
				if (objectData.objectID != replacementRule.replaceID)
				{
					return false;
				}
				if (replacementRule.replaceVariation.hasValue && objectData.variation != replacementRule.replaceVariation.value)
				{
					return false;
				}
				return true;
			}

			private static int GetRandomIndex(ref Unity.Mathematics.Random rng, BlobAssetReference<BlobArray<float>> normalizedWeights)
			{
				ref BlobArray<float> value = ref normalizedWeights.Value;
				float num = rng.NextFloat();
				for (int i = 0; i < normalizedWeights.Value.Length; i++)
				{
					if (num < value[i])
					{
						return i;
					}
				}
				return normalizedWeights.Value.Length - 1;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle);
				BufferAccessor<DungeonReplaceObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonReplaceObjectsBuffer_RO_BufferTypeHandle);
				BufferAccessor<DungeonSpawnedObjectBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ref DungeonAreaCD dungeon = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, i);
						DynamicBuffer<DungeonReplaceObjectsBuffer> replacementRules = bufferAccessor[i];
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects = bufferAccessor2[i];
						Execute(in dungeon, in replacementRules, ref spawnObjects);
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
							ref DungeonAreaCD dungeon2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, nextRangeBegin);
							DynamicBuffer<DungeonReplaceObjectsBuffer> replacementRules2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects2 = bufferAccessor2[nextRangeBegin];
							Execute(in dungeon2, in replacementRules2, ref spawnObjects2);
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
						ref DungeonAreaCD dungeon3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, j);
						DynamicBuffer<DungeonReplaceObjectsBuffer> replacementRules3 = bufferAccessor[j];
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects3 = bufferAccessor2[j];
						Execute(in dungeon3, in replacementRules3, ref spawnObjects3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ref DungeonAreaCD dungeon4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, k);
						DynamicBuffer<DungeonReplaceObjectsBuffer> replacementRules4 = bufferAccessor[k];
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects4 = bufferAccessor2[k];
						Execute(in dungeon4, in replacementRules4, ref spawnObjects4);
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
		internal struct RemoveNullObjectsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public BufferTypeHandle<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonSpawnedObjectBuffer>();
					}

					public void Update(ref SystemState state)
					{
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<DungeonSpawnedObjectBuffer>().Build(ref state);
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
				public void Run(ref RemoveNullObjectsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RemoveNullObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RemoveNullObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RemoveNullObjectsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RemoveNullObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RemoveNullObjectsJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects)
			{
				for (int num = spawnObjects.Length - 1; num >= 0; num--)
				{
					if (spawnObjects[num].objectData.objectID == ObjectID.None)
					{
						spawnObjects.RemoveAtSwapBack(num);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				BufferAccessor<DungeonSpawnedObjectBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects = bufferAccessor[i];
						Execute(ref spawnObjects);
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
							DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects2 = bufferAccessor[nextRangeBegin];
							Execute(ref spawnObjects2);
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
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects3 = bufferAccessor[j];
						Execute(ref spawnObjects3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects4 = bufferAccessor[k];
						Execute(ref spawnObjects4);
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
		private struct InitializeSubMapsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public BufferTypeHandle<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonSpawnedObjectBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAll<DungeonSpawnedObjectBuffer>().Build(ref state);
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
				public void Run(ref InitializeSubMapsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref InitializeSubMapsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref InitializeSubMapsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref InitializeSubMapsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref InitializeSubMapsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref InitializeSubMapsJob job, EntityManager entityManager)
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

			public EntityCommandBuffer Ecb;

			public Entity TileUpdateBufferSingleton;

			[ReadOnly]
			public TileAccessor TileAccessor;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in DynamicBuffer<DungeonSpawnedObjectBuffer> spawnObjects)
			{
				foreach (DungeonSpawnedObjectBuffer spawnObject in spawnObjects)
				{
					if (!TileAccessor.IsInitialized(spawnObject.position))
					{
						Ecb.AppendToBuffer(TileUpdateBufferSingleton, new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Add,
							position = spawnObject.position
						});
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				BufferAccessor<DungeonSpawnedObjectBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(bufferAccessor[i]);
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
							Execute(bufferAccessor[nextRangeBegin]);
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
						Execute(bufferAccessor[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(bufferAccessor[k]);
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
		private struct EnableAreaJob : IJobEntity, IJobChunk
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
					public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonAreaCD>();
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
				public void Run(ref EnableAreaJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref EnableAreaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref EnableAreaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref EnableAreaJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref EnableAreaJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref EnableAreaJob job, EntityManager entityManager)
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

			public EntityCommandBuffer Ecb;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in LocalTransform transform, in DungeonAreaCD dungeon)
			{
				Ecb.AddComponent(entity, new EnableEntitiesInCircleCD
				{
					Center = transform.Position.ToFloat2(),
					Radius = dungeon.placementRadius + 8
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, k));
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
		private struct ClearAreaJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonSpawnedObjectBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref state);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonSpawnedObjectBuffer>();
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
				public void Run(ref ClearAreaJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ClearAreaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ClearAreaJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ClearAreaJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ClearAreaJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ClearAreaJob job, EntityManager entityManager)
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

			public EntityCommandBuffer Ecb;

			public TileAccessor TileAccessor;

			[ReadOnly]
			public ComponentLookup<LocalTransform> TransformLookup;

			[ReadOnly]
			public CollisionWorld CollisionWorld;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in DungeonAreaCD dungeon, in DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects)
			{
				NativeList<int2> list = new NativeList<int2>(dungeonObjects.Length, Allocator.Temp);
				foreach (DungeonSpawnedObjectBuffer dungeonObject in dungeonObjects)
				{
					DungeonSpawnedObjectBuffer current = dungeonObject;
					list.Add(in current.position);
					TileAccessor.Clear(current.position);
				}
				float3 position = TransformLookup[entity].Position;
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131921u
				};
				int num = dungeon.placementRadius + 8;
				NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(1000, Allocator.Temp);
				if (!CollisionWorld.OverlapSphere(position, num, ref outHits, filter))
				{
					return;
				}
				foreach (DistanceHit item in outHits)
				{
					int2 value = TransformLookup[item.Entity].Position.RoundToInt2();
					if (list.Contains(value))
					{
						Ecb.DestroyEntity(item.Entity);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle);
				BufferAccessor<DungeonSpawnedObjectBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, i), bufferAccessor[i]);
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, j), bufferAccessor[j]);
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, k), bufferAccessor[k]);
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
		private struct SpawnObjectsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

					public BufferTypeHandle<DungeonSpawnedObjectBuffer> __PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonSpawnedObjectBuffer>();
					}

					public void Update(ref SystemState state)
					{
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref state);
						__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonSpawnedObjectBuffer>();
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
				public void Run(ref SpawnObjectsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SpawnObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SpawnObjectsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SpawnObjectsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SpawnObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SpawnObjectsJob job, EntityManager entityManager)
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

			public EntityCommandBuffer Ecb;

			public TileAccessor TileAccessor;

			public EntityArchetype WaterSpreadingArchetype;

			public BlobAssetReference<CustomSceneTableBlob> CustomSceneTable;

			public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

			public BlobAssetReference<LootTableBankBlob> LootBank;

			public CustomScenePrefabUtility.Lookups CustomSceneLookups;

			public CustomScenePrefabUtility.Data CustomSceneData;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> ContainedBufferLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> TileLookup;

			[ReadOnly]
			public BiomeLookup BiomeLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in DungeonAreaCD dungeon, ref DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects)
			{
				Unity.Mathematics.Random rand = new Unity.Mathematics.Random(dungeon.seed ^ 0xA74A613Bu);
				foreach (DungeonSpawnedObjectBuffer dungeonObject in dungeonObjects)
				{
					ObjectData objectData = dungeonObject.objectData;
					if (dungeonObject.prefabEntity != Entity.Null)
					{
						Entity entity = Ecb.Instantiate(dungeonObject.prefabEntity);
						Ecb.SetComponent(entity, LocalTransform.FromPosition(dungeonObject.prefabEntityPosition.ToFloat3()));
						Ecb.SetComponent(entity, new ObjectDataCD
						{
							objectID = objectData.objectID,
							amount = objectData.amount,
							variation = objectData.variation
						});
						Ecb.AddComponent<CustomSceneObjectCD>(entity);
						if (dungeonObject.optionalSceneIndex > -1 && dungeonObject.optionalScenePrefabIndex > -1)
						{
							CustomScenePrefabUtility.ApplyOverrides(Ecb, entity, dungeonObject.optionalScenePrefabIndex, ref CustomSceneTable.Value.scenes[dungeonObject.optionalSceneIndex], CustomSceneLookups, CustomSceneData);
						}
						continue;
					}
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, Database, objectData.variation);
					if (entityObjectInfo.prefabEntities.Length > 0 && !TileLookup.HasComponent(entityObjectInfo.prefabEntities[0]))
					{
						Biome biome = BiomeLookup.GetBiome(dungeonObject.position);
						EntityUtility.CreateEntityWithLoot(Ecb, dungeonObject.position.ToFloat3(), objectData.objectID, objectData.amount, dungeonObject.loot, ref rand, Database, LootBank, ContainedBufferLookup, biome, objectData.variation);
					}
					else if (entityObjectInfo.tileType != TileType.none)
					{
						TileAccessor.Set(dungeonObject.position, new TileCD
						{
							tileset = entityObjectInfo.tileset,
							tileType = entityObjectInfo.tileType
						});
						if (entityObjectInfo.tileType == TileType.water)
						{
							Entity e = Ecb.CreateEntity(WaterSpreadingArchetype);
							Ecb.SetComponent(e, new WaterSpreaderCD
							{
								position = dungeonObject.position
							});
						}
					}
				}
				dungeonObjects.Clear();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle);
				BufferAccessor<DungeonSpawnedObjectBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonSpawnedObjectBuffer_RW_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ref DungeonAreaCD dungeon = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, i);
						DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects = bufferAccessor[i];
						Execute(in dungeon, ref dungeonObjects);
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
							ref DungeonAreaCD dungeon2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, nextRangeBegin);
							DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects2 = bufferAccessor[nextRangeBegin];
							Execute(in dungeon2, ref dungeonObjects2);
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
						ref DungeonAreaCD dungeon3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, j);
						DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects3 = bufferAccessor[j];
						Execute(in dungeon3, ref dungeonObjects3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ref DungeonAreaCD dungeon4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, k);
						DynamicBuffer<DungeonSpawnedObjectBuffer> dungeonObjects4 = bufferAccessor[k];
						Execute(in dungeon4, ref dungeonObjects4);
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
			public ReplaceObjectsJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public RemoveNullObjectsJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public InitializeSubMapsJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public EnableAreaJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			public ClearAreaJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

			public SpawnObjectsJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
				__PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000002B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000002B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000002B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_0000002C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_0000002C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000002C_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
		internal delegate void __codegen__OnStartRunning_0000002D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_0000002D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000002D_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
		internal delegate void __codegen__OnStopRunning_0000002E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_0000002E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000002E_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

		private const uint SYSTEM_SEED = 2806669627u;

		private const int ENABLE_AREA_PADDING = 8;

		private bool _hasLazyInitialized;

		private EntityArchetype _waterSpreadingArchetype;

		private BiomeLookup _biomeLookup;

		private TileAccessor _tileAccessor;

		private CustomScenePrefabUtility.Lookups _customSceneLookups;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_548494060_0;

		private EntityQuery __query_548494060_1;

		private EntityQuery __query_548494060_2;

		private EntityQuery __query_548494060_3;

		private EntityQuery __query_548494060_4;

		private EntityQuery __query_548494060_5;

		private EntityQuery __query_548494060_6;

		private EntityQuery __query_548494060_7;

		private EntityQuery __query_548494060_8;

		private EntityQuery __query_548494060_9;

		private EntityQuery __query_548494060_10;

		private EntityQuery __query_548494060_11;

		private EntityQuery __query_548494060_12;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<TileUpdateBuffer>();
			state.RequireForUpdate<SubMapRegistry>();
			state.RequireForUpdate(__query_548494060_0);
			state.RequireForUpdate<ActivatedContentBundlesBuffer>();
			state.RequireForUpdate<DungeonAreaCD>();
			_waterSpreadingArchetype = state.EntityManager.CreateArchetype(typeof(WaterSpreaderCD));
			_customSceneLookups = new CustomScenePrefabUtility.Lookups(ref state);
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			if (!_hasLazyInitialized)
			{
				_hasLazyInitialized = true;
				_biomeLookup = (__query_548494060_4.HasSingleton<BiomeSamplesCD>() ? new BiomeLookup(__query_548494060_4.GetSingleton<BiomeSamplesCD>()) : new BiomeLookup(__query_548494060_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
				_tileAccessor = new TileAccessor(ref state, isReadOnly: false);
			}
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
			if (_hasLazyInitialized)
			{
				_biomeLookup.Dispose();
			}
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			EntityCommandBuffer ecb = __query_548494060_6.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			_tileAccessor.Update(ref state);
			_customSceneLookups.Update(ref state);
			EntityQuery _query_548494060_ = __query_548494060_1;
			EntityQuery _query_548494060_2 = __query_548494060_2;
			EntityQuery _query_548494060_3 = __query_548494060_3;
			ecb.DestroyEntity(_query_548494060_3, EntityQueryCaptureMode.AtRecord);
			ReplaceObjectsJob job = new ReplaceObjectsJob
			{
				Database = __query_548494060_7.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(job, _query_548494060_2, state.Dependency, ref state, hasUserDefinedQuery: true);
			state.Dependency = __ScheduleViaJobChunkExtension_1(default(RemoveNullObjectsJob), _query_548494060_, state.Dependency, ref state, hasUserDefinedQuery: true);
			InitializeSubMapsJob job2 = new InitializeSubMapsJob
			{
				Ecb = ecb,
				TileAccessor = _tileAccessor,
				TileUpdateBufferSingleton = __query_548494060_8.GetSingletonEntity()
			};
			state.Dependency = __ScheduleViaJobChunkExtension_2(job2, _query_548494060_, state.Dependency, ref state, hasUserDefinedQuery: true);
			EnableAreaJob job3 = new EnableAreaJob
			{
				Ecb = ecb
			};
			state.Dependency = __ScheduleViaJobChunkExtension_3(job3, _query_548494060_, state.Dependency, ref state, hasUserDefinedQuery: true);
			ClearAreaJob job4 = new ClearAreaJob
			{
				Ecb = ecb,
				TileAccessor = _tileAccessor,
				TransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				CollisionWorld = __query_548494060_9.GetSingleton<PhysicsWorldSingleton>().CollisionWorld
			};
			state.Dependency = __ScheduleViaJobChunkExtension_4(job4, _query_548494060_3, state.Dependency, ref state, hasUserDefinedQuery: true);
			CustomScenePrefabUtility.Data customSceneData = new CustomScenePrefabUtility.Data
			{
				ActiveContentBundles = __query_548494060_10.GetSingletonBuffer<ActivatedContentBundlesBuffer>().AsNativeArray().Reinterpret<DataBlockAddress>(),
				Database = __query_548494060_7.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob
			};
			SpawnObjectsJob job5 = new SpawnObjectsJob
			{
				Ecb = ecb,
				TileAccessor = _tileAccessor,
				WaterSpreadingArchetype = _waterSpreadingArchetype,
				CustomSceneTable = __query_548494060_11.GetSingleton<CustomSceneTableCD>().Value,
				Database = __query_548494060_7.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
				LootBank = __query_548494060_12.GetSingleton<LootTableBankCD>().Value,
				CustomSceneLookups = _customSceneLookups,
				CustomSceneData = customSceneData,
				ContainedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				TileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
				BiomeLookup = _biomeLookup
			};
			state.Dependency = __ScheduleViaJobChunkExtension_5(job5, _query_548494060_3, state.Dependency, ref state, hasUserDefinedQuery: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ReplaceObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ReplaceObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(RemoveNullObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_RemoveNullObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(InitializeSubMapsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_InitializeSubMapsJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_3(EnableAreaJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_EnableAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_4(ClearAreaJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_ClearAreaJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_5(SpawnObjectsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonApplySpawnedObjectsSystem_SpawnObjectsJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
			__query_548494060_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<Trigger, DungeonAreaCD, LocalTransform, DungeonSpawnedObjectBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EnableEntitiesInCircleCD>();
			__query_548494060_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<Trigger, DungeonAreaCD, LocalTransform, DungeonReplaceObjectsBuffer, DungeonSpawnedObjectBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EnableEntitiesInCircleCD>();
			__query_548494060_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<Trigger, DungeonAreaCD, PositionHasBeenEnabled, DungeonSpawnedObjectBuffer, LocalTransform>();
			__query_548494060_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_9 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_10 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_11 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<LootTableBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_548494060_12 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000002B_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_0000002C_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_0000002D_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_0000002E_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonApplySpawnedObjectsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
