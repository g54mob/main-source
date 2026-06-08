using ProtoBuf.Serializers;

namespace ProtoBuf.Compiler
{
	internal delegate T ProtoSubTypeDeserializer<T>(ref ProtoReader.State state, SubTypeState<T> value) where T : class;
}
