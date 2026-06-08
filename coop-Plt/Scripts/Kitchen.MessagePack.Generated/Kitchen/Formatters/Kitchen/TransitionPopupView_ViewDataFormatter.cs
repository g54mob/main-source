using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TransitionPopupView_ViewDataFormatter : IMessagePackFormatter<TransitionPopupView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TransitionPopupView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(0);
		}

		public TransitionPopupView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			reader.Skip();
			return default(TransitionPopupView.ViewData);
		}
	}
}
