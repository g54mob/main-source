using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ViewIdentifierFormatter : IMessagePackFormatter<ViewIdentifier>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ViewIdentifier value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Identifier);
		}

		public ViewIdentifier Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ViewIdentifier result = default(ViewIdentifier);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Identifier = reader.ReadInt32();
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
