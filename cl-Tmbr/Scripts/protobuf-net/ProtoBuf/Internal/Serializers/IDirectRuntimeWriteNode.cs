namespace ProtoBuf.Internal.Serializers
{
	internal interface IDirectRuntimeWriteNode
	{
		bool CanDirectWrite(WireType wireType);

		void DirectWrite(int fieldNumber, WireType wireType, ref ProtoWriter.State state, object value);
	}
}
