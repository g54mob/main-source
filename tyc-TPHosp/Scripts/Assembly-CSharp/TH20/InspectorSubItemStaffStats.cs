using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class InspectorSubItemStaffStats : InspectorSubItem
	{
		[SerializeField]
		private TMP_Text _employmentLengthText;

		[SerializeField]
		private TMP_Text _totalIncomeText;

		[SerializeField]
		private TMP_Text _totalPaidText;

		[SerializeField]
		private List<TMP_Text> _labelList;

		[SerializeField]
		private List<TMP_Text> _valueList;

		[SerializeField]
		private TMP_Text _trainingText;

		[SerializeField]
		private TMP_Text _promotionsText;

		[SerializeField]
		private TMP_Text _awardsWonText;

		[SerializeField]
		private List<GameObject> _statPanelList;

		[SerializeField]
		private List<TMP_Text> _statLabelList;

		[SerializeField]
		private List<TMP_Text> _statValueList;

		[SerializeField]
		private SharedInstance_TH20TH20_QualificationDefinition _researchQualification;

		[SerializeField]
		private SharedInstance_TH20TH20_QualificationDefinition _mechanicsQualification;

		[SerializeField]
		private SharedInstance_TH20TH20_QualificationDefinition _marketingQualification;

		[SerializeField]
		private PieChart _pieChart;

		private Staff _staff;

		public void Setup(Staff staff)
		{
			_staff = staff;
			switch (_staff.Definition._type)
			{
			case StaffDefinition.Type.Doctor:
			case StaffDefinition.Type.Nurse:
				_labelList[0].text = ScriptLocalization.Inspector.StaffStats_PatientsDiagnosed_CS + ":";
				_labelList[1].text = string.Empty;
				_valueList[1].text = string.Empty;
				_labelList[2].text = ScriptLocalization.Inspector.StaffStats_PatientsCured_CS + ":";
				_labelList[3].text = ScriptLocalization.Inspector.StaffStats_TreatmentFailed_CS + ":";
				_labelList[4].text = ScriptLocalization.Inspector.StaffStats_Deaths_CS + ":";
				_labelList[5].text = string.Empty;
				_valueList[5].text = string.Empty;
				_labelList[6].text = ScriptLocalization.Inspector.StaffStats_CureRate_CS + ":";
				_pieChart.SetSegmentShowing(0, isShowing: true);
				_pieChart.SetSegmentShowing(1, isShowing: true);
				_pieChart.SetSegmentShowing(2, isShowing: true);
				_pieChart.SetSegmentShowing(3, isShowing: false);
				_pieChart.SetSegmentShowing(4, isShowing: false);
				_pieChart.SetSegmentShowing(5, isShowing: false);
				_pieChart.SetSegmentShowing(6, isShowing: false);
				_pieChart.SetSegmentDescription(0, ScriptLocalization.Inspector.StaffStats_PatientsCured_CS);
				_pieChart.SetSegmentDescription(1, ScriptLocalization.Inspector.StaffStats_TreatmentFailed_CS);
				_pieChart.SetSegmentDescription(2, ScriptLocalization.Inspector.StaffStats_Deaths_CS);
				_pieChart.SetSegmentColor(0, Color.green);
				_pieChart.SetSegmentColor(1, Color.yellow);
				_pieChart.SetSegmentColor(2, Color.red);
				break;
			case StaffDefinition.Type.Janitor:
				_labelList[0].text = ScriptLocalization.Inspector.StaffStats_ToiletsUnblocked_CS + ":";
				_labelList[1].text = ScriptLocalization.Inspector.StaffStats_MachinesRepaired_CS + ":";
				_labelList[2].text = ScriptLocalization.Inspector.StaffStats_BinsEmptied_CS + ":";
				_labelList[3].text = ScriptLocalization.Inspector.StaffStats_FloorsCleaned_CS + ":";
				_labelList[4].text = ScriptLocalization.Inspector.StaffStats_VendingMachines_CS + ":";
				_labelList[5].text = ScriptLocalization.Inspector.StaffStats_PlantsWatered_CS + ":";
				_labelList[6].text = ScriptLocalization.Inspector.StaffStats_GhostsCaptured_CS + ":";
				_pieChart.SetSegmentShowing(0, isShowing: true);
				_pieChart.SetSegmentShowing(1, isShowing: true);
				_pieChart.SetSegmentShowing(2, isShowing: true);
				_pieChart.SetSegmentShowing(3, isShowing: true);
				_pieChart.SetSegmentShowing(4, isShowing: true);
				_pieChart.SetSegmentShowing(5, isShowing: true);
				_pieChart.SetSegmentShowing(6, isShowing: true);
				_pieChart.SetSegmentDescription(0, ScriptLocalization.Inspector.StaffStats_ToiletsUnblocked_CS);
				_pieChart.SetSegmentDescription(1, ScriptLocalization.Inspector.StaffStats_MachinesRepaired_CS);
				_pieChart.SetSegmentDescription(2, ScriptLocalization.Inspector.StaffStats_BinsEmptied_CS);
				_pieChart.SetSegmentDescription(3, ScriptLocalization.Inspector.StaffStats_FloorsCleaned_CS);
				_pieChart.SetSegmentDescription(4, ScriptLocalization.Inspector.StaffStats_VendingMachines_CS);
				_pieChart.SetSegmentDescription(5, ScriptLocalization.Inspector.StaffStats_PlantsWatered_CS);
				_pieChart.SetSegmentDescription(6, ScriptLocalization.Inspector.StaffStats_GhostsCaptured_CS);
				_pieChart.SetSegmentColor(0, Color.green);
				_pieChart.SetSegmentColor(1, Color.blue);
				_pieChart.SetSegmentColor(2, Color.red);
				_pieChart.SetSegmentColor(3, Color.yellow);
				_pieChart.SetSegmentColor(4, Color.magenta);
				_pieChart.SetSegmentColor(5, Color.cyan);
				_pieChart.SetSegmentColor(6, Color.black);
				break;
			case StaffDefinition.Type.Assistant:
				_labelList[0].text = string.Empty;
				_valueList[0].text = string.Empty;
				_labelList[1].text = string.Empty;
				_valueList[1].text = string.Empty;
				_labelList[2].text = ScriptLocalization.Inspector.StaffStats_CheckIns_CS + ":";
				_labelList[3].text = ScriptLocalization.Inspector.StaffStats_CustomersServed_CS + ":";
				_labelList[4].text = ScriptLocalization.Inspector.StaffStats_MarketingCampaigns_CS + ":";
				_labelList[5].text = string.Empty;
				_valueList[5].text = string.Empty;
				_labelList[6].text = string.Empty;
				_valueList[6].text = string.Empty;
				_pieChart.SetSegmentShowing(0, isShowing: true);
				_pieChart.SetSegmentShowing(1, isShowing: true);
				_pieChart.SetSegmentShowing(2, isShowing: true);
				_pieChart.SetSegmentShowing(3, isShowing: false);
				_pieChart.SetSegmentShowing(4, isShowing: false);
				_pieChart.SetSegmentShowing(5, isShowing: false);
				_pieChart.SetSegmentShowing(6, isShowing: false);
				_pieChart.SetSegmentDescription(0, ScriptLocalization.Inspector.StaffStats_CheckIns_CS);
				_pieChart.SetSegmentDescription(1, ScriptLocalization.Inspector.StaffStats_CustomersServed_CS);
				_pieChart.SetSegmentDescription(2, ScriptLocalization.Inspector.StaffStats_MarketingCampaigns_CS);
				_pieChart.SetSegmentColor(0, Color.blue);
				_pieChart.SetSegmentColor(1, Color.green);
				_pieChart.SetSegmentColor(2, Color.red);
				break;
			}
		}

		private void Update()
		{
			if (_staff != null)
			{
				double num = _staff.TotalTimeInHospital / (double)GameAlgorithms.Config.SecondsPerDay * 86400.0;
				_employmentLengthText.text = StringUtils.FormatTimeSpanDaysMonthsYears((uint)num);
				int totalEarned = _staff.StaffRecord.TotalEarned;
				_totalIncomeText.text = StringUtils.FormatCurrency(totalEarned);
				int totalPaid = _staff.StaffRecord.TotalPaid;
				_totalPaidText.text = StringUtils.FormatCurrency(totalPaid);
				int totalQualificationsReceived = _staff.StaffRecord.TotalQualificationsReceived;
				_trainingText.text = totalQualificationsReceived.ToString();
				int totalPromotionsReceived = _staff.StaffRecord.TotalPromotionsReceived;
				_promotionsText.text = totalPromotionsReceived.ToString();
				int totalAwardsReceived = _staff.StaffRecord.TotalAwardsReceived;
				_awardsWonText.text = totalAwardsReceived.ToString();
				float movementSpeedPercentage = _staff.GetMovementSpeedPercentage();
				switch (_staff.Definition._type)
				{
				case StaffDefinition.Type.Doctor:
				case StaffDefinition.Type.Nurse:
				{
					int totalDiagnosisContributionsMade = _staff.StaffRecord.TotalDiagnosisContributionsMade;
					int totalPatientsCured = _staff.StaffRecord.TotalPatientsCured;
					int totalPatientsIneffectivelyTreated = _staff.StaffRecord.TotalPatientsIneffectivelyTreated;
					int totalPatientsKilled = _staff.StaffRecord.TotalPatientsKilled;
					int num2 = totalPatientsIneffectivelyTreated + totalPatientsKilled + totalPatientsCured;
					float value = ((num2 == 0) ? 0f : ((float)totalPatientsCured / (float)num2));
					_valueList[0].text = totalDiagnosisContributionsMade.ToString("N0");
					_valueList[2].text = StringUtils.FormatNumber(totalPatientsCured);
					_valueList[3].text = StringUtils.FormatNumber(totalPatientsIneffectivelyTreated);
					_valueList[4].text = StringUtils.FormatNumber(totalPatientsKilled);
					_valueList[6].text = StringUtils.FormatPercentageValue(value, prefixPlus: true);
					_pieChart.SetSegmentValue(0, totalPatientsCured);
					_pieChart.SetSegmentValue(1, totalPatientsIneffectivelyTreated);
					_pieChart.SetSegmentValue(2, totalPatientsKilled);
					_statLabelList[0].text = ScriptLocalization.Inspector.StaffStats_DiagnosisSkill_CS;
					_statLabelList[1].text = ScriptLocalization.Inspector.StaffStats_TreatmentSkill_CS;
					_statLabelList[2].text = ScriptLocalization.Inspector.StaffStats_ResearchSkill_CS;
					_statLabelList[3].text = ScriptLocalization.Inspector.StaffStats_Speed_CS;
					_statValueList[0].text = StringUtils.FormatPercentageValue(_staff.GetDiagnosisMultiplier(_staff.RoomUsing));
					_statValueList[1].text = StringUtils.FormatPercentageValue(_staff.GetTreatmentSkillRating(_staff.RoomUsing));
					_statValueList[2].text = StringUtils.FormatPercentageValue(_staff.GetResearchRate(_staff.RoomUsing));
					_statValueList[3].text = StringUtils.FormatPercentageValue(movementSpeedPercentage);
					GameObjectUtils.SetActive(_statPanelList[0], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[1], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[2], _staff.HasCompletedQualification(_researchQualification.Instance));
					GameObjectUtils.SetActive(_statPanelList[3], isActive: true);
					break;
				}
				case StaffDefinition.Type.Janitor:
				{
					int totalToiletsUnblocked = _staff.StaffRecord.TotalToiletsUnblocked;
					int totalBrokenMachinesFixed = _staff.StaffRecord.TotalBrokenMachinesFixed;
					int totalLitterCollected = _staff.StaffRecord.TotalLitterCollected;
					int totalMedicalWasteCleaned = _staff.StaffRecord.TotalMedicalWasteCleaned;
					int totalVendingMachinesStocked = _staff.StaffRecord.TotalVendingMachinesStocked;
					int totalPlantsWatered = _staff.StaffRecord.TotalPlantsWatered;
					int totalGhostsCaptured = _staff.StaffRecord.TotalGhostsCaptured;
					_valueList[0].text = StringUtils.FormatNumber(totalToiletsUnblocked);
					_valueList[1].text = StringUtils.FormatNumber(totalBrokenMachinesFixed);
					_valueList[2].text = StringUtils.FormatNumber(totalLitterCollected);
					_valueList[3].text = StringUtils.FormatNumber(totalMedicalWasteCleaned);
					_valueList[4].text = StringUtils.FormatNumber(totalVendingMachinesStocked);
					_valueList[5].text = StringUtils.FormatNumber(totalPlantsWatered);
					_valueList[6].text = StringUtils.FormatNumber(totalGhostsCaptured);
					_pieChart.SetSegmentValue(0, totalToiletsUnblocked);
					_pieChart.SetSegmentValue(1, totalBrokenMachinesFixed);
					_pieChart.SetSegmentValue(2, totalLitterCollected);
					_pieChart.SetSegmentValue(3, totalMedicalWasteCleaned);
					_pieChart.SetSegmentValue(4, totalVendingMachinesStocked);
					_pieChart.SetSegmentValue(5, totalPlantsWatered);
					_pieChart.SetSegmentValue(6, totalGhostsCaptured);
					_statLabelList[0].text = ScriptLocalization.Inspector.StaffStats_MaintenanceSkill_CS;
					_statLabelList[1].text = ScriptLocalization.Inspector.StaffStats_UpgradeSkill_CS;
					_statLabelList[2].text = ScriptLocalization.Inspector.StaffStats_Speed_CS;
					_statValueList[0].text = StringUtils.FormatPercentageValue(_staff.GetMaintenanceMultiplier(_staff.RoomUsing));
					_statValueList[1].text = StringUtils.FormatPercentageValue(_staff.GetUpgradeItemMultiplier(_staff.RoomUsing));
					_statValueList[2].text = StringUtils.FormatPercentageValue(movementSpeedPercentage);
					GameObjectUtils.SetActive(_statPanelList[0], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[1], _staff.HasCompletedQualification(_mechanicsQualification.Instance));
					GameObjectUtils.SetActive(_statPanelList[2], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[3], isActive: false);
					break;
				}
				case StaffDefinition.Type.Assistant:
				{
					int totalCustomersCheckedIn = _staff.StaffRecord.TotalCustomersCheckedIn;
					int totalCustomersServedAtKiosk = _staff.StaffRecord.TotalCustomersServedAtKiosk;
					int totalMarketingCampaigns = _staff.StaffRecord.TotalMarketingCampaigns;
					_valueList[2].text = StringUtils.FormatNumber(totalCustomersCheckedIn);
					_valueList[3].text = StringUtils.FormatNumber(totalCustomersServedAtKiosk);
					_valueList[4].text = StringUtils.FormatNumber(totalMarketingCampaigns);
					_pieChart.SetSegmentValue(0, totalCustomersCheckedIn);
					_pieChart.SetSegmentValue(1, totalCustomersServedAtKiosk);
					_pieChart.SetSegmentValue(2, totalMarketingCampaigns);
					_statLabelList[0].text = ScriptLocalization.Inspector.StaffStats_CustomerServiceSkill_CS;
					_statLabelList[1].text = ScriptLocalization.Inspector.StaffStats_MarketingSkill_CS;
					_statLabelList[2].text = ScriptLocalization.Inspector.StaffStats_Speed_CS;
					_statValueList[0].text = StringUtils.FormatPercentageValue(_staff.GetServiceMultiplier(_staff.RoomUsing));
					_statValueList[1].text = StringUtils.FormatPercentageValue(_staff.GetMarketingSkill(_staff.RoomUsing));
					_statValueList[2].text = StringUtils.FormatPercentageValue(movementSpeedPercentage);
					GameObjectUtils.SetActive(_statPanelList[0], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[1], _staff.HasCompletedQualification(_marketingQualification.Instance));
					GameObjectUtils.SetActive(_statPanelList[2], isActive: true);
					GameObjectUtils.SetActive(_statPanelList[3], isActive: false);
					break;
				}
				}
			}
		}
	}
}
