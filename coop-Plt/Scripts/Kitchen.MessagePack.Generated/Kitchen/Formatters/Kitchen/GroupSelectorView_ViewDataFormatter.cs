using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GroupSelectorView_ViewDataFormatter : IMessagePackFormatter<GroupSelectorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GroupSelectorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<Bounds>().Serialize(ref writer, value.Bounds, options);
			writer.Write(value.Progress);
			writer.Write(value.IsActivated);
		}

		public GroupSelectorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			GroupSelectorView.ViewData result = default(GroupSelectorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Bounds = resolver.GetFormatterWithVerify<Bounds>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Progress = reader.ReadSingle();
					break;
				case 2:
					result.IsActivated = reader.ReadBoolean();
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
