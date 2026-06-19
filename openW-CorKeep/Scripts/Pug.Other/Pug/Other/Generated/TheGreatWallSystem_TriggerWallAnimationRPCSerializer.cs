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
	internal struct TheGreatWallSystem_TriggerWallAnimationRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<TheGreatWallSystem.TriggerWallAnimationRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in TheGreatWallSystem.TriggerWallAnimationRPC data)
		{
			writer.WriteUInt(data.startTick.SerializedData);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref TheGreatWallSystem.TriggerWallAnimationRPC data)
		{
			data.startTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<TheGreatWallSystem_TriggerWallAnimationRPCSerializer, TheGreatWallSystem.TriggerWallAnimationRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<TheGreatWallSystem.TriggerWallAnimationRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in TheGreatWallSystem.TriggerWallAnimationRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<TheGreatWallSystem.TriggerWallAnimationRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref TheGreatWallSystem.TriggerWallAnimationRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
