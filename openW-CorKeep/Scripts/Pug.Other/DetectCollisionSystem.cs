using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateAfter(typeof(PhysicsSimulationGroup))]
[UpdateInGroup(typeof(PhysicsSystemGroup))]
public struct DetectCollisionSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	public struct CollisionJob : ICollisionEventsJob, ICollisionEventsJobBase, ITriggerEventsJob, ITriggerEventsJobBase
	{
		public ComponentLookup<DetectCollisionCD> detectCollisionLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		public void Execute(CollisionEvent collisionEvent)
		{
			Execute(collisionEvent.EntityA, collisionEvent.EntityB, collisionEvent.Normal, isTrigger: false);
		}

		public void Execute(TriggerEvent triggerEvent)
		{
			Execute(triggerEvent.EntityA, triggerEvent.EntityB, 0, isTrigger: true);
		}

		public void Execute(Entity EntityA, Entity EntityB, float3 Normal, bool isTrigger)
		{
			if ((!tileLookup.HasComponent(EntityA) || !tileLookup.HasComponent(EntityB)) && (!enemyLookup.HasComponent(EntityA) || !enemyLookup.HasComponent(EntityB) || bossLookup.HasComponent(EntityA) || bossLookup.HasComponent(EntityB)))
			{
				bool num = detectCollisionLookup.HasComponent(EntityA);
				bool flag = detectCollisionLookup.HasComponent(EntityB);
				if (num)
				{
					detectCollisionLookup[EntityA] = new DetectCollisionCD
					{
						Normal = Normal,
						hitEntity = EntityB,
						isTriggerEvent = isTrigger
					};
				}
				else if (flag)
				{
					detectCollisionLookup[EntityB] = new DetectCollisionCD
					{
						Normal = -Normal,
						hitEntity = EntityA,
						isTriggerEvent = isTrigger
					};
				}
			}
		}
	}

	private struct TypeHandle
	{
		public ComponentLookup<DetectCollisionCD> __DetectCollisionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DetectCollisionCD_RW_ComponentLookup = state.GetComponentLookup<DetectCollisionCD>();
			__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000017B9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000017B9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000017B9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000017BA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000017BA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000017BA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_402710944_0;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SimulationSingleton>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		CollisionJob jobData = new CollisionJob
		{
			detectCollisionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DetectCollisionCD_RW_ComponentLookup, ref state),
			tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state)
		};
		SimulationSingleton singleton = __query_402710944_0.GetSingleton<SimulationSingleton>();
		state.Dependency = ICollisionEventJobExtensions.Schedule(jobData, singleton, state.Dependency);
		state.Dependency = ITriggerEventJobExtensions.Schedule(jobData, singleton, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SimulationSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_402710944_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000017B9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000017BA_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DetectCollisionSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DetectCollisionSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DetectCollisionSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
