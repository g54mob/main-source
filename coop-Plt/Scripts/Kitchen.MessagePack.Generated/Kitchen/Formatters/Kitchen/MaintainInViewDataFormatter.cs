using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class MaintainInViewDataFormatter : IMessagePackFormatter<MaintainInViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, MaintainInViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<ViewIdentifier>().Serialize(ref writer, value.View, options);
			writer.Write(value.Radius);
			writer.Write(value.ShouldMaintain);
		}

		public MaintainInViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			MaintainInViewData result = default(MaintainInViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.View = resolver.GetFormatterWithVerify<ViewIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Radius = reader.ReadSingle();
					break;
				case 2:
					result.ShouldMaintain = reader.ReadBoolean();
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
