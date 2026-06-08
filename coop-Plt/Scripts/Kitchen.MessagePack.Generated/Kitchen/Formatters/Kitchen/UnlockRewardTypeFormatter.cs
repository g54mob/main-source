using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class UnlockRewardTypeFormatter : IMessagePackFormatter<UnlockRewardType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, UnlockRewardType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public UnlockRewardType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (UnlockRewardType)reader.ReadInt32();
		}
	}
}
