using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace Pug.Automation
{
	[BurstCompile]
	[UpdateInGroup(typeof(PugAutomationStartCraftSystemGroup), OrderFirst = true)]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct TriggerCrafterChangedSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct TriggerCrafterUpdateOnChangeJob : IJobChunk
		{
			[ReadOnly]
			public ComponentTypeHandle<PugAutomationCD> pugAutomationTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<ContainedObjectsBuffer> containedObjectsBufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<SmallEntityCrafterRefBuffer> smallEntityCrafterRefBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> objectDataHandle;

			public ComponentLookup<BigEntityCraftingDataChangedTriggerCD> bigEntityCraftingDataChangedTriggerLookup;

			public uint lastSystemVersion;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				if (!chunk.DidChange(ref pugAutomationTypeHandle, lastSystemVersion) && !chunk.DidChange(ref containedObjectsBufferTypeHandle, lastSystemVersion) && !chunk.DidChange(ref objectDataHandle, lastSystemVersion) && !chunk.DidOrderChange(lastSystemVersion))
				{
					return;
				}
				BufferAccessor<SmallEntityCrafterRefBuffer> bufferAccessor = chunk.GetBufferAccessor(ref smallEntityCrafterRefBufferTypeHandle);
				for (int i = 0; i < chunk.Count; i++)
				{
					DynamicBuffer<SmallEntityCrafterRefBuffer> dynamicBuffer = bufferAccessor[i];
					for (int j = 0; j < dynamicBuffer.Length; j++)
					{
						bigEntityCraftingDataChangedTriggerLookup.GetRefRWOptional(dynamicBuffer[j].smallEntity);
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
			public ComponentTypeHandle<PugAutomationCD> __Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<SmallEntityCrafterRefBuffer> __Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

			public ComponentLookup<BigEntityCraftingDataChangedTriggerCD> __Pug_Automation_BigEntityCraftingDataChangedTriggerCD_RW_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugAutomationCD>(isReadOnly: true);
				__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
				__Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SmallEntityCrafterRefBuffer>(isReadOnly: true);
				__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				__Pug_Automation_BigEntityCraftingDataChangedTriggerCD_RW_ComponentLookup = state.GetComponentLookup<BigEntityCraftingDataChangedTriggerCD>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000064A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000064A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000064A_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1958695096_0;

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			state.Dependency = JobChunkExtensions.Schedule(new TriggerCrafterUpdateOnChangeJob
			{
				pugAutomationTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_Automation_PugAutomationCD_RO_ComponentTypeHandle, ref state),
				containedObjectsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle, ref state),
				smallEntityCrafterRefBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferTypeHandle, ref state),
				objectDataHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle, ref state),
				bigEntityCraftingDataChangedTriggerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_BigEntityCraftingDataChangedTriggerCD_RW_ComponentLookup, ref state),
				lastSystemVersion = state.LastSystemVersion
			}, __query_1958695096_0, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SmallEntityCrafterRefBuffer, PugAutomationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_1958695096_0 = entityQueryBuilder2.Build(ref state);
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
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000064A_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((TriggerCrafterChangedSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((TriggerCrafterChangedSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
