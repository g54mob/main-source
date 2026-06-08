using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceView_ViewDataFormatter : IMessagePackFormatter<ApplianceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(6);
			writer.Write(value.ApplianceID);
			writer.Write(value.Broken);
			writer.Write(value.InteractTarget);
			writer.Write(value.DrawUsing);
			writer.Write(value.MarkedForDeletion);
			writer.Write(value.IsOnFire);
		}

		public ApplianceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ApplianceView.ViewData result = default(ApplianceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ApplianceID = reader.ReadInt32();
					break;
				case 1:
					result.Broken = reader.ReadBoolean();
					break;
				case 2:
					result.InteractTarget = reader.ReadBoolean();
					break;
				case 3:
					result.DrawUsing = reader.ReadInt32();
					break;
				case 4:
					result.MarkedForDeletion = reader.ReadBoolean();
					break;
				case 5:
					result.IsOnFire = reader.ReadBoolean();
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
