using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateBefore(typeof(FollowerControlSystem))]
	[UpdateBefore(typeof(RepairPathSystem))]
	public struct TraverseOffMeshLinkSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		private readonly struct IFE_1565301199_0
		{
			public struct ResolvedChunk
			{
				public ManagedComponentAccessor<ManagedState> item1_ManagedComponentAccessor;

				public ManagedComponentAccessor<ManagedSettings> item2_ManagedComponentAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<ManagedState, ManagedSettings> Get(int index)
				{
					return default(QueryEnumerableWithEntity<ManagedState, ManagedSettings>);
				}
			}

			public struct TypeHandle
			{
				public EntityManager _entityManager;

				[ReadOnly]
				private ComponentTypeHandle<ManagedState> item1_ManagedComponentTypeHandle_RO;

				[ReadOnly]
				private ComponentTypeHandle<ManagedSettings> item2_ManagedComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					_entityManager = default(EntityManager);
					item1_ManagedComponentTypeHandle_RO = default(ComponentTypeHandle<ManagedState>);
					item2_ManagedComponentTypeHandle_RO = default(ComponentTypeHandle<ManagedSettings>);
					Entity_TypeHandle = default(EntityTypeHandle);
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

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ManagedState, ManagedSettings>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<ManagedState, ManagedSettings> Current => default(QueryEnumerableWithEntity<ManagedState, ManagedSettings>);

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
			public IFE_1565301199_0.TypeHandle __IFE_1565301199_0_TypeHandle;

			public JobManagedOffMeshLinkTransition.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedOffMeshLinkTransition_WithDefaultQuery_JobEntityTypeHandle;

			public JobManagedOffMeshLinkTransitionCleanup.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedOffMeshLinkTransitionCleanup_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private EntityQuery entityQueryPrepare;

		private EntityQuery entityQueryOffMeshLinkCleanup;

		public JobRepairPath.Scheduler jobRepairPathScheduler;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1565301199_0;

		private EntityQuery __query_1565301199_1;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private void StartOffMeshLinkTraversal(ref SystemState systemState, EntityCommandBuffer commandBuffer)
		{
		}

		public static OffMeshLinks.OffMeshLinkTracer NextLinkToTraverse(ManagedState state)
		{
			return default(OffMeshLinks.OffMeshLinkTracer);
		}

		public static IOffMeshLinkHandler ResolveOffMeshLinkHandler(ManagedSettings settings, AgentOffMeshLinkTraversalContext ctx)
		{
			return null;
		}

		private void ProcessActiveOffMeshLinkTraversal(ref SystemState systemState)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobManagedOffMeshLinkTransition job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_1(JobManagedOffMeshLinkTransitionCleanup job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
