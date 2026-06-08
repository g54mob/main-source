using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StartGameTextView_ViewDataFormatter : IMessagePackFormatter<StartGameTextView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StartGameTextView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<SLoadoutStatus.RequiredActions>().Serialize(ref writer, value.Actions, options);
		}

		public StartGameTextView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			StartGameTextView.ViewData result = default(StartGameTextView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Actions = resolver.GetFormatterWithVerify<SLoadoutStatus.RequiredActions>().Deserialize(ref reader, options);
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
