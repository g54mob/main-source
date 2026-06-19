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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct ShamanBossSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1456195127_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<MeleeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ChaseStateCD>, PhaseTransitionStateCD) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<MeleeAttackStateCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ShootMortarProjectileStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<RangeAttackStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ChaseStateCD>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PhaseTransitionStateCD>(item5_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<MeleeAttackStateCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ShootMortarProjectileStateCD> item2_ComponentTypeHandle_RW;

			private ComponentTypeHandle<RangeAttackStateCD> item3_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ChaseStateCD> item4_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<PhaseTransitionStateCD> item5_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<MeleeAttackStateCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RangeAttackStateCD>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ChaseStateCD>();
				item5_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PhaseTransitionStateCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RW),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<MeleeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ChaseStateCD>, PhaseTransitionStateCD)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<MeleeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<ChaseStateCD>, PhaseTransitionStateCD) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<MeleeAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ShootMortarProjectileStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RangeAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ChaseStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PhaseTransitionStateCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1456195127_0.TypeHandle __IFE_1456195127_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1456195127_0_TypeHandle = new IFE_1456195127_0.TypeHandle(ref state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000B2A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000B2A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000B2A_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000B2B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000B2B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000B2B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1456195127_0;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<ShamanBossCD>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		foreach (var item5 in IFE_1456195127_0.Query(__query_1456195127_0, __TypeHandle.__IFE_1456195127_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRW<MeleeAttackStateCD> item = item5.Item1;
			InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD> item2 = item5.Item2;
			InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD> item3 = item5.Item3;
			InternalCompilerInterface.UncheckedRefRW<ChaseStateCD> item4 = item5.Item4;
			bool flag = item5.Item5.currentPhase == 1;
			item.ValueRW.isDisabled = !flag;
			item4.ValueRW.isDisabled = !flag;
			item2.ValueRW.isDisabled = flag;
			item3.ValueRW.isDisabled = flag;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ShamanBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhaseTransitionStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MeleeAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
		__query_1456195127_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000B2A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000B2B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ShamanBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ShamanBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ShamanBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
