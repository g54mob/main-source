using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerShoeSubview_ViewDataFormatter : IMessagePackFormatter<PlayerShoeSubview.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerShoeSubview.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<PlayerShoe>().Serialize(ref writer, value.Shoe, options);
		}

		public PlayerShoeSubview.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerShoeSubview.ViewData result = default(PlayerShoeSubview.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Shoe = resolver.GetFormatterWithVerify<PlayerShoe>().Deserialize(ref reader, options);
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
