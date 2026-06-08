using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EntityUpdateFormatter : IMessagePackFormatter<EntityUpdate>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EntityUpdate value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<ViewIdentifier>().Serialize(ref writer, value.Identifier, options);
			resolver.GetFormatterWithVerify<IViewData>().Serialize(ref writer, value.Data, options);
			resolver.GetFormatterWithVerify<MessageType>().Serialize(ref writer, value.Type, options);
		}

		public EntityUpdate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			EntityUpdate result = default(EntityUpdate);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Identifier = resolver.GetFormatterWithVerify<ViewIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Data = resolver.GetFormatterWithVerify<IViewData>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Type = resolver.GetFormatterWithVerify<MessageType>().Deserialize(ref reader, options);
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
