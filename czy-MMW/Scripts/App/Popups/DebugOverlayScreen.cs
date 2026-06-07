using System;
using Factory;
using JetBrains.Annotations;
using Motorways;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
	public class DebugOverlayScreen : BasePopup
	{
		[SerializeField]
		private TouchOptionButton _yearSelector;

		[SerializeField]
		private TouchOptionButton _monthSelector;

		[SerializeField]
		private Button[] _calendarDayButtons = new Button[31];

		[Dependency]
		private ChallengeSystem _challengeSystem;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private PopupStack _popupStack;

		private const int _startingYear = 2022;

		private int _currentYear = 2023;

		private int _currentMonth;

		private void Start()
		{
			_currentYear = GameDateTime.UtcNow.Year;
			_currentMonth = GameDateTime.UtcNow.Month;
			_yearSelector.SetOption(_currentYear - 2022);
			_monthSelector.SetOption(_currentMonth - 1);
		}

		public void OnYearChanged()
		{
			_currentYear = 2022 + _yearSelector.SelectedOptionIndex;
			UpdateCalendar();
		}

		public void OnMonthChanged()
		{
			_currentMonth = _monthSelector.SelectedOptionIndex + 1;
			UpdateCalendar();
		}

		private void UpdateCalendar()
		{
			DateTime dateTime = new DateTime(_currentYear, _currentMonth, 1);
			dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
			int num = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
			YearOfChallenges yearOfChallengesForYear = _challengeSystem.GetYearOfChallengesForYear(_currentYear);
			if (yearOfChallengesForYear == null)
			{
				for (int num2 = _calendarDayButtons.Length - 1; num2 >= 0; num2--)
				{
					_calendarDayButtons[num2].gameObject.SetActive(value: false);
				}
				return;
			}
			MonthOfDailyChallenges monthOfDailyChallenges = yearOfChallengesForYear.monthsOfDailyChallenges[_currentMonth - 1];
			for (int num3 = _calendarDayButtons.Length - 1; num3 >= 0; num3--)
			{
				_calendarDayButtons[num3].gameObject.SetActive(num3 < num);
				if (monthOfDailyChallenges.dailyChallenges.Length > num3)
				{
					string text = "";
					text = text + "<color=\"purple\">" + monthOfDailyChallenges.dailyChallenges[num3].city.ToString() + "</color> \n";
					ChallengeData[] challenges = monthOfDailyChallenges.dailyChallenges[num3].challenges;
					foreach (ChallengeData obj in challenges)
					{
						MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
						if (Enum.TryParse<StringId>(obj.challengeName, out var result))
						{
							motorwaysStringKey.InitWithStringId(result);
							text = text + StandaloneLocString.CreateString(_scope, motorwaysStringKey)?.ToString() + ",";
						}
					}
					_calendarDayButtons[num3].GetComponentInChildren<Text>().text = num3 + 1 + "th\n" + text;
				}
			}
		}

		public void OnDayButtonPressed(int day)
		{
			DateTime dateTime = new DateTime(_currentYear, _currentMonth, day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second);
			TimeSpan timeSpan = dateTime - DateTime.UtcNow;
			if (dateTime > DateTime.UtcNow)
			{
				if (GameDateTime.Backend is AdjustableGameDateTime adjustableGameDateTime)
				{
					adjustableGameDateTime.UtcOffset = default(TimeSpan);
					adjustableGameDateTime.UtcOffset += TimeSpan.FromDays(timeSpan.Days + 1);
				}
			}
			else if (GameDateTime.Backend is AdjustableGameDateTime adjustableGameDateTime2)
			{
				adjustableGameDateTime2.UtcOffset = default(TimeSpan);
				adjustableGameDateTime2.UtcOffset += TimeSpan.FromDays(timeSpan.Days);
			}
		}

		[UsedImplicitly]
		public void ClosePressed()
		{
			_popupStack.PopPopup();
		}

		public override void Reset()
		{
			base.Reset();
			_currentYear = GameDateTime.UtcNow.Year;
			_currentMonth = GameDateTime.UtcNow.Month;
		}
	}
}
