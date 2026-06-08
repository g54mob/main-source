using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerPingView_ViewDataFormatter : IMessagePackFormatter<PlayerPingView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerPingView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.Colour, options);
		}

		public PlayerPingView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerPingView.ViewData result = default(PlayerPingView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Colour = resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
