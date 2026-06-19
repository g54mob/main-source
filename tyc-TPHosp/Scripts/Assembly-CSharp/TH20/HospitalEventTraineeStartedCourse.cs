using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventTraineeStartedCourse : HospitalEvent, IHospitalEventStaff, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			}

			private void OnStaffStartLearning(Staff staff, RoomLogicTrainingRoom roomLogicTrainingRoom)
			{
				int num = ((roomLogicTrainingRoom.Teacher is GuestTrainer guestTrainer) ? guestTrainer.Definition.GetSkill(roomLogicTrainingRoom.Qualification).GetCostPerTrainee(_level) : 0);
				_level.HospitalEventLog.AddEvent(new HospitalEventTraineeStartedCourse
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					StaffName = staff.CharacterName,
					Course = roomLogicTrainingRoom.Qualification,
					Money = -num
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
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.TraineeStartedCourse_CS, new SubPair[2]
			{
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[QUALIFICATION]}", Course.NameLocalised.Translation)
			});
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

		public CharacterName GetStaffName()
		{
			return StaffName;
		}
	}
}
