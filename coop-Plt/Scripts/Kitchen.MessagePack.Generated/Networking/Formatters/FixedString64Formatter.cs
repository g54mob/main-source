using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Networking.Formatters
{
	[MessagePackFormatter(typeof(FixedString64))]
	public class FixedString64Formatter : IMessagePackFormatter<FixedString64>, IMessagePackFormatter
	{
		public static readonly FixedString64Formatter Instance = new FixedString64Formatter();

		public void Serialize(ref MessagePackWriter writer, FixedString64 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				writer.Write(value[i]);
			}
		}

		public FixedString64 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			int num = reader.ReadArrayHeader();
			if (num == 0)
			{
				return default(FixedString64);
			}
			FixedString64 result = default(FixedString64);
			for (int i = 0; i < num; i++)
			{
				result.Add(reader.ReadByte());
			}
			return result;
		}
	}
}
