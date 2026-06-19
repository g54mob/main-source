using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class SpawnDroppedItemsSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SpawnDroppedItemsSystem_65758D7F_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer ecb;

		public float deltaTime;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<SpawnDroppedItemCD> __spawnerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref SpawnDroppedItemCD spawner, [NoAlias] in LocalTransform transform)
		{
			spawner.timer -= deltaTime;
			if (spawner.timer <= 0f)
			{
				ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = spawner.objectID,
						amount = spawner.amount
					}
				};
				EntityUtility.DropNewEntity(ecb, containedObject, transform.Position, databaseLocal);
				spawner.timer = spawner.timeBetweenSpawns;
				if (spawner.repeats > 0 && --spawner.repeats == 0)
				{
					ecb.DestroyEntity(entity);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __spawnerTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDroppedItemCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDroppedItemCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDroppedItemCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnDroppedItemCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l));
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

		public ComponentTypeHandle<SpawnDroppedItemCD> __SpawnDroppedItemCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__SpawnDroppedItemCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnDroppedItemCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1485055603_0;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate(GetEntityQuery(ComponentType.ReadOnly<SpawnDroppedItemCD>()));
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		SpawnDroppedItemsSystem_65758D7F_LambdaJob_0_Execute(ecb, deltaTime, databaseLocal);
		base.OnUpdate();
	}

	private void SpawnDroppedItemsSystem_65758D7F_LambdaJob_0_Execute(EntityCommandBuffer ecb, float deltaTime, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnDroppedItemCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SpawnDroppedItemsSystem_65758D7F_LambdaJob_0_Job jobData = new SpawnDroppedItemsSystem_65758D7F_LambdaJob_0_Job
		{
			ecb = ecb,
			deltaTime = deltaTime,
			databaseLocal = databaseLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__spawnerTypeHandle = __TypeHandle.__SpawnDroppedItemCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_1485055603_0.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1485055603_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnDroppedItemCD>();
		__query_1485055603_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public SpawnDroppedItemsSystem()
	{
	}
}
