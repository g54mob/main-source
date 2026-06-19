using System.Collections;

namespace MessagePack.Formatters
{
	public sealed class NonGenericDictionaryFormatter<T> : IMessagePackFormatter<T>, IMessagePackFormatter where T : class, IDictionary, new()
	{
		public int Serialize(ref byte[] bytes, int offset, T value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				MessagePackBinary.WriteNil(ref bytes, offset);
				return 1;
			}
			IMessagePackFormatter<object> formatterWithVerify = formatterResolver.GetFormatterWithVerify<object>();
			int num = offset;
			offset += MessagePackBinary.WriteMapHeader(ref bytes, offset, value.Count);
			foreach (DictionaryEntry item in value)
			{
				offset += formatterWithVerify.Serialize(ref bytes, offset, item.Key, formatterResolver);
				offset += formatterWithVerify.Serialize(ref bytes, offset, item.Value, formatterResolver);
			}
			return offset - num;
		}

		public T Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			IMessagePackFormatter<object> formatterWithVerify = formatterResolver.GetFormatterWithVerify<object>();
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			T val = new T();
			for (int i = 0; i < num2; i++)
			{
				object key = formatterWithVerify.Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				object value = formatterWithVerify.Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				val.Add(key, value);
			}
			readSize = offset - num;
			return val;
		}
	}
}
