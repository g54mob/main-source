using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventDiagnosisSessionCompleted : HospitalEvent, IHospitalEventFinance, IHospitalEventDiagnosis, IHospitalEventStaff, IHospitalEventPatient
	{
		public new class Config : HospitalEvent.Config
		{
			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Combine(financeManager.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
				FinanceManager financeManager2 = _level.FinanceManager;
				financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Combine(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
			}

			public override void UnregisterEvents()
			{
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Remove(financeManager.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
				FinanceManager financeManager2 = _level.FinanceManager;
				financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Remove(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
			}

			private void OnPatientChargedForDiagnosis(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventDiagnosisSessionCompleted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					PatientName = patient.CharacterName,
					StaffName = staff.CharacterName,
					RoomDefinition = room.Definition,
					UserSpecifiedRoomName = room.GetUserSpecifiedName(),
					DisagnosisCertaintyIncrement = certaintyIncrement,
					MoneyEarned = _level.FinanceManager.GetDiagnosisCharge(room.Definition),
					RefusedToPay = false
				});
			}

			private void OnPatientRefusedToPayForDiagnosis(Patient patient, Staff staff, Room room, float diagnosisCertaintyIncrement, int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventDiagnosisSessionCompleted
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					PatientName = patient.CharacterName,
					StaffName = staff.CharacterName,
					RoomDefinition = room.Definition,
					UserSpecifiedRoomName = room.GetUserSpecifiedName(),
					DisagnosisCertaintyIncrement = diagnosisCertaintyIncrement,
					MoneyEarned = 0,
					RefusedToPay = true
				});
			}
		}

		public CharacterName PatientName;

		public CharacterName StaffName;

		public RoomDefinition RoomDefinition;

		public float DisagnosisCertaintyIncrement;

		public int MoneyEarned;

		public bool RefusedToPay;

		public string UserSpecifiedRoomName;

		public override Sprite GetEventIcon()
		{
			return RoomDefinition._icon;
		}

		public override string GetDescription()
		{
			string replace = ((!string.IsNullOrEmpty(UserSpecifiedRoomName)) ? UserSpecifiedRoomName : ((RoomDefinition != null) ? RoomDefinition.GetLocalisedName() : "???"));
			return LocalisedString.Replace(ScriptLocalization.HospitalEvent.DiagnosisSessionCompleted_CS, new SubPair[3]
			{
				new SubPair("{[PATIENT]}", PatientName.GetCharacterName()),
				new SubPair("{[STAFF]}", StaffName.GetCharacterName()),
				new SubPair("{[ROOM]}", replace)
			});
		}

		public int GetFinanceValue()
		{
			return MoneyEarned;
		}

		public bool IsFinanceValueValid()
		{
			if (!RefusedToPay)
			{
				return GetFinanceValue() != 0;
			}
			return true;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public float GetDiagnosisValue()
		{
			return DisagnosisCertaintyIncrement;
		}

		public Sprite GetDiagnosisSprite()
		{
			return null;
		}

		public CharacterName GetStaffName()
		{
			return StaffName;
		}

		public CharacterName GetPatientName()
		{
			return PatientName;
		}
	}
}
