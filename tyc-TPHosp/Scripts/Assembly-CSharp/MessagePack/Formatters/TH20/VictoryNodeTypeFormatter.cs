using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class VictoryNodeTypeFormatter : IMessagePackFormatter<CollaborativeNode.VictoryNodeType>, IMessagePackFormatter
	{
		public int Serialize(ref byte[] bytes, int offset, CollaborativeNode.VictoryNodeType value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteInt32(ref bytes, offset, (int)value);
		}

		public CollaborativeNode.VictoryNodeType Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return (CollaborativeNode.VictoryNodeType)MessagePackBinary.ReadInt32(bytes, offset, out readSize);
		}
	}
}
