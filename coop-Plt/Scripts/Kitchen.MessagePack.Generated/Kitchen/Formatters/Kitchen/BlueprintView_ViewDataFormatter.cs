using System;
using Kitchen.ShopBuilder;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class BlueprintView_ViewDataFormatter : IMessagePackFormatter<BlueprintView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, BlueprintView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			writer.Write(value.IconPrefab);
			writer.Write(value.PlayerMoney);
			writer.Write(value.Price);
			writer.Write(value.IsCopy);
			resolver.GetFormatterWithVerify<ShopStapleType>().Serialize(ref writer, value.Staple, options);
			writer.Write(value.AnyEnchantingDesk);
		}

		public BlueprintView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			BlueprintView.ViewData result = default(BlueprintView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IconPrefab = reader.ReadInt32();
					break;
				case 1:
					result.PlayerMoney = reader.ReadInt32();
					break;
				case 2:
					result.Price = reader.ReadInt32();
					break;
				case 3:
					result.IsCopy = reader.ReadBoolean();
					break;
				case 4:
					result.Staple = resolver.GetFormatterWithVerify<ShopStapleType>().Deserialize(ref reader, options);
					break;
				case 5:
					result.AnyEnchantingDesk = reader.ReadBoolean();
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
