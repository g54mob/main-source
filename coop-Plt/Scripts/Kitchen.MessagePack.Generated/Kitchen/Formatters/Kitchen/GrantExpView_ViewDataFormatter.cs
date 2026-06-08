using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GrantExpView_ViewDataFormatter : IMessagePackFormatter<GrantExpView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GrantExpView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Amount);
			writer.Write(value.ExpIdentifier);
		}

		public GrantExpView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			GrantExpView.ViewData result = default(GrantExpView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Amount = reader.ReadInt32();
					break;
				case 1:
					result.ExpIdentifier = reader.ReadInt32();
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
