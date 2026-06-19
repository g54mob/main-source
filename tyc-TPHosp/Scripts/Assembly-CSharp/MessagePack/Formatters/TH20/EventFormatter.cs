using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class EventFormatter : IMessagePackFormatter<OnlineChallengeEvent.Event>, IMessagePackFormatter
	{
		public int Serialize(ref byte[] bytes, int offset, OnlineChallengeEvent.Event value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteInt32(ref bytes, offset, (int)value);
		}

		public OnlineChallengeEvent.Event Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return (OnlineChallengeEvent.Event)MessagePackBinary.ReadInt32(bytes, offset, out readSize);
		}
	}
}
