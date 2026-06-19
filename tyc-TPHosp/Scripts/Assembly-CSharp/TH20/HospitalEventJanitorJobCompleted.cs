using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventJanitorJobCompleted : HospitalEvent, IHospitalEventStaff, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}

			public override void UnregisterEvents()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			}

			private void OnStaffCompletedJob(Staff staff, Job job, bool success)
			{
				if (success && job is JobMaintenance jobMaintenance)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventJanitorJobCompleted
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						StaffName = staff.CharacterName,
						ItemDefinition = jobMaintenance.Item.Definition,
						UpgradeLevel = jobMaintenance.Item.UpgradeLevel,
						Money = jobMaintenance.GetCost()
					});
				}
			}
		}

		public IRoomItemDefinition ItemDefinition;

		public int UpgradeLevel;

		public CharacterName StaffName;

		public int Money;

		public override Sprite GetEventIcon()
		{
			return ItemDefinition.GetIcon();
		}

		public override string GetDescription()
		{
			return LocalisedString.Replace(ItemDefinition.MaintenanceDescription switch
			{
				JobMaintenance.JobDescription.BrokenMachine => ScriptLocalization.HospitalEvent.JanitorJobCompleted_BrokenMachine_CS, 
				JobMaintenance.JobDescription.BlockedToilet => ScriptLocalization.HospitalEvent.JanitorJobCompleted_BlockedToilet_CS, 
				JobMaintenance.JobDescription.OutOfStock => ScriptLocalization.HospitalEvent.JanitorJobCompleted_OutOfStock_CS, 
				JobMaintenance.JobDescription.WiltedPlant => ScriptLocalization.HospitalEvent.JanitorJobCompleted_WiltedPlant_CS, 
				JobMaintenance.JobDescription.Litter => ScriptLocalization.HospitalEvent.JanitorJobCompleted_Litter_CS, 
				JobMaintenance.JobDescription.MedicalWaste => ScriptLocalization.HospitalEvent.JanitorJobCompleted_MedicalWaste_CS, 
				JobMaintenance.JobDescription.Ghost => ScriptLocalization.HospitalEvent.JanitorJobCompleted_Ghost_CS, 
				JobMaintenance.JobDescription.Vehicular => ScriptLocalization.HospitalEvent.JanitorJobCompleted_BrokenMachine_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, new SubPair[2]
			{
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[ITEM]}", ItemDefinition.GetLocalisedName(UpgradeLevel))
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
