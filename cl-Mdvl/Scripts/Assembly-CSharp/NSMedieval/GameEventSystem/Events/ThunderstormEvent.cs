using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.ThunderstormEvent", "")]
	public class ThunderstormEvent : AlterWeatherEvent
	{
		public ThunderstormEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new ThunderstormPhase());
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<WeatherManager>.IsInstantiated())
			{
				return false;
			}
			if (!base.CanStart())
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

		public ThunderstormEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
