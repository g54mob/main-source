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
	internal struct TextRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<TextRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in TextRpc data)
		{
			writer.WriteUInt((uint)data.command);
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
			writer.WriteFixedString64(data.text);
			writer.WriteInt(data.rpcId);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref TextRpc data)
		{
			data.command = (Command)reader.ReadUInt();
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
			data.text = reader.ReadFixedString64();
			data.rpcId = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<TextRpcSerializer, TextRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<TextRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in TextRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<TextRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref TextRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
