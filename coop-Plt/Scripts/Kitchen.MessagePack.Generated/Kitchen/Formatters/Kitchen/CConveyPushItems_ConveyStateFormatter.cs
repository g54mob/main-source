using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CConveyPushItems_ConveyStateFormatter : IMessagePackFormatter<CConveyPushItems.ConveyState>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CConveyPushItems.ConveyState value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public CConveyPushItems.ConveyState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (CConveyPushItems.ConveyState)reader.ReadInt32();
		}
	}
}
