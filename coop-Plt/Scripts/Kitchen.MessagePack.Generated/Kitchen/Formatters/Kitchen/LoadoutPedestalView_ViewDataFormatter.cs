using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LoadoutPedestalView_ViewDataFormatter : IMessagePackFormatter<LoadoutPedestalView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LoadoutPedestalView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.WriteNil();
			writer.Write(value.IsDisabled);
		}

		public LoadoutPedestalView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			LoadoutPedestalView.ViewData result = default(LoadoutPedestalView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 1)
				{
					result.IsDisabled = reader.ReadBoolean();
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
