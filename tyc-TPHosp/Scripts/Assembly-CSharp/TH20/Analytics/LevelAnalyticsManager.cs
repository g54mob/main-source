using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20.Analytics
{
	public class LevelAnalyticsManager : MustCallDestroy
	{
		private class IllnessStats
		{
			public int Cures;

			public int Ineffectives;

			public int Fatals;

			public int DiagnosedCount;

			public double TotalDiagnosisDuration;

			public int TreatmentRevenue;

			public int DiagnosisRevenue;
		}

		private class RoomTypeStats
		{
			public int MoneyEarned;

			public int TotalPatientVisits;

			public double TotalPatientDuration;

			public int MinTileCount = int.MaxValue;

			public int MaxTileCount = int.MinValue;

			public int MinPrestige = int.MaxValue;

			public int MaxPrestige = int.MinValue;
		}

		public struct BatchedPatientSpawnData
		{
			public IllnessDefinition illness;

			public float illnessReputation;
		}

		public struct BatchedPatientDestroyData
		{
			public Patient.Mode patientMode;

			public int numOfDiagnosis;

			public double totalTimeInHospital;

			public int moneySpent;

			public IllnessDefinition illness;

			public Character.ReasonForLeavingHospital reasonForLeaving;
		}

		[DontSave]
		private AnalyticsManager _analyticsManager;

		private Level _level;

		private TimelineManager _timelineManager;

		private LevelStatsDatabase _levelStatsDatabase;

		private FinanceManager _financeManager;

		private Dictionary<string, IllnessStats> _illnessStatsInAYear = new Dictionary<string, IllnessStats>();

		private Dictionary<RoomDefinition.Type, RoomTypeStats> _roomTypeStatsInAMonth = new Dictionary<RoomDefinition.Type, RoomTypeStats>();

		private int _monthlySnackVendingMachineRevenue;

		private int _monthlyDrinkVendingMachineRevenue;

		private int _monthlyArcadeMachineRevenue;

		private int _monthlyShopFinanceRevenue;

		[DontSave]
		public bool bUseBatchedPatientEvents = true;

		[DontSave]
		private List<BatchedPatientSpawnData> BatchedPatientSpawnDataList;

		[DontSave]
		private List<BatchedPatientDestroyData> BatchedPatientDestroyDataList;

		private double[] _prevMonthTimeScaleDurations;

		public LevelAnalyticsManager(AnalyticsManager analyticsManager, Level level, TimelineManager timelineManager, LevelStatsDatabase levelStatsDatabase, FinanceManager financeManager)
		{
			_analyticsManager = analyticsManager;
			_level = level;
			_timelineManager = timelineManager;
			_levelStatsDatabase = levelStatsDatabase;
			_financeManager = financeManager;
			InitBatchedPatientData();
			RegisterEvents();
		}

		public void RestoreFromSave(AnalyticsManager analyticsManager)
		{
			_analyticsManager = analyticsManager;
			InitBatchedPatientData();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			FinanceManager financeManager = _financeManager;
			financeManager.OnMoneyEarnedInRoom = (Action<int, Room>)Delegate.Combine(financeManager.OnMoneyEarnedInRoom, new Action<int, Room>(OnMoneyEarnedInRoom));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Combine(financeManager2.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Combine(financeManager3.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager4 = _financeManager;
			financeManager4.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Combine(financeManager4.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents3.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Combine(characterEvents4.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnLeaveRoom = (Action<Character, Room, double>)Delegate.Combine(characterEvents5.OnLeaveRoom, new Action<Character, Room, double>(OnLeaveRoom));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents6.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents7.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			LevelStatsDatabase levelStatsDatabase = _levelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			LevelStatsDatabase levelStatsDatabase2 = _levelStatsDatabase;
			levelStatsDatabase2.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Combine(levelStatsDatabase2.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(OnYearCompleted));
		}

		private void UnRegisterEvents()
		{
			FinanceManager financeManager = _financeManager;
			financeManager.OnMoneyEarnedInRoom = (Action<int, Room>)Delegate.Remove(financeManager.OnMoneyEarnedInRoom, new Action<int, Room>(OnMoneyEarnedInRoom));
			FinanceManager financeManager2 = _financeManager;
			financeManager2.OnCharacterChargedForInteraction = (Action<Character, FinanceModifier, int, int>)Delegate.Remove(financeManager2.OnCharacterChargedForInteraction, new Action<Character, FinanceModifier, int, int>(OnCharacterChargedForInteraction));
			FinanceManager financeManager3 = _financeManager;
			financeManager3.OnPatientChargedForDiagnosis = (FinanceManager.PatientChargedForDiagnosisDelegate)Delegate.Remove(financeManager3.OnPatientChargedForDiagnosis, new FinanceManager.PatientChargedForDiagnosisDelegate(OnPatientChargedForDiagnosis));
			FinanceManager financeManager4 = _financeManager;
			financeManager4.OnPatientChargedForTreatment = (FinanceManager.PatientChargedForTreatmentDelegate)Delegate.Remove(financeManager4.OnPatientChargedForTreatment, new FinanceManager.PatientChargedForTreatmentDelegate(OnPatientChargedForTreatment));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents3.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Remove(characterEvents4.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			CharacterEvents characterEvents5 = _level.CharacterEvents;
			characterEvents5.OnLeaveRoom = (Action<Character, Room, double>)Delegate.Remove(characterEvents5.OnLeaveRoom, new Action<Character, Room, double>(OnLeaveRoom));
			CharacterEvents characterEvents6 = _level.CharacterEvents;
			characterEvents6.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents6.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents7 = _level.CharacterEvents;
			characterEvents7.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents7.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			LevelStatsDatabase levelStatsDatabase = _levelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			LevelStatsDatabase levelStatsDatabase2 = _levelStatsDatabase;
			levelStatsDatabase2.OnYearCompleted = (Action<LevelStatsDatabase.YearStats>)Delegate.Remove(levelStatsDatabase2.OnYearCompleted, new Action<LevelStatsDatabase.YearStats>(OnYearCompleted));
		}

		private void OnMoneyEarnedInRoom(int amount, Room room)
		{
			if (!_roomTypeStatsInAMonth.TryGetValue(room.Definition._type, out var value))
			{
				value = new RoomTypeStats();
				_roomTypeStatsInAMonth[room.Definition._type] = value;
			}
			value.MoneyEarned += amount;
		}

		private void OnCharacterChargedForInteraction(Character character, FinanceModifier financeModifier, int amount, int baseAmount)
		{
			switch (financeModifier.Type)
			{
			case FinanceModifier.EType.ArcadeMachine:
				_monthlyArcadeMachineRevenue += amount;
				break;
			case FinanceModifier.EType.VendingMachine_Drink:
				_monthlyDrinkVendingMachineRevenue += amount;
				break;
			case FinanceModifier.EType.VendingMachine_Snack:
				_monthlySnackVendingMachineRevenue += amount;
				break;
			case FinanceModifier.EType.Shop:
				_monthlyShopFinanceRevenue += amount;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case FinanceModifier.EType.None:
				break;
			}
		}

		private void OnPatientChargedForDiagnosis(Patient patient, Staff staff, Room room, float certaintyIncrement, int amount, int baseAmount)
		{
			string key = GeAnalyticstIllnessName(patient.Illness);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.DiagnosisRevenue += amount;
		}

		private void OnPatientChargedForTreatment(Patient patient, Staff staff, Room room, int amount, int baseAmount)
		{
			string key = GeAnalyticstIllnessName(patient.Illness);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.TreatmentRevenue += amount;
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			string key = GeAnalyticstIllnessName(patient.Illness);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.Cures++;
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			string key = GeAnalyticstIllnessName(patient.Illness);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.Ineffectives++;
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			string key = GeAnalyticstIllnessName(patient.Illness);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.Fatals++;
		}

		private void OnIllnessDiagnosed(Patient patient, IllnessDefinition illnessDefinition)
		{
			string key = GeAnalyticstIllnessName(illnessDefinition);
			if (!_illnessStatsInAYear.TryGetValue(key, out var value))
			{
				value = new IllnessStats();
				_illnessStatsInAYear[key] = value;
			}
			value.DiagnosedCount++;
			value.TotalDiagnosisDuration += patient.TotalTimeInHospital;
		}

		private void OnLeaveRoom(Character character, Room room, double durationInRoom)
		{
			if (character is Patient)
			{
				if (!_roomTypeStatsInAMonth.TryGetValue(room.Definition._type, out var value))
				{
					value = new RoomTypeStats();
					_roomTypeStatsInAMonth[room.Definition._type] = value;
				}
				value.TotalPatientVisits++;
				value.TotalPatientDuration += durationInRoom;
			}
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			if (!_roomTypeStatsInAMonth.TryGetValue(room.Definition._type, out var value))
			{
				value = new RoomTypeStats();
				_roomTypeStatsInAMonth[room.Definition._type] = value;
			}
			RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(room.FloorPlan);
			int tileCount = room.FloorPlan.TileCount;
			value.MinPrestige = Math.Min(value.MinPrestige, roomPrestige.Level);
			value.MaxPrestige = Math.Max(value.MaxPrestige, roomPrestige.Level);
			value.MinTileCount = Math.Min(value.MinTileCount, tileCount);
			value.MaxTileCount = Math.Max(value.MaxTileCount, tileCount);
		}

		private void OnPatientSpawned(Patient patient)
		{
			AddBatchedPatientSpawnData(patient);
		}

		private void OnPatientDestroyed(Patient patient)
		{
			AddBatchedPatientDestroyData(patient);
		}

		private void OnMonthCompleted(LevelStatsDatabase.MonthStats monthStats)
		{
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.MonthSummaryInfo).AddLevelHeader(_level).AddGameDate(ref monthStats.EndGameDate, addYear: true, addMonth: true, addDays: false).AddParam("patientCount", monthStats.NumberOfPatients)
				.AddParam("doctorCount", monthStats.NumberOfDoctors)
				.AddParam("nurseCount", monthStats.NumberOfNurses)
				.AddParam("janitorCount", monthStats.NumberOfJanitors)
				.AddParam("assistantCount", monthStats.NumberOfAssistants)
				.AddParam("staffRank1", monthStats.NumberOfStaffRank[0])
				.AddParam("staffRank2", monthStats.NumberOfStaffRank[1])
				.AddParam("staffRank3", monthStats.NumberOfStaffRank[2])
				.AddParam("staffRank4", monthStats.NumberOfStaffRank[3])
				.AddParam("staffRank5", monthStats.NumberOfStaffRank[4])
				.AddParam("doctorMaxXPRank1", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Doctor, 0))
				.AddParam("doctorMaxXPRank2", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Doctor, 1))
				.AddParam("doctorMaxXPRank3", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Doctor, 2))
				.AddParam("doctorMaxXPRank4", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Doctor, 3))
				.AddParam("doctorMaxXPRank5", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Doctor, 4))
				.AddParam("nurseMaxXPRank1", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Nurse, 0))
				.AddParam("nurseMaxXPRank2", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Nurse, 1))
				.AddParam("nurseMaxXPRank3", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Nurse, 2))
				.AddParam("nurseMaxXPRank4", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Nurse, 3))
				.AddParam("nurseMaxXPRank5", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Nurse, 4))
				.AddParam("janitorMaxXPRank1", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Janitor, 0))
				.AddParam("janitorMaxXPRank2", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Janitor, 1))
				.AddParam("janitorMaxXPRank3", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Janitor, 2))
				.AddParam("janitorMaxXPRank4", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Janitor, 3))
				.AddParam("janitorMaxXPRank5", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Janitor, 4))
				.AddParam("assistantMaxXPRank1", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Assistant, 0))
				.AddParam("assistantMaxXPRank2", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Assistant, 1))
				.AddParam("assistantMaxXPRank3", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Assistant, 2))
				.AddParam("assistantMaxXPRank4", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Assistant, 3))
				.AddParam("assistantMaxXPRank5", monthStats.GetAverageTimeStaffTookToReachMaxXP(StaffDefinition.Type.Assistant, 4))
				.AddParam("totalDoctorSalary", monthStats.TotalDoctorSalary)
				.AddParam("totalNurseSalary", monthStats.TotalNurseSalary)
				.AddParam("totalJanitorSalary", monthStats.TotalJanitorSalary)
				.AddParam("totalAssistantSalary", monthStats.TotalAssistantSalary)
				.AddParam("staffDesiredPayDifference", monthStats.StaffPaySatisfaction)
				.AddParam("buildingItemsExpenses", monthStats.BuildingItemsExpenses)
				.AddParam("buildingRoomsExpenses", monthStats.BuildingRoomsExpenses)
				.AddParam("nursesMorale", monthStats.NursesMorale)
				.AddParam("assistantsMorale", monthStats.AssistantsMorale)
				.AddParam("janitorsMorale", monthStats.JanitorsMorale)
				.AddParam("doctorsMorale", monthStats.DoctorsMorale)
				.AddParam("overallReputation", monthStats.OverallReputation)
				.AddParam("priceReputation", monthStats.PriceReputation)
				.AddParam("patientReputation", monthStats.PatientReputation)
				.AddParam("specialReputation", monthStats.SpecialReputation)
				.AddParam("staffReputation", monthStats.StaffReputation)
				.AddParam("medicalReputation", monthStats.MedicalReputation)
				.AddParam("snackVendingMachineRevenue", _monthlySnackVendingMachineRevenue)
				.AddParam("drinkVendingMachineRevenue", _monthlyDrinkVendingMachineRevenue)
				.AddParam("arcadeMachineRevenue", _monthlyArcadeMachineRevenue)
				.AddParam("shopFinanceRevenue", _monthlyShopFinanceRevenue)
				.AddParam("regularExpenses", monthStats.RegularExpenses)
				.AddParam("sporadicExpenses", monthStats.SporadicExpenses)
				.AddParam("totalLoans", monthStats.TotalLoans)
				.AddParam("moneyEarned", monthStats.Revenue)
				.AddParam("netAssetValue", monthStats.NetAssetValue)
				.AddParam("netIncome", monthStats.NetIncome)
				.AddParam("totalAssetValue", monthStats.TotalPhysicalAssetValue)
				.AddParam("balance", monthStats.Balance)
				.AddParam("hospitalValue", monthStats.HospitalValue);
			AddParamMonthTimeScaleDurations(gameEvent);
			_analyticsManager.RecordEvent(gameEvent);
			_monthlySnackVendingMachineRevenue = 0;
			_monthlyDrinkVendingMachineRevenue = 0;
			_monthlyArcadeMachineRevenue = 0;
			_monthlyShopFinanceRevenue = 0;
			SendBatchedPatientSpawnData();
			SendBatchedPatientDestroyData();
			SendBatchedMonthlyRoomTypeSummaryData();
		}

		private void OnYearCompleted(LevelStatsDatabase.YearStats yearStats)
		{
			foreach (KeyValuePair<string, IllnessStats> item in _illnessStatsInAYear)
			{
				string key = item.Key;
				IllnessStats value = item.Value;
				double num = value.TotalDiagnosisDuration / (double)value.DiagnosedCount;
				GameEvent gameEvent = new GameEvent(_analyticsManager.Config.AnnualIllnessSummaryInfo).AddLevelHeader(_level).AddGameDate(ref yearStats.EndGameDate, addYear: true, addMonth: false, addDays: false).AddParam("illnessName", key)
					.AddParam("cures", value.Cures)
					.AddParam("ineffectives", value.Ineffectives)
					.AddParam("fatals", value.Fatals)
					.AddParam("treatmentRevenue", value.TreatmentRevenue)
					.AddParam("diagnosisRevenue", value.DiagnosisRevenue)
					.AddParam("averageDiagnosisDuration", num);
				_analyticsManager.RecordEvent(gameEvent);
				value.Cures = 0;
				value.Ineffectives = 0;
				value.Fatals = 0;
				value.TotalDiagnosisDuration = 0.0;
				value.DiagnosedCount = 0;
				value.DiagnosisRevenue = 0;
				value.TreatmentRevenue = 0;
			}
		}

		public void SendSandboxSetupData()
		{
			if (_level != null && _level.IsSandbox())
			{
				GameEvent gameEvent = new GameEvent(_analyticsManager.Config.SandboxSetupInfo);
				_level.GetSandboxSettings().AddSetupAnalyticsEventData(gameEvent, _level);
				_analyticsManager.RecordEvent(gameEvent);
			}
		}

		private void InitBatchedPatientData()
		{
			if (bUseBatchedPatientEvents)
			{
				BatchedPatientSpawnDataList = new List<BatchedPatientSpawnData>();
				BatchedPatientDestroyDataList = new List<BatchedPatientDestroyData>();
			}
		}

		private void ResetBatchedPatientSpawnData()
		{
			BatchedPatientSpawnDataList.Clear();
		}

		private void ResetBatchedPatientDestroyData()
		{
			BatchedPatientDestroyDataList.Clear();
		}

		private void AddBatchedPatientSpawnData(Patient patient)
		{
			if (bUseBatchedPatientEvents)
			{
				BatchedPatientSpawnData item = new BatchedPatientSpawnData
				{
					illness = patient.Illness,
					illnessReputation = _level.ReputationTracker.GetIllnessReputation(patient.Illness)
				};
				BatchedPatientSpawnDataList.Add(item);
			}
		}

		private void AddBatchedPatientDestroyData(Patient patient)
		{
			if (bUseBatchedPatientEvents)
			{
				BatchedPatientDestroyData item = new BatchedPatientDestroyData
				{
					patientMode = patient.CurrentMode,
					numOfDiagnosis = patient.NumOfDiagnosis,
					totalTimeInHospital = patient.TotalTimeInHospital,
					moneySpent = patient.MoneySpent,
					illness = patient.Illness,
					reasonForLeaving = patient.ReasonForLeaving
				};
				BatchedPatientDestroyDataList.Add(item);
			}
		}

		private void SendBatchedPatientSpawnData()
		{
			if (!bUseBatchedPatientEvents || BatchedPatientSpawnDataList.Count <= 0)
			{
				return;
			}
			GameDate gameDate = _timelineManager.CurrentGameDate;
			List<EventParameters> list = new List<EventParameters>(BatchedPatientSpawnDataList.Count);
			foreach (BatchedPatientSpawnData batchedPatientSpawnData in BatchedPatientSpawnDataList)
			{
				EventParameters item = new EventParameters().AddParam("illness", batchedPatientSpawnData.illness.Name.ToString()).AddParam("reputation", batchedPatientSpawnData.illnessReputation);
				list.Add(item);
			}
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.BatchedSpawnPatientInfo).AddLevelHeader(_level).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: false).AddParam("numSpawnPatientItems", list.Count)
				.AddParam("spawnPatientData", list);
			_analyticsManager.RecordEvent(gameEvent);
			ResetBatchedPatientSpawnData();
		}

		private void SendBatchedPatientDestroyData()
		{
			if (!bUseBatchedPatientEvents || BatchedPatientDestroyDataList.Count <= 0)
			{
				return;
			}
			GameDate gameDate = _timelineManager.CurrentGameDate;
			List<EventParameters> list = new List<EventParameters>(BatchedPatientDestroyDataList.Count);
			foreach (BatchedPatientDestroyData batchedPatientDestroyData in BatchedPatientDestroyDataList)
			{
				EventParameters item = new EventParameters().AddParam("patientMode", batchedPatientDestroyData.patientMode.ToString()).AddParam("numOfDiagnosis", batchedPatientDestroyData.numOfDiagnosis).AddParam("totalTimeInHospital", batchedPatientDestroyData.totalTimeInHospital)
					.AddParam("moneySpent", batchedPatientDestroyData.moneySpent)
					.AddParam("illness", batchedPatientDestroyData.illness.Name.ToString())
					.AddParam("reasonForLeaving", batchedPatientDestroyData.reasonForLeaving.ToString());
				list.Add(item);
			}
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.BatchedDestroyPatientInfo).AddLevelHeader(_level).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: false).AddParam("numDestroyPatientItems", list.Count)
				.AddParam("destroyPatientData", list);
			_analyticsManager.RecordEvent(gameEvent);
			ResetBatchedPatientDestroyData();
		}

		private void AddParamMonthTimeScaleDurations(GameEvent monthSummaryEvent)
		{
			if (monthSummaryEvent == null)
			{
				return;
			}
			int num = Mathf.Min(_level.GameTime.ReleaseMaxTimeScaleIndex + 1, _level.TimeScaleDurations.Length);
			if (num > 0)
			{
				if (_prevMonthTimeScaleDurations == null)
				{
					_prevMonthTimeScaleDurations = new double[num];
				}
				float[] array = new float[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = (float)(_level.TimeScaleDurations[i] - _prevMonthTimeScaleDurations[i]);
					_prevMonthTimeScaleDurations[i] = _level.TimeScaleDurations[i];
				}
				monthSummaryEvent.AddParam("monthTimeScaleDurations", array);
			}
		}

		private void SendBatchedMonthlyRoomTypeSummaryData()
		{
			int count = _roomTypeStatsInAMonth.Count;
			if (_roomTypeStatsInAMonth == null || count <= 0)
			{
				return;
			}
			int length = Enum.GetValues(typeof(RoomDefinition.Type)).Length;
			int[] array = new int[length];
			int[] array2 = new int[length];
			int i = 0;
			for (int count2 = _level.WorldState.AllRooms.Count; i < count2; i++)
			{
				int type = (int)_level.WorldState.AllRooms[i].Definition._type;
				array[type]++;
				array2[type] += _level.WorldState.AllRooms[i].FloorPlan.GetNumPlacedItems();
			}
			List<EventParameters> list = new List<EventParameters>(count);
			foreach (KeyValuePair<RoomDefinition.Type, RoomTypeStats> item2 in _roomTypeStatsInAMonth)
			{
				RoomDefinition.Type key = item2.Key;
				RoomTypeStats value = item2.Value;
				double num = 0.0;
				if (value.TotalPatientVisits > 0)
				{
					num = value.TotalPatientDuration / (double)value.TotalPatientVisits;
				}
				EventParameters item = new EventParameters().AddParam("type", key.ToString()).AddParam("count", array[(int)key]).AddParam("moneyEarned", value.MoneyEarned)
					.AddParam("avePatientDurn", num)
					.AddParam("minPrestige", value.MinPrestige)
					.AddParam("maxPrestige", value.MaxPrestige)
					.AddParam("minTiles", value.MinTileCount)
					.AddParam("maxTiles", value.MaxTileCount)
					.AddParam("placedItemCount", array2[(int)key]);
				list.Add(item);
				value.MoneyEarned = 0;
				value.TotalPatientDuration = 0.0;
				value.TotalPatientVisits = 0;
			}
			GameDate gameDate = _timelineManager.CurrentGameDate;
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.BatchedMonthlyRoomTypeSummaryInfo).AddLevelHeader(_level).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: false).AddParam("numRoomTypeSummaryItems", list.Count)
				.AddParam("roomTypeSummaryData", list);
			_analyticsManager.RecordEvent(gameEvent);
		}

		public string GeAnalyticstIllnessName(IllnessDefinition illness)
		{
			return AnalyticsManager.ToFriendlyEventName(illness.Name.ToAnalyticsTermString().Replace("_Name", ""));
		}

		public override void Destroy()
		{
			GameDate gameDate = _timelineManager.CurrentGameDate;
			GameEvent gameEvent = new GameEvent(_analyticsManager.Config.EndLevelInfo).AddLevelHeader(_level).AddGameDate(ref gameDate, addYear: true, addMonth: true, addDays: true).AddParam("durationRealtime", (DateTime.UtcNow - _level.RealWorldInitTime).TotalSeconds)
				.AddParam("pauseDurationRealtime", _level.GameTime.SuperPausedDuration);
			_analyticsManager.RecordEvent(gameEvent);
			UnRegisterEvents();
			base.Destroy();
		}
	}
}
