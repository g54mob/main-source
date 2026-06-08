using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LoadLocationView_ViewDataFormatter : IMessagePackFormatter<LoadLocationView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LoadLocationView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(9);
			resolver.GetFormatterWithVerify<SaveState>().Serialize(ref writer, value.State, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.RestaurantName, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.RestaurantSafeName, options);
			writer.Write(value.Setting);
			writer.Write(value.Selected);
			writer.Write(value.Day);
			writer.Write(value.Slot);
			writer.Write(value.FranchiseTier);
			writer.Write(value.BeingLookedAt);
		}

		public LoadLocationView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LoadLocationView.ViewData result = default(LoadLocationView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.State = resolver.GetFormatterWithVerify<SaveState>().Deserialize(ref reader, options);
					break;
				case 1:
					result.RestaurantName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 2:
					result.RestaurantSafeName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Setting = reader.ReadInt32();
					break;
				case 4:
					result.Selected = reader.ReadBoolean();
					break;
				case 5:
					result.Day = reader.ReadInt32();
					break;
				case 6:
					result.Slot = reader.ReadInt32();
					break;
				case 7:
					result.FranchiseTier = reader.ReadInt32();
					break;
				case 8:
					result.BeingLookedAt = reader.ReadBoolean();
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
