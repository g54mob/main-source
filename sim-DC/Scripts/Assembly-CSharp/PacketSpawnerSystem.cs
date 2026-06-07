using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public struct PacketSpawnerSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct UpdatePacketsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PacketComponent> __PacketComponent_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
				}

				public void Update(ref SystemState state)
				{
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref UpdatePacketsJob job, EntityQuery query)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdatePacketsJob job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdatePacketsJob job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdatePacketsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdatePacketsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdatePacketsJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public EntityCommandBuffer.ParallelWriter ECB;

		public float DeltaTime;

		[ReadOnly]
		public ComponentLookup<PacketSpawnerComponent> SpawnerLookup;

		[ReadOnly]
		public ComponentLookup<CableIDComponent> CableIdLookup;

		[ReadOnly]
		public NativeArray<Entity> SpawnerEntities;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute([ChunkIndexInQuery] int chunkIndex, Entity entity, ref PacketComponent packet, ref LocalTransform transform)
		{
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}

		private JobHandle __ThrowCodeGenException()
		{
			return default(JobHandle);
		}

		public void Run()
		{
		}

		public void RunByRef()
		{
		}

		public void Run(EntityQuery query)
		{
		}

		public void RunByRef(EntityQuery query)
		{
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public void Schedule()
		{
		}

		public void ScheduleByRef()
		{
		}

		public void Schedule(EntityQuery query)
		{
		}

		public void ScheduleByRef(EntityQuery query)
		{
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return default(JobHandle);
		}

		public void ScheduleParallel()
		{
		}

		public void ScheduleParallelByRef()
		{
		}

		public void ScheduleParallel(EntityQuery query)
		{
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}
	}

	[StructLayout((LayoutKind)0, Size = 1)]
	private readonly struct IFE_23355594_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PacketSpawnerComponent>, InternalCompilerInterface.UncheckedRefRO<CableIDComponent>> Get(int index)
			{
				return default(QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PacketSpawnerComponent>, InternalCompilerInterface.UncheckedRefRO<CableIDComponent>>);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<PacketSpawnerComponent> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<CableIDComponent> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = default(ComponentTypeHandle<PacketSpawnerComponent>);
				item2_ComponentTypeHandle_RO = default(ComponentTypeHandle<CableIDComponent>);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PacketSpawnerComponent>, InternalCompilerInterface.UncheckedRefRO<CableIDComponent>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PacketSpawnerComponent>, InternalCompilerInterface.UncheckedRefRO<CableIDComponent>> Current => default(QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PacketSpawnerComponent>, InternalCompilerInterface.UncheckedRefRO<CableIDComponent>>);

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
		public IFE_23355594_0.TypeHandle __IFE_23355594_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<PacketSpawnerComponent> __PacketSpawnerComponent_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CableIDComponent> __CableIDComponent_RO_ComponentLookup;

		public UpdatePacketsJob.InternalCompilerQueryAndHandleData __PacketSpawnerSystem_UpdatePacketsJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000008C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000008C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
		}

		private static IntPtr GetFunctionPointer()
		{
			return (IntPtr)0;
		}

		public static void Invoke(IntPtr self, IntPtr state)
		{
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000008D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000008D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
		}

		private static IntPtr GetFunctionPointer()
		{
			return (IntPtr)0;
		}

		public static void Invoke(IntPtr self, IntPtr state)
		{
		}
	}

	private EntityQuery spawnerQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_23355594_0;

	private EntityQuery __query_23355594_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
	}

	[BurstCompile]
	private void SpawnPacket(EntityCommandBuffer ecb, PacketSpawnerComponent spawner, int spawnerIndex, ref BlobArray<float3> waypoints)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdatePacketsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		return default(JobHandle);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
	}
}
