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
	internal struct PlayerConnectRequestRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PlayerConnectRequestRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayerConnectRequestRPC data)
		{
			writer.WriteUInt(data.isOwner ? 1u : 0u);
			writer.WriteUInt(data.serverVersion);
			writer.WriteUInt(data.serverMinorVersion);
			writer.WriteULong(data.ghostCollectionHash);
			writer.WriteUInt(data.platform);
			writer.WriteUInt(data.allowCrossPlay ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayerConnectRequestRPC data)
		{
			data.isOwner = ((reader.ReadUInt() != 0) ? true : false);
			data.serverVersion = reader.ReadUInt();
			data.serverMinorVersion = reader.ReadUInt();
			data.ghostCollectionHash = reader.ReadULong();
			data.platform = (byte)reader.ReadUInt();
			data.allowCrossPlay = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PlayerConnectRequestRPCSerializer, PlayerConnectRequestRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PlayerConnectRequestRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayerConnectRequestRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PlayerConnectRequestRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayerConnectRequestRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
