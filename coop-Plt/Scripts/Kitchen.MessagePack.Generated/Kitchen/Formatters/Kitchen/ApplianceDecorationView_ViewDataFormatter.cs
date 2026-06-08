using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceDecorationView_ViewDataFormatter : IMessagePackFormatter<ApplianceDecorationView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceDecorationView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<DecorationValues>().Serialize(ref writer, value.Decorations, options);
			writer.Write(value.IsNight);
		}

		public ApplianceDecorationView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ApplianceDecorationView.ViewData result = default(ApplianceDecorationView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Decorations = resolver.GetFormatterWithVerify<DecorationValues>().Deserialize(ref reader, options);
					break;
				case 1:
					result.IsNight = reader.ReadBoolean();
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
