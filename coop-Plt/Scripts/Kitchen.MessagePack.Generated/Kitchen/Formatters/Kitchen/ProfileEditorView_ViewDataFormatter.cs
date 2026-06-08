using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ProfileEditorView_ViewDataFormatter : IMessagePackFormatter<ProfileEditorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ProfileEditorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.PlayerID);
		}

		public ProfileEditorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ProfileEditorView.ViewData result = default(ProfileEditorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.PlayerID = reader.ReadInt32();
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
