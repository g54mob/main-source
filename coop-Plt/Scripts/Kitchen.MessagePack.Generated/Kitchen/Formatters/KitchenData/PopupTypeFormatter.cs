using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class PopupTypeFormatter : IMessagePackFormatter<PopupType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PopupType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public PopupType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (PopupType)reader.ReadInt32();
		}
	}
}
