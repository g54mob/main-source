using System;
using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SiteView_ViewDataFormatter : IMessagePackFormatter<SiteView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SiteView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			writer.WriteNil();
			resolver.GetFormatterWithVerify<LayoutBlueprint>().Serialize(ref writer, value.Floorplan, options);
			writer.Write(value.Setting);
			resolver.GetFormatterWithVerify<Seed>().Serialize(ref writer, value.Seed, options);
			writer.Write(value.ShowSeed);
		}

		public SiteView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SiteView.ViewData result = default(SiteView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 1:
					result.Floorplan = resolver.GetFormatterWithVerify<LayoutBlueprint>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Setting = reader.ReadInt32();
					break;
				case 3:
					result.Seed = resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
					break;
				case 4:
					result.ShowSeed = reader.ReadBoolean();
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
