using System.Collections;

namespace MessagePack.Formatters
{
	public sealed class NonGenericInterfaceListFormatter : IMessagePackFormatter<IList>, IMessagePackFormatter
	{
		public static readonly IMessagePackFormatter<IList> Instance = new NonGenericInterfaceListFormatter();

		private NonGenericInterfaceListFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, IList value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				MessagePackBinary.WriteNil(ref bytes, offset);
				return 1;
			}
			IMessagePackFormatter<object> formatterWithVerify = formatterResolver.GetFormatterWithVerify<object>();
			int num = offset;
			offset += MessagePackBinary.WriteArrayHeader(ref bytes, offset, value.Count);
			foreach (object item in value)
			{
				offset += formatterWithVerify.Serialize(ref bytes, offset, item, formatterResolver);
			}
			return offset - num;
		}

		public IList Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			IMessagePackFormatter<object> formatterWithVerify = formatterResolver.GetFormatterWithVerify<object>();
			int num = offset;
			int num2 = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
			offset += readSize;
			object[] array = new object[num2];
			for (int i = 0; i < num2; i++)
			{
				array[i] = formatterWithVerify.Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
			}
			readSize = offset - num;
			return array;
		}
	}
}
