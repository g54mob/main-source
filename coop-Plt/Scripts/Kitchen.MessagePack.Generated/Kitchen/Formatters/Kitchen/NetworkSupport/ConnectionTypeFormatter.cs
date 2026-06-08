using Kitchen.NetworkSupport;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.NetworkSupport
{
	public sealed class ConnectionTypeFormatter : IMessagePackFormatter<ConnectionType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ConnectionType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ConnectionType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ConnectionType)reader.ReadInt32();
		}
	}
}
