using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerView_ResponseDataFormatter : IMessagePackFormatter<PlayerView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerView.ResponseData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.Position, options);
			resolver.GetFormatterWithVerify<Quaternion>().Serialize(ref writer, value.Rotation, options);
		}

		public PlayerView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerView.ResponseData result = default(PlayerView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Position = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Rotation = resolver.GetFormatterWithVerify<Quaternion>().Deserialize(ref reader, options);
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
