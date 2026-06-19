using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventTraineeCompletedCourse : HospitalEventStaff
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			}

			private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualification, Staff teacher)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventTraineeCompletedCourse(staff, _level.TimelineManager.CurrentGameDate)
				{
					_config = this,
					StaffName = staff.CharacterName,
					Course = qualification
				});
			}
		}

		public CharacterName StaffName;

		public QualificationDefinition Course;

		public HospitalEventTraineeCompletedCourse(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return Course.Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.TraineeCompletedCourse_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[QUALIFICATION]}", Course.NameLocalised.Translation)
			});
		}

		public override CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
