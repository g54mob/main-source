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
	internal struct PlayRespawnSequenceClientSystem_PlayRespawnSequenceRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC data)
		{
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC data)
		{
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PlayRespawnSequenceClientSystem_PlayRespawnSequenceRPCSerializer, PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayRespawnSequenceClientSystem.PlayRespawnSequenceRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
