using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct NetworkCommMessageRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<NetworkCommMessageRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommMessageRPC data)
		{
			writer.WriteInt(data.messageNumber);
			writer.WriteInt((int)data.messageType);
			writer.WriteInt(data.totalSize);
			writer.WriteUInt(data.platform);
			writer.WriteULong(data.platformID);
			writer.WriteUInt(data.isStreamIntegrationMessage ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommMessageRPC data)
		{
			data.messageNumber = reader.ReadInt();
			data.messageType = (NetworkCommMessageType)reader.ReadInt();
			data.totalSize = reader.ReadInt();
			data.platform = (byte)reader.ReadUInt();
			data.platformID = reader.ReadULong();
			data.isStreamIntegrationMessage = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<NetworkCommMessageRPCSerializer, NetworkCommMessageRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<NetworkCommMessageRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommMessageRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<NetworkCommMessageRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommMessageRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
