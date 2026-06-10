using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.CropBlightEvent", "")]
	public class CropBlightEvent : GameEventInstance
	{
		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new RunCropBlightPhase());
		}

		public CropBlightEvent()
		{
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<CropBlightManager>.IsInstantiated())
			{
				return false;
			}
			if (base.CanStart())
			{
				return CropBlightManager.IsCropBlightPossible();
			}
			return false;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public CropBlightEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
