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
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class InteractWithEnvironmentSystem : PugSimulationSystemBase
{
	private struct TriggeredByEntity : IEquatable<TriggeredByEntity>
	{
		public Entity Trigger;

		public Entity Entity;

		public bool Equals(TriggeredByEntity other)
		{
			if (Trigger == other.Trigger)
			{
				return Entity == other.Entity;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)math.hash(new int2(Trigger.GetHashCode(), Entity.GetHashCode()));
		}

		public override bool Equals(object obj)
		{
			if (obj is TriggeredByEntity other)
			{
				return Equals(other);
			}
			return false;
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00002195_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00002195_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00002195_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public PhysicsWorld physicsWorld;

		public NativeList<DistanceHit> allHits;

		public NativeParallelHashSet<TriggeredByEntity> triggeredThisTickLocal;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InteractWithEnvironmentCD> __triggerWhenEnterCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in InteractWithEnvironmentCD triggerWhenEnterCD, [NoAlias] in LocalTransform transform)
		{
			allHits.Clear();
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 556616u
			};
			if (!physicsWorld.OverlapSphere(transform.Position, triggerWhenEnterCD.radius, ref allHits, filter))
			{
				return;
			}
			foreach (DistanceHit allHit in allHits)
			{
				if (!entityDestroyedLookup.HasComponent(allHit.Entity) || !entityDestroyedLookup.IsComponentEnabled(allHit.Entity))
				{
					triggeredThisTickLocal.Add(new TriggeredByEntity
					{
						Trigger = allHit.Entity,
						Entity = entity
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __triggerWhenEnterCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractWithEnvironmentCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractWithEnvironmentCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractWithEnvironmentCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractWithEnvironmentCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00002195_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00002195_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InteractWithEnvironmentCD> __InteractWithEnvironmentCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__InteractWithEnvironmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InteractWithEnvironmentCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private NativeParallelHashSet<TriggeredByEntity> _triggeredLastTick;

	private NativeParallelHashSet<TriggeredByEntity> _triggeredThisTick;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1152270636_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<NetworkId>();
		_triggeredLastTick = new NativeParallelHashSet<TriggeredByEntity>(32, Allocator.Persistent);
		_triggeredThisTick = new NativeParallelHashSet<TriggeredByEntity>(32, Allocator.Persistent);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		_triggeredLastTick.Dispose();
		_triggeredThisTick.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		PhysicsWorld physicsWorld = GetPhysicsWorld();
		NativeList<DistanceHit> allHits = new NativeList<DistanceHit>(base.World.UpdateAllocator.ToAllocator);
		NativeParallelHashSet<TriggeredByEntity> triggeredLastTick = _triggeredLastTick;
		NativeParallelHashSet<TriggeredByEntity> triggeredThisTickLocal = _triggeredThisTick;
		ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Execute(ref physicsWorld, ref allHits, ref triggeredThisTickLocal, ref entityDestroyedLookup);
		foreach (TriggeredByEntity item in triggeredThisTickLocal)
		{
			EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(item.Trigger);
			if (entityMono == null)
			{
				continue;
			}
			PlayerController playerController = Manager.memory.GetEntityMono(item.Entity) as PlayerController;
			if (playerController == null)
			{
				entityMono.OnNonPlayerTrigger(item.Entity);
				if (!triggeredLastTick.Contains(item))
				{
					entityMono.OnNonPlayerTriggerEnter(item.Entity);
				}
			}
			else
			{
				entityMono.OnPlayerTrigger(playerController);
				if (!triggeredLastTick.Contains(item))
				{
					entityMono.OnPlayerTriggerEnter(playerController);
				}
			}
		}
		foreach (TriggeredByEntity item2 in triggeredLastTick)
		{
			if (triggeredThisTickLocal.Contains(item2))
			{
				continue;
			}
			EntityMonoBehaviour entityMono2 = Manager.memory.GetEntityMono(item2.Trigger);
			if (!(entityMono2 == null))
			{
				PlayerController playerController2 = Manager.memory.GetEntityMono(item2.Entity) as PlayerController;
				if (playerController2 == null)
				{
					entityMono2.OnNonPlayerTriggerExit(item2.Entity);
				}
				else
				{
					entityMono2.OnPlayerTriggerExit(playerController2);
				}
			}
		}
		_triggeredLastTick = triggeredThisTickLocal;
		_triggeredThisTick = triggeredLastTick;
		_triggeredThisTick.Clear();
		base.OnUpdate();
	}

	private void InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Execute(ref PhysicsWorld physicsWorld, ref NativeList<DistanceHit> allHits, ref NativeParallelHashSet<TriggeredByEntity> triggeredThisTickLocal, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__InteractWithEnvironmentCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Job value = new InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Job
		{
			physicsWorld = physicsWorld,
			allHits = allHits,
			triggeredThisTickLocal = triggeredThisTickLocal,
			entityDestroyedLookup = entityDestroyedLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__triggerWhenEnterCDTypeHandle = __TypeHandle.__InteractWithEnvironmentCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		if (!__query_1152270636_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			InteractWithEnvironmentSystem_4EAF5153_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1152270636_0, jobPtr);
		}
		physicsWorld = value.physicsWorld;
		allHits = value.allHits;
		triggeredThisTickLocal = value.triggeredThisTickLocal;
		entityDestroyedLookup = value.entityDestroyedLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<InteractWithEnvironmentCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_1152270636_0 = entityQueryBuilder2.Build(ref state);
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
	public InteractWithEnvironmentSystem()
	{
	}
}
