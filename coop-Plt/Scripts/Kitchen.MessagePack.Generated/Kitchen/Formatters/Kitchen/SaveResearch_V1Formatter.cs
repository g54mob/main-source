using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SaveResearch_V1Formatter : IMessagePackFormatter<SaveResearch.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SaveResearch.V1 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.ID);
			writer.Write(value.ResearchProvided);
		}

		public SaveResearch.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SaveResearch.V1 result = default(SaveResearch.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.ResearchProvided = reader.ReadInt32();
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
