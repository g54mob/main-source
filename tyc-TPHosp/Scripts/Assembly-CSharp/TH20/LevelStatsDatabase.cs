using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TH20.EventAwardSilver;
using TH20.EventStaffHired;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class LevelStatsDatabase : MustCallDestroy, IGameEventsBase, TH20.EventStaffHired.Interface, IGameEventCallback, TH20.EventAwardSilver.Interface
	{
		public enum Stat
		{
			None = 0,
			Balance = 100,
			TotalPhysicalAssetValue = 101,
			Revenue = 102,
			HospitalValue = 103,
			TotalStaffWages = 104,
			NetIncome = 105,
			Profit = 106,
			NetAssetValue = 107,
			TotalLoans = 108,
			HospitalLevel = 109,
			RoomPrestige = 110,
			HospitalAttractiveness = 111,
			HospitalTemperature = 112,
			HospitalHygiene = 113,
			ProfitFactor = 114,
			NetProfit = 115,
			PositiveMonthlyNetProfitCount = 116,
			RegularExpenses = 150,
			SporadicExpenses = 151,
			TotalExpenses = 152,
			BuildingRoomsExpenses = 200,
			BuildingItemsExpenses = 201,
			StaffMorale = 300,
			DoctorsMorale = 301,
			NursesMorale = 302,
			AssistantsMorale = 303,
			JanitorsMorale = 304,
			StaffNeeds = 305,
			StaffEnergy = 320,
			DoctorsEnergy = 321,
			NursesEnergy = 322,
			AssistantsEnergy = 323,
			JanitorsEnergy = 324,
			TotalDoctorSalary = 350,
			TotalNurseSalary = 351,
			TotalAssistantSalary = 352,
			TotalJanitorSalary = 353,
			StaffPaySatisfaction = 354,
			PatientHappiness = 400,
			PatientHealth = 401,
			NumberOfDoctors = 500,
			NumberOfNurses = 501,
			NumberOfAssistants = 502,
			NumberOfJanitors = 503,
			NumberOfPatients = 504,
			NumberOfStaff = 505,
			OverallReputation = 700,
			PriceReputation = 701,
			PatientReputation = 702,
			SpecialReputation = 703,
			StaffReputation = 704,
			MedicalReputation = 705,
			NumberOfDoctorsTrained = 800,
			NumberOfNursesTrained = 801,
			NumberOfAssistantsTrained = 802,
			NumberOfJanitorsTrained = 803,
			NumberOfStaffTrained = 804,
			NumberOfStaffReadyForTraining = 805,
			DoctorsRank = 850,
			NursesRank = 851,
			AssistantsRank = 852,
			JanitorsRank = 853,
			StaffRank = 854,
			NumberOfDoctorsPromoted = 900,
			NumberOfNursesPromoted = 901,
			NumberOfAssistantsPromoted = 902,
			NumberOfJanitorsPromoted = 903,
			NumberOfStaffPromoted = 904,
			NumberOfStaffReadyForPromotion = 905,
			NumberOfCures = 950,
			NumberOfFails = 951,
			CureRate = 952,
			NumberOfPatientsProcessed = 953
		}

		public class MonthStats
		{
			public GameDate StartGameDate;

			public GameDate EndGameDate;

			public int Balance;

			public int TotalPhysicalAssetValue;

			public int Revenue;

			public int RegularExpenses;

			public int SporadicExpenses;

			public int TotalLoans;

			public int NetProfit;

			public int PositiveMonthlyNetProfitCount;

			public int HospitalLevel;

			public float RoomPrestige;

			public int HospitalAttractiveness;

			public int HospitalTemperature;

			public float HospitalHygiene;

			public int TotalStaffWages;

			public int TotalRetailSpend;

			public int TreatmentRevenue;

			public int DiagnosisRevenue;

			public int BuildingRoomsExpenses;

			public int BuildingItemsExpenses;

			public float StaffMorale;

			public float DoctorsMorale;

			public float NursesMorale;

			public float AssistantsMorale;

			public float JanitorsMorale;

			public float StaffNeeds;

			public float StaffRank;

			public float DoctorsRank;

			public float NursesRank;

			public float AssistantsRank;

			public float JanitorsRank;

			public float StaffEnergy;

			public float DoctorsEnergy;

			public float NursesEnergy;

			public float AssistantsEnergy;

			public float JanitorsEnergy;

			public int TotalDoctorSalary;

			public int TotalNurseSalary;

			public int TotalAssistantSalary;

			public int TotalJanitorSalary;

			public float StaffPaySatisfaction;

			public int[] StaffTrained = new int[StaffDefinition.AllTypes.Length];

			public int NumberOfStaffTrained;

			public int[] StaffPromoted = new int[StaffDefinition.AllTypes.Length];

			public int NumberOfStaffPromoted;

			public int NumberOfDoctors;

			public int NumberOfNurses;

			public int NumberOfAssistants;

			public int NumberOfJanitors;

			public int[] NumberOfStaffRank = new int[5];

			public int[,] NumStaffReachedMaxXP = new int[StaffDefinition.AllTypes.Length, 5];

			public double[,] TimeStaffReachedMaxXP = new double[StaffDefinition.AllTypes.Length, 5];

			public float PatientHappiness;

			public float PatientHealth;

			public int NumberOfPatients;

			public float OverallReputation;

			public float PriceReputation;

			public float PatientReputation;

			public float SpecialReputation;

			public float StaffReputation;

			public float MedicalReputation;

			public int NumberOfPatientRageQuits;

			public int NumberOfPatientsSentHome;

			public int NumberOfTreatmentCures;

			public int NumberOfTreatmentIneffectives;

			public int NumberOfTreatmentFatals;

			public int HospitalValue => FinanceManager.AddBalance(FinanceManager.AddBalance(FinanceManager.AddBalance(Balance, ProfitFactor), TotalPhysicalAssetValue), -TotalLoans);

			public int ProfitFactor => PositiveMonthlyNetProfitCount * NetProfit;

			public int NumberOfDoctorsTrained => StaffTrained[0];

			public int NumberOfNursesTrained => StaffTrained[1];

			public int NumberOfAssistantsTrained => StaffTrained[2];

			public int NumberOfJanitorsTrained => StaffTrained[3];

			public int NumberOfDoctorsPromoted => StaffPromoted[0];

			public int NumberOfNursesPromoted => StaffPromoted[1];

			public int NumberOfAssistantsPromoted => StaffPromoted[2];

			public int NumberOfJanitorsPromoted => StaffPromoted[3];

			public int NumberOfStaff => NumberOfDoctors + NumberOfNurses + NumberOfAssistants + NumberOfJanitors;

			public int TotalExpenses => SporadicExpenses + RegularExpenses;

			public int NetIncome => Revenue - RegularExpenses - SporadicExpenses;

			public int Profit => Revenue - RegularExpenses;

			public int NetAssetValue => FinanceManager.AddBalance(FinanceManager.AddBalance(Balance, TotalPhysicalAssetValue), -TotalLoans);

			public int NumberOfCures => NumberOfTreatmentCures;

			public int NumberOfFails => NumberOfTreatmentIneffectives + NumberOfTreatmentFatals;

			public int NumberOfPatientsProcessed => NumberOfPatientRageQuits + NumberOfPatientsSentHome + NumberOfTreatmentCures + NumberOfTreatmentIneffectives + NumberOfTreatmentFatals;

			public float CureRate
			{
				get
				{
					int numberOfPatientsProcessed = NumberOfPatientsProcessed;
					if (numberOfPatientsProcessed == 0)
					{
						return 0f;
					}
					return (float)NumberOfTreatmentCures / (float)numberOfPatientsProcessed * 100f;
				}
			}

			public MonthStats Clone()
			{
				return (MonthStats)MemberwiseClone();
			}

			public double GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type type, int rank)
			{
				int num = NumStaffReachedMaxXP[(int)type, rank];
				double num2 = TimeStaffReachedMaxXP[(int)type, rank];
				if (num == 0)
				{
					return 0.0;
				}
				return num2 / (double)num;
			}

			public bool QueryAsDouble(Stat stat, out double value)
			{
				string name = stat.ToString();
				FieldInfo field = GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public);
				if (field != null)
				{
					Type fieldType = field.FieldType;
					if (fieldType == typeof(int))
					{
						value = (int)field.GetValue(this);
						return true;
					}
					if (fieldType == typeof(float))
					{
						value = (float)field.GetValue(this);
						return true;
					}
				}
				PropertyInfo property = GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					Type propertyType = property.PropertyType;
					if (propertyType == typeof(int))
					{
						value = (int)property.GetValue(this, null);
						return true;
					}
					if (propertyType == typeof(float))
					{
						value = (float)property.GetValue(this, null);
						return true;
					}
				}
				value = 0.0;
				return false;
			}
		}

		public class YearStats
		{
			public GameDate StartGameDate;

			public GameDate EndGameDate;

			public readonly List<MonthStats> Months = new List<MonthStats>(12);

			public int TotalProfit;

			public int TotalRevenue;

			public int TreatmentRevenue;

			public int DiagnosisRevenue;

			public int TotalNetIncome;

			public int TotalRegularExpenses;

			public int TotalSilverEarned;

			public int TotalStaffWages;

			public int AverageHospitalValue;

			public int AverageBalance;

			public int AveragePhysicalAssetValue;

			public int AverageLoans;

			public int AverageProfitFactor;

			public int NetProfit;

			public int PositiveMonthlyNetProfitCount;

			public int NumberOfTreatmentCures;

			public int NumberOfTreatmentIneffectives;

			public int NumberOfTreatmentFatals;

			public int NumberOfPatientRageQuits;

			public int NumberOfPatientDeaths;

			public int NumberOfPatientsSentHome;

			public float PatientHappiness;

			public float PatientHealth;

			public int[] StaffTrained = new int[StaffDefinition.AllTypes.Length];

			public int[] StaffPromoted = new int[StaffDefinition.AllTypes.Length];

			public int NumberOfHiredStaff;

			public int NumberOfFiredStaff;

			public int NumberOfStaffTrained;

			public int NumberOfStaffPromoted;

			public int NumberOfDoctors;

			public int NumberOfNurses;

			public int NumberOfAssistants;

			public int NumberOfJanitors;

			public int NumberOfPatients;

			public int AverageNumberOfStaff;

			public float AverageStaffPaySatisfaction;

			public float StaffMorale;

			public float DoctorsMorale;

			public float NursesMorale;

			public float AssistantsMorale;

			public float JanitorsMorale;

			public float StaffNeeds;

			public float StaffRank;

			public float DoctorsRank;

			public float NursesRank;

			public float AssistantsRank;

			public float JanitorsRank;

			public float StaffEnergy;

			public float DoctorsEnergy;

			public float NursesEnergy;

			public float AssistantsEnergy;

			public float JanitorsEnergy;

			public double TotalResearchPoints;

			public int HospitalValueAtStartOfYear;

			public float OverallReputationAtStartOfYear;

			public float AverageOverallReputation;

			public int HospitalLevelAtStartOfYear;

			public int HospitalLevelAtEndOfYear;

			public int HospitalAttractiveness;

			public int HospitalTemperature;

			public float HospitalHygiene;

			public int NumberOfCures => NumberOfTreatmentCures;

			public int NumberOfFails => NumberOfTreatmentIneffectives + NumberOfTreatmentFatals;

			public float CureRate
			{
				get
				{
					int num = NumberOfPatientRageQuits + NumberOfPatientsSentHome + NumberOfTreatmentCures + NumberOfTreatmentIneffectives + NumberOfTreatmentFatals;
					if (num == 0)
					{
						return 0f;
					}
					return (float)NumberOfTreatmentCures / (float)num * 100f;
				}
			}

			public int HospitalValueAtEndOfYear
			{
				get
				{
					if (Months.Count == 0)
					{
						return 0;
					}
					return Months[Months.Count - 1].HospitalValue;
				}
			}

			public int HospitalValueDelta => HospitalValueAtEndOfYear - HospitalValueAtStartOfYear;

			public float OverallReputationAtEndOfYear
			{
				get
				{
					if (Months.Count == 0)
					{
						return 0f;
					}
					return Months[Months.Count - 1].OverallReputation;
				}
			}

			public float OverallReputationDelta => OverallReputationAtEndOfYear - OverallReputationAtStartOfYear;

			public int HospitalLevelDelta => HospitalLevelAtEndOfYear - HospitalLevelAtStartOfYear;

			public int Profit => Mathf.Max(0, TotalProfit);

			public int Revenue => Mathf.Max(0, TotalRevenue);

			public int TotalExpenses => Mathf.Max(0, TotalRegularExpenses);

			public int RegularExpenses => Mathf.Max(0, TotalRegularExpenses);

			public int HospitalValue => Mathf.Max(0, AverageHospitalValue);

			public int ProfitFactor => Mathf.Max(0, AverageProfitFactor);

			public int Balance => Mathf.Max(0, AverageBalance);

			public int TotalPhysicalAssetValue => Mathf.Max(0, AveragePhysicalAssetValue);

			public int TotalLoans => Mathf.Max(0, AverageLoans);

			public int NumberOfStaff => Mathf.Max(0, AverageNumberOfStaff);

			public float StaffPaySatisfaction => Mathf.Max(0f, AverageStaffPaySatisfaction);

			public int NumberOfDoctorsPromoted => StaffPromoted[0];

			public int NumberOfNursesPromoted => StaffPromoted[1];

			public int NumberOfAssistantsPromoted => StaffPromoted[2];

			public int NumberOfJanitorsPromoted => StaffPromoted[3];

			public int NumberOfDoctorsTrained => StaffTrained[0];

			public int NumberOfNursesTrained => StaffTrained[1];

			public int NumberOfAssistantsTrained => StaffTrained[2];

			public int NumberOfJanitorsTrained => StaffTrained[3];

			public float OverallReputation => AverageOverallReputation;

			public YearStats Clone()
			{
				return (YearStats)MemberwiseClone();
			}

			public bool QueryAsDouble(Stat stat, out double value)
			{
				string name = stat.ToString();
				FieldInfo field = GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public);
				if (field != null)
				{
					Type fieldType = field.FieldType;
					if (fieldType == typeof(int))
					{
						value = (int)field.GetValue(this);
						return true;
					}
					if (fieldType == typeof(float))
					{
						value = (float)field.GetValue(this);
						return true;
					}
				}
				PropertyInfo property = GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					Type propertyType = property.PropertyType;
					if (propertyType == typeof(int))
					{
						value = (int)property.GetValue(this, null);
						return true;
					}
					if (propertyType == typeof(float))
					{
						value = (float)property.GetValue(this, null);
						return true;
					}
				}
				value = 0.0;
				return false;
			}
		}

		public class CumulativeLevelStats
		{
			public int TotalRevenue;

			public int TotalRegularExpenses;

			public int NumberOfHiredStaff;

			public int NumberOfFiredStaff;

			public int NumberOfStaffTrained;

			public int NumberOfStaffPromoted;

			public double TotalResearchPoints;

			public int NumberOfPatients;

			public int NumberOfPatientRageQuits;

			public int NumberOfPatientDeaths;

			public int NumberOfPatientsSentHome;

			public int NumberOfTreatmentCures;

			public int NumberOfTreatmentIneffectives;

			public int NumberOfTreatmentFatals;

			public int NumberOfAnachronisticPatientRageQuits;

			public int NumberOfAnachronisticPatientDeaths;

			public int NumberOfAnachronisticTreatmentCures;

			public int NumberOfAnachronisticTreatmentIneffectives;

			public int NumberOfAnachronisticTreatmentFatals;

			public int TotalNetIncome => TotalRevenue - TotalRegularExpenses;

			public float CureRate
			{
				get
				{
					int num = NumberOfPatientRageQuits + NumberOfPatientsSentHome + NumberOfTreatmentCures + NumberOfTreatmentIneffectives + NumberOfTreatmentFatals;
					if (num == 0)
					{
						return 0f;
					}
					return (float)NumberOfTreatmentCures / (float)num * 100f;
				}
			}

			public float AnachronisticCureRate
			{
				get
				{
					int num = NumberOfAnachronisticPatientRageQuits + NumberOfAnachronisticTreatmentCures + NumberOfAnachronisticTreatmentIneffectives + NumberOfAnachronisticTreatmentFatals;
					if (num == 0)
					{
						return 0f;
					}
					return (float)NumberOfAnachronisticTreatmentCures / (float)num * 100f;
				}
			}
		}

		public struct ExpensesBreakdown
		{
			public int Wages;

			public int Other;
		}

		public struct RevenueBreakdown
		{
			public int Treatment;

			public int Diagnosis;

			public int Other;
		}

		private static readonly List<MonthStats> _cachedMonthlyStatsList = new List<MonthStats>(24);

		private readonly List<MonthStats> _monthlyStats = new List<MonthStats>();

		private readonly List<YearStats> _yearStats = new List<YearStats>();

		private readonly Level _level;

		private readonly TimelineManager _timelineManager;

		private readonly FinanceManager _financeManager;

		private readonly ReputationTracker _reputationTracker;

		private readonly PrestigeTracker _prestigeTracker;

		private readonly ResearchManager _researchManager;

		private readonly CharacterManager _characterManager;

		private readonly CharacterEvents _characterEvents;

		private MonthStats _currentMonthStats;

		private YearStats _currentYearStats;

		private CumulativeLevelStats _cumulativeLevelStats;

		public Action<MonthStats> OnMonthCompleted;

		public Action<YearStats> OnYearCompleted;

		public Action<MonthStats, int, int> OnMonthlyStatsUpdatedPreExpenses;

		public int HospitalValue => _currentMonthStats.HospitalValue;

		public int HospitalLevel => _currentMonthStats.HospitalLevel;

		public int CurrentBalance => _financeManager.Balance;

		public int TotalStaffWages => _financeManager.TotalStaffWages;

		public float OverallReputation => _reputationTracker.OverallReputation;

		public LevelStatsDatabase(Level level, TimelineManager timelineManager, FinanceManager financeManager, ReputationTracker reputationTracker, PrestigeTracker prestigeTracker, ResearchManager researchManager, CharacterManager characterManager, CharacterEvents characterEvents)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			_timelineManager = timelineManager;
			_financeManager = financeManager;
			_reputationTracker = reputationTracker;
			_prestigeTracker = prestigeTracker;
			_researchManager = researchManager;
			_characterManager = characterManager;
			_characterEvents = characterEvents;
			_level.WorldState.Update(0f);
			MonthStats monthStats = new MonthStats
			{
				StartGameDate = new GameDate(_timelineManager.Year - 1, (12 + _timelineManager.Month - 1) % 12, 0),
				EndGameDate = new GameDate(_timelineManager.Year, _timelineManager.Month, 0),
				Balance = _financeManager.Balance,
				TotalPhysicalAssetValue = CalculateTotalPhysicalAssetValue(),
				Revenue = 0,
				RegularExpenses = 0,
				TotalLoans = 0,
				NetProfit = CalculateQuarterlyNetProfit(),
				PositiveMonthlyNetProfitCount = CalculatePositiveMonthlyNetProfitCount(),
				HospitalLevel = _prestigeTracker.Level,
				RoomPrestige = GameAlgorithms.CalculateAverageRoomPrestige(_level),
				HospitalAttractiveness = _level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness),
				HospitalTemperature = GameAlgorithms.CalculateEnvironmentThermalComfort(_level),
				HospitalHygiene = GameAlgorithms.CalculateHygieneEnvironmentRating(_level),
				StaffMorale = _characterManager.StaffMorale,
				DoctorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Doctor),
				NursesMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Janitor),
				StaffNeeds = _characterManager.GetAverageStaffNeedsValue(),
				StaffRank = _characterManager.StaffRank,
				DoctorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Doctor),
				NursesRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Janitor),
				StaffEnergy = _characterManager.StaffEnergy,
				DoctorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Doctor),
				NursesEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Janitor),
				PatientHappiness = _characterManager.PatientHappiness,
				PatientHealth = _characterManager.PatientHealth,
				OverallReputation = _reputationTracker.OverallReputation,
				PriceReputation = _reputationTracker.PriceReputation,
				PatientReputation = _reputationTracker.PatientReputation,
				SpecialReputation = _reputationTracker.SpecialReputation,
				StaffReputation = _reputationTracker.StaffReputation,
				MedicalReputation = _reputationTracker.MedicalReputation
			};
			_monthlyStats.Add(monthStats);
			_currentMonthStats = monthStats.Clone();
			_currentMonthStats.StartGameDate = new GameDate(_timelineManager.Year, _timelineManager.Month, 0);
			YearStats yearStats = new YearStats
			{
				StartGameDate = new GameDate(_timelineManager.Year - 1, 0, 0),
				EndGameDate = new GameDate(_timelineManager.Year, 0, 0),
				HospitalValueAtStartOfYear = CalculateHospitalValue(),
				OverallReputationAtStartOfYear = _reputationTracker.OverallReputation,
				HospitalLevelAtStartOfYear = _prestigeTracker.Level,
				HospitalAttractiveness = _level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness),
				HospitalTemperature = GameAlgorithms.CalculateEnvironmentThermalComfort(_level),
				HospitalHygiene = GameAlgorithms.CalculateHygieneEnvironmentRating(_level),
				StaffMorale = _characterManager.StaffMorale,
				DoctorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Doctor),
				NursesMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Janitor),
				StaffNeeds = _characterManager.GetAverageStaffNeedsValue(),
				StaffRank = _characterManager.StaffRank,
				DoctorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Doctor),
				NursesRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Janitor),
				StaffEnergy = _characterManager.StaffEnergy,
				DoctorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Doctor),
				NursesEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Nurse),
				AssistantsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Assistant),
				JanitorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Janitor),
				PatientHappiness = _characterManager.PatientHappiness,
				PatientHealth = _characterManager.PatientHealth
			};
			_yearStats.Add(yearStats);
			_currentYearStats = yearStats.Clone();
			_currentYearStats.StartGameDate = new GameDate(_timelineManager.Year, _timelineManager.Month, 0);
			_cumulativeLevelStats = new CumulativeLevelStats();
			Level level2 = _level;
			level2.PostConstruct = (System.Action)Delegate.Combine(level2.PostConstruct, (System.Action)delegate
			{
				RegisterEvents();
				_characterEvents.OnStaffHired.Add(this);
			});
			List<MonthStats> monthStats2 = new List<MonthStats>(1200);
			ConsoleCommandsDatabase.RegisterCommand("QueryMonthStat", "Query the monthly stats database", "Query the monthly stats database", delegate(string[] args)
			{
				if (args.Length == 0)
				{
					return ConsoleCommandResult.Failed();
				}
				Stat stat;
				try
				{
					stat = (Stat)Enum.Parse(typeof(Stat), args[0]);
				}
				catch
				{
					return ConsoleCommandResult.Failed("Failed to parse stat name");
				}
				monthStats2.Clear();
				GetPreviousMonthlyStatsAscendingOrder(1200, monthStats2);
				string text = $"{stat}: ";
				foreach (MonthStats item in monthStats2)
				{
					if (item.QueryAsDouble(stat, out var value))
					{
						text += $"{value}, ";
					}
				}
				UnityEngine.Debug.Log(text);
				return ConsoleCommandResult.Succeeded(text);
			});
			OnTimelineUpdated(0, 0, 0);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			ResearchManager researchManager = _researchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Combine(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			FinanceManager financeManager = _financeManager;
			financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Combine(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnSporadicExpense = (Action<int>)Delegate.Combine(financeManager2.OnSporadicExpense, new Action<int>(OnSporadicExpense));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnRegularExpense = (Action<int>)Delegate.Combine(financeManager3.OnRegularExpense, new Action<int>(OnRegularExpense));
			FinanceManager financeManager4 = _financeManager;
			financeManager4.OnRoomPurchased = (Action<Room, int>)Delegate.Combine(financeManager4.OnRoomPurchased, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager5 = _financeManager;
			financeManager5.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Combine(financeManager5.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager6 = _financeManager;
			financeManager6.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Combine(financeManager6.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager7 = _financeManager;
			financeManager7.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Combine(financeManager7.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffReachedMaxXP = (Action<Staff, double>)Delegate.Combine(characterEvents2.OnStaffReachedMaxXP, new Action<Staff, double>(OnStaffReachedMaxXP));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Combine(characterEvents3.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents5.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents6.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents7.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents8.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents9.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents10 = _characterEvents;
			characterEvents10.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents10.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents11 = _characterEvents;
			characterEvents11.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents11.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
		}

		private void UnregisterEvents()
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			ResearchManager researchManager = _researchManager;
			researchManager.OnResearchPointsAdded = (Action<float, ResearchProject>)Delegate.Remove(researchManager.OnResearchPointsAdded, new Action<float, ResearchProject>(OnResearchPointsAdded));
			FinanceManager financeManager = _financeManager;
			financeManager.OnMoneyEarned = (Action<int, Vector3?>)Delegate.Remove(financeManager.OnMoneyEarned, new Action<int, Vector3?>(OnMoneyEarned));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnSporadicExpense = (Action<int>)Delegate.Remove(financeManager2.OnSporadicExpense, new Action<int>(OnSporadicExpense));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnRegularExpense = (Action<int>)Delegate.Remove(financeManager3.OnRegularExpense, new Action<int>(OnRegularExpense));
			FinanceManager financeManager4 = _financeManager;
			financeManager4.OnRoomPurchased = (Action<Room, int>)Delegate.Remove(financeManager4.OnRoomPurchased, new Action<Room, int>(OnRoomPurchased));
			FinanceManager financeManager5 = _financeManager;
			financeManager5.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Remove(financeManager5.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager6 = _financeManager;
			financeManager6.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Remove(financeManager6.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager7 = _financeManager;
			financeManager7.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Remove(financeManager7.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffReachedMaxXP = (Action<Staff, double>)Delegate.Remove(characterEvents2.OnStaffReachedMaxXP, new Action<Staff, double>(OnStaffReachedMaxXP));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffQualificationComplete = (Action<Staff, QualificationDefinition, Staff>)Delegate.Remove(characterEvents3.OnStaffQualificationComplete, new Action<Staff, QualificationDefinition, Staff>(OnStaffQualificationComplete));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents5.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents6.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents7.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents8.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents9.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents10 = _characterEvents;
			characterEvents10.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents10.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents11 = _characterEvents;
			characterEvents11.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents11.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemPurchased = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemPurchased, new Action<RoomItem>(OnRoomItemPurchased));
		}

		public bool QueryCurrentMonthStat(Stat stat, out double value)
		{
			switch (stat)
			{
			case Stat.Balance:
				value = CurrentBalance;
				return true;
			case Stat.HospitalValue:
				value = HospitalValue;
				return true;
			case Stat.HospitalLevel:
				value = HospitalLevel;
				return true;
			case Stat.TotalStaffWages:
				value = TotalStaffWages;
				return true;
			case Stat.OverallReputation:
				value = OverallReputation;
				return true;
			case Stat.NumberOfStaff:
				value = 0.0;
				foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
				{
					if (!staffMember.HasBeenFired() && !staffMember.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfDoctors:
				value = 0.0;
				foreach (Staff staffMember2 in _level.CharacterManager.StaffMembers)
				{
					if (staffMember2.Definition._type == StaffDefinition.Type.Doctor && !staffMember2.HasBeenFired() && !staffMember2.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfJanitors:
				value = 0.0;
				foreach (Staff staffMember3 in _level.CharacterManager.StaffMembers)
				{
					if (staffMember3.Definition._type == StaffDefinition.Type.Janitor && !staffMember3.HasBeenFired() && !staffMember3.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfAssistants:
				value = 0.0;
				foreach (Staff staffMember4 in _level.CharacterManager.StaffMembers)
				{
					if (staffMember4.Definition._type == StaffDefinition.Type.Assistant && !staffMember4.HasBeenFired() && !staffMember4.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfNurses:
				value = 0.0;
				foreach (Staff staffMember5 in _level.CharacterManager.StaffMembers)
				{
					if (staffMember5.Definition._type == StaffDefinition.Type.Nurse && !staffMember5.HasBeenFired() && !staffMember5.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfPatients:
				value = _level.CharacterManager.Patients.Count;
				return true;
			case Stat.NumberOfStaffReadyForTraining:
				value = 0.0;
				foreach (Staff staffMember6 in _level.CharacterManager.StaffMembers)
				{
					if (!staffMember6.IsFullyTrained && !staffMember6.HasBeenFired() && !staffMember6.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			case Stat.NumberOfStaffReadyForPromotion:
				value = 0.0;
				foreach (Staff staffMember7 in _level.CharacterManager.StaffMembers)
				{
					if (staffMember7.IsReadyForPromotion && !staffMember7.HasBeenFired() && !staffMember7.HasResigned())
					{
						value += 1.0;
					}
				}
				return true;
			default:
				return _currentMonthStats.QueryAsDouble(stat, out value);
			}
		}

		public bool QueryPreviousMonthsStatSummed(Stat stat, int numberOfMonths, out double value)
		{
			double num = 0.0;
			List<MonthStats> list = new List<MonthStats>();
			GetPreviousMonthlyStats(numberOfMonths, list);
			foreach (MonthStats item in list)
			{
				if (item.QueryAsDouble(stat, out var value2))
				{
					num += value2;
				}
			}
			value = num;
			return true;
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("QueryMonthStat");
			UnregisterEvents();
			_characterEvents.OnStaffHired.Remove(this);
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnMonthCompleted.VerifyIsNull();
			OnYearCompleted.VerifyIsNull();
		}

		public MonthStats GetLatestCompletedMonthStats()
		{
			return _monthlyStats[_monthlyStats.Count - 1];
		}

		public MonthStats GetCurrentPendingMonthStats_Debug()
		{
			return _currentMonthStats;
		}

		public YearStats GetLatestCompletedYearStats()
		{
			return _yearStats[_yearStats.Count - 1];
		}

		public void GetPreviousYearlyStatsAscendingOrder(int numberOfYears, List<YearStats> results)
		{
			int num = Mathf.Min(_yearStats.Count, numberOfYears);
			for (int i = 0; i < num; i++)
			{
				results.Add(_yearStats[_yearStats.Count - num + i]);
			}
		}

		public CumulativeLevelStats GetCumulativeLevelStats()
		{
			return _cumulativeLevelStats;
		}

		public YearStats GetCurrentPendingYearStats_Debug()
		{
			return _currentYearStats;
		}

		public List<MonthStats> GetPreviousMonthlyStats(int numberOfMonths)
		{
			List<MonthStats> list = new List<MonthStats>(numberOfMonths);
			GetPreviousMonthlyStats(numberOfMonths, list);
			return list;
		}

		public void GetPreviousMonthlyStats(int numberOfMonths, List<MonthStats> results)
		{
			for (int i = 0; i < _monthlyStats.Count && i < numberOfMonths; i++)
			{
				results.Add(_monthlyStats[_monthlyStats.Count - i - 1]);
			}
		}

		public void GetPreviousMonthlyStatsAscendingOrder(int numberOfMonths, List<MonthStats> results)
		{
			int num = Mathf.Min(_monthlyStats.Count, numberOfMonths);
			for (int i = 0; i < num; i++)
			{
				results.Add(_monthlyStats[_monthlyStats.Count - num + i]);
			}
		}

		private int CalculateTotalPhysicalAssetValue()
		{
			float num = 0f;
			WorldState worldState = _level.WorldState;
			foreach (Room allRoom in worldState.AllRooms)
			{
				num += (float)allRoom.Definition._cost * GameAlgorithms.Config.GlobalSellValueMultiplier;
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					num += (float)item.SellValue();
				}
			}
			foreach (HospitalPlot hospitalPlot in worldState.HospitalPlots)
			{
				if (hospitalPlot.Bought)
				{
					num += (float)hospitalPlot.Definition.Cost * GameAlgorithms.Config.GlobalSellValueMultiplier;
				}
			}
			return Mathf.CeilToInt(num);
		}

		private int CalculateHospitalValue()
		{
			int balance = _financeManager.Balance;
			int num = CalculateProfitFactor();
			int num2 = CalculateTotalPhysicalAssetValue();
			int num3 = CalculateTotalLoans();
			return Mathf.Max(balance + num + num2 - num3, 0);
		}

		private int CalculateProfitFactor()
		{
			int num = CalculateQuarterlyNetProfit();
			int result = Mathf.Max(CalculatePositiveMonthlyNetProfitCount() * num, 0);
			CalculateMonthlyNetProfit();
			return result;
		}

		private int CalculateQuarterlyNetProfit()
		{
			_cachedMonthlyStatsList.Clear();
			GetPreviousMonthlyStats(12, _cachedMonthlyStatsList);
			int num = 0;
			int num2 = 0;
			foreach (MonthStats cachedMonthlyStats in _cachedMonthlyStatsList)
			{
				num += cachedMonthlyStats.RegularExpenses;
				num2 += cachedMonthlyStats.Revenue;
			}
			_cachedMonthlyStatsList.Clear();
			return Mathf.Max((num2 - num) / 4, 0);
		}

		private int CalculateMonthlyNetProfit()
		{
			_cachedMonthlyStatsList.Clear();
			GetPreviousMonthlyStats(1, _cachedMonthlyStatsList);
			int num = 0;
			int num2 = 0;
			foreach (MonthStats cachedMonthlyStats in _cachedMonthlyStatsList)
			{
				num += cachedMonthlyStats.RegularExpenses;
				num2 += cachedMonthlyStats.Revenue;
			}
			_cachedMonthlyStatsList.Clear();
			return num2 - num;
		}

		private int CalculatePositiveMonthlyNetProfitCount()
		{
			_cachedMonthlyStatsList.Clear();
			GetPreviousMonthlyStats(12, _cachedMonthlyStatsList);
			int result = _cachedMonthlyStatsList.Count((MonthStats record) => record.Profit > 0);
			_cachedMonthlyStatsList.Clear();
			return result;
		}

		private int CalculateTotalLoans()
		{
			int num = 0;
			if (_level.LoanManager != null)
			{
				foreach (LoanOffer offer in _level.LoanManager.Offers)
				{
					if (offer.Active)
					{
						num += offer.OutstandingBalance;
					}
				}
			}
			return num;
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day == 0 && month == 0 && year == 0)
			{
				return;
			}
			if (day == 0)
			{
				_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.MonthEnd);
				_currentMonthStats.EndGameDate = new GameDate(year, month, 0);
				_monthlyStats.Add(_currentMonthStats);
				_currentYearStats.Months.Add(_currentMonthStats);
				_currentMonthStats.HospitalLevel = _prestigeTracker.Level;
				_currentMonthStats.RoomPrestige = GameAlgorithms.CalculateAverageRoomPrestige(_level);
				_currentMonthStats.TotalLoans = CalculateTotalLoans();
				_currentMonthStats.HospitalAttractiveness = _level.WorldState.GetEnvironmentRating(HospitalAttributeMap.Attribute.Attractiveness);
				_currentMonthStats.HospitalTemperature = GameAlgorithms.CalculateEnvironmentThermalComfort(_level);
				_currentMonthStats.HospitalHygiene = GameAlgorithms.CalculateHygieneEnvironmentRating(_level);
				_currentMonthStats.OverallReputation = _reputationTracker.OverallReputation;
				_currentMonthStats.PriceReputation = _reputationTracker.PriceReputation;
				_currentMonthStats.PatientReputation = _reputationTracker.PatientReputation;
				_currentMonthStats.SpecialReputation = _reputationTracker.SpecialReputation;
				_currentMonthStats.StaffReputation = _reputationTracker.StaffReputation;
				_currentMonthStats.MedicalReputation = _reputationTracker.MedicalReputation;
				_currentMonthStats.StaffMorale = _characterManager.StaffMorale;
				_currentMonthStats.DoctorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Doctor);
				_currentMonthStats.NursesMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Nurse);
				_currentMonthStats.AssistantsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Assistant);
				_currentMonthStats.JanitorsMorale = _characterManager.GetMoraleOfStaffType(StaffDefinition.Type.Janitor);
				_currentMonthStats.StaffNeeds = _characterManager.GetAverageStaffNeedsValue();
				_currentMonthStats.StaffRank = _characterManager.StaffRank;
				_currentMonthStats.DoctorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Doctor);
				_currentMonthStats.NursesRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Nurse);
				_currentMonthStats.AssistantsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Assistant);
				_currentMonthStats.JanitorsRank = _characterManager.GetRankOfStaffType(StaffDefinition.Type.Janitor);
				_currentMonthStats.StaffEnergy = _characterManager.StaffEnergy;
				_currentMonthStats.DoctorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Doctor);
				_currentMonthStats.NursesEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Nurse);
				_currentMonthStats.AssistantsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Assistant);
				_currentMonthStats.JanitorsEnergy = _characterManager.GetEnergyOfStaffType(StaffDefinition.Type.Janitor);
				_currentMonthStats.TotalStaffWages = _financeManager.TotalStaffWages;
				float num = 0f;
				int count = _level.CharacterManager.StaffMembers.Count;
				foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
				{
					int salary = staffMember.GetSalary();
					switch (staffMember.Definition._type)
					{
					case StaffDefinition.Type.Doctor:
						_currentMonthStats.NumberOfDoctors++;
						_currentMonthStats.TotalDoctorSalary += salary;
						break;
					case StaffDefinition.Type.Nurse:
						_currentMonthStats.NumberOfNurses++;
						_currentMonthStats.TotalNurseSalary += salary;
						break;
					case StaffDefinition.Type.Assistant:
						_currentMonthStats.NumberOfAssistants++;
						_currentMonthStats.TotalAssistantSalary += salary;
						break;
					case StaffDefinition.Type.Janitor:
						_currentMonthStats.NumberOfJanitors++;
						_currentMonthStats.TotalJanitorSalary += salary;
						break;
					}
					num += (float)GameAlgorithms.CalculatePaySatisfactionLevel(staffMember.GetDesiredSalaryDifference()) / 4f;
					if (staffMember.Rank < 5)
					{
						_currentMonthStats.NumberOfStaffRank[staffMember.Rank]++;
					}
				}
				_currentMonthStats.StaffPaySatisfaction = ((count != 0) ? (num / (float)count) : 0f);
				_currentMonthStats.PatientHappiness = _characterManager.PatientHappiness;
				_currentMonthStats.PatientHealth = _characterManager.PatientHealth;
				_currentMonthStats.NumberOfPatients = _level.CharacterManager.Patients.Count;
				int param = _financeManager.TotalStaffWages / 12;
				int energyBills = _financeManager.EnergyBills;
				OnMonthlyStatsUpdatedPreExpenses.InvokeSafe(_currentMonthStats, param, energyBills);
				_financeManager.PayBillsAndWages();
				_currentMonthStats.Balance = _financeManager.Balance;
				_currentMonthStats.TotalPhysicalAssetValue = CalculateTotalPhysicalAssetValue();
				_currentMonthStats.NetProfit = CalculateQuarterlyNetProfit();
				_currentMonthStats.PositiveMonthlyNetProfitCount = CalculatePositiveMonthlyNetProfitCount();
				OnMonthCompleted.InvokeSafe(_currentMonthStats);
				_currentMonthStats = new MonthStats
				{
					StartGameDate = new GameDate(year, month, 0),
					Balance = _currentMonthStats.Balance,
					TotalPhysicalAssetValue = _currentMonthStats.TotalPhysicalAssetValue,
					HospitalLevel = _currentMonthStats.HospitalLevel,
					RoomPrestige = _currentMonthStats.RoomPrestige,
					TotalLoans = _currentMonthStats.TotalLoans,
					HospitalAttractiveness = _currentMonthStats.HospitalAttractiveness,
					HospitalTemperature = _currentMonthStats.HospitalTemperature,
					HospitalHygiene = _currentMonthStats.HospitalHygiene,
					NetProfit = _currentMonthStats.NetProfit,
					PositiveMonthlyNetProfitCount = _currentMonthStats.PositiveMonthlyNetProfitCount,
					OverallReputation = _currentMonthStats.OverallReputation,
					PriceReputation = _currentMonthStats.PriceReputation,
					PatientReputation = _reputationTracker.PatientReputation,
					SpecialReputation = _reputationTracker.SpecialReputation,
					StaffReputation = _reputationTracker.StaffReputation,
					MedicalReputation = _reputationTracker.MedicalReputation,
					StaffMorale = _currentMonthStats.StaffMorale,
					DoctorsMorale = _currentMonthStats.DoctorsMorale,
					NursesMorale = _currentMonthStats.NursesMorale,
					AssistantsMorale = _currentMonthStats.AssistantsMorale,
					JanitorsMorale = _currentMonthStats.JanitorsMorale,
					StaffNeeds = _currentMonthStats.StaffNeeds,
					StaffRank = _currentMonthStats.StaffRank,
					DoctorsRank = _currentMonthStats.DoctorsRank,
					NursesRank = _currentMonthStats.NursesRank,
					AssistantsRank = _currentMonthStats.AssistantsRank,
					JanitorsRank = _currentMonthStats.JanitorsRank,
					StaffPaySatisfaction = _currentMonthStats.StaffPaySatisfaction,
					StaffEnergy = _currentMonthStats.StaffEnergy,
					DoctorsEnergy = _currentMonthStats.DoctorsEnergy,
					NursesEnergy = _currentMonthStats.NursesEnergy,
					AssistantsEnergy = _currentMonthStats.AssistantsEnergy,
					JanitorsEnergy = _currentMonthStats.JanitorsEnergy,
					PatientHappiness = _characterManager.PatientHappiness,
					PatientHealth = _characterManager.PatientHealth
				};
				Debug_OutputHospitalProfitFactor();
			}
			if (day != 0 || month != 0)
			{
				return;
			}
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.YearEnd);
			_currentYearStats.EndGameDate = new GameDate(year, 0, 0);
			_yearStats.Add(_currentYearStats);
			_currentYearStats.HospitalLevelAtEndOfYear = _prestigeTracker.Level;
			_currentYearStats.HospitalAttractiveness = _currentMonthStats.HospitalAttractiveness;
			_currentYearStats.HospitalTemperature = _currentMonthStats.HospitalTemperature;
			_currentYearStats.HospitalHygiene = _currentMonthStats.HospitalHygiene;
			_currentYearStats.StaffMorale = _currentMonthStats.StaffMorale;
			_currentYearStats.DoctorsMorale = _currentMonthStats.DoctorsMorale;
			_currentYearStats.NursesMorale = _currentMonthStats.NursesMorale;
			_currentYearStats.AssistantsMorale = _currentMonthStats.AssistantsMorale;
			_currentYearStats.JanitorsMorale = _currentMonthStats.JanitorsMorale;
			_currentYearStats.StaffNeeds = _currentMonthStats.StaffNeeds;
			_currentYearStats.StaffRank = _currentMonthStats.StaffRank;
			_currentYearStats.DoctorsRank = _currentMonthStats.DoctorsRank;
			_currentYearStats.NursesRank = _currentMonthStats.NursesRank;
			_currentYearStats.AssistantsRank = _currentMonthStats.AssistantsRank;
			_currentYearStats.JanitorsRank = _currentMonthStats.JanitorsRank;
			_currentYearStats.StaffEnergy = _currentMonthStats.StaffEnergy;
			_currentYearStats.DoctorsEnergy = _currentMonthStats.DoctorsEnergy;
			_currentYearStats.NursesEnergy = _currentMonthStats.NursesEnergy;
			_currentYearStats.AssistantsEnergy = _currentMonthStats.AssistantsEnergy;
			_currentYearStats.JanitorsEnergy = _currentMonthStats.JanitorsEnergy;
			int count2 = _currentYearStats.Months.Count;
			for (int i = 0; i < count2; i++)
			{
				MonthStats monthStats = _currentYearStats.Months[i];
				_currentYearStats.TotalProfit += monthStats.Profit;
				_currentYearStats.TotalNetIncome += monthStats.NetIncome;
				_currentYearStats.TotalRegularExpenses += monthStats.RegularExpenses;
				_currentYearStats.TotalRevenue += monthStats.Revenue;
				_currentYearStats.DiagnosisRevenue += monthStats.DiagnosisRevenue;
				_currentYearStats.TreatmentRevenue += monthStats.TreatmentRevenue;
				_currentYearStats.AverageHospitalValue += monthStats.HospitalValue;
				_currentYearStats.AverageProfitFactor += monthStats.ProfitFactor;
				_currentYearStats.NetProfit += monthStats.NetProfit;
				_currentYearStats.PositiveMonthlyNetProfitCount += monthStats.PositiveMonthlyNetProfitCount;
				_currentYearStats.AverageBalance += monthStats.Balance;
				_currentYearStats.AveragePhysicalAssetValue += monthStats.TotalPhysicalAssetValue;
				_currentYearStats.AverageLoans += monthStats.TotalLoans;
				_currentYearStats.AverageNumberOfStaff += monthStats.NumberOfStaff;
				_currentYearStats.AverageStaffPaySatisfaction += monthStats.StaffPaySatisfaction;
				_currentYearStats.AverageOverallReputation += monthStats.OverallReputation;
			}
			if (count2 > 0)
			{
				_currentYearStats.AverageHospitalValue /= count2;
				_currentYearStats.AverageProfitFactor /= count2;
				_currentYearStats.NetProfit /= count2;
				_currentYearStats.PositiveMonthlyNetProfitCount /= count2;
				_currentYearStats.AverageBalance /= count2;
				_currentYearStats.AveragePhysicalAssetValue /= count2;
				_currentYearStats.AverageLoans /= count2;
				_currentYearStats.AverageNumberOfStaff /= count2;
				_currentYearStats.AverageStaffPaySatisfaction /= count2;
				_currentYearStats.AverageOverallReputation /= count2;
			}
			_currentYearStats.TotalStaffWages = _financeManager.TotalStaffWages;
			foreach (Staff staffMember2 in _level.CharacterManager.StaffMembers)
			{
				_currentYearStats.TotalStaffWages += staffMember2.GetSalary();
				switch (staffMember2.Definition._type)
				{
				case StaffDefinition.Type.Doctor:
					_currentYearStats.NumberOfDoctors++;
					break;
				case StaffDefinition.Type.Nurse:
					_currentYearStats.NumberOfNurses++;
					break;
				case StaffDefinition.Type.Assistant:
					_currentYearStats.NumberOfAssistants++;
					break;
				case StaffDefinition.Type.Janitor:
					_currentYearStats.NumberOfJanitors++;
					break;
				}
			}
			_currentYearStats.PatientHappiness = _currentMonthStats.PatientHappiness;
			_currentYearStats.PatientHealth = _currentMonthStats.PatientHealth;
			_currentYearStats.NumberOfPatients = _level.CharacterManager.Patients.Count;
			OnYearCompleted.InvokeSafe(_currentYearStats);
			_currentYearStats = new YearStats
			{
				StartGameDate = new GameDate(year, 0, 0),
				HospitalValueAtStartOfYear = _currentYearStats.HospitalValueAtEndOfYear,
				HospitalLevelAtStartOfYear = _currentYearStats.HospitalLevelAtEndOfYear,
				OverallReputationAtStartOfYear = _currentYearStats.OverallReputationAtEndOfYear
			};
		}

		private void Debug_OutputHospitalProfitFactor()
		{
			CalculateHospitalValue();
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			_currentYearStats.NumberOfHiredStaff++;
			_cumulativeLevelStats.NumberOfHiredStaff++;
		}

		private void OnStaffFired(Staff staff)
		{
			_currentYearStats.NumberOfFiredStaff++;
			_cumulativeLevelStats.NumberOfHiredStaff++;
		}

		private void OnStaffReachedMaxXP(Staff staff, double timeTaken)
		{
			_currentMonthStats.NumStaffReachedMaxXP[(int)staff.Definition._type, staff.Rank]++;
			_currentMonthStats.TimeStaffReachedMaxXP[(int)staff.Definition._type, staff.Rank] += timeTaken;
		}

		private void OnStaffQualificationComplete(Staff staff, QualificationDefinition qualificationDefinition, Staff trainer)
		{
			_currentMonthStats.StaffTrained[(int)staff.Definition._type]++;
			_currentMonthStats.NumberOfStaffTrained++;
			_currentYearStats.StaffTrained[(int)staff.Definition._type]++;
			_currentYearStats.NumberOfStaffTrained++;
			_cumulativeLevelStats.NumberOfStaffTrained++;
		}

		private void OnStaffPromoted(Staff staff)
		{
			_currentMonthStats.StaffPromoted[(int)staff.Definition._type]++;
			_currentMonthStats.NumberOfStaffPromoted++;
			_currentYearStats.StaffPromoted[(int)staff.Definition._type]++;
			_currentYearStats.NumberOfStaffPromoted++;
			_cumulativeLevelStats.NumberOfStaffPromoted++;
		}

		private void OnMoneyEarned(int amount, Vector3? inWorldPosition)
		{
			_currentMonthStats.Revenue += amount;
			_cumulativeLevelStats.TotalRevenue += amount;
		}

		private void OnRegularExpense(int amount)
		{
			_currentMonthStats.RegularExpenses += amount;
			_cumulativeLevelStats.TotalRegularExpenses += amount;
		}

		private void OnRoomPurchased(Room room, int cost)
		{
			_currentMonthStats.BuildingRoomsExpenses += cost;
		}

		private void OnCharacterChargedForInteraction(Character character, FinanceModifier financeModifier, int amount, int baseAmount)
		{
			_currentMonthStats.TotalRetailSpend += amount;
		}

		private void OnPatientChargedForDiagnosis(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount)
		{
			_currentMonthStats.DiagnosisRevenue += amount;
		}

		private void OnPatientChargedForTreatment(Patient patient, Staff staff, Room room, int amount, int baseAmount)
		{
			_currentMonthStats.TreatmentRevenue += amount;
		}

		private void OnSporadicExpense(int amount)
		{
			_currentMonthStats.SporadicExpenses += amount;
		}

		private void OnResearchPointsAdded(float points, ResearchProject project)
		{
			_currentYearStats.TotalResearchPoints += points;
		}

		private void OnPatientSpawned(Patient patient)
		{
			_cumulativeLevelStats.NumberOfPatients++;
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			_currentMonthStats.NumberOfTreatmentCures++;
			_currentYearStats.NumberOfTreatmentCures++;
			_cumulativeLevelStats.NumberOfTreatmentCures++;
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				_cumulativeLevelStats.NumberOfAnachronisticTreatmentCures++;
			}
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			_currentMonthStats.NumberOfTreatmentIneffectives++;
			_currentYearStats.NumberOfTreatmentIneffectives++;
			_cumulativeLevelStats.NumberOfTreatmentIneffectives++;
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				_cumulativeLevelStats.NumberOfAnachronisticTreatmentIneffectives++;
			}
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			_currentMonthStats.NumberOfTreatmentFatals++;
			_currentYearStats.NumberOfTreatmentFatals++;
			_cumulativeLevelStats.NumberOfTreatmentFatals++;
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				_cumulativeLevelStats.NumberOfAnachronisticTreatmentFatals++;
			}
		}

		private void OnPatientRageQuit(Patient patient)
		{
			_currentMonthStats.NumberOfPatientRageQuits++;
			_currentYearStats.NumberOfPatientRageQuits++;
			_cumulativeLevelStats.NumberOfPatientRageQuits++;
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				_cumulativeLevelStats.NumberOfAnachronisticPatientRageQuits++;
			}
		}

		private void OnPatientDied(Patient patient)
		{
			_currentYearStats.NumberOfPatientDeaths++;
			_cumulativeLevelStats.NumberOfPatientDeaths++;
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				_cumulativeLevelStats.NumberOfAnachronisticPatientDeaths++;
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			AlienComponent component = patient.GetComponent<AlienComponent>();
			AnachronisticTreatmentComponent component2 = patient.GetComponent<AnachronisticTreatmentComponent>();
			if (component == null && component2 == null)
			{
				_currentMonthStats.NumberOfPatientsSentHome++;
				_currentYearStats.NumberOfPatientsSentHome++;
				_cumulativeLevelStats.NumberOfPatientsSentHome++;
			}
		}

		public void OnSilverAwardedEvent(int amount)
		{
			_currentYearStats.TotalSilverEarned += amount;
		}

		private void OnRoomItemPurchased(RoomItem roomItem)
		{
			_currentMonthStats.BuildingItemsExpenses += roomItem.Cost;
		}

		public RevenueBreakdown GetRevenueBreakdown(int numMonths)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (MonthStats previousMonthlyStat in GetPreviousMonthlyStats(numMonths))
			{
				num += previousMonthlyStat.DiagnosisRevenue;
				num2 += previousMonthlyStat.TreatmentRevenue;
				num3 += previousMonthlyStat.Revenue;
			}
			return new RevenueBreakdown
			{
				Treatment = num2,
				Diagnosis = num,
				Other = num3 - num2 - num
			};
		}

		public ExpensesBreakdown GetExpensesBreakdown(int numMonths)
		{
			int num = 0;
			int num2 = 0;
			foreach (MonthStats previousMonthlyStat in GetPreviousMonthlyStats(numMonths))
			{
				int num3 = previousMonthlyStat.TotalStaffWages / 12;
				num += num3;
				num2 += previousMonthlyStat.RegularExpenses - num3;
			}
			return new ExpensesBreakdown
			{
				Wages = num,
				Other = num2
			};
		}

		public void GetPreviousMonthsProfitAndLoss(int numMonths, out int expenses, out int revenue, out int profit)
		{
			List<MonthStats> previousMonthlyStats = GetPreviousMonthlyStats(numMonths);
			expenses = 0;
			revenue = 0;
			foreach (MonthStats item in previousMonthlyStats)
			{
				expenses += item.RegularExpenses;
				revenue += item.Revenue;
			}
			profit = revenue - expenses;
		}
	}
}
