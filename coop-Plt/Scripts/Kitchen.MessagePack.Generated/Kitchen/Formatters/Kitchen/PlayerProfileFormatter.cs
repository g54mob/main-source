using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerProfileFormatter : IMessagePackFormatter<PlayerProfile>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerProfile value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
			resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.Colour, options);
			resolver.GetFormatterWithVerify<PlayerOutfit>().Serialize(ref writer, value.Outfit, options);
			writer.Write(value.RequiresTutorial);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cosmetics, options);
			resolver.GetFormatterWithVerify<ProfileFlags>().Serialize(ref writer, value.Flags, options);
		}

		public PlayerProfile Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerProfile result = default(PlayerProfile);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Colour = resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Outfit = resolver.GetFormatterWithVerify<PlayerOutfit>().Deserialize(ref reader, options);
					break;
				case 3:
					result.RequiresTutorial = reader.ReadBoolean();
					break;
				case 4:
					result.Cosmetics = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 5:
					result.Flags = resolver.GetFormatterWithVerify<ProfileFlags>().Deserialize(ref reader, options);
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
