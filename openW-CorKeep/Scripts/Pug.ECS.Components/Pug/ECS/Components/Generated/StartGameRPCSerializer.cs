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
	internal struct StartGameRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<StartGameRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in StartGameRPC data)
		{
			writer.WriteUInt(data.playerGuid.Value.x);
			writer.WriteUInt(data.playerGuid.Value.y);
			writer.WriteUInt(data.playerGuid.Value.z);
			writer.WriteUInt(data.playerGuid.Value.w);
			writer.WriteUInt(data.dataPart.offset0000.offset0000);
			writer.WriteUInt(data.dataPart.offset0000.offset0004);
			writer.WriteUInt(data.dataPart.offset0000.offset0008);
			writer.WriteUInt(data.dataPart.offset0000.offset0012);
			writer.WriteUInt(data.dataPart.offset0000.offset0016);
			writer.WriteUInt(data.dataPart.offset0000.offset0020);
			writer.WriteUInt(data.dataPart.offset0000.offset0024);
			writer.WriteUInt(data.dataPart.offset0000.offset0028);
			writer.WriteUInt(data.dataPart.offset0000.offset0032);
			writer.WriteUInt(data.dataPart.offset0000.offset0036);
			writer.WriteUInt(data.dataPart.offset0000.offset0040);
			writer.WriteUInt(data.dataPart.offset0000.offset0044);
			writer.WriteUInt(data.dataPart.offset0000.offset0048);
			writer.WriteUInt(data.dataPart.offset0000.offset0052);
			writer.WriteUInt(data.dataPart.offset0000.offset0056);
			writer.WriteUInt(data.dataPart.offset0000.offset0060);
			writer.WriteUInt(data.dataPart.offset0064.offset0000);
			writer.WriteUInt(data.dataPart.offset0064.offset0004);
			writer.WriteUInt(data.dataPart.offset0064.offset0008);
			writer.WriteUInt(data.dataPart.offset0064.offset0012);
			writer.WriteUInt(data.dataPart.offset0064.offset0016);
			writer.WriteUInt(data.dataPart.offset0064.offset0020);
			writer.WriteUInt(data.dataPart.offset0064.offset0024);
			writer.WriteUInt(data.dataPart.offset0064.offset0028);
			writer.WriteUInt(data.dataPart.offset0064.offset0032);
			writer.WriteUInt(data.dataPart.offset0064.offset0036);
			writer.WriteUInt(data.dataPart.offset0064.offset0040);
			writer.WriteUInt(data.dataPart.offset0064.offset0044);
			writer.WriteUInt(data.dataPart.offset0064.offset0048);
			writer.WriteUInt(data.dataPart.offset0064.offset0052);
			writer.WriteUInt(data.dataPart.offset0064.offset0056);
			writer.WriteUInt(data.dataPart.offset0064.offset0060);
			writer.WriteUInt(data.dataPart.offset0128.offset0000);
			writer.WriteUInt(data.dataPart.offset0128.offset0004);
			writer.WriteUInt(data.dataPart.offset0128.offset0008);
			writer.WriteUInt(data.dataPart.offset0128.offset0012);
			writer.WriteUInt(data.dataPart.offset0128.offset0016);
			writer.WriteUInt(data.dataPart.offset0128.offset0020);
			writer.WriteUInt(data.dataPart.offset0128.offset0024);
			writer.WriteUInt(data.dataPart.offset0128.offset0028);
			writer.WriteUInt(data.dataPart.offset0128.offset0032);
			writer.WriteUInt(data.dataPart.offset0128.offset0036);
			writer.WriteUInt(data.dataPart.offset0128.offset0040);
			writer.WriteUInt(data.dataPart.offset0128.offset0044);
			writer.WriteUInt(data.dataPart.offset0128.offset0048);
			writer.WriteUInt(data.dataPart.offset0128.offset0052);
			writer.WriteUInt(data.dataPart.offset0128.offset0056);
			writer.WriteUInt(data.dataPart.offset0128.offset0060);
			writer.WriteUInt(data.dataPart.offset0192.offset0000);
			writer.WriteUInt(data.dataPart.offset0192.offset0004);
			writer.WriteUInt(data.dataPart.offset0192.offset0008);
			writer.WriteUInt(data.dataPart.offset0192.offset0012);
			writer.WriteUInt(data.dataPart.offset0192.offset0016);
			writer.WriteUInt(data.dataPart.offset0192.offset0020);
			writer.WriteUInt(data.dataPart.offset0192.offset0024);
			writer.WriteUInt(data.dataPart.offset0192.offset0028);
			writer.WriteUInt(data.dataPart.offset0192.offset0032);
			writer.WriteUInt(data.dataPart.offset0192.offset0036);
			writer.WriteUInt(data.dataPart.offset0192.offset0040);
			writer.WriteUInt(data.dataPart.offset0192.offset0044);
			writer.WriteUInt(data.dataPart.offset0192.offset0048);
			writer.WriteUInt(data.dataPart.offset0192.offset0052);
			writer.WriteUInt(data.dataPart.offset0192.offset0056);
			writer.WriteUInt(data.dataPart.offset0192.offset0060);
			writer.WriteUInt(data.dataPart.offset0256.offset0000);
			writer.WriteUInt(data.dataPart.offset0256.offset0004);
			writer.WriteUInt(data.dataPart.offset0256.offset0008);
			writer.WriteUInt(data.dataPart.offset0256.offset0012);
			writer.WriteUInt(data.dataPart.offset0256.offset0016);
			writer.WriteUInt(data.dataPart.offset0256.offset0020);
			writer.WriteUInt(data.dataPart.offset0256.offset0024);
			writer.WriteUInt(data.dataPart.offset0256.offset0028);
			writer.WriteUInt(data.dataPart.offset0256.offset0032);
			writer.WriteUInt(data.dataPart.offset0256.offset0036);
			writer.WriteUInt(data.dataPart.offset0256.offset0040);
			writer.WriteUInt(data.dataPart.offset0256.offset0044);
			writer.WriteUInt(data.dataPart.offset0256.offset0048);
			writer.WriteUInt(data.dataPart.offset0256.offset0052);
			writer.WriteUInt(data.dataPart.offset0256.offset0056);
			writer.WriteUInt(data.dataPart.offset0256.offset0060);
			writer.WriteUInt(data.dataPart.offset0320.offset0000);
			writer.WriteUInt(data.dataPart.offset0320.offset0004);
			writer.WriteUInt(data.dataPart.offset0320.offset0008);
			writer.WriteUInt(data.dataPart.offset0320.offset0012);
			writer.WriteUInt(data.dataPart.offset0320.offset0016);
			writer.WriteUInt(data.dataPart.offset0320.offset0020);
			writer.WriteUInt(data.dataPart.offset0320.offset0024);
			writer.WriteUInt(data.dataPart.offset0320.offset0028);
			writer.WriteUInt(data.dataPart.offset0320.offset0032);
			writer.WriteUInt(data.dataPart.offset0320.offset0036);
			writer.WriteUInt(data.dataPart.offset0320.offset0040);
			writer.WriteUInt(data.dataPart.offset0320.offset0044);
			writer.WriteUInt(data.dataPart.offset0320.offset0048);
			writer.WriteUInt(data.dataPart.offset0320.offset0052);
			writer.WriteUInt(data.dataPart.offset0320.offset0056);
			writer.WriteUInt(data.dataPart.offset0320.offset0060);
			writer.WriteUInt(data.dataPart.offset0384.offset0000);
			writer.WriteUInt(data.dataPart.offset0384.offset0004);
			writer.WriteUInt(data.dataPart.offset0384.offset0008);
			writer.WriteUInt(data.dataPart.offset0384.offset0012);
			writer.WriteUInt(data.dataPart.offset0384.offset0016);
			writer.WriteUInt(data.dataPart.offset0384.offset0020);
			writer.WriteUInt(data.dataPart.offset0384.offset0024);
			writer.WriteUInt(data.dataPart.offset0384.offset0028);
			writer.WriteUInt(data.dataPart.offset0384.offset0032);
			writer.WriteUInt(data.dataPart.offset0384.offset0036);
			writer.WriteUInt(data.dataPart.offset0384.offset0040);
			writer.WriteUInt(data.dataPart.offset0384.offset0044);
			writer.WriteUInt(data.dataPart.offset0384.offset0048);
			writer.WriteUInt(data.dataPart.offset0384.offset0052);
			writer.WriteUInt(data.dataPart.offset0384.offset0056);
			writer.WriteUInt(data.dataPart.offset0384.offset0060);
			writer.WriteUInt(data.dataPart.offset0448.offset0000);
			writer.WriteUInt(data.dataPart.offset0448.offset0004);
			writer.WriteUInt(data.dataPart.offset0448.offset0008);
			writer.WriteUInt(data.dataPart.offset0448.offset0012);
			writer.WriteUInt(data.dataPart.offset0448.offset0016);
			writer.WriteUInt(data.dataPart.offset0448.offset0020);
			writer.WriteUInt(data.dataPart.offset0448.offset0024);
			writer.WriteUInt(data.dataPart.offset0448.offset0028);
			writer.WriteUInt(data.dataPart.offset0448.offset0032);
			writer.WriteUInt(data.dataPart.offset0448.offset0036);
			writer.WriteUInt(data.dataPart.offset0448.offset0040);
			writer.WriteUInt(data.dataPart.offset0448.offset0044);
			writer.WriteUInt(data.dataPart.offset0448.offset0048);
			writer.WriteUInt(data.dataPart.offset0448.offset0052);
			writer.WriteUInt(data.dataPart.offset0448.offset0056);
			writer.WriteUInt(data.dataPart.offset0448.offset0060);
			writer.WriteUInt(data.dataPartStart);
			writer.WriteUInt(data.dataPartSize);
			writer.WriteUInt(data.totalDataSize);
			writer.WriteULong(data.onlineID);
			writer.WriteFixedString32(data.onlineName);
			writer.WriteUInt(data.isThinClient ? 1u : 0u);
			writer.WriteUInt(data.platform);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref StartGameRPC data)
		{
			data.playerGuid.Value.x = reader.ReadUInt();
			data.playerGuid.Value.y = reader.ReadUInt();
			data.playerGuid.Value.z = reader.ReadUInt();
			data.playerGuid.Value.w = reader.ReadUInt();
			data.dataPart.offset0000.offset0000 = reader.ReadUInt();
			data.dataPart.offset0000.offset0004 = reader.ReadUInt();
			data.dataPart.offset0000.offset0008 = reader.ReadUInt();
			data.dataPart.offset0000.offset0012 = reader.ReadUInt();
			data.dataPart.offset0000.offset0016 = reader.ReadUInt();
			data.dataPart.offset0000.offset0020 = reader.ReadUInt();
			data.dataPart.offset0000.offset0024 = reader.ReadUInt();
			data.dataPart.offset0000.offset0028 = reader.ReadUInt();
			data.dataPart.offset0000.offset0032 = reader.ReadUInt();
			data.dataPart.offset0000.offset0036 = reader.ReadUInt();
			data.dataPart.offset0000.offset0040 = reader.ReadUInt();
			data.dataPart.offset0000.offset0044 = reader.ReadUInt();
			data.dataPart.offset0000.offset0048 = reader.ReadUInt();
			data.dataPart.offset0000.offset0052 = reader.ReadUInt();
			data.dataPart.offset0000.offset0056 = reader.ReadUInt();
			data.dataPart.offset0000.offset0060 = reader.ReadUInt();
			data.dataPart.offset0064.offset0000 = reader.ReadUInt();
			data.dataPart.offset0064.offset0004 = reader.ReadUInt();
			data.dataPart.offset0064.offset0008 = reader.ReadUInt();
			data.dataPart.offset0064.offset0012 = reader.ReadUInt();
			data.dataPart.offset0064.offset0016 = reader.ReadUInt();
			data.dataPart.offset0064.offset0020 = reader.ReadUInt();
			data.dataPart.offset0064.offset0024 = reader.ReadUInt();
			data.dataPart.offset0064.offset0028 = reader.ReadUInt();
			data.dataPart.offset0064.offset0032 = reader.ReadUInt();
			data.dataPart.offset0064.offset0036 = reader.ReadUInt();
			data.dataPart.offset0064.offset0040 = reader.ReadUInt();
			data.dataPart.offset0064.offset0044 = reader.ReadUInt();
			data.dataPart.offset0064.offset0048 = reader.ReadUInt();
			data.dataPart.offset0064.offset0052 = reader.ReadUInt();
			data.dataPart.offset0064.offset0056 = reader.ReadUInt();
			data.dataPart.offset0064.offset0060 = reader.ReadUInt();
			data.dataPart.offset0128.offset0000 = reader.ReadUInt();
			data.dataPart.offset0128.offset0004 = reader.ReadUInt();
			data.dataPart.offset0128.offset0008 = reader.ReadUInt();
			data.dataPart.offset0128.offset0012 = reader.ReadUInt();
			data.dataPart.offset0128.offset0016 = reader.ReadUInt();
			data.dataPart.offset0128.offset0020 = reader.ReadUInt();
			data.dataPart.offset0128.offset0024 = reader.ReadUInt();
			data.dataPart.offset0128.offset0028 = reader.ReadUInt();
			data.dataPart.offset0128.offset0032 = reader.ReadUInt();
			data.dataPart.offset0128.offset0036 = reader.ReadUInt();
			data.dataPart.offset0128.offset0040 = reader.ReadUInt();
			data.dataPart.offset0128.offset0044 = reader.ReadUInt();
			data.dataPart.offset0128.offset0048 = reader.ReadUInt();
			data.dataPart.offset0128.offset0052 = reader.ReadUInt();
			data.dataPart.offset0128.offset0056 = reader.ReadUInt();
			data.dataPart.offset0128.offset0060 = reader.ReadUInt();
			data.dataPart.offset0192.offset0000 = reader.ReadUInt();
			data.dataPart.offset0192.offset0004 = reader.ReadUInt();
			data.dataPart.offset0192.offset0008 = reader.ReadUInt();
			data.dataPart.offset0192.offset0012 = reader.ReadUInt();
			data.dataPart.offset0192.offset0016 = reader.ReadUInt();
			data.dataPart.offset0192.offset0020 = reader.ReadUInt();
			data.dataPart.offset0192.offset0024 = reader.ReadUInt();
			data.dataPart.offset0192.offset0028 = reader.ReadUInt();
			data.dataPart.offset0192.offset0032 = reader.ReadUInt();
			data.dataPart.offset0192.offset0036 = reader.ReadUInt();
			data.dataPart.offset0192.offset0040 = reader.ReadUInt();
			data.dataPart.offset0192.offset0044 = reader.ReadUInt();
			data.dataPart.offset0192.offset0048 = reader.ReadUInt();
			data.dataPart.offset0192.offset0052 = reader.ReadUInt();
			data.dataPart.offset0192.offset0056 = reader.ReadUInt();
			data.dataPart.offset0192.offset0060 = reader.ReadUInt();
			data.dataPart.offset0256.offset0000 = reader.ReadUInt();
			data.dataPart.offset0256.offset0004 = reader.ReadUInt();
			data.dataPart.offset0256.offset0008 = reader.ReadUInt();
			data.dataPart.offset0256.offset0012 = reader.ReadUInt();
			data.dataPart.offset0256.offset0016 = reader.ReadUInt();
			data.dataPart.offset0256.offset0020 = reader.ReadUInt();
			data.dataPart.offset0256.offset0024 = reader.ReadUInt();
			data.dataPart.offset0256.offset0028 = reader.ReadUInt();
			data.dataPart.offset0256.offset0032 = reader.ReadUInt();
			data.dataPart.offset0256.offset0036 = reader.ReadUInt();
			data.dataPart.offset0256.offset0040 = reader.ReadUInt();
			data.dataPart.offset0256.offset0044 = reader.ReadUInt();
			data.dataPart.offset0256.offset0048 = reader.ReadUInt();
			data.dataPart.offset0256.offset0052 = reader.ReadUInt();
			data.dataPart.offset0256.offset0056 = reader.ReadUInt();
			data.dataPart.offset0256.offset0060 = reader.ReadUInt();
			data.dataPart.offset0320.offset0000 = reader.ReadUInt();
			data.dataPart.offset0320.offset0004 = reader.ReadUInt();
			data.dataPart.offset0320.offset0008 = reader.ReadUInt();
			data.dataPart.offset0320.offset0012 = reader.ReadUInt();
			data.dataPart.offset0320.offset0016 = reader.ReadUInt();
			data.dataPart.offset0320.offset0020 = reader.ReadUInt();
			data.dataPart.offset0320.offset0024 = reader.ReadUInt();
			data.dataPart.offset0320.offset0028 = reader.ReadUInt();
			data.dataPart.offset0320.offset0032 = reader.ReadUInt();
			data.dataPart.offset0320.offset0036 = reader.ReadUInt();
			data.dataPart.offset0320.offset0040 = reader.ReadUInt();
			data.dataPart.offset0320.offset0044 = reader.ReadUInt();
			data.dataPart.offset0320.offset0048 = reader.ReadUInt();
			data.dataPart.offset0320.offset0052 = reader.ReadUInt();
			data.dataPart.offset0320.offset0056 = reader.ReadUInt();
			data.dataPart.offset0320.offset0060 = reader.ReadUInt();
			data.dataPart.offset0384.offset0000 = reader.ReadUInt();
			data.dataPart.offset0384.offset0004 = reader.ReadUInt();
			data.dataPart.offset0384.offset0008 = reader.ReadUInt();
			data.dataPart.offset0384.offset0012 = reader.ReadUInt();
			data.dataPart.offset0384.offset0016 = reader.ReadUInt();
			data.dataPart.offset0384.offset0020 = reader.ReadUInt();
			data.dataPart.offset0384.offset0024 = reader.ReadUInt();
			data.dataPart.offset0384.offset0028 = reader.ReadUInt();
			data.dataPart.offset0384.offset0032 = reader.ReadUInt();
			data.dataPart.offset0384.offset0036 = reader.ReadUInt();
			data.dataPart.offset0384.offset0040 = reader.ReadUInt();
			data.dataPart.offset0384.offset0044 = reader.ReadUInt();
			data.dataPart.offset0384.offset0048 = reader.ReadUInt();
			data.dataPart.offset0384.offset0052 = reader.ReadUInt();
			data.dataPart.offset0384.offset0056 = reader.ReadUInt();
			data.dataPart.offset0384.offset0060 = reader.ReadUInt();
			data.dataPart.offset0448.offset0000 = reader.ReadUInt();
			data.dataPart.offset0448.offset0004 = reader.ReadUInt();
			data.dataPart.offset0448.offset0008 = reader.ReadUInt();
			data.dataPart.offset0448.offset0012 = reader.ReadUInt();
			data.dataPart.offset0448.offset0016 = reader.ReadUInt();
			data.dataPart.offset0448.offset0020 = reader.ReadUInt();
			data.dataPart.offset0448.offset0024 = reader.ReadUInt();
			data.dataPart.offset0448.offset0028 = reader.ReadUInt();
			data.dataPart.offset0448.offset0032 = reader.ReadUInt();
			data.dataPart.offset0448.offset0036 = reader.ReadUInt();
			data.dataPart.offset0448.offset0040 = reader.ReadUInt();
			data.dataPart.offset0448.offset0044 = reader.ReadUInt();
			data.dataPart.offset0448.offset0048 = reader.ReadUInt();
			data.dataPart.offset0448.offset0052 = reader.ReadUInt();
			data.dataPart.offset0448.offset0056 = reader.ReadUInt();
			data.dataPart.offset0448.offset0060 = reader.ReadUInt();
			data.dataPartStart = reader.ReadUInt();
			data.dataPartSize = reader.ReadUInt();
			data.totalDataSize = reader.ReadUInt();
			data.onlineID = reader.ReadULong();
			data.onlineName = reader.ReadFixedString32();
			data.isThinClient = ((reader.ReadUInt() != 0) ? true : false);
			data.platform = (byte)reader.ReadUInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<StartGameRPCSerializer, StartGameRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<StartGameRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in StartGameRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<StartGameRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref StartGameRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
