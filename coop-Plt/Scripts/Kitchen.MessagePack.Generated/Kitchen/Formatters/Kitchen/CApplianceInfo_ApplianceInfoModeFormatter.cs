using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CApplianceInfo_ApplianceInfoModeFormatter : IMessagePackFormatter<CApplianceInfo.ApplianceInfoMode>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CApplianceInfo.ApplianceInfoMode value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public CApplianceInfo.ApplianceInfoMode Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (CApplianceInfo.ApplianceInfoMode)reader.ReadInt32();
		}
	}
}
