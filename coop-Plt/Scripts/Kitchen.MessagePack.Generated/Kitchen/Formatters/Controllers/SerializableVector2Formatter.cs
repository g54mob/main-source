using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class SerializableVector2Formatter : IMessagePackFormatter<SerializableVector2>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SerializableVector2 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.x);
			writer.Write(value.y);
		}

		public SerializableVector2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SerializableVector2 result = default(SerializableVector2);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.x = reader.ReadSingle();
					break;
				case 1:
					result.y = reader.ReadSingle();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
