using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Dev.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct GoToObjectRequestSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<GoToObjectRequest>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in GoToObjectRequest data)
		{
			if (state.GhostFromEntity.HasComponent(data.EntityToMove))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.EntityToMove];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt((int)data.ObjectID);
			writer.WriteFloat(data.Position.x);
			writer.WriteFloat(data.Position.y);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref GoToObjectRequest data)
		{
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.EntityToMove = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.EntityToMove = item;
			}
			data.ObjectID = (ObjectID)reader.ReadInt();
			data.Position.x = reader.ReadFloat();
			data.Position.y = reader.ReadFloat();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<GoToObjectRequestSerializer, GoToObjectRequest>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<GoToObjectRequest>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in GoToObjectRequest data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<GoToObjectRequest>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref GoToObjectRequest data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
