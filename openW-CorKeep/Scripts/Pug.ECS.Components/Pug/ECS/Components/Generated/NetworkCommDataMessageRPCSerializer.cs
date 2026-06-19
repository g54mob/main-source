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
	internal struct NetworkCommDataMessageRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<NetworkCommDataMessageRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommDataMessageRPC data)
		{
			writer.WriteInt(data.messageNumber);
			writer.WriteUInt(data.messagePart.offset0000);
			writer.WriteUInt(data.messagePart.offset0004);
			writer.WriteUInt(data.messagePart.offset0008);
			writer.WriteUInt(data.messagePart.offset0012);
			writer.WriteUInt(data.messagePart.offset0016);
			writer.WriteUInt(data.messagePart.offset0020);
			writer.WriteUInt(data.messagePart.offset0024);
			writer.WriteUInt(data.messagePart.offset0028);
			writer.WriteUInt(data.messagePart.offset0032);
			writer.WriteUInt(data.messagePart.offset0036);
			writer.WriteUInt(data.messagePart.offset0040);
			writer.WriteUInt(data.messagePart.offset0044);
			writer.WriteUInt(data.messagePart.offset0048);
			writer.WriteUInt(data.messagePart.offset0052);
			writer.WriteUInt(data.messagePart.offset0056);
			writer.WriteUInt(data.messagePart.offset0060);
			writer.WriteInt(data.startByte);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommDataMessageRPC data)
		{
			data.messageNumber = reader.ReadInt();
			data.messagePart.offset0000 = reader.ReadUInt();
			data.messagePart.offset0004 = reader.ReadUInt();
			data.messagePart.offset0008 = reader.ReadUInt();
			data.messagePart.offset0012 = reader.ReadUInt();
			data.messagePart.offset0016 = reader.ReadUInt();
			data.messagePart.offset0020 = reader.ReadUInt();
			data.messagePart.offset0024 = reader.ReadUInt();
			data.messagePart.offset0028 = reader.ReadUInt();
			data.messagePart.offset0032 = reader.ReadUInt();
			data.messagePart.offset0036 = reader.ReadUInt();
			data.messagePart.offset0040 = reader.ReadUInt();
			data.messagePart.offset0044 = reader.ReadUInt();
			data.messagePart.offset0048 = reader.ReadUInt();
			data.messagePart.offset0052 = reader.ReadUInt();
			data.messagePart.offset0056 = reader.ReadUInt();
			data.messagePart.offset0060 = reader.ReadUInt();
			data.startByte = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<NetworkCommDataMessageRPCSerializer, NetworkCommDataMessageRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<NetworkCommDataMessageRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommDataMessageRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<NetworkCommDataMessageRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommDataMessageRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
