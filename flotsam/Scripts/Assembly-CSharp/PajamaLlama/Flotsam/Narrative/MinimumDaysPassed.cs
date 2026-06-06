using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class MinimumDaysPassed : IScenarioTriggerableCondition
	{
		private enum Event
		{
			RunStarted = 0,
			ActorSpawned = 1,
			ActorRescued = 2,
			RegionScouted = 0x20
		}

		[SerializeField]
		private Event _event;

		[SerializeField]
		[ConditionalEnumHide("_event", 1, 2, true)]
		private ActorType _actorType;

		[SerializeField]
		[FormerlySerializedAs("_days")]
		private int _minimumDays;

		public bool IsMet()
		{
			int count = GameManager.TimeManager.Days.Count;
			switch (_event)
			{
			case Event.RunStarted:
				return _minimumDays <= count;
			case Event.ActorSpawned:
				return _minimumDays <= count - GameStatsManager.GetActorStat(_actorType, ActorStat.LastSpawnedDay);
			case Event.ActorRescued:
				return _minimumDays <= count - GameStatsManager.GetActorStat(_actorType, ActorStat.LastRescuedDay);
			case Event.RegionScouted:
				return _minimumDays <= count - StoryManager.LastRegionScoutedDay;
			default:
				Debug.LogException(new NotImplementedException($"MinimumDaysPassed.Event.{_event} needs implementation."));
				return false;
			}
		}
	}
}
