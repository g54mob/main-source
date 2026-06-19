namespace MessagePack.Internal
{
	internal delegate T AnonymousDeserializeFunc<T>(object[] customFormatters, byte[] bytes, int offset, IFormatterResolver resolver, out int readSize);
}
