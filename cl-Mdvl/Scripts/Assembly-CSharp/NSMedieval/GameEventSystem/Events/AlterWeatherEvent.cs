using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.AlterWeatherEvent", "")]
	public class AlterWeatherEvent : GameEventInstance
	{
		public AlterWeatherEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new AlterWeatherPhase());
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public AlterWeatherEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
