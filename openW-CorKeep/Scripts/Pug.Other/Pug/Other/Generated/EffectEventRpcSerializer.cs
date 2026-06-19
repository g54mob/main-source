using System.Runtime.InteropServices;
using AOT;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct EffectEventRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<EffectEventRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in EffectEventRpc data)
		{
			writer.WriteUInt((uint)data.Value.effectID);
			writer.WriteUInt(data.Value.localOnlyEffect);
			writer.WriteFloat(data.Value.position1.x);
			writer.WriteFloat(data.Value.position1.y);
			writer.WriteFloat(data.Value.position1.z);
			writer.WriteFloat(data.Value.vector1.x);
			writer.WriteFloat(data.Value.vector1.y);
			writer.WriteFloat(data.Value.vector1.z);
			writer.WriteInt(data.Value.value1);
			writer.WriteInt(data.Value.value2);
			if (state.GhostFromEntity.HasComponent(data.Value.entity))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.Value.entity];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.Value.entity2))
			{
				GhostInstance ghostInstance2 = state.GhostFromEntity[data.Value.entity2];
				writer.WriteInt(ghostInstance2.ghostId);
				writer.WriteUInt(ghostInstance2.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.Value.tileInfo.tileset);
			writer.WriteInt((int)data.Value.tileInfo.tileType);
			writer.WriteInt(data.Value.tileInfo.state);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref EffectEventRpc data)
		{
			data.Value.effectID = (EffectID)reader.ReadUInt();
			data.Value.localOnlyEffect = (byte)reader.ReadUInt();
			data.Value.position1.x = reader.ReadFloat();
			data.Value.position1.y = reader.ReadFloat();
			data.Value.position1.z = reader.ReadFloat();
			data.Value.vector1.x = reader.ReadFloat();
			data.Value.vector1.y = reader.ReadFloat();
			data.Value.vector1.z = reader.ReadFloat();
			data.Value.value1 = reader.ReadInt();
			data.Value.value2 = reader.ReadInt();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.Value.entity = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.Value.entity = item;
			}
			int num2 = reader.ReadInt();
			NetworkTick spawnTick2 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.Value.entity2 = Entity.Null;
			if (num2 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num2,
				spawnTick = spawnTick2
			}, out var item2))
			{
				data.Value.entity2 = item2;
			}
			data.Value.tileInfo.tileset = reader.ReadInt();
			data.Value.tileInfo.tileType = (TileType)reader.ReadInt();
			data.Value.tileInfo.state = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<EffectEventRpcSerializer, EffectEventRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<EffectEventRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in EffectEventRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<EffectEventRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref EffectEventRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
