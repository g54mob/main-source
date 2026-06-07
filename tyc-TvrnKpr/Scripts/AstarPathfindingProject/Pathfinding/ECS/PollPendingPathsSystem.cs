using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace Pathfinding.ECS
{
	[BurstCompile]
	public struct PollPendingPathsSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		private readonly struct IFE_1964892062_0
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ManagedState Get(int index)
				{
					return null;
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = default(EntityManager);
					item1_ManagedComponentTypeHandle_RO = default(ComponentTypeHandle<ManagedState>);
				}

				public void Update(ref SystemState systemState)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return default(ResolvedChunk);
				}
			}

			public struct Enumerator : IEnumerator<ManagedState>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public ManagedState Current => null;

				object IEnumerator.Current => null;

				public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					_entityQueryEnumerator = default(InternalEntityQueryEnumerator);
					_typeHandle = default(TypeHandle);
					_resolvedChunk = default(ResolvedChunk);
					_currentEntityIndex = 0;
					_endEntityIndex = 0;
				}

				public void Dispose()
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					return false;
				}

				public Enumerator GetEnumerator()
				{
					return default(Enumerator);
				}

				public void Reset()
				{
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				return default(Enumerator);
			}

			public static void CompleteDependencies(ref SystemState state)
			{
			}
		}

		private struct TypeHandle
		{
			public IFE_1964892062_0.TypeHandle __IFE_1964892062_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private GCHandle onPathsCalculated;

		private static bool anyPendingPaths;

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private EntityQuery entityQueryPrepare;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1964892062_0;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		private void OnUpdate(ref SystemState systemState)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
