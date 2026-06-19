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
	internal struct DebugRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<DebugRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in DebugRpc data)
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
			if (state.GhostFromEntity.HasComponent(data.entity1))
			{
				GhostInstance ghostInstance2 = state.GhostFromEntity[data.entity1];
				writer.WriteInt(ghostInstance2.ghostId);
				writer.WriteUInt(ghostInstance2.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.int0);
			writer.WriteInt(data.int1);
			writer.WriteFloat(data.position0.x);
			writer.WriteFloat(data.position0.y);
			writer.WriteFloat(data.position0.z);
			writer.WriteFloat(data.position1.x);
			writer.WriteFloat(data.position1.y);
			writer.WriteFloat(data.position1.z);
			writer.WriteUInt(data.bool0 ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref DebugRpc data)
		{
			data.command = (DebugCommand)reader.ReadUInt();
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
			int num2 = reader.ReadInt();
			NetworkTick spawnTick2 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.entity1 = Entity.Null;
			if (num2 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num2,
				spawnTick = spawnTick2
			}, out var item2))
			{
				data.entity1 = item2;
			}
			data.int0 = reader.ReadInt();
			data.int1 = reader.ReadInt();
			data.position0.x = reader.ReadFloat();
			data.position0.y = reader.ReadFloat();
			data.position0.z = reader.ReadFloat();
			data.position1.x = reader.ReadFloat();
			data.position1.y = reader.ReadFloat();
			data.position1.z = reader.ReadFloat();
			data.bool0 = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<DebugRpcSerializer, DebugRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<DebugRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in DebugRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<DebugRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref DebugRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
