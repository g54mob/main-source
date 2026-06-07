using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[UpdateBefore(typeof(SchedulePathSearchSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	public struct MovementPlaneFromGraphSystem : ISystem, ISystemCompilerGenerated
	{
		private struct JobMovementPlaneFromNavmeshNormal : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

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
				public void Run(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobMovementPlaneFromNavmeshNormal job, EntityManager entityManager)
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

			public float dt;

			public NativeList<Int3> vertices;

			public List<GraphNode> que;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public EntityManager __EntityManager;

			public void Execute(ManagedState managedState, in LocalTransform localTransform, ref AgentMovementPlane agentMovementPlane, in AgentCylinderShape shape)
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

		[BurstCompile]
		private struct JobMovementPlaneFromGraph : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

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
				public void Run(ref JobMovementPlaneFromGraph job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobMovementPlaneFromGraph job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobMovementPlaneFromGraph job, EntityManager entityManager)
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

			[ReadOnly]
			public NativeArray<AgentMovementPlane> movementPlanes;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MovementState movementState, ref AgentMovementPlane movementPlane)
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

		private struct TypeHandle
		{
			public JobMovementPlaneFromNavmeshNormal.InternalCompilerQueryAndHandleData __Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromNavmeshNormal_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobMovementPlaneFromGraph.InternalCompilerQueryAndHandleData __Pathfinding_ECS_MovementPlaneFromGraphSystem_JobMovementPlaneFromGraph_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SampleSmoothTriangleNormal_00001541_0024PostfixBurstDelegate(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha);

		internal static class SampleSmoothTriangleNormal_00001541_0024BurstDirectCall
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

			public static void Invoke(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
			{
			}
		}

		public EntityQuery entityQueryGraph;

		public EntityQuery entityQueryNormal;

		private GCHandle graphNodeQueue;

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		public static NativeMovementPlane MovementPlaneFromGraph(NavGraph graph)
		{
			return default(NativeMovementPlane);
		}

		public static void SampleSmoothNavmeshNormal(TriangleMeshNode node, List<GraphNode> scratchList, NativeList<Int3> scratchBuffer, float3 position, float agentRadius, ref AgentMovementPlane agentMovementPlane, float alpha)
		{
		}

		private static float Square(float x)
		{
			return 0f;
		}

		private static float SinAngle(float3 a, float3 b, float3 c)
		{
			return 0f;
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(SampleSmoothTriangleNormal_00001541_0024PostfixBurstDelegate))]
		private static void SampleSmoothTriangleNormal(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobMovementPlaneFromNavmeshNormal job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobMovementPlaneFromGraph job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public static void SampleSmoothTriangleNormal_0024BurstManaged(ref float3 position, ref UnsafeSpan<Int3> _triangleVertices, ref AgentMovementPlane agentMovementPlane, float agentRadius, float alpha)
		{
		}
	}
}
