using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventRefusedToPay : HospitalEvent, IHospitalEventPatient
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnCharacterRefusedToPayForItem = (Action<Character, int, RoomItem>)Delegate.Combine(financeManager.OnCharacterRefusedToPayForItem, new Action<Character, int, RoomItem>(OnCharacterRefusedToPayForItem));
				FinanceManager financeManager2 = _level.FinanceManager;
				financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Combine(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
				FinanceManager financeManager3 = _level.FinanceManager;
				financeManager3.OnPatientRefusedToPayForTreatment = (Action<Patient, Staff, Room, int>)Delegate.Combine(financeManager3.OnPatientRefusedToPayForTreatment, new Action<Patient, Staff, Room, int>(OnPatientRefusedToPayForTreatment));
			}

			public override void UnregisterEvents()
			{
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnCharacterRefusedToPayForItem = (Action<Character, int, RoomItem>)Delegate.Remove(financeManager.OnCharacterRefusedToPayForItem, new Action<Character, int, RoomItem>(OnCharacterRefusedToPayForItem));
				FinanceManager financeManager2 = _level.FinanceManager;
				financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Remove(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
				FinanceManager financeManager3 = _level.FinanceManager;
				financeManager3.OnPatientRefusedToPayForTreatment = (Action<Patient, Staff, Room, int>)Delegate.Remove(financeManager3.OnPatientRefusedToPayForTreatment, new Action<Patient, Staff, Room, int>(OnPatientRefusedToPayForTreatment));
			}

			private void OnPatientRefusedToPayForTreatment(Patient patient, Staff staff, Room room, int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventRefusedToPay
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_name = patient.CharacterName,
					_refusalType = ERefusalType.Treatment,
					_roomDefinition = room.Definition
				});
			}

			private void OnPatientRefusedToPayForDiagnosis(Patient patient, Staff staff, Room room, float diagnosisCertaintyIncrement, int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventRefusedToPay
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_name = patient.CharacterName,
					_refusalType = ERefusalType.Diagnosis,
					_roomDefinition = room.Definition
				});
			}

			private void OnCharacterRefusedToPayForItem(Character character, int amount, RoomItem roomItem)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventRefusedToPay
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_name = character.CharacterName,
					_refusalType = ERefusalType.Item,
					_itemDefinition = roomItem.Definition,
					_upgradeLevel = roomItem.UpgradeLevel
				});
			}
		}

		private enum ERefusalType
		{
			Item = 0,
			Diagnosis = 1,
			Treatment = 2
		}

		private ERefusalType _refusalType;

		private CharacterName _name;

		private RoomDefinition _roomDefinition;

		private int _upgradeLevel;

		private IRoomItemDefinition _itemDefinition;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			string result = string.Empty;
			switch (_refusalType)
			{
			case ERefusalType.Item:
				result = ScriptLocalization.HospitalEvent.RefusedToPay_Item_CS;
				result = LocalisedString.Replace(result, new SubPair[2]
				{
					new SubPair("{[NAME]}", _name.GetCharacterName()),
					new SubPair("{[ITEM]}", _itemDefinition.GetLocalisedName(_upgradeLevel))
				});
				break;
			case ERefusalType.Diagnosis:
				result = ScriptLocalization.HospitalEvent.RefusedToPay_Diagnosis_CS;
				result = LocalisedString.Replace(result, new SubPair[2]
				{
					new SubPair("{[NAME]}", _name.GetCharacterName()),
					new SubPair("{[ROOM]}", _roomDefinition.GetLocalisedName())
				});
				break;
			case ERefusalType.Treatment:
				result = ScriptLocalization.HospitalEvent.RefusedToPay_Treatment_CS;
				result = LocalisedString.Replace(result, new SubPair[2]
				{
					new SubPair("{[NAME]}", _name.GetCharacterName()),
					new SubPair("{[ROOM]}", _roomDefinition.GetLocalisedName())
				});
				break;
			}
			return result;
		}

		public CharacterName GetPatientName()
		{
			return _name;
		}
	}
}
