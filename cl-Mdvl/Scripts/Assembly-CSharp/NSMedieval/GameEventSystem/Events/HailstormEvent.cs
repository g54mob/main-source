using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.HailstormEvent", "")]
	public class HailstormEvent : AlterWeatherEvent
	{
		public HailstormEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new HailstormPhase());
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<WeatherManager>.IsInstantiated())
			{
				return false;
			}
			if (base.Blueprint.SkipIfWeatherEventsRunning != null)
			{
				foreach (string item in base.Blueprint.SkipIfWeatherEventsRunning)
				{
					if (MonoSingleton<WeatherManager>.Instance.IsEventRunning(item))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public HailstormEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
