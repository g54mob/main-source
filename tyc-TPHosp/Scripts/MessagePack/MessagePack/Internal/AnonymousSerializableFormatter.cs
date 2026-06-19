using System;
using MessagePack.Formatters;

namespace MessagePack.Internal
{
	internal class AnonymousSerializableFormatter<T> : IMessagePackFormatter<T>, IMessagePackFormatter
	{
		private readonly byte[][] stringByteKeysField;

		private readonly object[] serializeCustomFormatters;

		private readonly object[] deserializeCustomFormatters;

		private readonly AnonymousSerializeFunc<T> serialize;

		private readonly AnonymousDeserializeFunc<T> deserialize;

		public AnonymousSerializableFormatter(byte[][] stringByteKeysField, object[] serializeCustomFormatters, object[] deserializeCustomFormatters, AnonymousSerializeFunc<T> serialize, AnonymousDeserializeFunc<T> deserialize)
		{
			this.stringByteKeysField = stringByteKeysField;
			this.serializeCustomFormatters = serializeCustomFormatters;
			this.deserializeCustomFormatters = deserializeCustomFormatters;
			this.serialize = serialize;
			this.deserialize = deserialize;
		}

		public int Serialize(ref byte[] bytes, int offset, T value, IFormatterResolver formatterResolver)
		{
			if (serialize == null)
			{
				throw new InvalidOperationException(GetType().Name + " does not support Serialize.");
			}
			return serialize(stringByteKeysField, serializeCustomFormatters, ref bytes, offset, value, formatterResolver);
		}

		public T Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (deserialize == null)
			{
				throw new InvalidOperationException(GetType().Name + " does not support Deserialize.");
			}
			return deserialize(deserializeCustomFormatters, bytes, offset, formatterResolver, out readSize);
		}
	}
}
