using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffPayRise : HospitalEvent, IHospitalEventStaff, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Combine(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Remove(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			}

			private void OnStaffSalaryChanged(Staff staff, int salary)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffPayRise
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_staffName = staff.CharacterName,
					_salary = salary
				});
			}
		}

		private CharacterName _staffName;

		private int _salary;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffPayRise_CS.Replace("{[STAFF]}", _staffName.GetCharacterName());
		}

		public CharacterName GetStaffName()
		{
			return _staffName;
		}

		public int GetFinanceValue()
		{
			return _salary;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return false;
		}
	}
}
