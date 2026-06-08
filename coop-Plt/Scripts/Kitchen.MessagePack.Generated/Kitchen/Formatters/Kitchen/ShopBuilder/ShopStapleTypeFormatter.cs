using Kitchen.ShopBuilder;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.ShopBuilder
{
	public sealed class ShopStapleTypeFormatter : IMessagePackFormatter<ShopStapleType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ShopStapleType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ShopStapleType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ShopStapleType)reader.ReadInt32();
		}
	}
}
