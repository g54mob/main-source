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
	internal struct NetworkCommandResponseRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<NetworkCommandResponseRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommandResponseRpc data)
		{
			writer.WriteInt((int)data.command);
			writer.WriteFixedString128(data.string0);
			writer.WriteInt(data.int0);
			writer.WriteInt(data.int1);
			writer.WriteULong(data.ulong1);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommandResponseRpc data)
		{
			data.command = (NetworkCommand)reader.ReadInt();
			data.string0 = reader.ReadFixedString128();
			data.int0 = reader.ReadInt();
			data.int1 = reader.ReadInt();
			data.ulong1 = reader.ReadULong();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<NetworkCommandResponseRpcSerializer, NetworkCommandResponseRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<NetworkCommandResponseRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommandResponseRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<NetworkCommandResponseRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommandResponseRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
