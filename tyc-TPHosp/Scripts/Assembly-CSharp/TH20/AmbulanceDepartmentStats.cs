using System;
using System.Collections.Generic;
using System.Linq;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class AmbulanceDepartmentStats
	{
		public enum AmbulanceDepartmentStat
		{
			PatientsCollected = 0,
			PatientsCured = 1,
			PatientsDied = 2,
			PatientsCureFailed = 3,
			DepartmentReputation = 4,
			NUM_STATS = 5
		}

		private AmbulanceDepartmentStatsContainer _lastMonthStats;

		private AmbulanceDepartmentStatsContainer _lastYearStats;

		private AmbulanceDepartmentStatsContainer _currentMonthStats;

		private AmbulanceDepartmentStatsContainer _currentYearStats;

		private Queue<LineGraph.DataVector2>[] _monthlyStats;

		private Queue<LineGraph.DataVector2>[] _yearlyStats;

		private TimelineManager _timelineManager;

		private Dictionary<AmbulanceDepartmentStat, int> _leagueMonthlyPositions;

		private Dictionary<AmbulanceDepartmentStat, int> _leagueYearlyPositions;

		private const int MonthsToShow = 12;

		private const int YearsToShow = 12;

		private bool _useDebugStats;

		public AmbulanceDepartmentStatsContainer LastMonthStats => _lastMonthStats;

		public AmbulanceDepartmentStatsContainer LastYearStats => _lastMonthStats;

		public AmbulanceDepartmentStatsContainer CurrentMonthStats => _currentMonthStats;

		public AmbulanceDepartmentStatsContainer CurrentYearStats => _currentYearStats;

		public int GetMonthlyLeaguePosition(AmbulanceDepartmentStat stat)
		{
			if (!_leagueMonthlyPositions.TryGetValue(stat, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetYearlyLeaguePosition(AmbulanceDepartmentStat stat)
		{
			if (!_leagueYearlyPositions.TryGetValue(stat, out var value))
			{
				return 0;
			}
			return value;
		}

		public AmbulanceDepartmentStats(TimelineManager timelineManager)
		{
			_monthlyStats = new Queue<LineGraph.DataVector2>[5];
			for (int i = 0; i < _monthlyStats.Length; i++)
			{
				_monthlyStats[i] = new Queue<LineGraph.DataVector2>();
			}
			_yearlyStats = new Queue<LineGraph.DataVector2>[5];
			for (int j = 0; j < _yearlyStats.Length; j++)
			{
				_yearlyStats[j] = new Queue<LineGraph.DataVector2>();
			}
			_currentMonthStats = new AmbulanceDepartmentStatsContainer();
			_currentYearStats = new AmbulanceDepartmentStatsContainer();
			_lastMonthStats = new AmbulanceDepartmentStatsContainer();
			_lastYearStats = new AmbulanceDepartmentStatsContainer();
			_timelineManager = timelineManager;
			TimelineManager timelineManager2 = _timelineManager;
			timelineManager2.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager2.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			_leagueMonthlyPositions = new Dictionary<AmbulanceDepartmentStat, int>();
			_leagueYearlyPositions = new Dictionary<AmbulanceDepartmentStat, int>();
		}

		~AmbulanceDepartmentStats()
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
		}

		public void RestoreFromSave()
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			if (_lastMonthStats == null)
			{
				_lastMonthStats = new AmbulanceDepartmentStatsContainer();
			}
			if (_lastYearStats == null)
			{
				_lastYearStats = new AmbulanceDepartmentStatsContainer();
			}
			if (_leagueMonthlyPositions == null)
			{
				_leagueMonthlyPositions = new Dictionary<AmbulanceDepartmentStat, int>();
			}
			if (_leagueYearlyPositions == null)
			{
				_leagueYearlyPositions = new Dictionary<AmbulanceDepartmentStat, int>();
			}
		}

		public void IncrementStats(AmbulanceDepartmentStatsContainer additionalStats)
		{
			_currentMonthStats.IncrementStats(additionalStats);
			_currentYearStats.IncrementStats(additionalStats);
		}

		public void IncrementStat(AmbulanceDepartmentStat statType, int value = 1)
		{
			_currentMonthStats.IncrementStat(statType, value);
			_currentYearStats.IncrementStat(statType, value);
		}

		public void PushReputationScore(int score)
		{
			_currentMonthStats.DepartmentReputation.Add(score);
			_currentYearStats.DepartmentReputation.Add(score);
		}

		public static bool ShouldInvertScore(AmbulanceDepartmentStat statType)
		{
			if (statType != AmbulanceDepartmentStat.PatientsDied)
			{
				return statType == AmbulanceDepartmentStat.PatientsCureFailed;
			}
			return true;
		}

		public List<LineGraph.DataVector2> GetMonthlyHistoryForStat(AmbulanceDepartmentStat stat)
		{
			return _monthlyStats[(int)stat].ToList();
		}

		public List<LineGraph.DataVector2> GetYearlyHistoryForStat(AmbulanceDepartmentStat stat)
		{
			return _yearlyStats[(int)stat].ToList();
		}

		public void UpdateMonthlyLeaguePosition(AmbulanceDepartmentStat stat, int currentPosition)
		{
			if (!_leagueMonthlyPositions.ContainsKey(stat))
			{
				_leagueMonthlyPositions.Add(stat, currentPosition);
			}
			else
			{
				_leagueMonthlyPositions[stat] = currentPosition;
			}
		}

		public void UpdateYearlyLeaguePosition(AmbulanceDepartmentStat stat, int currentPosition)
		{
			if (!_leagueYearlyPositions.ContainsKey(stat))
			{
				_leagueYearlyPositions.Add(stat, currentPosition);
			}
			else
			{
				_leagueYearlyPositions[stat] = currentPosition;
			}
		}

		public void SetDebugStats(int monthsAmount, int yearsAmount)
		{
			_useDebugStats = true;
			List<int> departmentReputation = new List<int>
			{
				UnityEngine.Random.Range(0, 100),
				UnityEngine.Random.Range(0, 100),
				UnityEngine.Random.Range(0, 100)
			};
			_currentMonthStats = new AmbulanceDepartmentStatsContainer(UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), departmentReputation);
			List<int> departmentReputation2 = new List<int>
			{
				UnityEngine.Random.Range(0, 100),
				UnityEngine.Random.Range(0, 100),
				UnityEngine.Random.Range(0, 100)
			};
			_currentYearStats = new AmbulanceDepartmentStatsContainer(UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), UnityEngine.Random.Range(0, 50), departmentReputation2);
			Queue<LineGraph.DataVector2>[] monthlyStats = _monthlyStats;
			for (int i = 0; i < monthlyStats.Length; i++)
			{
				monthlyStats[i].Clear();
			}
			monthlyStats = _yearlyStats;
			for (int i = 0; i < monthlyStats.Length; i++)
			{
				monthlyStats[i].Clear();
			}
			for (int j = 0; j < monthsAmount; j++)
			{
				_monthlyStats[0].Enqueue(new LineGraph.DataVector2(j, UnityEngine.Random.Range(0, 50)));
				_monthlyStats[1].Enqueue(new LineGraph.DataVector2(j, UnityEngine.Random.Range(0, 100)));
				_monthlyStats[2].Enqueue(new LineGraph.DataVector2(j, UnityEngine.Random.Range(0, 100)));
				_monthlyStats[3].Enqueue(new LineGraph.DataVector2(j, UnityEngine.Random.Range(0, 100)));
				_monthlyStats[4].Enqueue(new LineGraph.DataVector2(j, UnityEngine.Random.Range(0, 100)));
			}
			for (int k = 0; k < yearsAmount; k++)
			{
				_yearlyStats[0].Enqueue(new LineGraph.DataVector2(k, UnityEngine.Random.Range(0, 100)));
				_yearlyStats[1].Enqueue(new LineGraph.DataVector2(k, UnityEngine.Random.Range(0, 100)));
				_yearlyStats[2].Enqueue(new LineGraph.DataVector2(k, UnityEngine.Random.Range(0, 100)));
				_yearlyStats[3].Enqueue(new LineGraph.DataVector2(k, UnityEngine.Random.Range(0, 100)));
				_yearlyStats[4].Enqueue(new LineGraph.DataVector2(k, UnityEngine.Random.Range(0, 100)));
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day == 0 && !_useDebugStats)
			{
				if (month == 0)
				{
					ReportStats(_yearlyStats, _currentYearStats, year - 1, 12, ref _lastYearStats);
				}
				month = ((month == 0) ? 12 : (month - 1));
				ReportStats(_monthlyStats, _currentMonthStats, month, 12, ref _lastMonthStats);
			}
		}

		private void ReportStats(Queue<LineGraph.DataVector2>[] statToReport, AmbulanceDepartmentStatsContainer currentStats, int recordIndex, int valuesToShow, ref AmbulanceDepartmentStatsContainer previousStats)
		{
			float num = currentStats.PatientsCollected;
			int stat = currentStats.GetStat(AmbulanceDepartmentStat.PatientsCured);
			int stat2 = currentStats.GetStat(AmbulanceDepartmentStat.PatientsDied);
			int stat3 = currentStats.GetStat(AmbulanceDepartmentStat.PatientsCureFailed);
			int stat4 = currentStats.GetStat(AmbulanceDepartmentStat.DepartmentReputation);
			statToReport[0].Enqueue(new LineGraph.DataVector2(recordIndex, num));
			statToReport[1].Enqueue(new LineGraph.DataVector2(recordIndex, stat));
			statToReport[2].Enqueue(new LineGraph.DataVector2(recordIndex, stat2));
			statToReport[3].Enqueue(new LineGraph.DataVector2(recordIndex, stat3));
			statToReport[4].Enqueue(new LineGraph.DataVector2(recordIndex, stat4));
			for (int i = 0; i < statToReport.Length; i++)
			{
				if (statToReport[i].Count > valuesToShow)
				{
					statToReport[i].Dequeue();
				}
			}
			previousStats = new AmbulanceDepartmentStatsContainer(currentStats);
			currentStats.ResetStats();
		}
	}
}
