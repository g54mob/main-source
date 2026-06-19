using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct ClientInputDataInputBufferDataSerializer : ICommandDataSerializer<InputBufferData<ClientInputData>>
	{
		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in InputBufferData<ClientInputData> data)
		{
			writer.WriteUInt(data.InternalInput.dataOffset00);
			writer.WriteUInt(data.InternalInput.dataOffset04);
			writer.WriteUInt(data.InternalInput.dataOffset08);
			writer.WriteUInt(data.InternalInput.dataOffset12);
			writer.WriteUInt(data.InternalInput.dataOffset16);
			writer.WriteUInt(data.InternalInput.dataOffset20);
			writer.WriteUInt(data.InternalInput.dataOffset24);
			writer.WriteUInt(data.InternalInput.dataOffset28);
			writer.WriteUInt(data.InternalInput.dataOffset32);
			writer.WriteUInt(data.InternalInput.dataOffset36);
			writer.WriteUInt(data.InternalInput.dataOffset40);
			writer.WriteUInt(data.InternalInput.dataOffset44);
			writer.WriteUInt(data.InternalInput.dataOffset48);
			writer.WriteUInt(data.InternalInput.dataOffset52);
			writer.WriteUInt(data.InternalInput.dataOffset56);
			writer.WriteUInt(data.InternalInput.dataOffset60);
			writer.WriteUInt(data.InternalInput.dataOffset64);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref InputBufferData<ClientInputData> data)
		{
			data.InternalInput.dataOffset00 = reader.ReadUInt();
			data.InternalInput.dataOffset04 = reader.ReadUInt();
			data.InternalInput.dataOffset08 = reader.ReadUInt();
			data.InternalInput.dataOffset12 = reader.ReadUInt();
			data.InternalInput.dataOffset16 = reader.ReadUInt();
			data.InternalInput.dataOffset20 = reader.ReadUInt();
			data.InternalInput.dataOffset24 = reader.ReadUInt();
			data.InternalInput.dataOffset28 = reader.ReadUInt();
			data.InternalInput.dataOffset32 = reader.ReadUInt();
			data.InternalInput.dataOffset36 = reader.ReadUInt();
			data.InternalInput.dataOffset40 = reader.ReadUInt();
			data.InternalInput.dataOffset44 = reader.ReadUInt();
			data.InternalInput.dataOffset48 = reader.ReadUInt();
			data.InternalInput.dataOffset52 = reader.ReadUInt();
			data.InternalInput.dataOffset56 = reader.ReadUInt();
			data.InternalInput.dataOffset60 = reader.ReadUInt();
			data.InternalInput.dataOffset64 = reader.ReadUInt();
		}

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in InputBufferData<ClientInputData> data, in InputBufferData<ClientInputData> baseline, StreamCompressionModel compressionModel)
		{
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset00, baseline.InternalInput.dataOffset00, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset04, baseline.InternalInput.dataOffset04, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset08, baseline.InternalInput.dataOffset08, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset12, baseline.InternalInput.dataOffset12, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset16, baseline.InternalInput.dataOffset16, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset20, baseline.InternalInput.dataOffset20, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset24, baseline.InternalInput.dataOffset24, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset28, baseline.InternalInput.dataOffset28, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset32, baseline.InternalInput.dataOffset32, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset36, baseline.InternalInput.dataOffset36, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset40, baseline.InternalInput.dataOffset40, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset44, baseline.InternalInput.dataOffset44, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset48, baseline.InternalInput.dataOffset48, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset52, baseline.InternalInput.dataOffset52, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset56, baseline.InternalInput.dataOffset56, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset60, baseline.InternalInput.dataOffset60, in compressionModel);
			writer.WritePackedUIntDelta(data.InternalInput.dataOffset64, baseline.InternalInput.dataOffset64, in compressionModel);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref InputBufferData<ClientInputData> data, in InputBufferData<ClientInputData> baseline, StreamCompressionModel compressionModel)
		{
			data.InternalInput.dataOffset00 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset00, in compressionModel);
			data.InternalInput.dataOffset04 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset04, in compressionModel);
			data.InternalInput.dataOffset08 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset08, in compressionModel);
			data.InternalInput.dataOffset12 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset12, in compressionModel);
			data.InternalInput.dataOffset16 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset16, in compressionModel);
			data.InternalInput.dataOffset20 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset20, in compressionModel);
			data.InternalInput.dataOffset24 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset24, in compressionModel);
			data.InternalInput.dataOffset28 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset28, in compressionModel);
			data.InternalInput.dataOffset32 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset32, in compressionModel);
			data.InternalInput.dataOffset36 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset36, in compressionModel);
			data.InternalInput.dataOffset40 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset40, in compressionModel);
			data.InternalInput.dataOffset44 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset44, in compressionModel);
			data.InternalInput.dataOffset48 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset48, in compressionModel);
			data.InternalInput.dataOffset52 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset52, in compressionModel);
			data.InternalInput.dataOffset56 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset56, in compressionModel);
			data.InternalInput.dataOffset60 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset60, in compressionModel);
			data.InternalInput.dataOffset64 = reader.ReadPackedUIntDelta(baseline.InternalInput.dataOffset64, in compressionModel);
		}

		void ICommandDataSerializer<InputBufferData<ClientInputData>>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in InputBufferData<ClientInputData> data)
		{
			Serialize(ref writer, in state, in data);
		}

		void ICommandDataSerializer<InputBufferData<ClientInputData>>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref InputBufferData<ClientInputData> data)
		{
			Deserialize(ref reader, in state, ref data);
		}

		void ICommandDataSerializer<InputBufferData<ClientInputData>>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in InputBufferData<ClientInputData> data, in InputBufferData<ClientInputData> baseline, StreamCompressionModel compressionModel)
		{
			Serialize(ref writer, in state, in data, in baseline, compressionModel);
		}

		void ICommandDataSerializer<InputBufferData<ClientInputData>>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref InputBufferData<ClientInputData> data, in InputBufferData<ClientInputData> baseline, StreamCompressionModel compressionModel)
		{
			Deserialize(ref reader, in state, ref data, in baseline, compressionModel);
		}
	}
}
