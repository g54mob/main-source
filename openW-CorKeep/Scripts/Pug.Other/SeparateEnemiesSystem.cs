using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class SeparateEnemiesSystem : SystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SeparateEnemiesSystem_39376ED7_LambdaJob_0_Job : IJobChunk
	{
		public float deltaTime;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<SeparateIfStuckCD> __separateIfStuckTypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __velocityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref SeparateIfStuckCD separateIfStuck, [NoAlias] ref PhysicsVelocity velocity, [NoAlias] in LocalTransform transform)
		{
			int2 int5 = transform.Position.RoundToInt2();
			int2 lastPos = separateIfStuck.lastPos;
			separateIfStuck.lastPos = int5;
			if (math.lengthsq(velocity.Linear) < 0.1f || math.any(int5 != lastPos))
			{
				separateIfStuck.timer = 0f;
				return;
			}
			separateIfStuck.timer += deltaTime;
			if (separateIfStuck.timer > 4f)
			{
				velocity.AddLinear2D(new Unity.Mathematics.Random((uint)(separateIfStuck.timer * 1000000f) ^ (uint)entity.Index ^ (uint)entity.Version).NextFloat2Direction().ToFloat3() * 100f * deltaTime * (1f + separateIfStuck.timer - 4f));
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __separateIfStuckTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __velocityTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeparateIfStuckCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeparateIfStuckCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeparateIfStuckCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeparateIfStuckCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, l));
				}
				num >>= 1;
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

		public ComponentTypeHandle<SeparateIfStuckCD> __SeparateIfStuckCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__SeparateIfStuckCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SeparateIfStuckCD>();
			__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private const float timeUntilTrigger = 4f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_849767686_0;

	[Preserve]
	protected override void OnUpdate()
	{
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		SeparateEnemiesSystem_39376ED7_LambdaJob_0_Execute(deltaTime);
	}

	private void SeparateEnemiesSystem_39376ED7_LambdaJob_0_Execute(float deltaTime)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SeparateIfStuckCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SeparateEnemiesSystem_39376ED7_LambdaJob_0_Job jobData = new SeparateEnemiesSystem_39376ED7_LambdaJob_0_Job
		{
			deltaTime = deltaTime,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__separateIfStuckTypeHandle = __TypeHandle.__SeparateIfStuckCD_RW_ComponentTypeHandle,
			__velocityTypeHandle = __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_849767686_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SeparateIfStuckCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
		__query_849767686_0 = entityQueryBuilder2.Build(ref state);
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
	public SeparateEnemiesSystem()
	{
	}
}
