using System;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.InfoEvent", "")]
	public class InfoEvent : GameEventInstance
	{
		public InfoEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new PublishNewsPhase(0));
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public InfoEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
