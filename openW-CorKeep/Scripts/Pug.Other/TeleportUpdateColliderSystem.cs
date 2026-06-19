using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[RequireMatchingQueriesForUpdate]
public struct TeleportUpdateColliderSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_787009589_0
	{
		public struct ResolvedChunk
		{
			public EnabledMask item1_EnabledMask;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>>(item1_EnabledMask.GetEnabledRefRW<DisablePhysicsCD>(index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<DisablePhysicsCD> item1_ComponentTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<DisablePhysicsCD>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_EnabledMask = archetypeChunk.GetEnabledMask(ref item1_ComponentTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<DisablePhysicsCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_787009589_0.TypeHandle __IFE_787009589_0_TypeHandle;

		public ComponentLookup<BirdBossHasAppearedCD> __BirdBossHasAppearedCD_RW_ComponentLookup;

		public ComponentLookup<OctopusBossHasAppearedCD> __OctopusBossHasAppearedCD_RW_ComponentLookup;

		public ComponentLookup<ScarabBossHasAppearedCD> __ScarabBossHasAppearedCD_RW_ComponentLookup;

		public ComponentLookup<ScarabBossChargeStateCD> __ScarabBossChargeStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossBuriedRoamingStateCD> __HydraBossBuriedRoamingStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossBuriedCombatStateCD> __HydraBossBuriedCombatStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossCD> __HydraBossCD_RW_ComponentLookup;

		public ComponentLookup<CoreBossCD> __CoreBossCD_RW_ComponentLookup;

		public ComponentLookup<VulnerableStateCD> __VulnerableStateCD_RW_ComponentLookup;

		public ComponentLookup<PhaseTransitionStateCD> __PhaseTransitionStateCD_RW_ComponentLookup;

		public ComponentLookup<TeleportStateCD> __TeleportStateCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_787009589_0_TypeHandle = new IFE_787009589_0.TypeHandle(ref state);
			__BirdBossHasAppearedCD_RW_ComponentLookup = state.GetComponentLookup<BirdBossHasAppearedCD>();
			__OctopusBossHasAppearedCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossHasAppearedCD>();
			__ScarabBossHasAppearedCD_RW_ComponentLookup = state.GetComponentLookup<ScarabBossHasAppearedCD>();
			__ScarabBossChargeStateCD_RW_ComponentLookup = state.GetComponentLookup<ScarabBossChargeStateCD>();
			__HydraBossBuriedRoamingStateCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossBuriedRoamingStateCD>();
			__HydraBossBuriedCombatStateCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossBuriedCombatStateCD>();
			__HydraBossCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossCD>();
			__CoreBossCD_RW_ComponentLookup = state.GetComponentLookup<CoreBossCD>();
			__VulnerableStateCD_RW_ComponentLookup = state.GetComponentLookup<VulnerableStateCD>();
			__PhaseTransitionStateCD_RW_ComponentLookup = state.GetComponentLookup<PhaseTransitionStateCD>();
			__TeleportStateCD_RW_ComponentLookup = state.GetComponentLookup<TeleportStateCD>();
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000411E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000411E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000411E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000411F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000411F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000411F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_787009589_0;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BossCD>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		ComponentLookup<BirdBossHasAppearedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossHasAppearedCD_RW_ComponentLookup, ref state);
		ComponentLookup<OctopusBossHasAppearedCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossHasAppearedCD_RW_ComponentLookup, ref state);
		ComponentLookup<ScarabBossHasAppearedCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossHasAppearedCD_RW_ComponentLookup, ref state);
		ComponentLookup<ScarabBossChargeStateCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossChargeStateCD_RW_ComponentLookup, ref state);
		ComponentLookup<HydraBossBuriedRoamingStateCD> componentLookup5 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedRoamingStateCD_RW_ComponentLookup, ref state);
		ComponentLookup<HydraBossBuriedCombatStateCD> componentLookup6 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedCombatStateCD_RW_ComponentLookup, ref state);
		ComponentLookup<HydraBossCD> componentLookup7 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossCD_RW_ComponentLookup, ref state);
		ComponentLookup<CoreBossCD> componentLookup8 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossCD_RW_ComponentLookup, ref state);
		ComponentLookup<VulnerableStateCD> componentLookup9 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VulnerableStateCD_RW_ComponentLookup, ref state);
		ComponentLookup<PhaseTransitionStateCD> componentLookup10 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PhaseTransitionStateCD_RW_ComponentLookup, ref state);
		ComponentLookup<TeleportStateCD> componentLookup11 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TeleportStateCD_RW_ComponentLookup, ref state);
		foreach (QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>> item in IFE_787009589_0.Query(__query_787009589_0, __TypeHandle.__IFE_787009589_0_TypeHandle, ref state))
		{
			var (enabledRefRW2, entity2) = (QueryEnumerableWithEntity<EnabledRefRW<DisablePhysicsCD>>)(ref item);
			if (!InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state, entity2) || !InternalCompilerInterface.IsComponentEnabledAfterCompletingDependency(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state, entity2))
			{
				bool num = !componentLookup11.HasComponent(entity2) || componentLookup11[entity2].internalState != 1;
				bool flag = !componentLookup10.HasComponent(entity2) || !componentLookup10[entity2].isInvulnerable;
				bool flag2 = !componentLookup.HasComponent(entity2) || componentLookup[entity2].Value;
				bool flag3 = !componentLookup2.HasComponent(entity2) || componentLookup2[entity2].Value;
				bool flag4 = !componentLookup3.HasComponent(entity2) || componentLookup3[entity2].Value;
				bool flag5 = !componentLookup4.HasComponent(entity2) || componentLookup4[entity2].internalState != 2;
				bool num2 = (!componentLookup5.HasComponent(entity2) || componentLookup5[entity2].internalState == 0) && (!componentLookup6.HasComponent(entity2) || componentLookup6[entity2].internalState == 0);
				bool flag6 = !componentLookup5.HasComponent(entity2) || !componentLookup9.HasComponent(entity2) || componentLookup9[entity2].internalState <= 1;
				bool flag7 = !componentLookup7.HasComponent(entity2) || !componentLookup7[entity2].isGhost;
				bool flag8 = !componentLookup8.HasComponent(entity2) || (componentLookup9.HasComponent(entity2) && componentLookup9[entity2].isVulnerable);
				bool flag9 = flag4 && flag5;
				bool flag10 = num2 && flag6 && flag7;
				bool flag11 = num && flag && flag2 && flag3 && flag9 && flag10 && flag8;
				enabledRefRW2.ValueRW = !flag11;
			}
		}
		entityCommandBuffer.Playback(state.EntityManager);
		entityCommandBuffer.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<HydraBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<HydraBossBuriedRoamingStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<HydraBossBuriedCombatStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<VulnerableStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<ScarabBossChargeStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<PhaseTransitionStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<TeleportStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<BirdBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<OctopusBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<ScarabBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DisablePhysicsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
		__query_787009589_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000411E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000411F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((TeleportUpdateColliderSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TeleportUpdateColliderSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TeleportUpdateColliderSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
