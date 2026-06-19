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
	internal struct RevealWholeMapProgressUpdateSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<RevealWholeMapProgressUpdate>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RevealWholeMapProgressUpdate data)
		{
			writer.WriteInt(data.SubmapsUpdated);
			writer.WriteInt(data.TotalSubMapsToUpdate);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RevealWholeMapProgressUpdate data)
		{
			data.SubmapsUpdated = reader.ReadInt();
			data.TotalSubMapsToUpdate = reader.ReadInt();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<RevealWholeMapProgressUpdateSerializer, RevealWholeMapProgressUpdate>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<RevealWholeMapProgressUpdate>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in RevealWholeMapProgressUpdate data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<RevealWholeMapProgressUpdate>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref RevealWholeMapProgressUpdate data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
