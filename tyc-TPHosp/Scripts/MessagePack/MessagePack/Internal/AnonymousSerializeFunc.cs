namespace MessagePack.Internal
{
	internal delegate int AnonymousSerializeFunc<T>(byte[][] stringByteKeysField, object[] customFormatters, ref byte[] bytes, int offset, T value, IFormatterResolver resolver);
}
