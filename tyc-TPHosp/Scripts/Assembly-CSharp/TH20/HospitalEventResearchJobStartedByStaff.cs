using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventResearchJobStartedByStaff : HospitalEvent, IHospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffAssignedJob = (Action<Room, Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffAssignedJob, new Action<Room, Staff, Job, bool>(OnStaffAssignedJob));
			}

			private void OnStaffAssignedJob(Room room, Staff staff, Job job, bool wasOnBreak)
			{
				if (!(job is JobResearch))
				{
					return;
				}
				ResearchProject project = null;
				RoomAlgorithms.IterateRoomItemsWithComponent(room, delegate(ResearchProjectComponent component)
				{
					if (component.Project != null)
					{
						project = component.Project;
					}
				});
				if (project != null)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventResearchJobStartedByStaff
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_staffName = staff.CharacterName,
						_projectName = project.Definition.NameLocalised
					});
				}
			}
		}

		private CharacterName _staffName;

		private LocalisedString _projectName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.ResearchJobStartedByStaff_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", _staffName.GetCharacterName()),
				new SubPair("{[PROJECT]}", _projectName.Translation)
			});
		}

		public CharacterName GetStaffName()
		{
			return _staffName;
		}
	}
}
