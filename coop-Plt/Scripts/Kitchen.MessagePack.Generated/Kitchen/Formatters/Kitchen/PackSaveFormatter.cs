using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveFormatter : IMessagePackFormatter<PackSave>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSave value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			writer.Write(value.SaveVersion);
			resolver.GetFormatterWithVerify<List<ISaveObject>>().Serialize(ref writer, value.SaveObjects, options);
		}

		public PackSave Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PackSave result = default(PackSave);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.SaveVersion = reader.ReadInt32();
					break;
				case 1:
					result.SaveObjects = resolver.GetFormatterWithVerify<List<ISaveObject>>().Deserialize(ref reader, options);
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
