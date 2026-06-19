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
	internal struct PlayOutroClientSystem_PlayOutroRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PlayOutroClientSystem.PlayOutroRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayOutroClientSystem.PlayOutroRPC data)
		{
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayOutroClientSystem.PlayOutroRPC data)
		{
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PlayOutroClientSystem_PlayOutroRPCSerializer, PlayOutroClientSystem.PlayOutroRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PlayOutroClientSystem.PlayOutroRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayOutroClientSystem.PlayOutroRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PlayOutroClientSystem.PlayOutroRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayOutroClientSystem.PlayOutroRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
