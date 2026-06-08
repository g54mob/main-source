using MessagePack;
using MessagePack.Formatters;
using Platforms;

namespace Networking.Formatters
{
	[MessagePackFormatter(typeof(PlatformUser))]
	public class PlatformUserFormatter : IMessagePackFormatter<PlatformUser>, IMessagePackFormatter
	{
		public static readonly PlatformUserFormatter Instance = new PlatformUserFormatter();

		public void Serialize(ref MessagePackWriter writer, PlatformUser value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.WriteInt32(0);
			writer.Write("");
		}

		public PlatformUser Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			reader.Skip();
			return default(PlatformUser);
		}
	}
}
