using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup), OrderFirst = true)]
[UpdateAfter(typeof(SummarizeConditionsSystem))]
public class UpdateMovementSpeedSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<MovementSpeedCD> __moveSpeedTypeHandle;

		public BufferTypeHandle<SummarizedConditionEffectsBuffer> __conditionsTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref MovementSpeedCD moveSpeed, DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
		{
			moveSpeed.speed = EntityUtility.GetActiveMovementSpeed(conditions, moveSpeed);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __moveSpeedTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __conditionsTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, i), bufferAccessor[i]);
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, j), bufferAccessor[j]);
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, k), bufferAccessor[k]);
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, l), bufferAccessor[l]);
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_1_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<MovementSpeedCD> __moveSpeedTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref MovementSpeedCD moveSpeed)
		{
			moveSpeed.speed = EntityUtility.GetActiveMovementSpeed2(moveSpeed);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __moveSpeedTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__MovementSpeedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>();
			__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_855246610_0;

	private EntityQuery __query_855246610_1;

	[Preserve]
	protected override void OnUpdate()
	{
		UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_0_Execute();
		UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_1_Execute();
		base.OnUpdate();
	}

	private void UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_0_Execute()
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_0_Job jobData = new UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_0_Job
		{
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__moveSpeedTypeHandle = __TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle,
			__conditionsTypeHandle = __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_855246610_0.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_855246610_0, base.CheckedStateRef.Dependency);
	}

	private void UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_1_Execute()
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_1_Job jobData = new UpdateMovementSpeedSystem_7A55CB7B_LambdaJob_1_Job
		{
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__moveSpeedTypeHandle = __TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_855246610_1.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_855246610_1, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementSpeedCD>();
		__query_855246610_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_855246610_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(SummarizedConditionEffectsBuffer))
		});
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SummarizedConditionEffectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementSpeedCD>();
		__query_855246610_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_855246610_1.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(MovementSpeedCD))
		});
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public UpdateMovementSpeedSystem()
	{
	}
}
