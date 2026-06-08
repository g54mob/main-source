using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StartPracticePopup_CRequestFormatter : IMessagePackFormatter<StartPracticePopup.CRequest>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StartPracticePopup.CRequest value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(0);
		}

		public StartPracticePopup.CRequest Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			reader.Skip();
			return default(StartPracticePopup.CRequest);
		}
	}
}
