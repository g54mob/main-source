using System;
using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class SerialisedLayoutBlueprintFormatter : IMessagePackFormatter<SerialisedLayoutBlueprint>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SerialisedLayoutBlueprint value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Data);
		}

		public SerialisedLayoutBlueprint Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			byte[] data = null;
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					data = CodeGenHelpers.GetArrayFromNullableSequence(reader.ReadBytes());
				}
				else
				{
					reader.Skip();
				}
			}
			SerialisedLayoutBlueprint result = new SerialisedLayoutBlueprint(data);
			reader.Depth--;
			return result;
		}
	}
}
