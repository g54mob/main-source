using System;
using System.Collections.Generic;
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
using UnityEngine;

namespace Pug.Automation
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct PugElectricitySystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct GetElectricityTriggerJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ElectricityTriggerUpdateNearbyCD> __Pug_Automation_ElectricityTriggerUpdateNearbyCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricityTriggerUpdateNearbyCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityTriggerUpdateNearbyCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricityTriggerUpdateNearbyCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAll<ElectricityTriggerUpdateNearbyCD>().Build(ref state);
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
				public void Run(ref GetElectricityTriggerJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GetElectricityTriggerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GetElectricityTriggerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GetElectricityTriggerJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GetElectricityTriggerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GetElectricityTriggerJob job, EntityManager entityManager)
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

			public EntityCommandBuffer ecb;

			public NativeList<int2> triggerUpdateNearbyPositions;

			public NativeList<float> triggerDistances;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in ElectricityTriggerUpdateNearbyCD triggerUpdateNearby)
			{
				ecb.DestroyEntity(entity);
				triggerUpdateNearbyPositions.Add(in triggerUpdateNearby.position);
				triggerDistances.Add(triggerUpdateNearby.useDoubleRange ? 50f : 25f);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityTriggerUpdateNearbyCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityTriggerUpdateNearbyCD>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityTriggerUpdateNearbyCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityTriggerUpdateNearbyCD>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityTriggerUpdateNearbyCD>(nativeArrayPtr2, k));
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
		private struct GetElectricitySourcesJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricitySourceCD>();
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityConnectionCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityConnectionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ElectricitySourceCD>();
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
				public void Run(ref GetElectricitySourcesJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GetElectricitySourcesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GetElectricitySourcesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GetElectricitySourcesJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GetElectricitySourcesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GetElectricitySourcesJob job, EntityManager entityManager)
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
			public NativeList<int2> triggerUpdateNearbyPositions;

			[ReadOnly]
			public NativeList<float> triggerDistances;

			public NativeList<Entity> triggerUpdateNearbySourceEntities;

			public NativeList<int2> triggerUpdateNearbySourcePositions;

			public NativeParallelHashMap<int2, ConnectionMapEntry> connectionMap;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref ElectricitySourceCD source, in ElectricityConnectionCD connection)
			{
				for (int i = 0; i < triggerUpdateNearbyPositions.Length; i++)
				{
					int2 int5 = math.abs(connection.position - triggerUpdateNearbyPositions[i]);
					if ((float)(int5.x + int5.y) <= triggerDistances[i])
					{
						connectionMap.TryAdd(connection.position, new ConnectionMapEntry
						{
							entity = entity,
							connection = connection
						});
						triggerUpdateNearbySourceEntities.Add(in entity);
						triggerUpdateNearbySourcePositions.Add(in connection.position);
						break;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, k));
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
		private struct SortElectricityTriggersJob : IJob
		{
			public NativeList<int2> triggerUpdateNearbyPositions;

			public NativeList<int2> triggerUpdateNearbySourcePositions;

			public void Execute()
			{
				triggerUpdateNearbyPositions.Sort(default(XCoordinateComparer));
				triggerUpdateNearbySourcePositions.Sort(default(XCoordinateComparer));
			}
		}

		[BurstCompile]
		private struct ComputeConnectionRelevancyJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityConnectionCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<ElectricityConnectionCD>().Build(ref state);
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
				public void Run(ref ComputeConnectionRelevancyJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ComputeConnectionRelevancyJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ComputeConnectionRelevancyJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return InternalCompilerInterface.JobChunkInterface.ScheduleParallelByRef(ref job, query, dependency, job.__ChunkBaseEntityIndices);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ComputeConnectionRelevancyJob job, EntityQuery query, ref SystemState state)
				{
					NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArray(state.WorldUpdateAllocator);
					job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ComputeConnectionRelevancyJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					JobHandle outJobHandle;
					NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArrayAsync(state.WorldUpdateAllocator, dependency, out outJobHandle);
					job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
					return outJobHandle;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ComputeConnectionRelevancyJob job, EntityManager entityManager)
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

			[NativeDisableParallelForRestriction]
			public NativeArray<bool> ShouldAdd;

			[ReadOnly]
			public NativeList<int2> TriggerUpdateNearbyPositions;

			[ReadOnly]
			public NativeList<int2> TriggerUpdateNearbySourcePositions;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			public NativeArray<int> __ChunkBaseEntityIndices;

			public void Execute(Entity entity, [EntityIndexInQuery] int index, ref ElectricityConnectionCD connection)
			{
				ShouldAdd[index] = IsPositionInTriggerRange(connection.position, TriggerUpdateNearbyPositions, 25) || IsPositionInTriggerRange(connection.position, TriggerUpdateNearbySourcePositions, 25);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static bool IsPositionInTriggerRange(int2 position, NativeList<int2> xSortedTriggers, int range)
			{
				int i = 0;
				int num = xSortedTriggers.Length;
				int num2 = position.x - range;
				while (i < num)
				{
					int num3 = (i + num) / 2;
					if (xSortedTriggers[num3].x < num2)
					{
						i = num3 + 1;
					}
					else
					{
						num = num3;
					}
				}
				for (; i < xSortedTriggers.Length && xSortedTriggers[i].x <= position.x + range; i++)
				{
					if (math.csum(math.abs(xSortedTriggers[i] - position)) <= range)
					{
						return true;
					}
				}
				return false;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						int index = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity, index, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, i));
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
							int index2 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
							Execute(entity2, index2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, nextRangeBegin));
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
						int index3 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity3, index3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, j));
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
						int index4 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity4, index4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, k));
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
		private struct GetRelevantConnectionsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityConnectionCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<ElectricityConnectionCD>().Build(ref state);
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
				public void Run(ref GetRelevantConnectionsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GetRelevantConnectionsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GetRelevantConnectionsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return InternalCompilerInterface.JobChunkInterface.ScheduleParallelByRef(ref job, query, dependency, job.__ChunkBaseEntityIndices);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GetRelevantConnectionsJob job, EntityQuery query, ref SystemState state)
				{
					NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArray(state.WorldUpdateAllocator);
					job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GetRelevantConnectionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					JobHandle outJobHandle;
					NativeArray<int> _ChunkBaseEntityIndices = query.CalculateBaseEntityIndexArrayAsync(state.WorldUpdateAllocator, dependency, out outJobHandle);
					job.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
					return outJobHandle;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GetRelevantConnectionsJob job, EntityManager entityManager)
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
			public NativeArray<bool> ShouldAdd;

			public NativeParallelHashMap<int2, ConnectionMapEntry> ConnectionMap;

			public NativeList<Entity> HiddenConnections;

			[ReadOnly]
			public ComponentLookup<ElectricitySourceCD> electricitySourceLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			public NativeArray<int> __ChunkBaseEntityIndices;

			private unsafe void Execute(Entity entity, [EntityIndexInQuery] int entityInQueryIndex, ref ElectricityConnectionCD connection)
			{
				if (!ShouldAdd[entityInQueryIndex])
				{
					return;
				}
				for (int i = 0; i < 4; i++)
				{
					Entity sourceEntity = connection.GetSourceEntity((ElectricityDirection)i);
					if (!(sourceEntity == Entity.Null) && !electricitySourceLookup.HasComponent(sourceEntity))
					{
						connection.SetSourceEntity(i, Entity.Null);
						connection.electricityAmount[i] = 0;
					}
				}
				if (connection.prioritize)
				{
					if (ConnectionMap.ContainsKey(connection.position))
					{
						ref NativeList<Entity> hiddenConnections = ref HiddenConnections;
						ConnectionMapEntry connectionMapEntry = ConnectionMap[connection.position];
						hiddenConnections.Add(in connectionMapEntry.connection.connectedEntity);
						ConnectionMap.Remove(connection.position);
					}
					ConnectionMap.Add(connection.position, new ConnectionMapEntry
					{
						entity = entity,
						connection = connection
					});
				}
				else
				{
					ConnectionMap.TryAdd(connection.position, new ConnectionMapEntry
					{
						entity = entity,
						connection = connection
					});
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						int entityInQueryIndex = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity, entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, i));
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
							int entityInQueryIndex2 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
							Execute(entity2, entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, nextRangeBegin));
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
						int entityInQueryIndex3 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity3, entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, j));
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
						int entityInQueryIndex4 = __ChunkBaseEntityIndices[chunkIndexInQuery] + num;
						Execute(entity4, entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, k));
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
		private struct BFSJob : IJob
		{
			[ReadOnly]
			public ComponentLookup<ElectricityConnectionCD> electricityConnectionLookup;

			public ComponentLookup<ElectricitySourceCD> electricitySourceLookup;

			public NativeList<Entity> triggerUpdateNearbySourceEntities;

			public NativeParallelHashMap<int2, ConnectionMapEntry> connectionMap;

			public NativeQueue<PathFindNode> frontier;

			public NativeParallelHashSet<int3> visited;

			[ReadOnly]
			public NativeArray<int2> allDirOptions;

			[ReadOnly]
			public NativeArray<ElectricityDirectionMask> crossMap;

			[ReadOnly]
			public NativeArray<ElectricityDirectionMask> TMap;

			[ReadOnly]
			public NativeArray<ElectricityDirectionMask> LMap;

			[ReadOnly]
			public NativeArray<ElectricityDirectionMask> IMap;

			public unsafe void Execute()
			{
				NativeParallelHashMap<Entity, int> nativeParallelHashMap = new NativeParallelHashMap<Entity, int>(triggerUpdateNearbySourceEntities.Length * 2, Allocator.Temp);
				for (int i = 0; i < triggerUpdateNearbySourceEntities.Length; i++)
				{
					nativeParallelHashMap.Add(triggerUpdateNearbySourceEntities[i], -1);
				}
				for (int j = 0; j < triggerUpdateNearbySourceEntities.Length; j++)
				{
					Entity entity = triggerUpdateNearbySourceEntities[j];
					ElectricityConnectionCD electricityConnectionCD = electricityConnectionLookup[entity];
					ElectricitySourceCD value = electricitySourceLookup[entity];
					frontier.Clear();
					visited.Clear();
					value.sourceUpdate++;
					nativeParallelHashMap[entity] = value.sourceUpdate;
					if (value.sourceEnergy <= 0)
					{
						electricitySourceLookup[entity] = value;
						continue;
					}
					int2 position = electricityConnectionCD.position;
					for (int k = 0; k < 4; k++)
					{
						int2 int5 = position + allDirOptions[k];
						visited.Add(new int3(int5.x, int5.y, k));
						if (((uint)electricityConnectionCD.direction & (uint)(1 << k)) != 0 && connectionMap.TryGetValue(int5, out var item) && !HasSpecificOutputDirectionAndIsOpposite(item.connection.direction, k) && !IsBlockedInDirection(item.connection, k))
						{
							frontier.Enqueue(new PathFindNode
							{
								position = int5,
								direction = (ElectricityDirection)k,
								electricity = value.sourceEnergy
							});
							visited.Add(new int3(position.x, position.y, 3 - k));
						}
					}
					PathFindNode item2;
					while (frontier.TryDequeue(out item2))
					{
						ConnectionMapEntry value2 = connectionMap[item2.position];
						Entity sourceEntity = value2.connection.GetSourceEntity(item2.direction);
						if (value2.connection.electricityAmount[(int)item2.direction] < item2.electricity || (nativeParallelHashMap.TryGetValue(sourceEntity, out var item3) && value2.connection.sourceUpdate[(int)item2.direction] != item3))
						{
							value2.connection.electricityAmount[(int)item2.direction] = item2.electricity;
							value2.connection.SetSourceEntity((int)item2.direction, entity);
							value2.connection.sourceUpdate[(int)item2.direction] = value.sourceUpdate;
							connectionMap[item2.position] = value2;
						}
						if (value2.connection.mode == CircuitConnectionMode.None || item2.electricity <= 1)
						{
							continue;
						}
						ElectricityDirectionMask directionFromMode = GetDirectionFromMode(in value2.connection, item2.direction);
						for (int l = 0; l < 4; l++)
						{
							if (((uint)directionFromMode & (uint)(1 << l)) == 0)
							{
								continue;
							}
							int2 int6 = item2.position + allDirOptions[l];
							int3 item4 = new int3(int6.x, int6.y, l);
							int3 item5 = new int3(item2.position.x, item2.position.y, 3 - l);
							if (visited.Contains(item4))
							{
								continue;
							}
							if (connectionMap.ContainsKey(int6))
							{
								ElectricityConnectionCD connection = connectionMap[int6].connection;
								if (!HasSpecificOutputDirectionAndIsOpposite(connection.direction, l) && !IsBlockedInDirection(connection, l))
								{
									visited.Add(item4);
									visited.Add(item5);
									frontier.Enqueue(new PathFindNode
									{
										position = int6,
										direction = (ElectricityDirection)l,
										electricity = item2.electricity - 1
									});
								}
							}
							else
							{
								visited.Add(item4);
							}
						}
					}
					frontier.Clear();
					electricitySourceLookup[entity] = value;
				}
				nativeParallelHashMap.Dispose();
			}

			private ElectricityDirectionMask GetDirectionFromMode(in ElectricityConnectionCD connection, ElectricityDirection fromDirection)
			{
				ElectricityDirectionMask electricityDirectionMask = connection.direction;
				if (electricityDirectionMask == ElectricityDirectionMask.All)
				{
					switch (connection.mode)
					{
					case CircuitConnectionMode.Cross:
						electricityDirectionMask = crossMap[(int)(connection.connectionModeVariation * 4 + fromDirection)];
						break;
					case CircuitConnectionMode.T:
						electricityDirectionMask = TMap[(int)(connection.connectionModeVariation * 4 + fromDirection)];
						break;
					case CircuitConnectionMode.L:
						electricityDirectionMask = LMap[(int)(connection.connectionModeVariation * 4 + fromDirection)];
						break;
					case CircuitConnectionMode.I:
						electricityDirectionMask = IMap[(int)(connection.connectionModeVariation * 4 + fromDirection)];
						break;
					}
				}
				return electricityDirectionMask;
			}

			private bool IsBlockedInDirection(ElectricityConnectionCD connection, int directionIndex)
			{
				if ((connection.mode & CircuitConnectionMode.BlockingDirectionCircuitTypes) == 0)
				{
					return false;
				}
				return GetDirectionFromMode(in connection, (ElectricityDirection)directionIndex) == ElectricityDirectionMask.None;
			}
		}

		[BurstCompile]
		private struct WritebackJob : IJob
		{
			public ComponentLookup<ElectricityConnectionCD> electricityConnectionLookup;

			[ReadOnly]
			public ComponentLookup<ElectricitySourceCD> electricitySourceLookup;

			public ComponentLookup<ElectricityCD> electricityLookup;

			[ReadOnly]
			public NativeParallelHashMap<int2, ConnectionMapEntry>.ReadOnly connectionMap;

			[ReadOnly]
			public NativeList<Entity> hiddenConnections;

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			public unsafe void Execute()
			{
				using (NativeArray<ConnectionMapEntry> nativeArray = connectionMap.GetValueArray(Allocator.Temp))
				{
					for (int i = 0; i < nativeArray.Length; i++)
					{
						Entity entity = nativeArray[i].entity;
						ElectricityConnectionCD connection = nativeArray[i].connection;
						ElectricityConnectionCD electricityConnectionCD = electricityConnectionLookup[entity];
						bool flag = false;
						for (int j = 0; j < 4; j++)
						{
							Entity sourceEntity = connection.GetSourceEntity((ElectricityDirection)j);
							if (electricitySourceLookup.TryGetComponent(sourceEntity, out var componentData))
							{
								if (connection.sourceUpdate[j] != componentData.sourceUpdate)
								{
									connection.SetSourceEntity(j, Entity.Null);
									connection.electricityAmount[j] = 0;
									flag = true;
								}
							}
							else if (sourceEntity != Entity.Null)
							{
								connection.SetSourceEntity(j, Entity.Null);
								connection.electricityAmount[j] = 0;
								flag = true;
							}
							else if (electricityConnectionCD.electricityAmount[j] > connection.electricityAmount[j])
							{
								flag = true;
							}
						}
						if (flag)
						{
							Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
							ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
							{
								position = connection.position
							});
						}
						electricityConnectionLookup[entity] = connection;
						if (electricityLookup.TryGetComponent(connection.connectedEntity, out var componentData2))
						{
							componentData2.blocksElectricity = connection.mode == CircuitConnectionMode.None;
							componentData2.electricityAmountLeft = connection.electricityAmount[0];
							componentData2.electricityAmountDown = connection.electricityAmount[1];
							componentData2.electricityAmountUp = connection.electricityAmount[2];
							componentData2.electricityAmountRight = connection.electricityAmount[3];
							electricityLookup[connection.connectedEntity] = componentData2;
						}
					}
				}
				for (int k = 0; k < hiddenConnections.Length; k++)
				{
					if (electricityLookup.TryGetComponent(hiddenConnections[k], out var componentData3))
					{
						componentData3.electricityAmountLeft = 0;
						componentData3.electricityAmountDown = 0;
						componentData3.electricityAmountUp = 0;
						componentData3.electricityAmountRight = 0;
						electricityLookup[hiddenConnections[k]] = componentData3;
					}
				}
			}
		}

		[BurstCompile]
		[WithAll(new Type[] { typeof(DelayCircuitCD) })]
		private struct DelayCircuitJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricitySourceCD>();
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityConnectionCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityConnectionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DelayCircuitCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ElectricitySourceCD>();
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
				public void Run(ref DelayCircuitJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref DelayCircuitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref DelayCircuitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref DelayCircuitJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref DelayCircuitJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref DelayCircuitJob job, EntityManager entityManager)
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

			public ComponentLookup<ElectricityCD> electricityLookup;

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private unsafe void Execute(Entity entity, ref ElectricitySourceCD source, in ElectricityConnectionCD conn)
			{
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					num = math.max(num, conn.electricityAmount[i]);
				}
				if (source.sourceEnergy != num - 1)
				{
					source.sourceEnergy = num - 1;
					Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
					ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
					{
						position = conn.position
					});
					if (electricityLookup.TryGetComponent(conn.connectedEntity, out var componentData))
					{
						componentData.sourceEnergy = source.sourceEnergy;
						electricityLookup[conn.connectedEntity] = componentData;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricitySourceCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr3, k));
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
		[WithChangeFilter(new Type[] { typeof(ElectricityConnectionCD) })]
		[WithAll(new Type[] { typeof(LogicCircuitCD) })]
		private struct LogicCircuitJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityConnectionCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityConnectionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LogicCircuitCD>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(ElectricityConnectionCD))
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
				public void Run(ref LogicCircuitJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref LogicCircuitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref LogicCircuitJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref LogicCircuitJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref LogicCircuitJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref LogicCircuitJob job, EntityManager entityManager)
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
			public ComponentLookup<ElectricitySourceCD> electricitySourceLookup;

			public EntityCommandBuffer ecb;

			public EntityArchetype triggerUpdateArchetypeLocal;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private unsafe void Execute(Entity entity, in ElectricityConnectionCD conn)
			{
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					if (conn.electricityAmount[i] <= 0 || HasSpecificOutputDirectionAndIsOpposite(conn.direction, i))
					{
						continue;
					}
					if (conn.electricityAmount[i] == 1)
					{
						Entity sourceEntity = conn.GetSourceEntity((ElectricityDirection)i);
						if (electricitySourceLookup.TryGetComponent(sourceEntity, out var componentData) && componentData.sourceEnergy != 1)
						{
							continue;
						}
					}
					num++;
				}
				bool flag = num != 2;
				if (conn.mode == CircuitConnectionMode.None != flag)
				{
					ElectricityConnectionCD component = conn;
					component.mode = ((!flag) ? CircuitConnectionMode.AccordingToDirection : CircuitConnectionMode.None);
					ecb.SetComponent(entity, component);
					Entity e = ecb.CreateEntity(triggerUpdateArchetypeLocal);
					ecb.SetComponent(e, new ElectricityTriggerUpdateNearbyCD
					{
						position = conn.position
					});
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityConnectionCD>(nativeArrayPtr2, k));
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

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct XCoordinateComparer : IComparer<int2>
		{
			public int Compare(int2 x, int2 y)
			{
				return x.x.CompareTo(y.x);
			}
		}

		private struct ConnectionMapEntry
		{
			public Entity entity;

			public ElectricityConnectionCD connection;
		}

		private struct PathFindNode
		{
			public int2 position;

			public ElectricityDirection direction;

			public int electricity;
		}

		private struct TypeHandle
		{
			public GetElectricityTriggerJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle;

			public GetElectricitySourcesJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComputeConnectionRelevancyJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_RO_ComponentLookup;

			public GetRelevantConnectionsJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup;

			public ComponentLookup<ElectricitySourceCD> __Pug_Automation_ElectricitySourceCD_RW_ComponentLookup;

			public ComponentLookup<ElectricityConnectionCD> __Pug_Automation_ElectricityConnectionCD_RW_ComponentLookup;

			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RW_ComponentLookup;

			public DelayCircuitJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle;

			public LogicCircuitJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup = state.GetComponentLookup<ElectricitySourceCD>(isReadOnly: true);
				__Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
				__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityConnectionCD>(isReadOnly: true);
				__Pug_Automation_ElectricitySourceCD_RW_ComponentLookup = state.GetComponentLookup<ElectricitySourceCD>();
				__Pug_Automation_ElectricityConnectionCD_RW_ComponentLookup = state.GetComponentLookup<ElectricityConnectionCD>();
				__Pug_Automation_ElectricityCD_RW_ComponentLookup = state.GetComponentLookup<ElectricityCD>();
				__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000055D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000055D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000055D_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000055E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000055E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000055E_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_0000055F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_0000055F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000055F_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

		private static readonly ElectricityDirectionMask[] OppositeDirMask = new ElectricityDirectionMask[4]
		{
			ElectricityDirectionMask.West,
			ElectricityDirectionMask.South,
			ElectricityDirectionMask.North,
			ElectricityDirectionMask.East
		};

		private EntityArchetype _triggerUpdateArchetype;

		private int _delayCircuitClockTicks;

		private bool _hasRunAtLeastOnce;

		private EntityQuery _triggerUpdateQuery;

		private NativeArray<int2> _allDirOptions;

		private NativeArray<ElectricityDirectionMask> _crossMap;

		private NativeArray<ElectricityDirectionMask> _TMap;

		private NativeArray<ElectricityDirectionMask> _LMap;

		private NativeArray<ElectricityDirectionMask> _IMap;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1580601634_0;

		private EntityQuery __query_1580601634_1;

		private EntityQuery __query_1580601634_2;

		private EntityQuery __query_1580601634_3;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasSpecificOutputDirectionAndIsOpposite(ElectricityDirectionMask outputDirection, int directionIndex)
		{
			if (outputDirection != ElectricityDirectionMask.All)
			{
				return (outputDirection & OppositeDirMask[directionIndex]) != 0;
			}
			return false;
		}

		[BurstCompile]
		public unsafe void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			ComponentType* ptr = stackalloc ComponentType[1];
			*ptr = ComponentType.ReadOnly<ElectricityTriggerUpdateNearbyCD>();
			ReadOnlySpan<ComponentType> types = new ReadOnlySpan<ComponentType>(ptr, 1);
			_triggerUpdateArchetype = state.EntityManager.CreateArchetype(types);
			_triggerUpdateQuery = __query_1580601634_0;
			_allDirOptions = CollectionHelper.CreateNativeArray<int2>(4, Allocator.Persistent);
			_allDirOptions[0] = new int2(1, 0);
			_allDirOptions[1] = new int2(0, 1);
			_allDirOptions[2] = new int2(0, -1);
			_allDirOptions[3] = new int2(-1, 0);
			SetupCrossMap();
			SetupTMap();
			SetupLMap();
			SetupIMap();
		}

		private void SetupCrossMap()
		{
			_crossMap = CollectionHelper.CreateNativeArray<ElectricityDirectionMask>(12, Allocator.Persistent);
			int num = 0;
			_crossMap[num] = ElectricityDirectionMask.East;
			_crossMap[num + 1] = ElectricityDirectionMask.North;
			_crossMap[num + 2] = ElectricityDirectionMask.South;
			_crossMap[num + 3] = ElectricityDirectionMask.West;
			num = 4;
			_crossMap[num] = ElectricityDirectionMask.South;
			_crossMap[num + 1] = ElectricityDirectionMask.West;
			_crossMap[num + 2] = ElectricityDirectionMask.East;
			_crossMap[num + 3] = ElectricityDirectionMask.North;
			num = 8;
			_crossMap[num] = ElectricityDirectionMask.North;
			_crossMap[num + 1] = ElectricityDirectionMask.East;
			_crossMap[num + 2] = ElectricityDirectionMask.West;
			_crossMap[num + 3] = ElectricityDirectionMask.South;
		}

		private void SetupTMap()
		{
			_TMap = CollectionHelper.CreateNativeArray<ElectricityDirectionMask>(16, Allocator.Persistent);
			int num = 0;
			_TMap[num] = ElectricityDirectionMask.East | ElectricityDirectionMask.South;
			_TMap[num + 1] = ElectricityDirectionMask.East | ElectricityDirectionMask.West;
			_TMap[num + 2] = ElectricityDirectionMask.None;
			_TMap[num + 3] = ElectricityDirectionMask.South | ElectricityDirectionMask.West;
			num = 4;
			_TMap[num] = ElectricityDirectionMask.North | ElectricityDirectionMask.South;
			_TMap[num + 1] = ElectricityDirectionMask.North | ElectricityDirectionMask.West;
			_TMap[num + 2] = ElectricityDirectionMask.South | ElectricityDirectionMask.West;
			_TMap[num + 3] = ElectricityDirectionMask.None;
			num = 8;
			_TMap[num] = ElectricityDirectionMask.East | ElectricityDirectionMask.North;
			_TMap[num + 1] = ElectricityDirectionMask.None;
			_TMap[num + 2] = ElectricityDirectionMask.East | ElectricityDirectionMask.West;
			_TMap[num + 3] = ElectricityDirectionMask.North | ElectricityDirectionMask.West;
			num = 12;
			_TMap[num] = ElectricityDirectionMask.None;
			_TMap[num + 1] = ElectricityDirectionMask.East | ElectricityDirectionMask.North;
			_TMap[num + 2] = ElectricityDirectionMask.East | ElectricityDirectionMask.South;
			_TMap[num + 3] = ElectricityDirectionMask.North | ElectricityDirectionMask.South;
		}

		private void SetupLMap()
		{
			_LMap = CollectionHelper.CreateNativeArray<ElectricityDirectionMask>(16, Allocator.Persistent);
			int num = 0;
			_LMap[num] = ElectricityDirectionMask.South;
			_LMap[num + 1] = ElectricityDirectionMask.West;
			_LMap[num + 2] = ElectricityDirectionMask.None;
			_LMap[num + 3] = ElectricityDirectionMask.None;
			num = 4;
			_LMap[num] = ElectricityDirectionMask.North;
			_LMap[num + 1] = ElectricityDirectionMask.None;
			_LMap[num + 2] = ElectricityDirectionMask.West;
			_LMap[num + 3] = ElectricityDirectionMask.None;
			num = 8;
			_LMap[num] = ElectricityDirectionMask.None;
			_LMap[num + 1] = ElectricityDirectionMask.None;
			_LMap[num + 2] = ElectricityDirectionMask.East;
			_LMap[num + 3] = ElectricityDirectionMask.North;
			num = 12;
			_LMap[num] = ElectricityDirectionMask.None;
			_LMap[num + 1] = ElectricityDirectionMask.East;
			_LMap[num + 2] = ElectricityDirectionMask.None;
			_LMap[num + 3] = ElectricityDirectionMask.South;
		}

		private void SetupIMap()
		{
			_IMap = CollectionHelper.CreateNativeArray<ElectricityDirectionMask>(16, Allocator.Persistent);
			int num = 0;
			_IMap[num] = ElectricityDirectionMask.None;
			_IMap[num + 1] = ElectricityDirectionMask.North;
			_IMap[num + 2] = ElectricityDirectionMask.South;
			_IMap[num + 3] = ElectricityDirectionMask.None;
			num = 4;
			_IMap[num] = ElectricityDirectionMask.East;
			_IMap[num + 1] = ElectricityDirectionMask.None;
			_IMap[num + 2] = ElectricityDirectionMask.None;
			_IMap[num + 3] = ElectricityDirectionMask.West;
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
			_allDirOptions.Dispose();
			_crossMap.Dispose();
			_TMap.Dispose();
			_LMap.Dispose();
			_IMap.Dispose();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			EntityCommandBuffer ecb = __query_1580601634_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			EntityArchetype triggerUpdateArchetype = _triggerUpdateArchetype;
			NativeList<int2> triggerUpdateNearbyPositions = new NativeList<int2>(state.WorldUpdateAllocator);
			NativeList<float> triggerDistances = new NativeList<float>(state.WorldUpdateAllocator);
			NativeList<Entity> triggerUpdateNearbySourceEntities = new NativeList<Entity>(state.WorldUpdateAllocator);
			NativeList<int2> triggerUpdateNearbySourcePositions = new NativeList<int2>(state.WorldUpdateAllocator);
			NativeParallelHashMap<int2, ConnectionMapEntry> connectionMap = new NativeParallelHashMap<int2, ConnectionMapEntry>((_hasRunAtLeastOnce ? 1 : 100) * 25 * 25 * 2, state.WorldUpdateAllocator);
			NativeList<Entity> hiddenConnections = new NativeList<Entity>(state.WorldUpdateAllocator);
			NativeParallelHashSet<int3> visited = new NativeParallelHashSet<int3>(1250, state.WorldUpdateAllocator);
			NativeQueue<PathFindNode> frontier = new NativeQueue<PathFindNode>(state.WorldUpdateAllocator);
			__query_1580601634_3.TryGetSingleton<ClientServerTickRate>(out var value);
			_delayCircuitClockTicks--;
			bool num = _delayCircuitClockTicks <= 0;
			if (num)
			{
				_delayCircuitClockTicks = value.SimulationTickRate;
			}
			if (!_hasRunAtLeastOnce)
			{
				UnityEngine.Debug.Log($"Running {_triggerUpdateQuery.CalculateEntityCount()} electricity updates initially");
			}
			_hasRunAtLeastOnce = true;
			state.Dependency = __ScheduleViaJobChunkExtension_0(new GetElectricityTriggerJob
			{
				ecb = ecb,
				triggerUpdateNearbyPositions = triggerUpdateNearbyPositions,
				triggerDistances = triggerDistances
			}, _triggerUpdateQuery, state.Dependency, ref state, hasUserDefinedQuery: true);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new GetElectricitySourcesJob
			{
				triggerUpdateNearbyPositions = triggerUpdateNearbyPositions,
				triggerDistances = triggerDistances,
				triggerUpdateNearbySourceEntities = triggerUpdateNearbySourceEntities,
				triggerUpdateNearbySourcePositions = triggerUpdateNearbySourcePositions,
				connectionMap = connectionMap
			}, __TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = IJobExtensions.Schedule(new SortElectricityTriggersJob
			{
				triggerUpdateNearbyPositions = triggerUpdateNearbyPositions,
				triggerUpdateNearbySourcePositions = triggerUpdateNearbySourcePositions
			}, state.Dependency);
			EntityQuery _query_1580601634_ = __query_1580601634_1;
			NativeArray<bool> shouldAdd = CollectionHelper.CreateNativeArray<bool>(_query_1580601634_.CalculateEntityCount(), state.WorldUpdateAllocator);
			state.Dependency = __ScheduleViaJobChunkExtension_2(new ComputeConnectionRelevancyJob
			{
				ShouldAdd = shouldAdd,
				TriggerUpdateNearbyPositions = triggerUpdateNearbyPositions,
				TriggerUpdateNearbySourcePositions = triggerUpdateNearbySourcePositions
			}, _query_1580601634_, state.Dependency, ref state, hasUserDefinedQuery: true);
			state.Dependency = __ScheduleViaJobChunkExtension_3(new GetRelevantConnectionsJob
			{
				ShouldAdd = shouldAdd,
				ConnectionMap = connectionMap,
				HiddenConnections = hiddenConnections,
				electricitySourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup, ref state)
			}, _query_1580601634_, state.Dependency, ref state, hasUserDefinedQuery: true);
			state.Dependency = IJobExtensions.Schedule(new BFSJob
			{
				electricityConnectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RO_ComponentLookup, ref state),
				electricitySourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RW_ComponentLookup, ref state),
				triggerUpdateNearbySourceEntities = triggerUpdateNearbySourceEntities,
				connectionMap = connectionMap,
				frontier = frontier,
				visited = visited,
				allDirOptions = _allDirOptions,
				crossMap = _crossMap,
				TMap = _TMap,
				LMap = _LMap,
				IMap = _IMap
			}, state.Dependency);
			state.Dependency = IJobExtensions.Schedule(new WritebackJob
			{
				electricityConnectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityConnectionCD_RW_ComponentLookup, ref state),
				electricitySourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup, ref state),
				electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RW_ComponentLookup, ref state),
				connectionMap = connectionMap.AsReadOnly(),
				hiddenConnections = hiddenConnections,
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetype
			}, state.Dependency);
			if (num)
			{
				state.Dependency = __ScheduleViaJobChunkExtension_4(new DelayCircuitJob
				{
					electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RW_ComponentLookup, ref state),
					ecb = ecb,
					triggerUpdateArchetypeLocal = triggerUpdateArchetype
				}, __TypeHandle.__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
			state.Dependency = __ScheduleViaJobChunkExtension_5(new LogicCircuitJob
			{
				electricitySourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricitySourceCD_RO_ComponentLookup, ref state),
				ecb = ecb,
				triggerUpdateArchetypeLocal = triggerUpdateArchetype
			}, __TypeHandle.__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(GetElectricityTriggerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricityTriggerJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(GetElectricitySourcesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_GetElectricitySourcesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(ComputeConnectionRelevancyJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_ComputeConnectionRelevancyJob_WithoutDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_3(GetRelevantConnectionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_GetRelevantConnectionsJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_4(DelayCircuitJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_DelayCircuitJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_5(LogicCircuitJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugElectricitySystem_LogicCircuitJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityTriggerUpdateNearbyCD>();
			__query_1580601634_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ElectricityConnectionCD>();
			__query_1580601634_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1580601634_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1580601634_3 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000055D_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000055E_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_0000055F_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugElectricitySystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugElectricitySystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugElectricitySystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugElectricitySystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}
	}
}
