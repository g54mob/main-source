using System.Runtime.InteropServices;
using AOT;
using PugScan;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct PugScanResponseRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PugScanResponseRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PugScanResponseRpc data)
		{
			writer.WriteInt((int)data.code);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PugScanResponseRpc data)
		{
			data.code = (PugScanReturnCode)reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PugScanResponseRpcSerializer, PugScanResponseRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PugScanResponseRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PugScanResponseRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PugScanResponseRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PugScanResponseRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
