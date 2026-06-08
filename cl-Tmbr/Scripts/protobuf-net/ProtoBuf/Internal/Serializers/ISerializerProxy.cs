namespace ProtoBuf.Internal.Serializers
{
	internal interface ISerializerProxy
	{
		IRuntimeProtoSerializerNode Serializer { get; }
	}
}
