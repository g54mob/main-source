using System;
using Controllers;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InfoManagerPlayerDetailFormatter : IMessagePackFormatter<InfoManagerPlayerDetail>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InfoManagerPlayerDetail value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(8);
			writer.Write(value.ID);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.Identifier, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.MainName, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.SubName, options);
			writer.Write(value.Index);
			writer.Write(value.JoinProgress);
			resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.Colour, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cosmetics, options);
		}

		public InfoManagerPlayerDetail Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InfoManagerPlayerDetail result = default(InfoManagerPlayerDetail);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.Identifier = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
					break;
				case 2:
					result.MainName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 3:
					result.SubName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 4:
					result.Index = reader.ReadInt32();
					break;
				case 5:
					result.JoinProgress = reader.ReadSingle();
					break;
				case 6:
					result.Colour = resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
					break;
				case 7:
					result.Cosmetics = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
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
