using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateBefore(typeof(FollowerControlSystem))]
	[BurstCompile]
	public struct RepairPathSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		private struct TypeHandle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private EntityQuery entityQueryPrepare;

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_943785559_0;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		[Obsolete("Use TraverseOffMeshLinkSystem.NextLinkToTraverse instead")]
		public static OffMeshLinks.OffMeshLinkTracer NextLinkToTraverse(ManagedState state)
		{
			return default(OffMeshLinks.OffMeshLinkTracer);
		}

		[Obsolete("Use TraverseOffMeshLinkSystem.ResolveOffMeshLinkHandler instead")]
		public static IOffMeshLinkHandler ResolveOffMeshLinkHandler(ManagedSettings settings, AgentOffMeshLinkTraversalContext ctx)
		{
			return null;
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
