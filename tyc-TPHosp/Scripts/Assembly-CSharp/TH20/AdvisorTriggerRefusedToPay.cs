using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRefusedToPay : AdvisorTrigger
	{
		private string _text;

		private bool _messageSet;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerRefusedToPay(AdvisorTriggerRefusedToPayDefinition definition)
			: base(definition)
		{
		}

		public override void OnRegister(App app, Level level, Advisor advisor, AdvisorMenu advisorMenu)
		{
			base.OnRegister(app, level, advisor, advisorMenu);
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnCharacterRefusedToPayForItem = (Action<Character, int, RoomItem>)Delegate.Combine(financeManager.OnCharacterRefusedToPayForItem, new Action<Character, int, RoomItem>(OnCharacterRefusedToPayForItem));
			FinanceManager financeManager2 = Level.FinanceManager;
			financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Combine(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
			FinanceManager financeManager3 = Level.FinanceManager;
			financeManager3.OnPatientRefusedToPayForTreatment = (Action<Patient, Staff, Room, int>)Delegate.Combine(financeManager3.OnPatientRefusedToPayForTreatment, new Action<Patient, Staff, Room, int>(OnPatientRefusedToPayForTreatment));
		}

		public override void OnUnregister()
		{
			FinanceManager financeManager = Level.FinanceManager;
			financeManager.OnCharacterRefusedToPayForItem = (Action<Character, int, RoomItem>)Delegate.Remove(financeManager.OnCharacterRefusedToPayForItem, new Action<Character, int, RoomItem>(OnCharacterRefusedToPayForItem));
			FinanceManager financeManager2 = Level.FinanceManager;
			financeManager2.OnPatientRefusedToPayForDiagnosis = (FinanceManager.PatientRefusedToPayForDiagnosisDelegate)Delegate.Remove(financeManager2.OnPatientRefusedToPayForDiagnosis, new FinanceManager.PatientRefusedToPayForDiagnosisDelegate(OnPatientRefusedToPayForDiagnosis));
			FinanceManager financeManager3 = Level.FinanceManager;
			financeManager3.OnPatientRefusedToPayForTreatment = (Action<Patient, Staff, Room, int>)Delegate.Remove(financeManager3.OnPatientRefusedToPayForTreatment, new Action<Patient, Staff, Room, int>(OnPatientRefusedToPayForTreatment));
		}

		private void OnCharacterRefusedToPayForItem(Character character, int amount, RoomItem roomItem)
		{
			if (!(base.CooldownTimeRemaining > 0f))
			{
				_messageSet = true;
				_interestPoint = character.GetCameraTrackObject();
				_text = ScriptLocalization.Advisor.Finance_RefusedToPay_Item_CS;
				_text = LocalisedString.Replace(_text, new SubPair[2]
				{
					new SubPair("{[PRICE]}", StringUtils.FormatCurrency(amount)),
					new SubPair("{[ITEM]}", roomItem.LocalisedName)
				});
			}
		}

		private void OnPatientRefusedToPayForDiagnosis(Patient patient, Staff staff, Room room, float diagnosisCertaintyIncrement, int amount)
		{
			if (!(base.CooldownTimeRemaining > 0f))
			{
				_messageSet = true;
				_interestPoint = patient.GetCameraTrackObject();
				_text = ScriptLocalization.Advisor.Finance_RefusedToPay_Diagnosis_CS;
				_text = LocalisedString.Replace(_text, new SubPair[2]
				{
					new SubPair("{[PRICE]}", StringUtils.FormatCurrency(amount)),
					new SubPair("{[ROOM]}", room.Definition.GetLocalisedName())
				});
			}
		}

		private void OnPatientRefusedToPayForTreatment(Patient patient, Staff staff, Room room, int amount)
		{
			if (!(base.CooldownTimeRemaining > 0f))
			{
				_messageSet = true;
				_interestPoint = patient.GetCameraTrackObject();
				_text = ScriptLocalization.Advisor.Finance_RefusedToPay_Treatment_CS;
				_text = LocalisedString.Replace(_text, new SubPair[3]
				{
					new SubPair("{[PRICE]}", StringUtils.FormatCurrency(amount)),
					new SubPair("{[ILLNESS]}", patient.Illness.Name.Translation),
					new SubPair("{[ROOM]}", room.Definition.GetLocalisedName())
				});
			}
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!_messageSet)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			return Advisor.PriorityLevel.VeryHigh;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _text;
			result.CameraTrackObject = _interestPoint;
			_messageSet = false;
			return result;
		}
	}
}
