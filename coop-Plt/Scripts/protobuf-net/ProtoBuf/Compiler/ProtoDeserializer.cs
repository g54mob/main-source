namespace ProtoBuf.Compiler
{
	internal delegate T ProtoDeserializer<T>(ref ProtoReader.State state, T value);
}
