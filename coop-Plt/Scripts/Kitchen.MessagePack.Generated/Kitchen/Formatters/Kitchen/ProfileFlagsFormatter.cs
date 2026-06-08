using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ProfileFlagsFormatter : IMessagePackFormatter<ProfileFlags>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ProfileFlags value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ProfileFlags Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ProfileFlags)reader.ReadInt32();
		}
	}
}
