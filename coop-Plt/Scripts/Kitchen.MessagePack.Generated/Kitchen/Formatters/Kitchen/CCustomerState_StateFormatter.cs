using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CCustomerState_StateFormatter : IMessagePackFormatter<CCustomerState.State>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CCustomerState.State value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public CCustomerState.State Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (CCustomerState.State)reader.ReadInt32();
		}
	}
}
