using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventVIPPatientGroup : HospitalEvent
	{
		public new class Config : HospitalEvent.Config
		{
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
				if (objective is ChallengeSpecialPatient challengeSpecialPatient)
				{
					bool isGroupPlural = challengeSpecialPatient.GetConfig<ChallengeSpecialPatientConfig>()?.SpecialPatientNamePlural ?? false;
					_level.HospitalEventLog.AddEvent(new HospitalEventVIPPatientGroup
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_icon = challengeSpecialPatient.GetConfig<ChallengeConfig>().NoticeDef.Icon,
						_groupName = challengeSpecialPatient.Definition.NameLocalised,
						_isGroupPlural = isGroupPlural
					});
				}
			}
		}

		private Sprite _icon;

		private LocalisedString _groupName;

		private bool _isGroupPlural;

		public override Sprite GetEventIcon()
		{
			return _icon;
		}

		public override string GetDescription()
		{
			if (_isGroupPlural)
			{
				return ScriptLocalization.HospitalEvent.VIPPatientGroupPlural_CS.Replace("{[PLURALNAME]}", _groupName.Translation);
			}
			return ScriptLocalization.HospitalEvent.VIPPatientGroup_CS.Replace("{[NAME]}", _groupName.Translation);
		}
	}
}
