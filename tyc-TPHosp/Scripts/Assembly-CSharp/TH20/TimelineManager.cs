using System;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class TimelineManager : MustCallDestroy
	{
		private float _elapsedTime;

		private int _day;

		private int _month;

		private int _year;

		private int _totalGameDaysPassed;

		private int _totalGameMonthsPassed;

		private int _totalGameYearsPassed;

		public Action<int, int, int> OnTimelineUpdated;

		public int Minutes
		{
			get
			{
				float num = 24f * _elapsedTime / GameAlgorithms.Config.SecondsPerDay;
				float num2 = num - Mathf.Floor(num);
				return Mathf.FloorToInt(60f * num2);
			}
		}

		public int Hour => Mathf.FloorToInt(24f * _elapsedTime / GameAlgorithms.Config.SecondsPerDay);

		public int Day => _day;

		public int Month => _month;

		public int Year => _year;

		public GameDate CurrentGameDate => new GameDate(_year, _month, _day);

		public GameDate CurrentGameDateAndTime => new GameDate(_year, _month, _day, Hour, Minutes);

		public int TotalGameDaysPassed => _totalGameDaysPassed;

		public int TotalGameMonthsPassed => _totalGameMonthsPassed;

		public int TotalGameYearsPassed => _totalGameYearsPassed;

		public TimelineManager()
		{
			ConsoleCommandsDatabase.RegisterCommand("SetDayOfMonth", "Sets the day of the month", "SetDayOfMonth [Day]", DebugSetDayOfMonth);
			ConsoleCommandsDatabase.RegisterCommand("SetMonthOfYear", "Sets the month of the year", "SetMonthOfYear [Month]", DebugSetMonthOfYear);
			ConsoleCommandsDatabase.RegisterCommand("SetYear", "Sets the year number", "SetYear [Year]", DebugSetYear);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("SetDayOfMonth");
			ConsoleCommandsDatabase.UnRegisterCommand("SetMonthOfYear");
			ConsoleCommandsDatabase.UnRegisterCommand("SetYear");
			base.Destroy();
		}

		public void Update(float deltaTime)
		{
			_elapsedTime += deltaTime;
			while (_elapsedTime >= GameAlgorithms.Config.SecondsPerDay)
			{
				_elapsedTime -= GameAlgorithms.Config.SecondsPerDay;
				_day++;
				_totalGameDaysPassed++;
				if (_day == GameDate.GetDaysInMonth(_month))
				{
					_day = 0;
					_month++;
					_totalGameMonthsPassed++;
					if (_month >= 12)
					{
						_day = 0;
						_month = 0;
						_year++;
						_totalGameYearsPassed++;
					}
				}
				OnTimelineUpdated.InvokeSafe(_day, _month, _year);
			}
		}

		private ConsoleCommandResult DebugSetDayOfMonth(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int x)
			{
				_day = x;
			}, args);
		}

		private ConsoleCommandResult DebugSetMonthOfYear(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int x)
			{
				_month = x;
			}, args);
		}

		private ConsoleCommandResult DebugSetYear(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int x)
			{
				_year = x;
			}, args);
		}
	}
}
