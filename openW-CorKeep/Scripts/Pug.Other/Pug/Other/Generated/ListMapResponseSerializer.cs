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
	internal struct ListMapResponseSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<ListMapResponse>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ListMapResponse data)
		{
			writer.WriteInt(data.MapPosition.x);
			writer.WriteInt(data.MapPosition.y);
			writer.WriteULong(data.H1);
			writer.WriteULong(data.H2);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ListMapResponse data)
		{
			data.MapPosition.x = reader.ReadInt();
			data.MapPosition.y = reader.ReadInt();
			data.H1 = reader.ReadULong();
			data.H2 = reader.ReadULong();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<ListMapResponseSerializer, ListMapResponse>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<ListMapResponse>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in ListMapResponse data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<ListMapResponse>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref ListMapResponse data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
