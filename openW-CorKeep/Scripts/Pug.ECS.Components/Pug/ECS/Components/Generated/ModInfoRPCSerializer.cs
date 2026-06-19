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
	internal struct ModInfoRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<ModInfoRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ModInfoRPC data)
		{
			writer.WriteLong(data.modId);
			writer.WriteUInt(data.modGuid.Value.x);
			writer.WriteUInt(data.modGuid.Value.y);
			writer.WriteUInt(data.modGuid.Value.z);
			writer.WriteUInt(data.modGuid.Value.w);
			writer.WriteFixedString32(data.modName);
			writer.WriteUInt(data.required ? 1u : 0u);
			writer.WriteUInt(data.lastMod ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ModInfoRPC data)
		{
			data.modId = reader.ReadLong();
			data.modGuid.Value.x = reader.ReadUInt();
			data.modGuid.Value.y = reader.ReadUInt();
			data.modGuid.Value.z = reader.ReadUInt();
			data.modGuid.Value.w = reader.ReadUInt();
			data.modName = reader.ReadFixedString32();
			data.required = ((reader.ReadUInt() != 0) ? true : false);
			data.lastMod = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<ModInfoRPCSerializer, ModInfoRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<ModInfoRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ModInfoRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<ModInfoRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ModInfoRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
