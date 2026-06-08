using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerCosmeticSubview_ViewDataFormatter : IMessagePackFormatter<PlayerCosmeticSubview.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerCosmeticSubview.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cosmetics, options);
		}

		public PlayerCosmeticSubview.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerCosmeticSubview.ViewData result = default(PlayerCosmeticSubview.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Cosmetics = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
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
