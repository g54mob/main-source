using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Physics.GraphicsIntegration;

namespace FixedTickInterpolation
{
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	[UpdateInGroup(typeof(FixedTickInterpolationSmoothingSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct FixedTickInterpolationSmoothingSystem<T, D, E> : ISystem, ISystemCompilerGenerated where T : unmanaged, IFixedInterpolatedStateData<E, D> where D : unmanaged, IFixedInterpolatedSmoothedData where E : unmanaged, IComponentData
	{
		[BurstCompile]
		public struct SmoothJob : IJobChunk
		{
			public ComponentTypeHandle<D> SmoothedType;

			[ReadOnly]
			public ComponentTypeHandle<T> InterpolationStateType;

			[ReadOnly]
			public BufferLookup<MostRecentFixedTime> MostRecentFixedTime;

			[ReadOnly]
			public SharedComponentTypeHandle<PhysicsWorldIndex> PhysicsWorldIndex;

			public Entity MostRecentFixedTimeEntity;

			public double ElapsedTime;

			public int PhysicsTicksToInterpolate;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				int value = (int)chunk.GetSharedComponent(PhysicsWorldIndex).Value;
				DynamicBuffer<MostRecentFixedTime> dynamicBuffer = MostRecentFixedTime[MostRecentFixedTimeEntity];
				if (dynamicBuffer.Length <= value)
				{
					return;
				}
				MostRecentFixedTime mostRecentFixedTime = dynamicBuffer[value];
				float num = (float)(ElapsedTime - mostRecentFixedTime.ElapsedTime);
				float num2 = (float)mostRecentFixedTime.DeltaTime;
				if (!(num < 0f) && num2 != 0f)
				{
					float normalizedTimeAhead = math.clamp(num / num2, 0f, 1f);
					NativeArray<D> nativeArray = chunk.GetNativeArray(SmoothedType);
					NativeArray<T> nativeArray2 = chunk.GetNativeArray(InterpolationStateType);
					ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
					int nextIndex;
					while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
					{
						T val = nativeArray2[nextIndex];
						D interpolatedData = nativeArray[nextIndex];
						val.Interpolate(ref interpolatedData, normalizedTimeAhead);
						nativeArray[nextIndex] = interpolatedData;
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			public ComponentTypeHandle<D> __D_RW_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<T> __T_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferLookup<MostRecentFixedTime> __Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup;

			public SharedComponentTypeHandle<PhysicsWorldIndex> __Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__D_RW_ComponentTypeHandle = state.GetComponentTypeHandle<D>();
				__T_RO_ComponentTypeHandle = state.GetComponentTypeHandle<T>(isReadOnly: true);
				__Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup = state.GetBufferLookup<MostRecentFixedTime>(isReadOnly: true);
				__Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle = state.GetSharedComponentTypeHandle<PhysicsWorldIndex>();
			}
		}

		private int _physicsTicksToInterpolate;

		private EntityQuery _query;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1799675603_0;

		private EntityQuery __query_1799675603_1;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<MostRecentFixedTime>();
			state.RequireForUpdate<LastRecordedPhysicsStepCD>();
			EntityQueryBuilder queriesDesc = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder = queriesDesc.WithAll<T, D>();
			entityQueryBuilder = entityQueryBuilder.WithAll<PredictedGhost, GhostOwnerIsLocal>();
			entityQueryBuilder.WithAll<PhysicsWorldIndex>();
			_query = state.EntityManager.CreateEntityQuery(in queriesDesc);
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			RefRW<LastRecordedPhysicsStepCD> singletonRW = __query_1799675603_0.GetSingletonRW<LastRecordedPhysicsStepCD>();
			if (singletonRW.ValueRO.physicsTicks != 0)
			{
				_physicsTicksToInterpolate = singletonRW.ValueRO.physicsTicks;
			}
			state.Dependency = JobChunkExtensions.ScheduleParallel(new SmoothJob
			{
				SmoothedType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__D_RW_ComponentTypeHandle, ref state),
				InterpolationStateType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__T_RO_ComponentTypeHandle, ref state),
				MostRecentFixedTime = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup, ref state),
				PhysicsWorldIndex = InternalCompilerInterface.GetSharedComponentTypeHandle(ref __TypeHandle.__Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle, ref state),
				MostRecentFixedTimeEntity = __query_1799675603_1.GetSingletonEntity(),
				ElapsedTime = state.WorldUnmanaged.Time.ElapsedTime,
				PhysicsTicksToInterpolate = _physicsTicksToInterpolate
			}, _query, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<LastRecordedPhysicsStepCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799675603_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<MostRecentFixedTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1799675603_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}
	}
}
