using System.Runtime.InteropServices;
using AOT;
using PlayerCommand;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct RpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<Rpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in Rpc data)
		{
			writer.WriteUInt((uint)data.command);
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
			writer.WriteInt(data.int1);
			writer.WriteInt(data.int2);
			writer.WriteInt(data.int3);
			writer.WriteFloat(data.position0.x);
			writer.WriteFloat(data.position0.y);
			writer.WriteFloat(data.position0.z);
			writer.WriteFloat(data.position1.x);
			writer.WriteFloat(data.position1.y);
			writer.WriteFloat(data.position1.z);
			writer.WriteUInt(data.bool0 ? 1u : 0u);
			writer.WriteFloat(data.float0);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref Rpc data)
		{
			data.command = (Command)reader.ReadUInt();
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
			data.int1 = reader.ReadInt();
			data.int2 = reader.ReadInt();
			data.int3 = reader.ReadInt();
			data.position0.x = reader.ReadFloat();
			data.position0.y = reader.ReadFloat();
			data.position0.z = reader.ReadFloat();
			data.position1.x = reader.ReadFloat();
			data.position1.y = reader.ReadFloat();
			data.position1.z = reader.ReadFloat();
			data.bool0 = ((reader.ReadUInt() != 0) ? true : false);
			data.float0 = reader.ReadFloat();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<RpcSerializer, Rpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<Rpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in Rpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<Rpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref Rpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
