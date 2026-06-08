using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class AutoPartnerView_ViewDataFormatter : IMessagePackFormatter<AutoPartnerView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, AutoPartnerView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.GroupID);
		}

		public AutoPartnerView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			AutoPartnerView.ViewData result = default(AutoPartnerView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.GroupID = reader.ReadInt32();
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
