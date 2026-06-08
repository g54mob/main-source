using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CustomerNameSubview_ViewDataFormatter : IMessagePackFormatter<CustomerNameSubview.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CustomerNameSubview.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
			writer.Write(value.CustomOrder);
			writer.Write(value.HasTwitchTip);
			writer.Write(value.IsHalloween);
		}

		public CustomerNameSubview.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CustomerNameSubview.ViewData result = default(CustomerNameSubview.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 1:
					result.CustomOrder = reader.ReadInt32();
					break;
				case 2:
					result.HasTwitchTip = reader.ReadBoolean();
					break;
				case 3:
					result.IsHalloween = reader.ReadBoolean();
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
