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
	internal struct ModInfoRequestRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<ModInfoRequestRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ModInfoRequestRPC data)
		{
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ModInfoRequestRPC data)
		{
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<ModInfoRequestRPCSerializer, ModInfoRequestRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<ModInfoRequestRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ModInfoRequestRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<ModInfoRequestRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ModInfoRequestRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
