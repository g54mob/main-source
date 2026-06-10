using System;
using NSEipix.Base;
using NSMedieval.Serialization;
using NSMedieval.Village;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.RoomFloodEvent", "")]
	public class RoomFloodEvent : GameEventInstance
	{
		public RoomFloodEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new RoomFloodPhase());
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.Workers.Count == 0)
			{
				return false;
			}
			if (!base.CanStart())
			{
				return false;
			}
			return VillageManager.ActiveVillage.Map.RoomDetection.AnyRoomSafe(RoomFloodPhase.RoomFloodCheck);
		}

		protected override void ShowStartText()
		{
		}

		protected override void ShowEndText()
		{
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public RoomFloodEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
