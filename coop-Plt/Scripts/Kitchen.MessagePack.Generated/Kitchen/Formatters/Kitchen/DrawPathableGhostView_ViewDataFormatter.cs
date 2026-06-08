using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DrawPathableGhostView_ViewDataFormatter : IMessagePackFormatter<DrawPathableGhostView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DrawPathableGhostView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.IsPathable);
			writer.Write(value.IsCustomerVisible);
			writer.Write(value.IsEmptyAhead);
		}

		public DrawPathableGhostView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DrawPathableGhostView.ViewData result = default(DrawPathableGhostView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsPathable = reader.ReadBoolean();
					break;
				case 1:
					result.IsCustomerVisible = reader.ReadBoolean();
					break;
				case 2:
					result.IsEmptyAhead = reader.ReadBoolean();
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
