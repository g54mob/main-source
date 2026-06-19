using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class AwardsDebugMenu : MenuBase
	{
		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private List<Button> _awardButtons;

		[SerializeField]
		private TMP_Text _awardNameLabel;

		[SerializeField]
		private TMP_Text _tooltipLabel;

		[SerializeField]
		private TMP_Text _scoreRequiredLabel;

		[SerializeField]
		private TMP_Text _currentLeaderLabel;

		[SerializeField]
		private TMP_Text _staffRecordLabel;

		[SerializeField]
		private Text _staffRecordContentText;

		private List<HospitalAwardsManager.AwardType> _awardTypes;

		private int _awardIndex;

		private int _staffRecordIndex;

		private HospitalAwardsManager.AwardInstanceData _data;

		private Level _level;

		private HospitalAwardsManager _awardsManager;

		public void Setup(Level level, HospitalAwardsManager awardsManager)
		{
			_level = level;
			_awardsManager = awardsManager;
			_awardTypes = _awardsManager.AwardsConfig.AwardData.Keys.ToList();
			int count = _awardTypes.Count;
			for (int i = 0; i < _awardButtons.Count; i++)
			{
				_awardButtons[i].gameObject.SetActive(i < count);
			}
			_data = null;
			_awardIndex = 0;
			_staffRecordIndex = 0;
		}

		private void OnEnable()
		{
			_closeButton.onClick.AddListener(OnClosePressed);
		}

		private void OnDisable()
		{
			_closeButton.onClick.RemoveListener(OnClosePressed);
		}

		protected override void Update()
		{
			base.Update();
			if (_data == null)
			{
				_awardNameLabel.text = string.Empty;
				_tooltipLabel.text = string.Empty;
				_scoreRequiredLabel.text = "Score Required:";
				_currentLeaderLabel.text = "Current Leader:";
				_staffRecordLabel.text = "Staff Record: None";
				_staffRecordContentText.text = string.Empty;
				return;
			}
			_awardsManager.CalculatePendingAwards(useLastYearsRecords: false);
			HospitalAwardsManager.AwardType awardType = _awardTypes[_awardIndex];
			Staff highestScorer;
			bool flag = _awardsManager.DidWinAward(awardType, out highestScorer, useLastYearsRecords: false);
			_awardNameLabel.text = HospitalAwardsManager.AwardNames[(int)awardType];
			_tooltipLabel.text = _data.TooltipLoc.Translation;
			_scoreRequiredLabel.text = "Score Required: " + _data.ScoreThreshold;
			_currentLeaderLabel.color = (flag ? Color.green : Color.red);
			if (highestScorer != null)
			{
				float scoreForStaffMemeber = GetScoreForStaffMemeber(awardType, highestScorer);
				if (scoreForStaffMemeber > float.MinValue)
				{
					_currentLeaderLabel.text = "Current Leader: " + highestScorer.Name + " (" + scoreForStaffMemeber.ToString("n3") + ")";
				}
				else
				{
					_currentLeaderLabel.text = "Current Leader: " + highestScorer.Name;
				}
				if (_staffRecordIndex < 0)
				{
					_staffRecordLabel.text = "Staff Record: None";
					_staffRecordContentText.text = string.Empty;
				}
				else if (_staffRecordIndex <= _level.CharacterManager.StaffMembers.Count)
				{
					Staff staff = _level.CharacterManager.StaffMembers[_staffRecordIndex];
					float scoreForStaffMemeber2 = GetScoreForStaffMemeber(awardType, staff);
					if (scoreForStaffMemeber2 > float.MinValue)
					{
						_staffRecordLabel.text = "Staff Record: " + staff.Name + " (" + scoreForStaffMemeber2.ToString("n3") + ")";
						_staffRecordContentText.text = BuildStaffRecordString(awardType, staff);
					}
					else
					{
						_staffRecordLabel.text = "Staff Record: " + staff.Name;
						_staffRecordContentText.text = "Not eligble for this award.";
					}
					_staffRecordContentText.rectTransform.sizeDelta = new Vector2(_staffRecordContentText.rectTransform.sizeDelta.x, _staffRecordContentText.preferredHeight);
				}
				else
				{
					_staffRecordIndex = -1;
				}
			}
			else
			{
				float num = 0f;
				switch (awardType)
				{
				case HospitalAwardsManager.AwardType.HospitalOfTheYear:
					num = _awardsManager.GetHospitalOfTheYearScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.EmployerOfTheYear:
					num = _awardsManager.GetEmployerOfTheYearScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.MostPrestigious:
					num = _awardsManager.GetMostPrestigiousScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.NoDeaths:
					num = _awardsManager.GetNoDeathsScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.PatientsChoice:
					num = _awardsManager.GetPatientsChoiceScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.ResearchHospitalOfTheYear:
					num = _awardsManager.GetResearchHospitalOfTheYearScore(useLastYearRecords: false);
					break;
				case HospitalAwardsManager.AwardType.TeachingHospitalOfTheYear:
					num = _awardsManager.GetTeachingHospitalOfTheYearScore(useLastYearRecords: false);
					break;
				}
				_currentLeaderLabel.text = "Score: " + num.ToString("n3");
				_staffRecordLabel.text = "Record:";
				_staffRecordContentText.text = BuildHospitalRecordScore(awardType);
				_staffRecordContentText.rectTransform.sizeDelta = new Vector2(_staffRecordContentText.rectTransform.sizeDelta.x, _staffRecordContentText.preferredHeight);
			}
		}

		public void OnAwardButtonPressed(int awardIndex)
		{
			_awardIndex = awardIndex;
			_awardsManager.AwardsConfig.AwardData.TryGetValue(_awardTypes[_awardIndex], out _data);
		}

		public void OnGiveRewards()
		{
			_awardsManager.GiveReward(_awardTypes[_awardIndex]);
		}

		public void OnStaffRecordLeft()
		{
			_staffRecordIndex--;
			_staffRecordIndex = Mathf.Clamp(_staffRecordIndex, 0, _level.CharacterManager.StaffMembers.Count - 1);
		}

		public void OnStaffRecordRight()
		{
			_staffRecordIndex++;
			_staffRecordIndex = Mathf.Clamp(_staffRecordIndex, 0, _level.CharacterManager.StaffMembers.Count - 1);
		}

		private void OnClosePressed()
		{
			CloseMenu();
		}

		private float GetScoreForStaffMemeber(HospitalAwardsManager.AwardType awardType, Staff staff)
		{
			return awardType switch
			{
				HospitalAwardsManager.AwardType.AssistantOfTheYear => _awardsManager.GetAssistantOfTheYearScore(staff, useLastYearRecords: false), 
				HospitalAwardsManager.AwardType.DoctorOfTheYear => _awardsManager.GetDoctorOfTheYearScore(staff, useLastYearRecords: false), 
				HospitalAwardsManager.AwardType.JanitorOfTheYear => _awardsManager.GetJanitorOfTheYearScore(staff, useLastYearRecords: false), 
				HospitalAwardsManager.AwardType.NurseOfTheYear => _awardsManager.GetNurseOfTheYearScore(staff, useLastYearRecords: false), 
				HospitalAwardsManager.AwardType.RisingStar => _awardsManager.GetRisingStarScore(staff, useLastYearRecords: false), 
				_ => float.MinValue, 
			};
		}

		private string BuildStaffRecordString(HospitalAwardsManager.AwardType awardType, Staff staff)
		{
			switch (awardType)
			{
			case HospitalAwardsManager.AwardType.DoctorOfTheYear:
			case HospitalAwardsManager.AwardType.NurseOfTheYear:
				return BuildDoctorNurseOfTheYearString(staff.StaffRecord);
			case HospitalAwardsManager.AwardType.JanitorOfTheYear:
				return BuildJanitorOfTheYearString(staff.StaffRecord);
			case HospitalAwardsManager.AwardType.AssistantOfTheYear:
				return BuildAssistantOfTheYearString(staff.StaffRecord);
			case HospitalAwardsManager.AwardType.RisingStar:
				return BuildRisingStarString(staff.StaffRecord);
			default:
				return "No Record.";
			}
		}

		private string BuildDoctorNurseOfTheYearString(StaffRecord record)
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			stringBuilder.AppendFormat("Patients Cured = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.PatientsCured, instance.TreatmentMultiplier, (float)record.CurrentRecord.PatientsCured * instance.TreatmentMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Patients Ineffective Treatment = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.PatientsIneffectivelyTreated, instance.TreatmentMultiplier, (float)record.CurrentRecord.PatientsIneffectivelyTreated * instance.TreatmentMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Patients Killed = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.PatientsKilled, instance.TreatmentMultiplier, (float)record.CurrentRecord.PatientsKilled * instance.TreatmentMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Diagnosis Contributions = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.DiagnosisContribution, instance.DiagnosisMultiplier, record.CurrentRecord.DiagnosisContribution * instance.DiagnosisMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Research Contributions = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.ResearchContributed, instance.ResearchMultiplier, record.CurrentRecord.ResearchContributed * instance.ResearchMultiplier);
			return stringBuilder.ToString();
		}

		private string BuildJanitorOfTheYearString(StaffRecord record)
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			stringBuilder.AppendFormat("Clear Medical Waste = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.MedicalWasteCleaned, instance.MaintainedMedicalWaste, (float)record.CurrentRecord.MedicalWasteCleaned * instance.MaintainedMedicalWaste);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Clear Blocked Toilets = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.ToiletsUnblocked, instance.MaintainedBlockedToilet, (float)record.CurrentRecord.ToiletsUnblocked * instance.MaintainedBlockedToilet);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Fixed Broken Machines = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.BrokenMachinesFixed, instance.MaintainedMachineBroken, (float)record.CurrentRecord.BrokenMachinesFixed * instance.MaintainedMachineBroken);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Clear Litter Items = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.LitterCollected, instance.MaintainedLitter, (float)record.CurrentRecord.LitterCollected * instance.MaintainedLitter);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Restock Vending = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.VendingMachinesStocked, instance.MaintainedOutOfStock, (float)record.CurrentRecord.VendingMachinesStocked * instance.MaintainedOutOfStock);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Water Plants = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.PlantsWatered, instance.MaintainedWiltedPlants, (float)record.CurrentRecord.PlantsWatered * instance.MaintainedWiltedPlants);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Capture Ghosts = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.GhostsCaptured, instance.GhostsCaptured, (float)record.CurrentRecord.GhostsCaptured * instance.GhostsCaptured);
			return stringBuilder.ToString();
		}

		private string BuildAssistantOfTheYearString(StaffRecord record)
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			stringBuilder.AppendFormat("Service CheckIn = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.CustomersCheckedIn, instance.CustomersSeenMultiplier, (float)record.CurrentRecord.CustomersCheckedIn * instance.CustomersSeenMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Service Kiosk = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.CustomersServedAtKiosk, instance.CustomersSeenMultiplier, (float)record.CurrentRecord.CustomersServedAtKiosk * instance.CustomersSeenMultiplier);
			return stringBuilder.ToString();
		}

		private string BuildRisingStarString(StaffRecord record)
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			int num = 0;
			int num2 = 0;
			int totalXP = record.TotalXP;
			int num3 = record.GetSummedXP() - totalXP;
			stringBuilder.AppendLine("[XP - " + num3 + "] +" + num3 + " * " + instance.XPMultiplier + " = " + (float)num3 * instance.XPMultiplier);
			stringBuilder.AppendFormat("Promotion = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.PromotionsReceived, instance.PromotionsMultiplier, (float)record.CurrentRecord.PromotionsReceived * instance.PromotionsMultiplier);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Training Completed = {0}\n{0} * {1} = {2}\n", record.CurrentRecord.QualificationsReceived, instance.QualificationsMultiplier, (float)record.CurrentRecord.QualificationsReceived * instance.QualificationsMultiplier);
			stringBuilder.AppendLine("===================================");
			stringBuilder.AppendLine("Total: = " + (float)num3 * instance.XPMultiplier + (float)num * instance.PromotionsMultiplier + (float)num2 * instance.QualificationsMultiplier);
			return stringBuilder.ToString();
		}

		private string BuildHospitalRecordScore(HospitalAwardsManager.AwardType awardType)
		{
			return awardType switch
			{
				HospitalAwardsManager.AwardType.EmployerOfTheYear => BuildEmployerOfTheYearScore(), 
				HospitalAwardsManager.AwardType.MostPrestigious => BuildMostPrestigiousScore(), 
				HospitalAwardsManager.AwardType.TeachingHospitalOfTheYear => BuildTeachingHospitalScore(), 
				HospitalAwardsManager.AwardType.ResearchHospitalOfTheYear => BuildResearchHospitalScore(), 
				HospitalAwardsManager.AwardType.PatientsChoice => BuildPatientsChoiceScore(), 
				HospitalAwardsManager.AwardType.NoDeaths => BuildNoDeathScore(), 
				HospitalAwardsManager.AwardType.HospitalOfTheYear => BuildHospitalOfTheYearScore(), 
				_ => "No Record.", 
			};
		}

		private string BuildEmployerOfTheYearScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			stringBuilder.AppendFormat("[Staff Reputation - {0:n3}] {0:n3} * {1:n3} = {2:n3}\n", _level.ReputationTracker.StaffReputation, instance.StaffReputationMultiplier, _level.ReputationTracker.StaffReputation * instance.StaffReputationMultiplier);
			stringBuilder.AppendFormat("[Hospital Reputation - {0:n3}] {0:n3} * {1:n3} = {2:n3}\n", _level.ReputationTracker.OverallReputation, instance.OverallReputationMultiplier, _level.ReputationTracker.StaffReputation * instance.OverallReputationMultiplier);
			stringBuilder.AppendLine();
			float num = 0f;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				num += staffMember.StaffRecord.CurrentRecord.GetAverageHappiness();
				int promotionsReceived = staffMember.StaffRecord.CurrentRecord.PromotionsReceived;
				stringBuilder.AppendFormat("[Staff Promotion - {0}] {0} * {1} = {2:n3}\n", promotionsReceived, instance.EoyPromotionsMultiplier, (float)promotionsReceived * instance.EoyPromotionsMultiplier);
				int qualificationsReceived = staffMember.StaffRecord.CurrentRecord.QualificationsReceived;
				stringBuilder.AppendFormat("[Staff Qualification - {0}] {0} * {1} = {2:n3}\n", qualificationsReceived, instance.EoyQualificationsMultiplier, (float)qualificationsReceived * instance.EoyQualificationsMultiplier);
				float num2 = staffMember.GetSalary() - staffMember.GetDesiredSalary();
				stringBuilder.AppendFormat("[Staff Salary - {0}] {0} * {1} = {2:n3}\n", num2, instance.SalaryMultiplier, num2 * instance.SalaryMultiplier);
				float num3 = (float)promotionsReceived * instance.EoyPromotionsMultiplier + (float)qualificationsReceived * instance.EoyQualificationsMultiplier + num2 * instance.SalaryMultiplier;
				stringBuilder.AppendLine("===================================");
				stringBuilder.AppendLine("Total: " + staffMember.NameWithTitle + " = " + num3);
			}
			if (_level.CharacterManager.StaffMembers.Count > 0)
			{
				float num4 = num / (float)_level.CharacterManager.StaffMembers.Count;
				stringBuilder.AppendFormat("[Staff Happiness (average) - {0:n3}] {0:n3} * {1:n3} = {2:n3}", num4, instance.StaffHappinessMultiplier, num4 * instance.StaffHappinessMultiplier);
			}
			return stringBuilder.ToString();
		}

		private string BuildMostPrestigiousScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			float num = GameAlgorithms.CalculateAverageRoomPrestige(_level);
			int environmentRating = _level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness);
			float num2 = GameAlgorithms.CalculateHygieneEnvironmentRating(_level);
			int num3 = GameAlgorithms.CalculateEnvironmentThermalComfort(_level);
			float num4 = num * instance.RoomPrestigeMultiplier + (float)environmentRating * instance.AttractivenessMultiplier + num2 * instance.HygieneMultiplier + (float)num3 * instance.TemperatureMultiplier;
			stringBuilder.AppendFormat("[Prestige - {0}] {0} * {1} = {2:n3}\n", num, instance.RoomPrestigeMultiplier, num * instance.RoomPrestigeMultiplier);
			stringBuilder.AppendFormat("[Attractiveness Rating - {0}] {0} * {1} = {2:n3}\n", environmentRating, instance.AttractivenessMultiplier, (float)environmentRating * instance.AttractivenessMultiplier);
			stringBuilder.AppendFormat("[Hygiene Rating - {0}] {0} * {1} = {2:n3}\n", num2, instance.HygieneMultiplier, num2 * instance.HygieneMultiplier);
			stringBuilder.AppendFormat("[Thermal Comfort - {0}] {0} * {1} = {2:n3}\n", num3, instance.TemperatureMultiplier, (float)num3 * instance.TemperatureMultiplier);
			stringBuilder.AppendLine("======================================");
			stringBuilder.AppendFormat("Total = {0:n3}", num4);
			return stringBuilder.ToString();
		}

		private string BuildTeachingHospitalScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				int qualificationsReceived = staffMember.StaffRecord.CurrentRecord.QualificationsReceived;
				stringBuilder.AppendFormat("[Staff Qualification - {0}] = {0:n3}\n", qualificationsReceived);
			}
			return stringBuilder.ToString();
		}

		private string BuildResearchHospitalScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			stringBuilder.AppendFormat("[Projects Completed - {0:n3}] {0:n3} * {1:n3} = {2:n3}\n", _awardsManager.ResearchProjectsCompletedThisYear, instance.TotalResearchProjectsMultiplier, (float)_awardsManager.ResearchProjectsCompletedThisYear * instance.TotalResearchProjectsMultiplier);
			stringBuilder.AppendFormat("[Research Points Earned - {0:n3}] {0:n3} * {1:n3} = {2:n3}\n", _awardsManager.ResearchPointsGeneratedThisYear, instance.TotalReseachPointsMultiplier, _awardsManager.ResearchPointsGeneratedThisYear * instance.TotalReseachPointsMultiplier);
			stringBuilder.AppendLine("======================================");
			stringBuilder.AppendFormat("Total = {0:n3}", (float)_awardsManager.ResearchProjectsCompletedThisYear * instance.TotalResearchProjectsMultiplier + _awardsManager.ResearchPointsGeneratedThisYear * instance.TotalReseachPointsMultiplier);
			return stringBuilder.ToString();
		}

		private string BuildPatientsChoiceScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HospitalAwardsManager.AwardsScoreSheet instance = _awardsManager.AwardsConfig.ScoreSheet.Instance;
			int num = 0;
			int num2 = 0;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				num += staffMember.StaffRecord.CurrentRecord.PatientsCured;
				num2 += staffMember.StaffRecord.CurrentRecord.PatientsIneffectivelyTreated + staffMember.StaffRecord.CurrentRecord.PatientsKilled;
			}
			stringBuilder.AppendFormat("[Patient Cures - {0}] = +{0} * {1} = {2:n3}\n", num, instance.TotalTreatmentsMultiplier, (float)num * instance.TotalTreatmentsMultiplier);
			stringBuilder.AppendFormat("[Patient Cure Fails - {0}] = -{0} * {1} = {2:n3}\n", num2, instance.TotalTreatmentsMultiplier, (float)(-num2) * instance.TotalTreatmentsMultiplier);
			return stringBuilder.ToString();
		}

		private string BuildNoDeathScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				num += staffMember.StaffRecord.CurrentRecord.PatientsKilled;
			}
			for (int i = 0; i < num; i++)
			{
				stringBuilder.AppendLine("[Patient Death] = -1");
			}
			return stringBuilder.ToString();
		}

		private string BuildHospitalOfTheYearScore()
		{
			StringBuilder stringBuilder = new StringBuilder();
			_awardsManager.CalculatePendingAwards(useLastYearsRecords: false);
			foreach (KeyValuePair<HospitalAwardsManager.AwardType, CharacterName> pendingAward in _awardsManager.PendingAwards)
			{
				stringBuilder.AppendFormat("[Award, {0}] = +1\n", pendingAward.Key);
			}
			return stringBuilder.ToString();
		}
	}
}
