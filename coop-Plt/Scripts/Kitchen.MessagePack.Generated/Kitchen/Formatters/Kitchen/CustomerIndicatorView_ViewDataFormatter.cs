using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CustomerIndicatorView_ViewDataFormatter : IMessagePackFormatter<CustomerIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CustomerIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(8);
			writer.Write(value.HasPatience);
			writer.Write(value.Patience);
			resolver.GetFormatterWithVerify<PatienceReason>().Serialize(ref writer, value.PatienceReason, options);
			resolver.GetFormatterWithVerify<DrinkData>().Serialize(ref writer, value.Drink, options);
			writer.Write(value.WantsDrink);
			writer.Write(value.IsHidden);
			resolver.GetFormatterWithVerify<DisplayedPatienceFactor>().Serialize(ref writer, value.PatienceFactors, options);
			writer.Write(value.IsObfuscated);
		}

		public CustomerIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CustomerIndicatorView.ViewData result = default(CustomerIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.HasPatience = reader.ReadBoolean();
					break;
				case 1:
					result.Patience = reader.ReadSingle();
					break;
				case 2:
					result.PatienceReason = resolver.GetFormatterWithVerify<PatienceReason>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Drink = resolver.GetFormatterWithVerify<DrinkData>().Deserialize(ref reader, options);
					break;
				case 4:
					result.WantsDrink = reader.ReadBoolean();
					break;
				case 5:
					result.IsHidden = reader.ReadBoolean();
					break;
				case 6:
					result.PatienceFactors = resolver.GetFormatterWithVerify<DisplayedPatienceFactor>().Deserialize(ref reader, options);
					break;
				case 7:
					result.IsObfuscated = reader.ReadBoolean();
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
