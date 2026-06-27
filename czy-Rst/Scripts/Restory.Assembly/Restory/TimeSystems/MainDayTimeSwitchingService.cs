using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.TimeSystems
{
	public class MainDayTimeSwitchingService : MonoBehaviour, ITimeChangeReceiver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private GameCalendar gameCalendar;

		private TimeSettingsProvidingService settings;

		private MainDayTimes currentDayTime;

		private MainDayTimes previousDayTime;

		private MainDayTimeSwitchingServiceSaveData restoredState;

		public MainDayTimes CurrentDayTime
		{
			get
			{
				return currentDayTime;
			}
			private set
			{
				if (value != currentDayTime)
				{
					previousDayTime = currentDayTime;
					currentDayTime = value;
					Debug.Log("Time is changing to " + currentDayTime);
					this.OnDayTimeChanged?.Invoke();
				}
			}
		}

		public MainDayTimes PreviousDayTime => previousDayTime;

		public event Action OnDayTimeChanged;

		[Inject]
		private void Construct(TimeSettingsProvidingService settings, GameCalendar gameCalendar)
		{
			this.settings = settings;
			this.gameCalendar = gameCalendar;
		}

		public void OnDisable()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void ProcessTimeChanged()
		{
			DetermineCurrentDayTime();
		}

		public void ForceEndDay()
		{
			gameCalendar.RemoveSubscriber(this);
			CurrentDayTime = MainDayTimes.StoreClosedTime;
		}

		private void DetermineCurrentDayTime()
		{
			TimeSpan timeSpan = settings.WorkDayEndTime.InTimeSpan();
			TimeSpan timeSpan2 = settings.MorningStartTime.InTimeSpan();
			if (timeSpan > timeSpan2)
			{
				if (gameCalendar.CurrentDateTime.TimeOfDay >= timeSpan)
				{
					CurrentDayTime = MainDayTimes.AfterWork;
				}
				else if (gameCalendar.CurrentDateTime.TimeOfDay >= settings.EveningStartTime.InTimeSpan())
				{
					CurrentDayTime = MainDayTimes.Evening;
				}
				else if (gameCalendar.CurrentDateTime.TimeOfDay >= settings.AfternoonStartTime.InTimeSpan())
				{
					CurrentDayTime = MainDayTimes.Afternoon;
				}
				else if (gameCalendar.CurrentDateTime.TimeOfDay >= timeSpan2)
				{
					CurrentDayTime = MainDayTimes.Morning;
				}
			}
			else if (gameCalendar.CurrentDateTime.TimeOfDay >= settings.EveningStartTime.InTimeSpan())
			{
				CurrentDayTime = MainDayTimes.Evening;
			}
			else if (gameCalendar.CurrentDateTime.TimeOfDay >= settings.AfternoonStartTime.InTimeSpan())
			{
				CurrentDayTime = MainDayTimes.Afternoon;
			}
			else if (gameCalendar.CurrentDateTime.TimeOfDay >= timeSpan2)
			{
				CurrentDayTime = MainDayTimes.Morning;
			}
			else if (gameCalendar.CurrentDateTime.TimeOfDay >= timeSpan)
			{
				CurrentDayTime = MainDayTimes.AfterWork;
			}
		}

		public object CaptureState()
		{
			try
			{
				return new MainDayTimeSwitchingServiceSaveData
				{
					DayTime = CurrentDayTime
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<MainDayTimeSwitchingServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			MainDayTimeSwitchingServiceSaveData mainDayTimeSwitchingServiceSaveData = restoredState;
			if (mainDayTimeSwitchingServiceSaveData != null && mainDayTimeSwitchingServiceSaveData.DayTime == MainDayTimes.StoreClosedTime)
			{
				SetTimeToMorning();
			}
			DetermineCurrentDayTime();
			gameCalendar.AddSubscriber(this);
		}

		private void SetTimeToMorning()
		{
			int num = ((!(gameCalendar.CurrentDateTime.TimeOfDay < settings.MorningStartTime.InTimeSpan())) ? 1 : 0);
			DateTime currentDateTime = gameCalendar.CurrentDateTime - gameCalendar.CurrentDateTime.TimeOfDay + TimeSpan.FromDays(num) + settings.MorningStartTime.InTimeSpan();
			Debug.Log("Switching time from " + $"{gameCalendar.CurrentDateTime.Month}/{gameCalendar.CurrentDateTime.Day} {gameCalendar.CurrentDateTime.TimeOfDay} " + $"to {currentDateTime.Month}/{currentDateTime.Day} {currentDateTime.TimeOfDay}");
			gameCalendar.CurrentDateTime = currentDateTime;
		}
	}
}
