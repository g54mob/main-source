using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DrinkDataFormatter : IMessagePackFormatter<DrinkData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DrinkData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.Component1);
			writer.Write(value.Component2);
			writer.Write(value.Component3);
		}

		public DrinkData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DrinkData result = default(DrinkData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Component1 = reader.ReadInt32();
					break;
				case 1:
					result.Component2 = reader.ReadInt32();
					break;
				case 2:
					result.Component3 = reader.ReadInt32();
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
