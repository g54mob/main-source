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
	internal struct RevealWholeMapRequestSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<RevealWholeMapRequest>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RevealWholeMapRequest data)
		{
			writer.WriteInt(data.playerPosition.x);
			writer.WriteInt(data.playerPosition.y);
			writer.WriteInt(data.generationRadius);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RevealWholeMapRequest data)
		{
			data.playerPosition.x = reader.ReadInt();
			data.playerPosition.y = reader.ReadInt();
			data.generationRadius = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<RevealWholeMapRequestSerializer, RevealWholeMapRequest>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<RevealWholeMapRequest>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RevealWholeMapRequest data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<RevealWholeMapRequest>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RevealWholeMapRequest data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
