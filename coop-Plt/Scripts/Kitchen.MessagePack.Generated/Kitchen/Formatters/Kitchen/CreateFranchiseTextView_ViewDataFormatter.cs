using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CreateFranchiseTextView_ViewDataFormatter : IMessagePackFormatter<CreateFranchiseTextView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CreateFranchiseTextView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.CardCount);
			writer.Write(value.ExpValue);
			writer.Write(value.IsScrapMode);
		}

		public CreateFranchiseTextView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CreateFranchiseTextView.ViewData result = default(CreateFranchiseTextView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.CardCount = reader.ReadInt32();
					break;
				case 1:
					result.ExpValue = reader.ReadInt32();
					break;
				case 2:
					result.IsScrapMode = reader.ReadBoolean();
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
