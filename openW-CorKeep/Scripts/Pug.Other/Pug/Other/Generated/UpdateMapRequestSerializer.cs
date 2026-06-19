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
	internal struct UpdateMapRequestSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<UpdateMapRequest>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UpdateMapRequest data)
		{
			writer.WriteInt(data.MapPosition.x);
			writer.WriteInt(data.MapPosition.y);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UpdateMapRequest data)
		{
			data.MapPosition.x = reader.ReadInt();
			data.MapPosition.y = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<UpdateMapRequestSerializer, UpdateMapRequest>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<UpdateMapRequest>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UpdateMapRequest data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<UpdateMapRequest>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UpdateMapRequest data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
