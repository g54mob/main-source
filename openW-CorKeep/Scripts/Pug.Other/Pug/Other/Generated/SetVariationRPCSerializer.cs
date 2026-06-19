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
	internal struct SetVariationRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<SetVariationRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in SetVariationRPC data)
		{
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
			writer.WriteInt(data.variation);
			writer.WriteInt(data.updateCount);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref SetVariationRPC data)
		{
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
			data.variation = reader.ReadInt();
			data.updateCount = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<SetVariationRPCSerializer, SetVariationRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<SetVariationRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in SetVariationRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<SetVariationRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref SetVariationRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
