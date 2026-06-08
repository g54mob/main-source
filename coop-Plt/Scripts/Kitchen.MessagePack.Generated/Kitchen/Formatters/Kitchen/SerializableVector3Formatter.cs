using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SerializableVector3Formatter : IMessagePackFormatter<SerializableVector3>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SerializableVector3 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.x);
			writer.Write(value.y);
			writer.Write(value.z);
		}

		public SerializableVector3 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			float x = 0f;
			float y = 0f;
			float z = 0f;
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					x = reader.ReadSingle();
					break;
				case 1:
					y = reader.ReadSingle();
					break;
				case 2:
					z = reader.ReadSingle();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			SerializableVector3 result = new SerializableVector3(x, y, z);
			reader.Depth--;
			return result;
		}
	}
}
