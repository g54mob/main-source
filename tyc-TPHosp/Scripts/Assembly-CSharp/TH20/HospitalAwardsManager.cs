using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class HospitalAwardsManager : MustCallDestroy
	{
		public enum AwardType
		{
			DoctorOfTheYear = 0,
			NurseOfTheYear = 1,
			JanitorOfTheYear = 2,
			AssistantOfTheYear = 3,
			RisingStar = 4,
			EmployerOfTheYear = 5,
			MostPrestigious = 6,
			TeachingHospitalOfTheYear = 7,
			ResearchHospitalOfTheYear = 8,
			PatientsChoice = 9,
			NoDeaths = 10,
			HospitalOfTheYear = 11
		}

		public class SimpleAwardInfo
		{
			public bool Winner;

			public AwardType AwardType;

			public SimpleAwardInfo(AwardType type, bool hasWon)
			{
				AwardType = type;
				Winner = hasWon;
			}
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
		public class AwardInstanceData
		{
			[InspectorTooltip("If the score calculated is higher than this value, the award is won")]
			public float ScoreThreshold;

			public LocalisedString AwardNameLoc;

			public LocalisedString TooltipLoc;

			public Sprite TrophySprite;

			public Sprite TrophySpriteBG;

			[InspectorTooltip("{0} = Award Name, {1} = Staff Name, {2} = Hospital Name, {3} = Rewards")]
			public LocalisedString VictoryLetterLoc;

			public IReward[] HospitalRewards;

			[InspectorTooltip("Status effects applied to winning staff member")]
			public SharedInstance<CharacterStatusEffectDefinition>[] StaffStatusEffects;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
		public class Config
		{
			public SharedInstance<AwardsScoreSheet> ScoreSheet;

			[InspectorTooltip("The awards offered and the score threshold required to achieve it")]
			public Dictionary<AwardType, AwardInstanceData> AwardData;
		}

		public class AwardsWonData
		{
			public int AwardCount;

			public Staff LastWonByStaffMember;

			public string LastWonByStaffMemberName;

			public AwardsWonData(int inAwardCount, string inLastWonByStaffMemberName)
			{
				AwardCount = inAwardCount;
				LastWonByStaffMemberName = inLastWonByStaffMemberName;
			}
		}

		private delegate float GetStaffScoreDelegate(Staff staff, bool useLastYearRecords);

		private delegate float GetHospitalScoreDelegate(bool useLastYearRecords);

		[DontSave]
		public class AwardsScoreSheet
		{
			[InspectorMargin(8)]
			[InspectorHeader("Doctor/Nurse of the Year")]
			[InspectorTooltip("Cures - Treatment Failures")]
			public float TreatmentMultiplier = 1f;

			[InspectorTooltip("Total points of diagnosis done")]
			public float DiagnosisMultiplier = 1f;

			[InspectorTooltip("Total points of research contributed")]
			public float ResearchMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Janitor of the Year")]
			public float MaintainedOutOfStock = 1f;

			public float MaintainedWiltedPlants = 1f;

			public float MaintainedMachineBroken = 1f;

			public float MaintainedLitter = 1f;

			public float MaintainedMedicalWaste = 1f;

			public float MaintainedBlockedToilet = 1f;

			public float GhostsCaptured = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Assistant of the Year")]
			[InspectorTooltip("Number of customers deal with (reception and kiosks)")]
			public float CustomersSeenMultiplier = 1f;

			[InspectorTooltip("TBD Marketing Value")]
			public float MarketingMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Rising Star")]
			[InspectorTooltip("XP gained this year")]
			public float XPMultiplier = 1f;

			[InspectorTooltip("Number of Promotions gained this year")]
			public float PromotionsMultiplier = 1f;

			[InspectorTooltip("Number of Qualifications gained this year")]
			public float QualificationsMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Employee of the Year")]
			[InspectorTooltip("Average Happiness over the year")]
			public float StaffHappinessMultiplier = 1f;

			[InspectorTooltip("Staff Reputation score at year end")]
			public float StaffReputationMultiplier = 1f;

			[InspectorTooltip("Overall Reputation at year end")]
			public float OverallReputationMultiplier = 1f;

			[InspectorTooltip("Number of Promotions gained this year")]
			public float EoyPromotionsMultiplier = 1f;

			[InspectorTooltip("Number of Qualifications gained this year")]
			public float EoyQualificationsMultiplier = 1f;

			[InspectorTooltip("Salary / Desired Salary")]
			public float SalaryMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Most Prestigious")]
			[InspectorTooltip("Average attractiveness of the hospital")]
			public float AttractivenessMultiplier = 1f;

			[InspectorTooltip("Average hygiene of the hospital")]
			public float HygieneMultiplier = 1f;

			[InspectorTooltip("Average distance-from-comfortable of the hospital. Perfect = 0")]
			public float TemperatureMultiplier = 1f;

			[InspectorTooltip("Average room prestige of the hospital")]
			public float RoomPrestigeMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Research Hospital of the Year")]
			[InspectorTooltip("Total research points accrued this year")]
			[FullInspector.InspectorName("Research Point Multiplier")]
			public float TotalReseachPointsMultiplier = 1f;

			[InspectorTooltip("Total research projects completed this year")]
			[FullInspector.InspectorName("Research Projects Multiplier")]
			public float TotalResearchProjectsMultiplier = 1f;

			[InspectorMargin(8)]
			[InspectorHeader("Patients' Choice")]
			[InspectorTooltip("Average Patient Reputation")]
			public float PatientReputationMultiplier = 1f;

			[InspectorTooltip("Cures - Treatments failures hospital-wide")]
			public float TotalTreatmentsMultiplier = 1f;
		}

		public static string[] AwardNames = new string[12]
		{
			"Doctor of the Year", "Nurse of the Year", "Janitor of the Year", "Assistant of the Year", "Rising Star Award", "Employer of the Year", "Most Prestigious Hospital", "Teaching Hospital of the Year", "Research Hospital of the Year", "Patients' Choice",
			"Bodybag Surplus Award", "Hospital of the Year"
		};

		private readonly Config _config;

		private Level _level;

		private readonly CharacterManager _characterManager;

		private readonly ReputationTracker _reputationTracker;

		private readonly ResearchManager _researchManager;

		private readonly string _hospitalName;

		[DontSave]
		private Dictionary<AwardType, GetStaffScoreDelegate> _getHighScoreStaffDelegates = new Dictionary<AwardType, GetStaffScoreDelegate>();

		[DontSave]
		private Dictionary<AwardType, GetHospitalScoreDelegate> _getHighScoreHospitalDelegates = new Dictionary<AwardType, GetHospitalScoreDelegate>();

		public readonly Dictionary<AwardType, CharacterName> PendingAwards = new Dictionary<AwardType, CharacterName>();

		private Dictionary<AwardType, AwardsWonData> AwardsWon;

		[DontSave]
		private Dictionary<AwardType, AwardsWonData> AwardsWonForTooltips;

		private int _researchProjectsCompletedThisYear;

		private float _researchPointsGeneratedThisYear;

		public Action<AwardType, AwardInstanceData, CharacterName> OnAwardWon;

		public int ResearchProjectsCompletedThisYear => _researchProjectsCompletedThisYear;

		public float ResearchPointsGeneratedThisYear => _researchPointsGeneratedThisYear;

		public Config AwardsConfig => _config;

		public HospitalAwardsManager(Level level, Config config)
		{
			_level = level;
			_config = config;
			_characterManager = level.CharacterManager;
			_reputationTracker = level.ReputationTracker;
			_researchManager = level.ResearchManager;
			_hospitalName = level.Config.GetLocalisedDisplayName();
			ResearchManager researchManager = _researchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			ResearchManager researchManager2 = _researchManager;
			researchManager2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			InitialiseDelegates();
			ConsoleCommandsDatabase.RegisterCommand("ShowAwardsDebugMenu", "Show the balancing menu for the level awards", "ShowAwardsDebugMenu", Debug_ShowAwardsDebugMenu);
			ResetAllCounters();
			AwardNames[0] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/DoctorAwards");
			AwardNames[1] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/NurseAward");
			AwardNames[2] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/JanitorAward");
			AwardNames[3] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/AssistantAward");
			AwardNames[4] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/RisingStar");
			AwardNames[5] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/EmployerAward");
			AwardNames[6] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/MostPrestigious");
			AwardNames[7] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/TrainerAward");
			AwardNames[8] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/ResearcherAward");
			AwardNames[9] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/PatientsChoice");
			AwardNames[10] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/NoDeaths");
			AwardNames[11] = LocalizationManager.GetTranslation("Menu/Overview Menu/Awards/HospitalAward");
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			ResearchManager researchManager = _researchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			ResearchManager researchManager2 = _researchManager;
			researchManager2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			InitialiseDelegates();
			ConsoleCommandsDatabase.RegisterCommand("ShowAwardsDebugMenu", "Show the balancing menu for the level awards", "ShowAwardsDebugMenu", Debug_ShowAwardsDebugMenu);
		}

		private void InitialiseDelegates()
		{
			_getHighScoreStaffDelegates = new Dictionary<AwardType, GetStaffScoreDelegate>();
			_getHighScoreStaffDelegates.Add(AwardType.DoctorOfTheYear, GetDoctorOfTheYearScore);
			_getHighScoreStaffDelegates.Add(AwardType.NurseOfTheYear, GetNurseOfTheYearScore);
			_getHighScoreStaffDelegates.Add(AwardType.JanitorOfTheYear, GetJanitorOfTheYearScore);
			_getHighScoreStaffDelegates.Add(AwardType.AssistantOfTheYear, GetAssistantOfTheYearScore);
			_getHighScoreStaffDelegates.Add(AwardType.RisingStar, GetRisingStarScore);
			_getHighScoreHospitalDelegates = new Dictionary<AwardType, GetHospitalScoreDelegate>();
			_getHighScoreHospitalDelegates.Add(AwardType.EmployerOfTheYear, GetEmployerOfTheYearScore);
			_getHighScoreHospitalDelegates.Add(AwardType.MostPrestigious, GetMostPrestigiousScore);
			_getHighScoreHospitalDelegates.Add(AwardType.TeachingHospitalOfTheYear, GetTeachingHospitalOfTheYearScore);
			_getHighScoreHospitalDelegates.Add(AwardType.ResearchHospitalOfTheYear, GetResearchHospitalOfTheYearScore);
			_getHighScoreHospitalDelegates.Add(AwardType.PatientsChoice, GetPatientsChoiceScore);
			_getHighScoreHospitalDelegates.Add(AwardType.NoDeaths, GetNoDeathsScore);
			_getHighScoreHospitalDelegates.Add(AwardType.HospitalOfTheYear, GetHospitalOfTheYearScore);
		}

		public override void Destroy()
		{
			ResearchManager researchManager = _researchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			ResearchManager researchManager2 = _researchManager;
			researchManager2.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(researchManager2.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			_getHighScoreStaffDelegates.Clear();
			_getHighScoreHospitalDelegates.Clear();
			ConsoleCommandsDatabase.UnRegisterCommand("ShowAwardsDebugMenu");
			_level.HUD.DestroyMenu<AwardsDebugMenu>();
			ActionExtension.VerifyCallValid = true;
			OnAwardWon.VerifyIsNull();
			ActionExtension.VerifyCallValid = false;
			_level = null;
			base.Destroy();
		}

		private void OnResearchProjectComplete(ResearchProject project)
		{
			_researchProjectsCompletedThisYear++;
		}

		private void OnResearchPointsAdded(float points, ResearchProject project)
		{
			_researchPointsGeneratedThisYear += points;
		}

		public string GetEventLogSuccesssText(AwardType type)
		{
			string newValue = "";
			if (_config.AwardData.ContainsKey(type))
			{
				AwardInstanceData awardInstanceData = _config.AwardData[type];
				if (awardInstanceData != null)
				{
					newValue = awardInstanceData.AwardNameLoc.Translation;
				}
			}
			return ScriptLocalization.Menu_Overview_Menu_EventLog.AwardWon_CS.Replace("{[AWARD_NAME]}", newValue);
		}

		public string RemoveTextColourMarkup(string inStr)
		{
			string text = inStr;
			int num = 0;
			int num2 = text.IndexOf("<color=", StringComparison.Ordinal);
			while (num2 >= 0 && num >= 0)
			{
				num = text.IndexOf(">", num2, text.Length - num2, StringComparison.Ordinal);
				if (num >= 0)
				{
					text = text.Remove(num2, num - num2 + 1);
				}
				num2 = text.IndexOf("<color=", StringComparison.Ordinal);
			}
			for (num2 = text.IndexOf("</color>", StringComparison.Ordinal); num2 >= 0; num2 = text.IndexOf("</color>", StringComparison.Ordinal))
			{
				text = text.Remove(num2, 8);
			}
			return text;
		}

		public string GetAwardTooltipText(AwardType awardType)
		{
			string text = "";
			if (_config.AwardData.ContainsKey(awardType))
			{
				AwardInstanceData awardInstanceData = _config.AwardData[awardType];
				if (awardInstanceData != null && awardInstanceData.AwardNameLoc.Term != null)
				{
					text = text + "<b>" + awardInstanceData.AwardNameLoc.Translation + "</b>";
					text += "\n";
					text += awardInstanceData.TooltipLoc.Translation;
					text += "\n";
					bool flag = false;
					CheckCreateAwardsWonForTooltips();
					if (AwardsWonForTooltips.TryGetValue(awardType, out var value) && value.AwardCount > 0)
					{
						flag = true;
						text += ScriptLocalization.Menu_Overview_Menu_Awards_Tooltips.NumTimesWon_CS.Replace("{[NUM_TIMES_WON]}", $"{value.AwardCount}");
						if (!value.LastWonByStaffMemberName.IsNullOrEmpty())
						{
							text += "\n";
							text += ScriptLocalization.Menu_Overview_Menu_Awards_Tooltips.LastWonBy_CS.Replace("{[STAFF_MEMBER_NAME]}", value.LastWonByStaffMemberName);
						}
					}
					if (!flag)
					{
						text += ScriptLocalization.Menu_Overview_Menu_Awards_Tooltips.NumTimesWon_CS.Replace("{[NUM_TIMES_WON]}", "0");
					}
				}
			}
			return text;
		}

		public string GetSuccessText(AwardType type)
		{
			if (!_config.AwardData.ContainsKey(type))
			{
				return ScriptLocalization.Menu_Overview_Menu_Awards_Announcer.Congratulations_CS;
			}
			string text = string.Empty;
			if (PendingAwards.ContainsKey(type))
			{
				text = PendingAwards[type].GetCharacterName();
			}
			AwardInstanceData awardInstanceData = _config.AwardData[type];
			return string.Format(awardInstanceData.VictoryLetterLoc.Translation, awardInstanceData.AwardNameLoc.Translation, text, _hospitalName, RewardUtils.GetFullRewardString(null, awardInstanceData.HospitalRewards)).Replace("\\n", "\n");
		}

		public void GetSuccessTextItems(AwardType awardType, string awardName, out string textUpperPage, out string textLowerPage)
		{
			textUpperPage = "";
			textLowerPage = "";
			bool flag = true;
			if (!ShouldUseDefaultAwardTypeTextItems(awardType))
			{
				AwardInstanceData awardInstanceData = _config.AwardData[awardType];
				string text = string.Empty;
				if (PendingAwards.ContainsKey(awardType))
				{
					text = PendingAwards[awardType].GetCharacterName();
				}
				string victoryLetterLoc = awardInstanceData.VictoryLetterLoc.Translation;
				bool num = IsIndividualStaffAwradType(awardType);
				PreProcessVictoryLetterLoc(ref victoryLetterLoc);
				string text2 = ((!num) ? _hospitalName : ((!text.IsNullOrEmpty()) ? text : _hospitalName));
				string organisationName = _level.OrganisationName;
				string text3 = string.Format(victoryLetterLoc, awardInstanceData.AwardNameLoc.Translation, text2, organisationName, RewardUtils.GetFullRewardString(null, awardInstanceData.HospitalRewards));
				text3 = text3.Replace("\\n", "\n");
				string text4 = "\n\n";
				int length = text4.Length;
				int num2 = text3.IndexOf(text4, StringComparison.OrdinalIgnoreCase);
				if (num2 >= 0)
				{
					textUpperPage = text3.Substring(0, num2);
					textLowerPage = text3.Substring(num2 + length);
					if (!textUpperPage.IsNullOrEmpty() && !textLowerPage.IsNullOrEmpty())
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				textUpperPage = awardName;
				textLowerPage = ScriptLocalization.Menu_Overview_Menu_Awards_Announcer.Congratulations_CS;
			}
			textUpperPage = RemoveTextColourMarkup(textUpperPage);
			textLowerPage = RemoveTextColourMarkup(textLowerPage);
		}

		public void GetSuccessTextItems2(AwardType awardType, string awardName, out string textUpperPage, out string textLowerPage, out string textLowerPage2)
		{
			GetSuccessTextItems(awardType, awardName, out textUpperPage, out textLowerPage);
			string value = "\n\n";
			int num = textLowerPage.IndexOf(value, StringComparison.OrdinalIgnoreCase);
			if (num >= 0)
			{
				textLowerPage = textLowerPage.Substring(0, num);
			}
			AwardInstanceData awardInstanceData = _config.AwardData[awardType];
			textLowerPage2 = RewardUtils.GetFullRewardString(null, awardInstanceData.HospitalRewards);
			textLowerPage2 = textLowerPage2.Replace("\\n", "\n");
			textLowerPage2 = textLowerPage2.Replace("\n", ", ");
			if (textLowerPage2.EndsWith(", "))
			{
				textLowerPage2 = textLowerPage2.Remove(textLowerPage2.Length - 2, 2);
			}
			textLowerPage2 = ScriptLocalization.Misc.Prize_CS + ScriptLocalization.Misc.ColonSeparator_CS + textLowerPage2;
		}

		public void GetNonSuccessTextItems(AwardType awardType, string awardName, string rivalHospitalName, out string textUpperPage, out string textLowerPage)
		{
			textUpperPage = "";
			textLowerPage = "";
			bool flag = true;
			if (!ShouldUseDefaultAwardTypeTextItems(awardType))
			{
				AwardInstanceData awardInstanceData = _config.AwardData[awardType];
				string translation = awardInstanceData.VictoryLetterLoc.Translation;
				translation = translation.Replace("\\n", "\n");
				string value = "\n\n";
				int num = translation.IndexOf(value, StringComparison.OrdinalIgnoreCase);
				if (num >= 0)
				{
					translation = translation.Substring(0, num);
					if (!translation.IsNullOrEmpty())
					{
						textUpperPage = string.Format(translation, awardInstanceData.AwardNameLoc.Translation);
						textLowerPage = rivalHospitalName;
						if (!textUpperPage.IsNullOrEmpty() && !textLowerPage.IsNullOrEmpty())
						{
							flag = false;
						}
					}
				}
			}
			if (flag)
			{
				textUpperPage = awardName;
				textLowerPage = rivalHospitalName;
			}
			textUpperPage = RemoveTextColourMarkup(textUpperPage);
			textLowerPage = RemoveTextColourMarkup(textLowerPage);
		}

		private void PreProcessVictoryLetterLoc(ref string victoryLetterLoc)
		{
			if (victoryLetterLoc.IndexOf("{1}", StringComparison.OrdinalIgnoreCase) < 0)
			{
				victoryLetterLoc = victoryLetterLoc.Replace("<color=#B87804><size=150%><b>{2}</b></size></color>", "<color=#B87804><size=150%><b>{1}</b></size>\n<alpha=#CF>{2}</color>");
			}
		}

		private bool IsIndividualStaffAwradType(AwardType awardType)
		{
			bool result = false;
			if ((uint)awardType <= 4u)
			{
				result = true;
			}
			return result;
		}

		private bool ShouldUseDefaultAwardTypeTextItems(AwardType awardType)
		{
			bool result = true;
			if (_config.AwardData.ContainsKey(awardType))
			{
				AwardInstanceData awardInstanceData = _config.AwardData[awardType];
				if (awardInstanceData != null && awardInstanceData.VictoryLetterLoc.Translation != null)
				{
					result = false;
				}
			}
			return result;
		}

		public void OnStartAwardsCeremony()
		{
			PendingAwards.Clear();
		}

		public void OnEndAwardsCeremony()
		{
			UpdateAllAwardsWonForTooltips();
			ResetAllCounters();
		}

		private void CheckCreateAwardsWonForTooltips()
		{
			if (AwardsWonForTooltips == null)
			{
				AwardsWonForTooltips = new Dictionary<AwardType, AwardsWonData>();
			}
		}

		public void UpdateAllAwardsWonForTooltips()
		{
			CheckCreateAwardsWonForTooltips();
			AwardsWonForTooltips.Clear();
			if (AwardsWon == null)
			{
				return;
			}
			foreach (KeyValuePair<AwardType, AwardsWonData> item in AwardsWon)
			{
				AwardsWonForTooltips.Add(item.Key, new AwardsWonData(item.Value.AwardCount, item.Value.LastWonByStaffMemberName));
			}
		}

		public void UpdateAwardWonForTooltips(AwardType awardType)
		{
			CheckCreateAwardsWonForTooltips();
			if (AwardsWonForTooltips.ContainsKey(awardType))
			{
				AwardsWonForTooltips.Remove(awardType);
			}
			if (AwardsWon != null && AwardsWon.TryGetValue(awardType, out var value))
			{
				AwardsWonForTooltips.Add(awardType, new AwardsWonData(value.AwardCount, value.LastWonByStaffMemberName));
			}
		}

		public void AddPendingAwardStaffWinner(AwardType awardType, Staff staffWinner)
		{
			PendingAwards.Add(awardType, staffWinner?.CharacterName ?? CharacterName.Empty);
		}

		public void CalculatePendingAwards(bool useLastYearsRecords)
		{
			PendingAwards.Clear();
			foreach (KeyValuePair<AwardType, AwardInstanceData> awardDatum in _config.AwardData)
			{
				if (DidWinAward(awardDatum.Key, out var highestScorer, useLastYearsRecords))
				{
					AddPendingAwardStaffWinner(awardDatum.Key, highestScorer);
				}
			}
		}

		public void GiveReward(AwardType awardType)
		{
			if (!_config.AwardData.ContainsKey(awardType))
			{
				return;
			}
			AwardInstanceData awardInstanceData = _config.AwardData[awardType];
			RewardUtils.GiveAllRewards(null, awardInstanceData.HospitalRewards, _level.Metagame);
			CharacterName characterName = (PendingAwards.ContainsKey(awardType) ? PendingAwards[awardType] : CharacterName.Empty);
			OnAwardWon.InvokeSafe(awardType, awardInstanceData, characterName);
			if (awardInstanceData.StaffStatusEffects == null || characterName == CharacterName.Empty)
			{
				return;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (!(staffMember.CharacterName == characterName))
				{
					continue;
				}
				SharedInstance<CharacterStatusEffectDefinition>[] staffStatusEffects = awardInstanceData.StaffStatusEffects;
				foreach (SharedInstance<CharacterStatusEffectDefinition> sharedInstance in staffStatusEffects)
				{
					if (sharedInstance.Instance != null && staffMember.ModifiersComponent != null)
					{
						staffMember.ModifiersComponent.AddStatusEffect(sharedInstance.Instance);
					}
				}
				break;
			}
		}

		public bool DidWinAward(AwardType awardType, out Staff highestScorer, bool useLastYearsRecords)
		{
			highestScorer = null;
			if (_getHighScoreStaffDelegates.TryGetValue(awardType, out var value))
			{
				float num = float.MinValue;
				foreach (Staff staffMember in _characterManager.StaffMembers)
				{
					float num2 = value(staffMember, useLastYearsRecords);
					if (!(num2 < num))
					{
						num = num2;
						highestScorer = staffMember;
					}
				}
				return num >= _config.AwardData[awardType].ScoreThreshold;
			}
			if (_getHighScoreHospitalDelegates.TryGetValue(awardType, out var value2))
			{
				return value2(useLastYearsRecords) >= _config.AwardData[awardType].ScoreThreshold;
			}
			return false;
		}

		public float GetDoctorOfTheYearScore(Staff staff, bool useLastYearRecords)
		{
			if (staff.Definition._type != StaffDefinition.Type.Doctor)
			{
				return float.MinValue;
			}
			StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staff.StaffRecord.LastYearRecord : staff.StaffRecord.CurrentRecord);
			if (yearlyRecord == null)
			{
				return float.MinValue;
			}
			int patientsCured = yearlyRecord.PatientsCured;
			int num = yearlyRecord.PatientsIneffectivelyTreated + yearlyRecord.PatientsKilled;
			float num2 = (float)(patientsCured - num) * _config.ScoreSheet.Instance.TreatmentMultiplier;
			float num3 = yearlyRecord.DiagnosisContribution * _config.ScoreSheet.Instance.DiagnosisMultiplier;
			float num4 = yearlyRecord.ResearchContributed * _config.ScoreSheet.Instance.ResearchMultiplier;
			return num2 + num3 + num4;
		}

		public float GetNurseOfTheYearScore(Staff staff, bool useLastYearRecords)
		{
			if (staff.Definition._type != StaffDefinition.Type.Nurse)
			{
				return float.MinValue;
			}
			StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staff.StaffRecord.LastYearRecord : staff.StaffRecord.CurrentRecord);
			if (yearlyRecord == null)
			{
				return float.MinValue;
			}
			int patientsCured = yearlyRecord.PatientsCured;
			int num = yearlyRecord.PatientsIneffectivelyTreated + yearlyRecord.PatientsKilled;
			float num2 = (float)(patientsCured - num) * _config.ScoreSheet.Instance.TreatmentMultiplier;
			float num3 = yearlyRecord.DiagnosisContribution * _config.ScoreSheet.Instance.DiagnosisMultiplier;
			float num4 = yearlyRecord.ResearchContributed * _config.ScoreSheet.Instance.ResearchMultiplier;
			return num2 + num3 + num4;
		}

		public float GetJanitorOfTheYearScore(Staff staff, bool useLastYearRecords)
		{
			if (staff.Definition._type != StaffDefinition.Type.Janitor)
			{
				return float.MinValue;
			}
			StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staff.StaffRecord.LastYearRecord : staff.StaffRecord.CurrentRecord);
			if (yearlyRecord == null)
			{
				return float.MinValue;
			}
			return (float)yearlyRecord.ToiletsUnblocked * _config.ScoreSheet.Instance.MaintainedBlockedToilet + (float)yearlyRecord.BrokenMachinesFixed * _config.ScoreSheet.Instance.MaintainedMachineBroken + (float)yearlyRecord.LitterCollected * _config.ScoreSheet.Instance.MaintainedLitter + (float)yearlyRecord.MedicalWasteCleaned * _config.ScoreSheet.Instance.MaintainedMedicalWaste + (float)yearlyRecord.VendingMachinesStocked * _config.ScoreSheet.Instance.MaintainedOutOfStock + (float)yearlyRecord.PlantsWatered * _config.ScoreSheet.Instance.MaintainedWiltedPlants + (float)yearlyRecord.GhostsCaptured * _config.ScoreSheet.Instance.GhostsCaptured;
		}

		public float GetAssistantOfTheYearScore(Staff staff, bool useLastYearRecords)
		{
			if (staff.Definition._type != StaffDefinition.Type.Assistant)
			{
				return float.MinValue;
			}
			StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staff.StaffRecord.LastYearRecord : staff.StaffRecord.CurrentRecord);
			if (yearlyRecord == null)
			{
				return float.MinValue;
			}
			return (float)(yearlyRecord.CustomersServedAtKiosk + yearlyRecord.CustomersCheckedIn) * _config.ScoreSheet.Instance.CustomersSeenMultiplier;
		}

		public float GetRisingStarScore(Staff staff, bool useLastYearRecords)
		{
			StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staff.StaffRecord.LastYearRecord : staff.StaffRecord.CurrentRecord);
			if (yearlyRecord == null)
			{
				return float.MinValue;
			}
			float num = (float)yearlyRecord.XP * _config.ScoreSheet.Instance.XPMultiplier;
			float num2 = (float)yearlyRecord.PromotionsReceived * _config.ScoreSheet.Instance.PromotionsMultiplier;
			float num3 = (float)yearlyRecord.QualificationsReceived * _config.ScoreSheet.Instance.QualificationsMultiplier;
			return num + num2 + num3;
		}

		public float GetEmployerOfTheYearScore(bool useLastYearRecords)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			foreach (Staff staffMember in _characterManager.StaffMembers)
			{
				StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staffMember.StaffRecord.LastYearRecord : staffMember.StaffRecord.CurrentRecord);
				if (yearlyRecord != null)
				{
					num += yearlyRecord.GetAverageHappiness();
					num2 += (float)yearlyRecord.PromotionsReceived;
					num3 += (float)yearlyRecord.QualificationsReceived;
					int salary = staffMember.GetSalary();
					int num5 = salary - staffMember.GetDesiredSalary();
					num4 += (((float)salary > 0f) ? ((float)num5 / (float)salary) : ((float)num5));
				}
			}
			if (_characterManager.StaffMembers.Count > 0)
			{
				num /= (float)_characterManager.StaffMembers.Count;
			}
			return num * _config.ScoreSheet.Instance.StaffHappinessMultiplier + _reputationTracker.StaffReputation * _config.ScoreSheet.Instance.StaffReputationMultiplier + _reputationTracker.OverallReputation * _config.ScoreSheet.Instance.OverallReputationMultiplier + num2 * _config.ScoreSheet.Instance.EoyPromotionsMultiplier + num3 * _config.ScoreSheet.Instance.EoyQualificationsMultiplier + num4 * _config.ScoreSheet.Instance.SalaryMultiplier;
		}

		public float GetMostPrestigiousScore(bool useLastYearRecords)
		{
			float num = GameAlgorithms.CalculateAverageRoomPrestige(_level) * _config.ScoreSheet.Instance.RoomPrestigeMultiplier;
			float num2 = (float)_level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness) * _config.ScoreSheet.Instance.AttractivenessMultiplier;
			float num3 = GameAlgorithms.CalculateHygieneEnvironmentRating(_level) * _config.ScoreSheet.Instance.HygieneMultiplier;
			float num4 = (float)GameAlgorithms.CalculateEnvironmentThermalComfort(_level) * _config.ScoreSheet.Instance.TemperatureMultiplier;
			return num + num2 + num3 + num4;
		}

		public float GetTeachingHospitalOfTheYearScore(bool useLastYearRecords)
		{
			int num = 0;
			foreach (Staff staffMember in _characterManager.StaffMembers)
			{
				StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staffMember.StaffRecord.LastYearRecord : staffMember.StaffRecord.CurrentRecord);
				if (yearlyRecord != null)
				{
					num += yearlyRecord.QualificationsReceived;
				}
			}
			return num;
		}

		public float GetResearchHospitalOfTheYearScore(bool useLastYearRecords)
		{
			return _researchPointsGeneratedThisYear * _config.ScoreSheet.Instance.TotalReseachPointsMultiplier + (float)_researchProjectsCompletedThisYear * _config.ScoreSheet.Instance.TotalResearchProjectsMultiplier;
		}

		public float GetPatientsChoiceScore(bool useLastYearRecords)
		{
			int num = 0;
			foreach (Staff staffMember in _characterManager.StaffMembers)
			{
				if (staffMember.Definition._type == StaffDefinition.Type.Doctor)
				{
					StaffRecord.YearlyRecord yearlyRecord = (useLastYearRecords ? staffMember.StaffRecord.LastYearRecord : staffMember.StaffRecord.CurrentRecord);
					if (yearlyRecord != null)
					{
						int patientsCured = yearlyRecord.PatientsCured;
						int num2 = yearlyRecord.PatientsIneffectivelyTreated + yearlyRecord.PatientsKilled;
						num += patientsCured - num2;
					}
				}
			}
			return (float)num * _config.ScoreSheet.Instance.TotalTreatmentsMultiplier + _reputationTracker.PatientReputation * _config.ScoreSheet.Instance.PatientReputationMultiplier;
		}

		public float GetNoDeathsScore(bool useLastYearRecords)
		{
			int num = 0;
			LevelStatsDatabase.YearStats latestCompletedYearStats = _level.LevelStatsDatabase.GetLatestCompletedYearStats();
			if (latestCompletedYearStats != null)
			{
				num = -latestCompletedYearStats.NumberOfPatientDeaths;
			}
			return num;
		}

		public float GetHospitalOfTheYearScore(bool useLastYearRecords)
		{
			float num = 0f;
			foreach (KeyValuePair<AwardType, AwardInstanceData> awardDatum in AwardsConfig.AwardData)
			{
				if (awardDatum.Key != AwardType.HospitalOfTheYear && DidWinAward(awardDatum.Key, out var _, useLastYearsRecords: true))
				{
					num += 1f;
				}
			}
			return num;
		}

		public bool HasAwardBeenWon(AwardType awardType)
		{
			if (AwardsWon != null)
			{
				return AwardsWon.ContainsKey(awardType);
			}
			return false;
		}

		public int GetAwardWinCount(AwardType awardType)
		{
			int result = 0;
			if (AwardsWon.TryGetValue(awardType, out var value))
			{
				result = value.AwardCount;
			}
			return result;
		}

		public void SetAwardWon(AwardType awardType, Staff staffWinner)
		{
			if (AwardsWon == null)
			{
				AwardsWon = new Dictionary<AwardType, AwardsWonData>();
			}
			if (AwardsWon.TryGetValue(awardType, out var value))
			{
				value.AwardCount++;
				value.LastWonByStaffMemberName = ((staffWinner != null) ? staffWinner.Name : "");
				AwardsWon.Remove(awardType);
			}
			else
			{
				value = new AwardsWonData(1, (staffWinner != null) ? staffWinner.Name : "");
			}
			AwardsWon.Add(awardType, value);
		}

		public void ProcessEndOfYearAwardsSilently()
		{
			List<SimpleAwardInfo> awardInfoList = new List<SimpleAwardInfo>();
			OnStartAwardsCeremony();
			ProcessAwards(ref awardInfoList);
			CheckWinAllAwardsAchievement(awardInfoList);
		}

		public void ProcessAwards(ref List<SimpleAwardInfo> awardInfoList)
		{
			foreach (KeyValuePair<AwardType, AwardInstanceData> awardDatum in AwardsConfig.AwardData)
			{
				Staff highestScorer;
				bool flag = DidWinAward(awardDatum.Key, out highestScorer, useLastYearsRecords: true);
				awardInfoList.Add(new SimpleAwardInfo(awardDatum.Key, flag));
				if (flag)
				{
					if (highestScorer != null)
					{
						AddPendingAwardStaffWinner(awardDatum.Key, highestScorer);
					}
					GiveReward(awardDatum.Key);
					SetAwardWon(awardDatum.Key, highestScorer);
					highestScorer?.StaffRecord.RecordAward();
				}
			}
		}

		public void CheckWinAllAwardsAchievement(List<SimpleAwardInfo> awardInfoList)
		{
			if (awardInfoList == null || awardInfoList.Count != AwardsConfig.AwardData.Count)
			{
				return;
			}
			bool flag = false;
			foreach (SimpleAwardInfo awardInfo in awardInfoList)
			{
				if (!awardInfo.Winner)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.AwardWinner);
			}
		}

		private void ResetAllCounters()
		{
			_researchPointsGeneratedThisYear = 0f;
			_researchProjectsCompletedThisYear = 0;
		}

		private ConsoleCommandResult Debug_ShowAwardsDebugMenu(string[] args)
		{
			if (_level.HUD.FindMenu<AwardsDebugMenu>() == null)
			{
				AwardsDebugMenu awardsDebugMenu = _level.HUD.CreateMenu<AwardsDebugMenu>();
				awardsDebugMenu.Setup(_level, this);
				awardsDebugMenu.Initialise(_level.HUD);
			}
			return ConsoleCommandResult.Succeeded();
		}
	}
}
