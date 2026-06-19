using I2.Loc;
using TH20.EventStaffHired;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffHired : HospitalEventStaff, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config, Interface, IGameEventCallback
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				if (!restoreFromSave)
				{
					_level.CharacterEvents.OnStaffHired.Add(this);
				}
			}

			public override void UnregisterEvents()
			{
				_level.CharacterEvents.OnStaffHired.Remove(this);
			}

			public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffHired(staff, _level.TimelineManager.CurrentGameDate)
				{
					_config = this,
					StaffName = staff.CharacterName,
					StaffDefinition = staff.Definition,
					RecruitmentFee = -fee
				});
			}
		}

		public CharacterName StaffName;

		public StaffDefinition StaffDefinition;

		public int RecruitmentFee;

		public HospitalEventStaffHired(Staff staff, GameDate expiryDate)
			: base(staff, expiryDate)
		{
		}

		public override Sprite GetEventIcon()
		{
			return StaffDefinition._icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffHired_CS.Replace("{[STAFF]}", StaffName.GetCharacterName());
		}

		public override CharacterName GetStaffName()
		{
			return StaffName;
		}

		public int GetFinanceValue()
		{
			return RecruitmentFee;
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
