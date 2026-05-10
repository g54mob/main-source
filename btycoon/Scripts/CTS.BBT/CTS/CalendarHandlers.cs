using System;
using System.Globalization;
using System.Linq;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	[DefaultExecutionOrder(-100)]
	public class CalendarHandlers : MonoSingleton<CalendarHandlers>
	{
		[Space(10f)]
		[Header("Main Data")]
		[ReadOnly]
		public int CurrentDay = 1;

		[ReadOnly]
		public int CurrentMonth = 1;

		[ReadOnly]
		public int CurrentYear;

		[Space(10f)]
		[ReadOnly]
		public float ProgressPercentCurrentMonth;

		[Space(10f)]
		[ReadOnly]
		public int NBDaysLastMonth;

		[ReadOnly]
		public int NBDaysCurrentMonth = 31;

		[SerializeField]
		private string _chineseJapaneseDay;

		[SerializeField]
		private string _chineseJapaneseMounth;

		[SerializeField]
		private string _koreanDay;

		[SerializeField]
		private string _koreanMounth;

		[Space(10f)]
		[Header("Debug")]
		[SerializeField]
		private float _speedTime = 1f;

		private int _isInitialized;

		private float _secondsPerDay = 1f;

		private float _timeInSeconds;

		private bool _extendedMonth = true;

		private bool _leapYear;

		private Locale _currentLocale;

		private CultureInfo _cultureInfo;

		private string[] _monthNames;

		private string _fullDate;

		public static event Action CalendarLoaded;

		public static event Action NewDay;

		public static event Action NewMonth;

		public static event Action NewYear;

		public static event Action NewMonthAfterYearChanged;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			SceneReset.Reset += EventReset;
			LocalizationSettings.SelectedLocaleChanged += EventLocaleChanged;
			SaveManager.OnLoadingFinished += GameData_OnLoadingFinished;
		}

		private void Start()
		{
			EventLocaleChanged();
		}

		private void Update()
		{
			if (_isInitialized != 0)
			{
				MainExecution();
			}
		}

		private void OnDisable()
		{
			SceneReset.Reset -= EventReset;
			LocalizationSettings.SelectedLocaleChanged -= EventLocaleChanged;
			SaveManager.OnLoadingFinished -= GameData_OnLoadingFinished;
		}

		private void GameData_OnLoadingFinished()
		{
			CalendarHandlers.CalendarLoaded?.Invoke();
		}

		private void EventReset()
		{
			CurrentDay = 1;
			CurrentMonth = 1;
			CurrentYear = 0;
			NBDaysCurrentMonth = 31;
			_extendedMonth = true;
			_secondsPerDay = MonoSingleton<TimeController>.Instance._dayDurationInSeconds;
			_isInitialized = 1;
		}

		private void EventLocaleChanged(Locale value = null)
		{
			_currentLocale = LocalizationSettings.SelectedLocale;
			_cultureInfo = CultureInfo.GetCultureInfo(_currentLocale.Identifier.Code);
			switch (_currentLocale.LocaleName)
			{
			case "Japanese":
			case "Chinese (Simplified)":
			case "Chinese (Traditional)":
				_monthNames = CreateChineseJapaneseMounth();
				return;
			case "Korean":
				_monthNames = CreateKoreanMounth();
				return;
			}
			_monthNames = _cultureInfo.DateTimeFormat.AbbreviatedMonthNames.Select((string name) => name.TrimEnd('.')).ToArray();
		}

		private string[] CreateChineseJapaneseMounth()
		{
			string[] array = new string[12];
			for (int i = 0; i < 12; i++)
			{
				array[i] = i + 1 + " " + _chineseJapaneseMounth;
			}
			return array;
		}

		private string[] CreateKoreanMounth()
		{
			string[] array = new string[12];
			for (int i = 0; i < 12; i++)
			{
				array[i] = i + 1 + " " + _koreanMounth;
			}
			return array;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void NextMounth()
		{
			_timeInSeconds += _secondsPerDay * (float)NBDaysCurrentMonth;
		}

		private void MainExecution()
		{
			_timeInSeconds += Time.deltaTime * _speedTime;
			if (_timeInSeconds >= _secondsPerDay)
			{
				_timeInSeconds -= _secondsPerDay;
				CurrentDay++;
				bool flag = false;
				if (CurrentMonth == 2 && CurrentDay > (_leapYear ? 29 : 28))
				{
					NBDaysLastMonth = CurrentDay;
					CurrentDay = 1;
					CurrentMonth++;
					_extendedMonth = IsItAnExtendedMonth(CurrentMonth);
					CalendarHandlers.NewMonth?.Invoke();
					flag = true;
				}
				else if (CurrentDay > (_extendedMonth ? 31 : 30))
				{
					NBDaysLastMonth = CurrentDay;
					CurrentDay = 1;
					CurrentMonth++;
					_extendedMonth = IsItAnExtendedMonth(CurrentMonth);
					CalendarHandlers.NewMonth?.Invoke();
					flag = true;
				}
				if (CurrentMonth > 12)
				{
					CurrentMonth = 1;
					CurrentYear++;
					_leapYear = IsItALeapYear(CurrentYear);
					CalendarHandlers.NewYear?.Invoke();
				}
				if (flag)
				{
					CalendarHandlers.NewMonthAfterYearChanged?.Invoke();
				}
				GetProgressPercent();
				CalendarHandlers.NewDay?.Invoke();
			}
		}

		private void GetProgressPercent()
		{
			if (CurrentMonth == 2)
			{
				NBDaysCurrentMonth = (_leapYear ? 29 : 28);
			}
			else
			{
				NBDaysCurrentMonth = (_extendedMonth ? 31 : 30);
			}
			ProgressPercentCurrentMonth = (float)CurrentDay / (float)NBDaysCurrentMonth;
		}

		public string GetFullDateString()
		{
			switch (_currentLocale.LocaleName)
			{
			case "Japanese":
			case "Chinese (Simplified)":
			case "Chinese (Traditional)":
				_fullDate = _monthNames[CurrentMonth - 1] + " " + CurrentDay + " " + _chineseJapaneseDay;
				break;
			case "Korean":
				_fullDate = _monthNames[CurrentMonth - 1] + " " + CurrentDay + " " + _koreanDay;
				break;
			default:
				_fullDate = CurrentDay + " " + _monthNames[CurrentMonth - 1];
				break;
			}
			return _fullDate.ToUpper();
		}

		public string GetMonthDateString()
		{
			Locale selectedLocale = LocalizationSettings.SelectedLocale;
			CultureInfo.GetCultureInfo(selectedLocale.Identifier.Code);
			string[] array;
			switch (selectedLocale.LocaleName)
			{
			case "Japanese":
			case "Chinese (Simplified)":
			case "Chinese (Traditional)":
				array = CreateChineseJapaneseMounth();
				break;
			case "Korean":
				array = CreateKoreanMounth();
				break;
			default:
				array = _cultureInfo.DateTimeFormat.MonthNames.Select((string name) => name.TrimEnd('.')).ToArray();
				break;
			}
			return array[CurrentMonth - 1].ToUpper();
		}

		private bool IsItAnExtendedMonth(int value)
		{
			if (value != 1 && value != 3 && value != 5 && value != 7 && value != 8 && value != 10)
			{
				return value == 12;
			}
			return true;
		}

		private bool IsItALeapYear(int value)
		{
			if (value % 4 == 0)
			{
				if (value % 100 == 0)
				{
					return value % 400 == 0;
				}
				return true;
			}
			return false;
		}
	}
}
