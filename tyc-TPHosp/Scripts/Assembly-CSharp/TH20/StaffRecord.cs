using System.Collections.Generic;
using System.Linq;

namespace TH20
{
	public class StaffRecord : MustCallDestroy
	{
		public enum RecordType
		{
			PatientCured = 0,
			PatientTreatmentIneffective = 1,
			PatientKilled = 2,
			DiagnosisContribution = 3,
			ResearchContribution = 4,
			MaintainedBrokenMachine = 5,
			MaintainedBlockedToilet = 6,
			MaintainedOutOfStock = 7,
			MaintainedWiltedPlant = 8,
			MaintainedLitter = 9,
			MaintainedMedicalWaste = 10,
			GhostsCaptured = 11,
			ServiceCheckIn = 12,
			ServiceKioskCustomer = 13,
			MarketingCampaign = 14,
			Promotion = 15,
			TrainingCompleted = 16,
			StaffHappiness = 17,
			PayReceived = 18,
			MoneyEarned = 19,
			AwardReceived = 20
		}

		public class YearlyRecord
		{
			public int XP;

			public int QualificationsReceived;

			public int PromotionsReceived;

			public int AwardsReceived;

			public float CumulativeHappiness;

			public int HappinessEntries;

			public int PatientsCured;

			public int PatientsIneffectivelyTreated;

			public int PatientsKilled;

			public int DiagnosisContributionsMade;

			public float DiagnosisContribution;

			public float ResearchContributed;

			public int CustomersCheckedIn;

			public int CustomersServedAtKiosk;

			public int MarketingCampaigns;

			public int ToiletsUnblocked;

			public int LitterCollected;

			public int PlantsWatered;

			public int MedicalWasteCleaned;

			public int VendingMachinesStocked;

			public int GhostsCaptured;

			public int BrokenMachinesFixed;

			public float MaintenanceContribution;

			public float MachineMaintenanceContribution;

			public float GetAverageHappiness()
			{
				if (HappinessEntries != 0)
				{
					return CumulativeHappiness / (float)HappinessEntries;
				}
				return 0f;
			}
		}

		public readonly Staff StaffOwner;

		public readonly List<YearlyRecord> RecordArchive = new List<YearlyRecord>();

		private int _totalEarned;

		private int _totalPaid;

		public YearlyRecord CurrentRecord { get; private set; }

		public YearlyRecord LastYearRecord
		{
			get
			{
				if (RecordArchive.Count <= 0)
				{
					return null;
				}
				return RecordArchive.Last();
			}
		}

		public int TotalEarned => _totalEarned;

		public int TotalPaid => _totalPaid;

		public int TotalPatientsCured { get; private set; }

		public int TotalPatientsIneffectivelyTreated { get; private set; }

		public int TotalPatientsKilled { get; private set; }

		public int TotalDiagnosisContributionsMade { get; private set; }

		public float TotalDiagnosisContribution { get; private set; }

		public float TotalResearchContributed { get; private set; }

		public int TotalCustomersCheckedIn { get; private set; }

		public int TotalCustomersServedAtKiosk { get; private set; }

		public int TotalMarketingCampaigns { get; private set; }

		public int TotalToiletsUnblocked { get; private set; }

		public int TotalLitterCollected { get; private set; }

		public int TotalPlantsWatered { get; private set; }

		public int TotalMedicalWasteCleaned { get; private set; }

		public int TotalVendingMachinesStocked { get; private set; }

		public int TotalGhostsCaptured { get; private set; }

		public int TotalBrokenMachinesFixed { get; private set; }

		public float TotalMaintenanceContribution { get; private set; }

		public float TotalMachineMaintenanceContribution { get; private set; }

		public int TotalQualificationsReceived { get; private set; }

		public int TotalPromotionsReceived { get; private set; }

		public int TotalAwardsReceived { get; private set; }

		public int TotalXP { get; private set; }

		public StaffRecord(Staff staff)
		{
			StaffOwner = staff;
			CurrentRecord = new YearlyRecord();
		}

		public void FinaliseMonthlyReport()
		{
			if (StaffOwner.Happiness != null)
			{
				RecordHappiness(StaffOwner.Happiness.Value());
			}
		}

		public void FinaliseYearlyReport()
		{
			int summedXP = GetSummedXP();
			int xP = summedXP - TotalXP;
			CurrentRecord.XP = xP;
			TotalXP = summedXP;
			RecordArchive.Add(CurrentRecord);
			CurrentRecord = new YearlyRecord();
		}

		public void RecordPatientCured()
		{
			CurrentRecord.PatientsCured++;
			TotalPatientsCured++;
		}

		public void RecordPatientTreatmentIneffective()
		{
			CurrentRecord.PatientsIneffectivelyTreated++;
			TotalPatientsIneffectivelyTreated++;
		}

		public void RecordPatientKilled()
		{
			CurrentRecord.PatientsKilled++;
			TotalPatientsKilled++;
		}

		public void RecordDiagnosisContribution(float contribution)
		{
			CurrentRecord.DiagnosisContribution += contribution;
			TotalDiagnosisContribution += contribution;
			CurrentRecord.DiagnosisContributionsMade++;
			TotalDiagnosisContributionsMade++;
		}

		public void RecordResearchContribution(float contribution)
		{
			CurrentRecord.ResearchContributed += contribution;
			TotalResearchContributed += contribution;
		}

		public void RecordCustomerCheckedIn()
		{
			CurrentRecord.CustomersCheckedIn++;
			TotalCustomersCheckedIn++;
		}

		public void RecordCustomerServedAtKiosk()
		{
			CurrentRecord.CustomersServedAtKiosk++;
			TotalCustomersServedAtKiosk++;
		}

		public void RecordMarketingCampaignRun()
		{
			CurrentRecord.MarketingCampaigns++;
			TotalMarketingCampaigns++;
		}

		public void RecordToiletUnblocked()
		{
			CurrentRecord.ToiletsUnblocked++;
			TotalToiletsUnblocked++;
		}

		public void RecordLitterCollected()
		{
			CurrentRecord.LitterCollected++;
			TotalLitterCollected++;
		}

		public void RecordPlantWatered()
		{
			CurrentRecord.PlantsWatered++;
			TotalPlantsWatered++;
		}

		public void RecordMedicalWasteCleaned()
		{
			CurrentRecord.MedicalWasteCleaned++;
			TotalMedicalWasteCleaned++;
		}

		public void RecordVendingMachineStocked()
		{
			CurrentRecord.VendingMachinesStocked++;
			TotalVendingMachinesStocked++;
		}

		public void RecordGhostsCaptured()
		{
			CurrentRecord.GhostsCaptured++;
			TotalGhostsCaptured++;
		}

		public void RecordBrokenMachineFixed()
		{
			CurrentRecord.BrokenMachinesFixed++;
			TotalBrokenMachinesFixed++;
		}

		public void RecordMaintenanceContribution(float amount)
		{
			CurrentRecord.MaintenanceContribution += amount;
			TotalMaintenanceContribution += amount;
		}

		public void RecordMachineMaintenanceContribution(float amount)
		{
			CurrentRecord.MachineMaintenanceContribution += amount;
			TotalMachineMaintenanceContribution += amount;
		}

		public void RecordQualification()
		{
			CurrentRecord.QualificationsReceived++;
			TotalQualificationsReceived++;
		}

		public void RecordPromotion()
		{
			CurrentRecord.PromotionsReceived++;
			TotalPromotionsReceived++;
		}

		public void RecordAward()
		{
			CurrentRecord.AwardsReceived++;
			TotalAwardsReceived++;
		}

		public void RecordMoneyEarned(int earned)
		{
			_totalEarned += earned;
		}

		public void RecordMoneyPaid(int paid)
		{
			_totalPaid += paid;
		}

		public void RecordHappiness(float happiness)
		{
			CurrentRecord.CumulativeHappiness += happiness;
			CurrentRecord.HappinessEntries++;
		}

		public int GetSummedXP()
		{
			float num = 0f;
			for (int i = 0; i < StaffOwner.Rank - 1; i++)
			{
				num += StaffOwner.Definition._rank[i].MaximumXP;
			}
			num += StaffOwner.XP.Value();
			return (int)num;
		}
	}
}
