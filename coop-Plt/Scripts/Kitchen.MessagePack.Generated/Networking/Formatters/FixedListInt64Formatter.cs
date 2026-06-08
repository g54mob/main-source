using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Networking.Formatters
{
	[MessagePackFormatter(typeof(FixedListInt64))]
	public class FixedListInt64Formatter : IMessagePackFormatter<FixedListInt64>, IMessagePackFormatter
	{
		public static readonly FixedListInt64Formatter Instance = new FixedListInt64Formatter();

		public void Serialize(ref MessagePackWriter writer, FixedListInt64 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				writer.Write(value[i]);
			}
		}

		public FixedListInt64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			int num = reader.ReadArrayHeader();
			if (num == 0)
			{
				return default(FixedListInt64);
			}
			FixedListInt64 result = default(FixedListInt64);
			for (int i = 0; i < num; i++)
			{
				result.Add(reader.ReadInt32());
			}
			return result;
		}
	}
}
