using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SLoadoutStatus_RequiredActionsFormatter : IMessagePackFormatter<SLoadoutStatus.RequiredActions>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SLoadoutStatus.RequiredActions value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public SLoadoutStatus.RequiredActions Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (SLoadoutStatus.RequiredActions)reader.ReadInt32();
		}
	}
}
