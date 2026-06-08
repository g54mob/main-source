using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class RemoveLayoutDoorsView_ViewDataFormatter : IMessagePackFormatter<RemoveLayoutDoorsView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, RemoveLayoutDoorsView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<Vector3>>().Serialize(ref writer, value.DoorRemovers, options);
		}

		public RemoveLayoutDoorsView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			RemoveLayoutDoorsView.ViewData result = default(RemoveLayoutDoorsView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.DoorRemovers = resolver.GetFormatterWithVerify<List<Vector3>>().Deserialize(ref reader, options);
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
