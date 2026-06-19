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
	internal struct RegenerateTerrainRequestSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<RegenerateTerrainRequest>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RegenerateTerrainRequest data)
		{
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RegenerateTerrainRequest data)
		{
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<RegenerateTerrainRequestSerializer, RegenerateTerrainRequest>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<RegenerateTerrainRequest>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RegenerateTerrainRequest data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<RegenerateTerrainRequest>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RegenerateTerrainRequest data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
