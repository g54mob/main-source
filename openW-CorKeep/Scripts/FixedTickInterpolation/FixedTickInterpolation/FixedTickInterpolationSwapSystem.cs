using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

namespace FixedTickInterpolation
{
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	[UpdateInGroup(typeof(FixedTickInterpolationSwapSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct FixedTickInterpolationSwapSystem<T, D, E> : ISystem, ISystemCompilerGenerated where T : unmanaged, IFixedInterpolatedStateData<E, D> where D : unmanaged, IFixedInterpolatedSmoothedData where E : unmanaged, IComponentData
	{
		[BurstCompile]
		public struct SwapInterpolatedJob : IJobChunk
		{
			public ComponentTypeHandle<T> InterpolationStateType;

			[ReadOnly]
			public ComponentTypeHandle<E> CurrentStateType;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				NativeArray<T> nativeArray = chunk.GetNativeArray(InterpolationStateType);
				NativeArray<E> nativeArray2 = chunk.GetNativeArray(CurrentStateType);
				ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
				{
					E newState = nativeArray2[nextIndex];
					T value = nativeArray[nextIndex];
					value.Swap(newState);
					nativeArray[nextIndex] = value;
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			public ComponentTypeHandle<T> __T_RW_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<E> __E_RO_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__T_RW_ComponentTypeHandle = state.GetComponentTypeHandle<T>();
				__E_RO_ComponentTypeHandle = state.GetComponentTypeHandle<E>(isReadOnly: true);
			}
		}

		private NetworkTick _lastUpdateTick;

		private EntityQuery _query;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_223786575_0;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<LastRecordedPhysicsStepCD>();
			EntityQueryBuilder queriesDesc = new EntityQueryBuilder(Allocator.Temp);
			queriesDesc.WithAll<T, E>().WithAll<PredictedGhost, GhostOwnerIsLocal>();
			_query = state.EntityManager.CreateEntityQuery(in queriesDesc);
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			if (__query_223786575_0.GetSingletonRW<LastRecordedPhysicsStepCD>().ValueRO.physicsTicks != 0)
			{
				state.Dependency = JobChunkExtensions.Schedule(new SwapInterpolatedJob
				{
					InterpolationStateType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__T_RW_ComponentTypeHandle, ref state),
					CurrentStateType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__E_RO_ComponentTypeHandle, ref state)
				}, _query, state.Dependency);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<LastRecordedPhysicsStepCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_223786575_0 = entityQueryBuilder2.Build(ref state);
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
