using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct ListMapRequestSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<ListMapRequest>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ListMapRequest data)
		{
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ListMapRequest data)
		{
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<ListMapRequestSerializer, ListMapRequest>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<ListMapRequest>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ListMapRequest data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<ListMapRequest>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ListMapRequest data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
