using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace Pathfinding.ECS
{
	[UpdateBefore(typeof(SchedulePathSearchSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public struct SyncDestinationTransformSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		private readonly struct IFE_315116516_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public ManagedComponentAccessor<AIDestinationSetter> item2_ManagedComponentAccessor;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public (InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, SystemAPI.ManagedAPI.UnityEngineComponent<AIDestinationSetter>) Get(int index)
				{
					return default((InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, SystemAPI.ManagedAPI.UnityEngineComponent<AIDestinationSetter>));
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				private ComponentTypeHandle<DestinationPoint> item1_ComponentTypeHandle_RW;

				[ReadOnly]
				private ComponentTypeHandle<AIDestinationSetter> item2_ManagedComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = default(EntityManager);
					item1_ComponentTypeHandle_RW = default(ComponentTypeHandle<DestinationPoint>);
					item2_ManagedComponentTypeHandle_RO = default(ComponentTypeHandle<AIDestinationSetter>);
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

			public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, SystemAPI.ManagedAPI.UnityEngineComponent<AIDestinationSetter>)>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public (InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, SystemAPI.ManagedAPI.UnityEngineComponent<AIDestinationSetter>) Current => default((InternalCompilerInterface.UncheckedRefRW<DestinationPoint>, SystemAPI.ManagedAPI.UnityEngineComponent<AIDestinationSetter>));

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
			public IFE_315116516_0.TypeHandle __IFE_315116516_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_315116516_0;

		public void OnUpdate(ref SystemState systemState)
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
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
