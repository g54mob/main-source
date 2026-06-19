using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedSimulationSystemGroup))]
public class UpdateColliderMelodyAffectedSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Tag : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct UpdateColliderMelodyAffectedSystem_2E14B0FD_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AffectObjectWhenMelodyPlayedCD> __affectCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in AffectObjectWhenMelodyPlayedCD affectCD, [NoAlias] in ObjectDataCD objectData)
		{
			if (affectCD.newVariation != objectData.variation)
			{
				return;
			}
			if (__Unity_Physics_PhysicsCollider_ComponentLookup.HasComponent(entity))
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(affectCD.changeObjectID ? affectCD.newObjectId : objectData.objectID, databaseLocal, affectCD.newVariation);
				if (__Unity_Physics_PhysicsCollider_ComponentLookup.HasComponent(primaryPrefabEntity))
				{
					PhysicsCollider component = __Unity_Physics_PhysicsCollider_ComponentLookup[primaryPrefabEntity];
					ecb.SetComponent(entity, component);
				}
				else
				{
					ecb.RemoveComponent<PhysicsCollider>(entity);
				}
			}
			ecb.AddComponent<Tag>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __affectCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AffectObjectWhenMelodyPlayedCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l));
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

		[ReadOnly]
		public ComponentTypeHandle<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__AffectObjectWhenMelodyPlayedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AffectObjectWhenMelodyPlayedCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__Unity_Physics_PhysicsCollider_RO_ComponentLookup = state.GetComponentLookup<PhysicsCollider>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1643736778_0;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		NeedDatabase();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		UpdateColliderMelodyAffectedSystem_2E14B0FD_LambdaJob_0_Execute(ecb, databaseLocal);
		base.OnUpdate();
	}

	private void UpdateColliderMelodyAffectedSystem_2E14B0FD_LambdaJob_0_Execute(EntityCommandBuffer ecb, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Physics_PhysicsCollider_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		UpdateColliderMelodyAffectedSystem_2E14B0FD_LambdaJob_0_Job jobData = new UpdateColliderMelodyAffectedSystem_2E14B0FD_LambdaJob_0_Job
		{
			ecb = ecb,
			databaseLocal = databaseLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__affectCDTypeHandle = __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
			__Unity_Physics_PhysicsCollider_ComponentLookup = __TypeHandle.__Unity_Physics_PhysicsCollider_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1643736778_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<Tag>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AffectObjectWhenMelodyPlayedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		_queryRequiredForUpdate = (__query_1643736778_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		__query_1643736778_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(ObjectDataCD))
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
	public UpdateColliderMelodyAffectedSystem()
	{
	}
}
