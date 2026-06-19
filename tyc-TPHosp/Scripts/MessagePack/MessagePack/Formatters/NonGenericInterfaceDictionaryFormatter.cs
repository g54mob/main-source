using System.Collections;
using System.Collections.Generic;

namespace MessagePack.Formatters
{
	public sealed class NonGenericInterfaceDictionaryFormatter : IMessagePackFormatter<IDictionary>, IMessagePackFormatter
	{
		public static readonly IMessagePackFormatter<IDictionary> Instance = new NonGenericInterfaceDictionaryFormatter();

		private NonGenericInterfaceDictionaryFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, IDictionary value, IFormatterResolver formatterResolver)
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

		public IDictionary Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
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
			Dictionary<object, object> dictionary = new Dictionary<object, object>(num2);
			for (int i = 0; i < num2; i++)
			{
				object key = formatterWithVerify.Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				object value = formatterWithVerify.Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				dictionary.Add(key, value);
			}
			readSize = offset - num;
			return dictionary;
		}
	}
}
