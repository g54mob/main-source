using NSMedieval.Serialization;
using NSMedieval.Village.Map;

namespace NSMedieval.CommanderAI
{
	[FVSerializableKey("NothingCommanderAgent", "")]
	public class NothingCommanderAgent : CommanderAgentBase
	{
		public NothingCommanderAgent(uint id, VillageMap map)
			: base(id, map)
		{
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public NothingCommanderAgent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
