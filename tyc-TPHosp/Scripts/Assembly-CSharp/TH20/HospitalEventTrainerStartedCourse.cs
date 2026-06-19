using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventTrainerStartedCourse : HospitalEvent, IHospitalEventStaff, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartTeaching));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffStartTeaching = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents.OnStaffStartTeaching, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartTeaching));
			}

			private void OnStaffStartTeaching(Staff staff, RoomLogicTrainingRoom roomLogicTrainingRoom)
			{
				GuestTrainer guestTrainer = staff as GuestTrainer;
				QualificationDefinition qualification = roomLogicTrainingRoom.Qualification;
				int money = ((guestTrainer != null) ? (-guestTrainer.Definition.GetSkill(qualification).GetUpfrontCost(staff.Level)) : 0);
				_level.HospitalEventLog.AddEvent(new HospitalEventTrainerStartedCourse
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					StaffName = staff.CharacterName,
					Course = qualification,
					Money = money
				});
			}
		}

		public CharacterName StaffName;

		public QualificationDefinition Course;

		public int Money;

		public override Sprite GetEventIcon()
		{
			return Course.Icon;
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.TrainerStartedCourse_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[QUALIFICATION]}", Course.NameLocalised.Translation)
			});
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}

		public int GetFinanceValue()
		{
			return Money;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}
	}
}
