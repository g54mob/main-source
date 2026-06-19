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
	internal struct AttackPlayerRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<AttackPlayerRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in AttackPlayerRPC data)
		{
			writer.WriteInt(data.attackerGhost.ghostId);
			writer.WriteUInt(data.attackerGhost.spawnTick.SerializedData);
			writer.WriteUInt(data.startServerTick.SerializedData);
			writer.WriteUInt(data.endServerTick.SerializedData);
			writer.WriteFloat(data.startPosition.x);
			writer.WriteFloat(data.startPosition.y);
			writer.WriteFloat(data.startPosition.z);
			writer.WriteFloat(data.attackOffset.x);
			writer.WriteFloat(data.attackOffset.y);
			writer.WriteFloat(data.attackOffset.z);
			writer.WriteFloat(data.direction.x);
			writer.WriteFloat(data.direction.y);
			writer.WriteFloat(data.direction.z);
			writer.WriteFloat(data.radius);
			writer.WriteFloat(data.boxHorizontalWidth);
			writer.WriteFloat(data.boxVerticalWidth);
			writer.WriteFloat(data.rotation.value.x);
			writer.WriteFloat(data.rotation.value.y);
			writer.WriteFloat(data.rotation.value.z);
			writer.WriteFloat(data.rotation.value.w);
			writer.WriteInt(data.damage);
			writer.WriteUInt((uint)data.damageEffectType);
			writer.WriteInt(data.reverseDamage);
			writer.WriteFloat(data.pushback);
			writer.WriteFloat(data.reversePushback);
			writer.WriteInt(data.triggerAnimationOnHit);
			writer.WriteFloat(data.castDistance);
			writer.WriteUInt(data.checkVisibility ? 1u : 0u);
			writer.WriteUInt(data.isRanged ? 1u : 0u);
			writer.WriteUInt(data.isBoss ? 1u : 0u);
			writer.WriteUInt(data.isMinion ? 1u : 0u);
			writer.WriteUInt(data.isPet ? 1u : 0u);
			writer.WriteUInt(data.isExplosive ? 1u : 0u);
			writer.WriteUInt(data.isExplosiveDamageFromBomb ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref AttackPlayerRPC data)
		{
			data.attackerGhost.ghostId = reader.ReadInt();
			data.attackerGhost.spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.startServerTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.endServerTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.startPosition.x = reader.ReadFloat();
			data.startPosition.y = reader.ReadFloat();
			data.startPosition.z = reader.ReadFloat();
			data.attackOffset.x = reader.ReadFloat();
			data.attackOffset.y = reader.ReadFloat();
			data.attackOffset.z = reader.ReadFloat();
			data.direction.x = reader.ReadFloat();
			data.direction.y = reader.ReadFloat();
			data.direction.z = reader.ReadFloat();
			data.radius = reader.ReadFloat();
			data.boxHorizontalWidth = reader.ReadFloat();
			data.boxVerticalWidth = reader.ReadFloat();
			data.rotation.value.x = reader.ReadFloat();
			data.rotation.value.y = reader.ReadFloat();
			data.rotation.value.z = reader.ReadFloat();
			data.rotation.value.w = reader.ReadFloat();
			data.damage = reader.ReadInt();
			data.damageEffectType = (DamageEffectType)reader.ReadUInt();
			data.reverseDamage = reader.ReadInt();
			data.pushback = reader.ReadFloat();
			data.reversePushback = reader.ReadFloat();
			data.triggerAnimationOnHit = reader.ReadInt();
			data.castDistance = reader.ReadFloat();
			data.checkVisibility = ((reader.ReadUInt() != 0) ? true : false);
			data.isRanged = ((reader.ReadUInt() != 0) ? true : false);
			data.isBoss = ((reader.ReadUInt() != 0) ? true : false);
			data.isMinion = ((reader.ReadUInt() != 0) ? true : false);
			data.isPet = ((reader.ReadUInt() != 0) ? true : false);
			data.isExplosive = ((reader.ReadUInt() != 0) ? true : false);
			data.isExplosiveDamageFromBomb = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<AttackPlayerRPCSerializer, AttackPlayerRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<AttackPlayerRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in AttackPlayerRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<AttackPlayerRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref AttackPlayerRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
