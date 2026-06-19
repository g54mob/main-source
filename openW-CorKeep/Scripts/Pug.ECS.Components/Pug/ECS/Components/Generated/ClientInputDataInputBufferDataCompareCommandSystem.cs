using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[UpdateInGroup(typeof(CompareCommandSystemGroup))]
	[BurstCompile]
	internal struct ClientInputDataInputBufferDataCompareCommandSystem : ISystem
	{
		[BurstCompile]
		private struct CompareJob : IJobChunk
		{
			public NativeParallelHashMap<NetworkTick, NetworkTick>.ParallelWriter map;

			[ReadOnly]
			public BufferTypeHandle<InputBufferData<ClientInputData>> inputTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static uint Compare(in InputBufferData<ClientInputData> snapshot, in InputBufferData<ClientInputData> baseline)
			{
				return (uint)(0 | ((snapshot.InternalInput.dataOffset00 != baseline.InternalInput.dataOffset00) ? 1 : 0) | ((snapshot.InternalInput.dataOffset04 != baseline.InternalInput.dataOffset04) ? 1 : 0) | ((snapshot.InternalInput.dataOffset08 != baseline.InternalInput.dataOffset08) ? 1 : 0) | ((snapshot.InternalInput.dataOffset12 != baseline.InternalInput.dataOffset12) ? 1 : 0) | ((snapshot.InternalInput.dataOffset16 != baseline.InternalInput.dataOffset16) ? 1 : 0) | ((snapshot.InternalInput.dataOffset20 != baseline.InternalInput.dataOffset20) ? 1 : 0) | ((snapshot.InternalInput.dataOffset24 != baseline.InternalInput.dataOffset24) ? 1 : 0) | ((snapshot.InternalInput.dataOffset28 != baseline.InternalInput.dataOffset28) ? 1 : 0) | ((snapshot.InternalInput.dataOffset32 != baseline.InternalInput.dataOffset32) ? 1 : 0) | ((snapshot.InternalInput.dataOffset36 != baseline.InternalInput.dataOffset36) ? 1 : 0) | ((snapshot.InternalInput.dataOffset40 != baseline.InternalInput.dataOffset40) ? 1 : 0) | ((snapshot.InternalInput.dataOffset44 != baseline.InternalInput.dataOffset44) ? 1 : 0) | ((snapshot.InternalInput.dataOffset48 != baseline.InternalInput.dataOffset48) ? 1 : 0) | ((snapshot.InternalInput.dataOffset52 != baseline.InternalInput.dataOffset52) ? 1 : 0) | ((snapshot.InternalInput.dataOffset56 != baseline.InternalInput.dataOffset56) ? 1 : 0) | ((snapshot.InternalInput.dataOffset60 != baseline.InternalInput.dataOffset60) ? 1 : 0) | ((snapshot.InternalInput.dataOffset64 != baseline.InternalInput.dataOffset64) ? 1 : 0));
			}

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				BufferAccessor<InputBufferData<ClientInputData>> bufferAccessor = chunk.GetBufferAccessor(ref inputTypeHandle);
				for (int i = 0; i < chunk.Count; i++)
				{
					DynamicBuffer<InputBufferData<ClientInputData>> buffer = bufferAccessor[i];
					int length = buffer.Length;
					for (int j = 0; j < length; j++)
					{
						ref readonly InputBufferData<ClientInputData> inputAtIndex = ref buffer.GetInputAtIndex(j);
						NetworkTick tick = inputAtIndex.Tick;
						if (!tick.IsValid)
						{
							break;
						}
						NetworkTick tick2 = inputAtIndex.Tick;
						tick2.Decrement();
						int index = (j - 1 + length) % length;
						ref readonly InputBufferData<ClientInputData> inputAtIndex2 = ref buffer.GetInputAtIndex(index);
						if (!inputAtIndex2.Tick.IsValid || inputAtIndex2.Tick.IsNewerThan(tick2) || Compare(in inputAtIndex, in inputAtIndex2) != 0)
						{
							map.TryAdd(tick, tick);
						}
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000142_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000142_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000142_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00000143_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000143_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000143_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery m_Query;

		private EntityQuery m_TickMapQuery;

		private BufferTypeHandle<InputBufferData<ClientInputData>> m_ClientInputDataInputBufferDataHandle;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			EntityQueryBuilder builder = new EntityQueryBuilder(Allocator.Temp).WithAllRW<InputBufferData<ClientInputData>>();
			m_Query = state.GetEntityQuery(in builder);
			builder.Reset();
			builder.WithAllRW<UniqueInputTickMap>();
			m_TickMapQuery = state.GetEntityQuery(in builder);
			m_ClientInputDataInputBufferDataHandle = state.GetBufferTypeHandle<InputBufferData<ClientInputData>>(isReadOnly: true);
			state.RequireForUpdate(m_Query);
			state.RequireForUpdate<UniqueInputTickMap>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			m_ClientInputDataInputBufferDataHandle.Update(ref state);
			CompareJob jobData = new CompareJob
			{
				inputTypeHandle = m_ClientInputDataInputBufferDataHandle,
				map = m_TickMapQuery.GetSingletonRW<UniqueInputTickMap>().ValueRW.Value
			};
			state.Dependency = JobChunkExtensions.ScheduleParallel(jobData, m_Query, state.Dependency);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			__codegen__OnCreate_00000142_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000143_0024BurstDirectCall.Invoke(self, state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ClientInputDataInputBufferDataCompareCommandSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ClientInputDataInputBufferDataCompareCommandSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
