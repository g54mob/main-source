using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_ReviewPanelManager : MonoSingleton<UI_ReviewPanelManager>
	{
		[SerializeField]
		private UI_ReviewMounth _currentMounth;

		[SerializeField]
		private UI_ReviewMounth _lastMounth;

		private void SetLastMounthFromCurrent()
		{
			_lastMounth.SetValuesFromOther(_currentMounth);
		}

		protected override void SingletonAwake()
		{
			CalendarHandlers.NewMonthAfterYearChanged += CalendarHandlers_NewMonthAfterYearChanged;
		}

		protected override void OnSingletonDestroy()
		{
			CalendarHandlers.NewMonthAfterYearChanged -= CalendarHandlers_NewMonthAfterYearChanged;
		}

		private void CalendarHandlers_NewMonthAfterYearChanged()
		{
			_lastMounth.SetValuesFromOther(_currentMounth);
			_currentMounth.ClearValues();
		}

		public void Clear()
		{
			_currentMounth.ClearValues();
			_lastMounth.ClearValues();
		}

		public void Load(ReviewManagerSaveStruct save)
		{
			Clear();
			_currentMounth.LoadStruct(save.CurrentMounth);
			_lastMounth.LoadStruct(save.LastMounth);
		}

		public ReviewManagerSaveStruct Save()
		{
			return new ReviewManagerSaveStruct
			{
				CurrentMounth = _currentMounth.SaveStruct(),
				LastMounth = _lastMounth.SaveStruct()
			};
		}
	}
}
