using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InstantProcessToolView_ViewDataFormatter : IMessagePackFormatter<InstantProcessToolView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InstantProcessToolView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.WriteNil();
			writer.Write(value.OnCooldown);
		}

		public InstantProcessToolView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			InstantProcessToolView.ViewData result = default(InstantProcessToolView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 1)
				{
					result.OnCooldown = reader.ReadBoolean();
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
