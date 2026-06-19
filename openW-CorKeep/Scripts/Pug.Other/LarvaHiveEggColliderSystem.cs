using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class LarvaHiveEggColliderSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003B38_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003B38_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003B38_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public BlobAssetReference<Collider> localCollHatched;

		public BlobAssetReference<Collider> localCollState0;

		public BlobAssetReference<Collider> localCollState1;

		public BlobAssetReference<Collider> localCollState2;

		public ComponentTypeHandle<PhysicsCollider> __colliderTypeHandle;

		public ComponentTypeHandle<LarvaHiveEggHatchStateCD> __hatchStateTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref PhysicsCollider collider, [NoAlias] ref LarvaHiveEggHatchStateCD hatchState)
		{
			if (hatchState.internalState != hatchState.colliderState)
			{
				if (hatchState.internalState == 0 || hatchState.internalState == 7)
				{
					collider.Value = localCollHatched;
				}
				else if (hatchState.internalState == 1)
				{
					collider.Value = localCollState0;
				}
				else if (hatchState.internalState == 3)
				{
					collider.Value = localCollState1;
				}
				else if (hatchState.internalState == 5)
				{
					collider.Value = localCollState2;
				}
			}
			hatchState.colliderState = hatchState.internalState;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __colliderTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __hatchStateTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsCollider>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsCollider>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsCollider>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsCollider>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003B38_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003B38_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<PhysicsCollider> __Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle;

		public ComponentTypeHandle<LarvaHiveEggHatchStateCD> __LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsCollider>();
			__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LarvaHiveEggHatchStateCD>();
		}
	}

	private BlobAssetReference<Collider> collHatched;

	private BlobAssetReference<Collider> collState0;

	private BlobAssetReference<Collider> collState1;

	private BlobAssetReference<Collider> collState2;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2116667647_0;

	[Preserve]
	protected override void OnCreate()
	{
		collHatched = GetCollider(0.8f, 512u, noCollision: true);
		collState0 = GetCollider(0.5f, 24u);
		collState1 = GetCollider(0.7f, 24u);
		collState2 = GetCollider(0.9f, 24u);
		RequireForUpdate<LarvaHiveEggHatchStateCD>();
		base.OnCreate();
	}

	private BlobAssetReference<Collider> GetCollider(float radius, uint belongsTo, bool noCollision = false)
	{
		BlobAssetReference<Collider> blobAsset = SphereCollider.Create(new SphereGeometry
		{
			Center = float3.zero,
			Radius = radius
		}, new CollisionFilter
		{
			BelongsTo = belongsTo,
			CollidesWith = 20u
		}, new Material
		{
			Friction = 0f,
			Restitution = 0f,
			CollisionResponse = (noCollision ? CollisionResponsePolicy.None : CollisionResponsePolicy.Collide)
		});
		Manager.ecs.BlobAssetStore.TryAdd(ref blobAsset);
		return blobAsset;
	}

	[Preserve]
	protected override void OnUpdate()
	{
		BlobAssetReference<Collider> localCollHatched = collHatched;
		BlobAssetReference<Collider> localCollState = collState0;
		BlobAssetReference<Collider> localCollState2 = collState1;
		BlobAssetReference<Collider> localCollState3 = collState2;
		LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Execute(ref localCollHatched, ref localCollState, ref localCollState2, ref localCollState3);
		base.OnUpdate();
	}

	private void LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Execute(ref BlobAssetReference<Collider> localCollHatched, ref BlobAssetReference<Collider> localCollState0, ref BlobAssetReference<Collider> localCollState1, ref BlobAssetReference<Collider> localCollState2)
	{
		__TypeHandle.__Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Job value = new LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Job
		{
			localCollHatched = localCollHatched,
			localCollState0 = localCollState0,
			localCollState1 = localCollState1,
			localCollState2 = localCollState2,
			__colliderTypeHandle = __TypeHandle.__Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle,
			__hatchStateTypeHandle = __TypeHandle.__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle
		};
		if (!__query_2116667647_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LarvaHiveEggColliderSystem_10EA7DB3_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2116667647_0, jobPtr);
		}
		localCollHatched = value.localCollHatched;
		localCollState0 = value.localCollState0;
		localCollState1 = value.localCollState1;
		localCollState2 = value.localCollState2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PhysicsCollider>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LarvaHiveEggHatchStateCD>();
		__query_2116667647_0 = entityQueryBuilder2.Build(ref state);
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
	public LarvaHiveEggColliderSystem()
	{
	}
}
