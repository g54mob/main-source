using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceInfoView_ViewDataFormatter : IMessagePackFormatter<ApplianceInfoView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceInfoView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			writer.Write(value.ID);
			writer.Write(value.PlayerMoney);
			resolver.GetFormatterWithVerify<CApplianceInfo.ApplianceInfoMode>().Serialize(ref writer, value.Mode, options);
			writer.Write(value.Price);
			writer.Write(value.AnyEnchantingDesk);
		}

		public ApplianceInfoView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ApplianceInfoView.ViewData result = default(ApplianceInfoView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.PlayerMoney = reader.ReadInt32();
					break;
				case 2:
					result.Mode = resolver.GetFormatterWithVerify<CApplianceInfo.ApplianceInfoMode>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Price = reader.ReadInt32();
					break;
				case 4:
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
