using System;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.GameOverSecondMapEvent", "")]
	public class GameOverSecondMapEvent : GameEventInstance
	{
		public GameOverSecondMapEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new ShowDialogPhase(0), new LoadMainScenePhase());
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public GameOverSecondMapEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
