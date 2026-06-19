using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct PlayerConnectResponseRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PlayerConnectResponseRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayerConnectResponseRPC data)
		{
			writer.WriteUInt(data.rejected ? 1u : 0u);
			writer.WriteUInt(data.minorVersionMismatch ? 1u : 0u);
			writer.WriteUInt(data.streamIntegrationEnabled ? 1u : 0u);
			writer.WriteFixedString64(data.reason);
			writer.WriteUInt(data.serverGuid.Value.x);
			writer.WriteUInt(data.serverGuid.Value.y);
			writer.WriteUInt(data.serverGuid.Value.z);
			writer.WriteUInt(data.serverGuid.Value.w);
			writer.WriteUInt(data.serverSessionId.Value.x);
			writer.WriteUInt(data.serverSessionId.Value.y);
			writer.WriteUInt(data.serverSessionId.Value.z);
			writer.WriteUInt(data.serverSessionId.Value.w);
			writer.WriteFixedString64(data.serverName);
			writer.WriteUInt(data.serverSeed);
			writer.WriteInt(data.season);
			writer.WriteInt((int)data.worldMode);
			writer.WriteInt((int)data.worldGenerationType);
			writer.WriteUInt(data.biomeCompassDirections.offset0000);
			writer.WriteUInt(data.biomeCompassDirections.offset0004);
			writer.WriteUInt(data.biomeCompassDirections.offset0008);
			writer.WriteUInt(data.biomeCompassDirections.offset0012);
			writer.WriteUInt(data.biomeCompassDirections.offset0016);
			writer.WriteUInt(data.biomeCompassDirections.offset0020);
			writer.WriteUInt(data.biomeCompassDirections.offset0024);
			writer.WriteUInt(data.biomeCompassDirections.offset0028);
			writer.WriteUInt(data.biomeCompassDirections.offset0032);
			writer.WriteUInt(data.biomeCompassDirections.offset0036);
			writer.WriteUInt(data.biomeCompassDirections.offset0040);
			writer.WriteUInt(data.biomeCompassDirections.offset0044);
			writer.WriteUInt(data.biomeCompassDirections.offset0048);
			writer.WriteUInt(data.biomeCompassDirections.offset0052);
			writer.WriteUInt(data.biomeCompassDirections.offset0056);
			writer.WriteUInt(data.biomeCompassDirections.offset0060);
			writer.WriteFixedString64(data.serverVersionString);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayerConnectResponseRPC data)
		{
			data.rejected = ((reader.ReadUInt() != 0) ? true : false);
			data.minorVersionMismatch = ((reader.ReadUInt() != 0) ? true : false);
			data.streamIntegrationEnabled = ((reader.ReadUInt() != 0) ? true : false);
			data.reason = reader.ReadFixedString64();
			data.serverGuid.Value.x = reader.ReadUInt();
			data.serverGuid.Value.y = reader.ReadUInt();
			data.serverGuid.Value.z = reader.ReadUInt();
			data.serverGuid.Value.w = reader.ReadUInt();
			data.serverSessionId.Value.x = reader.ReadUInt();
			data.serverSessionId.Value.y = reader.ReadUInt();
			data.serverSessionId.Value.z = reader.ReadUInt();
			data.serverSessionId.Value.w = reader.ReadUInt();
			data.serverName = reader.ReadFixedString64();
			data.serverSeed = reader.ReadUInt();
			data.season = reader.ReadInt();
			data.worldMode = (WorldMode)reader.ReadInt();
			data.worldGenerationType = (WorldGenerationType)reader.ReadInt();
			data.biomeCompassDirections.offset0000 = reader.ReadUInt();
			data.biomeCompassDirections.offset0004 = reader.ReadUInt();
			data.biomeCompassDirections.offset0008 = reader.ReadUInt();
			data.biomeCompassDirections.offset0012 = reader.ReadUInt();
			data.biomeCompassDirections.offset0016 = reader.ReadUInt();
			data.biomeCompassDirections.offset0020 = reader.ReadUInt();
			data.biomeCompassDirections.offset0024 = reader.ReadUInt();
			data.biomeCompassDirections.offset0028 = reader.ReadUInt();
			data.biomeCompassDirections.offset0032 = reader.ReadUInt();
			data.biomeCompassDirections.offset0036 = reader.ReadUInt();
			data.biomeCompassDirections.offset0040 = reader.ReadUInt();
			data.biomeCompassDirections.offset0044 = reader.ReadUInt();
			data.biomeCompassDirections.offset0048 = reader.ReadUInt();
			data.biomeCompassDirections.offset0052 = reader.ReadUInt();
			data.biomeCompassDirections.offset0056 = reader.ReadUInt();
			data.biomeCompassDirections.offset0060 = reader.ReadUInt();
			data.serverVersionString = reader.ReadFixedString64();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PlayerConnectResponseRPCSerializer, PlayerConnectResponseRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PlayerConnectResponseRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PlayerConnectResponseRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PlayerConnectResponseRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PlayerConnectResponseRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
