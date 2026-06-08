using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SerializableQuaternionFormatter : IMessagePackFormatter<SerializableQuaternion>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SerializableQuaternion value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.x);
			writer.Write(value.y);
			writer.Write(value.z);
			writer.Write(value.w);
		}

		public SerializableQuaternion Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
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
			float w = 0f;
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
				case 3:
					w = reader.ReadSingle();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			SerializableQuaternion result = new SerializableQuaternion(x, y, z, w);
			reader.Depth--;
			return result;
		}
	}
}
