using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Interaction;
using Outlines.Components;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace Outlines.Systems
{
	[BurstCompile]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(ToggleClosestLocalInteractableSystem))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct VisualOutlineSelectSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct VisualOutlineSelectJob : IJobChunk
		{
			[ReadOnly]
			public ComponentTypeHandle<IsClosestLocalInteractableCD> isClosestLocalInteractableTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<IsCloneCD> isCloneTypeHandle;

			public ComponentTypeHandle<VisualOutlineCD> visualOutlineTypeHandle;

			public uint lastSystemVersion;

			public unsafe void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				bool num = chunk.DidChange(ref isClosestLocalInteractableTypeHandle, lastSystemVersion);
				bool flag = chunk.DidChange(ref visualOutlineTypeHandle, lastSystemVersion);
				bool flag2 = chunk.DidOrderChange(lastSystemVersion);
				if (!num && !flag && !flag2)
				{
					return;
				}
				VisualOutlineCD* ptr = chunk.GetComponentDataPtrRO(ref visualOutlineTypeHandle);
				bool flag3 = false;
				ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
				{
					OutlineType outlineType = OutlineType.None;
					if (chunk.IsComponentEnabled(ref isClosestLocalInteractableTypeHandle, nextIndex))
					{
						outlineType = OutlineType.ClosestInteractable;
					}
					else if (chunk.IsComponentEnabled(ref isCloneTypeHandle, nextIndex))
					{
						outlineType = OutlineType.Clone;
					}
					VisualOutlineCD visualOutlineCD = ptr[nextIndex];
					if (outlineType != visualOutlineCD.outlineType)
					{
						if (!flag3)
						{
							flag3 = true;
							ptr = chunk.GetComponentDataPtrRW(ref visualOutlineTypeHandle);
						}
						visualOutlineCD.outlineType = outlineType;
						ptr[nextIndex] = visualOutlineCD;
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentTypeHandle<IsClosestLocalInteractableCD> __Interaction_IsClosestLocalInteractableCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<IsCloneCD> __IsCloneCD_RO_ComponentTypeHandle;

			public ComponentTypeHandle<VisualOutlineCD> __Outlines_Components_VisualOutlineCD_RW_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Interaction_IsClosestLocalInteractableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsClosestLocalInteractableCD>(isReadOnly: true);
				__IsCloneCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsCloneCD>(isReadOnly: true);
				__Outlines_Components_VisualOutlineCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<VisualOutlineCD>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000001A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000001A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000001A_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000001B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000001B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000001B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery _query;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1944118857_0;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			_query = __query_1944118857_0;
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			state.Dependency = JobChunkExtensions.Schedule(new VisualOutlineSelectJob
			{
				isClosestLocalInteractableTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Interaction_IsClosestLocalInteractableCD_RO_ComponentTypeHandle, ref state),
				isCloneTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__IsCloneCD_RO_ComponentTypeHandle, ref state),
				visualOutlineTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Outlines_Components_VisualOutlineCD_RW_ComponentTypeHandle, ref state),
				lastSystemVersion = state.LastSystemVersion
			}, _query, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<VisualOutlineCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAny<MarkedAsMinionAttackTarget, HoveredAsMinionAttackTarget, IsClosestLocalInteractableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
			__query_1944118857_0 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000001A_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000001B_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((VisualOutlineSelectSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((VisualOutlineSelectSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((VisualOutlineSelectSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
