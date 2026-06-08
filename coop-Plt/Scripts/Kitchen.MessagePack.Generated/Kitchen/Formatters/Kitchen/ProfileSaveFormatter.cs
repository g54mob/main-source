using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ProfileSaveFormatter : IMessagePackFormatter<ProfileSave>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ProfileSave value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<Dictionary<string, PlayerProfile>>().Serialize(ref writer, value.Profiles, options);
			resolver.GetFormatterWithVerify<Dictionary<string, string>>().Serialize(ref writer, value.ControlOverrides, options);
		}

		public ProfileSave Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ProfileSave profileSave = new ProfileSave();
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					profileSave.Profiles = resolver.GetFormatterWithVerify<Dictionary<string, PlayerProfile>>().Deserialize(ref reader, options);
					break;
				case 1:
					profileSave.ControlOverrides = resolver.GetFormatterWithVerify<Dictionary<string, string>>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return profileSave;
		}
	}
}
