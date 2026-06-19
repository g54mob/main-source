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
	internal struct RegenerateTerrainResponseSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<RegenerateTerrainResponse>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RegenerateTerrainResponse data)
		{
			writer.WriteUInt(data.Success ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RegenerateTerrainResponse data)
		{
			data.Success = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<RegenerateTerrainResponseSerializer, RegenerateTerrainResponse>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<RegenerateTerrainResponse>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RegenerateTerrainResponse data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<RegenerateTerrainResponse>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RegenerateTerrainResponse data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
