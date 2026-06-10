using System;
using NSEipix.Base;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Serialization;
using NSMedieval.UI.Statistic;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	[FVSerializableKey("AddHistoricalEntryPhase", "")]
	public class AddHistoricalEntryPhase : SingleExecutePhaseBase
	{
		public AddHistoricalEntryPhase()
		{
		}

		protected override void Execute()
		{
			if (base.Blueprint.Dialogs != null && base.Blueprint.Dialogs.Count != 0)
			{
				MonoSingleton<HistoricalRecordsManager>.Instance.OnGameEventOptionChosen(base.EventInstance, 0);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public AddHistoricalEntryPhase(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
