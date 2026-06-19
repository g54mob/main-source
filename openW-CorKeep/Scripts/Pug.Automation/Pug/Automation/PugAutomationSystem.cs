using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
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
using UnityEngine;

namespace Pug.Automation
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateBefore(typeof(StateSystemGroup))]
	[BurstCompile]
	public struct PugAutomationSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		public struct UpdateBigEntityIsDisabledJob : IJobChunk
		{
			public uint LastSystemVersion;

			[ReadOnly]
			public BufferTypeHandle<SmallEntityRefBuffer> SmallEntityRefBufferHandle;

			public ComponentLookup<BigEntityIsEnabledCD> BigEntityIsEnabledLookup;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				if (!chunk.DidOrderChange(LastSystemVersion))
				{
					return;
				}
				BufferAccessor<SmallEntityRefBuffer> bufferAccessor = chunk.GetBufferAccessor(SmallEntityRefBufferHandle);
				bool value = !chunk.Has<Disabled>();
				for (int i = 0; i < chunk.Count; i++)
				{
					DynamicBuffer<SmallEntityRefBuffer> dynamicBuffer = bufferAccessor[i];
					for (int j = 0; j < dynamicBuffer.Length; j++)
					{
						Entity value2 = dynamicBuffer[j].Value;
						if (BigEntityIsEnabledLookup.HasComponent(value2))
						{
							BigEntityIsEnabledLookup.SetComponentEnabled(value2, value);
						}
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[BurstCompile]
		[WithAll(new Type[] { typeof(EnabledMoverFromSharedStateCD) })]
		private struct UpdateMoverTimerJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<MoverTimerCD> __Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoverCD> __Pug_Automation_MoverCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoverTimerCD>();
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnabledMoverFromSharedStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoverTimerCD>();
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
				public void Run(ref UpdateMoverTimerJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateMoverTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateMoverTimerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateMoverTimerJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateMoverTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateMoverTimerJob job, EntityManager entityManager)
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

			public NativeParallelMultiHashMap<int2, Entity> PlacedAtPosition;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> ContainerLookup;

			[ReadOnly]
			public ComponentLookup<PlantInEndOfMoveCD> PlantInEndOfMoveLookup;

			[ReadOnly]
			public ComponentLookup<DropInEndOfMoveCD> DropInEndOfMoveLookup;

			public ComponentLookup<PlantTriggerCD> PlantTriggerLookup;

			public ComponentLookup<EnableSharedMoversTriggerCD> EnableSharedMoversTriggerLookup;

			public ComponentLookup<CycleEnabledMoversTriggerCD> cycleEnabledMoversTriggerLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, ref MoverTimerCD moverTimerCD, in MoverCD mover)
			{
				moverTimerCD.timer--;
				if (moverTimerCD.timer != -1)
				{
					return;
				}
				if (IsPickUpMover(in mover) && HasMoverPickedUpObject(in mover, ContainerLookup))
				{
					if (PlantInEndOfMoveLookup.HasComponent(entity))
					{
						PlantTriggerLookup.SetComponentEnabled(entity, value: true);
						PlacedAtPosition.Add(mover.stop, mover.inventoryEntity);
					}
					else if (DropInEndOfMoveLookup.HasComponent(entity))
					{
						PlacedAtPosition.Add(mover.stop, mover.inventoryEntity);
					}
					moverTimerCD.timer = mover.cooldownTime;
				}
				else if (mover.cycleEnabledMoverAfterActivation)
				{
					cycleEnabledMoversTriggerLookup.SetComponentEnabled(mover.moverOrchestratorEntity, value: true);
				}
				else if (mover.enableAllMoversAfterActivation)
				{
					EnableSharedMoversTriggerLookup.SetComponentEnabled(mover.moverOrchestratorEntity, value: true);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, k));
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
		public struct CycleEnabledMoversJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<CycleEnabledMoversTriggerCD> __Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<MoverOrchestratorCD> __Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<MoversWithSharedStateBuffer> __Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CycleEnabledMoversTriggerCD>();
						__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoverOrchestratorCD>();
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MoversWithSharedStateBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoversWithSharedStateBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CycleEnabledMoversTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoverOrchestratorCD>();
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
				public void Run(ref CycleEnabledMoversJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref CycleEnabledMoversJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref CycleEnabledMoversJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref CycleEnabledMoversJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref CycleEnabledMoversJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref CycleEnabledMoversJob job, EntityManager entityManager)
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

			public ComponentLookup<EnabledMoverFromSharedStateCD> EnabledMoverFromSharedStateLookup;

			public NativeHashSet<int2> NewMovers;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(EnabledRefRW<CycleEnabledMoversTriggerCD> trigger, ref MoverOrchestratorCD orchestrator, in DynamicBuffer<MoversWithSharedStateBuffer> movers)
			{
				trigger.ValueRW = false;
				if (orchestrator.enabledMoverIndex == -1)
				{
					orchestrator.enabledMoverIndex = 0;
				}
				else
				{
					orchestrator.enabledMoverIndex += orchestrator.nextMoverCycleIncrement;
					orchestrator.enabledMoverIndex %= movers.Length;
					orchestrator.nextMoverCycleIncrement = 0;
				}
				for (int i = 0; i < movers.Length; i++)
				{
					EnabledMoverFromSharedStateLookup.SetComponentEnabled(movers[i].moverEntity, i == orchestrator.enabledMoverIndex);
				}
				NewMovers.Add(movers[orchestrator.enabledMoverIndex].cachedStart);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle);
				BufferAccessor<MoversWithSharedStateBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ref MoverOrchestratorCD orchestrator = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, i);
						DynamicBuffer<MoversWithSharedStateBuffer> movers = bufferAccessor[i];
						Execute(enabledMask.GetEnabledRefRW<CycleEnabledMoversTriggerCD>(i), ref orchestrator, in movers);
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
							ref MoverOrchestratorCD orchestrator2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, nextRangeBegin);
							DynamicBuffer<MoversWithSharedStateBuffer> movers2 = bufferAccessor[nextRangeBegin];
							Execute(enabledMask.GetEnabledRefRW<CycleEnabledMoversTriggerCD>(nextRangeBegin), ref orchestrator2, in movers2);
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
						ref MoverOrchestratorCD orchestrator3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, j);
						DynamicBuffer<MoversWithSharedStateBuffer> movers3 = bufferAccessor[j];
						Execute(enabledMask.GetEnabledRefRW<CycleEnabledMoversTriggerCD>(j), ref orchestrator3, in movers3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ref MoverOrchestratorCD orchestrator4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, k);
						DynamicBuffer<MoversWithSharedStateBuffer> movers4 = bufferAccessor[k];
						Execute(enabledMask.GetEnabledRefRW<CycleEnabledMoversTriggerCD>(k), ref orchestrator4, in movers4);
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
		public struct EnableSharedMoversJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<EnableSharedMoversTriggerCD> __Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<MoversWithSharedStateBuffer> __Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EnableSharedMoversTriggerCD>();
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MoversWithSharedStateBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoversWithSharedStateBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EnableSharedMoversTriggerCD>();
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
				public void Run(ref EnableSharedMoversJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref EnableSharedMoversJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref EnableSharedMoversJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref EnableSharedMoversJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref EnableSharedMoversJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref EnableSharedMoversJob job, EntityManager entityManager)
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

			public NativeHashSet<int2> NewMovers;

			public ComponentLookup<EnabledMoverFromSharedStateCD> ActiveMoverFromSharedStateLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(EnabledRefRW<EnableSharedMoversTriggerCD> enabledSharedMoversTriggerEnabledRW, in DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer)
			{
				enabledSharedMoversTriggerEnabledRW.ValueRW = false;
				for (int i = 0; i < moversWithSharedStateBuffer.Length; i++)
				{
					ActiveMoverFromSharedStateLookup.SetComponentEnabled(moversWithSharedStateBuffer[i].moverEntity, value: true);
					NewMovers.Add(moversWithSharedStateBuffer[i].cachedStart);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentTypeHandle);
				BufferAccessor<MoversWithSharedStateBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer = bufferAccessor[i];
						Execute(enabledMask.GetEnabledRefRW<EnableSharedMoversTriggerCD>(i), in moversWithSharedStateBuffer);
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
							DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(enabledMask.GetEnabledRefRW<EnableSharedMoversTriggerCD>(nextRangeBegin), in moversWithSharedStateBuffer2);
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
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer3 = bufferAccessor[j];
						Execute(enabledMask.GetEnabledRefRW<EnableSharedMoversTriggerCD>(j), in moversWithSharedStateBuffer3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer4 = bufferAccessor[k];
						Execute(enabledMask.GetEnabledRefRW<EnableSharedMoversTriggerCD>(k), in moversWithSharedStateBuffer4);
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
		[WithAll(new Type[] { typeof(BigEntityIsEnabledCD) })]
		public struct UpdateEnabledMoveeJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<MoveeCD> __Pug_Automation_MoveeCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveeCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BigEntityRefCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BigEntityIsEnabledCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveeCD>();
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
				public void Run(ref UpdateEnabledMoveeJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateEnabledMoveeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateEnabledMoveeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateEnabledMoveeJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateEnabledMoveeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateEnabledMoveeJob job, EntityManager entityManager)
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

			public float DeltaTime;

			public NativeParallelMultiHashMap<int2, Entity> MoveeAtPosition;

			[ReadOnly]
			public ComponentLookup<PhysicsDamping> PhysicsDampingLookup;

			public ComponentLookup<LocalTransform> LocalTransformLookup;

			public ComponentLookup<PhysicsVelocity> PhysicsVelocityLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in BigEntityRefCD entityRef, ref MoveeCD movee)
			{
				if (!LocalTransformLookup.TryGetComponent(entityRef.Value, out var componentData))
				{
					UnityEngine.Debug.LogError("Missing LocalTransform on entity ref in UpdateEnabledMoveeJob");
					return;
				}
				movee.position = componentData.Position.xz;
				if (movee.moveTimer < 0)
				{
					MoveeAtPosition.Add(movee.position.RoundToInt2(), entity);
					return;
				}
				float num = math.distancesq(movee.position, movee.target);
				PhysicsVelocity componentData2;
				if (num < 0.1f || num > 100f)
				{
					movee.moveTimer = -1;
				}
				else if (PhysicsVelocityLookup.TryGetComponent(entityRef.Value, out componentData2))
				{
					if (!PhysicsDampingLookup.TryGetComponent(entityRef.Value, out var componentData3))
					{
						componentData3 = new PhysicsDamping
						{
							Linear = 1f
						};
					}
					float2 float5 = math.normalizesafe(movee.target - movee.position);
					componentData2.AddLinear2D(float5.ToFloat3() * math.max(1f, componentData3.Linear) * DeltaTime);
					float2 ontoB = math.cross((movee.target - math.round(movee.position)).ToFloat3(), math.up()).ToFloat2();
					componentData2.AddLinear2D(math.normalizesafe(math.projectsafe(float5, ontoB)).ToFloat3() * math.max(1f, componentData3.Linear) * DeltaTime);
					PhysicsVelocityLookup[entityRef.Value] = componentData2;
					movee.moveTimer--;
				}
				else
				{
					movee.position += (movee.target - movee.position) / (movee.moveTimer + 1);
					movee.moveTimer--;
				}
				LocalTransformLookup[entityRef.Value] = LocalTransform.FromPosition(movee.position.X0Y());
				if (movee.moveTimer < 0)
				{
					MoveeAtPosition.Add(movee.target.RoundToInt2(), entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoveeCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr3, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr3, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr3, k));
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
		[WithNone(new Type[] { typeof(BigEntityIsEnabledCD) })]
		public struct UpdateDisabledMoveeJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<MoveeCD> __Pug_Automation_MoveeCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveeCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<BigEntityIsEnabledCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveeCD>();
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
				public void Run(ref UpdateDisabledMoveeJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateDisabledMoveeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateDisabledMoveeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateDisabledMoveeJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateDisabledMoveeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateDisabledMoveeJob job, EntityManager entityManager)
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

			public NativeParallelMultiHashMap<int2, Entity> MoveeAtPosition;

			public NativeHashSet<int2> NewMovers;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, ref MoveeCD movee)
			{
				if (movee.moveTimer < 0)
				{
					int2 int5 = movee.position.RoundToInt2();
					if (NewMovers.Contains(int5))
					{
						MoveeAtPosition.Add(int5, entity);
					}
					return;
				}
				movee.position += (movee.target - movee.position) / (movee.moveTimer + 1);
				movee.moveTimer--;
				if (movee.moveTimer < 0)
				{
					MoveeAtPosition.Add(movee.target.RoundToInt2(), entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoveeCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, k));
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
		public struct MoveeMergeJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<MoveeCD> __Pug_Automation_MoveeCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveeCD>();
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoveeCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BigEntityRefCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveeCD>();
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
				public void Run(ref MoveeMergeJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref MoveeMergeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref MoveeMergeJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref MoveeMergeJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref MoveeMergeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref MoveeMergeJob job, EntityManager entityManager)
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
			public NativeParallelMultiHashMap<int2, Entity> MoveeAtPosition;

			[ReadOnly]
			public ComponentLookup<BigEntityRefCD> BigEntityLookup;

			[ReadOnly]
			public ComponentLookup<PickUpItemCD> PickUpObjectLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

			public BufferLookup<InventoryChangeBuffer> InventoryChangeBufferLookup;

			public Entity InventoryChangeBufferEntity;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in BigEntityRefCD entityRef, ref MoveeCD movee)
			{
				if (movee.moveTimer >= 0)
				{
					return;
				}
				int2 key = movee.position.RoundToInt2();
				if (MoveeAtPosition.TryGetFirstValue(key, out var item, out var _))
				{
					Entity value = entityRef.Value;
					Entity value2 = BigEntityLookup[item].Value;
					if (!EntityDestroyedLookup.HasAndIsComponentEnabled(value) && !EntityDestroyedLookup.HasAndIsComponentEnabled(value2) && value != value2 && PickUpObjectLookup.TryGetComponent(value, out var componentData) && PickUpObjectLookup.TryGetComponent(value2, out var componentData2) && componentData.targetEntity == componentData2.targetEntity && componentData.state != PickUpItemState.HasBeenPickedUp && componentData2.state != PickUpItemState.HasBeenPickedUp)
					{
						InventoryChangeBufferLookup[InventoryChangeBufferEntity].Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.MoveAmount(value, 0, value2, 0, -1, int.MaxValue, destroyExisting: false)
						});
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoveeCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, k));
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
			typeof(EnabledMoverFromSharedStateCD),
			typeof(PlantInEndOfMoveCD)
		})]
		public struct PlanterCheckPlantStateChangedJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MoverCD> __Pug_Automation_MoverCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoverTimerCD> __Pug_Automation_MoverTimerCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverCD>(isReadOnly: true);
						__Pug_Automation_MoverTimerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverTimerCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverTimerCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoverTimerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnabledMoverFromSharedStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlantInEndOfMoveCD>();
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
				public void Run(ref PlanterCheckPlantStateChangedJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref PlanterCheckPlantStateChangedJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref PlanterCheckPlantStateChangedJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref PlanterCheckPlantStateChangedJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref PlanterCheckPlantStateChangedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref PlanterCheckPlantStateChangedJob job, EntityManager entityManager)
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

			public NativeHashSet<int2> ActivePlanterMovers;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(in MoverCD moverCD, in MoverTimerCD moverTimerCD)
			{
				if (moverTimerCD.timer < 0)
				{
					ActivePlanterMovers.Add(moverCD.start);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverTimerCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, k));
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
		public struct PlaceInStorageJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<StorageCD> __Pug_Automation_StorageCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_StorageCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StorageCD>();
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_StorageCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<StorageCD>().Build(ref state);
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
				public void Run(ref PlaceInStorageJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref PlaceInStorageJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref PlaceInStorageJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref PlaceInStorageJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref PlaceInStorageJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref PlaceInStorageJob job, EntityManager entityManager)
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

			public uint GlobalSystemVersion;

			public EntityCommandBuffer ECB;

			[ReadOnly]
			public NativeHashSet<int2> NewMovers;

			[ReadOnly]
			public NativeHashSet<int2> ActivePlanterMovers;

			public NativeParallelHashMap<int2, Entity> StorageAtPosition;

			public NativeParallelMultiHashMap<int2, Entity> PlacedAtPosition;

			public PugDatabase.DatabaseBankCD DatabaseBankCD;

			public BufferLookup<ContainedObjectsBuffer> ContainerLookup;

			[ReadOnly]
			public BufferLookup<InventoryBuffer> InventoryLookup;

			[ReadOnly]
			public ComponentLookup<CraftingCD> CraftingLookup;

			[ReadOnly]
			public BufferLookup<InventorySlotRequirementBuffer> RequirementsBuffers;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> TagLookup;

			[ReadOnly]
			public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> OverrideAlwaysAllowToBeTrashedLookup;

			public BufferLookup<InventoryChangeBuffer> InventoryChangeBufferLookup;

			public Entity InventoryChangeBufferEntity;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref StorageCD storage)
			{
				if ((NewMovers.Contains(storage.position) || ActivePlanterMovers.Contains(storage.position)) && ContainerLookup.DidChange(storage.inventoryEntity, storage.wasEmptyAtVersion))
				{
					if (InventoryUtility.CanPickup(ContainerLookup, CraftingLookup, RequirementsBuffers, TagLookup, OverrideAlwaysAllowToBeTrashedLookup, storage.inventoryEntity, DatabaseBankCD))
					{
						StorageAtPosition.TryAdd(storage.position, storage.inventoryEntity);
					}
					else
					{
						storage.wasEmptyAtVersion = GlobalSystemVersion;
					}
				}
				if (!PlacedAtPosition.TryGetFirstValue(storage.position, out var item, out var it))
				{
					return;
				}
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = InventoryChangeBufferLookup[InventoryChangeBufferEntity];
				do
				{
					ObjectDataCD objectData = ContainerLookup[item][0].objectData;
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, DatabaseBankCD.databaseBankBlob, objectData.variation);
					TagLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
					if (RequirementsBuffers.HasComponent(storage.inventoryEntity) && !InventoryUtility.ObjectIsValidToPutInInventory(RequirementsBuffers[storage.inventoryEntity], componentData, objectData.objectID, InventoryLookup[storage.inventoryEntity], OverrideAlwaysAllowToBeTrashedLookup, out var _, DatabaseBankCD))
					{
						dynamicBuffer.Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.DropAllItems(item, storage.position.ToFloat3(), Entity.Null, randomOffset: false)
						});
					}
					else
					{
						dynamicBuffer.Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.MoveOrDropAmount(item, 0, storage.inventoryEntity, -1, -1, int.MaxValue, storage.position.ToFloat3())
						});
					}
				}
				while (PlacedAtPosition.TryGetNextValue(out item, ref it));
				PlacedAtPosition.Remove(storage.position);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_StorageCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StorageCD>(nativeArrayPtr, i));
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StorageCD>(nativeArrayPtr, nextRangeBegin));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StorageCD>(nativeArrayPtr, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StorageCD>(nativeArrayPtr, k));
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
		[WithAll(new Type[] { typeof(PlantInEndOfMoveCD) })]
		private struct PlantJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MoverCD> __Pug_Automation_MoverCD_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PlantTriggerCD> __Pug_Automation_PlantTriggerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverCD>(isReadOnly: true);
						__Pug_Automation_PlantTriggerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlantTriggerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_PlantTriggerCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlantInEndOfMoveCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlantTriggerCD>();
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
				public void Run(ref PlantJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref PlantJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref PlantJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref PlantJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref PlantJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref PlantJob job, EntityManager entityManager)
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

			public BufferLookup<ContainedObjectsBuffer> ContainerLookup;

			public PlacementHandler.CanPlaceSharedData CanPlaceSharedData;

			public BufferLookup<InventoryChangeBuffer> InventoryChangeBufferLookup;

			public Entity InventoryChangeBufferEntity;

			[ReadOnly]
			public ObjectLookupCD ObjectLookupCD;

			public NativeHashSet<int2> PlacedObjectAtPositionThisTickMap;

			public NativeReference<Unity.Mathematics.Random> rnd;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(in MoverCD mover, EnabledRefRW<PlantTriggerCD> plantTriggerCD)
			{
				plantTriggerCD.ValueRW = false;
				if (!IsPickUpMover(in mover) || !HasMoverPickedUpObject(in mover, ContainerLookup))
				{
					return;
				}
				int3 placeAtPos = mover.stop.ToInt3();
				if (PlacedObjectAtPositionThisTickMap.Contains(placeAtPos.xz))
				{
					return;
				}
				ContainedObjectsBuffer containedObjectsBuffer = ContainerLookup[mover.inventoryEntity][0];
				if (!InventoryUtility.CanPlaceSeed(mover.inventoryEntity, containedObjectsBuffer.objectID, containedObjectsBuffer.variation, placeAtPos, ContainerLookup, in CanPlaceSharedData, in ObjectLookupCD))
				{
					return;
				}
				int variationToInstatiate = containedObjectsBuffer.variation;
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, CanPlaceSharedData.databaseBank.databaseBankBlob, containedObjectsBuffer.variation);
				if (CanPlaceSharedData.objectPropertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData) && componentData.TryGet<int>(1273594437, out var value) && value > 0)
				{
					Unity.Mathematics.Random value2 = rnd.Value;
					float num = value2.NextFloat();
					rnd.Value = value2;
					float num2 = 0.03f;
					if (num < num2)
					{
						variationToInstatiate = value;
					}
				}
				InventoryChangeBufferLookup[InventoryChangeBufferEntity].Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.ConsumeEntityAt(mover.inventoryEntity, 0, 1, destroy: false, dontConsume: false, new float3(placeAtPos.x, 0f, placeAtPos.z), variationToInstatiate, float3.zero)
				});
				PlacedObjectAtPositionThisTickMap.Add(placeAtPos.xz);
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentTypeHandle);
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__Pug_Automation_PlantTriggerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, i), enabledMask.GetEnabledRefRW<PlantTriggerCD>(i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, nextRangeBegin), enabledMask.GetEnabledRefRW<PlantTriggerCD>(nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, j), enabledMask.GetEnabledRefRW<PlantTriggerCD>(j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr, k), enabledMask.GetEnabledRefRW<PlantTriggerCD>(k));
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
		[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
		[WithChangeFilter(new Type[] { typeof(ContainedObjectsBuffer) })]
		[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
		public struct StorageChangeCheckJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SmallEntityRefBuffer> __Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugAutomationCD>(isReadOnly: true);
						__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SmallEntityRefBuffer>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugAutomationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SmallEntityRefBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
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
				public void Run(ref StorageChangeCheckJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref StorageChangeCheckJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref StorageChangeCheckJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref StorageChangeCheckJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref StorageChangeCheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref StorageChangeCheckJob job, EntityManager entityManager)
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

			public NativeParallelHashMap<int2, Entity> StorageAtPosition;

			[ReadOnly]
			public ComponentLookup<StorageCD> StorageLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in PugAutomationCD automation, in DynamicBuffer<SmallEntityRefBuffer> smallEntityBuffer, in DynamicBuffer<ContainedObjectsBuffer> containedObjects)
			{
				if ((automation.type & AutomationType.Storage) == 0)
				{
					return;
				}
				int i;
				for (i = 0; i < containedObjects.Length && containedObjects[i].objectData.objectID == ObjectID.None; i++)
				{
				}
				if (i == containedObjects.Length)
				{
					return;
				}
				for (i = 0; i < smallEntityBuffer.Length; i++)
				{
					if (StorageLookup.TryGetComponent(smallEntityBuffer[i].Value, out var componentData))
					{
						StorageAtPosition.TryAdd(componentData.position, componentData.inventoryEntity);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle);
				BufferAccessor<SmallEntityRefBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr, i), bufferAccessor[i], bufferAccessor2[i]);
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr, nextRangeBegin), bufferAccessor[nextRangeBegin], bufferAccessor2[nextRangeBegin]);
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr, j), bufferAccessor[j], bufferAccessor2[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugAutomationCD>(nativeArrayPtr, k), bufferAccessor[k], bufferAccessor2[k]);
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
		public struct UpdateMinerJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<MinerCD> __Pug_Automation_MinerCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_MinerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MinerCD>();
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_MinerCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					DefaultQuery = entityQueryBuilder.WithAllRW<MinerCD>().Build(ref state);
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
				public void Run(ref UpdateMinerJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateMinerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateMinerJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateMinerJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateMinerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateMinerJob job, EntityManager entityManager)
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

			public NativeParallelHashMap<int2, int> MiningDamages;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref MinerCD miner)
			{
				if (miner.timer > 0)
				{
					miner.timer--;
					return;
				}
				if (MiningDamages.ContainsKey(miner.position))
				{
					MiningDamages[miner.position] += miner.damage;
				}
				else
				{
					MiningDamages.Add(miner.position, miner.damage);
				}
				miner.timer = miner.cooldown;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MinerCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinerCD>(nativeArrayPtr, i));
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
							Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinerCD>(nativeArrayPtr, nextRangeBegin));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinerCD>(nativeArrayPtr, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinerCD>(nativeArrayPtr, k));
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
		public struct MiningMineablesJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MineableCD> __Pug_Automation_MineableCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_MineableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MineableCD>(isReadOnly: true);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_MineableCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MineableCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BigEntityRefCD>();
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
				public void Run(ref MiningMineablesJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref MiningMineablesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref MiningMineablesJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref MiningMineablesJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref MiningMineablesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref MiningMineablesJob job, EntityManager entityManager)
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

			public NetworkTick ServerTick;

			public int TickRate;

			[ReadOnly]
			public NativeParallelHashMap<int2, int> MiningDamages;

			public ComponentLookup<MineableDamageDecreaseCD> MineableDamageDecreaseLookup;

			public Entity HealthChangeBufferEntity;

			public BufferLookup<HealthChangeBuffer> HealthChangeBufferLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MineableCD mineable, in BigEntityRefCD entityRef)
			{
				if (!MiningDamages.ContainsKey(mineable.position))
				{
					return;
				}
				int num = MiningDamages[mineable.position];
				float num2 = 1f;
				if (MineableDamageDecreaseLookup.TryGetComponent(entityRef.Value, out var componentData))
				{
					NetworkTick old = componentData.lastTotalDamageUpdateTick;
					if (!componentData.lastTotalDamageUpdateTick.IsValid)
					{
						old = ServerTick;
						old.Subtract((uint)(TickRate + 1));
					}
					old.Add((uint)TickRate);
					if (ServerTick.IsNewerThan(old))
					{
						componentData.lastTotalDamageUpdateTick = ServerTick;
						componentData.damageFactor = math.pow(componentData.damageDecreaseFactor, (float)componentData.totalDamage * componentData.damageDecreaseExp);
						componentData.totalDamage = 0;
					}
					componentData.totalDamage += num;
					num2 = componentData.damageFactor;
					MineableDamageDecreaseLookup[entityRef.Value] = componentData;
				}
				int num3 = (int)math.round((float)num * num2);
				HealthChangeBufferLookup[HealthChangeBufferEntity].Add(new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = entityRef.Value,
						amount = -num3,
						bypassDamageReduction = true,
						bypassMaxDamagePerHit = true,
						optionalPositionToDropLootWhenDamaged = mineable.position
					}
				});
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MineableCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MineableCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MineableCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MineableCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MineableCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, k));
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
		public struct ApplyTileDamageJob : IJob
		{
			[ReadOnly]
			public NativeParallelHashMap<int2, int> MiningDamages;

			public Entity TileDamageBufferSingletonEntity;

			public BufferLookup<TileDamageBuffer> TileDamageBufferLookup;

			public void Execute()
			{
				DynamicBuffer<TileDamageBuffer> dynamicBuffer = TileDamageBufferLookup[TileDamageBufferSingletonEntity];
				NativeKeyValueArrays<int2, int> keyValueArrays = MiningDamages.GetKeyValueArrays(Allocator.Temp);
				try
				{
					for (int i = 0; i < keyValueArrays.Length; i++)
					{
						TileDamageBuffer elem = default(TileDamageBuffer);
						NativeArray<int> values = keyValueArrays.Values;
						elem.damage = values[i];
						NativeArray<int2> keys = keyValueArrays.Keys;
						elem.position = keys[i];
						elem.dontHitBridges = true;
						elem.canHitLowColliders = true;
						elem.bypassDamageReduction = true;
						elem.dontHitWalkableTiles = true;
						dynamicBuffer.Add(elem);
					}
				}
				finally
				{
					((IDisposable)keyValueArrays/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}

		[BurstCompile]
		public struct DropPlacedJob : IJob
		{
			[ReadOnly]
			public NativeParallelMultiHashMap<int2, Entity> PlacedAtPosition;

			public BufferLookup<InventoryChangeBuffer> InventoryChangeBufferLookup;

			public Entity InventoryChangeBufferEntity;

			public void Execute()
			{
				NativeKeyValueArrays<int2, Entity> keyValueArrays = PlacedAtPosition.GetKeyValueArrays(Allocator.Temp);
				try
				{
					DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = InventoryChangeBufferLookup[InventoryChangeBufferEntity];
					for (int i = 0; i < keyValueArrays.Length; i++)
					{
						InventoryChangeBuffer elem = default(InventoryChangeBuffer);
						NativeArray<Entity> values = keyValueArrays.Values;
						Entity inventory = values[i];
						NativeArray<int2> keys = keyValueArrays.Keys;
						elem.inventoryChangeData = Create.DropAllItems(inventory, keys[i].ToFloat3(), Entity.Null, randomOffset: false);
						dynamicBuffer.Add(elem);
					}
				}
				finally
				{
					((IDisposable)keyValueArrays/*cast due to .constrained prefix*/).Dispose();
				}
			}
		}

		[BurstCompile]
		[WithChangeFilter(new Type[]
		{
			typeof(ObjectFilteringCD),
			typeof(SmallEntityRefBuffer)
		})]
		[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
		public struct MoverFilterUpdateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ObjectFilteringCD> __ObjectFilteringCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SmallEntityRefBuffer> __Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__ObjectFilteringCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectFilteringCD>(isReadOnly: true);
						__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SmallEntityRefBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__ObjectFilteringCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectFilteringCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SmallEntityRefBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[2]
					{
						new ComponentType(typeof(ObjectFilteringCD)),
						new ComponentType(typeof(SmallEntityRefBuffer))
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
				public void Run(ref MoverFilterUpdateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref MoverFilterUpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref MoverFilterUpdateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref MoverFilterUpdateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref MoverFilterUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref MoverFilterUpdateJob job, EntityManager entityManager)
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

			public ComponentLookup<MoverFilterCD> MoverFilterLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in ObjectFilteringCD objectFilteringCD, in DynamicBuffer<SmallEntityRefBuffer> smallEntityRefBuffer)
			{
				for (int i = 0; i < smallEntityRefBuffer.Length; i++)
				{
					Entity value = smallEntityRefBuffer[i].Value;
					if (MoverFilterLookup.HasComponent(value))
					{
						MoverFilterLookup[value] = new MoverFilterCD
						{
							filterType = objectFilteringCD.filterType,
							filterObject = objectFilteringCD.filterObject,
							filterVariation = objectFilteringCD.filterVariation,
							filterCategory = ObjectCategoryTag.None
						};
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectFilteringCD_RO_ComponentTypeHandle);
				BufferAccessor<SmallEntityRefBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectFilteringCD>(nativeArrayPtr2, i), bufferAccessor[i]);
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectFilteringCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectFilteringCD>(nativeArrayPtr2, j), bufferAccessor[j]);
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectFilteringCD>(nativeArrayPtr2, k), bufferAccessor[k]);
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
			typeof(EnabledMoverFromSharedStateCD),
			typeof(PickupInStartOfMoveCD)
		})]
		public struct MoverMoveAndPickupJob : IJobEntity, IJobEntityChunkBeginEnd, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<MoverTimerCD> __Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoverCD> __Pug_Automation_MoverCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoverFilterCD> __Pug_Automation_MoverFilterCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoverTimerCD>();
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverCD>(isReadOnly: true);
						__Pug_Automation_MoverFilterCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverFilterCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverFilterCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoverFilterCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnabledMoverFromSharedStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PickupInStartOfMoveCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoverTimerCD>();
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
				public void Run(ref MoverMoveAndPickupJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref MoverMoveAndPickupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref MoverMoveAndPickupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref MoverMoveAndPickupJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref MoverMoveAndPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref MoverMoveAndPickupJob job, EntityManager entityManager)
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
			public NativeParallelMultiHashMap<int2, Entity> MoveeAtPosition;

			[ReadOnly]
			public NativeParallelHashMap<int2, Entity> StorageAtPosition;

			[ReadOnly]
			public TileAccessor TileLookup;

			[ReadOnly]
			public ComponentLookup<CraftingCD> CraftingLookup;

			[ReadOnly]
			public ComponentLookup<BigEntityRefCD> BigEntityLookup;

			[ReadOnly]
			public ComponentLookup<PickUpItemCD> PickUpItemLookup;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> ObjectCategoryTagsLookup;

			[ReadOnly]
			public ComponentLookup<AutomatedPlantableSeedCD> AutomatedPlantableSeedLookup;

			[ReadOnly]
			public ComponentLookup<MoverCD> MoverLookup;

			[ReadOnly]
			public BufferLookup<MoversWithSharedStateBuffer> MoversWithSharedStateBufferLookup;

			[ReadOnly]
			public BufferLookup<InventorySlotRequirementBuffer> InventorySlotRequirementsBuffers;

			[ReadOnly]
			public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> OverrideAlwaysAllowToBeTrashedLookup;

			public BufferLookup<ContainedObjectsBuffer> ContainerLookup;

			public ComponentLookup<MoveeCD> MoveeLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerCD> DeactivateSharedMoversTriggerLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerEntityCD> DeactivateSharedMoversTriggerEntityLookup;

			public ComponentLookup<MoverOrchestratorCD> MoverOrchestratorLookup;

			public PugDatabase.DatabaseBankCD DatabaseBankCD;

			private bool plantsInEndOfMove;

			public PlacementHandler.CanPlaceSharedData CanPlaceSharedData;

			public ObjectLookupCD ObjectLookupCD;

			public EntityCommandBuffer Ecb;

			public NativeReference<Unity.Mathematics.Random> rng;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public bool OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				plantsInEndOfMove = chunk.Has<PlantInEndOfMoveCD>();
				return true;
			}

			public void OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
			{
			}

			public void Execute(Entity entity, ref MoverTimerCD moverTimerCD, in MoverCD mover, in MoverFilterCD moverFilterCD)
			{
				if (moverTimerCD.timer >= 0)
				{
					return;
				}
				bool flag = IsPickUpMover(in mover);
				if ((flag && HasMoverPickedUpObject(in mover, ContainerLookup)) || DeactivateSharedMoversTriggerLookup.IsComponentEnabled(mover.moverOrchestratorEntity))
				{
					return;
				}
				bool flag2 = false;
				bool flag3 = false;
				if (MoveeAtPosition.TryGetFirstValue(mover.start, out var item, out var it))
				{
					do
					{
						Entity value = BigEntityLookup[item].Value;
						DynamicBuffer<ContainedObjectsBuffer> bufferData;
						bool flag4 = PickUpItemLookup.HasComponent(value) && ContainerLookup.TryGetBuffer(value, out bufferData) && bufferData.Length > 0 && InventoryUtility.ItemMatchesObjectFilter(bufferData[0].objectID, bufferData[0].variation, in moverFilterCD, ObjectCategoryTagsLookup, DatabaseBankCD) && InventoryUtility.PredictCanFinishMoveByMover(in mover, bufferData[0], ContainerLookup, in CanPlaceSharedData, in ObjectLookupCD, plantsInEndOfMove);
						if (!flag)
						{
							MoveeCD value2 = MoveeLookup[item];
							if (!flag4 && !flag2)
							{
								flag3 = TileLookup.TryGetBlockingTile(mover.stop, out var _);
								flag2 = true;
							}
							Unity.Mathematics.Random value3 = rng.Value;
							if ((flag4 || !flag3) && (value2.moveTimer <= 0 || value3.NextBool()))
							{
								value2.target = mover.stop;
								value2.moveTimer = MoverUtilities.CalculateMoveTimer(in mover, value2.position);
								moverTimerCD.timer = mover.cooldownTime;
								int nextCycleIncrement = 1;
								if (mover.splitsIntoOnMove > 1 && flag4)
								{
									DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffers = MoversWithSharedStateBufferLookup[mover.moverOrchestratorEntity];
									InventoryUtility.SplitItemAndDropFromMover(value, moversWithSharedStateBuffers, MoverLookup, 0, value2.position.ToFloat3(), mover.splitsIntoOnMove, in mover, ContainerLookup, Ecb, DatabaseBankCD, out var moverIncrement);
									nextCycleIncrement = moverIncrement;
								}
								DeactivateSharedMovers(mover.moverOrchestratorEntity, entity, DeactivateSharedMoversTriggerLookup, DeactivateSharedMoversTriggerEntityLookup, MoverOrchestratorLookup, nextCycleIncrement);
								MoveeLookup[item] = value2;
							}
							rng.Value = value3;
						}
						else if (flag4)
						{
							InventoryUtility.AutomatedPickup(value, mover.inventoryEntity, in mover, in moverFilterCD, plantsInEndOfMove, ContainerLookup, CraftingLookup, ObjectCategoryTagsLookup, AutomatedPlantableSeedLookup, InventorySlotRequirementsBuffers, OverrideAlwaysAllowToBeTrashedLookup, in ObjectLookupCD, DatabaseBankCD, in CanPlaceSharedData);
							if (ContainerLookup[mover.inventoryEntity][0].objectData.objectID != ObjectID.None)
							{
								moverTimerCD.timer = mover.moveTime;
								DeactivateSharedMovers(mover.moverOrchestratorEntity, entity, DeactivateSharedMoversTriggerLookup, DeactivateSharedMoversTriggerEntityLookup, MoverOrchestratorLookup, 1);
							}
						}
					}
					while (moverTimerCD.timer < 0 && MoveeAtPosition.TryGetNextValue(out item, ref it));
				}
				if (mover.allowPickupFromInventories && mover.inventoryEntity != Entity.Null && moverTimerCD.timer < 0 && StorageAtPosition.TryGetValue(mover.start, out var item2))
				{
					InventoryUtility.AutomatedPickup(item2, mover.inventoryEntity, in mover, in moverFilterCD, plantsInEndOfMove, ContainerLookup, CraftingLookup, ObjectCategoryTagsLookup, AutomatedPlantableSeedLookup, InventorySlotRequirementsBuffers, OverrideAlwaysAllowToBeTrashedLookup, in ObjectLookupCD, DatabaseBankCD, in CanPlaceSharedData);
					if (ContainerLookup[mover.inventoryEntity][0].objectData.objectID != ObjectID.None)
					{
						moverTimerCD.timer = mover.moveTime;
						DeactivateSharedMovers(mover.moverOrchestratorEntity, entity, DeactivateSharedMoversTriggerLookup, DeactivateSharedMoversTriggerEntityLookup, MoverOrchestratorLookup, 1);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				bool flag = OnChunkBegin(in chunk, chunkIndexInQuery, useEnabledMask, in chunkEnabledMask);
				if (flag)
				{
					IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
					IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle);
					IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentTypeHandle);
					IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverFilterCD_RO_ComponentTypeHandle);
					int count = chunk.Count;
					int num = 0;
					if (!useEnabledMask)
					{
						for (int i = 0; i < count; i++)
						{
							Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
							Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverFilterCD>(nativeArrayPtr4, i));
							num++;
						}
					}
					else if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
					{
						int nextRangeBegin = 0;
						int nextRangeEnd = 0;
						while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
						{
							while (nextRangeBegin < nextRangeEnd)
							{
								Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
								Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverFilterCD>(nativeArrayPtr4, nextRangeBegin));
								nextRangeBegin++;
								num++;
							}
						}
					}
					else
					{
						ulong num2 = chunkEnabledMask.ULong0;
						int num3 = math.min(64, count);
						for (int j = 0; j < num3; j++)
						{
							if ((num2 & 1) != 0L)
							{
								Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
								Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverFilterCD>(nativeArrayPtr4, j));
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
								Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverFilterCD>(nativeArrayPtr4, k));
								num++;
							}
							num2 >>= 1;
						}
					}
				}
				OnChunkEnd(in chunk, chunkIndexInQuery, useEnabledMask, in chunkEnabledMask, flag);
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

			bool IJobEntityChunkBeginEnd.OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				return OnChunkBegin(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			void IJobEntityChunkBeginEnd.OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
			{
				OnChunkEnd(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask, chunkWasExecuted);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(HarvestInStartOfMoveCD),
			typeof(EnabledMoverFromSharedStateCD)
		})]
		private struct MoverHarvestJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<MoverTimerCD> __Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoverCD> __Pug_Automation_MoverCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoverTimerCD>();
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<HarvestInStartOfMoveCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnabledMoverFromSharedStateCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoverTimerCD>();
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
				public void Run(ref MoverHarvestJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref MoverHarvestJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref MoverHarvestJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref MoverHarvestJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref MoverHarvestJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref MoverHarvestJob job, EntityManager entityManager)
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

			public BufferLookup<ContainedObjectsBuffer> ContainerLookup;

			[ReadOnly]
			public ComponentLookup<PlantCD> PlantLookup;

			public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

			public ComponentLookup<DontDropLootCD> DontDropLootLookup;

			public ComponentLookup<DontDropSelfCD> DontDropSelfLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerCD> DeactivateSharedMoversTriggerLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerEntityCD> DeactivateSharedMoversTriggerEntityLookup;

			public ComponentLookup<MoverOrchestratorCD> MoverOrchestratorLookup;

			[ReadOnly]
			public ComponentLookup<HasFinishedGrowingCD> HasFinishedGrowingLookup;

			[ReadOnly]
			public ComponentLookup<PugAutomationCD> PugAutomationLookup;

			[ReadOnly]
			public ObjectLookupCD ObjectLookupCD;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref MoverTimerCD moverTimerCD, in MoverCD mover)
			{
				if (moverTimerCD.timer >= 0 || (IsPickUpMover(in mover) && HasMoverPickedUpObject(in mover, ContainerLookup)) || DeactivateSharedMoversTriggerLookup.IsComponentEnabled(mover.moverOrchestratorEntity))
				{
					return;
				}
				NativeList<ObjectLookupEntry> objects = ObjectLookupCD.lookup.GetObjects(mover.start, Allocator.Temp);
				for (int i = 0; i < objects.Length; i++)
				{
					Entity optionalEntityIfLoaded = objects[i].optionalEntityIfLoaded;
					if (!(optionalEntityIfLoaded == Entity.Null) && PugAutomationLookup.TryGetComponent(optionalEntityIfLoaded, out var componentData) && (componentData.type & AutomationType.HarvestablePlant) != AutomationType.None && InventoryUtility.AutomatedHarvest(ContainerLookup, PlantLookup, HasFinishedGrowingLookup, EntityDestroyedLookup, DontDropLootLookup, DontDropSelfLookup, optionalEntityIfLoaded, mover.inventoryEntity) && ContainerLookup[mover.inventoryEntity][0].objectData.objectID != ObjectID.None)
					{
						moverTimerCD.timer = mover.moveTime;
						DeactivateSharedMovers(mover.moverOrchestratorEntity, entity, DeactivateSharedMoversTriggerLookup, DeactivateSharedMoversTriggerEntityLookup, MoverOrchestratorLookup, 1);
						break;
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverTimerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverTimerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverCD>(nativeArrayPtr3, k));
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
		public struct DeactivateSharedMoversOnMoverOrPickupJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<DeactivateSharedMoversTriggerCD> __Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<MoverOrchestratorCD> __Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DeactivateSharedMoversTriggerEntityCD> __Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<MoversWithSharedStateBuffer> __Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DeactivateSharedMoversTriggerCD>();
						__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoverOrchestratorCD>();
						__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DeactivateSharedMoversTriggerEntityCD>(isReadOnly: true);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MoversWithSharedStateBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DeactivateSharedMoversTriggerEntityCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoversWithSharedStateBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DeactivateSharedMoversTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoverOrchestratorCD>();
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
				public void Run(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityManager entityManager)
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

			public ComponentLookup<EnabledMoverFromSharedStateCD> ActiveMoverFromSharedStateLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(EnabledRefRW<DeactivateSharedMoversTriggerCD> deactivateSharedMoversTriggerEnabledRW, ref MoverOrchestratorCD moverOrchestrator, in DeactivateSharedMoversTriggerEntityCD deactivateSharedMoversTriggerEntityCD, in DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer)
			{
				deactivateSharedMoversTriggerEnabledRW.ValueRW = false;
				for (int i = 0; i < moversWithSharedStateBuffer.Length; i++)
				{
					if (moversWithSharedStateBuffer[i].moverEntity == deactivateSharedMoversTriggerEntityCD.Entity)
					{
						moverOrchestrator.enabledMoverIndex = i;
					}
					else
					{
						ActiveMoverFromSharedStateLookup.SetComponentEnabled(moversWithSharedStateBuffer[i].moverEntity, value: false);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverOrchestratorCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RO_ComponentTypeHandle);
				BufferAccessor<MoversWithSharedStateBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ref MoverOrchestratorCD moverOrchestrator = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, i);
						ref DeactivateSharedMoversTriggerEntityCD deactivateSharedMoversTriggerEntityCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DeactivateSharedMoversTriggerEntityCD>(nativeArrayPtr2, i);
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer = bufferAccessor[i];
						Execute(enabledMask.GetEnabledRefRW<DeactivateSharedMoversTriggerCD>(i), ref moverOrchestrator, in deactivateSharedMoversTriggerEntityCD, in moversWithSharedStateBuffer);
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
							ref MoverOrchestratorCD moverOrchestrator2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, nextRangeBegin);
							ref DeactivateSharedMoversTriggerEntityCD deactivateSharedMoversTriggerEntityCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DeactivateSharedMoversTriggerEntityCD>(nativeArrayPtr2, nextRangeBegin);
							DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer2 = bufferAccessor[nextRangeBegin];
							Execute(enabledMask.GetEnabledRefRW<DeactivateSharedMoversTriggerCD>(nextRangeBegin), ref moverOrchestrator2, in deactivateSharedMoversTriggerEntityCD2, in moversWithSharedStateBuffer2);
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
						ref MoverOrchestratorCD moverOrchestrator3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, j);
						ref DeactivateSharedMoversTriggerEntityCD deactivateSharedMoversTriggerEntityCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DeactivateSharedMoversTriggerEntityCD>(nativeArrayPtr2, j);
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer3 = bufferAccessor[j];
						Execute(enabledMask.GetEnabledRefRW<DeactivateSharedMoversTriggerCD>(j), ref moverOrchestrator3, in deactivateSharedMoversTriggerEntityCD3, in moversWithSharedStateBuffer3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ref MoverOrchestratorCD moverOrchestrator4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, k);
						ref DeactivateSharedMoversTriggerEntityCD deactivateSharedMoversTriggerEntityCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DeactivateSharedMoversTriggerEntityCD>(nativeArrayPtr2, k);
						DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer4 = bufferAccessor[k];
						Execute(enabledMask.GetEnabledRefRW<DeactivateSharedMoversTriggerCD>(k), ref moverOrchestrator4, in deactivateSharedMoversTriggerEntityCD4, in moversWithSharedStateBuffer4);
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
		public struct SetNewMoveePositionJob : IJob
		{
			[ReadOnly]
			public NativeParallelMultiHashMap<int2, Entity> MoveeAtPosition;

			[ReadOnly]
			public ComponentLookup<BigEntityRefCD> BigEntityLookup;

			[ReadOnly]
			public ComponentLookup<BigEntityIsEnabledCD> BigEntityIsEnabledLookup;

			[ReadOnly]
			public ComponentLookup<MoveeCD> MoveeLookup;

			public ComponentLookup<LocalTransform> LocalTransformLookup;

			public void Execute()
			{
				using NativeArray<Entity> nativeArray = MoveeAtPosition.GetValueArray(Allocator.Temp);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					Entity entity = nativeArray[i];
					if (BigEntityIsEnabledLookup.IsComponentEnabled(entity))
					{
						continue;
					}
					Entity value = BigEntityLookup[entity].Value;
					if (LocalTransformLookup.TryGetComponent(value, out var componentData))
					{
						MoveeCD moveeCD = MoveeLookup[nativeArray[i]];
						if (!(math.distancesq(componentData.Position.ToFloat2(), moveeCD.position) > 100f))
						{
							LocalTransformLookup[value] = LocalTransform.FromPosition(moveeCD.position.ToFloat3());
						}
					}
				}
			}
		}

		[BurstCompile]
		private struct UpdateMoveeBigEntityJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MoveeCD> __Pug_Automation_MoveeCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
						__Pug_Automation_MoveeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoveeCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoveeCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BigEntityRefCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoveeCD>();
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
				public void Run(ref UpdateMoveeBigEntityJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateMoveeBigEntityJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateMoveeBigEntityJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateMoveeBigEntityJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateMoveeBigEntityJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateMoveeBigEntityJob job, EntityManager entityManager)
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

			public ComponentLookup<MoveeBigEntityCD> MoveeBigEntityLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(in BigEntityRefCD bigEntityRefCD, in MoveeCD moveeCD)
			{
				if (MoveeBigEntityLookup.TryGetComponent(bigEntityRefCD.Value, out var componentData) && (componentData.moveTimer != moveeCD.moveTimer || !math.all(componentData.target == moveeCD.target)))
				{
					MoveeBigEntityLookup[bigEntityRefCD.Value] = new MoveeBigEntityCD
					{
						moveTimer = moveeCD.moveTimer,
						target = moveeCD.target
					};
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoveeCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveeCD>(nativeArrayPtr2, k));
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
		[WithChangeFilter(new Type[] { typeof(MoverOrchestratorCD) })]
		private struct UpdateSyncedOrchestratorFieldsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MoverOrchestratorCD> __Pug_Automation_MoverOrchestratorCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<MoversWithSharedStateBuffer> __Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Pug_Automation_MoverOrchestratorCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoverOrchestratorCD>(isReadOnly: true);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<MoversWithSharedStateBuffer>(isReadOnly: true);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BigEntityRefCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Pug_Automation_MoverOrchestratorCD_RO_ComponentTypeHandle.Update(ref state);
						__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle.Update(ref state);
						__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MoverOrchestratorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoversWithSharedStateBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BigEntityRefCD>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
					{
						new ComponentType(typeof(MoverOrchestratorCD))
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
				public void Run(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateSyncedOrchestratorFieldsJob job, EntityManager entityManager)
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

			public ComponentLookup<PugAutomationEnabledMoverSyncedCD> PugAutomationMoverOrchestratorSyncedLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MoverOrchestratorCD orchestrator, in DynamicBuffer<MoversWithSharedStateBuffer> movers, in BigEntityRefCD bigEntityRef)
			{
				if (PugAutomationMoverOrchestratorSyncedLookup.TryGetComponent(bigEntityRef.Value, out var componentData))
				{
					sbyte moverIndex = componentData.moverIndex;
					int nextMoverCycleIncrement = componentData.nextMoverCycleIncrement;
					if (moverIndex != orchestrator.enabledMoverIndex || nextMoverCycleIncrement != orchestrator.nextMoverCycleIncrement)
					{
						PugAutomationMoverOrchestratorSyncedLookup[bigEntityRef.Value] = new PugAutomationEnabledMoverSyncedCD
						{
							moverIndex = (sbyte)orchestrator.enabledMoverIndex,
							moveVector = ((orchestrator.enabledMoverIndex >= 0) ? movers[orchestrator.enabledMoverIndex].cachedDirection : int2.zero),
							nextMoverCycleIncrement = orchestrator.nextMoverCycleIncrement
						};
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_MoverOrchestratorCD_RO_ComponentTypeHandle);
				BufferAccessor<MoversWithSharedStateBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoverOrchestratorCD>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BigEntityRefCD>(nativeArrayPtr2, k));
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
			public BufferTypeHandle<SmallEntityRefBuffer> __Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle;

			public ComponentLookup<BigEntityIsEnabledCD> __Pug_Automation_BigEntityIsEnabledCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<PlantInEndOfMoveCD> __Pug_Automation_PlantInEndOfMoveCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DropInEndOfMoveCD> __Pug_Automation_DropInEndOfMoveCD_RO_ComponentLookup;

			public ComponentLookup<PlantTriggerCD> __Pug_Automation_PlantTriggerCD_RW_ComponentLookup;

			public ComponentLookup<EnableSharedMoversTriggerCD> __Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentLookup;

			public ComponentLookup<CycleEnabledMoversTriggerCD> __Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentLookup;

			public UpdateMoverTimerJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<EnabledMoverFromSharedStateCD> __Pug_Automation_EnabledMoverFromSharedStateCD_RW_ComponentLookup;

			public CycleEnabledMoversJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle;

			public EnableSharedMoversJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<PhysicsDamping> __Unity_Physics_PhysicsDamping_RO_ComponentLookup;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			public ComponentLookup<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentLookup;

			public UpdateEnabledMoveeJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle;

			public UpdateDisabledMoveeJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<BigEntityRefCD> __Pug_Automation_BigEntityRefCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PickUpItemCD> __PickUpItemCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public MoveeMergeJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

			public ComponentLookup<PlantCD> __PlantCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CritterCD> __CritterCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<FireflyCD> __FireflyCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<RequiresDrillCD> __RequiresDrillCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<EventTerminalCD> __EventTerminalCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PseudoTileCD> __PseudoTileCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WayPointCD> __WayPointCD_RO_ComponentLookup;

			public PlantJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle;

			public PlanterCheckPlantStateChangedJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle;

			public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

			[ReadOnly]
			public BufferLookup<InventoryBuffer> __InventoryBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<CraftingCD> __CraftingCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<InventorySlotRequirementBuffer> __InventorySlotRequirementBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> __OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup;

			public PlaceInStorageJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<StorageCD> __Pug_Automation_StorageCD_RO_ComponentLookup;

			public StorageChangeCheckJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle;

			public UpdateMinerJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<MineableDamageDecreaseCD> __Pug_Automation_MineableDamageDecreaseCD_RW_ComponentLookup;

			public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

			public MiningMineablesJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle;

			public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

			public ComponentLookup<MoverFilterCD> __Pug_Automation_MoverFilterCD_RW_ComponentLookup;

			public MoverFilterUpdateJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<AutomatedPlantableSeedCD> __Pug_Automation_AutomatedPlantableSeedCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoverCD> __Pug_Automation_MoverCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<MoversWithSharedStateBuffer> __Pug_Automation_MoversWithSharedStateBuffer_RO_BufferLookup;

			public ComponentLookup<MoveeCD> __Pug_Automation_MoveeCD_RW_ComponentLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerCD> __Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentLookup;

			public ComponentLookup<DeactivateSharedMoversTriggerEntityCD> __Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RW_ComponentLookup;

			public ComponentLookup<MoverOrchestratorCD> __Pug_Automation_MoverOrchestratorCD_RW_ComponentLookup;

			public MoverMoveAndPickupJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<PlantCD> __PlantCD_RO_ComponentLookup;

			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

			public ComponentLookup<DontDropLootCD> __DontDropLootCD_RW_ComponentLookup;

			public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<HasFinishedGrowingCD> __HasFinishedGrowingCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentLookup;

			public MoverHarvestJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle;

			public DeactivateSharedMoversOnMoverOrPickupJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<BigEntityIsEnabledCD> __Pug_Automation_BigEntityIsEnabledCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoveeCD> __Pug_Automation_MoveeCD_RO_ComponentLookup;

			public ComponentLookup<MoveeBigEntityCD> __Pug_Automation_MoveeBigEntityCD_RW_ComponentLookup;

			public UpdateMoveeBigEntityJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<PugAutomationEnabledMoverSyncedCD> __Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup;

			public UpdateSyncedOrchestratorFieldsJob.InternalCompilerQueryAndHandleData __Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SmallEntityRefBuffer>(isReadOnly: true);
				__Pug_Automation_BigEntityIsEnabledCD_RW_ComponentLookup = state.GetComponentLookup<BigEntityIsEnabledCD>();
				__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
				__Pug_Automation_PlantInEndOfMoveCD_RO_ComponentLookup = state.GetComponentLookup<PlantInEndOfMoveCD>(isReadOnly: true);
				__Pug_Automation_DropInEndOfMoveCD_RO_ComponentLookup = state.GetComponentLookup<DropInEndOfMoveCD>(isReadOnly: true);
				__Pug_Automation_PlantTriggerCD_RW_ComponentLookup = state.GetComponentLookup<PlantTriggerCD>();
				__Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentLookup = state.GetComponentLookup<EnableSharedMoversTriggerCD>();
				__Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentLookup = state.GetComponentLookup<CycleEnabledMoversTriggerCD>();
				__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_EnabledMoverFromSharedStateCD_RW_ComponentLookup = state.GetComponentLookup<EnabledMoverFromSharedStateCD>();
				__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Unity_Physics_PhysicsDamping_RO_ComponentLookup = state.GetComponentLookup<PhysicsDamping>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__Unity_Physics_PhysicsVelocity_RW_ComponentLookup = state.GetComponentLookup<PhysicsVelocity>();
				__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_BigEntityRefCD_RO_ComponentLookup = state.GetComponentLookup<BigEntityRefCD>(isReadOnly: true);
				__PickUpItemCD_RO_ComponentLookup = state.GetComponentLookup<PickUpItemCD>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
				__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
				__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
				__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
				__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
				__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
				__PlantCD_RW_ComponentLookup = state.GetComponentLookup<PlantCD>();
				__CritterCD_RO_ComponentLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
				__FireflyCD_RO_ComponentLookup = state.GetComponentLookup<FireflyCD>(isReadOnly: true);
				__RequiresDrillCD_RO_ComponentLookup = state.GetComponentLookup<RequiresDrillCD>(isReadOnly: true);
				__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
				__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
				__EventTerminalCD_RO_ComponentLookup = state.GetComponentLookup<EventTerminalCD>(isReadOnly: true);
				__PseudoTileCD_RO_ComponentLookup = state.GetComponentLookup<PseudoTileCD>(isReadOnly: true);
				__WayPointCD_RO_ComponentLookup = state.GetComponentLookup<WayPointCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
				__InventoryBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
				__CraftingCD_RO_ComponentLookup = state.GetComponentLookup<CraftingCD>(isReadOnly: true);
				__InventorySlotRequirementBuffer_RO_BufferLookup = state.GetBufferLookup<InventorySlotRequirementBuffer>(isReadOnly: true);
				__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
				__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup = state.GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_StorageCD_RO_ComponentLookup = state.GetComponentLookup<StorageCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_MineableDamageDecreaseCD_RW_ComponentLookup = state.GetComponentLookup<MineableDamageDecreaseCD>();
				__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
				__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
				__Pug_Automation_MoverFilterCD_RW_ComponentLookup = state.GetComponentLookup<MoverFilterCD>();
				__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_AutomatedPlantableSeedCD_RO_ComponentLookup = state.GetComponentLookup<AutomatedPlantableSeedCD>(isReadOnly: true);
				__Pug_Automation_MoverCD_RO_ComponentLookup = state.GetComponentLookup<MoverCD>(isReadOnly: true);
				__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferLookup = state.GetBufferLookup<MoversWithSharedStateBuffer>(isReadOnly: true);
				__Pug_Automation_MoveeCD_RW_ComponentLookup = state.GetComponentLookup<MoveeCD>();
				__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentLookup = state.GetComponentLookup<DeactivateSharedMoversTriggerCD>();
				__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RW_ComponentLookup = state.GetComponentLookup<DeactivateSharedMoversTriggerEntityCD>();
				__Pug_Automation_MoverOrchestratorCD_RW_ComponentLookup = state.GetComponentLookup<MoverOrchestratorCD>();
				__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PlantCD_RO_ComponentLookup = state.GetComponentLookup<PlantCD>(isReadOnly: true);
				__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
				__DontDropLootCD_RW_ComponentLookup = state.GetComponentLookup<DontDropLootCD>();
				__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
				__HasFinishedGrowingCD_RO_ComponentLookup = state.GetComponentLookup<HasFinishedGrowingCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_BigEntityIsEnabledCD_RO_ComponentLookup = state.GetComponentLookup<BigEntityIsEnabledCD>(isReadOnly: true);
				__Pug_Automation_MoveeCD_RO_ComponentLookup = state.GetComponentLookup<MoveeCD>(isReadOnly: true);
				__Pug_Automation_MoveeBigEntityCD_RW_ComponentLookup = state.GetComponentLookup<MoveeBigEntityCD>();
				__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup = state.GetComponentLookup<PugAutomationEnabledMoverSyncedCD>();
				__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000288_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000288_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000288_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00000289_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000289_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000289_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_0000028A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_0000028A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000028A_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
		internal delegate void __codegen__OnStartRunning_0000028B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_0000028B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000028B_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
		internal delegate void __codegen__OnStopRunning_0000028C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_0000028C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000028C_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

		private TileAccessor _tileAccessor;

		private NativeReference<Unity.Mathematics.Random> _rnd;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1171083638_0;

		private EntityQuery __query_1171083638_1;

		private EntityQuery __query_1171083638_2;

		private EntityQuery __query_1171083638_3;

		private EntityQuery __query_1171083638_4;

		private EntityQuery __query_1171083638_5;

		private EntityQuery __query_1171083638_6;

		private EntityQuery __query_1171083638_7;

		private EntityQuery __query_1171083638_8;

		private EntityQuery __query_1171083638_9;

		private EntityQuery __query_1171083638_10;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<HealthChangeBuffer>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<TileDamageBuffer>();
			state.RequireForUpdate<ObjectLookupCD>();
			_rnd = new NativeReference<Unity.Mathematics.Random>(Allocator.Persistent);
			_rnd.Value = PugRandom.GetRng();
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
			if (_rnd.IsCreated)
			{
				_rnd.Dispose();
			}
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
			EntityCommandBuffer entityCommandBuffer = __query_1171083638_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_1171083638_2.TryGetSingleton<NetworkTime>(out var value);
			NetworkTick serverTick = value.ServerTick;
			NativeHashSet<int2> newMovers = new NativeHashSet<int2>(1024, state.WorldUpdateAllocator);
			NativeParallelMultiHashMap<int2, Entity> moveeAtPosition = new NativeParallelMultiHashMap<int2, Entity>(1024, state.WorldUpdateAllocator);
			NativeParallelMultiHashMap<int2, Entity> placedAtPosition = new NativeParallelMultiHashMap<int2, Entity>(1024, state.WorldUpdateAllocator);
			NativeParallelHashMap<int2, Entity> storageAtPosition = new NativeParallelHashMap<int2, Entity>(1024, state.WorldUpdateAllocator);
			NativeParallelHashMap<int2, int> miningDamages = new NativeParallelHashMap<int2, int>(1024, state.WorldUpdateAllocator);
			_tileAccessor.Update(ref state);
			bool simulationDisabled = __query_1171083638_3.GetSingleton<WorldInfoCD>().simulationDisabled;
			__query_1171083638_4.TryGetSingleton<ClientServerTickRate>(out var value2);
			value2.ResolveDefaults();
			int simulationTickRate = value2.SimulationTickRate;
			UpdateBigEntityIsDisabledJob jobData = new UpdateBigEntityIsDisabledJob
			{
				LastSystemVersion = state.LastSystemVersion,
				SmallEntityRefBufferHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Pug_Automation_SmallEntityRefBuffer_RO_BufferTypeHandle, ref state),
				BigEntityIsEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityIsEnabledCD_RW_ComponentLookup, ref state)
			};
			EntityQuery _query_1171083638_ = __query_1171083638_0;
			state.Dependency = JobChunkExtensions.ScheduleByRef(ref jobData, _query_1171083638_, state.Dependency);
			if (!simulationDisabled)
			{
				UpdateMoverTimerJob job = new UpdateMoverTimerJob
				{
					PlacedAtPosition = placedAtPosition,
					ContainerLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
					PlantInEndOfMoveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PlantInEndOfMoveCD_RO_ComponentLookup, ref state),
					DropInEndOfMoveLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_DropInEndOfMoveCD_RO_ComponentLookup, ref state),
					PlantTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PlantTriggerCD_RW_ComponentLookup, ref state),
					EnableSharedMoversTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_EnableSharedMoversTriggerCD_RW_ComponentLookup, ref state),
					cycleEnabledMoversTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_CycleEnabledMoversTriggerCD_RW_ComponentLookup, ref state)
				};
				state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				CycleEnabledMoversJob job2 = new CycleEnabledMoversJob
				{
					EnabledMoverFromSharedStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_EnabledMoverFromSharedStateCD_RW_ComponentLookup, ref state),
					NewMovers = newMovers
				};
				state.Dependency = __ScheduleViaJobChunkExtension_1(ref job2, __TypeHandle.__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				EnableSharedMoversJob job3 = new EnableSharedMoversJob
				{
					NewMovers = newMovers,
					ActiveMoverFromSharedStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_EnabledMoverFromSharedStateCD_RW_ComponentLookup, ref state)
				};
				state.Dependency = __ScheduleViaJobChunkExtension_2(ref job3, __TypeHandle.__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				UpdateEnabledMoveeJob job4 = new UpdateEnabledMoveeJob
				{
					DeltaTime = deltaTime,
					MoveeAtPosition = moveeAtPosition,
					PhysicsDampingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsDamping_RO_ComponentLookup, ref state),
					LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
					PhysicsVelocityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentLookup, ref state)
				};
				state.Dependency = __ScheduleViaJobChunkExtension_3(ref job4, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
				UpdateDisabledMoveeJob job5 = new UpdateDisabledMoveeJob
				{
					MoveeAtPosition = moveeAtPosition,
					NewMovers = newMovers
				};
				state.Dependency = __ScheduleViaJobChunkExtension_4(ref job5, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
			MoveeMergeJob job6 = new MoveeMergeJob
			{
				MoveeAtPosition = moveeAtPosition,
				BigEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentLookup, ref state),
				PickUpObjectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PickUpItemCD_RO_ComponentLookup, ref state),
				EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				InventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				InventoryChangeBufferEntity = __query_1171083638_5.GetSingletonEntity()
			};
			state.Dependency = __ScheduleViaJobChunkExtension_5(ref job6, __TypeHandle.__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			PlacementHandler.CanPlaceSharedData canPlaceSharedData = new PlacementHandler.CanPlaceSharedData
			{
				objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
				tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
				objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
				playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				minionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref state),
				indestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
				plantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RW_ComponentLookup, ref state),
				critterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state),
				fireflyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FireflyCD_RO_ComponentLookup, ref state),
				requiresDrillLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RequiresDrillCD_RO_ComponentLookup, ref state),
				surfacePriorityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref state),
				electricityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state),
				eventTerminalLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EventTerminalCD_RO_ComponentLookup, ref state),
				pseudoTileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PseudoTileCD_RO_ComponentLookup, ref state),
				waypointLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WayPointCD_RO_ComponentLookup, ref state),
				databaseBank = __query_1171083638_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
				tileAccessor = _tileAccessor,
				tileWithTilesetToObjectDataMapCD = __query_1171083638_7.GetSingleton<TileWithTilesetToObjectDataMapCD>()
			};
			PlantJob job7 = new PlantJob
			{
				ContainerLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				CanPlaceSharedData = canPlaceSharedData,
				InventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				InventoryChangeBufferEntity = __query_1171083638_5.GetSingletonEntity(),
				ObjectLookupCD = __query_1171083638_8.GetSingleton<ObjectLookupCD>(),
				PlacedObjectAtPositionThisTickMap = new NativeHashSet<int2>(1024, state.WorldUpdateAllocator),
				rnd = _rnd
			};
			state.Dependency = __ScheduleViaJobChunkExtension_6(ref job7, __TypeHandle.__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			NativeHashSet<int2> activePlanterMovers = new NativeHashSet<int2>(1024, state.WorldUpdateAllocator);
			state.Dependency = __ScheduleViaJobChunkExtension_7(new PlanterCheckPlantStateChangedJob
			{
				ActivePlanterMovers = activePlanterMovers
			}, __TypeHandle.__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			PlaceInStorageJob job8 = new PlaceInStorageJob
			{
				GlobalSystemVersion = state.GlobalSystemVersion,
				ECB = entityCommandBuffer,
				NewMovers = newMovers,
				ActivePlanterMovers = activePlanterMovers,
				StorageAtPosition = storageAtPosition,
				PlacedAtPosition = placedAtPosition,
				DatabaseBankCD = __query_1171083638_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
				ContainerLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
				InventoryLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
				CraftingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CraftingCD_RO_ComponentLookup, ref state),
				RequirementsBuffers = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventorySlotRequirementBuffer_RO_BufferLookup, ref state),
				TagLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
				OverrideAlwaysAllowToBeTrashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup, ref state),
				InventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				InventoryChangeBufferEntity = __query_1171083638_5.GetSingletonEntity()
			};
			state.Dependency = __ScheduleViaJobChunkExtension_8(ref job8, __TypeHandle.__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			StorageChangeCheckJob job9 = new StorageChangeCheckJob
			{
				StorageAtPosition = storageAtPosition,
				StorageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_StorageCD_RO_ComponentLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_9(job9, __TypeHandle.__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			UpdateMinerJob job10 = new UpdateMinerJob
			{
				MiningDamages = miningDamages
			};
			state.Dependency = __ScheduleViaJobChunkExtension_10(ref job10, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			MiningMineablesJob job11 = new MiningMineablesJob
			{
				ServerTick = serverTick,
				TickRate = simulationTickRate,
				MiningDamages = miningDamages,
				MineableDamageDecreaseLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MineableDamageDecreaseCD_RW_ComponentLookup, ref state),
				HealthChangeBufferEntity = __query_1171083638_9.GetSingletonEntity(),
				HealthChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_11(ref job11, __TypeHandle.__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			ApplyTileDamageJob jobData2 = new ApplyTileDamageJob
			{
				MiningDamages = miningDamages,
				TileDamageBufferSingletonEntity = __query_1171083638_10.GetSingletonEntity(),
				TileDamageBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref state)
			};
			state.Dependency = IJobExtensions.ScheduleByRef(ref jobData2, state.Dependency);
			DropPlacedJob jobData3 = new DropPlacedJob
			{
				PlacedAtPosition = placedAtPosition,
				InventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				InventoryChangeBufferEntity = __query_1171083638_5.GetSingletonEntity()
			};
			state.Dependency = IJobExtensions.ScheduleByRef(ref jobData3, state.Dependency);
			state.Dependency = __ScheduleViaJobChunkExtension_12(new MoverFilterUpdateJob
			{
				MoverFilterLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoverFilterCD_RW_ComponentLookup, ref state)
			}, __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			MoverMoveAndPickupJob job12 = new MoverMoveAndPickupJob
			{
				MoveeAtPosition = moveeAtPosition,
				StorageAtPosition = storageAtPosition,
				TileLookup = _tileAccessor,
				CraftingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CraftingCD_RO_ComponentLookup, ref state),
				BigEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentLookup, ref state),
				PickUpItemLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PickUpItemCD_RO_ComponentLookup, ref state),
				ObjectCategoryTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
				AutomatedPlantableSeedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_AutomatedPlantableSeedCD_RO_ComponentLookup, ref state),
				MoverLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoverCD_RO_ComponentLookup, ref state),
				MoversWithSharedStateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Pug_Automation_MoversWithSharedStateBuffer_RO_BufferLookup, ref state),
				InventorySlotRequirementsBuffers = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventorySlotRequirementBuffer_RO_BufferLookup, ref state),
				OverrideAlwaysAllowToBeTrashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup, ref state),
				ContainerLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
				MoveeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoveeCD_RW_ComponentLookup, ref state),
				DeactivateSharedMoversTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentLookup, ref state),
				DeactivateSharedMoversTriggerEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RW_ComponentLookup, ref state),
				MoverOrchestratorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoverOrchestratorCD_RW_ComponentLookup, ref state),
				DatabaseBankCD = __query_1171083638_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
				CanPlaceSharedData = canPlaceSharedData,
				ObjectLookupCD = __query_1171083638_8.GetSingleton<ObjectLookupCD>(),
				Ecb = entityCommandBuffer,
				rng = _rnd
			};
			state.Dependency = __ScheduleViaJobChunkExtension_13(ref job12, __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			MoverHarvestJob job13 = new MoverHarvestJob
			{
				ContainerLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
				PlantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RO_ComponentLookup, ref state),
				EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
				DontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref state),
				DontDropSelfLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref state),
				DeactivateSharedMoversTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerCD_RW_ComponentLookup, ref state),
				DeactivateSharedMoversTriggerEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_DeactivateSharedMoversTriggerEntityCD_RW_ComponentLookup, ref state),
				MoverOrchestratorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoverOrchestratorCD_RW_ComponentLookup, ref state),
				HasFinishedGrowingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasFinishedGrowingCD_RO_ComponentLookup, ref state),
				PugAutomationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentLookup, ref state),
				ObjectLookupCD = __query_1171083638_8.GetSingleton<ObjectLookupCD>()
			};
			state.Dependency = __ScheduleViaJobChunkExtension_14(ref job13, __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			DeactivateSharedMoversOnMoverOrPickupJob job14 = new DeactivateSharedMoversOnMoverOrPickupJob
			{
				ActiveMoverFromSharedStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_EnabledMoverFromSharedStateCD_RW_ComponentLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_15(ref job14, __TypeHandle.__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			SetNewMoveePositionJob jobData4 = new SetNewMoveePositionJob
			{
				MoveeAtPosition = moveeAtPosition,
				BigEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityRefCD_RO_ComponentLookup, ref state),
				BigEntityIsEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityIsEnabledCD_RO_ComponentLookup, ref state),
				MoveeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoveeCD_RO_ComponentLookup, ref state),
				LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state)
			};
			state.Dependency = IJobExtensions.ScheduleByRef(ref jobData4, state.Dependency);
			state.Dependency = __ScheduleViaJobChunkExtension_16(new UpdateMoveeBigEntityJob
			{
				MoveeBigEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoveeBigEntityCD_RW_ComponentLookup, ref state)
			}, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			UpdateSyncedOrchestratorFieldsJob job15 = new UpdateSyncedOrchestratorFieldsJob
			{
				PugAutomationMoverOrchestratorSyncedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_17(ref job15, __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsPickUpMover(in MoverCD mover)
		{
			return mover.inventoryEntity != Entity.Null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool HasMoverPickedUpObject(in MoverCD mover, BufferLookup<ContainedObjectsBuffer> ContainerLookup)
		{
			return ContainerLookup[mover.inventoryEntity][0].objectData.objectID != ObjectID.None;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void DeactivateSharedMovers(Entity orchestratorEntity, Entity triggeredMoverEntity, ComponentLookup<DeactivateSharedMoversTriggerCD> deactivateSharedMoversTriggerLookup, ComponentLookup<DeactivateSharedMoversTriggerEntityCD> deactivateSharedMoversTriggerEntityLookup, ComponentLookup<MoverOrchestratorCD> moverOrchestratorLookup, int nextCycleIncrement)
		{
			deactivateSharedMoversTriggerLookup.SetComponentEnabled(orchestratorEntity, value: true);
			deactivateSharedMoversTriggerEntityLookup.GetRefRW(orchestratorEntity).ValueRW.Entity = triggeredMoverEntity;
			moverOrchestratorLookup.GetRefRW(orchestratorEntity).ValueRW.nextMoverCycleIncrement = nextCycleIncrement;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ref UpdateMoverTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoverTimerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(ref CycleEnabledMoversJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_CycleEnabledMoversJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(ref EnableSharedMoversJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_EnableSharedMoversJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_3(ref UpdateEnabledMoveeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateEnabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_4(ref UpdateDisabledMoveeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateDisabledMoveeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_5(ref MoveeMergeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_MoveeMergeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_6(ref PlantJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_PlantJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_7(PlanterCheckPlantStateChangedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_PlanterCheckPlantStateChangedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_8(ref PlaceInStorageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_PlaceInStorageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_9(StorageChangeCheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_StorageChangeCheckJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_10(ref UpdateMinerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMinerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_11(ref MiningMineablesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_MiningMineablesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_12(MoverFilterUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverFilterUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_13(ref MoverMoveAndPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverMoveAndPickupJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_14(ref MoverHarvestJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_MoverHarvestJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_15(ref DeactivateSharedMoversOnMoverOrPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_DeactivateSharedMoversOnMoverOrPickupJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_16(UpdateMoveeBigEntityJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateMoveeBigEntityJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_17(ref UpdateSyncedOrchestratorFieldsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Pug_Automation_PugAutomationSystem_UpdateSyncedOrchestratorFieldsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_1171083638_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TileWithTilesetToObjectDataMapCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectLookupCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_9 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1171083638_10 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00000288_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000289_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_0000028A_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_0000028B_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_0000028C_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
