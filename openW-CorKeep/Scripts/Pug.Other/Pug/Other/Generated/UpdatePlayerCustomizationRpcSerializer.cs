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
	internal struct UpdatePlayerCustomizationRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<UpdatePlayerCustomizationRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UpdatePlayerCustomizationRpc data)
		{
			writer.WriteFixedString32(data.playerCustomization.name);
			writer.WriteULong((ulong)data.playerCustomization.body.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.body.highBits);
			writer.WriteULong((ulong)data.playerCustomization.skinColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.skinColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.hair.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.hair.highBits);
			writer.WriteULong((ulong)data.playerCustomization.hairColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.hairColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.hairShadeColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.hairShadeColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.eyes.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.eyes.highBits);
			writer.WriteULong((ulong)data.playerCustomization.eyesColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.eyesColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.shirtColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.shirtColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.shirtSkin.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.shirtSkin.highBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsColor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsColor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsSkin.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsSkin.highBits);
			writer.WriteULong((ulong)data.playerCustomization.helm.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.helm.highBits);
			writer.WriteULong((ulong)data.playerCustomization.breastArmor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.breastArmor.highBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsArmor.lowBits);
			writer.WriteULong((ulong)data.playerCustomization.pantsArmor.highBits);
			writer.WriteUInt(data.playerCustomization.role);
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
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UpdatePlayerCustomizationRpc data)
		{
			data.playerCustomization.name = reader.ReadFixedString32();
			data.playerCustomization.body = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.skinColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.hair = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.hairColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.hairShadeColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.eyes = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.eyesColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.shirtColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.shirtSkin = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.pantsColor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.pantsSkin = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.helm = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.breastArmor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.pantsArmor = new DataBlockAddress((long)reader.ReadULong(), (long)reader.ReadULong());
			data.playerCustomization.role = (byte)reader.ReadUInt();
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
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<UpdatePlayerCustomizationRpcSerializer, UpdatePlayerCustomizationRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<UpdatePlayerCustomizationRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UpdatePlayerCustomizationRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<UpdatePlayerCustomizationRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UpdatePlayerCustomizationRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
