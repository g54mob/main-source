#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Text;
using I2.Loc;

namespace TH20
{
	public static class GameStringUtils
	{
		public static string GetTrainingCourseDaysRemainingString(QualificationDefinition course, Staff trainer, List<Staff> trainees, Room room)
		{
			if (course == null || trainer == null || trainees.Count == 0 || room == null)
			{
				return ScriptLocalization.Menu_Training.TrainingCourseDaysRemainingUnknown_CS;
			}
			float num = float.MaxValue;
			float num2 = 0f;
			foreach (Staff trainee in trainees)
			{
				QualificationSlot qualificationSlot = trainee.GetQualificationSlot(course);
				float num3 = ((qualificationSlot == null) ? course.TrainingPoints : (course.TrainingPoints - qualificationSlot.TrainingPoints));
				float num4 = GameAlgorithms.CalculateTrainingPointLearnRate(trainer, trainee, trainees.Count, room);
				if (num4 > 0f)
				{
					float num5 = num3 / num4;
					if (num5 < num)
					{
						num = num5;
					}
					if (num5 > num2)
					{
						num2 = num5;
					}
				}
			}
			num /= GameAlgorithms.Config.SecondsPerDay;
			num2 /= GameAlgorithms.Config.SecondsPerDay;
			if (num > 0f && num < 1f)
			{
				num = 1f;
			}
			if (num2 > 0f && num2 < 1f)
			{
				num2 = 1f;
			}
			if ((int)num == (int)num2)
			{
				string text = ScriptLocalization.Menu_Training.TrainingCourseDaysRemaining_CS;
				LocalisationParams.Set("DAYS", (int)num);
				LocalisationParams.Localise(ref text);
				return text;
			}
			string text2 = ScriptLocalization.Menu_Training.TrainingCourseDaysRemaining_Range_CS;
			LocalisationParams.Set("MIN", (int)num);
			LocalisationParams.Set("MAX", (int)num2);
			LocalisationParams.Localise(ref text2);
			return text2;
		}

		public static string StaffTitle(Staff staff)
		{
			if (staff is GuestTrainer)
			{
				string arg = ((staff.Gender == Character.Sex.Male) ? ScriptLocalization.Menu_Training.GuestTrainer_Name_M_CS : ScriptLocalization.Menu_Training.GuestTrainer_Name_F_CS);
				return $"{staff.NameWithTitle} ({arg})";
			}
			return string.Format("{0} ({1})", staff.NameWithTitle, (staff.RankDefinition != null) ? staff.RankDefinition.GetTitleLocalised(staff.Gender).Translation : "");
		}

		public static string GetGuestTrainerCostText(GuestTrainer staff, GuestTrainerDefinition.Skill skill)
		{
			string newValue = StringUtils.FormatCurrency(skill.GetUpfrontCost(staff.Level));
			string newValue2 = StringUtils.FormatCurrency(skill.GetCostPerTrainee(staff.Level));
			return (staff.Level.FinanceManager.CanAfford(skill.GetUpfrontCost(staff.Level)) ? ScriptLocalization.Menu_Training.GuestTrainerCost_CS : ScriptLocalization.Menu_Training.GuestTrainerCostCannotAfford_CS).Replace("{[UPFRONTCOST]}", newValue).Replace("{[TRAININGCOST]}", newValue2);
		}

		public static string GetJobDescriptionString(JobMaintenance.JobDescription description)
		{
			return description switch
			{
				JobMaintenance.JobDescription.None => string.Empty, 
				JobMaintenance.JobDescription.BrokenMachine => ScriptLocalization.Staff.JobDescription_BrokenMachine_CS, 
				JobMaintenance.JobDescription.BlockedToilet => ScriptLocalization.Staff.JobDescription_BlockedToilet_CS, 
				JobMaintenance.JobDescription.OutOfStock => ScriptLocalization.Staff.JobDescription_OutOfStock_CS, 
				JobMaintenance.JobDescription.WiltedPlant => ScriptLocalization.Staff.JobDescription_WiltedPlant_CS, 
				JobMaintenance.JobDescription.Litter => ScriptLocalization.Staff.JobDescription_Litter_CS, 
				JobMaintenance.JobDescription.MedicalWaste => ScriptLocalization.Staff.JobDescription_MedicalWaste_CS, 
				JobMaintenance.JobDescription.Vehicular => ScriptLocalization.Staff.JobDescription_BrokenMachine_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static string GetJobActionString(JobMaintenance.JobDescription description)
		{
			return description switch
			{
				JobMaintenance.JobDescription.None => string.Empty, 
				JobMaintenance.JobDescription.BrokenMachine => ScriptLocalization.Staff.JobAction_BrokenMachine_CS, 
				JobMaintenance.JobDescription.BlockedToilet => ScriptLocalization.Staff.JobAction_BlockedToilet_CS, 
				JobMaintenance.JobDescription.OutOfStock => ScriptLocalization.Staff.JobAction_OutOfStock_CS, 
				JobMaintenance.JobDescription.WiltedPlant => ScriptLocalization.Staff.JobAction_WiltedPlant_CS, 
				JobMaintenance.JobDescription.Litter => ScriptLocalization.Staff.JobAction_Litter_CS, 
				JobMaintenance.JobDescription.MedicalWaste => ScriptLocalization.Staff.JobAction_MedicalWaste_CS, 
				JobMaintenance.JobDescription.Vehicular => ScriptLocalization.Staff.JobAction_BrokenMachine_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private static string GetDoctorNurseRecordText(StaffRecord record, Character.Sex gender)
		{
			int value = record.TotalPatientsCured + record.TotalPatientsIneffectivelyTreated + record.TotalPatientsKilled + record.TotalDiagnosisContributionsMade;
			int totalPatientsCured = record.TotalPatientsCured;
			int totalPatientsKilled = record.TotalPatientsKilled;
			int totalEarned = record.TotalEarned;
			int totalPaid = record.TotalPaid;
			string text = ((gender == Character.Sex.Male) ? ScriptLocalization.Staff_RecordText.DoctorNurse_CS : ScriptLocalization.Staff_RecordText.DoctorNurse_F_CS);
			LocalisationParams.Set("PATIENTS", value);
			LocalisationParams.Set("KILLED", totalPatientsKilled);
			LocalisationParams.Set("CURED", totalPatientsCured);
			LocalisationParams.Set("EARNED", StringUtils.FormatCurrency(totalEarned));
			LocalisationParams.Set("PAID", StringUtils.FormatCurrency(totalPaid));
			LocalisationParams.Localise(ref text);
			return text;
		}

		private static string GetJanitorRecordText(StaffRecord record, Character.Sex gender)
		{
			int value = record.TotalBrokenMachinesFixed + record.TotalVendingMachinesStocked + record.TotalLitterCollected + record.TotalGhostsCaptured + record.TotalMedicalWasteCleaned + record.TotalPlantsWatered + record.TotalToiletsUnblocked;
			int totalPaid = record.TotalPaid;
			string text = ((gender == Character.Sex.Male) ? ScriptLocalization.Staff_RecordText.Janitor_CS : ScriptLocalization.Staff_RecordText.Janitor_F_CS);
			LocalisationParams.Set("JOBS", value);
			LocalisationParams.Set("PAID", StringUtils.FormatCurrency(totalPaid));
			LocalisationParams.Localise(ref text);
			return text;
		}

		private static string GetAssistantRecordText(StaffRecord record, Character.Sex gender)
		{
			int value = record.TotalCustomersServedAtKiosk + record.TotalCustomersCheckedIn + record.TotalMarketingCampaigns;
			int totalPaid = record.TotalPaid;
			string text = ((gender == Character.Sex.Male) ? ScriptLocalization.Staff_RecordText.Assistant_CS : ScriptLocalization.Staff_RecordText.Assistant_F_CS);
			LocalisationParams.Set("PEOPLE", value);
			LocalisationParams.Set("PAID", StringUtils.FormatCurrency(totalPaid));
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string GetStaffRecordText(Staff staff)
		{
			double num = staff.TotalTimeInHospital / (double)GameAlgorithms.Config.SecondsPerDay * 86400.0;
			string text = ((staff.Gender == Character.Sex.Male) ? ScriptLocalization.Staff_RecordText.EmployedTime_CS : ScriptLocalization.Staff_RecordText.EmployedTime_F_CS);
			text = text.Replace("{[TIME]}", StringUtils.FormatTimeSpanDaysMonthsYears((uint)num));
			text += "\n";
			switch (staff.Definition._type)
			{
			case StaffDefinition.Type.Doctor:
			case StaffDefinition.Type.Nurse:
				text += GetDoctorNurseRecordText(staff.StaffRecord, staff.Gender);
				break;
			case StaffDefinition.Type.Assistant:
				text += GetAssistantRecordText(staff.StaffRecord, staff.Gender);
				break;
			case StaffDefinition.Type.Janitor:
				text += GetJanitorRecordText(staff.StaffRecord, staff.Gender);
				break;
			}
			return text;
		}

		public static string GetStaffTypeTextLocTerm(StaffDefinition.Type type)
		{
			return type switch
			{
				StaffDefinition.Type.Doctor => "Menu/Ribbon Menu/RibbonMenu_RequiredDoctor_CS", 
				StaffDefinition.Type.Nurse => "Menu/Ribbon Menu/RibbonMenu_RequiredNurse_CS", 
				StaffDefinition.Type.Assistant => "Menu/Ribbon Menu/RibbonMenu_RequiredAssistant_CS", 
				StaffDefinition.Type.Janitor => "Menu/Ribbon Menu/RibbonMenu_RequiredJanitor_CS", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static string GetStaffTypeTextLoc(StaffDefinition.Type type)
		{
			return LocalizationManager.GetTranslation(GetStaffTypeTextLocTerm(type));
		}

		public static string GetRequiredStaffText(List<StaffRequired> requiredStaff, string delimiter = ", ")
		{
			string text = ((requiredStaff.Count != 0) ? ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredStaff_Title_CS : string.Empty);
			for (int i = 0; i < requiredStaff.Count; i++)
			{
				StaffRequired staffRequired = requiredStaff[i];
				string text2 = ((staffRequired.QualificationInstance != null) ? (staffRequired.Definition._type switch
				{
					StaffDefinition.Type.Doctor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredDoctor_Qualification_CS, 
					StaffDefinition.Type.Nurse => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredNurse_Qualification_CS, 
					StaffDefinition.Type.Assistant => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredAssistant_Qualification_CS, 
					StaffDefinition.Type.Janitor => ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_RequiredJanitor_Qualification_CS, 
					_ => throw new ArgumentOutOfRangeException(), 
				}).Replace("{[QUALIFICATION]}", staffRequired.QualificationInstance.NameLocalised.Translation) : GetStaffTypeTextLoc(staffRequired.Definition._type));
				text = text + " " + text2;
				if (requiredStaff.Count != 1 && i < requiredStaff.Count - 1)
				{
					text += delimiter;
				}
			}
			return text;
		}

		public static string GetRoomCountText(GameplayStatsTracker gameplayStatsTracker, RoomDefinition definition)
		{
			int numberOfRooms = gameplayStatsTracker.GetNumberOfRooms(definition);
			string text = ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_Tooltip_RoomCount_CS;
			LocalisationParams.Set("COUNT", numberOfRooms);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string GetRoomItemCountText(GameplayStatsTracker gameplayStatsTracker, IRoomItemDefinition definition)
		{
			int numberOfRoomItems = gameplayStatsTracker.GetNumberOfRoomItems(definition);
			string text = ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_Tooltip_ItemCount_CS;
			LocalisationParams.Set("COUNT", numberOfRoomItems);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string GetUnlockText(int cost, int totalSilver)
		{
			string text = ScriptLocalization.Menu_Ribbon_Menu.RibbonMenu_UnlockMessage_CS;
			LocalisationParams.Set("SILVER", StringUtils.FormatSilverCurrency(cost));
			LocalisationParams.Set("AVAILABLE", StringUtils.FormatSilverCurrency(totalSilver));
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string GetRoomItemJanitorText(RoomItem roomItem, QualificationDefinition qualification, out Staff staff)
		{
			staff = null;
			if (roomItem != null && roomItem.Level != null && roomItem.Level.StaffWorkScheduler != null)
			{
				staff = roomItem.Level.StaffWorkScheduler.FindStaffAssignedToJob(roomItem);
				if (staff != null)
				{
					return ScriptLocalization.Menu.Hover_RoomItem_JanitorAssigned_CS.Replace("{[STAFF]}", staff.NameWithTitle);
				}
				if (qualification != null)
				{
					return ScriptLocalization.Menu.Hover_RoomItem_JanitorQualificationRequired_CS.Replace("{[QUALIFICATION]}", qualification.NameLocalised.Translation);
				}
				if (roomItem.MaintenanceLevel != null && (roomItem.MaintenanceLevel.Value() > GameAlgorithms.Config.ItemMaintenanceThreshold || roomItem.GetComponent<RoomItemUpgradeComponent>() != null))
				{
					return ScriptLocalization.Menu.Hover_RoomItem_JanitorRequired_CS;
				}
			}
			return string.Empty;
		}

		public static string GetFriendOnlineChallengeStatusText(OnlinePlayerID friendOnlinePlayerId, bool isChallengeFinished, float playerScore, float rivalScore, bool challengedMe)
		{
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(friendOnlinePlayerId);
			string newValue = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
			if (playerInfo == null)
			{
				OnlinePlayerID onlinePlayerID = friendOnlinePlayerId;
				Logging.Warning("GetFriendOnlineChallengeStatusText playerInfo was null, because the issuing player: " + onlinePlayerID.ToString() + " is not in our friends list");
			}
			if (!isChallengeFinished)
			{
				if (challengedMe)
				{
					return ScriptLocalization.Online.OnlineFriendChallengedYou_CS.Replace("{[FRIEND_NAME]}", newValue);
				}
				return ScriptLocalization.Online.OnlineFriendStartedTheChallenged_CS.Replace("{[FRIEND_NAME]}", newValue);
			}
			if (playerScore > 0f)
			{
				if (rivalScore > playerScore)
				{
					return ScriptLocalization.Online.OnlineFriendChallengedAndBeat_CS.Replace("{[FRIEND_NAME]}", newValue);
				}
				if (rivalScore < playerScore)
				{
					return ScriptLocalization.Online.OnlineFriendChallengedAndDidntBeat_CS.Replace("{[FRIEND_NAME]}", newValue);
				}
				return ScriptLocalization.Online.OnlineFriendDrewWithYourScore_CS.Replace("{[FRIEND_NAME]}", newValue);
			}
			return ScriptLocalization.Online.OnlineFriendFinishedTheChallenged_CS.Replace("{[FRIEND_NAME]}", newValue);
		}

		public static string GetRoomModifiersTooltipText(RoomModifier[] roomModifiers, string delimiter = "\n")
		{
			List<string> list = new List<string>();
			for (int i = 0; i < roomModifiers.Length; i++)
			{
				string text = roomModifiers[i].Description();
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < list.Count; j++)
			{
				string value = list[j];
				stringBuilder.Append(value);
				if (j < list.Count - 1)
				{
					stringBuilder.Append(delimiter);
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetTemperatureDescription(float temperatureValue)
		{
			if (temperatureValue > 0.4f)
			{
				return ScriptLocalization.Inspector.Stat_Temp_TooHot_CS;
			}
			if (temperatureValue > -0.4f)
			{
				return ScriptLocalization.Inspector.Stat_Temp_Comfortable_CS;
			}
			return ScriptLocalization.Inspector.Stat_Temp_TooCold_CS;
		}

		public static string MakeStringFromList(List<string> list, string delimiter = ", ")
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				if (i == list.Count - 1)
				{
					stringBuilder.Append(list[i]);
				}
				else
				{
					stringBuilder.AppendFormat("{0}{1}", list[i], delimiter);
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetStaffRankTooltip(Staff staff)
		{
			if (staff == null || staff.RankDefinition == null)
			{
				return string.Empty;
			}
			bool num = staff.XP.Value() >= staff.RankDefinition.MaximumXP;
			bool flag = num && staff.HasFreeTrainingSlots;
			bool flag2 = num && !staff.HasFreeTrainingSlots && staff.Rank < 4;
			return $"<b>{staff.RankDefinition.GetTitleLocalised(staff.Gender).Translation}</b>\n{ScriptLocalization.Inspector.Staff_CurrentExpInRank_CS} {staff.XP.Value():N0}/{staff.RankDefinition.MaximumXP}\n{(flag2 ? ScriptLocalization.Inspector.Staff_ReadyForPromotion_CS : (flag ? ScriptLocalization.Inspector.Staff_TrainingRequiredToPromote_CS : string.Empty))}";
		}

		public static string GetStaffPaySatisfaction(Staff staff, int desiredSalary)
		{
			if (staff == null)
			{
				return string.Empty;
			}
			return GameAlgorithms.CalculatePaySatisfactionLevel(staff.GetDesiredSalaryDifference(desiredSalary)) switch
			{
				StaffDefinition.Satisfaction.VeryUnhappy => ScriptLocalization.Staff.Pay_VeryUnhappy_CS, 
				StaffDefinition.Satisfaction.Unhappy => ScriptLocalization.Staff.Pay_Unhappy_CS, 
				StaffDefinition.Satisfaction.Satisfied => ScriptLocalization.Staff.Pay_Satisfied_CS, 
				StaffDefinition.Satisfaction.Happy => ScriptLocalization.Staff.Pay_Happy_CS, 
				StaffDefinition.Satisfaction.VeryHappy => ScriptLocalization.Staff.Pay_VeryHappy_CS, 
				_ => string.Empty, 
			};
		}

		public static string GetDaysString(int numberOfDays)
		{
			string text = ScriptLocalization.Misc.Days_CS;
			LocalisationParams.Set("DAYS", numberOfDays);
			return LocalisationParams.Localise(ref text);
		}

		public static string GetEmergencyTimeLeftString(int timeLeft)
		{
			string text = ScriptLocalization.Menu_EmergencyDetails.Emergency_TimeLeft;
			LocalisationParams.Set("DURATION", timeLeft);
			return LocalisationParams.Localise(ref text);
		}

		public static string GetEmergencyDistanceString(float distance)
		{
			string text = ScriptLocalization.Menu_EmergencyDetails.Emergency_Distance;
			LocalisationParams.Set("DISTANCE", distance);
			return LocalisationParams.Localise(ref text);
		}

		public static string GetHospitalAgeString(int dateMonth, int dateYear)
		{
			int num = dateMonth;
			if (dateYear == 0 && num == 0)
			{
				num = 1;
			}
			string newValue = string.Empty;
			string newValue2 = string.Empty;
			if (num > 0)
			{
				newValue = LocalisedString.GetTranslationPlural("Menu/SelectedHospital/HospitalAgeMonths_CS", num);
				newValue = newValue.Replace("{[MONTHS]}", StringUtils.FormatNumber(num));
			}
			if (dateYear > 0)
			{
				newValue2 = LocalisedString.GetTranslationPlural("Menu/SelectedHospital/HospitalAgeYears_CS", dateYear);
				newValue2 = newValue2.Replace("{[YEARS]}", StringUtils.FormatNumber(dateYear));
			}
			string hospitalAgeDisplayYearsAndMonths_CS;
			if (dateYear > 0)
			{
				if (num > 0)
				{
					hospitalAgeDisplayYearsAndMonths_CS = ScriptLocalization.Menu_SelectedHospital.HospitalAgeDisplayYearsAndMonths_CS;
					hospitalAgeDisplayYearsAndMonths_CS = hospitalAgeDisplayYearsAndMonths_CS.Replace("{[YEARS_STRING]}", newValue2);
					return hospitalAgeDisplayYearsAndMonths_CS.Replace("{[MONTHS_STRING]}", newValue);
				}
				hospitalAgeDisplayYearsAndMonths_CS = ScriptLocalization.Menu_SelectedHospital.HospitalAgeDisplayYearsOnly_CS;
				return hospitalAgeDisplayYearsAndMonths_CS.Replace("{[YEARS_STRING]}", newValue2);
			}
			hospitalAgeDisplayYearsAndMonths_CS = ScriptLocalization.Menu_SelectedHospital.HospitalAgeDisplayMonthsOnly_CS;
			return hospitalAgeDisplayYearsAndMonths_CS.Replace("{[MONTHS_STRING]}", newValue);
		}

		public static string GetDlcRequiredString(DLCItemDefinition dlcItemDefinition)
		{
			if (dlcItemDefinition == null)
			{
				return string.Empty;
			}
			return string.Format(ScriptLocalization.Misc.RequiresDLC_CS, dlcItemDefinition.Name.Translation);
		}
	}
}
