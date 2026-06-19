using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventEpidemicStart : HospitalEvent
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			}

			public override void UnregisterEvents()
			{
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			}

			private void OnObjectiveStarted(Objective objective)
			{
				if (objective is ChallengeEpidemic)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventEpidemicStart
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate
					});
				}
			}
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.EpidemicStart_CS;
		}
	}
}
