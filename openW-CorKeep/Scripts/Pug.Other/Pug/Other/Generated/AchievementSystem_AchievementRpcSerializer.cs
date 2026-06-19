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
	internal struct AchievementSystem_AchievementRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<AchievementSystem.AchievementRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in AchievementSystem.AchievementRpc data)
		{
			writer.WriteInt((int)data.AchievementID);
			if (state.GhostFromEntity.HasComponent(data.playerEntity))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.playerEntity];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref AchievementSystem.AchievementRpc data)
		{
			data.AchievementID = (AchievementID)reader.ReadInt();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.playerEntity = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.playerEntity = item;
			}
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<AchievementSystem_AchievementRpcSerializer, AchievementSystem.AchievementRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<AchievementSystem.AchievementRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in AchievementSystem.AchievementRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<AchievementSystem.AchievementRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref AchievementSystem.AchievementRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
