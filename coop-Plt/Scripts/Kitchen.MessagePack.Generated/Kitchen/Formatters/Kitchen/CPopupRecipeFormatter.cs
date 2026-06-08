using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CPopupRecipeFormatter : IMessagePackFormatter<CPopupRecipe>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CPopupRecipe value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.ID);
		}

		public CPopupRecipe Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CPopupRecipe result = default(CPopupRecipe);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.ID = reader.ReadInt32();
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
