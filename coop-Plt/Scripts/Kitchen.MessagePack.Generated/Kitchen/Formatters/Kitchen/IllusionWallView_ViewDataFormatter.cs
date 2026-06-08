using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class IllusionWallView_ViewDataFormatter : IMessagePackFormatter<IllusionWallView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, IllusionWallView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<(Vector3, Vector3)>>().Serialize(ref writer, value.IllusionWalls, options);
		}

		public IllusionWallView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			IllusionWallView.ViewData result = default(IllusionWallView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.IllusionWalls = resolver.GetFormatterWithVerify<List<(Vector3, Vector3)>>().Deserialize(ref reader, options);
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
