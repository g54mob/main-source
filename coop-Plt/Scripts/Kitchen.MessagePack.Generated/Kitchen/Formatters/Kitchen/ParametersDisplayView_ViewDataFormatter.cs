using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ParametersDisplayView_ViewDataFormatter : IMessagePackFormatter<ParametersDisplayView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ParametersDisplayView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			writer.Write(value.ExpectedGroupCount);
			writer.Write(value.MinimumGroupSize);
			writer.Write(value.MaximumGroupSize);
			writer.Write(value.IsNight);
			resolver.GetFormatterWithVerify<DecorationValues>().Serialize(ref writer, value.Decoration, options);
			writer.Write(value.ExtraGroups);
		}

		public ParametersDisplayView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ParametersDisplayView.ViewData result = default(ParametersDisplayView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ExpectedGroupCount = reader.ReadInt32();
					break;
				case 1:
					result.MinimumGroupSize = reader.ReadInt32();
					break;
				case 2:
					result.MaximumGroupSize = reader.ReadInt32();
					break;
				case 3:
					result.IsNight = reader.ReadBoolean();
					break;
				case 4:
					result.Decoration = resolver.GetFormatterWithVerify<DecorationValues>().Deserialize(ref reader, options);
					break;
				case 5:
					result.ExtraGroups = reader.ReadInt32();
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
