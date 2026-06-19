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
	internal struct NetworkCommandRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<NetworkCommandRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommandRpc data)
		{
			writer.WriteInt((int)data.command);
			if (state.GhostFromEntity.HasComponent(data.entity0))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.entity0];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.int0);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommandRpc data)
		{
			data.command = (NetworkCommand)reader.ReadInt();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.entity0 = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.entity0 = item;
			}
			data.int0 = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<NetworkCommandRpcSerializer, NetworkCommandRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<NetworkCommandRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in NetworkCommandRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<NetworkCommandRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref NetworkCommandRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
