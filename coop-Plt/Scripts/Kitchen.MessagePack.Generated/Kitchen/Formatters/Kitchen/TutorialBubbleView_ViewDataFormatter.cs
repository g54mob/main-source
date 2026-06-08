using System;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TutorialBubbleView_ViewDataFormatter : IMessagePackFormatter<TutorialBubbleView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TutorialBubbleView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<TutorialMessage>().Serialize(ref writer, value.Message, options);
			resolver.GetFormatterWithVerify<Button>().Serialize(ref writer, value.ButtonPrompt, options);
			resolver.GetFormatterWithVerify<InputPromptAnimation>().Serialize(ref writer, value.Animation, options);
		}

		public TutorialBubbleView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			TutorialBubbleView.ViewData result = default(TutorialBubbleView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Message = resolver.GetFormatterWithVerify<TutorialMessage>().Deserialize(ref reader, options);
					break;
				case 1:
					result.ButtonPrompt = resolver.GetFormatterWithVerify<Button>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Animation = resolver.GetFormatterWithVerify<InputPromptAnimation>().Deserialize(ref reader, options);
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
