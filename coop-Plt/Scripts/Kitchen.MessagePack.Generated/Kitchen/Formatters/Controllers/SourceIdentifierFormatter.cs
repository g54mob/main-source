using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class SourceIdentifierFormatter : IMessagePackFormatter<SourceIdentifier>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SourceIdentifier value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Value);
		}

		public SourceIdentifier Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SourceIdentifier result = default(SourceIdentifier);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Value = reader.ReadInt32();
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
