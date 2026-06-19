using System;
using System.Collections.Generic;

namespace TH20
{
	public class StaffRecordManager : MustCallDestroy
	{
		private readonly CharacterEvents _characterEvents;

		private readonly CharacterManager _characterManager;

		private readonly TimelineManager _timelineManager;

		private readonly FinanceManager _financeManager;

		private readonly BuildEvents _buildEvents;

		public StaffRecordManager(CharacterManager characterManager, TimelineManager timelineManager, CharacterEvents characterEvents, FinanceManager financeManager, BuildEvents buildEvents)
		{
			_characterEvents = characterEvents;
			_characterManager = characterManager;
			_timelineManager = timelineManager;
			_financeManager = financeManager;
			_buildEvents = buildEvents;
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents5.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnStaffContributedToDiagnosis));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents6.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents7.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualified));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Combine(characterEvents8.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnStaffServedCustomer = (Action<Staff, Character>)Delegate.Combine(characterEvents9.OnStaffServedCustomer, new Action<Staff, Character>(OnStaffServeCustomer));
			TimelineManager timelineManager2 = _timelineManager;
			timelineManager2.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager2.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Combine(financeManager2.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Combine(financeManager3.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			FinanceManager financeManager4 = _financeManager;
			financeManager4.OnStaffPaid = (Action<Staff, int>)Delegate.Combine(financeManager4.OnStaffPaid, new Action<Staff, int>(OnStaffPaid));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Combine(buildEvents2.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(OnRoomItemMaintenanceComplete));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents3.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents4.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnStaffContributedToDiagnosis));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents5.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents6.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualified));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnStaffCompletedJob = (Action<Staff, Job, bool>)Delegate.Remove(characterEvents7.OnStaffCompletedJob, new Action<Staff, Job, bool>(OnStaffCompletedJob));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnStaffServedCustomer = (Action<Staff, Character>)Delegate.Remove(characterEvents8.OnStaffServedCustomer, new Action<Staff, Character>(OnStaffServeCustomer));
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			FinanceManager financeManager = _financeManager;
			financeManager.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Remove(financeManager.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Remove(financeManager2.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnStaffPaid = (Action<Staff, int>)Delegate.Remove(financeManager3.OnStaffPaid, new Action<Staff, int>(OnStaffPaid));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemMaintenanceComplete = (Action<RoomItem, Staff, JobMaintenance>)Delegate.Remove(buildEvents.OnRoomItemMaintenanceComplete, new Action<RoomItem, Staff, JobMaintenance>(OnRoomItemMaintenanceComplete));
			base.Destroy();
		}

		private void OnPatientChargedForDiagnosis(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount)
		{
			staff.StaffRecord.RecordMoneyEarned(amount);
		}

		private void OnPatientChargedForTreatment(Patient patient, Staff staff, Room room, int amount, int baseamount)
		{
			staff.StaffRecord.RecordMoneyEarned(amount);
		}

		private void OnStaffPaid(Staff staff, int amount)
		{
			staff.StaffRecord.RecordMoneyPaid(amount);
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			foreach (Staff item in involvedStaff)
			{
				item.StaffRecord.RecordPatientKilled();
			}
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			foreach (Staff item in involvedStaff)
			{
				item.StaffRecord.RecordPatientTreatmentIneffective();
			}
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			foreach (Staff item in involvedStaff)
			{
				item.StaffRecord.RecordPatientCured();
			}
		}

		private void OnStaffQualified(Staff staff, QualificationDefinition qualification, Staff trainer)
		{
			staff.StaffRecord.RecordQualification();
		}

		private void OnStaffPromoted(Staff staff)
		{
			staff.StaffRecord.RecordPromotion();
		}

		private void OnStaffContributedToDiagnosis(Patient patient, Staff staff, Room room, float increment)
		{
			staff.StaffRecord.RecordDiagnosisContribution(increment);
		}

		private void OnRoomItemMaintenanceComplete(RoomItem roomItem, Staff staff, JobMaintenance job)
		{
			if (roomItem.Definition.MaintenanceDescription == JobMaintenance.JobDescription.BrokenMachine || roomItem.Definition.MaintenanceDescription == JobMaintenance.JobDescription.Vehicular)
			{
				float amount = job.InitialMaintenanceValue - roomItem.MaintenanceLevel.Value();
				staff.StaffRecord.RecordMachineMaintenanceContribution(amount);
				staff.StaffRecord.RecordBrokenMachineFixed();
			}
		}

		private void OnStaffCompletedJob(Staff staff, Job job, bool success)
		{
			if (staff == null || job == null || !success)
			{
				return;
			}
			if (job is JobMaintenance { Item: var item } jobMaintenance)
			{
				if (item == null)
				{
					return;
				}
				float amount = jobMaintenance.InitialMaintenanceValue - item.MaintenanceLevel.Value();
				switch (item.Definition.MaintenanceDescription)
				{
				case JobMaintenance.JobDescription.BlockedToilet:
					staff.StaffRecord.RecordToiletUnblocked();
					staff.StaffRecord.RecordMaintenanceContribution(amount);
					break;
				case JobMaintenance.JobDescription.Litter:
					staff.StaffRecord.RecordLitterCollected();
					staff.StaffRecord.RecordMaintenanceContribution(100f);
					break;
				case JobMaintenance.JobDescription.WiltedPlant:
					staff.StaffRecord.RecordPlantWatered();
					staff.StaffRecord.RecordMaintenanceContribution(100f);
					break;
				case JobMaintenance.JobDescription.MedicalWaste:
					staff.StaffRecord.RecordMedicalWasteCleaned();
					staff.StaffRecord.RecordMaintenanceContribution(100f);
					break;
				case JobMaintenance.JobDescription.OutOfStock:
					staff.StaffRecord.RecordVendingMachineStocked();
					staff.StaffRecord.RecordMaintenanceContribution(100f);
					break;
				}
			}
			if (job is JobGhost)
			{
				staff.StaffRecord.RecordGhostsCaptured();
			}
			if (job is JobMarketing)
			{
				staff.StaffRecord.RecordMarketingCampaignRun();
			}
		}

		private void OnStaffServeCustomer(Staff staff, Character character)
		{
			if (staff == null)
			{
				return;
			}
			Job currentJob = staff.CurrentJob;
			if (currentJob == null)
			{
				return;
			}
			if (currentJob is JobRoom jobRoom && jobRoom.Room.Definition._type == RoomDefinition.Type.Reception)
			{
				staff.StaffRecord.RecordCustomerCheckedIn();
			}
			else
			{
				if (!(currentJob is JobService jobService))
				{
					return;
				}
				switch (jobService.RoomItemDefinition.ServiceDescription)
				{
				case JobService.JobDescription.ReceptionCheckIn:
					staff.StaffRecord.RecordCustomerCheckedIn();
					break;
				case JobService.JobDescription.KioskCustomer:
				{
					staff.StaffRecord.RecordCustomerServedAtKiosk();
					int num = 0;
					InteractionAttributeModifier[] interactionAttributeModifiers = jobService.RoomItemDefinition.InteractionAttributeModifiers;
					foreach (InteractionAttributeModifier interactionAttributeModifier in interactionAttributeModifiers)
					{
						if (interactionAttributeModifier._financeModifier.NotNull())
						{
							num += _financeManager.GetObjectInteractionBalanceModification(interactionAttributeModifier._financeModifier.Instance, 1f, out var _);
						}
					}
					if (num > 0)
					{
						staff.StaffRecord.RecordMoneyEarned(num);
					}
					break;
				}
				}
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day != 0)
			{
				return;
			}
			if (month == 0)
			{
				foreach (Staff staffMember in _characterManager.StaffMembers)
				{
					staffMember.StaffRecord.FinaliseMonthlyReport();
					staffMember.StaffRecord.FinaliseYearlyReport();
				}
				return;
			}
			foreach (Staff staffMember2 in _characterManager.StaffMembers)
			{
				staffMember2.StaffRecord.FinaliseMonthlyReport();
			}
		}
	}
}
