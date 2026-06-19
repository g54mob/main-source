using System.Runtime.InteropServices;
using AOT;
using NetworkedEcb;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct NetworkedEcbRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<NetworkedEcbRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkedEcbRpc data)
		{
			writer.WriteInt((int)data.command);
			if (state.GhostFromEntity.HasComponent(data.entity))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.entity];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteULong(data.componentTypeHash);
			writer.WriteUInt(data.data.offset0000);
			writer.WriteUInt(data.data.offset0004);
			writer.WriteUInt(data.data.offset0008);
			writer.WriteUInt(data.data.offset0012);
			writer.WriteUInt(data.data.offset0016);
			writer.WriteUInt(data.data.offset0020);
			writer.WriteUInt(data.data.offset0024);
			writer.WriteUInt(data.data.offset0028);
			writer.WriteUInt(data.data.offset0032);
			writer.WriteUInt(data.data.offset0036);
			writer.WriteUInt(data.data.offset0040);
			writer.WriteUInt(data.data.offset0044);
			writer.WriteUInt(data.data.offset0048);
			writer.WriteUInt(data.data.offset0052);
			writer.WriteUInt(data.data.offset0056);
			writer.WriteUInt(data.data.offset0060);
			writer.WriteInt(data.dataLength);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkedEcbRpc data)
		{
			data.command = (NetworkedEcbCommand)reader.ReadInt();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.entity = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.entity = item;
			}
			data.componentTypeHash = reader.ReadULong();
			data.data.offset0000 = reader.ReadUInt();
			data.data.offset0004 = reader.ReadUInt();
			data.data.offset0008 = reader.ReadUInt();
			data.data.offset0012 = reader.ReadUInt();
			data.data.offset0016 = reader.ReadUInt();
			data.data.offset0020 = reader.ReadUInt();
			data.data.offset0024 = reader.ReadUInt();
			data.data.offset0028 = reader.ReadUInt();
			data.data.offset0032 = reader.ReadUInt();
			data.data.offset0036 = reader.ReadUInt();
			data.data.offset0040 = reader.ReadUInt();
			data.data.offset0044 = reader.ReadUInt();
			data.data.offset0048 = reader.ReadUInt();
			data.data.offset0052 = reader.ReadUInt();
			data.data.offset0056 = reader.ReadUInt();
			data.data.offset0060 = reader.ReadUInt();
			data.dataLength = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<NetworkedEcbRpcSerializer, NetworkedEcbRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<NetworkedEcbRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkedEcbRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<NetworkedEcbRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkedEcbRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
