namespace ProtoBuf.Compiler
{
	internal delegate void ProtoSerializer<T>(ref ProtoWriter.State state, T value);
}
