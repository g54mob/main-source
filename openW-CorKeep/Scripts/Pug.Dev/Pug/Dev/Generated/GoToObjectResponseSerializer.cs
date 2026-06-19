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
	internal struct GoToObjectResponseSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<GoToObjectResponse>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in GoToObjectResponse data)
		{
			writer.WriteInt((int)data.Type);
			writer.WriteInt((int)data.ObjectID);
			writer.WriteFloat(data.Position.x);
			writer.WriteFloat(data.Position.y);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref GoToObjectResponse data)
		{
			data.Type = (GoToObjectResponse.ResponseType)reader.ReadInt();
			data.ObjectID = (ObjectID)reader.ReadInt();
			data.Position.x = reader.ReadFloat();
			data.Position.y = reader.ReadFloat();
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<GoToObjectResponseSerializer, GoToObjectResponse>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<GoToObjectResponse>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in GoToObjectResponse data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<GoToObjectResponse>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref GoToObjectResponse data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
