using System;
using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class RoomFormatter : IMessagePackFormatter<Room>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Room value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			writer.Write(value.ID);
			resolver.GetFormatterWithVerify<RoomType>().Serialize(ref writer, value.Type, options);
		}

		public Room Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			int id = 0;
			RoomType type = RoomType.NoRoom;
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					id = reader.ReadInt32();
					break;
				case 1:
					type = resolver.GetFormatterWithVerify<RoomType>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			Room result = new Room(id, type);
			reader.Depth--;
			return result;
		}
	}
}
