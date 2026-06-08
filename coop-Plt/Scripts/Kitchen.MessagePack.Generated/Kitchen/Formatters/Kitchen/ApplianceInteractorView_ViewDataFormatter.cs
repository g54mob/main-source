using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceInteractorView_ViewDataFormatter : IMessagePackFormatter<ApplianceInteractorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceInteractorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Process);
			writer.Write(value.IsInteracting);
		}

		public ApplianceInteractorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ApplianceInteractorView.ViewData result = default(ApplianceInteractorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Process = reader.ReadInt32();
					break;
				case 1:
					result.IsInteracting = reader.ReadBoolean();
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
