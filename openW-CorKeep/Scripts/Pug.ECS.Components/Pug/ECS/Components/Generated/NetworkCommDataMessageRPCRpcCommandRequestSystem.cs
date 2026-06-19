using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[UpdateInGroup(typeof(RpcCommandRequestSystemGroup))]
	[CreateAfter(typeof(RpcSystem))]
	[BurstCompile]
	internal struct NetworkCommDataMessageRPCRpcCommandRequestSystem : ISystem
	{
		[BurstCompile]
		private struct SendRpc : IJobChunk
		{
			public RpcCommandRequest<NetworkCommDataMessageRPCSerializer, NetworkCommDataMessageRPC>.SendRpcData data;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				data.Execute(chunk, unfilteredChunkIndex);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_000019F2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_000019F2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000019F2_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private RpcCommandRequest<NetworkCommDataMessageRPCSerializer, NetworkCommDataMessageRPC> m_Request;

		public void OnCreate(ref SystemState state)
		{
			m_Request.OnCreate(ref state);
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			SendRpc jobData = new SendRpc
			{
				data = m_Request.InitJobData(ref state)
			};
			state.Dependency = JobChunkExtensions.Schedule(jobData, m_Request.Query, state.Dependency);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((NetworkCommDataMessageRPCRpcCommandRequestSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_000019F2_0024BurstDirectCall.Invoke(self, state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((NetworkCommDataMessageRPCRpcCommandRequestSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
